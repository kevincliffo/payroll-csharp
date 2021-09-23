using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
//using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;
using CustomGrid;

namespace PayRollSystem
{
    public partial class F_Table : Form
    {
        private dynamic dyxDataServer = null;
        private Utilities.Utilities utsx = null;
        private Form mdixForm = null;
        private DatabaseConnection dbcx = null;
        private const string szxEMPTY = "";
        private ApplicationPathCarrier apcx = null;
        private SubDepartments_DS sd_dsx = null;
        private SharedComponents scx = null;

        private int nxPrevColIndex = -1;
        private ListSortDirection lsdxPrevSortDirection = ListSortDirection.Ascending;
        private string szxView;

        public F_Table(Form mdivForm,
                       DatabaseConnection dbcv,
                       string szvTableName,
                       dynamic dyvDataServer)
        {
            InitializeComponent();
            this.Text = szvTableName;
            dyxDataServer = dyvDataServer;
            apcx = new ApplicationPathCarrier(Application.StartupPath);
            utsx = new Utilities.Utilities();
            mdixForm = mdivForm;
            dbcx = dbcv;
            sd_dsx = new SubDepartments_DS(dbcx);

            scx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;

            szxView = "UnboundContactInfo";
        }

        private void XX_SetOutlookSkin()
        {
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd.DefaultCellStyle = dataGridViewCellStyle2;
            this.grd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.grd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;

            this.grd.GridColor = System.Drawing.SystemColors.Control;
            this.grd.RowTemplate.Height = 19;
            this.grd.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grd.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.grd.RowHeadersVisible = false;
            this.grd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AllowUserToResizeRows = false;
            this.grd.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.grd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.grd.ClearGroups(); // reset

        }

        private void XX_SetIconForTable(string szvTableName)
        {
                                        Icon ic = null;
                                        string szIconName = string.Empty;

            switch(szvTableName)
            {
                case "Staff":
                case "Users":
                case "Customers":
                case "Suppliers":
                    szIconName = "users.ico";
                    break;

                case "Students":
                    szIconName = "students.ico";
                    break;
                case "Teachers":
                    szIconName = "teacher.ico";
                    break;
                case "Departments":
                case "SubDepartments":
                    szIconName = "calculator.ico";
                    break;
            }

            ic = new Icon(apcx.IconsPath + "\\" + szIconName);
            this.Icon = ic;
            //this.TopPanel.IconPath = apcx.IconsPath + "\\" + szIconName;
        }

        private void F_Table_Load(object sender, EventArgs e)
        {
                                        Fields fds = new Fields();
                                        Fields fdsDummy = new Fields();
                                        DataGridViewRow dgvRow = new DataGridViewRow();
                                        bool bEndOfFind = false;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szValue = string.Empty;
                                        string szSQL = string.Empty;
                                        DataGridViewColumn dgvc = null;

            XX_SetIconForTable(this.Text);
            //dgvData.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvData_RowHeaderMouseDoubleClick);
            //dgvData.AllowUserToResizeColumns = true;
            grd.CellClick += new DataGridViewCellEventHandler(grd_CellClick);

            //XX_SetOutlookSkin();
            foreach (Field fd in dyxDataServer.Fields)
            {
                //dgvData.Columns.Add(fd.Key,
                //                    fd.LocalizedName);
                //grd.Columns.Add(fd.Key, fd.LocalizedName);

                dgvc = new DataGridViewColumn();
                
                dgvc.Tag = fd.EnumFieldType;
                dgvc.HeaderText = fd.LocalizedName;
                dgvc.Name = fd.Key;
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                dgvc.CellTemplate = cell;
                try
                {
                    grd.Columns.Add(dgvc);
                }

                catch (Exception ex)
                {
                    utsx.ShowMessage(ex.Message,
                                     EnumsCollection.EnumMessageType.emtError);
                }
            }

            fdsDummy = dyxDataServer.Fields;
            switch (this.Text) 
            {
                case "Staff":
                case "Users":
                case "Students":
                case "Customers":
                case "Departments":                
                case "FeeStructures":
                case "FeesPayments":
                    dyxDataServer.GetFirstRecordFromDataBase(ref fds,
                                                             ref bEndOfFind,
                                                             ref bErrorFound,
                                                             ref szErrorMessage);

                    scx.MoveFieldValuesToCustomGridGridRow(grd,
                                                           fds,
                                                           true);

                    while (true)
                    {
                        dyxDataServer.GetNextRecordFromDataBase(ref fds,
                                                                ref bEndOfFind,
                                                                ref bErrorFound,
                                                                ref szErrorMessage);
                        if (bEndOfFind)
                        {
                            break;

                        }

                        scx.MoveFieldValuesToCustomGridGridRow(grd,
                                                               fds,
                                                               true);
                    }

                    //scx.FormatDataGridViewCells(fdsDummy,
                    //                            dgvData);
                    break;

                case "SubDepartments":
                    XX_DispalySubDepartmentsOnDataGrid();
                    break;
            }

            //XX_SetOutlookSkin();
        }

        void grd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex >= 0)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                if (e.ColumnIndex == nxPrevColIndex) // reverse sort order
                    direction = lsdxPrevSortDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;

                // remember the column that was clicked and in which direction is ordered
                nxPrevColIndex = e.ColumnIndex;
                lsdxPrevSortDirection = direction;

                // set the column to be grouped
                grd.GroupTemplate.Column = grd.Columns[e.ColumnIndex];

                //sort the grid (based on the selected view)
                switch (szxView)
                {
                    case "BoundContactInfo":
                        grd.Sort(new ContactInfoComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundCategory":
                        grd.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundInvoices":
                        grd.Sort(new DataRowComparer(e.ColumnIndex, direction));
                        break;
                    case "BoundQuarterly":
                        // this is an example of overriding the default behaviour of the
                        // Group object. Instead of using the DefaultGroup behavious, we
                        // use the AlphabeticGroup, so items are grouped together based on
                        // their first character:
                        // all items starting with A or a will be put in the same group.
                        GridGroup prevGroup = grd.GroupTemplate;

                        if (e.ColumnIndex == 0) // execption when user pressed the customer name column
                        {
                            // simply override the GroupTemplate to use before sorting
                            grd.GroupTemplate = new OutlookGridAlphabeticGroup();
                            grd.GroupTemplate.Collapsed = prevGroup.Collapsed;
                        }

                        // set the column to be grouped
                        // this must always be done before sorting
                        grd.GroupTemplate.Column = grd.Columns[e.ColumnIndex];

                        // execute the sort, arrange and group function
                        grd.Sort(new DataRowComparer(e.ColumnIndex, direction));

                        //after sorting, reset the GroupTemplate back to its default (if it was changed)
                        // this is needed just for this demo. We do not want the other
                        // columns to be grouped alphabetically.
                        grd.GroupTemplate = prevGroup;
                        break;
                    default: //UnboundContactInfo
                        grd.Sort(grd.Columns[e.ColumnIndex], direction);
                        break;
                }
            }
        }

        private void XX_DispalySubDepartmentsOnDataGrid()
        {
                                        Fields fds = new Fields();
                                        DataGridViewRow dgvRow = new DataGridViewRow();
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szValue = string.Empty;
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        GridRow grRow = new GridRow();

            szSQL = "SELECT * FROM SubDepartments Order By DepartmentId, SubDepartmentId ASC";
            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                fds = sd_dsx.Fields;
                while (mysql_dr.Read())
                {
                    dbcx.MoveRecordToMemberObject(ref mysql_dr,
                                                  ref fds);

                    //dgvRow = (DataGridViewRow)dgvData.Rows[0].Clone();

                    //scx.MoveFieldsValuesToDataGridRow(dgvData,
                    //                                  dgvRow,
                    //                                  fds,
                    //                                  true);

                    //dgvData.Rows.Add(dgvRow);

                    scx.MoveFieldValuesToCustomGridGridRow(grd,
                                                           fds,
                                                           true);
                }

                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }
        
        }

        void dgvData_RowHeaderMouseDoubleClick(object sender, 
                                               DataGridViewCellMouseEventArgs e)
        {
                                        int nRowIndex = e.RowIndex;
                                        DataGridViewRow dgvRow = new DataGridViewRow();
                                        DataGridViewColumn dgvColumn = new DataGridViewColumn();
                                        Fields fds = new Fields();
                                        Field fd = new Field();
                                        string szValue = string.Empty;
                                        ArrayList collEmptyFields = new ArrayList();

            //for (int i = 0; i < dgvData.ColumnCount; i++)
            //{
            //    szValue = Convert.ToString(dgvData[i, nRowIndex].Value);
            //    dgvColumn = dgvData.Columns[i];

            //    fds.AddField(dgvColumn.Name,
            //                 ref fd);

            //    fd.StringValue = szValue;

            //    if (szValue.Trim() == szxEMPTY)
            //    {
            //        collEmptyFields.Add(fd.Key);
            //    }
            //}

            //if (collEmptyFields.Count != dgvData.ColumnCount)
            //{
            //    XX_LaunchFormForUpdateOverText(fds);
            //}

            collEmptyFields.Clear();
            collEmptyFields = null;
        }

        private void XX_LaunchFormForUpdateOverText(Fields fds)
        {
            switch (this.Text)
            { 
                case "Users":
                    fds.TableName = "Users";
                    F_Users f_Users = new F_Users(mdixForm,
                                                  dbcx,
                                                  fds,
                                                  EnumsCollection.EnumFormMode.efmUpdate);

                    f_Users.MdiParent = mdixForm;
                    f_Users.Show();
                    break;

                case "Attendance":
                    fds.TableName = "Attendance";
                    F_Attendance f_Attendance = new F_Attendance(this,
                                                                 dbcx,
                                                                 fds,
                                                                 EnumsCollection.EnumFormMode.efmUpdate);
                    f_Attendance.MdiParent = mdixForm;
                    f_Attendance.Show();
                    break;

                case "Staff":
                    fds.TableName = "Staffs";
                    F_StaffMaster f_sm = new F_StaffMaster(mdixForm,
                                                           dbcx,
                                                           fds,
                                                           EnumsCollection.EnumFormMode.efmUpdate);
                    f_sm.MdiParent = mdixForm;
                    f_sm.Show();
                    break;

                case "Departments":
                    fds.TableName = "Departments";
                    F_Departments f_d = new F_Departments(mdixForm,
                                                          dbcx,
                                                          fds,
                                                          EnumsCollection.EnumFormMode.efmUpdate);
                    f_d.MdiParent = mdixForm;
                    f_d.Show();
                    break;

            }
        }
        public void AddDataToGrid()
        {
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
