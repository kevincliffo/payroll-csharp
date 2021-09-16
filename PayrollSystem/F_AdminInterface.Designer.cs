namespace PayRollSystem
{
    partial class F_AdminInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_AdminInterface));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbAdministrationDetails = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryModule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ProductionModule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PayrollModule = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkPayrollManagementModule = new System.Windows.Forms.CheckBox();
            this.chkProductionModule = new System.Windows.Forms.CheckBox();
            this.chkInventoryModule = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.gbAdministrationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1038, 554);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(6, 554);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // gbAdministrationDetails
            // 
            this.gbAdministrationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAdministrationDetails.Controls.Add(this.dgvUsers);
            this.gbAdministrationDetails.Controls.Add(this.chkPayrollManagementModule);
            this.gbAdministrationDetails.Controls.Add(this.chkProductionModule);
            this.gbAdministrationDetails.Controls.Add(this.chkInventoryModule);
            this.gbAdministrationDetails.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAdministrationDetails.Location = new System.Drawing.Point(0, 49);
            this.gbAdministrationDetails.Name = "gbAdministrationDetails";
            this.gbAdministrationDetails.Size = new System.Drawing.Size(1113, 502);
            this.gbAdministrationDetails.TabIndex = 25;
            this.gbAdministrationDetails.TabStop = false;
            this.gbAdministrationDetails.Text = "Administration Details";
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.UserName,
            this.FullName,
            this.UserType,
            this.Password,
            this.InventoryModule,
            this.ProductionModule,
            this.PayrollModule});
            this.dgvUsers.Location = new System.Drawing.Point(6, 118);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(1097, 367);
            this.dgvUsers.TabIndex = 4;
            // 
            // UserId
            // 
            this.UserId.HeaderText = "User Id";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Width = 110;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 150;
            // 
            // FullName
            // 
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // UserType
            // 
            this.UserType.HeaderText = "User Type";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            // 
            // InventoryModule
            // 
            this.InventoryModule.HeaderText = "Inventory Module";
            this.InventoryModule.Name = "InventoryModule";
            this.InventoryModule.ReadOnly = true;
            this.InventoryModule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryModule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.InventoryModule.Width = 140;
            // 
            // ProductionModule
            // 
            this.ProductionModule.HeaderText = "Production Module";
            this.ProductionModule.Name = "ProductionModule";
            this.ProductionModule.ReadOnly = true;
            this.ProductionModule.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductionModule.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductionModule.Width = 150;
            // 
            // PayrollModule
            // 
            this.PayrollModule.HeaderText = "Payroll Module";
            this.PayrollModule.Name = "PayrollModule";
            this.PayrollModule.ReadOnly = true;
            this.PayrollModule.Width = 140;
            // 
            // chkPayrollManagementModule
            // 
            this.chkPayrollManagementModule.AutoSize = true;
            this.chkPayrollManagementModule.Location = new System.Drawing.Point(6, 73);
            this.chkPayrollManagementModule.Name = "chkPayrollManagementModule";
            this.chkPayrollManagementModule.Size = new System.Drawing.Size(202, 23);
            this.chkPayrollManagementModule.TabIndex = 3;
            this.chkPayrollManagementModule.Text = "Payroll Management Module";
            this.chkPayrollManagementModule.UseVisualStyleBackColor = true;
            // 
            // chkProductionModule
            // 
            this.chkProductionModule.AutoSize = true;
            this.chkProductionModule.Location = new System.Drawing.Point(6, 52);
            this.chkProductionModule.Name = "chkProductionModule";
            this.chkProductionModule.Size = new System.Drawing.Size(142, 23);
            this.chkProductionModule.TabIndex = 2;
            this.chkProductionModule.Text = "Production Module";
            this.chkProductionModule.UseVisualStyleBackColor = true;
            // 
            // chkInventoryModule
            // 
            this.chkInventoryModule.AutoSize = true;
            this.chkInventoryModule.Location = new System.Drawing.Point(6, 31);
            this.chkInventoryModule.Name = "chkInventoryModule";
            this.chkInventoryModule.Size = new System.Drawing.Size(133, 23);
            this.chkInventoryModule.TabIndex = 1;
            this.chkInventoryModule.Text = "Inventory Module";
            this.chkInventoryModule.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_FormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1115, 44);
            this.panel2.TabIndex = 29;
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Ubuntu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FormTitle.Location = new System.Drawing.Point(6, 9);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(228, 25);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "Administrator Interface";
            // 
            // F_AdminInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.gbAdministrationDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "F_AdminInterface";
            this.Text = "Administrator Interface";
            this.Load += new System.EventHandler(this.F_AdminInterface_Load);
            this.gbAdministrationDetails.ResumeLayout(false);
            this.gbAdministrationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gbAdministrationDetails;
        private System.Windows.Forms.CheckBox chkPayrollManagementModule;
        private System.Windows.Forms.CheckBox chkProductionModule;
        private System.Windows.Forms.CheckBox chkInventoryModule;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InventoryModule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ProductionModule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PayrollModule;
    }
}