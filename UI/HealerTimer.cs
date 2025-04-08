using System;
using System.Drawing;
using System.Windows.Forms;

using Advanced_Combat_Tracker;
using ActCurseTracker.Model;
using System.Runtime.CompilerServices;

namespace ActCurseTracker.UI
{
    public partial class HealerTimer : UserControl
    {
        public event Action<HealerTimer> TimerDone;
        private void OnTimerDone(HealerTimer timer)
        {
            if (TimerDone != null) TimerDone(this);
        }

        public event Action<HealerTimer> TimerClicked;
        private void OnTimerClicked(HealerTimer timer)
        {
            if (TimerClicked != null) TimerClicked(this);
        }

        public Healer Healer { get; set; }
        public int Time { get; set; } = 0;
        public bool Running {  get {  return Time > 0; } }

        private Bitmap _buff = null;
        private System.Timers.Timer _tickTimer = null;
        private Color _initalBgColour;
        private Color _hoverColour;
        private SolidBrush _bFill = null;
        private SolidBrush _bOutline = null;
        private SolidBrush _bOutlineDark = null;
        private SolidBrush _bTime = null;
        private StringFormat _sfNearMid;
        private Font _fTime = null;

        public HealerTimer(Healer healer)
        {
            InitializeComponent();

            Healer = healer;

            _tickTimer = new System.Timers.Timer();
            _tickTimer.Interval = 1000;
            _tickTimer.AutoReset = true;
            _tickTimer.Elapsed += TickTimerElapsed;

            var c = Healer.Colour;
            var cBright = Color.FromArgb(Math.Min(255, c.R + 30), Math.Min(255, c.G + 30), Math.Min(255, c.B + 30));
            var cDark = Color.FromArgb(Math.Max(0, c.R - 30), Math.Max(0, c.G - 30), Math.Max(0, c.B - 30));
            _bOutline = new SolidBrush(cBright);
            _bOutlineDark = new SolidBrush(cDark);
            _bFill = new SolidBrush(c);
            _bTime = new SolidBrush(Settings.GetMainForegroundColour(false));

            _sfNearMid = new StringFormat(StringFormatFlags.NoWrap);
            _sfNearMid.Alignment = StringAlignment.Center;
            _sfNearMid.LineAlignment = StringAlignment.Center;
            _fTime = new Font(lblName.Font.FontFamily, lblName.Font.Size, FontStyle.Bold);

            Settings.SettingsSaved += SettingsSaved;
        }

        private void CustomDispose()
        {
            _tickTimer.Stop();
            _tickTimer.Dispose();

            if (_buff != null) _buff.Dispose();
            if (_bFill != null) _bFill.Dispose();
            if (_bOutline != null) _bOutline.Dispose();
            if (_bOutlineDark != null) _bOutlineDark.Dispose();
            if (_bTime != null) _bTime.Dispose();
            if (_sfNearMid != null) _sfNearMid.Dispose();
            if (_fTime != null) _fTime.Dispose();
        }

        private void HealerTimer_Load(object sender, EventArgs e)
        {
            SetColours();

            lblName.Text = Healer.Name;
            RepaintProgress();
        }

        private void SettingsSaved()
        {
            if (InvokeRequired) {
                Invoke(new Action(() => { SettingsSaved(); }));
            }
            else {
                SetColours();
            }
        }

        private void HealerTimer_MouseLeave(object sender, EventArgs e)
        {
            BackColor = _initalBgColour;
        }

        private void HealerTimer_MouseEnter(object sender, EventArgs e)
        {
            BackColor = _hoverColour;
        }

        private void HealerTimer_Click(object sender, EventArgs e)
        {
            OnTimerClicked(this);
        }

        private void picProgress_SizeChanged(object sender, EventArgs e)
        {
            RepaintProgress();
        }

        private void picMain_Paint(object sender, PaintEventArgs e)
        {
            if (_buff != null)
                e.Graphics.DrawImage(_buff, 0, 0);
        }

        private void TickTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (InvokeRequired) {
                Invoke(new Action(() => { Tick(); }));
            }
            else {
                RepaintProgress();
            }
        }

        public void SetColours()
        {
            _initalBgColour = Settings.GetMainBackgroundColour(true);
            BackColor = _initalBgColour;
            ForeColor = Settings.GetMainForegroundColour(true);
            _hoverColour = Color.FromArgb(255,
                Math.Min(255, (int)_initalBgColour.R + 30),
                Math.Min(255, (int)_initalBgColour.G + 30),
                Math.Min(255, (int)_initalBgColour.B + 30));

            pnlMain.BackColor = BackColor;
            pnlMain.ForeColor = ForeColor;
        }

        public void Restart()
        {
            Time = Healer.RecastSeconds;
            RepaintProgress();

            if (!_tickTimer.Enabled) _tickTimer.Start();
        }

        public void Stop()
        {
            if (_tickTimer.Enabled) _tickTimer.Stop();

            Time = 0;
            RepaintProgress();
        }

        public void Tick()
        {
            Time = Math.Max(0, Time - 1);
            if (Time <= 0) {
                if (_tickTimer.Enabled) _tickTimer.Stop();
                OnTimerDone(this);
            }
            RepaintProgress();
        }

        private void RepaintProgress()
        {
            if (picProgress.Width < 1 || picProgress.Height < 1) return;

            try {
                Bitmap buff = new Bitmap(picProgress.Width, picProgress.Height);
                using (Graphics g = Graphics.FromImage(buff)) {
                    if (Time > 0) {
                        double pWidth = 1.0;
                        if (Healer.RecastSeconds > 0) {
                            pWidth = (Time / (1.0 * Healer.RecastSeconds));
                        }
                        int actualWidth = (int)(pWidth * picProgress.Width);
                        g.FillRectangle(_bOutlineDark, 0, 0, actualWidth, picProgress.Height);
                        g.FillRectangle(_bFill, 4, 4, actualWidth - 8, picProgress.Height - 8);

                        var rect = new RectangleF() {
                            X = 0,
                            Y = 0,
                            Width = actualWidth,
                            Height = picProgress.Height
                        };
                        string text = Time.ToString();
                        var stringWidth = g.MeasureString(text, _fTime, picProgress.Width).Width;
                        if (stringWidth > rect.Width) rect.Width = stringWidth;
                        g.DrawString(text, _fTime, _bTime, rect, _sfNearMid);
                    }
                    else {
                        g.FillRectangle(_bOutline, 0, 0, picProgress.Width, picProgress.Height);
                        g.FillRectangle(_bFill, 4, 4, picProgress.Width - 8, picProgress.Height - 8);
                    }
                }
                SwapBuff(buff);
            }
            catch { }

            picProgress.Refresh();
        }

        private void SwapBuff(Bitmap newBuff)
        {
            if (_buff != null)
                _buff.Dispose();

            _buff = newBuff;
        }
    }
}
