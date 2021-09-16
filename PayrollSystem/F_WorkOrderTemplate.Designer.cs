namespace PayRollSystem
{
    partial class F_WorkOrderTemplate
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_WorkOrderTemplate));
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.tcItems = new System.Windows.Forms.TabControl();
            this.tpMaterials = new System.Windows.Forms.TabPage();
            this.btnRemoveItemsRow = new System.Windows.Forms.Button();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.MaterialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpWork = new System.Windows.Forms.TabPage();
            this.btnRemoveTaskRow = new System.Windows.Forms.Button();
            this.dgvWorks = new System.Windows.Forms.DataGridView();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsContextCall = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTemplateDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemplateNumber = new System.Windows.Forms.TextBox();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.gbItems.SuspendLayout();
            this.tcItems.SuspendLayout();
            this.tpMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.tpWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).BeginInit();
            this.cmsContextCall.SuspendLayout();
            this.gbHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItems
            // 
            this.gbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItems.Controls.Add(this.tcItems);
            this.gbItems.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItems.Location = new System.Drawing.Point(12, 187);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(870, 300);
            this.gbItems.TabIndex = 6;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Items";
            // 
            // tcItems
            // 
            this.tcItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcItems.Controls.Add(this.tpMaterials);
            this.tcItems.Controls.Add(this.tpWork);
            this.tcItems.Location = new System.Drawing.Point(6, 25);
            this.tcItems.Name = "tcItems";
            this.tcItems.SelectedIndex = 0;
            this.tcItems.Size = new System.Drawing.Size(858, 269);
            this.tcItems.TabIndex = 0;
            // 
            // tpMaterials
            // 
            this.tpMaterials.Controls.Add(this.btnRemoveItemsRow);
            this.tpMaterials.Controls.Add(this.dgvMaterials);
            this.tpMaterials.Location = new System.Drawing.Point(4, 28);
            this.tpMaterials.Name = "tpMaterials";
            this.tpMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaterials.Size = new System.Drawing.Size(850, 237);
            this.tpMaterials.TabIndex = 0;
            this.tpMaterials.Text = "Materials";
            this.tpMaterials.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItemsRow
            // 
            this.btnRemoveItemsRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveItemsRow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItemsRow.Location = new System.Drawing.Point(721, 208);
            this.btnRemoveItemsRow.Name = "btnRemoveItemsRow";
            this.btnRemoveItemsRow.Size = new System.Drawing.Size(123, 23);
            this.btnRemoveItemsRow.TabIndex = 3;
            this.btnRemoveItemsRow.Text = "Remove Row";
            this.btnRemoveItemsRow.UseVisualStyleBackColor = true;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialId,
            this.MaterialName,
            this.MaterialDescription,
            this.UnitOfMeasure,
            this.Quantity,
            this.PricePerUnit,
            this.MaterialRatio});
            this.dgvMaterials.Location = new System.Drawing.Point(9, 6);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.Size = new System.Drawing.Size(835, 196);
            this.dgvMaterials.TabIndex = 1;
            // 
            // MaterialId
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.MaterialId.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaterialId.HeaderText = "Material Id";
            this.MaterialId.Name = "MaterialId";
            this.MaterialId.ReadOnly = true;
            // 
            // MaterialName
            // 
            this.MaterialName.HeaderText = "Material Name";
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.ReadOnly = true;
            this.MaterialName.Width = 120;
            // 
            // MaterialDescription
            // 
            this.MaterialDescription.HeaderText = "Material Description";
            this.MaterialDescription.Name = "MaterialDescription";
            this.MaterialDescription.ReadOnly = true;
            this.MaterialDescription.Width = 180;
            // 
            // UnitOfMeasure
            // 
            this.UnitOfMeasure.HeaderText = "UOM";
            this.UnitOfMeasure.Name = "UnitOfMeasure";
            this.UnitOfMeasure.ReadOnly = true;
            // 
            // Quantity
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // PricePerUnit
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.PricePerUnit.DefaultCellStyle = dataGridViewCellStyle3;
            this.PricePerUnit.HeaderText = "Price Per Unit";
            this.PricePerUnit.Name = "PricePerUnit";
            this.PricePerUnit.ReadOnly = true;
            this.PricePerUnit.Width = 120;
            // 
            // MaterialRatio
            // 
            this.MaterialRatio.HeaderText = "Material Ratio";
            this.MaterialRatio.Name = "MaterialRatio";
            // 
            // tpWork
            // 
            this.tpWork.Controls.Add(this.btnRemoveTaskRow);
            this.tpWork.Controls.Add(this.dgvWorks);
            this.tpWork.Location = new System.Drawing.Point(4, 28);
            this.tpWork.Name = "tpWork";
            this.tpWork.Padding = new System.Windows.Forms.Padding(3);
            this.tpWork.Size = new System.Drawing.Size(850, 237);
            this.tpWork.TabIndex = 1;
            this.tpWork.Text = "Work";
            this.tpWork.UseVisualStyleBackColor = true;
            // 
            // btnRemoveTaskRow
            // 
            this.btnRemoveTaskRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTaskRow.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveTaskRow.Location = new System.Drawing.Point(735, 208);
            this.btnRemoveTaskRow.Name = "btnRemoveTaskRow";
            this.btnRemoveTaskRow.Size = new System.Drawing.Size(108, 23);
            this.btnRemoveTaskRow.TabIndex = 3;
            this.btnRemoveTaskRow.Text = "Remove Row";
            this.btnRemoveTaskRow.UseVisualStyleBackColor = true;
            // 
            // dgvWorks
            // 
            this.dgvWorks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkId,
            this.WorkName,
            this.WorkDescription,
            this.WorkCost,
            this.WorkRatio});
            this.dgvWorks.Location = new System.Drawing.Point(8, 6);
            this.dgvWorks.Name = "dgvWorks";
            this.dgvWorks.Size = new System.Drawing.Size(835, 196);
            this.dgvWorks.TabIndex = 1;
            // 
            // WorkId
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.WorkId.DefaultCellStyle = dataGridViewCellStyle4;
            this.WorkId.HeaderText = "Work Id";
            this.WorkId.Name = "WorkId";
            // 
            // WorkName
            // 
            this.WorkName.HeaderText = "Work Name";
            this.WorkName.Name = "WorkName";
            this.WorkName.ReadOnly = true;
            this.WorkName.Width = 120;
            // 
            // WorkDescription
            // 
            this.WorkDescription.HeaderText = "Work Description";
            this.WorkDescription.Name = "WorkDescription";
            this.WorkDescription.ReadOnly = true;
            this.WorkDescription.Width = 150;
            // 
            // WorkCost
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.WorkCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.WorkCost.HeaderText = "Work Cost";
            this.WorkCost.Name = "WorkCost";
            this.WorkCost.ReadOnly = true;
            // 
            // WorkRatio
            // 
            this.WorkRatio.HeaderText = "Work Ratio";
            this.WorkRatio.Name = "WorkRatio";
            // 
            // cmsContextCall
            // 
            this.cmsContextCall.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsContextCall.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddOrder});
            this.cmsContextCall.Name = "cmsContextCall";
            this.cmsContextCall.Size = new System.Drawing.Size(180, 28);
            this.cmsContextCall.Text = "Add Order";
            // 
            // tsmiAddOrder
            // 
            this.tsmiAddOrder.Name = "tsmiAddOrder";
            this.tsmiAddOrder.Size = new System.Drawing.Size(179, 24);
            this.tsmiAddOrder.Text = "Add Work Order";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(807, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(104, 493);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 493);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTemplateDescription
            // 
            this.txtTemplateDescription.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateDescription.Location = new System.Drawing.Point(537, 22);
            this.txtTemplateDescription.Name = "txtTemplateDescription";
            this.txtTemplateDescription.Size = new System.Drawing.Size(323, 22);
            this.txtTemplateDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(397, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Template Description";
            // 
            // txtTemplateNumber
            // 
            this.txtTemplateNumber.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateNumber.Location = new System.Drawing.Point(132, 56);
            this.txtTemplateNumber.Name = "txtTemplateNumber";
            this.txtTemplateNumber.Size = new System.Drawing.Size(203, 22);
            this.txtTemplateNumber.TabIndex = 3;
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemplateName.Location = new System.Drawing.Point(132, 25);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(203, 22);
            this.txtTemplateName.TabIndex = 2;
            // 
            // gbHeader
            // 
            this.gbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeader.Controls.Add(this.txtTemplateDescription);
            this.gbHeader.Controls.Add(this.label3);
            this.gbHeader.Controls.Add(this.txtTemplateNumber);
            this.gbHeader.Controls.Add(this.txtTemplateName);
            this.gbHeader.Controls.Add(this.label2);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHeader.Location = new System.Drawing.Point(12, 69);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(870, 114);
            this.gbHeader.TabIndex = 5;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "Header";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Template Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Template Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_FormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 60);
            this.panel2.TabIndex = 17;
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Ubuntu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FormTitle.Location = new System.Drawing.Point(10, 17);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(207, 25);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "Work Order Template";
            // 
            // F_WorkOrderTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_WorkOrderTemplate";
            this.Text = "Work Order Template";
            this.Load += new System.EventHandler(this.F_WorkOrderTemplate_Load);
            this.gbItems.ResumeLayout(false);
            this.tcItems.ResumeLayout(false);
            this.tpMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.tpWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).EndInit();
            this.cmsContextCall.ResumeLayout(false);
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.TabControl tcItems;
        private System.Windows.Forms.TabPage tpMaterials;
        private System.Windows.Forms.Button btnRemoveItemsRow;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.TabPage tpWork;
        private System.Windows.Forms.Button btnRemoveTaskRow;
        private System.Windows.Forms.DataGridView dgvWorks;
        private System.Windows.Forms.ContextMenuStrip cmsContextCall;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTemplateDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTemplateNumber;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkRatio;
    }
}