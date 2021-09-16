using System;
using System.Collections;
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
    public partial class F_WorkOrderTemplate : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Materials_DS m_dsx = null;
        private Works_DS w_dsx = null;
        private WorkOrderTemplates_DS wot_dsx = null;
        private WorkOrderTemplateMaterials_DS wotm_dsx = null;
        private WorkOrderTemplateWorks_DS wotw_dsx = null;
        private SharedComponents scsx = null;
        private const string szxEMPTY = "";

        public F_WorkOrderTemplate(Form mdivForm,
                                   DatabaseConnection dbcv,
                                   
                                   Fields fdsvUpdateFields,
                                   EnumsCollection.EnumFormMode efmv)
        {
            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            m_dsx = new Materials_DS(dbcx);
            w_dsx = new Works_DS(dbcv);
            wot_dsx = new WorkOrderTemplates_DS(dbcx);
            wotm_dsx = new WorkOrderTemplateMaterials_DS(dbcx);
            wotw_dsx = new WorkOrderTemplateWorks_DS(dbcx);

            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            
            scsx = new SharedComponents(dbcx);

            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void F_WorkOrderTemplate_Load(object sender, EventArgs e)
        {
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
            dgvWorks.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvTasksView_RowHeaderMouseDoubleClick);
            dgvMaterials.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvMaterials_RowHeaderMouseDoubleClick);
            cmsContextCall.Click += new EventHandler(cmsContextCall_Click);
            this.MouseDown += new MouseEventHandler(ContextCall_MouseDown);

            ((F_Main)mdixParent).RecordNavigationTasks += new F_Main.delRecordNavigationTasks(F_WorkOrderTemplate_RecordNavigationTasks);
            XX_InitializeDataGridViewColumns();
        }

        private void XX_InitializeDataGridViewColumns()
        {
                                        Dictionary<string, string> dictMaterialColumns = new Dictionary<string, string>();
                                        Dictionary<string, string> dictWorkColumns = new Dictionary<string, string>();

            foreach (DataGridViewCell dgvc in dgvMaterials.Rows[0].Cells)
            {
                dictMaterialColumns.Add(dgvc.OwningColumn.Name, dgvc.OwningColumn.HeaderText);
            }
            dgvMaterials.Tag = dictMaterialColumns;

            foreach (DataGridViewCell dgvc in dgvWorks.Rows[0].Cells)
            {
                dictWorkColumns.Add(dgvc.OwningColumn.Name, dgvc.OwningColumn.HeaderText);
            }
            dgvWorks.Tag = dictWorkColumns;
        }

        private void XX_InitializeForm()
        {
            txtTemplateName.Text = szxEMPTY;
            txtTemplateNumber.Text = szxEMPTY;
            txtTemplateDescription.Text = szxEMPTY;
        }

        private void XX_ClearGrids()
        {
            dgvMaterials.Rows.Clear();
            dgvMaterials.Refresh();
            dgvWorks.Rows.Clear();
            dgvWorks.Refresh();
        }

        private void XX_MoveValuesToFields(ref Fields fdsr)
        {
            fdsr.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
            fdsr.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;
            fdsr.ItemIsField("WorkOrderTemplateDescription").StringValue = txtTemplateDescription.Text;
        }

        private void XX_MoveFieldValuesToControls(Fields fdsv)
        {
            txtTemplateName.Text = fdsv.ItemIsField("WorkOrderTemplateName").StringValue;
            txtTemplateNumber.Text = fdsv.ItemIsField("WorkOrderTemplateNumber").StringValue;
            txtTemplateDescription.Text = fdsv.ItemIsField("WorkOrderTemplateDescription").StringValue;
        }

        private void XX_AddWorkOrderTemplateMaterialsToDataGridView()
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
                scsx.ClearDataGridView(dgvMaterials);
                fds = wotm_dsx.Fields;
                fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                wotm_dsx.GetFirstRecordFromDataBase(ref fds,
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

                    dgvRow = (DataGridViewRow)dgvMaterials.Rows[0].Clone();

                    dgvRow.Cells[0].Value = fds.ItemIsField("MaterialId").StringValue;
                    dgvRow.Cells[1].Value = fds.ItemIsField("MaterialName").StringValue;
                    dgvRow.Cells[2].Value = fds.ItemIsField("MaterialDescription").StringValue;
                    dgvRow.Cells[3].Value = fds.ItemIsField("UnitOfMeasure").StringValue;
                    dgvRow.Cells[4].Value = fds.ItemIsField("Quantity").StringValue;
                    dgvRow.Cells[5].Value = fds.ItemIsField("PricePerUnit").StringValue;
                    dgvRow.Cells[6].Value = fds.ItemIsField("MaterialRatio").StringValue;

                    dgvMaterials.Rows.Add(dgvRow);

                    fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                    fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                    wotm_dsx.GetNextRecordFromDataBase(ref fds,
                                                       ref bEndofFind,
                                                       ref bErrorFound,
                                                       ref szErrorMessage);
                
                }

                break;
            }        
        }

        private void XX_AddWorkOrderTemplateWorksToDataGridView()
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
                scsx.ClearDataGridView(dgvWorks);

                fds = wotw_dsx.Fields;
                fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                wotw_dsx.GetFirstRecordFromDataBase(ref fds,
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

                    dgvRow = (DataGridViewRow)dgvWorks.Rows[0].Clone();

                    dgvRow.Cells[0].Value = fds.ItemIsField("WorkId").StringValue;
                    dgvRow.Cells[1].Value = fds.ItemIsField("WorkName").StringValue;
                    dgvRow.Cells[2].Value = fds.ItemIsField("WorkDescription").StringValue;
                    dgvRow.Cells[3].Value = fds.ItemIsField("WorkCost").StringValue;
                    dgvRow.Cells[4].Value = fds.ItemIsField("WorkRatio").StringValue;

                    dgvWorks.Rows.Add(dgvRow);

                    fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                    fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                    wotw_dsx.GetNextRecordFromDataBase(ref fds,
                                                       ref bEndofFind,
                                                       ref bErrorFound,
                                                       ref szErrorMessage);

                }

                break;
            }        
        }

        private void XX_RemoveWorkOrderTemplateFromDataBase(string szvFormKey,
                                                            Fields fdsv)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        DialogResult dResult = System.Windows.Forms.DialogResult.None;
                                        string szPromptMessage = string.Empty;

            szPromptMessage = "Are you sure you want to Remove Work Order Template" 
                            + System.Environment.NewLine
                            + txtTemplateName.Text
                            + "-"
                            + txtTemplateNumber.Text
                            + "?";
            
            dResult = MessageBox.Show(szPromptMessage,
                                      "Remove",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            switch (dResult)
            {
                case DialogResult.Yes:
                    wot_dsx.RemoveFromDataBase(fdsv,
                                               ref bErrorFound,
                                               ref szErrorMessage);

                    if (bErrorFound)
                    {
                        utsx.ShowMessage(szErrorMessage,
                                         EnumsCollection.EnumMessageType.emtError);
                    }
                    else 
                    {
                        utsx.ShowMessage("Work Order Template Removed Successfully",
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

        void F_WorkOrderTemplate_RecordNavigationTasks(string szvFormKey, 
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

                fds = wot_dsx.Fields;
                
                switch (erntv)
                {
                    case EnumsCollection.EnumRecordNavigationTasks.erntNewRecord:
                        XX_InitializeForm();
                        XX_ClearGrids();
                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToFirstRecord:
                        wot_dsx.GetFirstRecordFromDataBase(ref fds,
                                                           ref bNothingFound,
                                                           ref bErrorFound,
                                                           ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderTemplateMaterialsToDataGridView();
                            XX_AddWorkOrderTemplateWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToLastRecord:
                        wot_dsx.GetLastRecordFromDataBase(ref fds,
                                                          ref bNothingFound,
                                                          ref bErrorFound,
                                                          ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderTemplateMaterialsToDataGridView();
                            XX_AddWorkOrderTemplateWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToNextRecord:
                        XX_MoveValuesToFields(ref fds);

                        wot_dsx.GetNextRecordFromDataBase(ref fds,
                                                          ref bNothingFound,
                                                          ref bErrorFound,
                                                          ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderTemplateMaterialsToDataGridView();
                            XX_AddWorkOrderTemplateWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntMoveToPreviousRecord:
                        XX_MoveValuesToFields(ref fds);

                        wot_dsx.GetPreviousRecordFromDataBase(ref fds,
                                                              ref bNothingFound,
                                                              ref bErrorFound,
                                                              ref szErrorMessage);

                        if (!bNothingFound && !bErrorFound)
                        {
                            XX_MoveFieldValuesToControls(fds);
                            XX_AddWorkOrderTemplateMaterialsToDataGridView();
                            XX_AddWorkOrderTemplateWorksToDataGridView();
                            btnUpdate.Enabled = true;
                            btnAdd.Enabled = false;
                        }
                        break;

                    case EnumsCollection.EnumRecordNavigationTasks.erntRemoveRecord:
                        XX_MoveValuesToFields(ref fds);
                        XX_RemoveWorkOrderTemplateFromDataBase(szvFormKey,
                                                               fds);

                        btnUpdate.Enabled = false;
                        btnAdd.Enabled = true;

                        break;
                }
                break;
            }
        }

        void dgvMaterials_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgvCurrent = (DataGridView)sender;

            while (true)
            {
                if (dgvCurrent.CurrentCell.RowIndex < 0)
                {
                    break;
                }

                F_CFLMaterials f_ms = new F_CFLMaterials(mdixParent,
                                                         dbcx,
                                                         m_dsx);
                f_ms.MdiParent = mdixParent;
                f_ms.RowSelected += new F_CFLMaterials.delRowSelected(f_ms_RowSelected);
                f_ms.Show();

                break;
            }   
        }

        void f_ms_RowSelected(Fields fdsv)
        {
            DataGridViewRow dgvRow = dgvMaterials.Rows[dgvMaterials.CurrentCell.RowIndex];

            dgvMaterials.NotifyCurrentCellDirty(false);
            scsx.MoveFieldsValuesToDataGridRow(dgvMaterials,
                                               dgvRow,
                                               fdsv);

            dgvMaterials.NotifyCurrentCellDirty(true);
        }

        void ContextCall_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Right:
                    cmsContextCall.Show(Cursor.Position);
                    break;
            }
        }

        void cmsContextCall_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (txtTemplateName.Text == szxEMPTY || txtTemplateNumber.Text == szxEMPTY || txtTemplateDescription.Text == szxEMPTY)
                {
                    //f_wmx.AddMessageToMessagesdataGridView(EnumsCollection.EnumMessageType.emtError,
                    //                                       "Record should not be empty");
                    break;
                }

                F_WorkOrder f_wo = new F_WorkOrder(mdixParent,
                                                   dbcx,
                                                   null, 
                                                   EnumsCollection.EnumFormMode.efmAdd);
                f_wo.MdiParent = mdixParent;
                f_wo.InitializeWorkOrderHeaderDetails(txtTemplateName.Text,
                                                      txtTemplateDescription.Text,
                                                      txtTemplateNumber.Text);
                f_wo.Show();
                break;
            }
        }

        void dgvTasksView_RowHeaderMouseDoubleClick(object sender, 
                                                    DataGridViewCellMouseEventArgs e)
        {
                                        DataGridView dgvCurrent = (DataGridView)sender;

            while(true)
            {
                if (dgvCurrent.CurrentCell.RowIndex < 0)
                {
                    break;
                }

                F_CFLWorks f_CFLWorks = new F_CFLWorks(mdixParent,
                                                       dbcx,
                                                       w_dsx);
                f_CFLWorks.MdiParent = mdixParent;
                f_CFLWorks.RowSelected += new F_CFLWorks.delRowSelected(f_CFLWorks_RowSelected);
                f_CFLWorks.Show();

                break;
            }   
        }

        void f_CFLWorks_RowSelected(Fields fdsv)
        {
                                        DataGridViewRow dgvRow = dgvWorks.Rows[dgvWorks.CurrentCell.RowIndex];

            dgvWorks.NotifyCurrentCellDirty(false);
            scsx.MoveFieldsValuesToDataGridRow(dgvWorks,
                                               dgvRow,
                                               fdsv);

            dgvWorks.NotifyCurrentCellDirty(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            while(true)
            {
                XX_AddWorkOrderTemplateToDataBase(ref bErrorFound,
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

                XX_AddWorkOrderTemplateWorksToDataBase(ref bErrorFound,
                                                       ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                utsx.ShowMessage("Data added to database successfully",
                                 EnumsCollection.EnumMessageType.emtSuccess);
                break;
            }

            if (bErrorFound)
            {
                utsx.ShowMessage(szErrorMessage,
                                 EnumsCollection.EnumMessageType.emtError);
            }
        }

        private void XX_AddWorkOrderTemplateToDataBase(ref bool brErrorFound,
                                                       ref string szrErrorMessage)
        { 
                                        Fields fdsWorkOrderTemplate = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            fdsWorkOrderTemplate = wot_dsx.Fields;

            fdsWorkOrderTemplate.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
            fdsWorkOrderTemplate.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;
            fdsWorkOrderTemplate.ItemIsField("WorkOrderTemplateDescription").StringValue = txtTemplateDescription.Text;

            wot_dsx.AddToDataBase(fdsWorkOrderTemplate,
                                  ref bErrorFound,
                                  ref szErrorMessage);

            szrErrorMessage = szErrorMessage;
            brErrorFound = bErrorFound;
        }

        private void XX_AddWorkOrderTemplateMaterialsToDataBase(ref bool brErrorFound,
                                                                ref string szrErrorMessage)
        {
                                        bool bErrorFound = false;
                                        bool bRowHasEmptyCell = false;
                                        string szErrorMessage = string.Empty;
                                        DataGridViewRow dgvRow = null;
                                        Fields fds = null;
            
            for (int nRow = 0; nRow <= dgvMaterials.Rows.Count - 1; nRow++)
            {
                while (true)
                {
                    dgvRow = dgvMaterials.Rows[nRow];
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

                    fds = wotm_dsx.Fields;
                    fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                    fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                    scsx.MoveDataGridRowValuesToFields(dgvRow,
                                                       ref fds);

                    wotm_dsx.AddToDataBase(fds,
                                           ref bErrorFound,
                                           ref szErrorMessage);

                    //if (bErrorFound)
                    //{
                    //    utsx.ShowMessage(szErrorMessage,
                    //                     EnumsCollection.EnumMessageType.emtError);
                    //}
                    //else
                    //{
                    //    utsx.ShowMessage("Cake Item Added Successfully",
                    //                     EnumsCollection.EnumMessageType.emtSuccess);
                    //}
                    break;
                }
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void XX_AddWorkOrderTemplateWorksToDataBase(ref bool brErrorFound,
                                                            ref string szrErrorMessage)
        {
                                        bool bErrorFound = false;
                                        bool bRowHasEmptyCell = false;
                                        string szErrorMessage = string.Empty;
                                        DataGridViewRow dgvRow = null;
                                        Fields fds = null;
            
            for (int nRow = 0; nRow <= dgvWorks.Rows.Count - 1; nRow++)
            {
                while (true)
                {
                    dgvRow = dgvWorks.Rows[nRow];
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

                    fds = wotw_dsx.Fields;
                    fds.ItemIsField("WorkOrderTemplateName").StringValue = txtTemplateName.Text;
                    fds.ItemIsField("WorkOrderTemplateNumber").StringValue = txtTemplateNumber.Text;

                    scsx.MoveDataGridRowValuesToFields(dgvRow,
                                                       ref fds);

                    wotw_dsx.AddToDataBase(fds,
                                           ref bErrorFound,
                                           ref szErrorMessage);

                    //if (bErrorFound)
                    //{
                    //    utsx.ShowMessage(szErrorMessage,
                    //                     EnumsCollection.EnumMessageType.emtError);
                    //}
                    //else
                    //{
                    //    utsx.ShowMessage("Cake Item Added Successfully",
                    //                     EnumsCollection.EnumMessageType.emtSuccess);
                    //}
                    break;
                }
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
