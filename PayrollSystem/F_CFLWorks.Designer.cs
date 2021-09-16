namespace PayRollSystem
{
    partial class F_CFLWorks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_CFLWorks));
            this.dgvWorks = new System.Windows.Forms.DataGridView();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnumWorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWorks
            // 
            this.dgvWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkId,
            this.WorkName,
            this.WorkDescription,
            this.EnumWorkType,
            this.SetupTime,
            this.RunTime,
            this.WorkCost});
            this.dgvWorks.Location = new System.Drawing.Point(4, 62);
            this.dgvWorks.Margin = new System.Windows.Forms.Padding(4);
            this.dgvWorks.Name = "dgvWorks";
            this.dgvWorks.Size = new System.Drawing.Size(514, 350);
            this.dgvWorks.TabIndex = 0;
            // 
            // WorkId
            // 
            this.WorkId.HeaderText = "Work Id";
            this.WorkId.Name = "WorkId";
            this.WorkId.ReadOnly = true;
            this.WorkId.Visible = false;
            // 
            // WorkName
            // 
            this.WorkName.HeaderText = "Work Name";
            this.WorkName.Name = "WorkName";
            this.WorkName.Width = 150;
            // 
            // WorkDescription
            // 
            this.WorkDescription.HeaderText = "Work Description";
            this.WorkDescription.Name = "WorkDescription";
            this.WorkDescription.ReadOnly = true;
            this.WorkDescription.Width = 200;
            // 
            // EnumWorkType
            // 
            this.EnumWorkType.HeaderText = "Work Type";
            this.EnumWorkType.Name = "EnumWorkType";
            this.EnumWorkType.ReadOnly = true;
            this.EnumWorkType.Width = 120;
            // 
            // SetupTime
            // 
            this.SetupTime.HeaderText = "Setup Time";
            this.SetupTime.Name = "SetupTime";
            this.SetupTime.ReadOnly = true;
            this.SetupTime.Visible = false;
            // 
            // RunTime
            // 
            this.RunTime.HeaderText = "Run Time";
            this.RunTime.Name = "RunTime";
            this.RunTime.ReadOnly = true;
            this.RunTime.Visible = false;
            // 
            // WorkCost
            // 
            this.WorkCost.HeaderText = "WorkCost";
            this.WorkCost.Name = "WorkCost";
            this.WorkCost.ReadOnly = true;
            this.WorkCost.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_FormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 60);
            this.panel2.TabIndex = 17;
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Ubuntu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FormTitle.Location = new System.Drawing.Point(10, 17);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(59, 25);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "Work";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(4, 419);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 27);
            this.btnSelect.TabIndex = 18;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(443, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // F_CFLWorks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvWorks);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "F_CFLWorks";
            this.Text = "CFL Works";
            this.Load += new System.EventHandler(this.F_CFLWorks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorks;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnumWorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetupTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
    }
}