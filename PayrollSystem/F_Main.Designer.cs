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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Administration Interface");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Users");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Departments");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Defaults");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Add Staff");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("View Staff");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Attendance");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Attendance View");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Staff", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Administration", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Suppliers");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Items Master");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Goods Receipt");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Goods Issue");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Inventory", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Add Work");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Internal Work List");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("External Work List");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Add Material");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Materials List");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Work Order Template");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Work Order Templates List");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Work Order Templates", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Work Order");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Production", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Staff Payroll");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Casual Staff Payroll");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Payoll List");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Payroll", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Menus", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode15,
            treeNode25,
            treeNode29});
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
            this.tsmiAttendanceView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAttendance = new System.Windows.Forms.ToolStripMenuItem();
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
            // tsmiAttendanceView
            // 
            this.tsmiAttendanceView.Name = "tsmiAttendanceView";
            this.tsmiAttendanceView.Size = new System.Drawing.Size(182, 24);
            this.tsmiAttendanceView.Text = "A&ttendance View";
            this.tsmiAttendanceView.Click += new System.EventHandler(this.tsmiAttendanceView_Click);
            // 
            // tsmiAttendance
            // 
            this.tsmiAttendance.Name = "tsmiAttendance";
            this.tsmiAttendance.Size = new System.Drawing.Size(182, 24);
            this.tsmiAttendance.Text = "Atte&ndance";
            this.tsmiAttendance.Click += new System.EventHandler(this.tsmiAttendance_Click);
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
            this.tsmiSupplier.Size = new System.Drawing.Size(131, 24);
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
            this.tsmiSubDepartmentsTable});
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
            treeNode1.ImageKey = "AdminInterface.png";
            treeNode1.Name = "mnuAdminInterface";
            treeNode1.SelectedImageIndex = 24;
            treeNode1.Text = "Administration Interface";
            treeNode2.ImageKey = "users.ico";
            treeNode2.Name = "mnuUsers";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "Users";
            treeNode3.ImageKey = "Department.png";
            treeNode3.Name = "mnuDepartments";
            treeNode3.SelectedImageIndex = 25;
            treeNode3.Text = "Departments";
            treeNode4.Name = "mnuDefaults";
            treeNode4.Text = "Defaults";
            treeNode5.ImageKey = "employee.ico";
            treeNode5.Name = "mnuAddStaff";
            treeNode5.SelectedImageIndex = 14;
            treeNode5.Text = "Add Staff";
            treeNode6.ImageKey = "StaffList.png";
            treeNode6.Name = "mnuViewStaff";
            treeNode6.SelectedImageIndex = 28;
            treeNode6.Text = "View Staff";
            treeNode7.Name = "mnuAttendance";
            treeNode7.Text = "Attendance";
            treeNode8.ImageKey = "Attendance.png";
            treeNode8.Name = "mnuAttendanceView";
            treeNode8.SelectedImageIndex = 27;
            treeNode8.Text = "Attendance View";
            treeNode9.Name = "mnuStaff";
            treeNode9.Text = "Staff";
            treeNode10.ImageKey = "Administrator.png";
            treeNode10.Name = "mnuAdministration";
            treeNode10.SelectedImageKey = "(default)";
            treeNode10.Text = "Administration";
            treeNode11.ImageKey = "hotel-supplier.png";
            treeNode11.Name = "mnuSuppliers";
            treeNode11.Text = "Suppliers";
            treeNode12.ImageKey = "Items.png";
            treeNode12.Name = "mnuItemsMaster";
            treeNode12.SelectedImageIndex = 21;
            treeNode12.Text = "Items Master";
            treeNode13.ImageKey = "GoodsReceipt.png";
            treeNode13.Name = "mnuGoodsReceipt";
            treeNode13.SelectedImageIndex = 20;
            treeNode13.Text = "Goods Receipt";
            treeNode14.ImageKey = "GoodsIssue.png";
            treeNode14.Name = "mnuGoodsIssue";
            treeNode14.SelectedImageIndex = 19;
            treeNode14.Text = "Goods Issue";
            treeNode15.ImageKey = "warehouse.png";
            treeNode15.Name = "mnuInventory";
            treeNode15.SelectedImageIndex = 18;
            treeNode15.Text = "Inventory";
            treeNode16.ImageKey = "handyman-tools.png";
            treeNode16.Name = "mnuAddWork";
            treeNode16.SelectedImageIndex = 15;
            treeNode16.Text = "Add Work";
            treeNode17.ImageKey = "handyman-tools.png";
            treeNode17.Name = "mnuInternalWorkList";
            treeNode17.SelectedImageIndex = 15;
            treeNode17.Text = "Internal Work List";
            treeNode18.ImageKey = "handyman-tools.png";
            treeNode18.Name = "mnuExternalWorkList";
            treeNode18.SelectedImageIndex = 15;
            treeNode18.Text = "External Work List";
            treeNode19.ImageKey = "Materials.png";
            treeNode19.Name = "mnuAddMaterial";
            treeNode19.SelectedImageIndex = 31;
            treeNode19.Text = "Add Material";
            treeNode20.ImageKey = "MaterialsList.png";
            treeNode20.Name = "mnuMaterialsList";
            treeNode20.SelectedImageIndex = 34;
            treeNode20.Text = "Materials List";
            treeNode21.ImageKey = "WorkOrder.png";
            treeNode21.Name = "mnuWorkOrderTemplate";
            treeNode21.SelectedImageIndex = 33;
            treeNode21.Text = "Work Order Template";
            treeNode22.ImageKey = "WorkOrder.png";
            treeNode22.Name = "mnuWorkOrderTemplatesList";
            treeNode22.SelectedImageIndex = 33;
            treeNode22.Text = "Work Order Templates List";
            treeNode23.ImageKey = "WorkOrder.png";
            treeNode23.Name = "mnuMainWorkOrderTemplate";
            treeNode23.SelectedImageIndex = 33;
            treeNode23.Text = "Work Order Templates";
            treeNode24.ImageKey = "WorkOrder.png";
            treeNode24.Name = "mnuWorkOrder";
            treeNode24.SelectedImageIndex = 33;
            treeNode24.Text = "Work Order";
            treeNode25.ImageKey = "Work.png";
            treeNode25.Name = "mnuProduction";
            treeNode25.SelectedImageIndex = 32;
            treeNode25.Text = "Production";
            treeNode26.ImageKey = "payroll1600.png";
            treeNode26.Name = "mnuStaffPayroll";
            treeNode26.SelectedImageIndex = 35;
            treeNode26.Text = "Staff Payroll";
            treeNode27.ImageKey = "payroll1600.png";
            treeNode27.Name = "mnuCasualStaffPayroll";
            treeNode27.SelectedImageIndex = 35;
            treeNode27.Text = "Casual Staff Payroll";
            treeNode28.ImageKey = "PaymentList.png";
            treeNode28.Name = "mnuPayrollList";
            treeNode28.SelectedImageIndex = 29;
            treeNode28.Text = "Payoll List";
            treeNode29.ImageKey = "give-money.png";
            treeNode29.Name = "mnuPayroll";
            treeNode29.Text = "Payroll";
            treeNode30.ImageKey = "order.ico";
            treeNode30.Name = "mnuMenus";
            treeNode30.SelectedImageIndex = 24;
            treeNode30.Text = "Menus";
            this.tvMenus.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30});
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
    }
}



