namespace Utilities
{
    partial class F_LicenseCreator
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
            this.chkPayroll = new System.Windows.Forms.CheckBox();
            this.chkInventory = new System.Windows.Forms.CheckBox();
            this.chkProduction = new System.Windows.Forms.CheckBox();
            this.txtLicesnseText = new System.Windows.Forms.TextBox();
            this.btnGenerateLicenseText = new System.Windows.Forms.Button();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.btnCreateLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkPayroll
            // 
            this.chkPayroll.AutoSize = true;
            this.chkPayroll.Location = new System.Drawing.Point(14, 15);
            this.chkPayroll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkPayroll.Name = "chkPayroll";
            this.chkPayroll.Size = new System.Drawing.Size(67, 20);
            this.chkPayroll.TabIndex = 0;
            this.chkPayroll.Text = "Payroll";
            this.chkPayroll.UseVisualStyleBackColor = true;
            // 
            // chkInventory
            // 
            this.chkInventory.AutoSize = true;
            this.chkInventory.Location = new System.Drawing.Point(14, 53);
            this.chkInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkInventory.Name = "chkInventory";
            this.chkInventory.Size = new System.Drawing.Size(82, 20);
            this.chkInventory.TabIndex = 1;
            this.chkInventory.Text = "Inventory";
            this.chkInventory.UseVisualStyleBackColor = true;
            // 
            // chkProduction
            // 
            this.chkProduction.AutoSize = true;
            this.chkProduction.Location = new System.Drawing.Point(14, 91);
            this.chkProduction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkProduction.Name = "chkProduction";
            this.chkProduction.Size = new System.Drawing.Size(88, 20);
            this.chkProduction.TabIndex = 2;
            this.chkProduction.Text = "Production";
            this.chkProduction.UseVisualStyleBackColor = true;
            // 
            // txtLicesnseText
            // 
            this.txtLicesnseText.Location = new System.Drawing.Point(168, 15);
            this.txtLicesnseText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLicesnseText.Multiline = true;
            this.txtLicesnseText.Name = "txtLicesnseText";
            this.txtLicesnseText.Size = new System.Drawing.Size(676, 96);
            this.txtLicesnseText.TabIndex = 3;
            // 
            // btnGenerateLicenseText
            // 
            this.btnGenerateLicenseText.Location = new System.Drawing.Point(168, 258);
            this.btnGenerateLicenseText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerateLicenseText.Name = "btnGenerateLicenseText";
            this.btnGenerateLicenseText.Size = new System.Drawing.Size(150, 28);
            this.btnGenerateLicenseText.TabIndex = 4;
            this.btnGenerateLicenseText.Text = "Generate License Text";
            this.btnGenerateLicenseText.UseVisualStyleBackColor = true;
            this.btnGenerateLicenseText.Click += new System.EventHandler(this.btnGenerateLicenseText_Click);
            // 
            // txtLicense
            // 
            this.txtLicense.Location = new System.Drawing.Point(168, 143);
            this.txtLicense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLicense.Multiline = true;
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.Size = new System.Drawing.Size(676, 96);
            this.txtLicense.TabIndex = 5;
            this.txtLicense.TextChanged += new System.EventHandler(this.txtLicense_TextChanged);
            // 
            // btnCreateLicense
            // 
            this.btnCreateLicense.Location = new System.Drawing.Point(324, 258);
            this.btnCreateLicense.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateLicense.Name = "btnCreateLicense";
            this.btnCreateLicense.Size = new System.Drawing.Size(115, 28);
            this.btnCreateLicense.TabIndex = 6;
            this.btnCreateLicense.Text = "Create License";
            this.btnCreateLicense.UseVisualStyleBackColor = true;
            this.btnCreateLicense.Click += new System.EventHandler(this.btnCreateLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(729, 258);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // F_LicenseCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 292);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateLicense);
            this.Controls.Add(this.txtLicense);
            this.Controls.Add(this.btnGenerateLicenseText);
            this.Controls.Add(this.txtLicesnseText);
            this.Controls.Add(this.chkProduction);
            this.Controls.Add(this.chkInventory);
            this.Controls.Add(this.chkPayroll);
            this.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "F_LicenseCreator";
            this.Text = "License Creator";
            this.Load += new System.EventHandler(this.F_LicenseCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPayroll;
        private System.Windows.Forms.CheckBox chkInventory;
        private System.Windows.Forms.CheckBox chkProduction;
        private System.Windows.Forms.TextBox txtLicesnseText;
        private System.Windows.Forms.Button btnGenerateLicenseText;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Button btnCreateLicense;
        private System.Windows.Forms.Button btnClose;
    }
}