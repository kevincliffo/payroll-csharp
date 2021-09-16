namespace PayRollSystem
{
    partial class F_ItemsMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_ItemsMaster));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tcInventory = new System.Windows.Forms.TabControl();
            this.tpInventoryInormation = new System.Windows.Forms.TabPage();
            this.dgvInventoryInformation = new System.Windows.Forms.DataGridView();
            this.InStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpGoodsIssue = new System.Windows.Forms.TabPage();
            this.dgvGoodsIssue = new System.Windows.Forms.DataGridView();
            this.IssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpGoodsReceipt = new System.Windows.Forms.TabPage();
            this.dgvGoodsReceipt = new System.Windows.Forms.DataGridView();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilInventoryImages = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tcInventory.SuspendLayout();
            this.tpInventoryInormation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryInformation)).BeginInit();
            this.tpGoodsIssue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsIssue)).BeginInit();
            this.tpGoodsReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtUnitPrice);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(865, 146);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Header";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(543, 100);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(196, 22);
            this.txtUnitPrice.TabIndex = 7;
            this.txtUnitPrice.Text = "0.00";
            this.txtUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(472, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Unit Price";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(159, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 27);
            this.comboBox1.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(159, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(159, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(229, 22);
            this.textBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Item Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Item Number";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tcInventory);
            this.groupBox4.Location = new System.Drawing.Point(12, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(865, 465);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Inventory";
            // 
            // tcInventory
            // 
            this.tcInventory.Controls.Add(this.tpInventoryInormation);
            this.tcInventory.Controls.Add(this.tpGoodsIssue);
            this.tcInventory.Controls.Add(this.tpGoodsReceipt);
            this.tcInventory.ImageList = this.ilInventoryImages;
            this.tcInventory.Location = new System.Drawing.Point(6, 21);
            this.tcInventory.Name = "tcInventory";
            this.tcInventory.SelectedIndex = 0;
            this.tcInventory.Size = new System.Drawing.Size(853, 428);
            this.tcInventory.TabIndex = 0;
            // 
            // tpInventoryInormation
            // 
            this.tpInventoryInormation.Controls.Add(this.dgvInventoryInformation);
            this.tpInventoryInormation.Location = new System.Drawing.Point(4, 28);
            this.tpInventoryInormation.Name = "tpInventoryInormation";
            this.tpInventoryInormation.Padding = new System.Windows.Forms.Padding(3);
            this.tpInventoryInormation.Size = new System.Drawing.Size(845, 396);
            this.tpInventoryInormation.TabIndex = 0;
            this.tpInventoryInormation.Text = "Inventory Information";
            this.tpInventoryInormation.UseVisualStyleBackColor = true;
            // 
            // dgvInventoryInformation
            // 
            this.dgvInventoryInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InStock,
            this.Ordered,
            this.Available,
            this.ItemCost});
            this.dgvInventoryInformation.Location = new System.Drawing.Point(16, 20);
            this.dgvInventoryInformation.Name = "dgvInventoryInformation";
            this.dgvInventoryInformation.Size = new System.Drawing.Size(813, 349);
            this.dgvInventoryInformation.TabIndex = 0;
            // 
            // InStock
            // 
            this.InStock.HeaderText = "In Stock";
            this.InStock.Name = "InStock";
            this.InStock.ReadOnly = true;
            // 
            // Ordered
            // 
            this.Ordered.HeaderText = "Ordered";
            this.Ordered.Name = "Ordered";
            this.Ordered.ReadOnly = true;
            // 
            // Available
            // 
            this.Available.HeaderText = "Available";
            this.Available.Name = "Available";
            this.Available.ReadOnly = true;
            // 
            // ItemCost
            // 
            this.ItemCost.HeaderText = "ItemCost";
            this.ItemCost.Name = "ItemCost";
            this.ItemCost.ReadOnly = true;
            // 
            // tpGoodsIssue
            // 
            this.tpGoodsIssue.Controls.Add(this.dgvGoodsIssue);
            this.tpGoodsIssue.ImageKey = "GoodsIssue.png";
            this.tpGoodsIssue.Location = new System.Drawing.Point(4, 28);
            this.tpGoodsIssue.Name = "tpGoodsIssue";
            this.tpGoodsIssue.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoodsIssue.Size = new System.Drawing.Size(845, 396);
            this.tpGoodsIssue.TabIndex = 1;
            this.tpGoodsIssue.Text = "Goods Issue";
            this.tpGoodsIssue.UseVisualStyleBackColor = true;
            // 
            // dgvGoodsIssue
            // 
            this.dgvGoodsIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IssueDate,
            this.Quantity,
            this.UnitPrice,
            this.Cost});
            this.dgvGoodsIssue.Location = new System.Drawing.Point(16, 24);
            this.dgvGoodsIssue.Name = "dgvGoodsIssue";
            this.dgvGoodsIssue.Size = new System.Drawing.Size(813, 349);
            this.dgvGoodsIssue.TabIndex = 1;
            // 
            // IssueDate
            // 
            this.IssueDate.HeaderText = "Issue Date";
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "IssueQuantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // tpGoodsReceipt
            // 
            this.tpGoodsReceipt.Controls.Add(this.dgvGoodsReceipt);
            this.tpGoodsReceipt.ImageKey = "GoodsReceipt.png";
            this.tpGoodsReceipt.Location = new System.Drawing.Point(4, 28);
            this.tpGoodsReceipt.Name = "tpGoodsReceipt";
            this.tpGoodsReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.tpGoodsReceipt.Size = new System.Drawing.Size(845, 396);
            this.tpGoodsReceipt.TabIndex = 2;
            this.tpGoodsReceipt.Text = "Goods Receipt";
            this.tpGoodsReceipt.UseVisualStyleBackColor = true;
            // 
            // dgvGoodsReceipt
            // 
            this.dgvGoodsReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptDate,
            this.ReceiptQuantity,
            this.ReceiptUnitPrice,
            this.ReceiptCost});
            this.dgvGoodsReceipt.Location = new System.Drawing.Point(16, 24);
            this.dgvGoodsReceipt.Name = "dgvGoodsReceipt";
            this.dgvGoodsReceipt.Size = new System.Drawing.Size(813, 349);
            this.dgvGoodsReceipt.TabIndex = 2;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.HeaderText = "Receipt Date";
            this.ReceiptDate.Name = "ReceiptDate";
            this.ReceiptDate.ReadOnly = true;
            this.ReceiptDate.Width = 120;
            // 
            // ReceiptQuantity
            // 
            this.ReceiptQuantity.HeaderText = "Receipt Quantity";
            this.ReceiptQuantity.Name = "ReceiptQuantity";
            this.ReceiptQuantity.ReadOnly = true;
            this.ReceiptQuantity.Width = 150;
            // 
            // ReceiptUnitPrice
            // 
            this.ReceiptUnitPrice.HeaderText = "Receipt Unit Price";
            this.ReceiptUnitPrice.Name = "ReceiptUnitPrice";
            this.ReceiptUnitPrice.ReadOnly = true;
            this.ReceiptUnitPrice.Width = 150;
            // 
            // ReceiptCost
            // 
            this.ReceiptCost.HeaderText = "Receipt Cost";
            this.ReceiptCost.Name = "ReceiptCost";
            this.ReceiptCost.ReadOnly = true;
            this.ReceiptCost.Width = 120;
            // 
            // ilInventoryImages
            // 
            this.ilInventoryImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilInventoryImages.ImageStream")));
            this.ilInventoryImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilInventoryImages.Images.SetKeyName(0, "GoodsReceipt.png");
            this.ilInventoryImages.Images.SetKeyName(1, "GoodsIssue.png");
            // 
            // F_ItemsMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 699);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_ItemsMaster";
            this.Text = "Items Master";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tcInventory.ResumeLayout(false);
            this.tpInventoryInormation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryInformation)).EndInit();
            this.tpGoodsIssue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsIssue)).EndInit();
            this.tpGoodsReceipt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tcInventory;
        private System.Windows.Forms.TabPage tpInventoryInormation;
        private System.Windows.Forms.TabPage tpGoodsIssue;
        private System.Windows.Forms.DataGridView dgvInventoryInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn InStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCost;
        private System.Windows.Forms.DataGridView dgvGoodsIssue;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.TabPage tpGoodsReceipt;
        private System.Windows.Forms.DataGridView dgvGoodsReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptCost;
        private System.Windows.Forms.ImageList ilInventoryImages;
    }
}