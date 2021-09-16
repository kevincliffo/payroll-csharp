using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using MySql.Data.MySqlClient;

namespace PayRollSystem
{
    public partial class F_AdminInterface : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private SharedComponents scsx = null;

        private const string szxEMPTY = "";

        public F_AdminInterface(Form mdivForm,
                                DatabaseConnection dbcv,
                                
                                Fields fdsvUpdateFields,
                                EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;

            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            
            scsx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_AdminInterface_Load(object sender, EventArgs e)
        {
                                        Icon ic = null;

            ic = new Icon(dbcx.ApplicationPathCarrier.IconsPath + "\\people.ico");
            this.Icon = ic;

            XX_GetEmployeeDetailsForFirstTime();
            XX_DoAdditionalTasksOverLicensedModules();
            XX_CheckIfCheckBoxesAreDisabled();
        }

        private void XX_DoAdditionalTasksOverLicensedModules()
        {
            foreach (Module m in dbcx.ApplicationModules)
            {
                switch (m.Key)
                {
                    case "mnuPayroll":
                        if (m.ModuleEnabled == false)
                        {
                            dgvUsers.Columns["PayrollModule"].Visible = false;
                            chkPayrollManagementModule.Enabled = false;
                        }

                        break;

                    case "mnuInventory":
                        if (m.ModuleEnabled == false)
                        {
                            dgvUsers.Columns["InventoryModule"].Visible = false;
                            chkInventoryModule.Enabled = false;
                        }
                        break;

                    case "mnuProduction":
                        if (m.ModuleEnabled == false)
                        {
                            dgvUsers.Columns["ProductionModule"].Visible = false;
                            chkProductionModule.Enabled = false;
                        }
                        break;
                }
            }        
        }

        private void XX_ResetCheckBoxes()
        {
            chkInventoryModule.Checked = false;
            chkPayrollManagementModule.Checked = false;
            chkProductionModule.Checked = false;
        }

        private void XX_CheckIfCheckBoxesAreDisabled()
        {
                                        bool bEnabledCheckBoxFound = false;

            while (true)
            {
                if (chkInventoryModule.Checked)
                {
                    bEnabledCheckBoxFound = true;
                    break;
                }

                if (chkPayrollManagementModule.Checked)
                {
                    bEnabledCheckBoxFound = true;
                    break;
                }

                if (chkProductionModule.Checked)
                {
                    bEnabledCheckBoxFound = true;
                    break;
                }
                break;
            }

            if (bEnabledCheckBoxFound == false)
            {
                btnUpdate.Enabled = false;
            }
        }

        private void XX_GetEmployeeDetailsForFirstTime()
        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader msql_dr = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DataGridViewRow dgvRow = null;
                                        string szFullName = string.Empty;
                                        string szUserType = string.Empty;
                                        string szPassword = string.Empty;
                                        long lUserType = 0;
                                        EnumsCollection.EnumUserType eut = new EnumsCollection.EnumUserType();

            szSQL = "SELECT * FROM users";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref msql_dr);

            while (msql_dr.Read())
            {
                dgvRow = (DataGridViewRow)dgvUsers.Rows[0].Clone();

                dgvRow.Cells[0].Value = Convert.ToInt32(msql_dr["UserId"].ToString());
                dgvRow.Cells[1].Value = msql_dr["UserName"].ToString();

                szFullName = msql_dr["FirstName"].ToString()
                           + " "
                           + msql_dr["LastName"].ToString()
                           + " "
                           + msql_dr["OtherName"].ToString();

                dgvRow.Cells[2].Value = szFullName;

                lUserType = Convert.ToInt32(msql_dr["UserType"].ToString());
                eut = (EnumsCollection.EnumUserType)lUserType;

                switch (eut)
                {
                    case EnumsCollection.EnumUserType.eutAdministrator:
                        szUserType = "Administrator";
                        break;
                    case EnumsCollection.EnumUserType.eutUser:
                        szUserType = "User";
                        break;
                    case EnumsCollection.EnumUserType.eutVisitor:
                        szUserType = "Visitor";
                        break;
                }

                dgvRow.Cells[3].Value = szUserType;

                utsx.Decrypt(msql_dr["Password"].ToString(),
                             ref szPassword);
                dgvRow.Cells[4].Value = szPassword;

                dgvRow.Cells[5].Value = Convert.ToInt32(msql_dr["InventoryModuleEnabled"].ToString());
                dgvRow.Cells[6].Value = Convert.ToInt32(msql_dr["ProductionModuleEnabled"].ToString());
                dgvRow.Cells[7].Value = Convert.ToInt32(msql_dr["PayrollModuleEnabled"].ToString());

                dgvUsers.Rows.Add(dgvRow);
            }

            msql_dr.Close();
            msql_dr.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                                        bool bInventoryEnabled = chkInventoryModule.Checked;
                                        bool bProductionEnabled = chkProductionModule.Checked;
                                        bool bPayrollEnabled = chkPayrollManagementModule.Checked;
                                        ArrayList collStaffIds = new ArrayList();

            foreach (DataGridViewRow dgvr in dgvUsers.Rows)
            {
                if (dgvr.Selected)
                {
                    collStaffIds.Add(dgvr.Cells[0].Value.ToString());
                }
            }

            XX_UpdateAdminInterfaceValues(collStaffIds,
                                          bInventoryEnabled,
                                          bProductionEnabled,
                                          bPayrollEnabled);
        }

        private void XX_UpdateAdminInterfaceValues(ArrayList collStaffIds,
                                                   bool bvInventoryEnabled,
                                                   bool bvProductionEnabled,
                                                   bool bvPayrollEnabled)
        {
                                        string szSQL = string.Empty;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
        
            foreach(string szStaffId in collStaffIds)
            {
                szSQL = "UPDATE staffs SET "
                      + " InventoryModuleEnabled = " + utsx.ConvertBooleanToLong(bvInventoryEnabled)
                      + " ,ProductionModuleEnabled = " + utsx.ConvertBooleanToLong(bvProductionEnabled)
                      + " ,PayrollModuleEnabled = " + utsx.ConvertBooleanToLong(bvPayrollEnabled)
                      + " WHERE StaffId = " + szStaffId;

                dbcx.ExecuteSQL(szSQL,
                                ref bErrorFound,
                                ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }
            }

            if (bErrorFound)
            {
                utsx.ShowMessage(szErrorMessage,
                                 EnumsCollection.EnumMessageType.emtError);
            }
            else
            {
                scsx.ClearDataGridView(dgvUsers);
                XX_GetEmployeeDetailsForFirstTime();
                XX_ResetCheckBoxes();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
