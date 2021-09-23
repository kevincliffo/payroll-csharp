namespace PayRollSystem
{
    partial class F_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main));
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Administration Interface");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Departments");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Defaults");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Add Staff");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("View Staff");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Attendance");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Attendance View");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Staff", new System.Windows.Forms.TreeNode[] {
            treeNode35,
            treeNode36,
            treeNode37,
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Administration", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32,
            treeNode33,
            treeNode34,
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Suppliers");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Items Master");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Goods Receipt");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Goods Issue");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Inventory", new System.Windows.Forms.TreeNode[] {
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("Add Work");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("Internal Work List");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("External Work List");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("Add Material");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("Materials List");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("Work Order Template");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("Work Order Templates List");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("Work Order Templates", new System.Windows.Forms.TreeNode[] {
            treeNode51,
            treeNode52});
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("Work Order");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("Production", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50,
            treeNode53,
            treeNode54});
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("Staff Payroll");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("Casual Staff Payroll");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Payoll List");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("Payroll", new System.Windows.Forms.TreeNode[] {
            treeNode56,
            treeNode57,
            treeNode58});
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Menus", new System.Windows.Forms.TreeNode[] {
            treeNode40,
            treeNode45,
            treeNode55,
            treeNode59});
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNHIFRates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNSSFRates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewTreeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActivateLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartmentsView = new System.Windows.Forms.ToolStripMenuItem();
            this.EmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttendance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttendanceView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStaffPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCasualStaffPayroll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPayrollList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSuppliers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsersTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStaffsTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDepartmentsTable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSubDepartmentsTable = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssMessages = new System.Windows.Forms.StatusStrip();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tsNavigation = new System.Windows.Forms.ToolStrip();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbFirst = new System.Windows.Forms.ToolStripButton();
            this.tsbPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbLast = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tvMenus = new System.Windows.Forms.TreeView();
            this.ilTreeViewImages = new System.Windows.Forms.ImageList(this.components);
            this.tsmiSuppliersTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.ssMessages.SuspendLayout();
            this.tsNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.usersToolStripMenuItem,
            this.tsmiDepartments,
            this.EmployeeToolStripMenuItem,
            this.tsmiPayroll,
            this.tsmiSuppliers,
            this.reportsToolStripMenuItem,
            this.tablesToolStripMenuItem,
            this.windowsMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(993, 29);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNHIFRates,
            this.tsmiNSSFRates,
            this.tsmiViewTreeMenu,
            this.tsmiActivateLicense,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileMenu.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(43, 23);
            this.fileMenu.Text = "&File";
            // 
            // tsmiNHIFRates
            // 
            this.tsmiNHIFRates.Name = "tsmiNHIFRates";
            this.tsmiNHIFRates.Size = new System.Drawing.Size(177, 24);
            this.tsmiNHIFRates.Text = "&NHIF Rates";
            this.tsmiNHIFRates.Click += new System.EventHandler(this.tsmiNHIFRates_Click);
            // 
            // tsmiNSSFRates
            // 
            this.tsmiNSSFRates.Name = "tsmiNSSFRates";
            this.tsmiNSSFRates.Size = new System.Drawing.Size(177, 24);
            this.tsmiNSSFRates.Text = "N&SSF Rates";
            this.tsmiNSSFRates.Click += new System.EventHandler(this.tsmiNSSFRates_Click);
            // 
            // tsmiViewTreeMenu
            // 
            this.tsmiViewTreeMenu.Checked = true;
            this.tsmiViewTreeMenu.CheckOnClick = true;
            this.tsmiViewTreeMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiViewTreeMenu.Name = "tsmiViewTreeMenu";
            this.tsmiViewTreeMenu.Size = new System.Drawing.Size(177, 24);
            this.tsmiViewTreeMenu.Text = "&View Tree Menu";
            this.tsmiViewTreeMenu.Click += new System.EventHandler(this.tsmiViewTreeMenu_Click);
            // 
            // tsmiActivateLicense
            // 
            this.tsmiActivateLicense.Name = "tsmiActivateLicense";
            this.tsmiActivateLicense.Size = new System.Drawing.Size(177, 24);
            this.tsmiActivateLicense.Text = "A&ctivate License";
            this.tsmiActivateLicense.Click += new System.EventHandler(this.tsmiActivateLicense_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.viewUsersToolStripMenuItem});
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(54, 23);
            this.usersToolStripMenuItem.Text = "&Users";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.addUserToolStripMenuItem.Text = "&Add User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // viewUsersToolStripMenuItem
            // 
            this.viewUsersToolStripMenuItem.Name = "viewUsersToolStripMenuItem";
            this.viewUsersToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.viewUsersToolStripMenuItem.Text = "&View Users";
            this.viewUsersToolStripMenuItem.Click += new System.EventHandler(this.viewUsersToolStripMenuItem_Click);
            // 
            // tsmiDepartments
            // 
            this.tsmiDepartments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDepartment,
            this.tsmiDepartmentsView});
            this.tsmiDepartments.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiDepartments.Name = "tsmiDepartments";
            this.tsmiDepartments.Size = new System.Drawing.Size(98, 23);
            this.tsmiDepartments.Text = "&Departments";
            // 
            // tsmiDepartment
            // 
            this.tsmiDepartment.Name = "tsmiDepartment";
            this.tsmiDepartment.Size = new System.Drawing.Size(191, 24);
            this.tsmiDepartment.Text = "&Department";
            this.tsmiDepartment.Click += new System.EventHandler(this.tsmiDepartment_Click);
            // 
            // tsmiDepartmentsView
            // 
            this.tsmiDepartmentsView.Name = "tsmiDepartmentsView";
            this.tsmiDepartmentsView.Size = new System.Drawing.Size(191, 24);
            this.tsmiDepartmentsView.Text = "D&epartments View";
            this.tsmiDepartmentsView.Click += new System.EventHandler(this.tsmiDepartmentsView_Click);
            // 
            // EmployeeToolStripMenuItem
            // 
            this.EmployeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStaff,
            this.tsmiViewStaff,
            this.tsmiAttendance,
            this.tsmiAttendanceView});
            this.EmployeeToolStripMenuItem.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem";
            this.EmployeeToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.EmployeeToolStripMenuItem.Text = "S&taff";
            // 
            // tsmiAddStaff
            // 
            this.tsmiAddStaff.Name = "tsmiAddStaff";
            this.tsmiAddStaff.Size = new System.Drawing.Size(182, 24);
            this.tsmiAddStaff.Text = "&Add Staff";
            this.tsmiAddStaff.Click += new System.EventHandler(this.tsmiAddStaff_Click);
            // 
            // tsmiViewStaff
            // 
            this.tsmiViewStaff.Name = "tsmiViewStaff";
            this.tsmiViewStaff.Size = new System.Drawing.Size(182, 24);
            this.tsmiViewStaff.Text = "&View Staff";
            this.tsmiViewStaff.Click += new System.EventHandler(this.tsmiViewStaff_Click);
            // 
            // tsmiAttendance
            // 
            this.tsmiAttendance.Name = "tsmiAttendance";
            this.tsmiAttendance.Size = new System.Drawing.Size(182, 24);
            this.tsmiAttendance.Text = "Atte&ndance";
            this.tsmiAttendance.Click += new System.EventHandler(this.tsmiAttendance_Click);
            // 
            // tsmiAttendanceView
            // 
            this.tsmiAttendanceView.Name = "tsmiAttendanceView";
            this.tsmiAttendanceView.Size = new System.Drawing.Size(182, 24);
            this.tsmiAttendanceView.Text = "A&ttendance View";
            this.tsmiAttendanceView.Click += new System.EventHandler(this.tsmiAttendanceView_Click);
            // 
            // tsmiPayroll
            // 
            this.tsmiPayroll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStaffPayroll,
            this.tsmiCasualStaffPayroll,
            this.tsmiPayrollList});
            this.tsmiPayroll.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiPayroll.Name = "tsmiPayroll";
            this.tsmiPayroll.Size = new System.Drawing.Size(66, 23);
            this.tsmiPayroll.Text = "&Payroll";
            // 
            // tsmiStaffPayroll
            // 
            this.tsmiStaffPayroll.Name = "tsmiStaffPayroll";
            this.tsmiStaffPayroll.Size = new System.Drawing.Size(201, 24);
            this.tsmiStaffPayroll.Text = "&Staff Payroll";
            this.tsmiStaffPayroll.Click += new System.EventHandler(this.tsmiStaffPayroll_Click);
            // 
            // tsmiCasualStaffPayroll
            // 
            this.tsmiCasualStaffPayroll.Name = "tsmiCasualStaffPayroll";
            this.tsmiCasualStaffPayroll.Size = new System.Drawing.Size(201, 24);
            this.tsmiCasualStaffPayroll.Text = "&Casual Staff Payroll";
            this.tsmiCasualStaffPayroll.Click += new System.EventHandler(this.tsmiCasualStaffPayroll_Click);
            // 
            // tsmiPayrollList
            // 
            this.tsmiPayrollList.Name = "tsmiPayrollList";
            this.tsmiPayrollList.Size = new System.Drawing.Size(201, 24);
            this.tsmiPayrollList.Text = "P&ayroll List";
            this.tsmiPayrollList.Click += new System.EventHandler(this.tsmiPayrollList_Click);
            // 
            // tsmiSuppliers
            // 
            this.tsmiSuppliers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSupplier});
            this.tsmiSuppliers.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiSuppliers.Name = "tsmiSuppliers";
            this.tsmiSuppliers.Size = new System.Drawing.Size(77, 23);
            this.tsmiSuppliers.Text = "&Suppliers";
            // 
            // tsmiSupplier
            // 
            this.tsmiSupplier.Name = "tsmiSupplier";
            this.tsmiSupplier.Size = new System.Drawing.Size(180, 24);
            this.tsmiSupplier.Text = "&Supplier";
            this.tsmiSupplier.Click += new System.EventHandler(this.tsmiSupplier_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersReportToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(68, 23);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // usersReportToolStripMenuItem
            // 
            this.usersReportToolStripMenuItem.Name = "usersReportToolStripMenuItem";
            this.usersReportToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.usersReportToolStripMenuItem.Text = "&Users Report";
            this.usersReportToolStripMenuItem.Click += new System.EventHandler(this.usersReportToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUsersTable,
            this.tsmiStaffsTable,
            this.tsmiDepartmentsTable,
            this.tsmiSubDepartmentsTable,
            this.tsmiSuppliersTable});
            this.tablesToolStripMenuItem.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(63, 23);
            this.tablesToolStripMenuItem.Text = "T&ables";
            // 
            // tsmiUsersTable
            // 
            this.tsmiUsersTable.Name = "tsmiUsersTable";
            this.tsmiUsersTable.Size = new System.Drawing.Size(183, 24);
            this.tsmiUsersTable.Text = "&Users";
            this.tsmiUsersTable.Click += new System.EventHandler(this.tsmiUsersTable_Click);
            // 
            // tsmiStaffsTable
            // 
            this.tsmiStaffsTable.Name = "tsmiStaffsTable";
            this.tsmiStaffsTable.Size = new System.Drawing.Size(183, 24);
            this.tsmiStaffsTable.Text = "&Staffs";
            this.tsmiStaffsTable.Click += new System.EventHandler(this.tsmiStaffsTable_Click);
            // 
            // tsmiDepartmentsTable
            // 
            this.tsmiDepartmentsTable.Name = "tsmiDepartmentsTable";
            this.tsmiDepartmentsTable.Size = new System.Drawing.Size(183, 24);
            this.tsmiDepartmentsTable.Text = "&Departments";
            this.tsmiDepartmentsTable.Click += new System.EventHandler(this.tsmiDepartmentsTable_Click);
            // 
            // tsmiSubDepartmentsTable
            // 
            this.tsmiSubDepartmentsTable.Name = "tsmiSubDepartmentsTable";
            this.tsmiSubDepartmentsTable.Size = new System.Drawing.Size(183, 24);
            this.tsmiSubDepartmentsTable.Text = "Su&b Departments";
            this.tsmiSubDepartmentsTable.Click += new System.EventHandler(this.tsmiSubDepartmentsTable_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(77, 23);
            this.windowsMenu.Text = "&Windows";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // ssMessages
            // 
            this.ssMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage});
            this.ssMessages.Location = new System.Drawing.Point(0, 640);
            this.ssMessages.Name = "ssMessages";
            this.ssMessages.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssMessages.Size = new System.Drawing.Size(993, 22);
            this.ssMessages.TabIndex = 2;
            this.ssMessages.Text = "StatusStrip";
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(39, 17);
            this.tsslMessage.Text = "Status";
            // 
            // tsNavigation
            // 
            this.tsNavigation.AutoSize = false;
            this.tsNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFind,
            this.tsbNew,
            this.tsbFirst,
            this.tsbPrevious,
            this.tsbNext,
            this.tsbLast,
            this.tsbDelete});
            this.tsNavigation.Location = new System.Drawing.Point(0, 29);
            this.tsNavigation.Name = "tsNavigation";
            this.tsNavigation.Size = new System.Drawing.Size(993, 37);
            this.tsNavigation.TabIndex = 4;
            this.tsNavigation.Text = "toolStrip1";
            this.tsNavigation.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsNavigation_ItemClicked);
            // 
            // tsbFind
            // 
            this.tsbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFind.Image = ((System.Drawing.Image)(resources.GetObject("tsbFind.Image")));
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(23, 34);
            this.tsbFind.Text = "Find";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 34);
            this.tsbNew.Text = "New";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbFirst
            // 
            this.tsbFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFirst.Image = ((System.Drawing.Image)(resources.GetObject("tsbFirst.Image")));
            this.tsbFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFirst.Name = "tsbFirst";
            this.tsbFirst.Size = new System.Drawing.Size(23, 34);
            this.tsbFirst.Text = "First Record";
            this.tsbFirst.Click += new System.EventHandler(this.tsbFirst_Click);
            // 
            // tsbPrevious
            // 
            this.tsbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrevious.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrevious.Image")));
            this.tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrevious.Name = "tsbPrevious";
            this.tsbPrevious.Size = new System.Drawing.Size(23, 34);
            this.tsbPrevious.Text = "Previous Record";
            this.tsbPrevious.Click += new System.EventHandler(this.tsbPrevious_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 34);
            this.tsbNext.Text = "Next Record";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // tsbLast
            // 
            this.tsbLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLast.Image = ((System.Drawing.Image)(resources.GetObject("tsbLast.Image")));
            this.tsbLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLast.Name = "tsbLast";
            this.tsbLast.Size = new System.Drawing.Size(23, 34);
            this.tsbLast.Text = "Last Record";
            this.tsbLast.Click += new System.EventHandler(this.tsbLast_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 34);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tvMenus
            // 
            this.tvMenus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvMenus.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMenus.ImageIndex = 0;
            this.tvMenus.ImageList = this.ilTreeViewImages;
            this.tvMenus.Location = new System.Drawing.Point(0, 66);
            this.tvMenus.Name = "tvMenus";
            treeNode31.ImageKey = "AdminInterface.png";
            treeNode31.Name = "mnuAdminInterface";
            treeNode31.SelectedImageIndex = 24;
            treeNode31.Text = "Administration Interface";
            treeNode32.ImageKey = "users.ico";
            treeNode32.Name = "mnuUsers";
            treeNode32.SelectedImageIndex = 0;
            treeNode32.Text = "Users";
            treeNode33.ImageKey = "Department.png";
            treeNode33.Name = "mnuDepartments";
            treeNode33.SelectedImageIndex = 25;
            treeNode33.Text = "Departments";
            treeNode34.Name = "mnuDefaults";
            treeNode34.Text = "Defaults";
            treeNode35.ImageKey = "employee.ico";
            treeNode35.Name = "mnuAddStaff";
            treeNode35.SelectedImageIndex = 14;
            treeNode35.Text = "Add Staff";
            treeNode36.ImageKey = "StaffList.png";
            treeNode36.Name = "mnuViewStaff";
            treeNode36.SelectedImageIndex = 28;
            treeNode36.Text = "View Staff";
            treeNode37.Name = "mnuAttendance";
            treeNode37.Text = "Attendance";
            treeNode38.ImageKey = "Attendance.png";
            treeNode38.Name = "mnuAttendanceView";
            treeNode38.SelectedImageIndex = 27;
            treeNode38.Text = "Attendance View";
            treeNode39.Name = "mnuStaff";
            treeNode39.Text = "Staff";
            treeNode40.ImageKey = "Administrator.png";
            treeNode40.Name = "mnuAdministration";
            treeNode40.SelectedImageKey = "(default)";
            treeNode40.Text = "Administration";
            treeNode41.ImageKey = "hotel-supplier.png";
            treeNode41.Name = "mnuSuppliers";
            treeNode41.Text = "Suppliers";
            treeNode42.ImageKey = "Items.png";
            treeNode42.Name = "mnuItemsMaster";
            treeNode42.SelectedImageIndex = 21;
            treeNode42.Text = "Items Master";
            treeNode43.ImageKey = "GoodsReceipt.png";
            treeNode43.Name = "mnuGoodsReceipt";
            treeNode43.SelectedImageIndex = 20;
            treeNode43.Text = "Goods Receipt";
            treeNode44.ImageKey = "GoodsIssue.png";
            treeNode44.Name = "mnuGoodsIssue";
            treeNode44.SelectedImageIndex = 19;
            treeNode44.Text = "Goods Issue";
            treeNode45.ImageKey = "warehouse.png";
            treeNode45.Name = "mnuInventory";
            treeNode45.SelectedImageIndex = 18;
            treeNode45.Text = "Inventory";
            treeNode46.ImageKey = "handyman-tools.png";
            treeNode46.Name = "mnuAddWork";
            treeNode46.SelectedImageIndex = 15;
            treeNode46.Text = "Add Work";
            treeNode47.ImageKey = "handyman-tools.png";
            treeNode47.Name = "mnuInternalWorkList";
            treeNode47.SelectedImageIndex = 15;
            treeNode47.Text = "Internal Work List";
            treeNode48.ImageKey = "handyman-tools.png";
            treeNode48.Name = "mnuExternalWorkList";
            treeNode48.SelectedImageIndex = 15;
            treeNode48.Text = "External Work List";
            treeNode49.ImageKey = "Materials.png";
            treeNode49.Name = "mnuAddMaterial";
            treeNode49.SelectedImageIndex = 31;
            treeNode49.Text = "Add Material";
            treeNode50.ImageKey = "MaterialsList.png";
            treeNode50.Name = "mnuMaterialsList";
            treeNode50.SelectedImageIndex = 34;
            treeNode50.Text = "Materials List";
            treeNode51.ImageKey = "WorkOrder.png";
            treeNode51.Name = "mnuWorkOrderTemplate";
            treeNode51.SelectedImageIndex = 33;
            treeNode51.Text = "Work Order Template";
            treeNode52.ImageKey = "WorkOrder.png";
            treeNode52.Name = "mnuWorkOrderTemplatesList";
            treeNode52.SelectedImageIndex = 33;
            treeNode52.Text = "Work Order Templates List";
            treeNode53.ImageKey = "WorkOrder.png";
            treeNode53.Name = "mnuMainWorkOrderTemplate";
            treeNode53.SelectedImageIndex = 33;
            treeNode53.Text = "Work Order Templates";
            treeNode54.ImageKey = "WorkOrder.png";
            treeNode54.Name = "mnuWorkOrder";
            treeNode54.SelectedImageIndex = 33;
            treeNode54.Text = "Work Order";
            treeNode55.ImageKey = "Work.png";
            treeNode55.Name = "mnuProduction";
            treeNode55.SelectedImageIndex = 32;
            treeNode55.Text = "Production";
            treeNode56.ImageKey = "payroll1600.png";
            treeNode56.Name = "mnuStaffPayroll";
            treeNode56.SelectedImageIndex = 35;
            treeNode56.Text = "Staff Payroll";
            treeNode57.ImageKey = "payroll1600.png";
            treeNode57.Name = "mnuCasualStaffPayroll";
            treeNode57.SelectedImageIndex = 35;
            treeNode57.Text = "Casual Staff Payroll";
            treeNode58.ImageKey = "PaymentList.png";
            treeNode58.Name = "mnuPayrollList";
            treeNode58.SelectedImageIndex = 29;
            treeNode58.Text = "Payoll List";
            treeNode59.ImageKey = "give-money.png";
            treeNode59.Name = "mnuPayroll";
            treeNode59.Text = "Payroll";
            treeNode60.ImageKey = "order.ico";
            treeNode60.Name = "mnuMenus";
            treeNode60.SelectedImageIndex = 24;
            treeNode60.Text = "Menus";
            this.tvMenus.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode60});
            this.tvMenus.SelectedImageIndex = 0;
            this.tvMenus.Size = new System.Drawing.Size(248, 327);
            this.tvMenus.TabIndex = 6;
            this.tvMenus.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenus_AfterSelect);
            // 
            // ilTreeViewImages
            // 
            this.ilTreeViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeViewImages.ImageStream")));
            this.ilTreeViewImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeViewImages.Images.SetKeyName(0, "users.ico");
            this.ilTreeViewImages.Images.SetKeyName(1, "user.ico");
            this.ilTreeViewImages.Images.SetKeyName(2, "teacher.ico");
            this.ilTreeViewImages.Images.SetKeyName(3, "TaskLink.ico");
            this.ilTreeViewImages.Images.SetKeyName(4, "system.ico");
            this.ilTreeViewImages.Images.SetKeyName(5, "students.ico");
            this.ilTreeViewImages.Images.SetKeyName(6, "Search.ico");
            this.ilTreeViewImages.Images.SetKeyName(7, "Science-Students.ico");
            this.ilTreeViewImages.Images.SetKeyName(8, "people.ico");
            this.ilTreeViewImages.Images.SetKeyName(9, "order.ico");
            this.ilTreeViewImages.Images.SetKeyName(10, "New.ico");
            this.ilTreeViewImages.Images.SetKeyName(11, "MovePrevious.ico");
            this.ilTreeViewImages.Images.SetKeyName(12, "List.ico");
            this.ilTreeViewImages.Images.SetKeyName(13, "favicon.ico");
            this.ilTreeViewImages.Images.SetKeyName(14, "employee.ico");
            this.ilTreeViewImages.Images.SetKeyName(15, "handyman-tools.png");
            this.ilTreeViewImages.Images.SetKeyName(16, "handyman-tools.ico");
            this.ilTreeViewImages.Images.SetKeyName(17, "give-money.png");
            this.ilTreeViewImages.Images.SetKeyName(18, "warehouse.png");
            this.ilTreeViewImages.Images.SetKeyName(19, "GoodsIssue.png");
            this.ilTreeViewImages.Images.SetKeyName(20, "GoodsReceipt.png");
            this.ilTreeViewImages.Images.SetKeyName(21, "Items.png");
            this.ilTreeViewImages.Images.SetKeyName(22, "hotel-supplier.png");
            this.ilTreeViewImages.Images.SetKeyName(23, "Administrator.png");
            this.ilTreeViewImages.Images.SetKeyName(24, "AdminInterface.png");
            this.ilTreeViewImages.Images.SetKeyName(25, "Department.png");
            this.ilTreeViewImages.Images.SetKeyName(26, "StaffView.png");
            this.ilTreeViewImages.Images.SetKeyName(27, "Attendance.png");
            this.ilTreeViewImages.Images.SetKeyName(28, "StaffList.png");
            this.ilTreeViewImages.Images.SetKeyName(29, "PaymentList.png");
            this.ilTreeViewImages.Images.SetKeyName(30, "StaffPayment.png");
            this.ilTreeViewImages.Images.SetKeyName(31, "Materials.png");
            this.ilTreeViewImages.Images.SetKeyName(32, "Work.png");
            this.ilTreeViewImages.Images.SetKeyName(33, "WorkOrder.png");
            this.ilTreeViewImages.Images.SetKeyName(34, "MaterialsList.png");
            this.ilTreeViewImages.Images.SetKeyName(35, "payroll1600.png");
            // 
            // tsmiSuppliersTable
            // 
            this.tsmiSuppliersTable.Name = "tsmiSuppliersTable";
            this.tsmiSuppliersTable.Size = new System.Drawing.Size(183, 24);
            this.tsmiSuppliersTable.Text = "Su&ppliers";
            this.tsmiSuppliersTable.Click += new System.EventHandler(this.tsmiSuppliersTable_Click);
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 662);
            this.Controls.Add(this.tvMenus);
            this.Controls.Add(this.tsNavigation);
            this.Controls.Add(this.ssMessages);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Ubuntu Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "F_Main";
            this.Text = "Management System";
            this.Load += new System.EventHandler(this.F_Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ssMessages.ResumeLayout(false);
            this.ssMessages.PerformLayout();
            this.tsNavigation.ResumeLayout(false);
            this.tsNavigation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip ssMessages;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStaff;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewStaff;
        private System.Windows.Forms.ToolStrip tsNavigation;
        private System.Windows.Forms.ToolStripButton tsbFirst;
        private System.Windows.Forms.ToolStripButton tsbPrevious;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbLast;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttendanceView;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartments;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartment;
        private System.Windows.Forms.ToolStripMenuItem tsmiNHIFRates;
        private System.Windows.Forms.ToolStripMenuItem tsmiNSSFRates;
        private System.Windows.Forms.ToolStripMenuItem tsmiSuppliers;
        private System.Windows.Forms.ToolStripMenuItem tsmiSupplier;
        private System.Windows.Forms.TreeView tvMenus;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiActivateLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList ilTreeViewImages;
        private System.Windows.Forms.ToolStripMenuItem tsmiPayroll;
        private System.Windows.Forms.ToolStripMenuItem tsmiStaffPayroll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCasualStaffPayroll;
        private System.Windows.Forms.ToolStripMenuItem tsmiPayrollList;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsersTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiStaffsTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartmentsTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiSubDepartmentsTable;
        private System.Windows.Forms.ToolStripMenuItem tsmiDepartmentsView;
        private System.Windows.Forms.ToolStripMenuItem tsmiAttendance;
        private System.Windows.Forms.ToolStripMenuItem tsmiSuppliersTable;
    }
}



