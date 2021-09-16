using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using Models;

namespace PayRollSystem
{
    public partial class F_StaffMaster : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Staffs_DS s_dsx = null;
        private Departments_DS d_dsx = null;
        private SubDepartments_DS sd_dsx = null;
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private SharedComponents scx = null;

        public F_StaffMaster(Form mdivForm,
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
            

            s_dsx = new Staffs_DS(dbcx);
            d_dsx = new Departments_DS(dbcx);
            sd_dsx = new SubDepartments_DS(dbcx);
            scx = new SharedComponents(dbcx);

            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void XX_AddDepartmentsToComboBox()
        { 
                                        ArrayList collDepartments = new ArrayList();
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szErrorMessage = string.Empty;

            while(true)
            {
                fds = d_dsx.Fields;
                d_dsx.GetFirstRecordFromDataBase(ref fds,
                                                 ref bNothingFound,
                                                 ref bErrorFound,
                                                 ref szErrorMessage);

                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    collDepartments.Add(fds.ItemIsField("DepartmentName").StringValue);
                    d_dsx.GetNextRecordFromDataBase(ref fds,
                                                    ref bNothingFound,
                                                    ref bErrorFound,
                                                    ref szErrorMessage);
                }
                break;
            }

            cbDepartments.Items.Clear();
            foreach (string szDepartment in collDepartments)
            {
                cbDepartments.Items.Add(szDepartment);
            }

            if (collDepartments.Count > 0)
            {
                cbDepartments.SelectedIndex = 0;
            }
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

        private void XX_InitializeEvents()
        {
            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_StaffMaster_RecordNavigationTasks);
            cbDepartments.SelectedIndexChanged += new EventHandler(cbDepartments_SelectedIndexChanged);
        }

        void cbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
                                        ComboBox cb = (ComboBox)sender;

            switch(cb.Name)
            {
                case "cbDepartments":
                    XX_AddSubDepartmentsToComboBoxOverDepartmentName(cb.Text);

                    break;
            }
        }

        private void XX_AddSubDepartmentsToComboBoxOverDepartmentName(string szvDepartmentName)
        {
                                        ArrayList collSubDepartments = new ArrayList();
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szErrorMessage = string.Empty;

            while(true)
            {
                fds = sd_dsx.Fields;
                fds.ItemIsField("DepartmentName").StringValue = szvDepartmentName;
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

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    collSubDepartments.Add(fds.ItemIsField("SubDepartmentName").StringValue);

                    fds.ItemIsField("DepartmentName").StringValue = szvDepartmentName;
                    sd_dsx.GetNextRecordFromDataBase(ref fds,
                                                     ref bNothingFound,
                                                     ref bErrorFound,
                                                     ref szErrorMessage);
                }
                break;
            }

            cbSubDepartments.Items.Clear();
            foreach (string szSubDepartment in collSubDepartments)
            {
                cbSubDepartments.Items.Add(szSubDepartment);
            }

            if (collSubDepartments.Count > 0)
            {
                cbSubDepartments.SelectedIndex = 0;
            }        
        }

        private void XX_RefereshControls() 
        {
            txtSurname.Text = string.Empty;
            txtOtherNames.Text = string.Empty;
            txtStaffNumber.Text = string.Empty;
            dtpEmploymentDate.Value = DateTime.Now;
            txtIdentificationNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            mtxtMobileNumber.Text = string.Empty;
            cbDepartments.Text = string.Empty;
            cbSubDepartments.Text = string.Empty;
            cbEmployeeType.SelectedIndex = 0;
            txtNSSFNumber.Text = string.Empty;
            txtNHIFNumber.Text = string.Empty;
            txtKRAPin.Text = string.Empty;
            txtBasicSalary.Text = "0.00";
            txtHouseAllowance.Text = "0.00";
            txtMedicalAllowance.Text = "0.00";
            txtTravelAllowance.Text = "0.00";
            txtPension.Text = "0.00";
            txtNextofKinEmail.Text = string.Empty;
            txtNextofKinMobileNumber.Text = string.Empty;
            txtNextofKinName.Text = string.Empty;
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
                                        DateTime dtEmploymentDate = new DateTime();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            this.Text = "Staff"
                      + " - "
                      + fdsv.ItemIsField("Surname").StringValue;

            txtSurname.Text = fdsv.ItemIsField("Surname").StringValue;
            txtOtherNames.Text = fdsv.ItemIsField("OtherNames").StringValue;
            txtStaffNumber.Text = fdsv.ItemIsField("StaffId").StringValue;

            utsx.GetDateValueOverStringDate(fdsv.ItemIsField("EmploymentDate").StringValue,
                                            ref dtEmploymentDate,
                                            ref bErrorFound,
                                            ref szErrorMessage);

            dtpEmploymentDate.Value = dtEmploymentDate;
            txtIdentificationNumber.Text = fdsv.ItemIsField("IdentificationNumber").StringValue;
            txtAddress.Text = fdsv.ItemIsField("Address").StringValue;
            txtEmailAddress.Text = fdsv.ItemIsField("EmailAddress").StringValue;
            mtxtMobileNumber.Text = fdsv.ItemIsField("MobileNo").StringValue;
            cbDepartments.Text = fdsv.ItemIsField("Department").StringValue;
            cbSubDepartments.Text = fdsv.ItemIsField("SubDepartment").StringValue;
            cbEmployeeType.Text = fdsv.ItemIsField("EmployeeType").StringValue;
            txtNSSFNumber.Text = fdsv.ItemIsField("NSSFNumber").StringValue;
            txtNHIFNumber.Text = fdsv.ItemIsField("NHIFNumber").StringValue;
            txtKRAPin.Text = fdsv.ItemIsField("KRAPin").StringValue;
            txtBasicSalary.Text = fdsv.ItemIsField("BasicSalary").StringValue;
            txtNextofKinEmail.Text = fdsv.ItemIsField("NextOfKinEmail").StringValue;
            txtNextofKinMobileNumber.Text = fdsv.ItemIsField("NextOfKinMobileNumber").StringValue;
            txtNextofKinName.Text = fdsv.ItemIsField("NextOfKinName").StringValue;
            txtHouseAllowance.Text = fdsv.ItemIsField("HouseAllowance").StringValue;
            txtMedicalAllowance.Text = fdsv.ItemIsField("MedicalAllowance").StringValue;
            txtTravelAllowance.Text = fdsv.ItemIsField("TravelAllowance").StringValue;
            txtPension.Text = fdsv.ItemIsField("Pension").StringValue;
        }

        private void XX_MoveUserValuesToFields(ref Fields fdsr)
        {
                                        string szDateString = string.Empty;
                                        string szTime = string.Empty;

            fdsr.ItemIsField("Surname").StringValue = txtSurname.Text;
            fdsr.ItemIsField("OtherNames").StringValue = txtOtherNames.Text;
            fdsr.ItemIsField("StaffId").StringValue = txtStaffNumber.Text;

            utsx.GetDateStringValueOverDate(dtpEmploymentDate.Value,
                                            ref szDateString,
                                            ref szTime);

            fdsr.ItemIsField("EmploymentDate").StringValue = szDateString;
            fdsr.ItemIsField("IdentificationNumber").StringValue = txtIdentificationNumber.Text;
            fdsr.ItemIsField("Address").StringValue = txtAddress.Text;
            fdsr.ItemIsField("EmailAddress").StringValue = txtEmailAddress.Text;
            fdsr.ItemIsField("MobileNo").StringValue = mtxtMobileNumber.Text;
            fdsr.ItemIsField("Department").StringValue = cbDepartments.Text;
            fdsr.ItemIsField("SubDepartment").StringValue = cbSubDepartments.Text;
            fdsr.ItemIsField("EmployeeType").StringValue = cbEmployeeType.Text;
            fdsr.ItemIsField("NSSFNumber").StringValue = txtNSSFNumber.Text;
            fdsr.ItemIsField("NHIFNumber").StringValue = txtNHIFNumber.Text;
            fdsr.ItemIsField("KRAPin").StringValue = txtKRAPin.Text;
            fdsr.ItemIsField("BasicSalary").StringValue = txtBasicSalary.Text;
            fdsr.ItemIsField("NextOfKinEmail").StringValue = txtNextofKinEmail.Text;
            fdsr.ItemIsField("NextOfKinMobileNumber").StringValue = txtNextofKinMobileNumber.Text;
            fdsr.ItemIsField("NextOfKinName").StringValue = txtNextofKinName.Text;
            fdsr.ItemIsField("HouseAllowance").StringValue = txtHouseAllowance.Text;
            fdsr.ItemIsField("MedicalAllowance").StringValue = txtMedicalAllowance.Text;
            fdsr.ItemIsField("TravelAllowance").StringValue = txtTravelAllowance.Text;
            fdsr.ItemIsField("Pension").StringValue = txtPension.Text;
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

        void F_StaffMaster_RecordNavigationTasks(string szvFormKey, EnumsCollection.EnumRecordNavigationTasks erntv)
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

                fds = s_dsx.Fields;
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_PrepareFormForAdd(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntFindRecord:
                        XX_PrepareFormForFind(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        s_dsx.GetFirstRecordFromDataBase(ref fds,
                                                         ref bNothingFound,
                                                         ref bErrorFound,
                                                         ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }

                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord:
                        s_dsx.GetLastRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        s_dsx.GetNextRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        s_dsx.GetPreviousRecordFromDataBase(ref fds,
                                                            ref bNothingFound,
                                                            ref bErrorFound,
                                                            ref szErrorMessage);

                        if (!bErrorFound && !bNothingFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
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

        private void XX_RemoveStaffFromDataBase(string szvFormKey,
                                                Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Staff" 
                            + System.Environment.NewLine
                            + txtSurname.Text
                            + " - "
                            + txtIdentificationNumber.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    s_dsx.RemoveFromDataBase(fdsv,
                                             ref bErrorFound,
                                             ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                            EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("Staff Removed Successfully",
                                         EnumsCollection.EnumMessageType.emtSuccess);                    
                    }

                    break;

                case DialogResult.No:

                    break;
            }        
        }
        private void F_StaffMaster_Load(object sender, EventArgs e)
        {

            XX_InitializeEvents();
            XX_AddDepartmentsToComboBox();
            cbEmployeeType.SelectedIndex = 0;
            switch (efmx)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmUpdate);
                    XX_MoveFieldValuesToControls(fdsxUpdateFields);
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

        private void XX_AddStaffToDataBase()
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        bool bEmptyTextBoxFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szMessage = string.Empty;
                                        string szControlDescription = string.Empty;

            fds = s_dsx.Fields;
            
            while (true)
            {
                scx.CheckIfEditableControlValuesAreValid(gbHeader.Controls,
                                                         ref bEmptyTextBoxFound,
                                                         ref szControlDescription);

                if (bEmptyTextBoxFound)
                {
                    utsx.ShowMessage("Enter Value for '" + szControlDescription + "' Field",
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                scx.CheckIfEditableControlValuesAreValid(gbAdditionalDetails.Controls,
                                                         ref bEmptyTextBoxFound,
                                                         ref szControlDescription);

                if (bEmptyTextBoxFound)
                {
                    utsx.ShowMessage("Enter Value for '" + szControlDescription + "' Field",
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                XX_MoveUserValuesToFields(ref fds);
                s_dsx.AddToDataBase(fds,
                                    ref bErrorFound,
                                    ref szErrorMessage);

                if (!bErrorFound)
                {
                    utsx.ShowMessage("Staff Added successfully",
                                     EnumsCollection.EnumMessageType.emtSuccess);

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

        private void XX_UpdateStaffInDataBase()
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            XX_MoveUserValuesToFields(ref fdsxUpdateFields);

            s_dsx.UpdateDataInDataBase(fdsxUpdateFields,
                                       ref bErrorFound,
                                       ref szErrorMessage);
            if (!bErrorFound)
            {
                utsx.ShowMessage("Staff Updated successfully",
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

            s_dsx.GetStaffOverStaffId(Convert.ToInt32(txtIdentificationNumber.Text),
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

        private void btnNavigation_Click(object sender, EventArgs e)
        {
                                        Button btn = (Button)sender;

            switch (btn.Text)
            {
                case "OK":
                    this.Hide();
                    break;

                case "Update":
                    XX_UpdateStaffInDataBase();
                    break;

                case "Add":
                    XX_AddStaffToDataBase();
                    break;

                case "Find":
                    XX_FindStaffrOverIdentificationNumber();
                    break;

            }
        }
    }
}
