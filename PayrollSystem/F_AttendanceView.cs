using System;
using System.Drawing;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using MySql.Data.MySqlClient;
using Models;

namespace PayRollSystem
{
    public partial class F_AttendanceView : Form
    {
        private Utilities.Utilities utsx = null;
        private Form mdixForm = null;
        private DatabaseConnection dbcx = null;
        private const string szxEMPTY = "";
        
        private Staffs_DS s_dsx = null;
        private SharedComponents scsx = null;

        public F_AttendanceView(Form mdivForm,
                                DatabaseConnection dbcv)
        {
            InitializeComponent();
            
            mdixForm = mdivForm;
            dbcx = dbcv;
            
            utsx = new Utilities.Utilities();

            s_dsx = new Staffs_DS(dbcx);
            scsx = new SharedComponents(dbcx);

            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void chkbSpecificEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbSpecificStaff.Checked)
            {
                lblEmployee.Visible = true;
                cbStaff.Visible = true;
            }
            else 
            {
                lblEmployee.Visible = false;
                cbStaff.Visible = false;            
            }
        }

        private void F_AttendanceView_Load(object sender, EventArgs e)
        {
            lblEmployee.Visible = false;
            cbStaff.Visible = false;

            cbAttendanceType.SelectedIndex = 0;
            XX_PopulateEmployeeComboBoxWithEmployeeDetails();
        }

        private void XX_PopulateEmployeeComboBoxWithEmployeeDetails()
        { 
                                        string szSQL = string.Empty;
                                        string szEmployeeData = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bEndOfFind = false;
                                        Fields fds = null;

            while(true)
            {
                s_dsx.GetFirstRecordFromDataBase(ref fds,
                                                 ref bEndOfFind,
                                                 ref bErrorFound,
                                                 ref szErrorMessage);

                if (bEndOfFind)
                {
                    utsx.ShowMessage("Nothing Found",
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                while (true)
                {
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

                    szEmployeeData = fds.ItemIsField("StaffId").StringValue
                                   + "."
                                   + fds.ItemIsField("Surname").StringValue
                                   + "."
                                   + fds.ItemIsField("OtherNames").StringValue
                                   + "."
                                   + fds.ItemIsField("IdentificationNumber").StringValue;

                    cbStaff.Items.Add(szEmployeeData);
                    s_dsx.GetNextRecordFromDataBase(ref fds,
                                                    ref bEndOfFind,
                                                    ref bErrorFound,
                                                    ref szErrorMessage);

                }

                break;
            }
            
            cbStaff.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
                                        string szSQL = string.Empty;
                                        string szAttendanceType = string.Empty;
                                        long lAttendanceType = 0;
                                        string szEmployeeId = string.Empty;
                                        MySqlDataReader msql_dr = null;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        DataGridViewRow dgvRow = null;
                                        double dHourlyRate = 0;
                                        double dAttendanceAmount = 0;
                                        double dGrossSalary = 0;
                                        double dMultiplier = 0;

            XX_RefreshDataGridView();
            szAttendanceType= cbAttendanceType.SelectedIndex.ToString();

            szSQL = " SELECT attendance.AttendanceId, "
                  + "        attendance.AttendanceType, "
                  + "        attendance.Date, "
                  + "        attendance.Hours, "
                  + "        staffs.StaffId, "
                  + "        staffs.Surname, "
                  + "        staffs.OtherNames, "
                  + "        staffs.IdentificationNumber, "
                  + "        staffs.BasicSalary "
                  + " FROM attendance "
                  + " INNER JOIN staffs ON Staffs.StaffId = attendance.EmployeeId ";

            if (szAttendanceType != "0")
            {
                szSQL = szSQL
                      + " WHERE AttendanceType = " + szAttendanceType;
            }

            if (chkbSpecificStaff.Checked)
            {
                szEmployeeId = cbStaff.SelectedItem.ToString()[0].ToString();
                szSQL = szSQL
                      + " AND staffs.StaffId = " + szEmployeeId;
            }

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref msql_dr);

            while (true)
            {
                if (msql_dr == null)
                {
                    break;
                }

                while(msql_dr.Read() == true)
                {
                    try
                    {
                        
                        dgvRow = (DataGridViewRow)dgvAttendanceView.Rows[0].Clone();
                        dgvRow.Cells[0].Value = msql_dr["AttendanceId"].ToString();
                        dgvRow.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        
                        lAttendanceType = Convert.ToInt32(msql_dr["AttendanceType"].ToString());

                        switch (lAttendanceType)
                        {
                            case 1:
                                szAttendanceType = "Extra";
                                dMultiplier = 1;
                                break;

                            case 2:
                                szAttendanceType = "Absent";
                                dMultiplier = -1;
                                break;
                        }

                        dgvRow.Cells[1].Value = szAttendanceType;
                        dgvRow.Cells[2].Value = msql_dr["Date"].ToString();
                        dgvRow.Cells[3].Value = msql_dr["Hours"].ToString();
                        dgvRow.Cells[3].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        dgvRow.Cells[4].Value = msql_dr["StaffId"].ToString();
                        dgvRow.Cells[4].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        dgvRow.Cells[5].Value = msql_dr["Surname"].ToString();
                        dgvRow.Cells[6].Value = msql_dr["OtherNames"].ToString();
                        dgvRow.Cells[7].Value = msql_dr["IdentificationNumber"].ToString();

                        dGrossSalary = Convert.ToDouble(msql_dr["BasicSalary"].ToString());
                        dgvRow.Cells[8].Value = dGrossSalary.ToString("0.00");
                        dgvRow.Cells[8].Style.Alignment = DataGridViewContentAlignment.BottomRight;

                        dHourlyRate = dGrossSalary
                                    / (scsx.HoursPerDay * scsx.WorkDaysPerMonth);

                        dgvRow.Cells[9].Value = dHourlyRate.ToString("0.00");
                        dgvRow.Cells[9].Style.Alignment = DataGridViewContentAlignment.BottomRight;

                        dAttendanceAmount = dHourlyRate 
                                          * Convert.ToDouble(msql_dr["Hours"].ToString())
                                          * dMultiplier;
                        dgvRow.Cells[10].Value = dAttendanceAmount.ToString("0.00");
                        dgvRow.Cells[10].Style.Alignment = DataGridViewContentAlignment.BottomRight;

                        dgvAttendanceView.Rows.Add(dgvRow);
                    }
                    catch
                    {

                    }
                }
                break;
            }

            XX_DisplayTotals();
            if (!msql_dr.IsClosed)
            {
                msql_dr.Close();
                msql_dr.Dispose();
            }
        }

        private void XX_RefreshDataGridView()
        {
            dgvAttendanceView.Rows.Clear();
            dgvAttendanceView.Refresh();
        }

        private void XX_DisplayTotals()
        {
                                        string szHours = string.Empty;
                                        double dHours = 0;
                                        string szAttendanceAmount = string.Empty;
                                        double dAttendanceAmount = 0;
                                        int nRowsCount = 0;

            foreach(DataGridViewRow dgvr in dgvAttendanceView.Rows)
            {
                if (dgvr.Cells[3].Value != null)
                {
                    szHours = dgvr.Cells[3].Value.ToString();

                    if (szHours.Trim() != "")
                    {
                        dHours = dHours
                               + Convert.ToDouble(szHours);
                    }
                }

                if (dgvr.Cells[10].Value != null)
                {
                    szAttendanceAmount = dgvr.Cells[10].Value.ToString();

                    if (szAttendanceAmount.Trim() != "")
                    {
                        dAttendanceAmount = dAttendanceAmount
                                          + Convert.ToDouble(szAttendanceAmount);
                    }
                }
            }

            nRowsCount = dgvAttendanceView.Rows.Count;

            DataGridViewCellStyle dgvcs = new DataGridViewCellStyle();
            
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[0].Value = "Totals";
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[0].Style.Font = new Font("Calibri", 9, FontStyle.Bold);
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomLeft; 
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[3].Value = dHours.ToString();
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[3].Style.Font = new Font("Calibri", 9, FontStyle.Bold);
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[3].Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[10].Value = dAttendanceAmount.ToString();
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[10].Style.Font = new Font("Calibri", 9, FontStyle.Bold);
            dgvAttendanceView.Rows[nRowsCount - 1].Cells[10].Style.Alignment = DataGridViewContentAlignment.BottomRight; 
            
        }
    }
}
