using Advanced_Combat_Tracker;

namespace ActCurseTracker.UI
{
    partial class HudForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnShowDgCures = new Advanced_Combat_Tracker.ButtonPainted();
            this.pnlCures = new System.Windows.Forms.Panel();
            this.dgCures = new ActCurseTracker.UI.FastDataGrid();
            this.pnlCuresControls = new System.Windows.Forms.Panel();
            this.btnOptions = new Advanced_Combat_Tracker.ButtonPainted();
            this.btnClearDgCures = new Advanced_Combat_Tracker.ButtonPainted();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlTimers = new System.Windows.Forms.FlowLayoutPanel();
            this.timerCures = new System.Windows.Forms.Timer(this.components);
            this.pnlCures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCures)).BeginInit();
            this.pnlCuresControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowDgCures
            // 
            this.btnShowDgCures.Location = new System.Drawing.Point(81, 5);
            this.btnShowDgCures.Name = "btnShowDgCures";
            this.btnShowDgCures.Size = new System.Drawing.Size(72, 27);
            this.btnShowDgCures.TabIndex = 3;
            this.btnShowDgCures.Text = "Cures";
            this.btnShowDgCures.UseVisualStyleBackColor = true;
            this.btnShowDgCures.Click += new System.EventHandler(this.btnShowDgCures_Click);
            // 
            // pnlCures
            // 
            this.pnlCures.Controls.Add(this.dgCures);
            this.pnlCures.Controls.Add(this.pnlCuresControls);
            this.pnlCures.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCures.Location = new System.Drawing.Point(0, 522);
            this.pnlCures.Name = "pnlCures";
            this.pnlCures.Size = new System.Drawing.Size(284, 239);
            this.pnlCures.TabIndex = 4;
            // 
            // dgCures
            // 
            this.dgCures.AllowUserToAddRows = false;
            this.dgCures.AllowUserToDeleteRows = false;
            this.dgCures.AllowUserToResizeColumns = false;
            this.dgCures.AllowUserToResizeRows = false;
            this.dgCures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCures.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgCures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCures.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCures.Location = new System.Drawing.Point(0, 36);
            this.dgCures.MultiSelect = false;
            this.dgCures.Name = "dgCures";
            this.dgCures.ReadOnly = true;
            this.dgCures.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgCures.RowHeadersVisible = false;
            this.dgCures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgCures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCures.ShowCellErrors = false;
            this.dgCures.ShowCellToolTips = false;
            this.dgCures.ShowEditingIcon = false;
            this.dgCures.ShowRowErrors = false;
            this.dgCures.Size = new System.Drawing.Size(284, 203);
            this.dgCures.TabIndex = 0;
            // 
            // pnlCuresControls
            // 
            this.pnlCuresControls.Controls.Add(this.btnOptions);
            this.pnlCuresControls.Controls.Add(this.btnClearDgCures);
            this.pnlCuresControls.Controls.Add(this.btnShowDgCures);
            this.pnlCuresControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCuresControls.Location = new System.Drawing.Point(0, 0);
            this.pnlCuresControls.Name = "pnlCuresControls";
            this.pnlCuresControls.Size = new System.Drawing.Size(284, 36);
            this.pnlCuresControls.TabIndex = 4;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(5, 5);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(72, 27);
            this.btnOptions.TabIndex = 5;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnClearDgCures
            // 
            this.btnClearDgCures.Location = new System.Drawing.Point(157, 5);
            this.btnClearDgCures.Name = "btnClearDgCures";
            this.btnClearDgCures.Size = new System.Drawing.Size(72, 27);
            this.btnClearDgCures.TabIndex = 4;
            this.btnClearDgCures.Text = "Clear";
            this.btnClearDgCures.UseVisualStyleBackColor = true;
            this.btnClearDgCures.Click += new System.EventHandler(this.btnClearDgCures_Click);
            // 
            // pnlControls
            // 
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(284, 1);
            this.pnlControls.TabIndex = 5;
            // 
            // pnlTimers
            // 
            this.pnlTimers.AutoScroll = true;
            this.pnlTimers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTimers.Location = new System.Drawing.Point(0, 1);
            this.pnlTimers.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTimers.Name = "pnlTimers";
            this.pnlTimers.Size = new System.Drawing.Size(284, 521);
            this.pnlTimers.TabIndex = 0;
            // 
            // timerCures
            // 
            this.timerCures.Interval = 1000;
            // 
            // HudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 761);
            this.Controls.Add(this.pnlTimers);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlCures);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 365);
            this.Name = "HudForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Curse Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HudForm_FormClosing);
            this.Load += new System.EventHandler(this.Hud_Load);
            this.Shown += new System.EventHandler(this.HudForm_Shown);
            this.LocationChanged += new System.EventHandler(this.HudForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.HudForm_SizeChanged);
            this.pnlCures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCures)).EndInit();
            this.pnlCuresControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FastDataGrid dgCures;
        private ButtonPainted btnShowDgCures;
        private System.Windows.Forms.Panel pnlCures;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlCuresControls;
        private ButtonPainted btnClearDgCures;
        private ButtonPainted btnOptions;
        private System.Windows.Forms.FlowLayoutPanel pnlTimers;
        private System.Windows.Forms.Timer timerCures;
    }
}