namespace PayRollSystem
{
    partial class F_AttendanceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_AttendanceView));
            this.dgvAttendanceView = new System.Windows.Forms.DataGridView();
            this.AttendanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatePerHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbAttendanceType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbSpecificStaff = new System.Windows.Forms.CheckBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAttendanceView
            // 
            this.dgvAttendanceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAttendanceView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttendanceId,
            this.AttendanceType,
            this.Date,
            this.Hours,
            this.EmployeeId,
            this.FirstName,
            this.LastName,
            this.RegNumber,
            this.Salary,
            this.RatePerHour,
            this.AttendanceAmount});
            this.dgvAttendanceView.Location = new System.Drawing.Point(8, 79);
            this.dgvAttendanceView.Name = "dgvAttendanceView";
            this.dgvAttendanceView.RowTemplate.Height = 24;
            this.dgvAttendanceView.Size = new System.Drawing.Size(1148, 349);
            this.dgvAttendanceView.TabIndex = 1;
            // 
            // AttendanceId
            // 
            this.AttendanceId.HeaderText = "AttendanceId";
            this.AttendanceId.Name = "AttendanceId";
            // 
            // AttendanceType
            // 
            this.AttendanceType.HeaderText = "Attendance";
            this.AttendanceType.Name = "AttendanceType";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "EmployeeId";
            this.EmployeeId.Name = "EmployeeId";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "LastName";
            this.LastName.Name = "LastName";
            // 
            // RegNumber
            // 
            this.RegNumber.HeaderText = "RegNumber";
            this.RegNumber.Name = "RegNumber";
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Salary";
            this.Salary.Name = "Salary";
            // 
            // RatePerHour
            // 
            this.RatePerHour.HeaderText = "Rate Per Hour";
            this.RatePerHour.Name = "RatePerHour";
            this.RatePerHour.ReadOnly = true;
            // 
            // AttendanceAmount
            // 
            this.AttendanceAmount.HeaderText = "Attendance Amount";
            this.AttendanceAmount.Name = "AttendanceAmount";
            this.AttendanceAmount.ReadOnly = true;
            // 
            // cbAttendanceType
            // 
            this.cbAttendanceType.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAttendanceType.FormattingEnabled = true;
            this.cbAttendanceType.Items.AddRange(new object[] {
            "All",
            "Extra",
            "Absent"});
            this.cbAttendanceType.Location = new System.Drawing.Point(168, 10);
            this.cbAttendanceType.Margin = new System.Windows.Forms.Padding(4);
            this.cbAttendanceType.Name = "cbAttendanceType";
            this.cbAttendanceType.Size = new System.Drawing.Size(160, 23);
            this.cbAttendanceType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Attendance Type";
            // 
            // chkbSpecificStaff
            // 
            this.chkbSpecificStaff.AutoSize = true;
            this.chkbSpecificStaff.Location = new System.Drawing.Point(20, 47);
            this.chkbSpecificStaff.Margin = new System.Windows.Forms.Padding(4);
            this.chkbSpecificStaff.Name = "chkbSpecificStaff";
            this.chkbSpecificStaff.Size = new System.Drawing.Size(136, 23);
            this.chkbSpecificStaff.TabIndex = 4;
            this.chkbSpecificStaff.Text = "Specific Employee";
            this.chkbSpecificStaff.UseVisualStyleBackColor = true;
            this.chkbSpecificStaff.CheckedChanged += new System.EventHandler(this.chkbSpecificEmployee_CheckedChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(361, 13);
            this.lblEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(32, 15);
            this.lblEmployee.TabIndex = 6;
            this.lblEmployee.Text = "Staff";
            // 
            // cbStaff
            // 
            this.cbStaff.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStaff.FormattingEnabled = true;
            this.cbStaff.Location = new System.Drawing.Point(513, 9);
            this.cbStaff.Margin = new System.Windows.Forms.Padding(4);
            this.cbStaff.Name = "cbStaff";
            this.cbStaff.Size = new System.Drawing.Size(160, 23);
            this.cbStaff.TabIndex = 5;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFind.Location = new System.Drawing.Point(8, 430);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 34);
            this.btnFind.TabIndex = 7;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // F_AttendanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 463);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cbStaff);
            this.Controls.Add(this.chkbSpecificStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAttendanceType);
            this.Controls.Add(this.dgvAttendanceView);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_AttendanceView";
            this.Text = "Attendance View";
            this.Load += new System.EventHandler(this.F_AttendanceView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAttendanceView;
        private System.Windows.Forms.ComboBox cbAttendanceType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkbSpecificStaff;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatePerHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttendanceAmount;
    }
}