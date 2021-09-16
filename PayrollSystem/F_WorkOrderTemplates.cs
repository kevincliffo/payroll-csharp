using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utilities;

namespace PayRollSystem
{
    public partial class F_WorkOrderTemplates : Form
    {
        public delegate void delRowSelected(Fields fdsv);
        public event delRowSelected RowSelected;

        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private WorkOrderTemplates_DS wot_dsx = null;
        private SharedComponents scsx = null;
            
        public F_WorkOrderTemplates(Form mdivForm,
                                    DatabaseConnection dbcv,
                                    Fields fdsvUpdateFields,
                                    EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            wot_dsx = new WorkOrderTemplates_DS(dbcv);

            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            scsx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_WorkOrderTemplates_Load(object sender, EventArgs e)
        {
            dgvWorkOrderTemplates.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvWorkOrderTemplates_RowHeaderMouseDoubleClick);
            XX_AddWorkOrderTemplatesToDataGridView();
        }

        void dgvWorkOrderTemplates_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
                                        DataGridView dgView = (DataGridView)sender;
                                        DataGridViewSelectedCellCollection dgvscCollection = dgView.SelectedCells;
                                        DataGridViewRow dgvr = dgView.SelectedRows[0];
                                        Fields fds = null;

            while(true)
            {
                if (dgvscCollection[0].Value == null)
                {
                    break;
                }

                fds = wot_dsx.Fields;
                scsx.MoveDataGridRowValuesToFields(dgvr,
                                                   ref fds);

                if (RowSelected != null)
                {
                    RowSelected(fds);

                    this.Close();
                }

                break;
            }
        }

        private void XX_AddWorkOrderTemplatesToDataGridView()
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
                wot_dsx.GetFirstRecordFromDataBase(ref fds,
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
                    utsx.ShowMessage("No record found",
                                     EnumsCollection.EnumMessageType.emtInformation);
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

                    dgvRow = (DataGridViewRow)dgvWorkOrderTemplates.Rows[0].Clone();

                    foreach (Field fd in fds)
                    {
                        szValue = fd.StringValue;
                        try
                        {
                            dgvRow.Cells[fd.Index - 1].Value = szValue;

                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }

                    dgvWorkOrderTemplates.Rows.Add(dgvRow);

                    wot_dsx.GetNextRecordFromDataBase(ref fds,
                                                      ref bEndofFind,
                                                      ref bErrorFound,
                                                      ref szErrorMessage);
                
                }

                break;
            }        
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
                                        int nSelectedRowIndex = 0;
                                        Fields fds = null;

            while (true)
            {
                nSelectedRowIndex = dgvWorkOrderTemplates.CurrentRow.Index;

                if (nSelectedRowIndex < 0)
                {
                    break;
                }

                if (dgvWorkOrderTemplates.CurrentRow.Cells[0].Value == null)
                {
                    break;
                }

                fds = wot_dsx.Fields;
                scsx.MoveDataGridRowValuesToFields(dgvWorkOrderTemplates.CurrentRow,
                                                   ref fds);

                if (RowSelected != null)
                {
                    RowSelected(fds);

                    this.Close();
                }


                break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
