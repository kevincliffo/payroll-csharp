namespace PayRollSystem
{
    partial class F_WorkOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_WorkOrder));
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.tcItems = new System.Windows.Forms.TabControl();
            this.tpMaterials = new System.Windows.Forms.TabPage();
            this.btnRemoveItemsRow = new System.Windows.Forms.Button();
            this.dgvWorkOrderMaterials = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitOfMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpWork = new System.Windows.Forms.TabPage();
            this.btnRemoveTaskRow = new System.Windows.Forms.Button();
            this.dgvWorkOrderWorks = new System.Windows.Forms.DataGridView();
            this.WorkNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpEmployeesWorkData = new System.Windows.Forms.TabPage();
            this.btnRemoveEmployeeWorkDataRow = new System.Windows.Forms.Button();
            this.btnAddEmployeeWorkDataRow = new System.Windows.Forms.Button();
            this.dgvEmployeeWorkData = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachedWork = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tpCostings = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tsmiAddOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.txtWorkOrderTemplateDescription = new System.Windows.Forms.TextBox();
            this.cmsContextCall = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_FormTitle = new System.Windows.Forms.Label();
            this.txtWorkOrderTemplateName = new System.Windows.Forms.TextBox();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWorkOrderTemplateNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkOrderNumber = new System.Windows.Forms.TextBox();
            this.gbItems.SuspendLayout();
            this.tcItems.SuspendLayout();
            this.tpMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderMaterials)).BeginInit();
            this.tpWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderWorks)).BeginInit();
            this.tpEmployeesWorkData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeWorkData)).BeginInit();
            this.tpCostings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.cmsContextCall.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbHeader.SuspendLayout();
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
            this.gbItems.TabIndex = 19;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Items";
            // 
            // tcItems
            // 
            this.tcItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcItems.Controls.Add(this.tpMaterials);
            this.tcItems.Controls.Add(this.tpWork);
            this.tcItems.Controls.Add(this.tpEmployeesWorkData);
            this.tcItems.Controls.Add(this.tpCostings);
            this.tcItems.Location = new System.Drawing.Point(6, 25);
            this.tcItems.Name = "tcItems";
            this.tcItems.SelectedIndex = 0;
            this.tcItems.Size = new System.Drawing.Size(858, 269);
            this.tcItems.TabIndex = 0;
            // 
            // tpMaterials
            // 
            this.tpMaterials.Controls.Add(this.btnRemoveItemsRow);
            this.tpMaterials.Controls.Add(this.dgvWorkOrderMaterials);
            this.tpMaterials.Location = new System.Drawing.Point(4, 28);
            this.tpMaterials.Name = "tpMaterials";
            this.tpMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaterials.Size = new System.Drawing.Size(850, 237);
            this.tpMaterials.TabIndex = 0;
            this.tpMaterials.Text = "Work Order Materials";
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
            // dgvWorkOrderMaterials
            // 
            this.dgvWorkOrderMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorkOrderMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrderMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.ItemName,
            this.ItemDescription,
            this.UnitOfMeasure,
            this.Quantity,
            this.PricePerUnit,
            this.MaterialRatio});
            this.dgvWorkOrderMaterials.Location = new System.Drawing.Point(9, 6);
            this.dgvWorkOrderMaterials.MultiSelect = false;
            this.dgvWorkOrderMaterials.Name = "dgvWorkOrderMaterials";
            this.dgvWorkOrderMaterials.Size = new System.Drawing.Size(835, 196);
            this.dgvWorkOrderMaterials.TabIndex = 1;
            // 
            // ItemId
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.ItemId.DefaultCellStyle = dataGridViewCellStyle1;
            this.ItemId.HeaderText = "Item Id";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemDescription
            // 
            this.ItemDescription.HeaderText = "Item Description";
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.ReadOnly = true;
            this.ItemDescription.Width = 180;
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
            this.MaterialRatio.ReadOnly = true;
            this.MaterialRatio.Width = 120;
            // 
            // tpWork
            // 
            this.tpWork.Controls.Add(this.btnRemoveTaskRow);
            this.tpWork.Controls.Add(this.dgvWorkOrderWorks);
            this.tpWork.Location = new System.Drawing.Point(4, 28);
            this.tpWork.Name = "tpWork";
            this.tpWork.Padding = new System.Windows.Forms.Padding(3);
            this.tpWork.Size = new System.Drawing.Size(850, 237);
            this.tpWork.TabIndex = 1;
            this.tpWork.Text = "Work Order Works";
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
            // dgvWorkOrderWorks
            // 
            this.dgvWorkOrderWorks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWorkOrderWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkOrderWorks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkNumber,
            this.WorkName,
            this.WorkDescription,
            this.WorkCost,
            this.WorkRatio});
            this.dgvWorkOrderWorks.Location = new System.Drawing.Point(8, 6);
            this.dgvWorkOrderWorks.MultiSelect = false;
            this.dgvWorkOrderWorks.Name = "dgvWorkOrderWorks";
            this.dgvWorkOrderWorks.Size = new System.Drawing.Size(835, 196);
            this.dgvWorkOrderWorks.TabIndex = 1;
            // 
            // WorkNumber
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.WorkNumber.DefaultCellStyle = dataGridViewCellStyle4;
            this.WorkNumber.HeaderText = "Work Number";
            this.WorkNumber.Name = "WorkNumber";
            this.WorkNumber.Width = 130;
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
            this.WorkRatio.ReadOnly = true;
            // 
            // tpEmployeesWorkData
            // 
            this.tpEmployeesWorkData.Controls.Add(this.btnRemoveEmployeeWorkDataRow);
            this.tpEmployeesWorkData.Controls.Add(this.btnAddEmployeeWorkDataRow);
            this.tpEmployeesWorkData.Controls.Add(this.dgvEmployeeWorkData);
            this.tpEmployeesWorkData.Location = new System.Drawing.Point(4, 28);
            this.tpEmployeesWorkData.Name = "tpEmployeesWorkData";
            this.tpEmployeesWorkData.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployeesWorkData.Size = new System.Drawing.Size(850, 237);
            this.tpEmployeesWorkData.TabIndex = 2;
            this.tpEmployeesWorkData.Text = "Employees Work Data";
            this.tpEmployeesWorkData.UseVisualStyleBackColor = true;
            // 
            // btnRemoveEmployeeWorkDataRow
            // 
            this.btnRemoveEmployeeWorkDataRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveEmployeeWorkDataRow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveEmployeeWorkDataRow.Location = new System.Drawing.Point(724, 205);
            this.btnRemoveEmployeeWorkDataRow.Name = "btnRemoveEmployeeWorkDataRow";
            this.btnRemoveEmployeeWorkDataRow.Size = new System.Drawing.Size(119, 23);
            this.btnRemoveEmployeeWorkDataRow.TabIndex = 7;
            this.btnRemoveEmployeeWorkDataRow.Text = "Remove Row";
            this.btnRemoveEmployeeWorkDataRow.UseVisualStyleBackColor = true;
            // 
            // btnAddEmployeeWorkDataRow
            // 
            this.btnAddEmployeeWorkDataRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddEmployeeWorkDataRow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployeeWorkDataRow.Location = new System.Drawing.Point(10, 208);
            this.btnAddEmployeeWorkDataRow.Name = "btnAddEmployeeWorkDataRow";
            this.btnAddEmployeeWorkDataRow.Size = new System.Drawing.Size(81, 23);
            this.btnAddEmployeeWorkDataRow.TabIndex = 6;
            this.btnAddEmployeeWorkDataRow.Text = "Add Row";
            this.btnAddEmployeeWorkDataRow.UseVisualStyleBackColor = true;
            this.btnAddEmployeeWorkDataRow.Click += new System.EventHandler(this.btnAddEmployeeWorkDataRow_Click);
            // 
            // dgvEmployeeWorkData
            // 
            this.dgvEmployeeWorkData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeWorkData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeWorkData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.FirstName,
            this.LastName,
            this.OtherName,
            this.AttachedWork});
            this.dgvEmployeeWorkData.Location = new System.Drawing.Point(8, 20);
            this.dgvEmployeeWorkData.MultiSelect = false;
            this.dgvEmployeeWorkData.Name = "dgvEmployeeWorkData";
            this.dgvEmployeeWorkData.Size = new System.Drawing.Size(835, 179);
            this.dgvEmployeeWorkData.TabIndex = 2;
            // 
            // EmployeeId
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.EmployeeId.DefaultCellStyle = dataGridViewCellStyle6;
            this.EmployeeId.HeaderText = "Employee Id";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EmployeeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EmployeeId.Width = 110;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 120;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 150;
            // 
            // OtherName
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.OtherName.DefaultCellStyle = dataGridViewCellStyle7;
            this.OtherName.HeaderText = "Other Name";
            this.OtherName.Name = "OtherName";
            this.OtherName.ReadOnly = true;
            this.OtherName.Width = 110;
            // 
            // AttachedWork
            // 
            this.AttachedWork.HeaderText = "Attached Work";
            this.AttachedWork.Name = "AttachedWork";
            this.AttachedWork.Width = 120;
            // 
            // tpCostings
            // 
            this.tpCostings.Controls.Add(this.dataGridView1);
            this.tpCostings.Location = new System.Drawing.Point(4, 28);
            this.tpCostings.Name = "tpCostings";
            this.tpCostings.Padding = new System.Windows.Forms.Padding(3);
            this.tpCostings.Size = new System.Drawing.Size(850, 237);
            this.tpCostings.TabIndex = 3;
            this.tpCostings.Text = "Costings";
            this.tpCostings.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.Costs});
            this.dataGridView1.Location = new System.Drawing.Point(3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(347, 225);
            this.dataGridView1.TabIndex = 0;
            // 
            // Items
            // 
            this.Items.HeaderText = "Items";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 150;
            // 
            // Costs
            // 
            this.Costs.HeaderText = "Costs";
            this.Costs.Name = "Costs";
            this.Costs.ReadOnly = true;
            this.Costs.Width = 150;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(807, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(93, 493);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 21;
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
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tsmiAddOrder
            // 
            this.tsmiAddOrder.Name = "tsmiAddOrder";
            this.tsmiAddOrder.Size = new System.Drawing.Size(144, 24);
            this.tsmiAddOrder.Text = "Add Order";
            // 
            // txtWorkOrderTemplateDescription
            // 
            this.txtWorkOrderTemplateDescription.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOrderTemplateDescription.Location = new System.Drawing.Point(388, 51);
            this.txtWorkOrderTemplateDescription.Name = "txtWorkOrderTemplateDescription";
            this.txtWorkOrderTemplateDescription.Size = new System.Drawing.Size(323, 22);
            this.txtWorkOrderTemplateDescription.TabIndex = 5;
            // 
            // cmsContextCall
            // 
            this.cmsContextCall.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsContextCall.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddOrder});
            this.cmsContextCall.Name = "cmsContextCall";
            this.cmsContextCall.Size = new System.Drawing.Size(145, 28);
            this.cmsContextCall.Text = "Add Order";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Work Order Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Template Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_FormTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Ubuntu Light", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(894, 44);
            this.panel2.TabIndex = 23;
            // 
            // lbl_FormTitle
            // 
            this.lbl_FormTitle.AutoSize = true;
            this.lbl_FormTitle.Font = new System.Drawing.Font("Ubuntu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FormTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_FormTitle.Location = new System.Drawing.Point(10, 17);
            this.lbl_FormTitle.Name = "lbl_FormTitle";
            this.lbl_FormTitle.Size = new System.Drawing.Size(126, 25);
            this.lbl_FormTitle.TabIndex = 0;
            this.lbl_FormTitle.Text = "Work Orders";
            // 
            // txtWorkOrderTemplateName
            // 
            this.txtWorkOrderTemplateName.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOrderTemplateName.Location = new System.Drawing.Point(148, 51);
            this.txtWorkOrderTemplateName.Name = "txtWorkOrderTemplateName";
            this.txtWorkOrderTemplateName.Size = new System.Drawing.Size(203, 22);
            this.txtWorkOrderTemplateName.TabIndex = 3;
            // 
            // gbHeader
            // 
            this.gbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHeader.Controls.Add(this.txtQuantity);
            this.gbHeader.Controls.Add(this.label3);
            this.gbHeader.Controls.Add(this.txtWorkOrderTemplateNumber);
            this.gbHeader.Controls.Add(this.label4);
            this.gbHeader.Controls.Add(this.txtWorkOrderTemplateDescription);
            this.gbHeader.Controls.Add(this.txtWorkOrderTemplateName);
            this.gbHeader.Controls.Add(this.txtWorkOrderNumber);
            this.gbHeader.Controls.Add(this.label2);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHeader.Location = new System.Drawing.Point(12, 50);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(870, 133);
            this.gbHeader.TabIndex = 18;
            this.gbHeader.TabStop = false;
            this.gbHeader.Text = "Header";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(147, 105);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(203, 22);
            this.txtQuantity.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Quantity";
            // 
            // txtWorkOrderTemplateNumber
            // 
            this.txtWorkOrderTemplateNumber.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOrderTemplateNumber.Location = new System.Drawing.Point(148, 76);
            this.txtWorkOrderTemplateNumber.Name = "txtWorkOrderTemplateNumber";
            this.txtWorkOrderTemplateNumber.Size = new System.Drawing.Size(203, 22);
            this.txtWorkOrderTemplateNumber.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Template Number";
            // 
            // txtWorkOrderNumber
            // 
            this.txtWorkOrderNumber.Enabled = false;
            this.txtWorkOrderNumber.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWorkOrderNumber.Location = new System.Drawing.Point(147, 25);
            this.txtWorkOrderNumber.Name = "txtWorkOrderNumber";
            this.txtWorkOrderNumber.Size = new System.Drawing.Size(203, 22);
            this.txtWorkOrderNumber.TabIndex = 2;
            this.txtWorkOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // F_WorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 525);
            this.Controls.Add(this.gbItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_WorkOrder";
            this.Text = "Work Order";
            this.Load += new System.EventHandler(this.F_WorkOrder_Load);
            this.gbItems.ResumeLayout(false);
            this.tcItems.ResumeLayout(false);
            this.tpMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderMaterials)).EndInit();
            this.tpWork.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderWorks)).EndInit();
            this.tpEmployeesWorkData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeWorkData)).EndInit();
            this.tpCostings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.cmsContextCall.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.TabControl tcItems;
        private System.Windows.Forms.TabPage tpMaterials;
        private System.Windows.Forms.Button btnRemoveItemsRow;
        private System.Windows.Forms.DataGridView dgvWorkOrderMaterials;
        private System.Windows.Forms.TabPage tpWork;
        private System.Windows.Forms.Button btnRemoveTaskRow;
        private System.Windows.Forms.DataGridView dgvWorkOrderWorks;
        private System.Windows.Forms.TabPage tpEmployeesWorkData;
        private System.Windows.Forms.DataGridView dgvEmployeeWorkData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddOrder;
        private System.Windows.Forms.TextBox txtWorkOrderTemplateDescription;
        private System.Windows.Forms.ContextMenuStrip cmsContextCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_FormTitle;
        private System.Windows.Forms.TextBox txtWorkOrderTemplateName;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.TextBox txtWorkOrderTemplateNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWorkOrderNumber;
        private System.Windows.Forms.Button btnRemoveEmployeeWorkDataRow;
        private System.Windows.Forms.Button btnAddEmployeeWorkDataRow;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherName;
        private System.Windows.Forms.DataGridViewComboBoxColumn AttachedWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCost;
        private System.Windows.Forms.TabPage tpCostings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costs;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitOfMeasure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkRatio;
    }
}