namespace JettisonApp
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rb24Hours = new System.Windows.Forms.RadioButton();
            this.rb48Hours = new System.Windows.Forms.RadioButton();
            this.rb72Hours = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.txtCustomLife = new System.Windows.Forms.TextBox();
            this.rbCustomLifeSeconds = new System.Windows.Forms.RadioButton();
            this.rbCustomLifeMinutes = new System.Windows.Forms.RadioButton();
            this.rbCustomLifeHours = new System.Windows.Forms.RadioButton();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.cbxRecycleFiles = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browse for a folder:";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectory.Location = new System.Drawing.Point(13, 37);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(571, 27);
            this.txtDirectory.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(590, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(44, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = ". . .";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Allow files to live in this folder for a maximum of:";
            // 
            // rb24Hours
            // 
            this.rb24Hours.AutoSize = true;
            this.rb24Hours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb24Hours.Location = new System.Drawing.Point(3, 0);
            this.rb24Hours.Name = "rb24Hours";
            this.rb24Hours.Size = new System.Drawing.Size(83, 24);
            this.rb24Hours.TabIndex = 4;
            this.rb24Hours.TabStop = true;
            this.rb24Hours.Text = "24 hours";
            this.rb24Hours.UseVisualStyleBackColor = true;
            // 
            // rb48Hours
            // 
            this.rb48Hours.AutoSize = true;
            this.rb48Hours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb48Hours.Location = new System.Drawing.Point(3, 30);
            this.rb48Hours.Name = "rb48Hours";
            this.rb48Hours.Size = new System.Drawing.Size(83, 24);
            this.rb48Hours.TabIndex = 5;
            this.rb48Hours.TabStop = true;
            this.rb48Hours.Text = "48 hours";
            this.rb48Hours.UseVisualStyleBackColor = true;
            // 
            // rb72Hours
            // 
            this.rb72Hours.AutoSize = true;
            this.rb72Hours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb72Hours.Location = new System.Drawing.Point(3, 60);
            this.rb72Hours.Name = "rb72Hours";
            this.rb72Hours.Size = new System.Drawing.Size(83, 24);
            this.rb72Hours.TabIndex = 6;
            this.rb72Hours.TabStop = true;
            this.rb72Hours.Text = "72 hours";
            this.rb72Hours.UseVisualStyleBackColor = true;
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustom.Location = new System.Drawing.Point(2, 90);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(77, 24);
            this.rbCustom.TabIndex = 7;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // txtCustomLife
            // 
            this.txtCustomLife.Enabled = false;
            this.txtCustomLife.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomLife.Location = new System.Drawing.Point(99, 193);
            this.txtCustomLife.Name = "txtCustomLife";
            this.txtCustomLife.Size = new System.Drawing.Size(57, 27);
            this.txtCustomLife.TabIndex = 8;
            // 
            // rbCustomLifeSeconds
            // 
            this.rbCustomLifeSeconds.AutoSize = true;
            this.rbCustomLifeSeconds.Enabled = false;
            this.rbCustomLifeSeconds.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomLifeSeconds.Location = new System.Drawing.Point(168, 194);
            this.rbCustomLifeSeconds.Name = "rbCustomLifeSeconds";
            this.rbCustomLifeSeconds.Size = new System.Drawing.Size(82, 24);
            this.rbCustomLifeSeconds.TabIndex = 9;
            this.rbCustomLifeSeconds.TabStop = true;
            this.rbCustomLifeSeconds.Text = "Seconds";
            this.rbCustomLifeSeconds.UseVisualStyleBackColor = true;
            // 
            // rbCustomLifeMinutes
            // 
            this.rbCustomLifeMinutes.AutoSize = true;
            this.rbCustomLifeMinutes.Enabled = false;
            this.rbCustomLifeMinutes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomLifeMinutes.Location = new System.Drawing.Point(256, 194);
            this.rbCustomLifeMinutes.Name = "rbCustomLifeMinutes";
            this.rbCustomLifeMinutes.Size = new System.Drawing.Size(79, 24);
            this.rbCustomLifeMinutes.TabIndex = 10;
            this.rbCustomLifeMinutes.TabStop = true;
            this.rbCustomLifeMinutes.Text = "Minutes";
            this.rbCustomLifeMinutes.UseVisualStyleBackColor = true;
            // 
            // rbCustomLifeHours
            // 
            this.rbCustomLifeHours.AutoSize = true;
            this.rbCustomLifeHours.Enabled = false;
            this.rbCustomLifeHours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomLifeHours.Location = new System.Drawing.Point(341, 194);
            this.rbCustomLifeHours.Name = "rbCustomLifeHours";
            this.rbCustomLifeHours.Size = new System.Drawing.Size(66, 24);
            this.rbCustomLifeHours.TabIndex = 11;
            this.rbCustomLifeHours.TabStop = true;
            this.rbCustomLifeHours.Text = "Hours";
            this.rbCustomLifeHours.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(12, 314);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(84, 32);
            this.btnRegister.TabIndex = 12;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb24Hours);
            this.panel1.Controls.Add(this.rb48Hours);
            this.panel1.Controls.Add(this.rb72Hours);
            this.panel1.Controls.Add(this.rbCustom);
            this.panel1.Location = new System.Drawing.Point(13, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 114);
            this.panel1.TabIndex = 13;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(102, 320);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(124, 20);
            this.lblError.TabIndex = 14;
            this.lblError.Text = "error placeholder";
            this.lblError.Visible = false;
            // 
            // cbxRecycleFiles
            // 
            this.cbxRecycleFiles.AutoSize = true;
            this.cbxRecycleFiles.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRecycleFiles.Location = new System.Drawing.Point(12, 256);
            this.cbxRecycleFiles.Name = "cbxRecycleFiles";
            this.cbxRecycleFiles.Size = new System.Drawing.Size(343, 24);
            this.cbxRecycleFiles.TabIndex = 15;
            this.cbxRecycleFiles.Text = "Send files to the Recycle bin instead of deleting";
            this.cbxRecycleFiles.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(646, 358);
            this.Controls.Add(this.cbxRecycleFiles);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.rbCustomLifeHours);
            this.Controls.Add(this.rbCustomLifeMinutes);
            this.Controls.Add(this.rbCustomLifeSeconds);
            this.Controls.Add(this.txtCustomLife);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Text = "Register";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rb24Hours;
        private System.Windows.Forms.RadioButton rb48Hours;
        private System.Windows.Forms.RadioButton rb72Hours;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.TextBox txtCustomLife;
        private System.Windows.Forms.RadioButton rbCustomLifeSeconds;
        private System.Windows.Forms.RadioButton rbCustomLifeMinutes;
        private System.Windows.Forms.RadioButton rbCustomLifeHours;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox cbxRecycleFiles;
    }
}