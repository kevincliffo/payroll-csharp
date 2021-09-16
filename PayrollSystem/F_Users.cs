using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;

namespace PayRollSystem
{
    public partial class F_Users : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Users_DS u_dsx = null;
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        

        public F_Users(Form mdivForm,
                       DatabaseConnection dbcv,
                       Fields fdsvUpdateFields,
                       EnumsCollection.EnumFormMode efmv)
        {
            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            utsx = new Utilities.Utilities();
            u_dsx = new Users_DS(dbcx);
            mdixParent = mdivForm;
            

            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void XX_GetNextUserId(ref long lrUserId)
        {
                                        long lUserId = 0;

            u_dsx.GetNextHighestId(ref lUserId);

            lrUserId = lUserId;
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

        private void F_Users_Load(object sender, EventArgs e)
        {
                                        long lUserId = 0;

            XX_InitializeEvents();

            switch (efmx)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    txtUserId.Enabled = false;
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                    XX_GetNextUserId(ref lUserId);
                    txtUserId.Text = Convert.ToString(lUserId);
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    txtUserId.Enabled = false;
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmUpdate);
                    XX_MoveFieldValuesToControls(fdsxUpdateFields);
                    break;

                case EnumsCollection.EnumFormMode.efmFirstTimeUse:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmFirstTimeUse);
                    lUserId = 1;
                    cbUserType.SelectedIndex = 0;
                    cbUserType.Enabled = false;
                    txtUserId.Text = Convert.ToString(lUserId);
                    break;

                case EnumsCollection.EnumFormMode.efmOk:
                    XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                    XX_MoveFieldValuesToControls(fdsxUpdateFields);
                    break;

                case EnumsCollection.EnumFormMode.efmFind:
                    XX_PrepareFormForFind(this.Name);
                    break;
            }

            if (efmx != EnumsCollection.EnumFormMode.efmFind)
            {
                txtUserId.Enabled = false;
            }
        }

        void F_Users_MoveFieldValuesToControls(string szvFormKey, 
                                               Fields fdsv)
        {
            if (this.Name == szvFormKey)
            {
                XX_MoveFieldValuesToControls(fdsv);
            }
        }

        void gbGroupBox_Paint(object sender, PaintEventArgs e)
        {
                                        GroupBox box = sender as GroupBox;

            while(true)
            {
                //if (fusx == null)
                //{
                //    break;
                //}

                switch (box.Name)
                {
                    case "gbPersonalDetails":
                        //fusx.DrawGroupBox(box,
                        //                  e.Graphics,
                        //                  Color.Red,
                        //                  Color.Blue,
                        //                  this.BackColor);
                        break;

                    case "gbContactDetails":
                        //fusx.DrawGroupBox(box,
                        //                  e.Graphics,
                        //                  Color.Green,
                        //                  Color.Blue,
                        //                  this.BackColor);
                        break;

                    case "gbLoginDetails":
                        //fusx.DrawGroupBox(box,
                        //                  e.Graphics,
                        //                  Color.Violet,
                        //                  Color.Blue,
                        //                  this.BackColor);
                        break;
                }
                break;
            }
            
        }

        private void XX_InitializeEvents()
        {
            this.FormClosed += new FormClosedEventHandler(F_Users_FormClosed);

            if (efmx != EnumsCollection.EnumFormMode.efmFirstTimeUse)
            {
                ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_Users_RecordNavigationTasks);
            }

            gbContactDetails.Paint += new PaintEventHandler(gbGroupBox_Paint);
            gbPersonalDetails.Paint += new PaintEventHandler(gbGroupBox_Paint);
            gbLoginDetails.Paint += new PaintEventHandler(gbGroupBox_Paint);
        }

        void F_Users_RecordNavigationTasks(string szvFormKey, 
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

                fds = u_dsx.Fields;
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_PrepareFormForAdd(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntFindRecord:
                        XX_PrepareFormForFind(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        u_dsx.GetFirstRecordFromDataBase(ref fds,
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
                        u_dsx.GetLastRecordFromDataBase(ref fds,
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

                        u_dsx.GetNextRecordFromDataBase(ref fds,
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

                        u_dsx.GetPreviousRecordFromDataBase(ref fds,
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

                        XX_RemoveUserFromDataBase(szvFormKey,
                                                  fds);

                        XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                        break;
                }
                break;
            }

            if (erntv != EnumsCollection.EnumRecordNavigationTasks.erntFindRecord)
            {
                XX_EnableControls(true);
            }

        }

        private void XX_RemoveUserFromDataBase(string szvFormKey,
                                               Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove User" 
                            + System.Environment.NewLine
                            + txtUserId.Text
                            + " - "
                            + txtFirstName.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    u_dsx.RemoveFromDataBase(fdsv,
                                             ref bErrorFound,
                                             ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                            EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("User Removed Successfully",
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
                txtUserId.Enabled = true;
                txtUserId.Text = "0";

                XX_EnableControls(false);
            }
        }

        private void XX_PrepareFormForAdd(string szvFormKey)
        {
                                        long lUserId = 0;

            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                
                XX_GetNextUserId(ref lUserId);
                XX_RefereshControls();
                txtUserId.Text = Convert.ToString(lUserId);
            }
        }

        void F_Users_FormClosed(object sender, 
                                FormClosedEventArgs e)
        {
        }

        private void XX_DrawGroupBox(GroupBox box, 
                                     Graphics g, 
                                     Color textColor,
                                     Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void XX_MoveUserValuesToFields(ref Fields fdsr)
        {
            string szEncryptedPassword = string.Empty;

            fdsr.ItemIsField("UserId").StringValue = txtUserId.Text;
            fdsr.ItemIsField("UserName").StringValue = txtUserName.Text;

            utsx.Encrypt(txtPassword.Text,
                         ref szEncryptedPassword);
            fdsr.ItemIsField("Password").StringValue = szEncryptedPassword;
            fdsr.ItemIsField("UserType").StringValue = Convert.ToString(cbUserType.SelectedIndex);
            fdsr.ItemIsField("FirstName").StringValue = txtFirstName.Text;
            fdsr.ItemIsField("LastName").StringValue = txtLastName.Text;
            fdsr.ItemIsField("OtherName").StringValue = txtOtherName.Text;
            fdsr.ItemIsField("Email").StringValue = txtEmail.Text;
            fdsr.ItemIsField("MobileNo").StringValue = txtMobileNo.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void XX_AddUserToDataBase()
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szMessage = string.Empty;

            fds = u_dsx.Fields;
            XX_MoveUserValuesToFields(ref fds);

            while (true)
            {
                u_dsx.AddToDataBase(fds,
                                    ref bErrorFound,
                                    ref szErrorMessage);

                if (dbcx.ApplicationPathCarrier.FirstTimeLaunch)
                {
                    szMessage = "Welcome "
                              + fds.ItemIsField("FirstName").StringValue
                              + " "
                              + " (" + fds.ItemIsField("UserName").StringValue + ")"
                              + " the application will now shut down and you will be required to login with the created credentials, good day!";
                    MessageBox.Show(szMessage,
                                    "First Time Launch!");

                    this.Close();
                    Application.Exit();
                }

                if (!bErrorFound)
                {
                    utsx.ShowMessage("User Added successfully",
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

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
                                        string szPassword = string.Empty;

            this.Text = "User"
                      + " - "
                      + fdsv.ItemIsField("UserId").StringValue
                      + " - "
                      + fdsv.ItemIsField("FirstName").StringValue
                      + " - "
                      + fdsv.ItemIsField("LastName").StringValue
                      + " "
                      + fdsv.ItemIsField("OtherName").StringValue;

            txtUserId.Text = fdsv.ItemIsField("UserId").StringValue;
            txtFirstName.Text = fdsv.ItemIsField("FirstName").StringValue;
            txtLastName.Text = fdsv.ItemIsField("LastName").StringValue;
            txtOtherName.Text = fdsv.ItemIsField("OtherName").StringValue;
            txtEmail.Text = fdsv.ItemIsField("Email").StringValue;
            txtMobileNo.Text = fdsv.ItemIsField("MobileNo").StringValue;

            txtUserName.Text = fdsv.ItemIsField("UserName").StringValue;
            utsx.Decrypt(fdsv.ItemIsField("Password").StringValue,
                         ref szPassword);
            txtPassword.Text = szPassword;
            cbUserType.SelectedIndex = Convert.ToInt32(fdsv.ItemIsField("UserType").StringValue);
        }

        private void XX_UpdateUserInDataBase()
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            XX_MoveUserValuesToFields(ref fdsxUpdateFields);

            u_dsx.UpdateDataInDataBase(fdsxUpdateFields,
                                       ref bErrorFound,
                                       ref szErrorMessage);
            if (!bErrorFound)
            {
                utsx.ShowMessage("User Updated successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);

                XX_RefereshControls();
            }
            else 
            {
                utsx.ShowMessage(szErrorMessage,
                                EnumsCollection.EnumMessageType.emtError);
            }
        }

        private void XX_FindUserOverUserId()
        {
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szErrorMessage = string.Empty;
                                        Fields fds = null;

            u_dsx.GetUserOverUserId(Convert.ToInt64(txtUserId.Text),
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

                XX_EnableControls(true);
                XX_MoveFieldValuesToControls(fds);
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmOk);
                break;
            }
        }

        private void XX_EnableControls(bool bvEnableControls)
        {
            txtUserId.Enabled = !bvEnableControls;
            txtUserName.Enabled = bvEnableControls;
            txtFirstName.Enabled = bvEnableControls;
            txtLastName.Enabled = bvEnableControls;
            txtOtherName.Enabled = bvEnableControls;
            txtEmail.Enabled = bvEnableControls;
            txtMobileNo.Enabled = bvEnableControls;
            txtPassword.Enabled = bvEnableControls;
            cbUserType.Enabled = bvEnableControls;
        }

        private void XX_RefereshControls() 
        {
                                        long lId = 0;

            u_dsx.GetNextHighestId(ref lId);
            txtUserId.Text = Convert.ToString(lId);
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtOtherName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbUserType.SelectedIndex = 0;
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
                    XX_UpdateUserInDataBase();
                    break;

                case "Add":
                    XX_AddUserToDataBase();
                    break;

                case "Find":
                    XX_FindUserOverUserId();
                    break;

            }
        }

        private void gbLoginDetails_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
