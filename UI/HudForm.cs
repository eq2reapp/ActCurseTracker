using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Advanced_Combat_Tracker;
using ActCurseTracker.Model;
using System.Text;
using System.Threading.Tasks;

namespace ActCurseTracker.UI
{
    public partial class HudForm : Form
    {
        private Main _main = null;
        private Rectangle _curePanelInitialBounds;
        private bool _showingCures = true;
        private List<HealerTimer> _timers = new List<HealerTimer>();
        private System.Timers.Timer _locationTimer = null;

        public HudForm(Main main)
        {
            _main = main;

            InitializeComponent();

            dgCures.Columns.Add("time", "Time");
            dgCures.Columns[dgCures.Columns.Count - 1].FillWeight = 75;
            dgCures.Columns.Add("healer", "Healer");
            dgCures.Columns[dgCures.Columns.Count - 1].FillWeight = 100;
            dgCures.Columns.Add("victim", "Victim");
            dgCures.Columns[dgCures.Columns.Count - 1].FillWeight = 100;
            dgCures.Columns.Add("curse", "Curse");
            dgCures.Columns[dgCures.Columns.Count - 1].FillWeight = 150;

            if (main != null) {
                main.CureDetected += Main_CureDetected;
            }

            Settings.SettingsSaved += SettingsSaved;

            _locationTimer = new System.Timers.Timer();
            _locationTimer.Interval = 1000;
            _locationTimer.AutoReset = false;
            _locationTimer.Elapsed += LocationTimerElapsed;
        }

        private void Hud_Load(object sender, EventArgs e)
        {
            HideCures();

            SetColours();
            LoadHealerTimers();
        }

        private void HudForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void HudForm_Shown(object sender, EventArgs e)
        {
            SetColours();
            ResizeTimers();
        }

        private void HudForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeTimers();

            if (_locationTimer != null && !_locationTimer.Enabled) {
                _locationTimer.Start();
            }
        }

        private void HudForm_LocationChanged(object sender, EventArgs e)
        {
            if (_locationTimer != null) {
                if (_locationTimer.Enabled) {
                    _locationTimer.Stop();
                }
                _locationTimer.Start();
            }
        }

        private void LocationTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired) {
                Invoke(new Action(() => { SaveLocation(); }));
            }
            else {
                SaveLocation();
            }
        }

        private void Main_CureDetected(Cure cure)
        {
            Logger.Log($"{cure.Healer} cured {cure.Victim} of {cure.Curse}");

            dgCures.Rows.Insert(0, new object[] {
                cure.Time.ToString("H':'mm':'ss"),
                cure.Healer,
                cure.Victim,
                cure.Curse
            });

            var timer = GetTimerForHealer(cure.Healer);
            if (timer != null) {
                timer.Restart();
                LoadHealerTimers();
            }
            else {
                if (Settings.Current.AutoAdd) {
                    // Check if an existing healer is just inactive
                    var existing = Settings.Current.GetHealerByName(cure.Healer);
                    if (existing != null) {
                        existing.Active = true;
                    }
                    else {
                        var healer = new Healer() {
                            Name = cure.Healer,
                            Group = Healer.DEFAULT_GROUP,
                            RecastSeconds = Healer.DEFAULT_RECAST,
                            Colour = Healer.DEFAULT_COLOUR,
                            Active = true
                        };
                        Settings.Current.Healers.Add(healer);
                    }

                    Settings.Current.Save();
                    LoadHealerTimers();

                    // Now that it's added, we still need to start the new timer
                    timer = GetTimerForHealer(cure.Healer);
                    if (timer != null) {
                        timer.Restart();
                        LoadHealerTimers();
                    }
                }
            }
        }

        private void SettingsSaved()
        {
            if (InvokeRequired) {
                Invoke(new Action(() => { SettingsSaved(); }));
            }
            else {
                SetColours();

                LoadHealerTimers();
            }
        }

        private void HealerTimerDone(HealerTimer obj)
        {
            LoadHealerTimers();
        }

        private void HealerTimerClicked(HealerTimer timer)
        {
            _main.ShowOptions(timer.Healer);
        }

        public static Size GetDefaultSize()
        {
            return (new HudForm(null)).Size;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            _main.ShowOptions();
        }

        private void btnShowDgCures_Click(object sender, EventArgs e)
        {
            if (_showingCures) {
                HideCures();
                btnShowDgCures.Text = "Cures";
            }
            else {
                ShowCures();
                btnShowDgCures.Text = "Hide";
            }
            ResizeTimers();
        }

        private void btnClearDgCures_Click(object sender, EventArgs e)
        {
            dgCures.Rows.Clear();

            foreach (var timer in _timers) {
                timer.Stop();
            }
        }

        private void SetColours()
        {
            BackColor = Settings.GetMainBackgroundColour(true);
            ForeColor = Settings.GetMainForegroundColour(true);

            dgCures.EnableHeadersVisualStyles = false;
            dgCures.BackgroundColor = Settings.GetDatagridBackgroundColour(true);
            dgCures.ForeColor = Settings.GetDatagridForegroundColour(true);
            dgCures.DefaultCellStyle.BackColor = dgCures.BackgroundColor;
            dgCures.DefaultCellStyle.ForeColor = dgCures.ForeColor;
            dgCures.ColumnHeadersDefaultCellStyle.BackColor = dgCures.BackgroundColor;
            dgCures.ColumnHeadersDefaultCellStyle.ForeColor = dgCures.ForeColor;
        }

        private void HideCures()
        {
            _curePanelInitialBounds = pnlCures.Bounds;
            pnlCures.Height = pnlCuresControls.Height;
            dgCures.Hide();
            _showingCures = false;
        }

        private void ShowCures()
        {
            dgCures.Show();
            pnlCures.Bounds = _curePanelInitialBounds;
            _showingCures = true;
        }

        private HealerTimer GetTimerForHealer(string name)
        {
            return _timers.Find(t => t.Healer.Name.ToLower().Equals(name.ToLower()));
        }

        private void LoadHealerTimers()
        {
            string initialSequence = "";
            foreach (var timer in _timers) {
                initialSequence += timer.Healer.Name;
            }

            // Prune our existing timers
            List<HealerTimer> removeTimers = new List<HealerTimer>();
            foreach (var timer in _timers) {
                var healer = timer.Healer;
                var existing = Settings.Current.GetHealerByName(healer.Name);
                if (existing == null || !existing.Active || 
                    existing.RecastSeconds != healer.RecastSeconds || existing.Colour != healer.Colour ||
                    existing.Pinned != healer.Pinned) {
                        removeTimers.Add(timer);
                }
            }
            foreach (HealerTimer timer in removeTimers) {
                _timers.Remove(timer);
            }

            // Add any from settings that we don't have
            List<HealerTimer> addTimers = new List<HealerTimer>();
            foreach (Healer healer in Settings.Current.Healers) {
                if (healer.Active) {
                    var existing = GetTimerForHealer(healer.Name);
                    if (existing == null) {
                        var timer = new HealerTimer(new Healer(healer));
                        timer.TimerDone += HealerTimerDone;
                        timer.TimerClicked += HealerTimerClicked;
                        addTimers.Add(timer);
                    }
                }
            }
            foreach (HealerTimer timer in addTimers) {
                _timers.Add(timer);
            }

            _timers.Sort((x, y) => {
                int cmp = -(x.Healer.Pinned ? 1 : -1).CompareTo(y.Healer.Pinned ? 1 : -1);
                if (cmp == 0) {
                    cmp = (x.Running ? 1 : -1).CompareTo(y.Running ? 1 : -1);
                }
                if (cmp == 0) {
                    cmp = -x.Time.CompareTo(y.Time);
                }
                if (cmp == 0) {
                    cmp = x.Healer.Name.CompareTo(y.Healer.Name);
                }
                return cmp;
            });

            bool rebuild = removeTimers.Count > 0 || addTimers.Count > 0;
            if (!rebuild) {
                string newSequence = "";
                foreach (var timer in _timers) {
                    newSequence += timer.Healer.Name;
                }
                rebuild = newSequence != initialSequence;
            }
            if (rebuild) {
                pnlTimers.Controls.Clear();
                foreach (var timer in _timers) {
                    pnlTimers.Controls.Add(timer);
                }
            }
            ResizeTimers();
        }

        private void ResizeTimers()
        {
            int newWidth = Math.Max(pnlTimers.ClientSize.Width - 6, 1);
            foreach (var timer in _timers) {
                timer.Width = newWidth;
            }
        }

        private void SaveLocation()
        {
            Settings.Current.PopupLastX = Location.X;
            Settings.Current.PopupLastY = Location.Y;
            Settings.Current.PopupLastW = Width;
            Settings.Current.PopupLastH = Height;
            Settings.Current.Save();
        }
    }
}
