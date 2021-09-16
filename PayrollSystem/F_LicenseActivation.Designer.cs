namespace PayRollSystem
{
    partial class F_LicenseActivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_LicenseActivation));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLicenseFile = new System.Windows.Forms.TextBox();
            this.txtLicenseText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnActivateLicense = new System.Windows.Forms.Button();
            this.btnDisplayLicenseText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "License File";
            // 
            // txtLicenseFile
            // 
            this.txtLicenseFile.Location = new System.Drawing.Point(127, 8);
            this.txtLicenseFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLicenseFile.Name = "txtLicenseFile";
            this.txtLicenseFile.Size = new System.Drawing.Size(969, 21);
            this.txtLicenseFile.TabIndex = 1;
            // 
            // txtLicenseText
            // 
            this.txtLicenseText.Enabled = false;
            this.txtLicenseText.Location = new System.Drawing.Point(127, 64);
            this.txtLicenseText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLicenseText.Multiline = true;
            this.txtLicenseText.Name = "txtLicenseText";
            this.txtLicenseText.Size = new System.Drawing.Size(969, 89);
            this.txtLicenseText.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "License Text";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(1102, 8);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(20, 24);
            this.btnSelectFile.TabIndex = 4;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnActivateLicense
            // 
            this.btnActivateLicense.Location = new System.Drawing.Point(925, 173);
            this.btnActivateLicense.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnActivateLicense.Name = "btnActivateLicense";
            this.btnActivateLicense.Size = new System.Drawing.Size(188, 37);
            this.btnActivateLicense.TabIndex = 5;
            this.btnActivateLicense.Text = "Activate License";
            this.btnActivateLicense.UseVisualStyleBackColor = true;
            this.btnActivateLicense.Click += new System.EventHandler(this.btnActivateLicense_Click);
            // 
            // btnDisplayLicenseText
            // 
            this.btnDisplayLicenseText.Location = new System.Drawing.Point(5, 173);
            this.btnDisplayLicenseText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDisplayLicenseText.Name = "btnDisplayLicenseText";
            this.btnDisplayLicenseText.Size = new System.Drawing.Size(188, 37);
            this.btnDisplayLicenseText.TabIndex = 6;
            this.btnDisplayLicenseText.Text = "Display License Text";
            this.btnDisplayLicenseText.UseVisualStyleBackColor = true;
            this.btnDisplayLicenseText.Click += new System.EventHandler(this.btnDisplayLicenseText_Click);
            // 
            // F_LicenseActivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 220);
            this.Controls.Add(this.btnDisplayLicenseText);
            this.Controls.Add(this.btnActivateLicense);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLicenseText);
            this.Controls.Add(this.txtLicenseFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "F_LicenseActivation";
            this.Text = "License Activation";
            this.Load += new System.EventHandler(this.F_LicenseActivation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenseFile;
        private System.Windows.Forms.TextBox txtLicenseText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnActivateLicense;
        private System.Windows.Forms.Button btnDisplayLicenseText;
    }
}