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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxRunOnStartup = new System.Windows.Forms.CheckBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnCancelSettings = new System.Windows.Forms.Button();
            this.cbxLogHistory = new System.Windows.Forms.CheckBox();
            this.cbxDisplayMessage = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.cbxRunOnStartup);
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
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSettings.Location = new System.Drawing.Point(271, 207);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(75, 30);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnCancelSettings
            // 
            this.btnCancelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSettings.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSettings.Location = new System.Drawing.Point(190, 207);
            this.btnCancelSettings.Name = "btnCancelSettings";
            this.btnCancelSettings.Size = new System.Drawing.Size(75, 30);
            this.btnCancelSettings.TabIndex = 2;
            this.btnCancelSettings.Text = "Cancel";
            this.btnCancelSettings.UseVisualStyleBackColor = true;
            this.btnCancelSettings.Click += new System.EventHandler(this.btnCancelSettings_Click);
            // 
            // cbxLogHistory
            // 
            this.cbxLogHistory.AutoSize = true;
            this.cbxLogHistory.Location = new System.Drawing.Point(3, 33);
            this.cbxLogHistory.Name = "cbxLogHistory";
            this.cbxLogHistory.Size = new System.Drawing.Size(161, 24);
            this.cbxLogHistory.TabIndex = 1;
            this.cbxLogHistory.Text = "Save Jettison history";
            this.cbxLogHistory.UseVisualStyleBackColor = true;
            // 
            // cbxDisplayMessage
            // 
            this.cbxDisplayMessage.AutoSize = true;
            this.cbxDisplayMessage.Location = new System.Drawing.Point(3, 63);
            this.cbxDisplayMessage.Name = "cbxDisplayMessage";
            this.cbxDisplayMessage.Size = new System.Drawing.Size(312, 24);
            this.cbxDisplayMessage.TabIndex = 2;
            this.cbxDisplayMessage.Text = "Display a message when a file is Jettisoned";
            this.cbxDisplayMessage.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AcceptButton = this.btnSaveSettings;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(358, 247);
            this.Controls.Add(this.btnCancelSettings);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox cbxRunOnStartup;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnCancelSettings;
        private System.Windows.Forms.CheckBox cbxLogHistory;
        private System.Windows.Forms.CheckBox cbxDisplayMessage;
    }
}