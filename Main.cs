using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Advanced_Combat_Tracker;
using ActCurseTracker.Model;
using ActCurseTracker.UI;

namespace ActCurseTracker
{
    public class Main : IActPluginV1
    {
        public static int PLUGIN_ID = 99;
        public const string PLUGIN_NAME = "Curse Tracker";

        public event Action<Cure> CureDetected;
        private void OnCureDetected(Cure cure)
        {
            if (_hud.InvokeRequired) {
                _hud.Invoke((Action<Cure>)OnCureDetected, new object[] { cure });
            }
            else {
                if (CureDetected != null) CureDetected(cure);
            }
        }

        // These elements are given to us by the plugin engine
        private TabPage _pluginScreenSpace = null;
        private Label _pluginStatusText = null;
        private ButtonPainted _btnShowCurseTracker = null;

        private PluginTab _tab = null;
        private HudForm _hud = null;
        private Regex _regexCureOther = new Regex(@"\] (?<healer>[A-Za-z]+)('s)?(')? Cure Curse relieves (?<curse>.+) from (?<victim>[A-Za-z]+)\.", RegexOptions.Compiled);
        private Regex _regexCureSelf = new Regex(@"\] YOUR Cure Curse relieves YOU of (?<curse>.+)\.", RegexOptions.Compiled);
        private Regex _regexWhoRaidInit = new Regex(@"\] /whoraid search results .*", RegexOptions.Compiled);
        private Regex _regexWhoRaidPlayer = new Regex(@"\] \[[0-9]+ [^ ]+ (?<player>[A-Za-z]+) .*", RegexOptions.Compiled);
        private bool _parsingWhoRaid = false;
        private int _skipLines = 0;
        private List<string> _activatePlayers = new List<string>();
        private List<Cure> _cures = new List<Cure>();

        public Main()
        {
            _btnShowCurseTracker = new ButtonPainted() {
                Text = "Show Curses",
                AutoSize = true
            };
            _btnShowCurseTracker.Click += (s, e) => {
                if (_hud != null) {
                    if (!_hud.Visible) {
                        ShowHud();
                    }
                    else {
                        HideHud();
                    }
                }
            };
        }

        // The entry-point from the ACT plugin engine, called when the plugin is loaded
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _pluginScreenSpace = pluginScreenSpace;
            _pluginStatusText = pluginStatusText;

            try {
                var pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);

                Logger.Log("Initializing plugin");
                Logger.Log($"Version: {GetType().Assembly.GetName().Version}");
                Logger.Log($"Plugin: {pluginData.pluginFile.FullName} ({File.GetLastWriteTime(pluginData.pluginFile.FullName)})");
                Logger.Log($"OS: {Environment.OSVersion} ({(Environment.Is64BitProcess ? "64" : "32")}-bit)");
                Logger.Log($"DotNet: {RuntimeInformation.FrameworkDescription}");
                Logger.Log($"ACT: {Environment.CurrentDirectory} (v{ActGlobals.oFormActMain.GetVersion()})");

                StringBuilder sbScreens = new StringBuilder();
                sbScreens.AppendLine("Screens:");
                int screenNum = 1;
                foreach (var screen in Screen.AllScreens) {
                    sbScreens.AppendLine($"  {screenNum}: {screen.DeviceName}{(screen.Primary ? " (Primary)" : "")}: {screen.Bounds}");
                    screenNum++;
                }
                Logger.Log(sbScreens.ToString().Trim());

                Logger.Log(Settings.Info());

                _tab = new PluginTab(this);
                _tab.Dock = DockStyle.Fill;
                _pluginScreenSpace.Controls.Add(_tab);
                _pluginScreenSpace.Text = PLUGIN_NAME;

                _hud = new HudForm(this);
                _cures.Clear();

                // Wire-up the ACT plugin engine to pass us log line read events
                ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;
                ActGlobals.oFormActMain.OnLogLineRead += oFormActMain_OnLogLineRead;

                // Delay opening the popup until the main window is finished
                ActGlobals.oFormActMain.ActLifecycleChanged += OFormActMain_ActLifecycleChanged;

                // Update pattern for file download
                // See: https://gist.github.com/EQAditu/4d6e3a1945fed2199f235fedc1e3ec56#Act_Plugin_Update.cs
                ActGlobals.oFormActMain.UpdateCheckClicked += OFormActMain_UpdateCheckClicked;
                if (ActGlobals.oFormActMain.GetAutomaticUpdatesAllowed()) {
                    new System.Threading.Thread(new System.Threading.ThreadStart(OFormActMain_UpdateCheckClicked)) { IsBackground = true }.Start();
                }

                ActGlobals.oFormActMain.CornerControlAdd(_btnShowCurseTracker);
            }
            catch { }

            _pluginStatusText.Text = "Enabled";
        }

        // The exit-point from the ACT plugin engine, called when the plugin is unloaded
        public void DeInitPlugin()
        {
            Logger.Log("Deinitializing plugin");

            ActGlobals.oFormActMain.CornerControlRemove(_btnShowCurseTracker);

            try {
                ActGlobals.oFormActMain.ActLifecycleChanged -= OFormActMain_ActLifecycleChanged;
                ActGlobals.oFormActMain.UpdateCheckClicked -= OFormActMain_UpdateCheckClicked;
                ActGlobals.oFormActMain.OnLogLineRead -= oFormActMain_OnLogLineRead;

                _hud.Close();
                _hud = null;
                _tab = null;
            }
            catch (Exception ex) {
                Logger.Log(ex.Message);
            }
            finally {
                Logger.Log("Deinitialized plugin");
            }

            _pluginStatusText.Text = "Disabled";
        }

        // This is called each time ACT detects a new log line
        public void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (isImport) return;

            if (_skipLines > 0) {
                _skipLines--;
                return;
            }

            string line = logInfo.logLine;
            try {
                if (_parsingWhoRaid) {
                    Match matchWhoRaidPlayer = _regexWhoRaidPlayer.Match(line);
                    if (matchWhoRaidPlayer.Success) {
                        string player = matchWhoRaidPlayer.Groups["player"].Value;
                        _activatePlayers.Add(player);
                    }
                    else {
                        _parsingWhoRaid = false;

                        foreach (var healer in Settings.Current.Healers) {
                            healer.Active = _activatePlayers.Contains(healer.Name);
                        }
                        Settings.Current.Save();
                    }
                }
                else {
                    Match matchWhoRaidInit = _regexWhoRaidInit.Match(line);
                    if (matchWhoRaidInit.Success) {
                        _parsingWhoRaid = true;
                        _activatePlayers.Clear();
                        _skipLines = 1;
                    }
                    else {
                        Match matchCureOther = _regexCureOther.Match(line);
                        Cure cure = null;
                        string youName = ActGlobals.charName;
                        if (matchCureOther.Success) {
                            string healer = matchCureOther.Groups["healer"].Value;
                            if (healer.Equals("YOUR"))
                                healer = youName;
                            string victim = matchCureOther.Groups["victim"].Value;
                            if (victim.Equals("YOU"))
                                victim = youName;
                            cure = new Cure() {
                                Healer = healer,
                                Victim = victim,
                                Curse = matchCureOther.Groups["curse"].Value
                            };
                        }
                        else {
                            Match matchCureSelf = _regexCureSelf.Match(line);
                            if (matchCureSelf.Success) {
                                cure = new Cure() {
                                    Healer = youName,
                                    Victim = youName,
                                    Curse = matchCureSelf.Groups["curse"].Value
                                };
                            }
                        }
                        if (cure != null) {
                            cure.Time = logInfo.detectedTime;
                            _cures.Add(cure);
                            OnCureDetected(cure);
                        }
                    }
                }
            }
            catch { } // Black hole...
        }
        private void OFormActMain_ActLifecycleChanged(ActLifecycleEventArgs args)
        {
            if (args.CurrentState == ActLifecycleEventArgs.ActLifecycleEnum.FormActMainShown && Settings.Current.AutoOpen) {
                ShowHud();
            }
        }

        public void OFormActMain_UpdateCheckClicked()
        {
            // This ID must be the same ID used on ACT's website.
            int pluginId = PLUGIN_ID;
            if (pluginId < 0) return;

            string pluginName = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;
            try {
                Version localVersion = GetType().Assembly.GetName().Version;
                Version remoteVersion = new Version(ActGlobals.oFormActMain.PluginGetRemoteVersion(pluginId).TrimStart(new char[] { 'v' }));
                if (remoteVersion > localVersion) {
                    DialogResult result = MessageBox.Show(
                        $"There is an updated version of the {pluginName} plugin.  Update it now?\n\n(If there is an update to ACT, you should click No and update ACT first.)",
                        "New Version", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) {
                        FileInfo updatedFile = ActGlobals.oFormActMain.PluginDownload(pluginId);
                        ActPluginData pluginData = ActGlobals.oFormActMain.PluginGetSelfData(this);
                        pluginData.pluginFile.Delete();
                        updatedFile.MoveTo(pluginData.pluginFile.FullName);

                        // You can choose to simply restart the plugin, if the plugin can properly clean-up in DeInit
                        // and has no external assemblies that update.
                        ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, false);
                        Application.DoEvents();
                        ThreadInvokes.CheckboxSetChecked(ActGlobals.oFormActMain, pluginData.cbEnabled, true);
                    }
                }
            }
            catch (Exception ex) {
                ActGlobals.oFormActMain.WriteExceptionLog(ex, $"Plugin Update Check - {pluginName}");
            }
        }

        public void ShowHud(bool reportOnly = false)
        {
            if (!reportOnly) {
                _hud.Show();
                _hud.WindowState = FormWindowState.Normal;
                _hud.Focus();
                if (Settings.Current.PopupLastW > 0 && Settings.Current.PopupLastH > 0) {
                    _hud.SetBounds(
                        Settings.Current.PopupLastX,
                        Settings.Current.PopupLastY,
                        Settings.Current.PopupLastW,
                        Settings.Current.PopupLastH
                    );
                }

                _hud.TopMost = Settings.Current.TopMost;
            }

            Logger.Log($"Showing window at {_hud.Left},{_hud.Top} {_hud.Width}x{_hud.Height}, on {Screen.FromControl(_hud).DeviceName}");
        }

        public void HideHud(bool reportOnly = false)
        {
            _hud.Hide();
        }

        public void ShowOptions(Healer selectHealer = null)
        {
            bool foundTab = false;
            foreach (Control c in ActGlobals.oFormActMain.Controls) {
                if (c.GetType().IsSubclassOf(typeof(TabControl))) {
                    TabControl cMainTabs = (TabControl)c;
                    foreach (TabPage p in cMainTabs.Controls) {
                        if (p.Text == "Plugins") {
                            cMainTabs.SelectedTab = p;
                            foreach (Control c2 in p.Controls) {
                                if (c2.GetType().IsSubclassOf(typeof(TabControl))) {
                                    TabControl cPluginTabs = (TabControl)c2;
                                    foreach (TabPage p2 in cPluginTabs.Controls) {
                                        if (p2.Text == PLUGIN_NAME) {
                                            cPluginTabs.SelectedTab = p2;
                                            foundTab = true;
                                            if (selectHealer != null) {
                                                _tab.SelectHealer(selectHealer);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (!foundTab) {
                MessageBox.Show(
                    $"Please open the \"Plugins\" tab in the ACT main window,{Environment.NewLine}and then select the \"{PLUGIN_NAME}\" tab.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
