using System;
using System.Collections;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;

namespace PayRollSystem
{
    public partial class F_Attendance : Form
    {
        private Form mdixParent = null;
        private DatabaseConnection dbcx = null;
        private Attendance_DS a_dsx = null;
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Staffs_DS s_dsx = null;
        

        public F_Attendance(Form mdivForm,
                            DatabaseConnection dbcv,
                            Fields fdsvUpdateFields,
                            EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();
            mdixParent = mdivForm;
            dbcx = dbcv;
            a_dsx = new Attendance_DS(dbcx);
            s_dsx = new Staffs_DS(dbcx);
            utsx = new Utilities.Utilities();
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void XX_ChangeFormMode(EnumsCollection.EnumFormMode efmv)
        {
            
            switch (efmv)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    break;

                case EnumsCollection.EnumFormMode.efmFirstTimeUse:
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    break;
            }
        }

        private void XX_AddUpdateValuesToControlsIf(Fields fdsv) 
        { 
                                        bool bValidUser = false;

            while(true)
            {
                bValidUser = dbcx.EnumUserType == EnumsCollection.EnumUserType.eutAdministrator;

                if (!bValidUser) 
                {
                    utsx.ShowMessage("User does not have permissions to perofrm this task",
                                     "Permissions", 
                                     EnumsCollection.EnumMessageType.emtError);
                                    
                    break;
                }

                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmUpdate);
                XX_MoveFieldValuesToControls(fdsv);

                break;
            }
        }

        private void XX_InitializeEvents()
        {
            this.FormClosed += new FormClosedEventHandler(F_Attendance_FormClosed);
            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_Attendance_RecordNavigationTasks);

            gbAttendanceDetails.Paint += new PaintEventHandler(gbGroupBox_Paint);
        }

        void gbGroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;

            switch (box.Name)
            {
                case "gbAttendanceDetails":
                    //fusx.DrawGroupBox(box,
                    //                  e.Graphics,
                    //                  Color.Red,
                    //                  Color.Blue,
                    //                  this.BackColor);
                    break;
            }
        }

        void F_Attendance_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        void F_Attendance_RecordNavigationTasks(string szvFormKey,
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

                fds = a_dsx.Fields;
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_PrepareFormForAdd(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntFindRecord:
                        XX_PrepareFormForFind(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        a_dsx.GetFirstRecordFromDataBase(ref fds,
                                                         ref bNothingFound,
                                                         ref bErrorFound,
                                                         ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord:
                        a_dsx.GetLastRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        a_dsx.GetNextRecordFromDataBase(ref fds,
                                                        ref bNothingFound,
                                                        ref bErrorFound,
                                                        ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        a_dsx.GetPreviousRecordFromDataBase(ref fds,
                                                            ref bNothingFound,
                                                            ref bErrorFound,
                                                            ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntRemoveRecord:
                        XX_MoveUserValuesToFields(ref fds);

                        XX_RemoveAttendanceFromDataBase(szvFormKey,
                                                        fds);
                        break;
                }
                break;
            }
        }


        private void XX_RemoveAttendanceFromDataBase(string szvFormKey,
                                                     Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Attendance" 
                            + System.Environment.NewLine
                            + txtAttendanceId.Text
                            + " - "
                            + cbEmployeeId.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    a_dsx.RemoveFromDataBase(fdsv,
                                             ref bErrorFound,
                                             ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                            EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("Employee Removed Successfully",
                                         EnumsCollection.EnumMessageType.emtSuccess);                    
                    }

                    break;

                case DialogResult.No:

                    break;
            }        
        }

        private void XX_PrepareFormForFind(string szvFormKey)
        {

            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmFind);
                XX_RefereshControls();
                txtAttendanceId.Enabled = true;
                txtAttendanceId.Text = "0";

            }
        }

        private void XX_PrepareFormForAdd(string szvFormKey)
        {
                                        long lAttendanceId = 0;

            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);

                a_dsx.GetNextHighestId(ref lAttendanceId);
                XX_RefereshControls();
                txtAttendanceId.Text = Convert.ToString(lAttendanceId);
            }
        }

        private void F_Attendance_Load(object sender, EventArgs e)
        {
                                       long lPaymentId = 0;
                                        ArrayList collIds = null;

            XX_InitializeEvents();
            s_dsx.GetCollectionOfStaffId(ref collIds);

            foreach (string szId in collIds)
            {
                cbEmployeeId.Items.Add(szId);
            }

            cbEmployeeId.SelectedIndex = 0;
            cbAttendanceType.SelectedIndex = 0;
            cbHours.SelectedIndex = 2;
            switch (efmx)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                    a_dsx.GetNextHighestId(ref lPaymentId);
                    txtAttendanceId.Text = Convert.ToString(lPaymentId);
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    XX_AddUpdateValuesToControlsIf(fdsxUpdateFields);
                    break;

                case EnumsCollection.EnumFormMode.efmFirstTimeUse:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmFirstTimeUse);
                    txtAttendanceId.Text = Convert.ToString(lPaymentId);
                    break;
            }

            txtAttendanceId.Enabled = false;
            cbEmployeeId.SelectedValueChanged += new EventHandler(cbEmployeeId_SelectedValueChanged);

        }

        void cbEmployeeId_SelectedValueChanged(object sender, EventArgs e)
        {
        
        }

        void F_Attendance_MoveFieldValuesToControls(string szvFormKey, 
                                                      Fields fdsv)
        {
            if (this.Name == szvFormKey)
            {
                XX_MoveFieldValuesToControls(fdsv);
            }
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
                                        string szDateString = string.Empty;
                                        DateTime dtDate = new DateTime();
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            txtAttendanceId.Text = fdsv.ItemIsField("AttendanceId").StringValue;
            cbEmployeeId.Text = fdsv.ItemIsField("EmployeeId").StringValue;

            szDateString = fdsv.ItemIsField("Date").StringValue;
            utsx.GetDateValueOverStringDate(szDateString,
                                            ref dtDate,
                                            ref bErrorFound,
                                            ref szErrorMessage);

            dtpDate.Value = dtDate;
            cbHours.Text = fdsv.ItemIsField("Hours").StringValue;

            switch (fdsv.ItemIsField("AttendanceType").StringValue)
            { 
                case "0":
                    cbAttendanceType.Text = "Extra";
                    break;

                case "1":
                    cbAttendanceType.Text = "Absent";
                    break;
            }
            
        }

         private void btnAdd_Click(object sender, EventArgs e)
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            fds = a_dsx.Fields;

            XX_MoveUserValuesToFields(ref fds);

            a_dsx.AddToDataBase(fds,
                                 ref bErrorFound,
                                 ref szErrorMessage);

            if (!bErrorFound)
            {
                utsx.ShowMessage("Attendance Added successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);

                XX_RefereshControls();
            }
            else
            {
                utsx.ShowMessage(szErrorMessage,
                                EnumsCollection.EnumMessageType.emtError);
            }
            
        }

        private void XX_RefereshControls()
        {
                                        long lId = 0;
            
            a_dsx.GetNextHighestId(ref lId);

            txtAttendanceId.Text = Convert.ToString(lId);

            dtpDate.Value = DateTime.Today;
            cbEmployeeId.SelectedIndex = 0;    
        }

        private void XX_MoveUserValuesToFields(ref Fields fdsr)
        {
                                        string szDateString = string.Empty;
                                        string szTime = string.Empty;

            fdsr.ItemIsField("AttendanceId").StringValue = txtAttendanceId.Text;
            fdsr.ItemIsField("EmployeeId").StringValue = cbEmployeeId.Text;

            utsx.GetDateStringValueOverDate(dtpDate.Value,
                                            ref szDateString,
                                            ref szTime);

            fdsr.ItemIsField("Date").StringValue = szDateString;
            fdsr.ItemIsField("Hours").StringValue = cbHours.Text;

            switch (cbAttendanceType.Text)
            { 
                case "Extra":
                    fdsr.ItemIsField("AttendanceType").StringValue = "1";
                    break;

                case "Absent":
                    fdsr.ItemIsField("AttendanceType").StringValue = "2";
                    break;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            fds = a_dsx.Fields;
            XX_MoveUserValuesToFields(ref fds);

            a_dsx.UpdateDataInDataBase(fds,
                                        ref bErrorFound,
                                        ref szErrorMessage);
            if (!bErrorFound)
            {
                utsx.ShowMessage("Attendance Updated successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);

                XX_RefereshControls();
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
            }
            else 
            {
                utsx.ShowMessage(szErrorMessage,
                                EnumsCollection.EnumMessageType.emtError);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
