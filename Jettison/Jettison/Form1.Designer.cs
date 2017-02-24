namespace JettisonApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lstMain = new System.Windows.Forms.ListView();
            this.colDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLife = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(16, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(138, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Jettison";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(16, 70);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(215, 44);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "Register a directory";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lstMain
            // 
            this.lstMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDirectory,
            this.colLife});
            this.lstMain.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMain.Location = new System.Drawing.Point(16, 122);
            this.lstMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstMain.Name = "lstMain";
            this.lstMain.Size = new System.Drawing.Size(826, 360);
            this.lstMain.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstMain.TabIndex = 2;
            this.lstMain.UseCompatibleStateImageBehavior = false;
            this.lstMain.View = System.Windows.Forms.View.Details;
            this.lstMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstMain_MouseClick);
            // 
            // colDirectory
            // 
            this.colDirectory.Text = "Directory";
            // 
            // colLife
            // 
            this.colLife.Text = "Life";
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.BackgroundImage = global::JettisonApp.Properties.Resources.settings_normal;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(787, 11);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 49);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.TabStop = false;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseDown);
            this.btnSettings.MouseEnter += new System.EventHandler(this.btnSettings_MouseEnter);
            this.btnSettings.MouseLeave += new System.EventHandler(this.btnSettings_MouseLeave);
            this.btnSettings.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSettings_MouseUp);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(239, 98);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(600, 16);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(859, 497);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lstMain);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Jettison";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ListView lstMain;
        private System.Windows.Forms.ColumnHeader colDirectory;
        private System.Windows.Forms.ColumnHeader colLife;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblStatus;
    }
}

