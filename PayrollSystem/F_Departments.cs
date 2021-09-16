using System;
using System.Collections.Generic;
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

namespace PayRollSystem
{
    public partial class F_Departments : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Departments_DS d_dsx = null;
        private SubDepartments_DS sd_dsx = null;
        private SharedComponents scsx = null;
        private const string szxEMPTY = "";

        public F_Departments(Form mdivForm,
                             DatabaseConnection dbcv,
                             
                             Fields fdsvUpdateFields,
                             EnumsCollection.EnumFormMode efmv)
        {
            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            d_dsx = new Departments_DS(dbcx);
            sd_dsx = new SubDepartments_DS(dbcv);

            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            
            scsx = new SharedComponents(dbcx);

            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void XX_ChangeFormMode(EnumsCollection.EnumFormMode efmv)
        {
            efmx = efmv;
            switch (efmv)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    btnNavigation.Text = "Add";
                    btnDelete.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    btnNavigation.Text = "Update";
                    btnDelete.Visible = true;
                    break;

                case EnumsCollection.EnumFormMode.efmFirstTimeUse:
                    btnNavigation.Text = "Add";
                    btnDelete.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmOk:
                    btnNavigation.Text = "Ok";
                    btnDelete.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmFind:
                    btnDelete.Visible = false;
                    btnNavigation.Text = "Find";
                    break;
            }
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
            this.Text = "Department"
                      + " - "
                      + fdsv.ItemIsField("DepartmentName").StringValue;

            txtDepartmentName.Text = fdsv.ItemIsField("DepartmentName").StringValue;
        }

        private void XX_MoveUserValuesToFields(ref Fields fdsr)
        {
            fdsr.ItemIsField("DepartmentName").StringValue = txtDepartmentName.Text;
        }

        private void XX_InitializeEvents()
        {
            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_Departments_RecordNavigationTasks);
        }

        private void XX_RefereshControls()
        {
            txtDepartmentName.Text = string.Empty;

            scsx.ClearDataGridView(dgvSubDepartments);
        }

        private void XX_PrepareFormForAdd(string szvFormKey)
        {
            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);

                XX_RefereshControls();
            }
        }

        private void XX_PrepareFormForFind(string szvFormKey)
        {
            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmFind);
                XX_RefereshControls();
            }
        }

        private void XX_AddDepartmentToDataBase()
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szMessage = string.Empty;
                                        long lDepartmentId = 0;

            fds = d_dsx.Fields;
            XX_MoveUserValuesToFields(ref fds);

            while (true)
            {
                d_dsx.AddToDataBase(fds,
                                    ref bErrorFound,
                                    ref szErrorMessage);

                if (!bErrorFound)
                {
                    lDepartmentId = Convert.ToInt32(fds.ItemIsField("DepartmentId").StringValue);
                    XX_AddSubDepartmentsToDataBase(lDepartmentId,
                                                   ref bErrorFound,
                                                   ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                         EnumsCollection.EnumMessageType.emtError);
                        break;
                    }
                    else
                    {
                        utsx.ShowMessage("Department Added successfully",
                                         EnumsCollection.EnumMessageType.emtSuccess);
                    }

                    XX_RefereshControls();
                }
                else
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                }
                break;
            }
        }

        private void XX_UpdateDepartmentInDataBase()
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            XX_MoveUserValuesToFields(ref fdsxUpdateFields);

            d_dsx.UpdateDataInDataBase(fds,
                                       ref bErrorFound,
                                       ref szErrorMessage);
            if (!bErrorFound)
            {
                utsx.ShowMessage("Department Updated successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);

                XX_RefereshControls();
            }
            else 
            {
                utsx.ShowMessage(szErrorMessage,
                                 EnumsCollection.EnumMessageType.emtError);
            }
        }

        private void XX_FindStaffrOverIdentificationNumber()
        {
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szErrorMessage = string.Empty;
                                        Fields fds = null;

            d_dsx.GetDepartmentOverDepartmentName(txtDepartmentName.Text,
                                                  ref fds,
                                                  ref bNothingFound,
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

                if(bNothingFound)
                {
                    utsx.ShowMessage("No Record Found",
                                     EnumsCollection.EnumMessageType.emtInformation);
                    break;
                }

                XX_MoveFieldValuesToControls(fds);
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                break;
            }
        }

        private void XX_RemoveStaffFromDataBase(string szvFormKey,
                                                Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Department" 
                            + System.Environment.NewLine
                            + txtDepartmentName.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    d_dsx.RemoveFromDataBase(fdsv,
                                             ref bErrorFound,
                                             ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                            EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        sd_dsx.RemoveAllSubDepartmentsFromDataBaseOverDepartmentName(fdsv,
                                                                                     ref bErrorFound,
                                                                                     ref szErrorMessage);
                        if (bErrorFound)
                        {
                            utsx.ShowMessage(szErrorMessage,
                                                EnumsCollection.EnumMessageType.emtError);
                        }
                        else
                        {
                            utsx.ShowMessage("Department Removed Successfully",
                                             EnumsCollection.EnumMessageType.emtSuccess);
                        }
                    }

                    break;

                case DialogResult.No:

                    break;
            }        
        }

        void F_Departments_RecordNavigationTasks(string szvFormKey, 
                                                 EnumsCollection.EnumRecordNavigationTasks erntv)
        {
                                       Fields fds = null;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            while (true)
            {
                if (szvFormKey != this.Name)
                {
                    break;
                }

                fds = d_dsx.Fields;
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_PrepareFormForAdd(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntFindRecord:
                        XX_PrepareFormForFind(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        d_dsx.GetFirstRecordFromDataBase(ref fds,
                                                         ref bNothingFound,
                                                         ref bErrorFound,
                                                         ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddSubDepartmentsToDataGridView();
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }

                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord:
                        d_dsx.GetLastRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddSubDepartmentsToDataGridView();
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        d_dsx.GetNextRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddSubDepartmentsToDataGridView();
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        d_dsx.GetPreviousRecordFromDataBase(ref fds,
                                                            ref bNothingFound,
                                                            ref bErrorFound,
                                                            ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddSubDepartmentsToDataGridView();
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntRemoveRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        XX_RemoveStaffFromDataBase(szvFormKey,
                                                   fds);

                        XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                        break;
                }
                break;
            }
        }

        private void F_Departments_Load(object sender, EventArgs e)
        {
            XX_InitializeEvents();

            switch (efmx)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmUpdate);
                    XX_MoveFieldValuesToControls(fdsxUpdateFields);
                    XX_AddSubDepartmentsToDataGridView();
                    break;

                case EnumsCollection.EnumFormMode.efmOk:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                    XX_MoveFieldValuesToControls(fdsxUpdateFields);
                    break;

                case EnumsCollection.EnumFormMode.efmFind:
                    XX_PrepareFormForFind(this.Name);
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnNavigation_Click(object sender, EventArgs e)
        {
                                        Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "OK":
                    this.Hide();
                    break;

                case "Update":
                    XX_UpdateDepartmentInDataBase();
                    break;

                case "Add":
                    XX_AddDepartmentToDataBase();
                    break;

                case "Find":
                    XX_FindStaffrOverIdentificationNumber();
                    break;

            }
        }

        private void XX_AddSubDepartmentsToDataGridView()
        { 
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;
                                        bool bEndofFind = false;
                                        DataGridViewRow dgvRow = null;
                                        string szValue = string.Empty;

            while(true)
            {
                scsx.ClearDataGridView(dgvSubDepartments);
                fds = sd_dsx.Fields;
                fds.ItemIsField("DepartmentName").StringValue = txtDepartmentName.Text;

                sd_dsx.GetFirstRecordFromDataBase(ref fds,
                                                  ref bNothingFound,
                                                  ref bErrorFound,
                                                  ref szErrorMessage);
                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                if (bNothingFound)
                {
                    //f_wmx.AddMessageToMessagesdataGridView(EnumsCollection.EnumMessageType.emtInformation,
                    //                                       "No Record found for Cake Plan Item."); 
                    break;
                }

                while (true)
                {
                    if (bEndofFind)
                    {
                        break;
                    }

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                         EnumsCollection.EnumMessageType.emtError);
                        break;
                    }

                    dgvRow = (DataGridViewRow)dgvSubDepartments.Rows[0].Clone();

                    dgvRow.Cells[0].Value = fds.ItemIsField("SubDepartmentName").StringValue;

                    dgvSubDepartments.Rows.Add(dgvRow);

                    fds.ItemIsField("DepartmentName").StringValue = txtDepartmentName.Text;

                    sd_dsx.GetNextRecordFromDataBase(ref fds,
                                                     ref bEndofFind,
                                                     ref bErrorFound,
                                                     ref szErrorMessage);
                
                }

                break;
            }        
        }

        private void XX_AddSubDepartmentsToDataBase(long lvDepartmentId,
                                                    ref bool brErrorFound,
                                                    ref string szrErrorMessage)
        {
                                        bool bErrorFound = false;
                                        bool bRowHasEmptyCell = false;
                                        string szErrorMessage = string.Empty;
                                        DataGridViewRow dgvRow = null;
                                        Fields fds = null;
            
            for (int nRow = 0; nRow <= dgvSubDepartments.Rows.Count - 1; nRow++)
            {
                while (true)
                {
                    dgvRow = dgvSubDepartments.Rows[nRow];
                    if (dgvRow.IsNewRow)
                    {
                        break;
                    }

                    scsx.DataGridRowHasEmptyCell(dgvRow,
                                                 ref bRowHasEmptyCell);

                    if (bRowHasEmptyCell)
                    {
                        break;
                    }

                    fds = sd_dsx.Fields;
                    fds.ItemIsField("DepartmentName").StringValue = txtDepartmentName.Text;
                    fds.ItemIsField("DepartmentId").StringValue = Convert.ToString(lvDepartmentId);

                    scsx.MoveDataGridRowValuesToFields(dgvRow,
                                                       ref fds);

                    sd_dsx.AddToDataBase(fds,
                                         ref bErrorFound,
                                         ref szErrorMessage);

                    if (bErrorFound)
                    {
                        break;
                    }

                    break;
                }
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
                                        DataGridViewRow dgvRow = null;

            dgvRow = dgvSubDepartments.SelectedRows[0];

            if(dgvRow.IsNewRow == false)
            {
                dgvSubDepartments.Rows.RemoveAt(dgvSubDepartments.SelectedRows[0].Index);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
