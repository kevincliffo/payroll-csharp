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
    public partial class F_CFLWorks : Form
    {
        public delegate void delRowSelected(Fields fdsv);

        public event delRowSelected RowSelected;
        private DatabaseConnection dbcx = null;
        private Form mdixParent = null;
        private Works_DS w_dsx = null;
        private Utilities.Utilities utsx = null;
        private const string szxEMPTY = "";
        private SharedComponents scsx = null;

        public F_CFLWorks(Form mdivParent,
                          DatabaseConnection dbcv,
                          Works_DS w_dsv)
        {
            InitializeComponent();

            dbcx = dbcv;
            w_dsx = w_dsv;
            mdixParent = mdivParent;
            utsx = new Utilities.Utilities();
            scsx = new SharedComponents(dbcx);

            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_CFLWorks_Load(object sender, EventArgs e)
        {
            dgvWorks.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvWorks_RowHeaderMouseDoubleClick);
            XX_AddTasksToDataGridView();
        }

        void dgvWorks_RowHeaderMouseDoubleClick(object sender, 
                                                DataGridViewCellMouseEventArgs e)
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

                fds = w_dsx.Fields;
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

        private void XX_AddTasksToDataGridView()
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
                w_dsx.GetFirstRecordFromDataBase(ref fds,
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

                    dgvRow = (DataGridViewRow)dgvWorks.Rows[0].Clone();

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

                    dgvWorks.Rows.Add(dgvRow);

                    w_dsx.GetNextRecordFromDataBase(ref fds,
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
                nSelectedRowIndex = dgvWorks.CurrentRow.Index;

                if (nSelectedRowIndex < 0)
                {
                    break;
                }

                if (dgvWorks.CurrentRow.Cells[0].Value == null)
                {
                    break;
                }

                fds = w_dsx.Fields;
                scsx.MoveDataGridRowValuesToFields(dgvWorks.CurrentRow,
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
