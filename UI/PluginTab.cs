using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Advanced_Combat_Tracker;
using ActCurseTracker.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Diagnostics;
using System.Security.Policy;

namespace ActCurseTracker.UI
{
    public partial class PluginTab : UserControl
    {
        private Main _main = null;
        private Healer _curHealer = null;
        private AutoCompleteStringCollection _groups = new AutoCompleteStringCollection();

        public PluginTab(Main main)
        {
            InitializeComponent();

            _main = main;
            Logger.LogAdded += Logger_LogAdded;
            Settings.SettingsSaved += Settings_SettingsSaved;

            txtHealerGroup.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtHealerGroup.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtHealerGroup.AutoCompleteCustomSource = _groups;

            dlgHealerColour.Color = Healer.DEFAULT_COLOUR;

            dgHealers.Columns.Add("name", "Name");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 100;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgHealers.Columns.Add("group", "Group");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 100;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgHealers.Columns.Add("recast", "Recast");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 50;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgHealers.Columns.Add("colour", "Colour");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 50;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgHealers.Columns.Add("active", "Active");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 50;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgHealers.Columns.Add("pinned", "Pinned");
            dgHealers.Columns[dgHealers.Columns.Count - 1].FillWeight = 50;
            dgHealers.Columns[dgHealers.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgHealers.SortCompare += DgHealers_SortCompare;
        }

        private void tabOptions_VisibleChanged(object sender, EventArgs e)
        {
            Color bg = Settings.GetMainBackgroundColour();
            Color fg = Settings.GetMainForegroundColour();
            BackColor = bg;
            ForeColor = fg;
            tabHealers.BackColor = bg;
            tabHealers.ForeColor = fg;
            pnlNewHealerBG.BackColor = fg;
            pnlNewHealer.BackColor = bg;
            pnlHealerColourBG.BackColor = fg;
            pnlHealerColour.BackColor = dlgHealerColour.Color;
            txtHealerName.BackColor = bg;
            txtHealerName.ForeColor = fg;
            txtHealerGroup.BackColor = bg;
            txtHealerGroup.ForeColor = fg;
            txtHealerRecast.BackColor = bg;
            txtHealerRecast.ForeColor = fg;
            txtLogs.BackColor = bg;
            txtLogs.ForeColor = fg;

            bg = Settings.GetDatagridBackgroundColour();
            fg = Settings.GetDatagridForegroundColour();
            dgHealers.EnableHeadersVisualStyles = false;
            dgHealers.BackgroundColor = bg;
            dgHealers.DefaultCellStyle.BackColor = bg;
            dgHealers.DefaultCellStyle.ForeColor = fg;
            dgHealers.ColumnHeadersDefaultCellStyle.BackColor = dgHealers.BackgroundColor;
            dgHealers.ColumnHeadersDefaultCellStyle.ForeColor = dgHealers.ForeColor;

            chkAutoOpen.Checked = Settings.Current.AutoOpen;
            chkOnTop.Checked = Settings.Current.TopMost;
            chkUseMiniParseColours.Checked = Settings.Current.MiniBg;
            chkAutoAddHealerCurers.Checked = Settings.Current.AutoAdd;
            chkWhoRaidActivate.Checked = Settings.Current.WhoRaidActivate;

            _curHealer = null;
            RefreshHealersInGrid();
            ActivateControlButtons();
            ClearHealerControls();

            ShowLogs();
        }

        private void Settings_SettingsSaved()
        {
            // Healers can be added by other means, so make sure we detect that here
            RefreshHealersInGrid();
        }

        private void DgHealers_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "colour") {
                Color c1 = (Color)dgHealers.Rows[e.RowIndex1].Cells["colour"].Style.BackColor;
                Color c2 = (Color)dgHealers.Rows[e.RowIndex2].Cells["colour"].Style.BackColor;
                e.SortResult = c1.GetBrightness().CompareTo(c2.GetBrightness());
            }
            else {
                e.SortResult = e.CellValue1.ToString().CompareTo(e.CellValue2.ToString());
            }
            e.Handled = true;
        }

        private void Logger_LogAdded(string logLine)
        {
            if (InvokeRequired) {
                Invoke(new Action(() => { ShowLogs(); }));
            }
            else {
                ShowLogs();
            }
        }

        private void btnShowHud_Click(object sender, EventArgs e)
        {
            _main.ShowHud();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/eq2reapp/ActCurseTracker/wiki/Help");
        }

        private void chkAutoOpen_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Current.AutoOpen = chkAutoOpen.Checked;
            Settings.Current.Save();
        }

        private void chkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Current.TopMost = chkOnTop.Checked;
            Settings.Current.Save();

            _main.ShowHud();
        }

        private void chkUseMiniParseColours_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Current.MiniBg = chkUseMiniParseColours.Checked;
            Settings.Current.Save();
        }

        private void chkWhoRaidActivate_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Current.WhoRaidActivate = chkWhoRaidActivate.Checked;
            Settings.Current.Save();
        }

        private void chkAutoAddHealerCurers_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Current.AutoAdd = chkAutoAddHealerCurers.Checked;
            Settings.Current.Save();
        }

        private void txtHealerRecast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtHealerRecast_Leave(object sender, EventArgs e)
        {
            int recast = 0;
            int.TryParse(txtHealerRecast.Text.Trim(), out recast);
            if (recast < 1)
                recast = Healer.DEFAULT_RECAST;
            txtHealerRecast.Text = recast.ToString();
        }

        private void pnlHealerColour_Click(object sender, EventArgs e)
        {
            dlgHealerColour.Color = pnlHealerColour.BackColor;
            List<int> colours = new List<int>();
            foreach (var healer in Settings.Current.Healers) {
                int colour = ColorTranslator.ToOle(healer.Colour);
                if (!colours.Contains(colour)) {
                    colours.Add(colour);
                }
            }
            dlgHealerColour.CustomColors = colours.ToArray();

            if (dlgHealerColour.ShowDialog() == DialogResult.OK) {
                pnlHealerColour.BackColor = dlgHealerColour.Color;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var healer = GetHealerFromForm();
            if (string.IsNullOrEmpty(healer.Name)) {
                MessageBox.Show($"Please provide a name", "No name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Settings.Current.GetHealerByName(healer.Name) != null) {
                MessageBox.Show($"\"{healer.Name}\" already exists. Select them in the list below, and click \"Edit\".", "Already exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Logger.Log($"Adding {healer.Name}");

            Settings.Current.Healers.Add(healer);
            Settings.Current.Save();

            ActivateControlButtons();
            ClearHealerControls();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_curHealer != null) {
                Logger.Log($"Removing {_curHealer.Name}");
                Settings.Current.Healers.Remove(_curHealer);
                _curHealer = null;

                Settings.Current.Save();
            }

            ActivateControlButtons();
            ClearHealerControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_curHealer != null) {
                var healer = GetHealerFromForm();
                if (string.IsNullOrEmpty(healer.Name)) {
                    MessageBox.Show($"Please provide a name", "No name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var existing = Settings.Current.GetHealerByName(healer.Name);
                if (existing != null && existing != _curHealer) {
                    MessageBox.Show($"\"{healer.Name}\" already exists. Select them in the list below, and click \"Edit\".", "Already exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _curHealer.Name = healer.Name;
                _curHealer.Group = healer.Group;
                _curHealer.RecastSeconds = healer.RecastSeconds;
                _curHealer.Colour = healer.Colour;
                _curHealer.Active = healer.Active;
                _curHealer.Pinned = healer.Pinned;

                Logger.Log($"Updating {_curHealer.Name}");
                _curHealer = null;

                Settings.Current.Save();
            }

            ActivateControlButtons();
            ClearHealerControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _curHealer = null;
            ActivateControlButtons();
            ClearHealerControls();
        }

        private void dgHealers_SelectionChanged(object sender, EventArgs e)
        {
            _curHealer = null;
            if (dgHealers.SelectedRows.Count > 0) {
                var healer = dgHealers.SelectedRows[0].Tag as Healer;
                if (healer != null) {
                    txtHealerName.Text = healer.Name;
                    txtHealerGroup.Text = healer.Group;
                    txtHealerRecast.Text = healer.RecastSeconds.ToString();
                    pnlHealerColour.BackColor = healer.Colour;
                    chkHealerActive.Checked = healer.Active;
                    chkHealerPinned.Checked = healer.Pinned;

                    _curHealer = healer;
                    ActivateControlButtons();
                }
            }
        }

        private void dgHealers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                var hit = dgHealers.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0) {
                    var row = dgHealers.Rows[hit.RowIndex];
                    var healer = row.Tag as Healer;
                    if (healer != null) {
                        menuRowActivate.Tag = row;
                        if (healer.Active) {
                            menuRowActivate.Text = "Deactivate";
                        }
                        else {
                            menuRowActivate.Text = "Activate";
                        }
                        row.Selected = true;
                    }
                }
            }
        }

        private void menuRowRemove_Click(object sender, EventArgs e)
        {
            var (row, healer) = GetSelectedRowAndHealer();
            if (_curHealer != null && healer != null && row != null) {
                Logger.Log($"Removing {_curHealer.Name}");
                Settings.Current.Healers.Remove(_curHealer);
                _curHealer = null;

                Settings.Current.Save();

                ActivateControlButtons();
                ClearHealerControls();
            }
        }

        private void menuRowActivate_Click(object sender, EventArgs e)
        {
            var (row, healer) = GetSelectedRowAndHealer();
            if (_curHealer != null && healer != null && row != null) {
                _curHealer.Active = menuRowActivate.Text == "Activate";
                Logger.Log($"{(_curHealer.Active ? "Activating" : "Deactivating")} {_curHealer.Name}");
                _curHealer = null;

                Settings.Current.Save();

                ActivateControlButtons();
                ClearHealerControls();
            }
        }

        private void menuRowActivateGroup_Click(object sender, EventArgs e)
        {
            var (row, curHealer) = GetSelectedRowAndHealer();
            if (curHealer != null) {
                var group = curHealer.Group;
                foreach (var healer in Settings.Current.Healers) {
                    if (!healer.Active && healer.Group.Equals(curHealer.Group)) {
                        healer.Active = true;
                    }
                }
                Settings.Current.Save();
            }
        }

        private void menuRowDeactivateGroup_Click(object sender, EventArgs e)
        {
            var (row, curHealer) = GetSelectedRowAndHealer();
            if (curHealer != null) {
                var group = curHealer.Group;
                foreach (var healer in Settings.Current.Healers) {
                    if (healer.Active && healer.Group.Equals(curHealer.Group)) {
                        healer.Active = false;
                    }
                }
                Settings.Current.Save();
            }
        }

        private void menuRowActivateAll_Click(object sender, EventArgs e)
        {
            foreach (var healer in Settings.Current.Healers) {
                healer.Active = true;
            }
            Settings.Current.Save();
        }

        private void menuRowDeactivateAll_Click(object sender, EventArgs e)
        {
            foreach (var healer in Settings.Current.Healers) {
                healer.Active = false;
            }
            Settings.Current.Save();
        }

        public void SelectHealer(Healer healer)
        {
            foreach (DataGridViewRow row in dgHealers.Rows) {
                var rowHealer = row.Tag as Healer;
                if (rowHealer != null && rowHealer.Name.ToLower().Equals(healer.Name.ToLower())) {
                    row.Selected = true;
                    break;
                }
            }
        }

        private (DataGridViewRow, Healer) GetSelectedRowAndHealer()
        {
            var row = menuRowActivate.Tag as DataGridViewRow;
            if (row != null) {
                var healer = row.Tag as Healer;
                if (healer != null) {
                    return (row, healer);
                }
            }
            return (row, null);
        }

        private Healer GetHealerFromForm()
        {
            string name = txtHealerName.Text.Trim();
            string group = txtHealerGroup.Text.Trim();
            if (string.IsNullOrEmpty(group)) {
                group = Healer.DEFAULT_GROUP;
            }
            int recast = 0;
            int.TryParse(txtHealerRecast.Text.Trim(), out recast);
            Healer healer = new Healer() {
                Name = name,
                Group = group,
                RecastSeconds = recast,
                Colour = pnlHealerColour.BackColor,
                Active = chkHealerActive.Checked,
                Pinned = chkHealerPinned.Checked
            };
            return healer;
        }

        private void ActivateControlButtons()
        {
            bool hasCurHealer = _curHealer != null;
            btnAdd.Enabled = !hasCurHealer;
            btnSave.Enabled = hasCurHealer;
            btnRemove.Enabled = hasCurHealer;
        }

        private void ClearHealerControls()
        {
            txtHealerName.Text = "";
            txtHealerGroup.Text = "";
            txtHealerRecast.Text = "60";
            pnlHealerColour.BackColor = Healer.DEFAULT_COLOUR;
            chkHealerActive.Checked = true;
            chkHealerPinned.Checked = false;

            dgHealers.ClearSelection();
        }

        private void RefreshHealersInGrid()
        {
            Settings.Current.Healers.Sort((x,y) => {
                return x.Name.CompareTo(y.Name);
            });

            dgHealers.Rows.Clear();
            foreach (Healer healer in Settings.Current.Healers) {
                AddHealerToGrid(healer);

                if (!_groups.Contains(healer.Group)) {
                    _groups.Add(healer.Group);
                }
            }
        }

        private void AddHealerToGrid(Healer healer)
        {
            int rowIndex = dgHealers.Rows.Add(new object[] {
                healer.Name,
                healer.Group,
                healer.RecastSeconds,
                "",
                healer.Active,
                healer.Pinned
            });

            dgHealers.Rows[rowIndex].Tag = healer;
            dgHealers.Rows[rowIndex].Cells["colour"].Style.BackColor = healer.Colour;
            dgHealers.Rows[rowIndex].ContextMenuStrip = menuRow;
        }

        private void ShowLogs()
        {
            txtLogs.Lines = Logger.Lines();
            txtLogs.SelectionStart = txtLogs.Lines.Length;
            txtLogs.ScrollToCaret();
        }
    }
}
