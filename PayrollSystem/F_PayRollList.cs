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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace PayRollSystem
{
    public partial class F_PayRollList : Form
    {
        private Utilities.Utilities utsx = null;
        private Form mdixForm = null;
        private DatabaseConnection dbcx = null;
        private const string szxEMPTY = "";
        private ApplicationPathCarrier apcx = null;
        
        private Staffs_DS s_dsx = null;
        private Defaults_DS d_dsx = null;
        private PAYECalculator pcx = null;
        private Payrolls_DS pr_dsx = null;
        private PayrollsList_DS prl_dsx = null;
        private Defaults dsx = null;
        private ToolStripStatusLabel tsslx = null;
        private Attendance_DS a_dsx = null;
        private SharedComponents scx = null;

        public F_PayRollList(Form mdivForm,
                                   ToolStripStatusLabel tsslv,
                                   DatabaseConnection dbcv)
        {
            InitializeComponent();
            apcx = new ApplicationPathCarrier(Application.StartupPath);
            utsx = new Utilities.Utilities();
            pcx = new PAYECalculator();
            dsx = new Defaults();
            tsslx = tsslv;

            mdixForm = mdivForm;
            dbcx = dbcv;
            s_dsx = new Staffs_DS(dbcx);
            d_dsx = new Defaults_DS(dbcx);
            pr_dsx = new Payrolls_DS(dbcx);
            prl_dsx = new  PayrollsList_DS(dbcx);
            a_dsx = new Attendance_DS(dbcx);
            scx = new SharedComponents(dbcx);
            
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_PayRollDeductions_Load(object sender, EventArgs e)
        {

                                        Fields fds = new Fields();
                                        Fields fdsDummy = new Fields();
                                        DataGridViewRow dgvRow = new DataGridViewRow();
                                        bool bEndOfFind = false;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szValue = string.Empty;

            dgvEmployeeDetails.AllowUserToResizeColumns = true;
            chkSelect.CheckedChanged += new EventHandler(chkSelect_CheckedChanged);

            fds = s_dsx.Fields;
            fdsDummy = s_dsx.Fields;

            while (true)
            {
                s_dsx.GetFirstRecordFromDataBase(ref fds,
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

                dgvRow = (DataGridViewRow)dgvEmployeeDetails.Rows[0].Clone();
                scx.MoveFieldsValuesToDataGridRow(dgvEmployeeDetails,
                                                   dgvRow,
                                                   fds);

                XX_AddAdditionalValuesToDataGridViewRow(fds,
                                                        dgvRow);
                dgvEmployeeDetails.Rows.Add(dgvRow);

                while (true)
                {
                    s_dsx.GetNextRecordFromDataBase(ref fds,
                                                     ref bEndOfFind,
                                                     ref bErrorFound,
                                                     ref szErrorMessage);
                    if (bEndOfFind)
                    {
                        break;

                    }

                    dgvRow = (DataGridViewRow)dgvEmployeeDetails.Rows[0].Clone();

                    scx.MoveFieldsValuesToDataGridRow(dgvEmployeeDetails,
                                                       dgvRow,
                                                       fds);

                    XX_AddAdditionalValuesToDataGridViewRow(fds,
                                                            dgvRow);
                    dgvEmployeeDetails.Rows.Add(dgvRow);
                }

                break;
            }

            scx.FormatDataGridViewCells(fdsDummy,
                                        dgvEmployeeDetails);

            cbEmployeeType.SelectedIndex = 0;
        }

        private void XX_AddAdditionalValuesToDataGridViewRow(Fields fdsv,
                                                             DataGridViewRow dgvRow)
        {
                                        string szDate = string.Empty;
                                        string szTime = string.Empty;
                                        double dHouseAllowance = 0;
                                        double dMedicalAllowance = 0;
                                        double dTravelAllowance = 0;
                                        double dTotalAllowance = 0;
                                        double dGrossSalary = 0;
                                        double dNHIF = 0;
                                        double dNSSF = 0;
                                        double dPAYE = 0;
                                        double dTotalDeductions = 0;
                                        double dPension = 0;
                                        double dNetSalary = 0;

            dgvRow.Cells[dgvEmployeeDetails.Columns["StaffName"].Index].Value = fdsv.ItemIsField("Surname").StringValue
                                                                              + " "
                                                                              + fdsv.ItemIsField("OtherNames").StringValue;

            utsx.GetDateStringValueOverDate(DateTime.Now,
                                            ref szDate,
                                            ref szTime);
            dgvRow.Cells[dgvEmployeeDetails.Columns["Date"].Index].Value = szDate;
            dgvRow.Cells[dgvEmployeeDetails.Columns["GrossSalary"].Index].Value = fdsv.ItemIsField("BasicSalary").StringValue;
            dgvEmployeeDetails.Columns["GrossSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dHouseAllowance = Convert.ToDouble(fdsv.ItemIsField("HouseAllowance").StringValue);
            dTravelAllowance = Convert.ToDouble(fdsv.ItemIsField("TravelAllowance").StringValue);
            dMedicalAllowance = Convert.ToDouble(fdsv.ItemIsField("MedicalAllowance").StringValue);
            
            dTotalAllowance = dHouseAllowance
                            + dTravelAllowance;

            dGrossSalary = Convert.ToDouble(fdsv.ItemIsField("BasicSalary").StringValue);
            dGrossSalary = dGrossSalary
                         + dTotalAllowance;
            
            dgvRow.Cells[dgvEmployeeDetails.Columns["TotalAllowance"].Index].Value = dTotalAllowance.ToString("0.00");
            dgvEmployeeDetails.Columns["TotalAllowance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            scx.GetNHIFAmountPayableOverGrossSalary(dGrossSalary,
                                                    ref dNHIF);
            dgvRow.Cells[dgvEmployeeDetails.Columns["NHIF"].Index].Value = dNHIF.ToString("0.00");
            dgvEmployeeDetails.Columns["NHIF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            scx.GetNSSFAmountPayableOverGrossSalary(dGrossSalary,
                                                    ref dNSSF);
            dgvRow.Cells[dgvEmployeeDetails.Columns["NSSF"].Index].Value = dNSSF.ToString("0.00");
            dgvEmployeeDetails.Columns["NSSF"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            pcx.GetTaxDeductionOverGrossSalary(dGrossSalary,
                                               ref dPAYE);
            dgvRow.Cells[dgvEmployeeDetails.Columns["PAYE"].Index].Value = dPAYE.ToString("0.00");
            dgvEmployeeDetails.Columns["PAYE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dPension = Convert.ToDouble(fdsv.ItemIsField("Pension").StringValue);
            dTotalDeductions = dNSSF
                             + dNHIF
                             + dPension;

            dNetSalary = dGrossSalary
                       + dMedicalAllowance
                       - (dPAYE + dTotalDeductions);
            dgvRow.Cells[dgvEmployeeDetails.Columns["NetSalary"].Index].Value = dNetSalary.ToString("0.00");
            dgvEmployeeDetails.Columns["NetSalary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
                                        bool bChecked = false;

            bChecked = ((CheckBox)sender).Checked;

            switch (bChecked)
            { 
                case true:
                    dgvEmployeeDetails.SelectAll();
                    break;

                case false:
                    dgvEmployeeDetails.ClearSelection();
                    break;
            }
        }
 
        private void XX_AddPayRollsToDataBaseOverSelectedRow(DataGridViewRow dgvr)
        {
                                        Fields fds = null;
                                        string szDate = string.Empty;
                                        string szTime = string.Empty;
                                        string szMessage = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
            
            fds = prl_dsx.Fields;

            fds.ItemIsField("StaffId").StringValue = Convert.ToString(dgvr.Cells[0].Value);
            fds.ItemIsField("StaffName").StringValue = Convert.ToString(dgvr.Cells[1].Value);
            fds.ItemIsField("Department").StringValue = Convert.ToString(dgvr.Cells[2].Value);
            fds.ItemIsField("SubDepartment").StringValue = Convert.ToString(dgvr.Cells[3].Value);
            fds.ItemIsField("Date").StringValue = Convert.ToString(dgvr.Cells[4].Value); ;
            fds.ItemIsField("HouseAllowance").StringValue = Convert.ToString(dgvr.Cells[5].Value);
            fds.ItemIsField("TravelAllowance").StringValue = Convert.ToString(dgvr.Cells[6].Value);
            fds.ItemIsField("MedicalAllowance").StringValue = Convert.ToString(dgvr.Cells[7].Value);
            fds.ItemIsField("AllowanceTotal").StringValue = Convert.ToString(dgvr.Cells[8].Value);
            fds.ItemIsField("NHIF").StringValue = Convert.ToString(dgvr.Cells[9].Value);
            fds.ItemIsField("NSSF").StringValue = Convert.ToString(dgvr.Cells[10].Value);
            fds.ItemIsField("Pension").StringValue = Convert.ToString(dgvr.Cells[11].Value);
            fds.ItemIsField("PAYE").StringValue = Convert.ToString(dgvr.Cells[12].Value);
            fds.ItemIsField("GrossSalary").StringValue = Convert.ToString(dgvr.Cells[13].Value);
            fds.ItemIsField("NetSalary").StringValue = Convert.ToString(dgvr.Cells[14].Value);

            szMessage = "Employee " + fds.ItemIsField("StaffId").StringValue
                      + " added successfully";

            prl_dsx.AddToDataBase(fds,
                                  ref bErrorFound,
                                  ref szErrorMessage);

            if (bErrorFound)
            {
                szMessage = szErrorMessage;
            }

            tsslx.Text = szMessage;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
                                        ArrayList collRowsIndex = new ArrayList();
                                        bool bRowHasEmptyCell = false;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        DataGridViewRow dgvRow = null;

            while(true)
            {
                prl_dsx.RemoveAllFromDataBase(ref bErrorFound,
                                              ref szErrorMessage);

                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                foreach (DataGridViewRow dgvr in dgvEmployeeDetails.SelectedRows)
                {
                    scx.DataGridRowHasEmptyCell(dgvr,
                                                ref bRowHasEmptyCell);

                    if (bRowHasEmptyCell == false)
                    {
                        collRowsIndex.Add(dgvr.Index);
                    }
                }

                for (int nDataGridRowIndex = 0; nDataGridRowIndex <= dgvEmployeeDetails.Rows.Count;nDataGridRowIndex++ )
                {
                    foreach (int nRowIndex in collRowsIndex)
                    {
                        if (nDataGridRowIndex == nRowIndex)
                        {
                            dgvRow = dgvEmployeeDetails.Rows[nDataGridRowIndex];

                            XX_AddPayRollsToDataBaseOverSelectedRow(dgvRow);
                        }
                    }

                }
                break;
            }

            if (bErrorFound == false)
            {
                XX_PrintReports();
            }
        }

        private void XX_PrintReports()
        {
                                        string szReportPath = string.Empty;
                                        F_ReportViewer f_Viewer = new F_ReportViewer(dbcx);
                                        ReportDocument doc = new ReportDocument();
                                        DataSet ds = null;
                                        DataTable dtReport = new DataTable();
                                        Reports.ReportDataSets.dsPayRoll dsPayRoll = new Reports.ReportDataSets.dsPayRoll();
                                        string szSQL = string.Empty;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            szSQL = "SELECT * FROM PayRollsList";
            dtReport.TableName = "PayRoll";
            dbcx.ExecuteSQL(szSQL,
                            ref ds,
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

                dtReport = ds.Tables[0];
                dsPayRoll.Tables[0].Merge(dtReport);

                szReportPath = dbcx.ApplicationPathCarrier.ReportsPath
                                + @"\crPayRoll.rpt";
                doc.Load(szReportPath);

                doc.SetDataSource(dsPayRoll);
                f_Viewer.LaunchReport("PayRoll",
                                        doc);

                f_Viewer.Show();
                break;
            }
        }

        private void X_GetHighestAndLowestEmployeeIdOverCollection(ArrayList collvEmployeeIds,
                                                                   ref long lrHighestEmployeeId,
                                                                   ref long lrLowestEmployeeId)
        {
                                        long lHighestEmployeeId = 0;
                                        long lLowestEmployeeId = 0;

            foreach(long lEmployeeId in collvEmployeeIds)
            {
                if (lEmployeeId <= lLowestEmployeeId)
                {
                    lLowestEmployeeId = lEmployeeId;
                }
            }

            foreach (long lEmployeeId in collvEmployeeIds)
            {
                if (lEmployeeId >= lHighestEmployeeId)
                {
                    lHighestEmployeeId = lEmployeeId;
                }
            }

            lrHighestEmployeeId = lHighestEmployeeId;
            lrLowestEmployeeId = lLowestEmployeeId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
