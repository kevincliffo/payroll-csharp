namespace PayRollSystem
{
    partial class F_WorkOrderTemplates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_WorkOrderTemplates));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.dgvWorkOrderTemplates = new System.Windows.Forms.DataGridView();
            this.WorkOrderTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkOrderTemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkOrderTemplateNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkOrderTemplateDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_FormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(709, 66);
            this.panel2.TabIndex = 18;
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Ubuntu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FormTitle.Location = new System.Drawing.Point(13, 25);
            this.lbl_FormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(216, 25);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "Work Order Templates";
            // 
            // dgvWorkOrderTemplates
            // 
            this.dgvWorkOrderTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorkOrderTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrderTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkOrderTemplateId,
            this.WorkOrderTemplateName,
            this.WorkOrderTemplateNumber,
            this.WorkOrderTemplateDescription});
            this.dgvWorkOrderTemplates.Location = new System.Drawing.Point(3, 75);
            this.dgvWorkOrderTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.dgvWorkOrderTemplates.Name = "dgvWorkOrderTemplates";
            this.dgvWorkOrderTemplates.Size = new System.Drawing.Size(693, 544);
            this.dgvWorkOrderTemplates.TabIndex = 19;
            // 
            // WorkOrderTemplateId
            // 
            this.WorkOrderTemplateId.HeaderText = "Template Id";
            this.WorkOrderTemplateId.Name = "WorkOrderTemplateId";
            this.WorkOrderTemplateId.ReadOnly = true;
            this.WorkOrderTemplateId.Width = 110;
            // 
            // WorkOrderTemplateName
            // 
            this.WorkOrderTemplateName.HeaderText = "Template Name";
            this.WorkOrderTemplateName.Name = "WorkOrderTemplateName";
            this.WorkOrderTemplateName.ReadOnly = true;
            this.WorkOrderTemplateName.Width = 140;
            // 
            // WorkOrderTemplateNumber
            // 
            this.WorkOrderTemplateNumber.HeaderText = "Template Number";
            this.WorkOrderTemplateNumber.Name = "WorkOrderTemplateNumber";
            this.WorkOrderTemplateNumber.ReadOnly = true;
            this.WorkOrderTemplateNumber.Width = 150;
            // 
            // WorkOrderTemplateDescription
            // 
            this.WorkOrderTemplateDescription.HeaderText = "Template Description";
            this.WorkOrderTemplateDescription.Name = "WorkOrderTemplateDescription";
            this.WorkOrderTemplateDescription.ReadOnly = true;
            this.WorkOrderTemplateDescription.Width = 170;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Location = new System.Drawing.Point(3, 627);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(100, 34);
            this.btnSelect.TabIndex = 20;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(597, 627);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // F_WorkOrderTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 661);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvWorkOrderTemplates);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_WorkOrderTemplates";
            this.Text = "Work Order Templates";
            this.Load += new System.EventHandler(this.F_WorkOrderTemplates_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderTemplates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.DataGridView dgvWorkOrderTemplates;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOrderTemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOrderTemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOrderTemplateNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkOrderTemplateDescription;
    }
}