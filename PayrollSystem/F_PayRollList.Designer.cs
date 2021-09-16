namespace PayRollSystem
{
    partial class F_PayRollList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_PayRollList));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbEmployeeType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEmployeeDetails = new System.Windows.Forms.DataGridView();
            this.StaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HouseAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TravelAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedicalAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NSSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(124, 16);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(229, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // chkSelect
            // 
            this.chkSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelect.AutoSize = true;
            this.chkSelect.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelect.Location = new System.Drawing.Point(16, 627);
            this.chkSelect.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(128, 19);
            this.chkSelect.TabIndex = 7;
            this.chkSelect.Text = "Select All/UnSelect";
            this.chkSelect.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(16, 655);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 34);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1310, 655);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbEmployeeType
            // 
            this.cbEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployeeType.FormattingEnabled = true;
            this.cbEmployeeType.Items.AddRange(new object[] {
            "All",
            "Permanent",
            "Casual"});
            this.cbEmployeeType.Location = new System.Drawing.Point(123, 48);
            this.cbEmployeeType.Name = "cbEmployeeType";
            this.cbEmployeeType.Size = new System.Drawing.Size(230, 27);
            this.cbEmployeeType.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Employee Type";
            // 
            // dgvEmployeeDetails
            // 
            this.dgvEmployeeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffId,
            this.StaffName,
            this.Department,
            this.SubDepartment,
            this.Date,
            this.HouseAllowance,
            this.TravelAllowance,
            this.MedicalAllowance,
            this.TotalAllowance,
            this.NHIF,
            this.NSSF,
            this.Pension,
            this.PAYE,
            this.GrossSalary,
            this.NetSalary});
            this.dgvEmployeeDetails.Location = new System.Drawing.Point(16, 79);
            this.dgvEmployeeDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployeeDetails.Name = "dgvEmployeeDetails";
            this.dgvEmployeeDetails.Size = new System.Drawing.Size(1394, 531);
            this.dgvEmployeeDetails.TabIndex = 6;
            // 
            // StaffId
            // 
            this.StaffId.HeaderText = "Staff Id";
            this.StaffId.Name = "StaffId";
            // 
            // StaffName
            // 
            this.StaffName.HeaderText = "Staff Name";
            this.StaffName.Name = "StaffName";
            // 
            // Department
            // 
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            // 
            // SubDepartment
            // 
            this.SubDepartment.HeaderText = "Sub Department";
            this.SubDepartment.Name = "SubDepartment";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // HouseAllowance
            // 
            this.HouseAllowance.HeaderText = "House Allowance";
            this.HouseAllowance.Name = "HouseAllowance";
            // 
            // TravelAllowance
            // 
            this.TravelAllowance.HeaderText = "Travel Allowance";
            this.TravelAllowance.Name = "TravelAllowance";
            // 
            // MedicalAllowance
            // 
            this.MedicalAllowance.HeaderText = "Medical Allowance";
            this.MedicalAllowance.Name = "MedicalAllowance";
            // 
            // TotalAllowance
            // 
            this.TotalAllowance.HeaderText = "Total Allowance";
            this.TotalAllowance.Name = "TotalAllowance";
            // 
            // NHIF
            // 
            this.NHIF.HeaderText = "NHIF";
            this.NHIF.Name = "NHIF";
            // 
            // NSSF
            // 
            this.NSSF.HeaderText = "NSSF";
            this.NSSF.Name = "NSSF";
            // 
            // Pension
            // 
            this.Pension.HeaderText = "Pension";
            this.Pension.Name = "Pension";
            // 
            // PAYE
            // 
            this.PAYE.HeaderText = "PAYE";
            this.PAYE.Name = "PAYE";
            // 
            // GrossSalary
            // 
            this.GrossSalary.HeaderText = "Gross Salary";
            this.GrossSalary.Name = "GrossSalary";
            // 
            // NetSalary
            // 
            this.NetSalary.HeaderText = "NetSalary";
            this.NetSalary.Name = "NetSalary";
            // 
            // F_PayRollList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 693);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEmployeeType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.dgvEmployeeDetails);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_PayRollList";
            this.Text = "Payroll List";
            this.Load += new System.EventHandler(this.F_PayRollDeductions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbEmployeeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEmployeeDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn HouseAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn TravelAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedicalAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHIF;
        private System.Windows.Forms.DataGridViewTextBoxColumn NSSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pension;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetSalary;
    }
}