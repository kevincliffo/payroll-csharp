using System;
using System.Data;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;
using CrystalDecisions.CrystalReports.Engine;
using CollectionClasses;

namespace PayRollSystem
{
    public partial class F_Main : Form
    {
        private DatabaseConnection dbcx = null;
        private Utilities.Utilities utsx = null;
        private Users_DS u_dsx = null;
        private Attendance_DS a_dsx = null;
        private StatusBarHandler sbhx = null;
        private ApplicationPathCarrier apcx = null;
        private NHIFRates nhifrsx = null;
        private License_DS l_dsx = null;
        private Defaults_DS def_dsx = null;
        private Departments_DS d_dsx = null;
        private Materials_DS m_dsx = null;
        private Payrolls_DS pr_dsx = null;
        private PayrollsList_DS prl_dsx = null;
        private Staffs_DS s_dsx = null;
        private SubDepartments_DS sd_dsx = null;
        private Suppliers_DS sup_dsx = null;
        private WorkOrderEmployeeWorkDatas_DS woewd_dsx = null;
        private WorkOrderMaterials_DS wom_dsx = null;
        private WorkOrders_DS wo_dsx = null;
        private WorkOrderTemplateMaterials_DS wotm_dsx = null;
        private WorkOrderTemplateWorks_DS wotw_dsx = null;
        private WorkOrderTemplates_DS wot_dsx = null;
        private WorkOrderWorks_DS wow_dsx = null;
        private Works_DS w_dsx = null;
        private BasicData_DS bd_dsx = null;

        private F_Login f_lx = null;
        private F_SplashScreen f_scx = null;

        private Modules msx = null;
        public delegate void delPrepareFormForAdd(string szvFormKey);
        public delegate void delRecordNavigationTasks(string szvFormKey,
                                                      EnumsCollection.EnumRecordNavigationTasks erntv);

        public event delRecordNavigationTasks RecordNavigationTasks;
        private bool bxByPassShutDownPrompt = false;
        private const string szxEMPTY = "";

        public F_Main()
        {
            apcx = new ApplicationPathCarrier(Application.StartupPath);
            utsx = new Utilities.Utilities();
            nhifrsx = new NHIFRates();
            msx = new Modules();
            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMDIForm;
        }

        private void XX_DoStartupTasks()
        {
            XX_EnableMDIFormControls(false);
            f_lx = new F_Login();
            f_lx.ConnectionSucceeded +=new F_Login.delConnectionSucceeded(f_lx_ConnectionSucceeded);
            f_lx.MdiParent = this;
            f_lx.StartPosition = FormStartPosition.CenterScreen;
            f_lx.Show();
        }

        private void XX_EnableMDIFormControls(bool bvEnable)
        {
            menuStrip.Visible = bvEnable;
            tsNavigation.Visible = bvEnable;
            tvMenus.Visible = bvEnable;
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            XX_DoStartupTasks();
        }

        void f_lx_ConnectionSucceeded(DatabaseConnection dbcv, 
                                      bool bvConnectionSucceeded)
        {
            switch (bvConnectionSucceeded)
            {
                case true:
                    dbcx = dbcv;
                    
                    f_scx = new F_SplashScreen(dbcx);
                    f_scx.EnableMDIFormControls += new F_SplashScreen.delEnableMDIFormControls(f_scx_EnableMDIFormControls);
                    f_scx.MdiParent = this;
                    f_scx.StartPosition = FormStartPosition.CenterScreen;
                    f_scx.Show();

                    break;

                case false:

                    break;
            }
        }

        void f_scx_EnableMDIFormControls()
        {
            XX_EnableMDIFormControls(true);

            this.FormClosed += new FormClosedEventHandler(F_Main_FormClosed);
            this.FormClosing += new FormClosingEventHandler(F_Main_FormClosing);
            utsx.DisplayMessageInStatusBar += new Utilities.Utilities.delDisplayMessageInStatusBar(utsx_DisplayMessageInStatusBar);
            this.MdiChildActivate += new EventHandler(F_Main_MdiChildActivate);
            sbhx = new StatusBarHandler(tsslMessage);

            XX_InitializeTables();
            XX_InitializeModulesCollection();
            XX_GetLicenseDetails();

            XX_ExpandTreeView();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XX_LaunchUsers();
        }

        private void XX_LaunchUsers()
        {
                                        bool bValidUser = false;

            while(true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser) 
                {
                    utsx.ShowMessage("User does not have permissions to launch form",
                                     "Permissions",
                                     EnumsCollection.EnumMessageType.emtError); 
                    break;
                }

                F_Users f_us = new F_Users(this, dbcx, null, EnumsCollection.EnumFormMode.efmAdd);
                f_us.MdiParent = this;
                f_us.Show();
                break;
            }
        }

        private void XX_CheckIfLicenseIsValid(string szvLicenseKey,
                                              ref string szrDecryptedLicenseText)
        {
                                        string szDecryptedLicenseText = string.Empty;
                                        string szActivatedModulesMessageString = string.Empty;
                                        string szNotActivatedModulesMessageString = string.Empty;
                                        string szMessage = string.Empty;
                                        string[] aszModules;
                                        Tags tgs = new Tags();
                                        bool bModuleFound = false;

            while(true)
            {
                if (szvLicenseKey == szxEMPTY)
                {
                    break;
                }

                utsx.Decrypt(szvLicenseKey,
                             ref szDecryptedLicenseText);

                aszModules = szDecryptedLicenseText.Split('_');

                foreach (string szModule in aszModules)
                {
                    while (true)
                    {
                        if (szModule == szxEMPTY)
                        {
                            break;
                        }

                        foreach (Module m in msx)
                        {
                            if (m.ModuleName == szModule)
                            {
                                bModuleFound = true;
                                m.ModuleEnabled = true;
                                break;
                            }
                        }

                        if (bModuleFound)
                        {
                            break;
                        }

                        break;
                    }
                }
                break;
            }
            szrDecryptedLicenseText = szDecryptedLicenseText;
        }

        private void XX_InitializeTables()
        {
            a_dsx = new Attendance_DS(dbcx);
            def_dsx = new Defaults_DS(dbcx);
            d_dsx = new Departments_DS(dbcx);
            l_dsx = new License_DS(dbcx);
            m_dsx = new Materials_DS(dbcx);
            pr_dsx = new Payrolls_DS(dbcx);
            prl_dsx = new PayrollsList_DS(dbcx);
            sd_dsx = new SubDepartments_DS(dbcx);
            sup_dsx = new Suppliers_DS(dbcx);
            u_dsx = new Users_DS(dbcx);
            woewd_dsx = new WorkOrderEmployeeWorkDatas_DS(dbcx);
            wom_dsx = new WorkOrderMaterials_DS(dbcx);
            wo_dsx = new WorkOrders_DS(dbcx);
            wotm_dsx = new WorkOrderTemplateMaterials_DS(dbcx);
            wotw_dsx = new WorkOrderTemplateWorks_DS(dbcx);
            wot_dsx = new WorkOrderTemplates_DS(dbcx);
            wow_dsx = new WorkOrderWorks_DS(dbcx);
            w_dsx = new Works_DS(dbcx);
            s_dsx = new Staffs_DS(dbcx);
            bd_dsx = new BasicData_DS(dbcx);
        }

        private void XX_GetLicenseDetails()
        {
                                        FileAccessor fa = new FileAccessor();
                                        string szValue = string.Empty;
                                        string szDecryptedLicenseText = string.Empty;
                                        string szLicenseValue = string.Empty;
                                        Fields fds = null;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szNewLicenseValue = string.Empty;

            while(true)
            {
                fds = l_dsx.Fields;
                l_dsx.GetLastRecordFromDataBase(ref fds,
                                                ref bNothingFound,
                                                ref bErrorFound,
                                                ref szErrorMessage);

                if (bNothingFound)
                {
                    break;
                }

                szLicenseValue = fds.ItemIsField("LicenseValue").StringValue;

                switch (szLicenseValue)
                {
                    case szxEMPTY:
                        XX_InitializeDemoMode();
                        break;
                    default:
                        utsx.Decrypt(szLicenseValue,
                                     ref szDecryptedLicenseText);

                        szDecryptedLicenseText = szDecryptedLicenseText.Substring(0, szDecryptedLicenseText.Length - 1);
                        XX_ActivateLicensedModules(szDecryptedLicenseText,
                                                   ref bErrorFound);
                        break;
                }
                break;
            }
        }
        private void XX_InitializeDemoMode()
        {
            utsx.ShowMessage("Application is not Licensed, You are running on \nDemo MOde",
                             "Licensing",
                             EnumsCollection.EnumMessageType.emtInformation);

            foreach (Module m in msx)
            {
                m.ModuleEnabled = false;
            }
        }

        private void XX_InitializeModulesCollection()
        { 
                                        Module m = null;

            msx.RemoveAllModules();

            msx.AddModule("mnuPayroll",
                          ref m);
            m.ModuleName = "Payroll";
            m.ModuleEnabled = false;

            msx.AddModule("mnuInventory",
                          ref m);
            m.ModuleName = "Inventory";
            m.ModuleEnabled = false;
            
            msx.AddModule("mnuProduction",
                          ref m);
            m.ModuleName = "Production";
            m.ModuleEnabled = false;
        }

        private void XX_ActivateLicensedModules(string szvDecryptedLicenseText,
                                                ref bool brErrorFound)
        {
                                        string[] aszModules = szvDecryptedLicenseText.Split('_');
                                        bool bModulesAreValid = false;

            while(true)
            {
                XX_CheckIfLicenseModulesAreValid(aszModules,
                                                 ref bModulesAreValid);

                if (bModulesAreValid == false)
                {
                    utsx.ShowMessage("License is not valid",
                                     " License File Error",
                                     EnumsCollection.EnumMessageType.emtError);

                    foreach (Module m in msx)
                    {
                        m.ModuleEnabled = false;
                    }

                    break;
                }
                                      
                foreach(string szModule in aszModules)
                {
                    foreach (Module m in msx)
                    {
                        if (m.ModuleName == szModule)
                        {
                            m.ModuleEnabled = true;
                            break;
                        }
                    }
                }
                break;
            }
        }

        private void XX_CheckIfLicenseModulesAreValid(string[] aszvModules,
                                                      ref bool brModulesAreValid)
        {
                                    bool bModuleIsValid = false;

            foreach (string szModule in aszvModules)
            {
                bModuleIsValid = false;
                foreach (Module m in msx)
                {
                    if (m.ModuleName == szModule)
                    {
                        bModuleIsValid = true;
                        break;
                    }
                }

                if (bModuleIsValid == false)
                {
                    break;
                }
            }

            brModulesAreValid = bModuleIsValid;
        }

        private void XX_ExpandTreeView()
        {
                                        bool bExit = false;

            foreach (TreeNode tn in tvMenus.Nodes)
            {
                if (tn.Level == 0)
                {
                    tn.Expand();
                }
            }

            TreeNode tnmnuAdminInterface = tvMenus.Nodes[0];

            for (int nNodeIndex = tnmnuAdminInterface.Nodes.Count -1; nNodeIndex >= 0; nNodeIndex--)
            {
                TreeNode tn = (TreeNode)tnmnuAdminInterface.Nodes[nNodeIndex];
                while(true)
                {
                    if (tn == null)
                    {
                        break;
                    }
                    
                    foreach (Module m in msx)
                    {
                        while (true)
                        {
                            if (tn.Name != m.Key)
                            {
                                break;
                            }

                            if (m.ModuleEnabled == false)
                            {
                                bExit = true;
                                tn.Remove();
                                break;
                            }
                            break;
                        }
                        if (bExit)
                        {
                            bExit = false;
                            break;
                        }
                    }
                    break;
                }
            }

            XX_DisableToolStripMenuItemsOnDisabledModulesIf(msx);
            dbcx.ApplicationModules = msx;
        }

        private void XX_DisableToolStripMenuItemsOnDisabledModulesIf(Modules msv)
        {
            foreach (Module m in msv)
            {
                while (true)
                {
                    if (m.ModuleEnabled)
                    {
                        break;
                    }

                    switch (m.Key)
                    {
                        case "mnuProduction":
                        case "mnuInventory":
                            tsmiSuppliers.Visible = false;
                            break;
                        case "mnuPayroll":
                            tsmiPayroll.Visible = false;
                            break;
                    }

                    break;
                }
            }
        }

        void F_Main_MdiChildActivate(object sender, EventArgs e)
        {
                                        Form frmActive = this.ActiveMdiChild;
                                        bool bEnableDataNavigation = false;
                                        Utilities.EnumsCollection.EnumFormType eft = new EnumsCollection.EnumFormType();
            
            while(true)
            {
                if(frmActive == null)
                {
                    bEnableDataNavigation = false;
                    break;
                }

                frmActive.Left = tvMenus.Width + 3;
                eft = (EnumsCollection.EnumFormType)frmActive.Tag;

                switch (eft)
                {
                    case EnumsCollection.EnumFormType.eftMaster:
                        bEnableDataNavigation = true;
                        break;

                    case EnumsCollection.EnumFormType.eftService:
                        bEnableDataNavigation = false;
                        break;

                    default:
                        bEnableDataNavigation = false;
                        break;
                }
                break;
            }

            tsNavigation.Enabled = bEnableDataNavigation;

        }

        void F_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
                                        bool bCancelExit = false;

            while(true)
            {
                if (bxByPassShutDownPrompt)
                {
                    bCancelExit = false;
                    break;
                }

                DialogResult dResult = MessageBox.Show("Are you sure you want to Close the application? ", 
                                                       "Exit",
                                                        MessageBoxButtons.YesNo, 
                                                        MessageBoxIcon.Question);
                switch(dResult)
                {
                    case DialogResult.Yes:
                        bCancelExit = false;
                        break;

                    case DialogResult.No:
                        bCancelExit = true;
                        break;
                }
                break;
            }
            e.Cancel = bCancelExit;
        }

        void utsx_DisplayMessageInStatusBar(string szvMessage, 
                                            EnumsCollection.EnumMessageType emtv)
        {
            sbhx.ShowStatusBarMessage(szvMessage, 
                                      emtv);
        }

        void F_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                        string szReportPath = string.Empty;
                                        F_ReportViewer f_Viewer = new F_ReportViewer(dbcx);
                                        ReportDocument doc = new ReportDocument();
                                        DataSet ds = null;
                                        DataTable dtReport = new DataTable();
                                        Reports.ReportDataSets.dsUsers dsUsers = new Reports.ReportDataSets.dsUsers();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            dtReport.TableName = "Users";
            dbcx.ExecuteSQL("SELECT * FROM users",
                            ref ds,
                            ref bErrorFound,
                            ref szErrorMessage);

            while (true)
            {
                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                dtReport = ds.Tables[0];
                dsUsers.Tables[0].Merge(dtReport);

                szReportPath = dbcx.ApplicationPathCarrier.ReportsPath
                             + @"\crUsers.rpt";
                doc.Load(szReportPath);
                
                //doc.SetDataSource(dsUsers);
                f_Viewer.LaunchReport("Users",
                                      doc);

                f_Viewer.Show();
                break;
            }
        }

        private void viewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {

                                        bool bValidUser = false;

            while (true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser)
                {
                    utsx.ShowMessage("User does not have permissions to launch form",
                                     "Permissions",
                                      EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                F_Table tbl_Users = new F_Table(this,
                                                dbcx,
                                                "Users",
                                                u_dsx);
                tbl_Users.MdiParent = this;
                tbl_Users.Show();
                break;
            }

        }

        private void feesBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Attendance f_FeesPayments = new F_Attendance(this,
                                                               dbcx,
                                                               null,
                                                               EnumsCollection.EnumFormMode.efmAdd);
            f_FeesPayments.MdiParent = this;
            f_FeesPayments.Show();
        }
         
        private void tsbFirst_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord);
            }
        }

        private void XX_GetId(ref string szrId)
        {

            foreach (Control c in this.ActiveMdiChild.Controls)
            {
                if (c.Name == "txtId")
                {
                    szrId = c.Text;
                    break;
                }
            }
        }

        private void tsbPrevious_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord);
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord);
            }
        }

        private void tsbLast_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord);
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntNewRecord);
            }
        }

        private void tsbFind_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntFindRecord);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (RecordNavigationTasks != null)
            {
                RecordNavigationTasks(this.ActiveMdiChild.Name,
                                      EnumsCollection.EnumRecordNavigationTasks.erntRemoveRecord);
            }
        }

        private void XX_ViewDefaults()
        {
            F_Defaults f_Defaults = new F_Defaults(this, dbcx);

            f_Defaults.MdiParent = this;
            f_Defaults.Show();
        }

        private void XX_LaunchPayrollList()
        { 
                                        bool bValidUser = false;

            while(true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser) 
                {
                    utsx.ShowMessage("User does not have permissions to launch form",
                                     "Permissions",
                                     EnumsCollection.EnumMessageType.emtError); 
                    break;
                }

                F_PayRollList f_PayRollList = new F_PayRollList(this, tsslMessage, dbcx);

                f_PayRollList.MdiParent = this;
                f_PayRollList.Show();
                break;
            }        
        }

        private void XX_AddAttendance()
        {
            F_Attendance f_Attendance = new F_Attendance(this, dbcx, null, EnumsCollection.EnumFormMode.efmAdd);

            f_Attendance.MdiParent = this;
            f_Attendance.Show();
        }

        private void tsmiPayRoll_Click(object sender, EventArgs e)
        {
                                        string szReportPath = string.Empty;
                                        F_ReportViewer f_Viewer = new F_ReportViewer(dbcx);
                                        ReportDocument doc = new ReportDocument();
                                        DataSet ds = null;
                                        DataTable dtReport = new DataTable();
                                        Reports.ReportDataSets.dsPayRoll dsPayRoll = new Reports.ReportDataSets.dsPayRoll();
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
            
            dtReport.TableName = "PayRollCalculation";
            dbcx.ExecuteSQL("SELECT * FROM payrollcalculation",
                            ref ds,
                            ref bErrorFound,
                            ref szErrorMessage);

            while (true)
            {
                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                dtReport = ds.Tables[0];
                dsPayRoll.Tables[0].Merge(dtReport);

                szReportPath = dbcx.ApplicationPathCarrier.ReportsPath
                             + @"\crPayRoll.rpt";
                doc.Load(szReportPath);
                doc.SetDataSource(dsPayRoll);
                f_Viewer.LaunchReport("PayRollCalculation",
                                      doc);

                f_Viewer.Show();
                break;
            }
        }

        private void tsbUsers_Click(object sender, EventArgs e)
        {
            F_Users f_Users = new F_Users(this, dbcx, null, EnumsCollection.EnumFormMode.efmFind);
            f_Users.MdiParent = this;
            f_Users.Show();
        }

        private void tsmiLogout_Click(object sender, EventArgs e)
        {
            bxByPassShutDownPrompt = true;
            this.Close();

        }

        private void tsbPayRoll_Click(object sender, EventArgs e)
        {
            F_PayRollList f_PayRollDeductions = new F_PayRollList(this, tsslMessage, dbcx);

            f_PayRollDeductions.MdiParent = this;
            f_PayRollDeductions.Show();
        }

        private void tsNavigation_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsmiAttendanceView_Click(object sender, EventArgs e)
        {
            XX_AttendanceView();
        }

        private void XX_AttendanceView()
        {
            F_AttendanceView f_AttendanceView = new F_AttendanceView(this, dbcx);

            f_AttendanceView.MdiParent = this;
            f_AttendanceView.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void XX_LaunchPayRoll()
        {
                                        bool bValidUser = false;

            while(true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser) 
                {
                    utsx.ShowMessage("User does not have permissions to launch form",
                                     "Permissions",
                                     EnumsCollection.EnumMessageType.emtError); 
                    break;
                }

                F_Payroll f_pr = new F_Payroll(this,
                                               dbcx,
                                               null,
                                               EnumsCollection.EnumFormMode.efmOk);
                f_pr.MdiParent = this;
                f_pr.Show();

                break;
            }
        }

        private void tsmiDepartment_Click(object sender, EventArgs e)
        {
            XX_LaunchDepartments(EnumsCollection.EnumFormMode.efmAdd);
        }

        private void XX_LaunchDepartments(EnumsCollection.EnumFormMode efmv)
        {
            F_Departments f_Departments = new F_Departments(this,
                                                            dbcx,
                                                            null,
                                                            efmv);
            f_Departments.MdiParent = this;
            f_Departments.Show();        
        }

        private void tsmiNHIFRates_Click(object sender, EventArgs e)
        {
            XX_LaunchNHIFRates();
        }

        private void XX_LaunchNHIFRates()
        { 
            while (true)
            {
                if (dbcx.EnumUserType != EnumsCollection.EnumUserType.eutAdministrator)
                {
                    utsx.ShowMessage("User does not have Permissions to view Form",
                                     EnumsCollection.EnumMessageType.emtInformation);
                    break;
                }

                F_NHIFRates f_NHIFRates = new F_NHIFRates(this,
                                                          dbcx);
                f_NHIFRates.MdiParent = this;
                f_NHIFRates.Show();

                break;
            }        
        }

        private void tsmiNSSFRates_Click(object sender, EventArgs e)
        {
            XX_LaunchNSSFRates();
        }

        private void XX_LaunchNSSFRates()
        {
            while (true)
            {
                if (dbcx.EnumUserType != EnumsCollection.EnumUserType.eutAdministrator)
                {
                    utsx.ShowMessage("User does not have Permissions to view Form",
                                     EnumsCollection.EnumMessageType.emtInformation);
                    break;
                }

                F_NSSFRates f_NSSFRates = new F_NSSFRates(this,
                                                          dbcx);
                f_NSSFRates.MdiParent = this;
                f_NSSFRates.Show();

                break;
            }
        }

        private void tsmiSupplier_Click(object sender, EventArgs e)
        {
            XX_LaunchSuppliers();
        }

        private void XX_LaunchSuppliers()
        {
            F_Suppliers f_Suppliers = new F_Suppliers(this,
                                                      dbcx,
                                                      null,
                                                      EnumsCollection.EnumFormMode.efmFind);
            f_Suppliers.MdiParent = this;
            f_Suppliers.Show();

        }

        private void XX_LaunchWorkOrderTemplatesList()
        {
            F_WorkOrderTemplates f_wots = new F_WorkOrderTemplates(this,
                                                                  dbcx,
                                                                  null,
                                                                  EnumsCollection.EnumFormMode.efmFind);
            f_wots.MdiParent = this;
            f_wots.Show();
        }

        private void XX_LaunchWorkOrderTemplate()
        {
            F_WorkOrderTemplate f_wot = new F_WorkOrderTemplate(this,
                                                                dbcx,
                                                                null,
                                                                EnumsCollection.EnumFormMode.efmFind);
            f_wot.MdiParent = this;
            f_wot.Show();
        }

        private void XX_LaunchWorkOrder()
        {
            F_WorkOrder f_wo = new F_WorkOrder(this,
                                               dbcx,
                                               null,
                                               EnumsCollection.EnumFormMode.efmFind);
            f_wo.MdiParent = this;
            f_wo.Show();
        }

        private void XX_LaunchItemsMaster()
        {
            F_ItemsMaster f_im = new F_ItemsMaster(this,
                                                   dbcx,
                                                   null,
                                                   EnumsCollection.EnumFormMode.efmFind);
            f_im.MdiParent = this;
            f_im.Show();
        }

        private void tvMenus_AfterSelect(object sender, TreeViewEventArgs e)
        {
                                        TreeView tvTreeView = (TreeView)sender;
                                        TreeNode tNode = tvTreeView.SelectedNode;

            switch (tNode.Name)
            {
                case "mnuDepartments":
                    XX_LaunchDepartments(EnumsCollection.EnumFormMode.efmFind);
                    break;
                case "mnuSuppliers":
                    XX_LaunchSuppliers();
                    break;
                case "mnuUsers":
                    XX_LaunchUsers();
                    break;
                case "mnuWorkOrderTemplate":
                    XX_LaunchWorkOrderTemplate();
                    break;
                case "mnuWorkOrderTemplatesList":
                    XX_LaunchWorkOrderTemplatesList();
                    break;
                case "mnuWorkOrder":
                    XX_LaunchWorkOrder();
                    break;
                case "mnuItemsMaster":
                    XX_LaunchItemsMaster();
                    break;
                case "mnuAttendanceView":
                    XX_AttendanceView();
                    break;
                case "mnuGoodsReceipt":

                    break;
                case "mnuAdminInterface":
                    XX_LaunchAdminInterface();
                    break;
                case "mnuStaffPayroll":
                    XX_LaunchPayRoll();
                    break;
                case "mnuCasualStaffPayroll":
                    XX_LaunchCasualStaffPayRoll();
                    break;
                case "mnuPayrollList":
                    XX_LaunchPayrollList();
                    break;
                case "mnuAddStaff":
                    XX_AddStaff();
                    break;
                case "mnuViewStaff":
                    XX_ViewStaff();
                    break;
                case "mnuDefaults":
                    XX_ViewDefaults();
                    break;
                case "mnuAttendance":
                    XX_AddAttendance();
                    break;

            }
        }

        private void XX_LaunchAdminInterface()
        {
            F_AdminInterface f_ai = new F_AdminInterface(this,
                                                         dbcx,
                                                         null,
                                                         EnumsCollection.EnumFormMode.efmOk);
            f_ai.MdiParent = this;
            f_ai.Show();
        }

        private void tsmiCasualStaffPayroll_Click(object sender, EventArgs e)
        {
            XX_LaunchCasualStaffPayRoll();
        }

        private void XX_LaunchCasualStaffPayRoll()
        {
            F_PayrollCasual f_pc = new F_PayrollCasual(this,
                                                       dbcx,
                                                       null,
                                                       EnumsCollection.EnumFormMode.efmOk);
            f_pc.MdiParent = this;
            f_pc.Show();
        }

        private void tsmiViewTreeMenu_Click(object sender, EventArgs e)
        {
                                        bool bTreeMenuVisible = false;

            bTreeMenuVisible = tvMenus.Visible;

            tvMenus.Visible = !bTreeMenuVisible;
            tsmiViewTreeMenu.Checked = tvMenus.Visible;
        }

        private void tsmiActivateLicense_Click(object sender, EventArgs e)
        {
            F_LicenseActivation f_la = new F_LicenseActivation(this,
                                                               dbcx,
                                                               msx);

            f_la.MdiParent = this;
            f_la.Show();
        }

        private void XX_AddStaff()
        {
                                        bool bValidUser = false;

            while(true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser) 
                {
                    utsx.ShowMessage("User does not have permissions to launch form",
                                     "Permissions",
                                     EnumsCollection.EnumMessageType.emtError); 
                    break;
                }

                F_StaffMaster f_StaffMaster = new F_StaffMaster(this, dbcx, null, EnumsCollection.EnumFormMode.efmAdd);
                f_StaffMaster.MdiParent = this;
                f_StaffMaster.Show();
                break;
            }
        }

        private void tsmiAddStaff_Click(object sender, EventArgs e)
        {
            XX_AddStaff();
        }

        private void XX_ViewStaff()
        {
            F_Table tbl_Staff = new F_Table(this,
                                            dbcx,
                                            "Staff",
                                            s_dsx);
            tbl_Staff.MdiParent = this;
            tbl_Staff.Show();
        }

        private void tsmiViewStaff_Click(object sender, EventArgs e)
        {
            XX_ViewStaff();
        }

        private void tsmiStaffPayroll_Click(object sender, EventArgs e)
        {
            XX_LaunchPayRoll();
        }

        private void tsmiPayrollList_Click(object sender, EventArgs e)
        {
            XX_LaunchPayrollList();
        }

        private void XX_LaunchTable(string szvTableName,
                                    dynamic dvDataServer)
        {
            F_Table f_t = new F_Table(this,
                                      dbcx,
                                      szvTableName,
                                      dvDataServer);

            f_t.MdiParent = this;
            f_t.Show();        
        }

        private void tsmiUsersTable_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("Users",
                           u_dsx);
        }

        private void tsmiStaffsTable_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("Staff",
                           s_dsx);
        }

        private void tsmiDepartmentsTable_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("Departments",
                           d_dsx);
        }

        private void tsmiSubDepartmentsTable_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("SubDepartments",
                           sd_dsx);
        }

        private void tsmiDepartmentsView_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("Departments",
                           d_dsx);
        }

        private void XX_LaunchAttendance()
        {
            F_Attendance f_a = new F_Attendance(this,
                                                dbcx,
                                                null,
                                                EnumsCollection.EnumFormMode.efmAdd);

            f_a.MdiParent = this;
            f_a.Show();
        }
        private void tsmiAttendance_Click(object sender, EventArgs e)
        {
            XX_LaunchAttendance();
        }

        private void tsmiSuppliersTable_Click(object sender, EventArgs e)
        {
            XX_LaunchTable("Suppliers",
                           sup_dsx);
        }
    }
}
