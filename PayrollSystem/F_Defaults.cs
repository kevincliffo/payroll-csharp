using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;
using CollectionClasses;

namespace PayRollSystem
{
    public partial class F_Defaults : Form
    {
        private Utilities.Utilities utsx = null;
        private Form mdixForm = null;
        private DatabaseConnection dbcx = null;
        private const string szxEMPTY = "";
        private ApplicationPathCarrier apcx = null;
        
        private SharedComponents scsx = null;
        private Defaults_DS d_dsx = null;

        public F_Defaults(Form mdivForm,
                          DatabaseConnection dbcv)
        {
            InitializeComponent();
            this.Text = "Defaults";
            apcx = new ApplicationPathCarrier(Application.StartupPath);
            utsx = new Utilities.Utilities();
            mdixForm = mdivForm;
            dbcx = dbcv;
            
            scsx = new SharedComponents(dbcx);
            d_dsx = new Defaults_DS(dbcx);

            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void XX_SetIconForTable(string szvTableName)
        {
            Icon ic = null;
            string szIconName = string.Empty;

            ic = new Icon(apcx.IconsPath + "\\" + szIconName);
            this.Icon = ic;
        }

        private void F_Table_Load(object sender, EventArgs e)
        {
                                        Fields fds = new Fields();
                                        DataGridViewRow dgvRow = new DataGridViewRow();
                                        bool bEndOfFind = false;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szValue = string.Empty;

            //XX_SetIconForTable(this.Text);
            dgvData.AllowUserToResizeColumns = true;

            foreach (Field fd in d_dsx.Fields)
            {
                dgvData.Columns.Add(fd.Key,
                                    fd.LocalizedName);
            }

            while (true)
            {
                d_dsx.GetFirstRecordFromDataBase(ref fds,
                                                 ref bEndOfFind,
                                                 ref bErrorFound,
                                                 ref szErrorMessage);

                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                if (bEndOfFind)
                {
                    break;
                }


                dgvRow = (DataGridViewRow)dgvData.Rows[0].Clone();

                XX_MoveFieldValuesToDataGridRow(ref fds,
                                                ref dgvRow);

                dgvData.Rows.Add(dgvRow);

                while (true)
                {
                    d_dsx.GetNextRecordFromDataBase(ref fds,
                                                    ref bEndOfFind,
                                                    ref bErrorFound,
                                                    ref szErrorMessage);
                    if (bEndOfFind)
                    {
                        break;

                    }

                    dgvRow = (DataGridViewRow)dgvData.Rows[0].Clone();
                    XX_MoveFieldValuesToDataGridRow(ref fds,
                                                    ref dgvRow);

                    dgvData.Rows.Add(dgvRow);
                }

                break;
            }

            dgvData.AutoResizeColumns();
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;            

        }

        private void XX_MoveFieldValuesToDataGridRow(ref Fields fdsr,
                                                     ref DataGridViewRow dgvrr)
        {
            dgvrr.Cells[0].Value = fdsr.ItemIsField("DefaultId").StringValue;
            dgvrr.Cells[1].Value = fdsr.ItemIsField("DefaultName").StringValue;
            dgvrr.Cells[2].Value = fdsr.ItemIsField("DefaultDescription").StringValue;
            dgvrr.Cells[3].Value = fdsr.ItemIsField("Value").StringValue;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void XX_AddDefaultsToDataBase(ref bool brErrorFound,
                                                    ref string szrErrorMessage)
        {
                                        bool bErrorFound = false;
                                        bool bRowHasEmptyCell = false;
                                        string szErrorMessage = string.Empty;
                                        DataGridViewRow dgvRow = null;
                                        Fields fds = null;
            
            for (int nRow = 0; nRow <= dgvData.Rows.Count - 1; nRow++)
            {
                while (true)
                {
                    dgvRow = dgvData.Rows[nRow];
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

                    fds = d_dsx.Fields;

                    scsx.MoveDataGridRowValuesToFields(dgvRow,
                                                       ref fds);

                    d_dsx.AddToDataBase(fds,
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

        private void btnStore_Click(object sender, EventArgs e)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            d_dsx.RemoveAllDefaultsFromDataBase(ref bErrorFound,
                                                ref szErrorMessage);

            XX_AddDefaultsToDataBase(ref bErrorFound,
                                     ref szErrorMessage);

            switch (bErrorFound)
            {
                case true:
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;

                case false:
                    utsx.ShowMessage("Values stored successfully",
                                     EnumsCollection.EnumMessageType.emtSuccess);
                    break;
            }
        }
    }
}
