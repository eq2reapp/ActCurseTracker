namespace ActCurseTracker.UI
{
    partial class HealerTimer
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
            CustomDispose();

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
            this.lblName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(2, 2);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 28);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "HealerName";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.HealerTimer_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.HealerTimer_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.HealerTimer_MouseLeave);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.picProgress);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(4, 4);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(2);
            this.pnlMain.Size = new System.Drawing.Size(342, 32);
            this.pnlMain.TabIndex = 3;
            this.pnlMain.Click += new System.EventHandler(this.HealerTimer_Click);
            this.pnlMain.MouseEnter += new System.EventHandler(this.HealerTimer_MouseEnter);
            this.pnlMain.MouseLeave += new System.EventHandler(this.HealerTimer_MouseLeave);
            // 
            // picProgress
            // 
            this.picProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProgress.Location = new System.Drawing.Point(93, 2);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(247, 28);
            this.picProgress.TabIndex = 3;
            this.picProgress.TabStop = false;
            this.picProgress.SizeChanged += new System.EventHandler(this.picProgress_SizeChanged);
            this.picProgress.Click += new System.EventHandler(this.HealerTimer_Click);
            this.picProgress.Paint += new System.Windows.Forms.PaintEventHandler(this.picMain_Paint);
            this.picProgress.MouseEnter += new System.EventHandler(this.HealerTimer_MouseEnter);
            this.picProgress.MouseLeave += new System.EventHandler(this.HealerTimer_MouseLeave);
            // 
            // HealerTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "HealerTimer";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(350, 40);
            this.Load += new System.EventHandler(this.HealerTimer_Load);
            this.Click += new System.EventHandler(this.HealerTimer_Click);
            this.MouseEnter += new System.EventHandler(this.HealerTimer_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.HealerTimer_MouseLeave);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox picProgress;
    }
}
