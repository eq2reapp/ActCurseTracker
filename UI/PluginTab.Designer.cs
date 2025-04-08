using Advanced_Combat_Tracker;

namespace ActCurseTracker.UI
{
    partial class PluginTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnShowHud = new Advanced_Combat_Tracker.ButtonPainted();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnHelp = new Advanced_Combat_Tracker.ButtonPainted();
            this.chkUseMiniParseColours = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.chkOnTop = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.chkAutoOpen = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.dlgHealerColour = new System.Windows.Forms.ColorDialog();
            this.menuRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRowRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowActivate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowSeparatorGroup = new System.Windows.Forms.ToolStripSeparator();
            this.menuRowActivateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowDeactivateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowSeparatorAll = new System.Windows.Forms.ToolStripSeparator();
            this.menuRowActivateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRowDeactivateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.tabOptions = new Advanced_Combat_Tracker.TabControlPainted();
            this.tabHealers = new System.Windows.Forms.TabPage();
            this.chkAutoAddHealerCurers = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.chkWhoRaidActivate = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.lblLogs = new System.Windows.Forms.Label();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.lblSavedHealers = new System.Windows.Forms.Label();
            this.dgHealers = new ActCurseTracker.UI.FastDataGrid();
            this.pnlNewHealerBG = new System.Windows.Forms.Panel();
            this.pnlNewHealer = new System.Windows.Forms.Panel();
            this.txtHealerGroup = new System.Windows.Forms.TextBox();
            this.lblHealerGroup = new System.Windows.Forms.Label();
            this.pnlHealerColourBG = new System.Windows.Forms.Panel();
            this.pnlHealerColour = new System.Windows.Forms.Panel();
            this.chkHealerPinned = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.btnRemove = new Advanced_Combat_Tracker.ButtonPainted();
            this.btnCancel = new Advanced_Combat_Tracker.ButtonPainted();
            this.btnSave = new Advanced_Combat_Tracker.ButtonPainted();
            this.btnAdd = new Advanced_Combat_Tracker.ButtonPainted();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.txtHealerRecast = new System.Windows.Forms.TextBox();
            this.txtHealerName = new System.Windows.Forms.TextBox();
            this.lblHealerColour = new System.Windows.Forms.Label();
            this.chkHealerActive = new Advanced_Combat_Tracker.CheckboxButtonPainted();
            this.lblHealerRecast = new System.Windows.Forms.Label();
            this.lblHealerName = new System.Windows.Forms.Label();
            this.pnlControls.SuspendLayout();
            this.menuRow.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tabHealers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHealers)).BeginInit();
            this.pnlNewHealerBG.SuspendLayout();
            this.pnlNewHealer.SuspendLayout();
            this.pnlHealerColourBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowHud
            // 
            this.btnShowHud.Location = new System.Drawing.Point(12, 14);
            this.btnShowHud.Name = "btnShowHud";
            this.btnShowHud.Size = new System.Drawing.Size(150, 23);
            this.btnShowHud.TabIndex = 0;
            this.btnShowHud.Text = "Show Tracker Window";
            this.btnShowHud.UseVisualStyleBackColor = true;
            this.btnShowHud.Click += new System.EventHandler(this.btnShowHud_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnHelp);
            this.pnlControls.Controls.Add(this.chkUseMiniParseColours);
            this.pnlControls.Controls.Add(this.chkOnTop);
            this.pnlControls.Controls.Add(this.chkAutoOpen);
            this.pnlControls.Controls.Add(this.btnShowHud);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(892, 74);
            this.pnlControls.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(806, 14);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(66, 23);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // chkUseMiniParseColours
            // 
            this.chkUseMiniParseColours.AutoSize = true;
            this.chkUseMiniParseColours.Location = new System.Drawing.Point(417, 18);
            this.chkUseMiniParseColours.Name = "chkUseMiniParseColours";
            this.chkUseMiniParseColours.Size = new System.Drawing.Size(134, 17);
            this.chkUseMiniParseColours.TabIndex = 15;
            this.chkUseMiniParseColours.Text = "Use Mini Parse colours";
            this.chkUseMiniParseColours.UseVisualStyleBackColor = true;
            this.chkUseMiniParseColours.CheckedChanged += new System.EventHandler(this.chkUseMiniParseColours_CheckedChanged);
            // 
            // chkOnTop
            // 
            this.chkOnTop.AutoSize = true;
            this.chkOnTop.Location = new System.Drawing.Point(204, 41);
            this.chkOnTop.Name = "chkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(123, 17);
            this.chkOnTop.TabIndex = 14;
            this.chkOnTop.Text = "Keep window on top";
            this.chkOnTop.UseVisualStyleBackColor = true;
            this.chkOnTop.CheckedChanged += new System.EventHandler(this.chkOnTop_CheckedChanged);
            // 
            // chkAutoOpen
            // 
            this.chkAutoOpen.AutoSize = true;
            this.chkAutoOpen.Location = new System.Drawing.Point(204, 18);
            this.chkAutoOpen.Name = "chkAutoOpen";
            this.chkAutoOpen.Size = new System.Drawing.Size(172, 17);
            this.chkAutoOpen.TabIndex = 13;
            this.chkAutoOpen.Text = "Open window when ACT starts";
            this.chkAutoOpen.UseVisualStyleBackColor = true;
            this.chkAutoOpen.CheckedChanged += new System.EventHandler(this.chkAutoOpen_CheckedChanged);
            // 
            // dlgHealerColour
            // 
            this.dlgHealerColour.FullOpen = true;
            // 
            // menuRow
            // 
            this.menuRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRowRemove,
            this.menuRowActivate,
            this.menuRowSeparatorGroup,
            this.menuRowActivateGroup,
            this.menuRowDeactivateGroup,
            this.menuRowSeparatorAll,
            this.menuRowActivateAll,
            this.menuRowDeactivateAll});
            this.menuRow.Name = "menuRow";
            this.menuRow.Size = new System.Drawing.Size(165, 148);
            // 
            // menuRowRemove
            // 
            this.menuRowRemove.Name = "menuRowRemove";
            this.menuRowRemove.Size = new System.Drawing.Size(164, 22);
            this.menuRowRemove.Text = "Remove";
            this.menuRowRemove.Click += new System.EventHandler(this.menuRowRemove_Click);
            // 
            // menuRowActivate
            // 
            this.menuRowActivate.Name = "menuRowActivate";
            this.menuRowActivate.Size = new System.Drawing.Size(164, 22);
            this.menuRowActivate.Text = "Activate";
            this.menuRowActivate.Click += new System.EventHandler(this.menuRowActivate_Click);
            // 
            // menuRowSeparatorGroup
            // 
            this.menuRowSeparatorGroup.Name = "menuRowSeparatorGroup";
            this.menuRowSeparatorGroup.Size = new System.Drawing.Size(161, 6);
            // 
            // menuRowActivateGroup
            // 
            this.menuRowActivateGroup.Name = "menuRowActivateGroup";
            this.menuRowActivateGroup.Size = new System.Drawing.Size(164, 22);
            this.menuRowActivateGroup.Text = "Activate group";
            this.menuRowActivateGroup.Click += new System.EventHandler(this.menuRowActivateGroup_Click);
            // 
            // menuRowDeactivateGroup
            // 
            this.menuRowDeactivateGroup.Name = "menuRowDeactivateGroup";
            this.menuRowDeactivateGroup.Size = new System.Drawing.Size(164, 22);
            this.menuRowDeactivateGroup.Text = "Deactivate group";
            this.menuRowDeactivateGroup.Click += new System.EventHandler(this.menuRowDeactivateGroup_Click);
            // 
            // menuRowSeparatorAll
            // 
            this.menuRowSeparatorAll.Name = "menuRowSeparatorAll";
            this.menuRowSeparatorAll.Size = new System.Drawing.Size(161, 6);
            // 
            // menuRowActivateAll
            // 
            this.menuRowActivateAll.Name = "menuRowActivateAll";
            this.menuRowActivateAll.Size = new System.Drawing.Size(164, 22);
            this.menuRowActivateAll.Text = "Activate all";
            this.menuRowActivateAll.Click += new System.EventHandler(this.menuRowActivateAll_Click);
            // 
            // menuRowDeactivateAll
            // 
            this.menuRowDeactivateAll.Name = "menuRowDeactivateAll";
            this.menuRowDeactivateAll.Size = new System.Drawing.Size(164, 22);
            this.menuRowDeactivateAll.Text = "Deactivate all";
            this.menuRowDeactivateAll.Click += new System.EventHandler(this.menuRowDeactivateAll_Click);
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.tabOptions);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabs.Location = new System.Drawing.Point(0, 74);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(892, 641);
            this.pnlTabs.TabIndex = 4;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabHealers);
            this.tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOptions.Location = new System.Drawing.Point(0, 0);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Drawing.Point(2, 4);
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(892, 641);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.VisibleChanged += new System.EventHandler(this.tabOptions_VisibleChanged);
            // 
            // tabHealers
            // 
            this.tabHealers.Controls.Add(this.chkAutoAddHealerCurers);
            this.tabHealers.Controls.Add(this.chkWhoRaidActivate);
            this.tabHealers.Controls.Add(this.lblLogs);
            this.tabHealers.Controls.Add(this.txtLogs);
            this.tabHealers.Controls.Add(this.lblSavedHealers);
            this.tabHealers.Controls.Add(this.dgHealers);
            this.tabHealers.Controls.Add(this.pnlNewHealerBG);
            this.tabHealers.Location = new System.Drawing.Point(4, 27);
            this.tabHealers.Name = "tabHealers";
            this.tabHealers.Padding = new System.Windows.Forms.Padding(3);
            this.tabHealers.Size = new System.Drawing.Size(884, 610);
            this.tabHealers.TabIndex = 0;
            this.tabHealers.Text = "Healers";
            this.tabHealers.UseVisualStyleBackColor = true;
            // 
            // chkAutoAddHealerCurers
            // 
            this.chkAutoAddHealerCurers.AutoSize = true;
            this.chkAutoAddHealerCurers.Location = new System.Drawing.Point(16, 35);
            this.chkAutoAddHealerCurers.Name = "chkAutoAddHealerCurers";
            this.chkAutoAddHealerCurers.Size = new System.Drawing.Size(179, 17);
            this.chkAutoAddHealerCurers.TabIndex = 15;
            this.chkAutoAddHealerCurers.Text = "Add healers from detected cures";
            this.chkAutoAddHealerCurers.UseVisualStyleBackColor = true;
            this.chkAutoAddHealerCurers.CheckedChanged += new System.EventHandler(this.chkAutoAddHealerCurers_CheckedChanged);
            // 
            // chkWhoRaidActivate
            // 
            this.chkWhoRaidActivate.AutoSize = true;
            this.chkWhoRaidActivate.Location = new System.Drawing.Point(16, 12);
            this.chkWhoRaidActivate.Name = "chkWhoRaidActivate";
            this.chkWhoRaidActivate.Size = new System.Drawing.Size(170, 17);
            this.chkWhoRaidActivate.TabIndex = 14;
            this.chkWhoRaidActivate.Text = "Activate healers from /whoraid";
            this.chkWhoRaidActivate.UseVisualStyleBackColor = true;
            this.chkWhoRaidActivate.CheckedChanged += new System.EventHandler(this.chkWhoRaidActivate_CheckedChanged);
            // 
            // lblLogs
            // 
            this.lblLogs.AutoSize = true;
            this.lblLogs.Location = new System.Drawing.Point(400, 5);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(33, 13);
            this.lblLogs.TabIndex = 4;
            this.lblLogs.Text = "Logs:";
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.CausesValidation = false;
            this.txtLogs.Location = new System.Drawing.Point(395, 16);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(473, 579);
            this.txtLogs.TabIndex = 3;
            this.txtLogs.WordWrap = false;
            // 
            // lblSavedHealers
            // 
            this.lblSavedHealers.AutoSize = true;
            this.lblSavedHealers.Location = new System.Drawing.Point(13, 238);
            this.lblSavedHealers.Name = "lblSavedHealers";
            this.lblSavedHealers.Size = new System.Drawing.Size(213, 13);
            this.lblSavedHealers.TabIndex = 2;
            this.lblSavedHealers.Text = "Saved healers (right-click for quick actions):";
            // 
            // dgHealers
            // 
            this.dgHealers.AllowUserToAddRows = false;
            this.dgHealers.AllowUserToDeleteRows = false;
            this.dgHealers.AllowUserToResizeColumns = false;
            this.dgHealers.AllowUserToResizeRows = false;
            this.dgHealers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgHealers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHealers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgHealers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHealers.Location = new System.Drawing.Point(16, 256);
            this.dgHealers.MultiSelect = false;
            this.dgHealers.Name = "dgHealers";
            this.dgHealers.ReadOnly = true;
            this.dgHealers.RowHeadersVisible = false;
            this.dgHealers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgHealers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHealers.ShowCellErrors = false;
            this.dgHealers.ShowCellToolTips = false;
            this.dgHealers.ShowEditingIcon = false;
            this.dgHealers.ShowRowErrors = false;
            this.dgHealers.Size = new System.Drawing.Size(349, 339);
            this.dgHealers.TabIndex = 1;
            this.dgHealers.SelectionChanged += new System.EventHandler(this.dgHealers_SelectionChanged);
            this.dgHealers.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.DgHealers_SortCompare);
            this.dgHealers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgHealers_MouseDown);
            // 
            // pnlNewHealerBG
            // 
            this.pnlNewHealerBG.BackColor = System.Drawing.Color.Gray;
            this.pnlNewHealerBG.Controls.Add(this.pnlNewHealer);
            this.pnlNewHealerBG.Location = new System.Drawing.Point(15, 61);
            this.pnlNewHealerBG.Name = "pnlNewHealerBG";
            this.pnlNewHealerBG.Padding = new System.Windows.Forms.Padding(1);
            this.pnlNewHealerBG.Size = new System.Drawing.Size(350, 162);
            this.pnlNewHealerBG.TabIndex = 0;
            // 
            // pnlNewHealer
            // 
            this.pnlNewHealer.BackColor = System.Drawing.SystemColors.Window;
            this.pnlNewHealer.Controls.Add(this.txtHealerGroup);
            this.pnlNewHealer.Controls.Add(this.lblHealerGroup);
            this.pnlNewHealer.Controls.Add(this.pnlHealerColourBG);
            this.pnlNewHealer.Controls.Add(this.chkHealerPinned);
            this.pnlNewHealer.Controls.Add(this.btnRemove);
            this.pnlNewHealer.Controls.Add(this.btnCancel);
            this.pnlNewHealer.Controls.Add(this.btnSave);
            this.pnlNewHealer.Controls.Add(this.btnAdd);
            this.pnlNewHealer.Controls.Add(this.lblSeconds);
            this.pnlNewHealer.Controls.Add(this.txtHealerRecast);
            this.pnlNewHealer.Controls.Add(this.txtHealerName);
            this.pnlNewHealer.Controls.Add(this.lblHealerColour);
            this.pnlNewHealer.Controls.Add(this.chkHealerActive);
            this.pnlNewHealer.Controls.Add(this.lblHealerRecast);
            this.pnlNewHealer.Controls.Add(this.lblHealerName);
            this.pnlNewHealer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNewHealer.Location = new System.Drawing.Point(1, 1);
            this.pnlNewHealer.Name = "pnlNewHealer";
            this.pnlNewHealer.Size = new System.Drawing.Size(348, 160);
            this.pnlNewHealer.TabIndex = 0;
            // 
            // txtHealerGroup
            // 
            this.txtHealerGroup.Location = new System.Drawing.Point(57, 37);
            this.txtHealerGroup.Name = "txtHealerGroup";
            this.txtHealerGroup.Size = new System.Drawing.Size(140, 20);
            this.txtHealerGroup.TabIndex = 1;
            // 
            // lblHealerGroup
            // 
            this.lblHealerGroup.AutoSize = true;
            this.lblHealerGroup.Location = new System.Drawing.Point(12, 40);
            this.lblHealerGroup.Name = "lblHealerGroup";
            this.lblHealerGroup.Size = new System.Drawing.Size(36, 13);
            this.lblHealerGroup.TabIndex = 13;
            this.lblHealerGroup.Text = "Group";
            // 
            // pnlHealerColourBG
            // 
            this.pnlHealerColourBG.Controls.Add(this.pnlHealerColour);
            this.pnlHealerColourBG.Location = new System.Drawing.Point(57, 88);
            this.pnlHealerColourBG.Name = "pnlHealerColourBG";
            this.pnlHealerColourBG.Padding = new System.Windows.Forms.Padding(2);
            this.pnlHealerColourBG.Size = new System.Drawing.Size(50, 20);
            this.pnlHealerColourBG.TabIndex = 1;
            // 
            // pnlHealerColour
            // 
            this.pnlHealerColour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHealerColour.Location = new System.Drawing.Point(2, 2);
            this.pnlHealerColour.Name = "pnlHealerColour";
            this.pnlHealerColour.Size = new System.Drawing.Size(46, 16);
            this.pnlHealerColour.TabIndex = 0;
            this.pnlHealerColour.Click += new System.EventHandler(this.pnlHealerColour_Click);
            // 
            // chkHealerPinned
            // 
            this.chkHealerPinned.AutoSize = true;
            this.chkHealerPinned.Location = new System.Drawing.Point(246, 33);
            this.chkHealerPinned.Name = "chkHealerPinned";
            this.chkHealerPinned.Size = new System.Drawing.Size(71, 17);
            this.chkHealerPinned.TabIndex = 4;
            this.chkHealerPinned.Text = "Pin to top";
            this.chkHealerPinned.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 124);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(258, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(177, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 124);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(110, 66);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(49, 13);
            this.lblSeconds.TabIndex = 7;
            this.lblSeconds.Text = "Seconds";
            // 
            // txtHealerRecast
            // 
            this.txtHealerRecast.Location = new System.Drawing.Point(57, 63);
            this.txtHealerRecast.Name = "txtHealerRecast";
            this.txtHealerRecast.Size = new System.Drawing.Size(50, 20);
            this.txtHealerRecast.TabIndex = 2;
            this.txtHealerRecast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHealerRecast_KeyPress);
            this.txtHealerRecast.Leave += new System.EventHandler(this.txtHealerRecast_Leave);
            // 
            // txtHealerName
            // 
            this.txtHealerName.Location = new System.Drawing.Point(57, 11);
            this.txtHealerName.Name = "txtHealerName";
            this.txtHealerName.Size = new System.Drawing.Size(140, 20);
            this.txtHealerName.TabIndex = 0;
            // 
            // lblHealerColour
            // 
            this.lblHealerColour.AutoSize = true;
            this.lblHealerColour.Location = new System.Drawing.Point(12, 90);
            this.lblHealerColour.Name = "lblHealerColour";
            this.lblHealerColour.Size = new System.Drawing.Size(37, 13);
            this.lblHealerColour.TabIndex = 4;
            this.lblHealerColour.Text = "Colour";
            // 
            // chkHealerActive
            // 
            this.chkHealerActive.AutoSize = true;
            this.chkHealerActive.Location = new System.Drawing.Point(246, 13);
            this.chkHealerActive.Name = "chkHealerActive";
            this.chkHealerActive.Size = new System.Drawing.Size(56, 17);
            this.chkHealerActive.TabIndex = 3;
            this.chkHealerActive.Text = "Active";
            this.chkHealerActive.UseVisualStyleBackColor = true;
            // 
            // lblHealerRecast
            // 
            this.lblHealerRecast.AutoSize = true;
            this.lblHealerRecast.Location = new System.Drawing.Point(12, 66);
            this.lblHealerRecast.Name = "lblHealerRecast";
            this.lblHealerRecast.Size = new System.Drawing.Size(41, 13);
            this.lblHealerRecast.TabIndex = 1;
            this.lblHealerRecast.Text = "Recast";
            // 
            // lblHealerName
            // 
            this.lblHealerName.AutoSize = true;
            this.lblHealerName.Location = new System.Drawing.Point(12, 14);
            this.lblHealerName.Name = "lblHealerName";
            this.lblHealerName.Size = new System.Drawing.Size(35, 13);
            this.lblHealerName.TabIndex = 0;
            this.lblHealerName.Text = "Name";
            // 
            // PluginTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlControls);
            this.Name = "PluginTab";
            this.Size = new System.Drawing.Size(892, 715);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.menuRow.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabHealers.ResumeLayout(false);
            this.tabHealers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHealers)).EndInit();
            this.pnlNewHealerBG.ResumeLayout(false);
            this.pnlNewHealer.ResumeLayout(false);
            this.pnlNewHealer.PerformLayout();
            this.pnlHealerColourBG.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPainted btnShowHud;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.ColorDialog dlgHealerColour;
        private System.Windows.Forms.ContextMenuStrip menuRow;
        private System.Windows.Forms.ToolStripMenuItem menuRowActivate;
        private CheckboxButtonPainted chkAutoOpen;
        private CheckboxButtonPainted chkOnTop;
        private System.Windows.Forms.ToolStripSeparator menuRowSeparatorGroup;
        private System.Windows.Forms.ToolStripMenuItem menuRowActivateGroup;
        private System.Windows.Forms.ToolStripMenuItem menuRowDeactivateGroup;
        private System.Windows.Forms.ToolStripSeparator menuRowSeparatorAll;
        private System.Windows.Forms.ToolStripMenuItem menuRowActivateAll;
        private System.Windows.Forms.ToolStripMenuItem menuRowDeactivateAll;
        private CheckboxButtonPainted chkUseMiniParseColours;
        private System.Windows.Forms.Panel pnlTabs;
        private TabControlPainted tabOptions;
        private System.Windows.Forms.TabPage tabHealers;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label lblSavedHealers;
        private FastDataGrid dgHealers;
        private System.Windows.Forms.Panel pnlNewHealerBG;
        private System.Windows.Forms.Panel pnlNewHealer;
        private System.Windows.Forms.TextBox txtHealerGroup;
        private System.Windows.Forms.Label lblHealerGroup;
        private System.Windows.Forms.Panel pnlHealerColourBG;
        private System.Windows.Forms.Panel pnlHealerColour;
        private CheckboxButtonPainted chkHealerPinned;
        private ButtonPainted btnRemove;
        private ButtonPainted btnCancel;
        private ButtonPainted btnSave;
        private ButtonPainted btnAdd;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.TextBox txtHealerRecast;
        private System.Windows.Forms.TextBox txtHealerName;
        private System.Windows.Forms.Label lblHealerColour;
        private CheckboxButtonPainted chkHealerActive;
        private System.Windows.Forms.Label lblHealerRecast;
        private System.Windows.Forms.Label lblHealerName;
        private CheckboxButtonPainted chkAutoAddHealerCurers;
        private CheckboxButtonPainted chkWhoRaidActivate;
        private System.Windows.Forms.ToolStripMenuItem menuRowRemove;
        private ButtonPainted btnHelp;
    }
}
