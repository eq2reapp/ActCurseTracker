using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

using Advanced_Combat_Tracker;
using ActCurseTracker.Model;
using ActCurseTracker.UI;
using System.Windows.Forms;

namespace ActCurseTracker
{
    public class Settings
    {
        public static event Action SettingsSaved;
        private static void OnSettingsSaved() { if (SettingsSaved != null) SettingsSaved(); }

        private static Settings _instance = new Settings();
        public static Settings Current {  get {  return _instance; } }

        private string _settingsFile = null;
        private FontColorControl _miniParseColours = null;

        public int PopupLastX = 0;
        public int PopupLastY = 0;
        public int PopupLastW = 0;
        public int PopupLastH = 0;
        public bool AutoOpen = false;
        public bool TopMost = false;
        public bool MiniBg = false;
        public bool AutoAdd = true;
        public bool WhoRaidActivate = false;
        public List<Healer> Healers = new List<Healer>();

        private Settings()
        {
            try {
                _settingsFile = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "Config\\CurseTracker.config.xml");
                Load();
            }
            catch (Exception ex) {
                Logger.Log("Unable to load from settings file: " + _settingsFile);
                Logger.Log(ex.ToString());
            }

            List<Control> miniParseOptions = new List<Control>();
            if (ActGlobals.oFormActMain.OptionsControlSets.TryGetValue(@"Output Display\Mini Parse Window", out miniParseOptions)) {
                foreach (Control parent in miniParseOptions) {
                    foreach (Control child in parent.Controls) {
                        if (child is FontColorControl) {
                            _miniParseColours = child as FontColorControl;
                        }
                    }
                }
            }
        }

        private void Load()
        {
            if (_settingsFile == null || !File.Exists(_settingsFile)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(_settingsFile);
            XmlNode rootNode = doc.SelectSingleNode("Settings");

            var minSize = HudForm.GetDefaultSize();
            PopupLastX = RetrieveSetting<int>(rootNode, "PopupLastX", minSize.Width);
            PopupLastY = RetrieveSetting<int>(rootNode, "PopupLastY", minSize.Height);
            PopupLastW = RetrieveSetting<int>(rootNode, "PopupLastW", minSize.Width);
            PopupLastH = RetrieveSetting<int>(rootNode, "PopupLastH", minSize.Height);
            AutoOpen = RetrieveSetting<bool>(rootNode, "AutoOpen", false);
            TopMost = RetrieveSetting<bool>(rootNode, "TopMost", false);
            MiniBg = RetrieveSetting<bool>(rootNode, "MiniBg", false);
            AutoAdd = RetrieveSetting<bool>(rootNode, "AutoAdd", false);
            WhoRaidActivate = RetrieveSetting<bool>(rootNode, "WhoRaidActivate", false);

            LoadHealers(rootNode.SelectSingleNode("Healers"));
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", null, null));

            XmlElement rootNode = doc.CreateElement("Settings");
            doc.AppendChild(rootNode);

            AttachChildNode(rootNode, "PopupLastX", PopupLastX.ToString());
            AttachChildNode(rootNode, "PopupLastY", PopupLastY.ToString());
            AttachChildNode(rootNode, "PopupLastW", PopupLastW.ToString());
            AttachChildNode(rootNode, "PopupLastH", PopupLastH.ToString());
            AttachChildNode(rootNode, "AutoOpen", AutoOpen.ToString());
            AttachChildNode(rootNode, "TopMost", TopMost.ToString());
            AttachChildNode(rootNode, "MiniBg", MiniBg.ToString());
            AttachChildNode(rootNode, "AutoAdd", AutoAdd.ToString());
            AttachChildNode(rootNode, "WhoRaidActivate", WhoRaidActivate.ToString());

            XmlElement healersNode = AttachChildNode(rootNode, "Healers", null);
            SaveHealers(healersNode);

            try {
                doc.Save(_settingsFile);
                OnSettingsSaved();
            }
            catch (Exception ex) {
                Logger.Log("Unable to save to settings file: " + _settingsFile);
                Logger.Log(ex.ToString());
            }
        }

        public static string Info()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Settings:");
            sb.AppendLine("  File = " + _instance._settingsFile.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "%AppData%"));
            sb.AppendLine("  PopupLastX = " + _instance.PopupLastX.ToString());
            sb.AppendLine("  PopupLastY = " + _instance.PopupLastY.ToString());
            sb.AppendLine("  PopupLastW = " + _instance.PopupLastW.ToString());
            sb.AppendLine("  PopupLastH = " + _instance.PopupLastH.ToString());
            sb.AppendLine("  AutoOpen = " + _instance.AutoOpen.ToString());
            sb.AppendLine("  TopMost = " + _instance.TopMost.ToString());
            sb.AppendLine("  MiniBg = " + _instance.MiniBg.ToString());
            sb.AppendLine("  AutoAdd = " + _instance.AutoAdd.ToString());
            sb.AppendLine("  WhoRaidActivate = " + _instance.WhoRaidActivate.ToString());
            sb.AppendLine("  Healers = [");
            foreach (Healer healer in _instance.Healers) {
                sb.AppendLine($"               {healer.Name} ({healer.RecastSeconds} sec)");
            }
            sb.AppendLine("  ]");

            return sb.ToString();
        }

        public Healer GetHealerByName(string name)
        {
            return _instance.Healers.Find(h => h.Name.ToLower().Equals(name.ToLower()));
        }

        public static Color GetMainBackgroundColour(bool allowMiniParseColours = false)
        {
            Color colour = ActGlobals.oFormActMain.ActColorSettings.MainWindowColors.BackColorSetting;
            if (allowMiniParseColours) {
                var miniParseColours = GetMiniParseColours();
                if (miniParseColours != null) {
                    colour = miniParseColours.BackColorSetting;
                }
            }
            return colour;
        }

        public static Color GetMainForegroundColour(bool allowMiniParseColours = false)
        {
            Color colour = ActGlobals.oFormActMain.ActColorSettings.MainWindowColors.ForeColorSetting;
            if (allowMiniParseColours) {
                var miniParseColours = GetMiniParseColours();
                if (miniParseColours != null) {
                    colour = miniParseColours.ForeColorSetting;
                }
            }
            return colour;
        }

        public static Color GetDatagridBackgroundColour(bool allowMiniParseColours = false)
        {
            Color colour = ActGlobals.oFormActMain.ActColorSettings.DataGridColors.BackColorSetting;
            if (allowMiniParseColours) {
                var miniParseColours = GetMiniParseColours();
                if (miniParseColours != null) {
                    colour = miniParseColours.BackColorSetting;
                }
            }
            return colour;
        }

        public static Color GetDatagridForegroundColour(bool allowMiniParseColours = false)
        {
            Color colour = ActGlobals.oFormActMain.ActColorSettings.DataGridColors.ForeColorSetting;
            if (allowMiniParseColours) {
                var miniParseColours = GetMiniParseColours();
                if (miniParseColours != null) {
                    colour = miniParseColours.ForeColorSetting;
                }
            }
            return colour;
        }

        public static FontColorControl GetMiniParseColours()
        {
            if (_instance.MiniBg && _instance._miniParseColours != null) {
                return _instance._miniParseColours;
            }
            return null;
        }

        private T RetrieveSetting<T>(XmlNode attachPoint, string name, T defaultVal)
        {
            T settingVal = defaultVal;

            XmlNode settingNode = attachPoint.SelectSingleNode(name);
            if (settingNode != null)
                settingVal = (T)Convert.ChangeType(settingNode.InnerText, typeof(T));

            return settingVal;
        }

        private void LoadHealers(XmlNode rootNode)
        {
            if (rootNode == null) return;

            Healers.Clear();
            foreach (XmlNode healerNode in rootNode.SelectNodes("Healer")) {
                string name = "Unknown";
                string group = Healer.DEFAULT_GROUP;
                int recast = 60;
                bool active = false;
                bool pinned = false;
                Color colour = Healer.DEFAULT_COLOUR;

                foreach (XmlNode childNode in healerNode.ChildNodes) {
                    string nodeVal = childNode.InnerText.Trim();
                    switch (childNode.Name.ToLower()) {
                        case "name":
                            name = nodeVal;
                            break;
                        case "group":
                            group = nodeVal;
                            break;
                        case "recast":
                            int.TryParse(nodeVal, out recast);
                            break;
                        case "active":
                            active = nodeVal.ToLower().Equals("true");
                            break;
                        case "pinned":
                            pinned = nodeVal.ToLower().Equals("true");
                            break;
                        case "colour":
                            TryParseColour(nodeVal, ref colour);
                            break;
                    }
                }

                Healers.Add(new Healer() {
                    Name = name,
                    Group = group,
                    RecastSeconds = recast,
                    Active = active,
                    Pinned = pinned,
                    Colour = colour
                });
            }
        }

        private void SaveHealers(XmlElement attachPoint)
        {
            foreach (Healer healer in Healers) {
                XmlElement statNode = AttachChildNode(attachPoint, "Healer", null);
                AttachChildNode(statNode, "Name", healer.Name);
                AttachChildNode(statNode, "Group", healer.Group);
                AttachChildNode(statNode, "Recast", healer.RecastSeconds.ToString());
                AttachChildNode(statNode, "Active", healer.Active.ToString());
                AttachChildNode(statNode, "Pinned", healer.Pinned.ToString());
                AttachChildNode(statNode, "Colour", ColourToString(healer.Colour));
            }
        }

        private XmlElement AttachChildNode(XmlElement parentNode, string name, string value)
        {
            XmlElement childNode = parentNode.OwnerDocument.CreateElement(name);
            if (value != null)
                childNode.InnerText = value;
            parentNode.AppendChild(childNode);

            return childNode;
        }

        private bool TryParseColour(string colourString, ref Color colour)
        {
            bool success = false;

            try {
                int r, g, b;
                string[] rgbParts = colourString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(rgbParts[0], out r) && int.TryParse(rgbParts[1], out g) && int.TryParse(rgbParts[2], out b))
                    colour = Color.FromArgb(Math.Min(255, Math.Max(0, r)), Math.Min(255, Math.Max(0, g)), Math.Min(255, Math.Max(0, b)));
                success = true;
            }
            catch { }

            return success;
        }

        private string ColourToString(Color colour)
        {
            return string.Format("{0},{1},{2}", colour.R, colour.G, colour.B);
        }
    }
}
