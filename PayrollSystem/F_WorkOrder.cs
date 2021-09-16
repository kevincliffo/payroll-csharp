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
    public partial class F_WorkOrder : Form
    {
        private Staffs_DS s_dsx = null;
        private WorkOrders_DS wo_dsx = null;
        private WorkOrderTemplateMaterials_DS wotm_dsx = null;
        private WorkOrderTemplateWorks_DS wotw_dsx = null;
        private WorkOrderMaterials_DS wom_dsx = null;
        private WorkOrderWorks_DS wow_dsx = null;
        private WorkOrderEmployeeWorkDatas_DS woewd_dsx = null;
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private SharedComponents scsx = null;
        private const string szxEMPTY = "";

        public F_WorkOrder(Form mdivForm,
                           DatabaseConnection dbcv,
                           
                           Fields fdsvUpdateFields,
                           EnumsCollection.EnumFormMode efmv)
        {
            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            
            scsx = new SharedComponents(dbcx);
            s_dsx = new Staffs_DS(dbcx);
            wo_dsx = new WorkOrders_DS(dbcx);
            wotm_dsx = new WorkOrderTemplateMaterials_DS(dbcx);
            wotw_dsx = new WorkOrderTemplateWorks_DS(dbcx);
            wom_dsx = new WorkOrderMaterials_DS(dbcx);
            wow_dsx = new WorkOrderWorks_DS(dbcx);
            woewd_dsx = new WorkOrderEmployeeWorkDatas_DS(dbcx);

            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
            
        }

        public void InitializeWorkOrderHeaderDetails(string szvTemplateName,
                                                     string szvTemplateDescription,
                                                     string szvTemplateNumber)
        {
            txtWorkOrderTemplateName.Text = szvTemplateName;
            txtWorkOrderTemplateDescription.Text = szvTemplateDescription;
            txtWorkOrderTemplateNumber.Text = szvTemplateNumber;
        }

        private void XX_GetNextWorkOrderNumber(ref long lrWorkOrderNumber)
        {
            wo_dsx.GetNextHighestWorkOrderNumber(ref lrWorkOrderNumber);
        }

        private void F_WorkOrder_Load(object sender, EventArgs e)
        {            
                                        long lWorkOrderNumber = 0;

            XX_InitializeEmployeeIdComboBoxInEmployeeWorkDataDataGrid();
            XX_GetNextWorkOrderNumber(ref lWorkOrderNumber);
            txtWorkOrderNumber.Text = Convert.ToString(lWorkOrderNumber);
            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_WorkOrder_RecordNavigationTasks);
        }

        private void XX_InitializeForm()
        {
            txtWorkOrderNumber.Text = szxEMPTY;
            txtWorkOrderTemplateName.Text = szxEMPTY;
            txtWorkOrderTemplateNumber.Text = szxEMPTY;
            txtWorkOrderTemplateDescription.Text = szxEMPTY;
            txtQuantity.Text = szxEMPTY;
        }

        private void XX_ClearGrids()
        {
            dgvWorkOrderMaterials.Rows.Clear();
            dgvWorkOrderMaterials.Refresh();
            dgvWorkOrderWorks.Rows.Clear();
            dgvWorkOrderWorks.Refresh();
        }

        private void XX_MoveValuesToFields(ref Fields fdsr)
        {
            fdsr.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;
            fdsr.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
            fdsr.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;
            fdsr.ItemIsField("WorkOrderTemplateDescription").StringValue = txtWorkOrderTemplateDescription.Text;
            fdsr.ItemIsField("Quantity").StringValue = txtQuantity.Text;
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
            txtWorkOrderNumber.Text = fdsv.ItemIsField("WorkOrderNumber").StringValue;
            txtWorkOrderTemplateName.Text = fdsv.ItemIsField("WorkOrderTemplateName").StringValue;
            txtWorkOrderTemplateNumber.Text = fdsv.ItemIsField("WorkOrderTemplateNumber").StringValue;
            txtWorkOrderTemplateDescription.Text = fdsv.ItemIsField("WorkOrderTemplateDescription").StringValue;
            txtQuantity.Text = fdsv.ItemIsField("Quantity").StringValue;
        }

        void F_WorkOrder_RecordNavigationTasks(string szvFormKey, 
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

                fds = wo_dsx.Fields;
                
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_InitializeForm();
                        XX_ClearGrids();
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        wo_dsx.GetFirstRecordFromDataBase(ref fds,
                                                          ref bNothingFound,
                                                          ref bErrorFound,
                                                          ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderMaterialsToDataGridView();
                            XX_AddWorkOrderWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord:
                        wo_dsx.GetLastRecordFromDataBase(ref fds,
                                                         ref bNothingFound,
                                                         ref bErrorFound,
                                                         ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderMaterialsToDataGridView();
                            XX_AddWorkOrderWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord:
                        XX_MoveValuesToFields(ref fds);

                        wo_dsx.GetNextRecordFromDataBase(ref fds,
                                                         ref bNothingFound,
                                                         ref bErrorFound,
                                                         ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderMaterialsToDataGridView();
                            XX_AddWorkOrderWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord:
                        XX_MoveValuesToFields(ref fds);

                        wo_dsx.GetPreviousRecordFromDataBase(ref fds,
                                                             ref bNothingFound,
                                                             ref bErrorFound,
                                                             ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderMaterialsToDataGridView();
                            XX_AddWorkOrderWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntRemoveRecord:
                        XX_MoveValuesToFields(ref fds);
                        XX_RemoveWorkOrderFromDataBase(szvFormKey,
                                                               fds);

                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;

                        break;
                }
                break;
            }
        }

        private void XX_RemoveWorkOrderFromDataBase(string szvFormKey,
                                                            Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Work Order" 
                            + System.Environment.NewLine
                            + txtWorkOrderNumber.Text
                            + "-"
                            + txtWorkOrderTemplateName.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    wo_dsx.RemoveFromDataBase(fdsv,
                                              ref bErrorFound,
                                              ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                         EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("Work Order Removed Successfully",
                                         EnumsCollection.EnumMessageType.emtSuccess);

                        XX_InitializeForm();
                        XX_ClearGrids();
                    }

                    break;

                case DialogResult.No:
                    utsx.ShowMessage("Operation Canceled",
                                     EnumsCollection.EnumMessageType.emtSuccess);
                    break;
            }        
        }

        private void XX_InitializeWorkNameInEmployeeWorkDataDataGrid()
        { 
                                        Fields fds = null;
                                        string szErrorMessage = string.Empty;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
                                        //dgvEmployeeWorkData.Rows.Add(1);
                                        DataGridViewRow dgvRow = dgvEmployeeWorkData.Rows[0];
                                        DataGridViewComboBoxCell dgvcbc = null;

            dgvEmployeeWorkData.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvEmployeeWorkData_EditingControlShowing);
            fds = wow_dsx.Fields;
            wow_dsx.GetFirstRecordFromDataBase(ref fds,
                                               ref bNothingFound,
                                               ref bErrorFound,
                                               ref szErrorMessage);

            while (true)
            {
                if (bNothingFound)
                {
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    try
                    {
                        dgvcbc = (DataGridViewComboBoxCell)(dgvRow.Cells[4]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    dgvcbc.Items.Add(fds.ItemIsField("WorkName").StringValue);

                    wow_dsx.GetNextRecordFromDataBase(ref fds,
                                                      ref bNothingFound,
                                                      ref bErrorFound,
                                                      ref szErrorMessage);                
                }

                break;
            }
        }

        private void XX_InitializeEmployeeIdComboBoxInEmployeeWorkDataDataGrid()
        { 
                                        Fields fds = null;
                                        string szErrorMessage = string.Empty;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
                                        dgvEmployeeWorkData.Rows.Add(1);
                                        DataGridViewRow dgvRow = dgvEmployeeWorkData.Rows[0];
                                        DataGridViewComboBoxCell dgvcbc = null;

                                        dgvEmployeeWorkData.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvEmployeeWorkData_EditingControlShowing);
            fds = s_dsx.Fields;

            s_dsx.GetFirstRecordFromDataBase(ref fds,
                                             ref bNothingFound,
                                             ref bErrorFound,
                                             ref szErrorMessage);

            while (true)
            {
                if (bNothingFound)
                {
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    try
                    {
                        dgvcbc = (DataGridViewComboBoxCell)(dgvRow.Cells[0]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    dgvcbc.Items.Add(fds.ItemIsField("EmployeeId").StringValue);

                    s_dsx.GetNextRecordFromDataBase(ref fds,
                                                    ref bNothingFound,
                                                    ref bErrorFound,
                                                    ref szErrorMessage);                
                }

                break;
            }
        }

        void dgvEmployeeWorkData_EditingControlShowing(object sender, 
                                                       DataGridViewEditingControlShowingEventArgs e)
        {
                                        ComboBox cbEmployeeId = e.Control as ComboBox;

            if(cbEmployeeId != null)
            {
                cbEmployeeId.SelectedIndexChanged -= new EventHandler(cbEmployeeId_SelectedIndexChanged);
                cbEmployeeId.SelectedIndexChanged += new EventHandler(cbEmployeeId_SelectedIndexChanged);
            }
        }

        void cbEmployeeId_SelectedIndexChanged(object sender, EventArgs e)
        {
                                        ComboBox cb = (ComboBox)sender;                                        
                                        DataGridViewRow dgvr = dgvEmployeeWorkData.Rows[dgvEmployeeWorkData.CurrentCell.RowIndex];
                                        string szFirstName = string.Empty;
                                        string szLastName = string.Empty;
                                        string szOtherName = string.Empty;
                                        string szEmployeeId = string.Empty;

            switch(dgvEmployeeWorkData.CurrentCell.ColumnIndex)
            {
                case 0:
                    szEmployeeId = cb.Text;
                    if (szEmployeeId != null)
                    {
                        XX_GetAdditionalValuesForEmployee(szEmployeeId,
                                                          ref szFirstName,
                                                          ref szLastName,
                                                          ref szOtherName);

                        dgvEmployeeWorkData.NotifyCurrentCellDirty(false);
                        dgvr.Cells[1].Value = szFirstName;
                        dgvr.Cells[2].Value = szLastName;
                        dgvr.Cells[3].Value = szOtherName;
                        dgvEmployeeWorkData.NotifyCurrentCellDirty(true);
                    }

                    break;

                case 4:


                    break;
            }

        }

        private void XX_GetAdditionalValuesForEmployee(string szvEmployeeId,
                                                       ref string szrFirstName,
                                                       ref string szrLastName,
                                                       ref string szrOtherName)
        {
                                        Fields fds = null;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
                                        string szFirstName = string.Empty;
                                        string szLastName = string.Empty;
                                        string szOtherName = string.Empty;
                                        string szErrorMessage = string.Empty;

            fds = s_dsx.Fields;

            s_dsx.GetStaffOverStaffId(Convert.ToInt32(szvEmployeeId),
                                      ref fds,
                                      ref bNothingFound,
                                      ref bErrorFound,
                                      ref szErrorMessage);

            szFirstName = fds.ItemIsField("FirstName").StringValue;
            szLastName = fds.ItemIsField("LastName").StringValue;
            szOtherName = fds.ItemIsField("OtherName").StringValue;

            szrFirstName = szFirstName;
            szrLastName = szLastName;
            szrOtherName = szOtherName;
        }

        private void btnAddEmployeeWorkDataRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvRow = (DataGridViewRow)dgvEmployeeWorkData.Rows[0].Clone();
            dgvEmployeeWorkData.Rows.Add(dgvRow);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            while(true)
            {
                XX_AddWorkOrderToDataBase(ref bErrorFound,
                                          ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                XX_AddWorkOrderTemplateMaterialsToDataBase(ref bErrorFound,
                                                           ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                XX_AddWorkOrderMaterialsToDataGridView();
                XX_AddWorkOrderTemplateWorksToDataBase(ref bErrorFound,
                                                       ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                utsx.ShowMessage("Data added to database successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);
                XX_InitializeWorkNameInEmployeeWorkDataDataGrid();

                break;
            }

            if (bErrorFound)
            {
                utsx.ShowMessage(szErrorMessage,
                                 EnumsCollection.EnumMessageType.emtError);
            }
        }

        private void XX_AddWorkOrderTemplateWorksToDataBase(ref bool brErrorFound,
                                                            ref string szrErrorMessage)
        {
                                        Fields fdsWorkOrderTemplatesWorks = null;
                                        Fields fdsWorkOrderWorks = null;
                                        string szErrorMessage = string.Empty;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
            
            fdsWorkOrderTemplatesWorks = wotw_dsx.Fields;
            fdsWorkOrderWorks = wow_dsx.Fields;

            fdsWorkOrderTemplatesWorks.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
            fdsWorkOrderTemplatesWorks.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;

            wotw_dsx.GetFirstRecordFromDataBase(ref fdsWorkOrderTemplatesWorks,
                                                ref bNothingFound,
                                                ref bErrorFound,
                                                ref szErrorMessage);

            while (true)
            {
                if (bNothingFound)
                {
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    fdsWorkOrderWorks.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;
                    fdsWorkOrderWorks.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
                    fdsWorkOrderWorks.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;
                    fdsWorkOrderWorks.ItemIsField("WorkOrderTemplateDescription").StringValue = txtWorkOrderTemplateDescription.Text;
                    fdsWorkOrderWorks.ItemIsField("WorkId").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("WorkId").StringValue;
                    fdsWorkOrderWorks.ItemIsField("WorkName").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("WorkName").StringValue;
                    fdsWorkOrderWorks.ItemIsField("WorkDescription").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("WorkDescription").StringValue;
                    fdsWorkOrderWorks.ItemIsField("EnumWorkType").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("EnumWorkType").StringValue;
                    fdsWorkOrderWorks.ItemIsField("SetupTime").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("SetupTime").StringValue;
                    fdsWorkOrderWorks.ItemIsField("RunTime").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("RunTime").StringValue;
                    fdsWorkOrderWorks.ItemIsField("WorkCost").StringValue = fdsWorkOrderTemplatesWorks.ItemIsField("WorkCost").StringValue;

                    wow_dsx.AddToDataBase(fdsWorkOrderWorks,
                                          ref bErrorFound,
                                          ref szErrorMessage);

                    wotw_dsx.GetNextRecordFromDataBase(ref fdsWorkOrderTemplatesWorks,
                                                       ref bNothingFound,
                                                       ref bErrorFound,
                                                       ref szErrorMessage);
                }

                break;
            }        
        }

        private void XX_AddWorkOrderTemplateMaterialsToDataBase(ref bool brErrorFound,
                                                                ref string szrErrorMessage)
        {
                                        Fields fdsWorkOrderTemplatesMaterial = null;
                                        Fields fdsWorkOrderMaterials = null;
                                        string szErrorMessage = string.Empty;
                                        bool bNothingFound = false;
                                        bool bErrorFound = false;
            
            fdsWorkOrderTemplatesMaterial = wotm_dsx.Fields;
            fdsWorkOrderMaterials = wom_dsx.Fields;

            fdsWorkOrderTemplatesMaterial.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
            fdsWorkOrderTemplatesMaterial.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;

            wotm_dsx.GetFirstRecordFromDataBase(ref fdsWorkOrderTemplatesMaterial,
                                                ref bNothingFound,
                                                ref bErrorFound,
                                                ref szErrorMessage);

            while (true)
            {
                if (bNothingFound)
                {
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    fdsWorkOrderMaterials.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;
                    fdsWorkOrderMaterials.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
                    fdsWorkOrderMaterials.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;
                    fdsWorkOrderMaterials.ItemIsField("WorkOrderTemplateDescription").StringValue = txtWorkOrderTemplateDescription.Text;
                    fdsWorkOrderMaterials.ItemIsField("MaterialId").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("MaterialId").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("MaterialName").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("MaterialName").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("MaterialDescription").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("MaterialDescription").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("UnitOfMeasure").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("UnitOfMeasure").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("Quantity").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("Quantity").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("EnumMaterialManagementType").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("EnumMaterialManagementType").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("PricePerUnit").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("PricePerUnit").StringValue;
                    fdsWorkOrderMaterials.ItemIsField("TotalPrice").StringValue = fdsWorkOrderTemplatesMaterial.ItemIsField("TotalPrice").StringValue;

                    wom_dsx.AddToDataBase(fdsWorkOrderMaterials,
                                          ref bErrorFound,
                                          ref szErrorMessage);

                    wotm_dsx.GetNextRecordFromDataBase(ref fdsWorkOrderTemplatesMaterial,
                                                       ref bNothingFound,
                                                       ref bErrorFound,
                                                       ref szErrorMessage);
                }

                break;
            }
        }

        private void XX_AddWorkOrderWorksToDataGridView()
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
                scsx.ClearDataGridView(dgvWorkOrderWorks);

                fds = wow_dsx.Fields;
                fds.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;

                wow_dsx.GetFirstRecordFromDataBase(ref fds,
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
                    //                                       "No Record found for Cake Plan Tasks.");
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

                    dgvRow = (DataGridViewRow)dgvWorkOrderWorks.Rows[0].Clone();

                    dgvRow.Cells[0].Value = fds.ItemIsField("WorkId").StringValue;
                    dgvRow.Cells[1].Value = fds.ItemIsField("WorkName").StringValue;
                    dgvRow.Cells[2].Value = fds.ItemIsField("WorkDescription").StringValue;
                    dgvRow.Cells[3].Value = fds.ItemIsField("WorkCost").StringValue;
                    dgvRow.Cells[4].Value = fds.ItemIsField("WorkRatio").StringValue;

                    dgvWorkOrderWorks.Rows.Add(dgvRow);

                    fds.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;

                    wow_dsx.GetNextRecordFromDataBase(ref fds,
                                                       ref bEndofFind,
                                                       ref bErrorFound,
                                                       ref szErrorMessage);

                }

                break;
            }        
        }

        private void XX_AddWorkOrderMaterialsToDataGridView()
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
                scsx.ClearDataGridView(dgvWorkOrderMaterials);
                fds = wom_dsx.Fields;
                fds.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;

                wom_dsx.GetFirstRecordFromDataBase(ref fds,
                                                   ref bNothingFound,
                                                   ref bErrorFound,
                                                   ref szErrorMessage);
                if(bErrorFound)
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

                    dgvRow = (DataGridViewRow)dgvWorkOrderMaterials.Rows[0].Clone();

                    dgvRow.Cells[0].Value = fds.ItemIsField("MaterialId").StringValue;
                    dgvRow.Cells[1].Value = fds.ItemIsField("MaterialName").StringValue;
                    dgvRow.Cells[2].Value = fds.ItemIsField("MaterialDescription").StringValue;
                    dgvRow.Cells[3].Value = fds.ItemIsField("UnitOfMeasure").StringValue;
                    dgvRow.Cells[4].Value = fds.ItemIsField("Quantity").StringValue;
                    dgvRow.Cells[5].Value = fds.ItemIsField("PricePerUnit").StringValue;
                    dgvRow.Cells[6].Value = fds.ItemIsField("MaterialRatio").StringValue;

                    dgvWorkOrderMaterials.Rows.Add(dgvRow);

                    fds.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;

                    wom_dsx.GetNextRecordFromDataBase(ref fds,
                                                      ref bEndofFind,
                                                      ref bErrorFound,
                                                      ref szErrorMessage);
                
                }

                break;
            }        
        }

        private void XX_AddWorkOrderToDataBase(ref bool brErrorFound,
                                               ref string szrErrorMessage)
        { 
                                        Fields fdsWorkOrder = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            fdsWorkOrder = wo_dsx.Fields;

            fdsWorkOrder.ItemIsField("WorkOrderNumber").StringValue = txtWorkOrderNumber.Text;
            fdsWorkOrder.ItemIsField("WorkOrderTemplateName").StringValue = txtWorkOrderTemplateName.Text;
            fdsWorkOrder.ItemIsField("WorkOrderTemplateNumber").StringValue = txtWorkOrderTemplateNumber.Text;
            fdsWorkOrder.ItemIsField("WorkOrderTemplateDescription").StringValue = txtWorkOrderTemplateDescription.Text;

            wo_dsx.AddToDataBase(fdsWorkOrder,
                                 ref bErrorFound,
                                 ref szErrorMessage);

            szrErrorMessage = szErrorMessage;
            brErrorFound = bErrorFound;

        }
    }
}
