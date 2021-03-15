namespace JettisonApp
{
    partial class Settings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxRunOnStartup = new System.Windows.Forms.CheckBox();
            this.cbxShowOnStart = new System.Windows.Forms.CheckBox();
            this.cbxCloseToTray = new System.Windows.Forms.CheckBox();
            this.cbxLogHistory = new System.Windows.Forms.CheckBox();
            this.cbxDisplayMessage = new System.Windows.Forms.CheckBox();
            this.BtnSaveSettings = new System.Windows.Forms.Button();
            this.BtnCancelSettings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.cbxRunOnStartup);
            this.flowLayoutPanel1.Controls.Add(this.cbxShowOnStart);
            this.flowLayoutPanel1.Controls.Add(this.cbxCloseToTray);
            this.flowLayoutPanel1.Controls.Add(this.cbxLogHistory);
            this.flowLayoutPanel1.Controls.Add(this.cbxDisplayMessage);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(334, 189);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cbxRunOnStartup
            // 
            this.cbxRunOnStartup.AutoSize = true;
            this.cbxRunOnStartup.Location = new System.Drawing.Point(3, 3);
            this.cbxRunOnStartup.Name = "cbxRunOnStartup";
            this.cbxRunOnStartup.Size = new System.Drawing.Size(235, 24);
            this.cbxRunOnStartup.TabIndex = 0;
            this.cbxRunOnStartup.Text = "Run on startup (recommended)";
            this.cbxRunOnStartup.UseVisualStyleBackColor = true;
            // 
            // cbxShowOnStart
            // 
            this.cbxShowOnStart.AutoSize = true;
            this.cbxShowOnStart.Location = new System.Drawing.Point(3, 33);
            this.cbxShowOnStart.Name = "cbxShowOnStart";
            this.cbxShowOnStart.Size = new System.Drawing.Size(174, 24);
            this.cbxShowOnStart.TabIndex = 3;
            this.cbxShowOnStart.Text = "Show window on start";
            this.cbxShowOnStart.UseVisualStyleBackColor = true;
            // 
            // cbxCloseToTray
            // 
            this.cbxCloseToTray.AutoSize = true;
            this.cbxCloseToTray.Location = new System.Drawing.Point(3, 63);
            this.cbxCloseToTray.Name = "cbxCloseToTray";
            this.cbxCloseToTray.Size = new System.Drawing.Size(235, 24);
            this.cbxCloseToTray.TabIndex = 4;
            this.cbxCloseToTray.Text = "Close / Minimize to system tray";
            this.cbxCloseToTray.UseVisualStyleBackColor = true;
            // 
            // cbxLogHistory
            // 
            this.cbxLogHistory.AutoSize = true;
            this.cbxLogHistory.Location = new System.Drawing.Point(3, 93);
            this.cbxLogHistory.Name = "cbxLogHistory";
            this.cbxLogHistory.Size = new System.Drawing.Size(161, 24);
            this.cbxLogHistory.TabIndex = 1;
            this.cbxLogHistory.Text = "Save Jettison history";
            this.cbxLogHistory.UseVisualStyleBackColor = true;
            // 
            // cbxDisplayMessage
            // 
            this.cbxDisplayMessage.AutoSize = true;
            this.cbxDisplayMessage.Location = new System.Drawing.Point(3, 123);
            this.cbxDisplayMessage.Name = "cbxDisplayMessage";
            this.cbxDisplayMessage.Size = new System.Drawing.Size(312, 24);
            this.cbxDisplayMessage.TabIndex = 2;
            this.cbxDisplayMessage.Text = "Display a message when a file is Jettisoned";
            this.cbxDisplayMessage.UseVisualStyleBackColor = true;
            // 
            // BtnSaveSettings
            // 
            this.BtnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveSettings.Location = new System.Drawing.Point(271, 207);
            this.BtnSaveSettings.Name = "BtnSaveSettings";
            this.BtnSaveSettings.Size = new System.Drawing.Size(75, 30);
            this.BtnSaveSettings.TabIndex = 1;
            this.BtnSaveSettings.Text = "Save Settings";
            this.BtnSaveSettings.UseVisualStyleBackColor = true;
            this.BtnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // BtnCancelSettings
            // 
            this.BtnCancelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancelSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelSettings.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelSettings.Location = new System.Drawing.Point(190, 207);
            this.BtnCancelSettings.Name = "BtnCancelSettings";
            this.BtnCancelSettings.Size = new System.Drawing.Size(75, 30);
            this.BtnCancelSettings.TabIndex = 2;
            this.BtnCancelSettings.Text = "Cancel";
            this.BtnCancelSettings.UseVisualStyleBackColor = true;
            this.BtnCancelSettings.Click += new System.EventHandler(this.BtnCancelSettings_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.BtnSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(358, 247);
            this.Controls.Add(this.BtnCancelSettings);
            this.Controls.Add(this.BtnSaveSettings);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbxRunOnStartup;
        private System.Windows.Forms.Button BtnSaveSettings;
        private System.Windows.Forms.Button BtnCancelSettings;
        private System.Windows.Forms.CheckBox cbxLogHistory;
        private System.Windows.Forms.CheckBox cbxDisplayMessage;
        private System.Windows.Forms.CheckBox cbxShowOnStart;
        private System.Windows.Forms.CheckBox cbxCloseToTray;
    }
}