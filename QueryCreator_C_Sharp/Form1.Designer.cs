namespace BuildingUtilities
{
    partial class Form1
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCreateDS = new System.Windows.Forms.Button();
            this.txtDSClass = new System.Windows.Forms.TextBox();
            this.txtInitials = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.txtPrimaryKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnCreateTableFile = new System.Windows.Forms.Button();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalizedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueRequired = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtTableContents = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(5, 21);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(5, 102);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(5, 183);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(97, 21);
            this.txtQuery.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(1076, 186);
            this.txtQuery.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1211, 423);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtQuery);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.btnInsert);
            this.tabPage1.Controls.Add(this.btnCreate);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1203, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Queries";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCreateDS);
            this.tabPage2.Controls.Add(this.txtDSClass);
            this.tabPage2.Controls.Add(this.txtInitials);
            this.tabPage2.Controls.Add(this.txtClassName);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1203, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Server";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCreateDS
            // 
            this.btnCreateDS.Location = new System.Drawing.Point(13, 334);
            this.btnCreateDS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateDS.Name = "btnCreateDS";
            this.btnCreateDS.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDS.TabIndex = 5;
            this.btnCreateDS.Text = "Create DS";
            this.btnCreateDS.UseVisualStyleBackColor = true;
            this.btnCreateDS.Click += new System.EventHandler(this.btnCreateDS_Click);
            // 
            // txtDSClass
            // 
            this.txtDSClass.Location = new System.Drawing.Point(133, 81);
            this.txtDSClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDSClass.Multiline = true;
            this.txtDSClass.Name = "txtDSClass";
            this.txtDSClass.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDSClass.Size = new System.Drawing.Size(1033, 276);
            this.txtDSClass.TabIndex = 4;
            // 
            // txtInitials
            // 
            this.txtInitials.Location = new System.Drawing.Point(133, 43);
            this.txtInitials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInitials.Name = "txtInitials";
            this.txtInitials.Size = new System.Drawing.Size(277, 22);
            this.txtInitials.TabIndex = 3;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(133, 15);
            this.txtClassName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(277, 22);
            this.txtClassName.TabIndex = 2;
            this.txtClassName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Data Initial";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class Name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTableContents);
            this.tabPage3.Controls.Add(this.btnCreateTableFile);
            this.tabPage3.Controls.Add(this.btnAddRow);
            this.tabPage3.Controls.Add(this.dgvTable);
            this.tabPage3.Controls.Add(this.txtPrimaryKey);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.txtTableName);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1203, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Table Creation";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Type,
            this.Length,
            this.InitialValue,
            this.LocalizedName,
            this.ValueRequired});
            this.dgvTable.Location = new System.Drawing.Point(18, 100);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(685, 259);
            this.dgvTable.TabIndex = 4;
            // 
            // txtPrimaryKey
            // 
            this.txtPrimaryKey.Location = new System.Drawing.Point(158, 57);
            this.txtPrimaryKey.Name = "txtPrimaryKey";
            this.txtPrimaryKey.Size = new System.Drawing.Size(249, 22);
            this.txtPrimaryKey.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Primary Key";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(158, 16);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(249, 22);
            this.txtTableName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Table Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Table File Path";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtTableFilePath
            // 
            this.txtTableFilePath.Location = new System.Drawing.Point(116, 9);
            this.txtTableFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTableFilePath.Name = "txtTableFilePath";
            this.txtTableFilePath.Size = new System.Drawing.Size(1049, 22);
            this.txtTableFilePath.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1173, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 21);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(18, 365);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 5;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnCreateTableFile
            // 
            this.btnCreateTableFile.Location = new System.Drawing.Point(1101, 365);
            this.btnCreateTableFile.Name = "btnCreateTableFile";
            this.btnCreateTableFile.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTableFile.TabIndex = 6;
            this.btnCreateTableFile.Text = "Create Table File";
            this.btnCreateTableFile.UseVisualStyleBackColor = true;
            this.btnCreateTableFile.Click += new System.EventHandler(this.btnCreateTableFile_Click);
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Items.AddRange(new object[] {
            "String",
            "Integer",
            "Long",
            "Float",
            "Date",
            "Time",
            "DateTime",
            "Boolean"});
            this.Type.Name = "Type";
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Length.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InitialValue
            // 
            this.InitialValue.HeaderText = "InitialValue";
            this.InitialValue.Name = "InitialValue";
            this.InitialValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InitialValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LocalizedName
            // 
            this.LocalizedName.HeaderText = "LocalizedName";
            this.LocalizedName.Name = "LocalizedName";
            this.LocalizedName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LocalizedName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValueRequired
            // 
            this.ValueRequired.HeaderText = "ValueRequired";
            this.ValueRequired.Items.AddRange(new object[] {
            "True",
            "False"});
            this.ValueRequired.Name = "ValueRequired";
            // 
            // txtTableContents
            // 
            this.txtTableContents.Location = new System.Drawing.Point(735, 16);
            this.txtTableContents.Multiline = true;
            this.txtTableContents.Name = "txtTableContents";
            this.txtTableContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTableContents.Size = new System.Drawing.Size(441, 343);
            this.txtTableContents.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 490);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTableFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableFilePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateDS;
        private System.Windows.Forms.TextBox txtDSClass;
        private System.Windows.Forms.TextBox txtInitials;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.TextBox txtPrimaryKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreateTableFile;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewComboBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalizedName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValueRequired;
        private System.Windows.Forms.TextBox txtTableContents;
    }
}

