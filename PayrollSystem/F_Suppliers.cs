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
    public partial class F_Suppliers : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;

        private Utilities.Utilities utsx = null;
        private SharedComponents scx = null;
        private Suppliers_DS ss_dsx = null;

        public F_Suppliers(Form mdivForm,
                           DatabaseConnection dbcv,

                           Fields fdsvUpdateFields,
                           EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            mdixParent = mdivForm;

            ss_dsx = new Suppliers_DS(dbcx);
            utsx = new Utilities.Utilities();
            scx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void F_Suppliers_Load(object sender, EventArgs e)
        {
            XX_InitializeEvents();
            string szCode = string.Empty;

            string szKey = utsx.Right("txtName", 3);

            ss_dsx.GetNextSupplierCode(ref szCode);
            txtSupplierCode.Text = szCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                                        Fields fds = null;
                                        bool bEmptyControlFound = false;
                                        string szControlDescription = string.Empty;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            scx.CheckIfEditableControlValuesAreValid(gbHeader.Controls,
                                                     ref bEmptyControlFound,
                                                     ref szControlDescription);

            while (true)
            {
                if (bEmptyControlFound)
                {
                    utsx.ShowMessage(szControlDescription,
                                     "Empty Value",
                                      EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                scx.CheckIfEditableControlValuesAreValid(gbDetails.Controls,
                                                         ref bEmptyControlFound,
                                                         ref szControlDescription);

                if (bEmptyControlFound)
                {
                    utsx.ShowMessage(szControlDescription,
                                     "Empty Value",
                                      EnumsCollection.EnumMessageType.emtError);
                    break;
                }
                fds = ss_dsx.Fields;

                XX_MoveControlValuesToFields(ref fds);


                ss_dsx.AddToDataBase(fds,
                                     ref bErrorFound,
                                     ref szErrorMessage);

                if(bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                }
                else
                {
                    utsx.ShowMessage("Supplier Added Successfully",
                                     EnumsCollection.EnumMessageType.emtSuccess);
                    XX_RefereshControls();
                }
                break;
            }
        }

        private void XX_InitializeEvents()
        {
            //((F_Main)mdixParent).RecordNavigationTasks += F_Suppliers_RecordNavigationTasks;
            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_Suppliers_RecordNavigationTasks);
        }

        private void F_Suppliers_RecordNavigationTasks(string szvFormKey, 
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

                fds = ss_dsx.Fields;
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_PrepareFormForAdd(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntFindRecord:
                        XX_PrepareFormForFind(szvFormKey);
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        ss_dsx.GetFirstRecordFromDataBase(ref fds,
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
                        ss_dsx.GetLastRecordFromDataBase(ref fds,
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
                        XX_MoveControlValuesToFields(ref fds);

                        ss_dsx.GetNextRecordFromDataBase(ref fds,
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
                        XX_MoveControlValuesToFields(ref fds);

                        ss_dsx.GetPreviousRecordFromDataBase(ref fds,
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
                        XX_MoveControlValuesToFields(ref fds);

                        XX_RemoveSupplierFromDataBase(szvFormKey,
                                                      fds);
                        break;
                }
                break;
            }
        }

        private void XX_RemoveSupplierFromDataBase(string szvFormKey,
                                                   Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Supplier" 
                            + System.Environment.NewLine
                            + txtSupplierName.Text
                            + " - "
                            + txtSupplierCode.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    ss_dsx.RemoveFromDataBase(fdsv,
                                              ref bErrorFound,
                                              ref szErrorMessage);
                    
                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                            EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("Supplier Removed Successfully",
                                         EnumsCollection.EnumMessageType.emtSuccess);

                        XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);
                    }

                    break;

                case DialogResult.No:

                    break;
            }        
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
            txtSupplierCode.Text = fdsv.ItemIsField("SupplierCode").StringValue;
            txtSupplierName.Text = fdsv.ItemIsField("SupplierName").StringValue;
            txtMobileNumber.Text = fdsv.ItemIsField("MobileNumber").StringValue;
            txtEmail.Text = fdsv.ItemIsField("Email").StringValue;
            txtAddress.Text = fdsv.ItemIsField("Address").StringValue;
            txtTown.Text = fdsv.ItemIsField("Town").StringValue;
            txtCity.Text = fdsv.ItemIsField("City").StringValue;
            txtCountry.Text = fdsv.ItemIsField("Country").StringValue;
        }

        private void XX_PrepareFormForFind(string szvFormKey)
        {
            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmFind);
                XX_RefereshControls();
            }
        }

        private void XX_MoveControlValuesToFields(ref Fields fdsr)
        {

            scx.MoveControlValuesToFields(gbHeader.Controls,
                                          ref fdsr);

            scx.MoveControlValuesToFields(gbDetails.Controls,
                                          ref fdsr);
        }

        private void XX_PrepareFormForAdd(string szvFormKey)
        {
            if (this.Name == szvFormKey)
            {
                XX_ChangeFormMode(EnumsCollection.EnumFormMode.efmAdd);

                XX_RefereshControls();
            }
        }

        private void XX_ChangeFormMode(EnumsCollection.EnumFormMode efmv)
        {
            efmx = efmv;
            switch (efmv)
            {
                case EnumsCollection.EnumFormMode.efmAdd:
                    btnNavigation.Text = "Add";
                    btnRemove.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmUpdate:
                    btnNavigation.Text = "Update";
                    btnRemove.Visible = true;
                    break;

                case EnumsCollection.EnumFormMode.efmFirstTimeUse:
                    btnNavigation.Text = "Add";
                    btnRemove.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmOk:
                    btnNavigation.Text = "Ok";
                    btnRemove.Visible = false;
                    break;

                case EnumsCollection.EnumFormMode.efmFind:
                    btnRemove.Visible = false;
                    btnNavigation.Text = "Find";
                    break;
            }
        }

        private void XX_RefereshControls()
        {
            txtSupplierCode.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtMobileNumber.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtTown.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Fields fds = ss_dsx.Fields;

            XX_MoveControlValuesToFields(ref fds);

            XX_RemoveSupplierFromDataBase(this.Name,
                                          fds);
        }
    }
}
