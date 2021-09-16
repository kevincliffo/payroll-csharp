using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using Models;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using Reports;

namespace PayRollSystem
{
    public partial class F_Payroll : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Staffs_DS s_dsx = null;
        private PayrollsList_DS p_dsx = null;
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Staffs ssx = null;
        private SharedComponents scsx = null;
        private PAYECalculator pcx = null;

        public F_Payroll(Form mdivForm,
                         DatabaseConnection dbcv,
                         
                         Fields fdsvUpdateFields,
                         EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            pcx = new PAYECalculator();
            utsx = new Utilities.Utilities();
            mdixParent = mdivForm;
            
            ssx = new Staffs();
            scsx = new SharedComponents(dbcx);

            s_dsx = new Staffs_DS(dbcx);
            p_dsx = new PayrollsList_DS(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void XX_AddStaffToComboBox()
        { 
                                        ArrayList collStaffs = new ArrayList();
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        bool bNothingFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szName = string.Empty;
                                        Staff s = null;

            while(true)
            {
                fds = s_dsx.Fields;
                s_dsx.GetFirstRecordFromDataBase(ref fds,
                                                 ref bNothingFound,
                                                 ref bErrorFound,
                                                 ref szErrorMessage);

                if (bErrorFound)
                {
                    utsx.ShowMessage(szErrorMessage,
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                while (true)
                {
                    if (bNothingFound)
                    {
                        break;
                    }

                    if (fds.ItemIsField("EmployeeType").StringValue == "Permanent")
                    {
                        ssx.AddStaff(fds.ItemIsField("StaffId").StringValue,
                                     ref s);

                        s.Surname = fds.ItemIsField("Surname").StringValue;
                        s.OtherNames = fds.ItemIsField("OtherNames").StringValue;
                        s.StaffId = Convert.ToInt16(fds.ItemIsField("StaffId").StringValue);
                        s.Department = fds.ItemIsField("Department").StringValue;
                        s.SubDepartment = fds.ItemIsField("SubDepartment").StringValue;
                        s.BasicSalary = Convert.ToDouble(fds.ItemIsField("BasicSalary").StringValue);
                        s.TravelAllowance = Convert.ToDouble(fds.ItemIsField("TravelAllowance").StringValue);
                        s.HouseAllowance = Convert.ToDouble(fds.ItemIsField("HouseAllowance").StringValue);
                        s.MedicalAllowance = Convert.ToDouble(fds.ItemIsField("MedicalAllowance").StringValue);
                        s.Pension = Convert.ToDouble(fds.ItemIsField("Pension").StringValue);

                        szName = Convert.ToString(s.StaffId)
                               + " - "
                               + s.Surname
                               + " "
                               + s.OtherNames;

                        collStaffs.Add(szName);
                    }

                    s_dsx.GetNextRecordFromDataBase(ref fds,
                                                    ref bNothingFound,
                                                    ref bErrorFound,
                                                    ref szErrorMessage);
                }
                break;
            }

            cbStaffName.Items.Clear();
            foreach (string szDepartment in collStaffs)
            {
                cbStaffName.Items.Add(szDepartment);
            }

            if (collStaffs.Count > 0)
            {
                cbStaffName.SelectedIndex = 0;
            }
        }

        private void F_Payroll_Load(object sender, EventArgs e)
        {
            btnCalculate.Visible = false; 
            XX_AddStaffToComboBox();
            cbStaffName.SelectedIndexChanged += new EventHandler(cbStaffName_SelectedIndexChanged);
            XX_EnableButtons(false);
        }

        private void XX_EnableButtons(bool bvEnable)
        {
            btnCalculate.Enabled = bvEnable;
            btnPrint.Enabled = bvEnable;
        }

        void cbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
                                        ComboBox cb = (ComboBox)sender;

            switch(cb.Name)
            {
                case "cbStaffName":
                    XX_DisplayAdditionalDataAfterComboBoxSelected();
                    XX_EnableButtons(true);
                    break;
            }
        }

        private void XX_DisplayAdditionalDataAfterComboBoxSelected()
        { 
                                        string szStaffId = string.Empty;
                                        Staff s = null;
                                        double dGrossSalary = 0;
                                        double dHourlyRate = 0;
                                        double dTaxDeduction = 0;
                                        double dNHIFAmountPayable = 0;
                                        double dNSSFAmountPayable = 0;
                                        double dTotalDeductions = 0;
                                        double dNetSalary = 0;
                                        double dTotalBenefits = 0;

            szStaffId = cbStaffName.Text.Substring(0, 1);

            s = ssx.ItemIsStaff(szStaffId);
            txtStaffId.Text = Convert.ToString(s.StaffId);
            txtDepartment.Text = s.Department;
            txtSubDepartment.Text = s.SubDepartment;
            txtGrossSalary.Text = s.BasicSalary.ToString("0.00");

            txtHouseAllowance.Text = s.HouseAllowance.ToString("0.00");
            txtMedicalAllowance.Text = s.MedicalAllowance.ToString("0.00");
            txtTravelAllowance.Text = s.TravelAllowance.ToString("0.00");

            dTotalBenefits = Convert.ToDouble(txtHouseAllowance.Text)
                           + Convert.ToDouble(txtTravelAllowance.Text);
            txtTotalBenefits.Text = dTotalBenefits.ToString("0.00");

            dGrossSalary = Convert.ToDouble(txtGrossSalary.Text);

            dGrossSalary = dGrossSalary
                         + (Convert.ToDouble(txtTotalBenefits.Text));

            scsx.CalculateHourlyRate(dGrossSalary, 
                                     EnumsCollection.EnumHourlyRateCalculationType.ehrctMonthly,
                                     ref dHourlyRate);

            txtPayRatePerHour.Text = dHourlyRate.ToString("0.00");

            pcx.GetTaxDeductionOverGrossSalary(dGrossSalary,
                                               ref dTaxDeduction);

            txtPaye.Text = dTaxDeduction.ToString("0.00");

            scsx.GetNHIFAmountPayableOverGrossSalary(dGrossSalary,
                                                     ref dNHIFAmountPayable);
            txtNHIF.Text = dNHIFAmountPayable.ToString("0.00");

            scsx.GetNSSFAmountPayableOverGrossSalary(dGrossSalary,
                                                     ref dNSSFAmountPayable);
            txtNSSF.Text = dNSSFAmountPayable.ToString("0.00");
            txtPension.Text = s.Pension.ToString("0.00");

            dTotalDeductions = Convert.ToDouble(txtNSSF.Text)
                             + Convert.ToDouble(txtNHIF.Text)
                             + Convert.ToDouble(txtPension.Text);

            txtTotalDeductions.Text = dTotalDeductions.ToString("0.00");
            txtPayrollDeductions.Text = txtTotalDeductions.Text;

            dNetSalary = dGrossSalary
                       + Convert.ToDouble(txtMedicalAllowance.Text)
                       - (dTaxDeduction + dTotalDeductions);

            txtBenefits.Text = txtTotalBenefits.Text;
            
            txtNetSalary.Text = dNetSalary.ToString("0.00");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
                                        double dTotalBenefits = 0;
                                        double dTotalDeductions = 0;
                                        double dNetSalary = 0;
                                        double dGrossSalary = 0;

            dTotalBenefits = Convert.ToDouble(txtHouseAllowance.Text)
                           + Convert.ToDouble(txtTravelAllowance.Text)
                           + Convert.ToDouble(txtMedicalAllowance.Text);
            txtTotalBenefits.Text = dTotalBenefits.ToString("0.00");

            dTotalDeductions = Convert.ToDouble(txtNSSF.Text)
                             + Convert.ToDouble(txtNHIF.Text)
                             + Convert.ToDouble(txtPension.Text);
            txtTotalDeductions.Text = dTotalDeductions.ToString("0.00");
            txtPayrollDeductions.Text = txtTotalDeductions.Text;
            txtBenefits.Text = txtTotalBenefits.Text;

            dGrossSalary = Convert.ToDouble(txtGrossSalary.Text);
            dNetSalary = dGrossSalary
                       + Convert.ToDouble(txtBenefits.Text)
                       - (Convert.ToDouble(txtPaye.Text) + dTotalDeductions);
            txtNetSalary.Text = dNetSalary.ToString("0.00");
        }

        private void XX_AddDataTodataBase()
        { 
                                        Fields fds = null;
                                        string szName = string.Empty;
                                        string szDate = string.Empty;
                                        string szTime = string.Empty;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            p_dsx.RemoveAllFromDataBase(ref bErrorFound,
                                        ref szErrorMessage);
            fds = p_dsx.Fields;

            fds.ItemIsField("StaffId").StringValue = txtStaffId.Text;

            XX_GetStaffNameOverComboBoxString(cbStaffName.Text,
                                              ref szName);
            fds.ItemIsField("StaffName").StringValue = szName;
            fds.ItemIsField("Department").StringValue = txtDepartment.Text;
            fds.ItemIsField("SubDepartment").StringValue = txtSubDepartment.Text;

            utsx.GetDateStringValueOverDate(DateTime.Now,
                                            ref szDate,
                                            ref szTime);
            fds.ItemIsField("Date").StringValue = szDate;
            fds.ItemIsField("HouseAllowance").StringValue = txtHouseAllowance.Text;
            fds.ItemIsField("TravelAllowance").StringValue = txtTravelAllowance.Text;
            fds.ItemIsField("MedicalAllowance").StringValue = txtMedicalAllowance.Text;
            fds.ItemIsField("AllowanceTotal").StringValue = txtTravelAllowance.Text;
            fds.ItemIsField("NHIF").StringValue = txtNHIF.Text;
            fds.ItemIsField("NSSF").StringValue = txtNSSF.Text;
            fds.ItemIsField("Pension").StringValue = txtPension.Text;
            fds.ItemIsField("PAYE").StringValue = txtPaye.Text;
            fds.ItemIsField("GrossSalary").StringValue = txtGrossSalary.Text;
            fds.ItemIsField("NetSalary").StringValue = txtNetSalary.Text;
            fds.ItemIsField("EmployeeType").StringValue = Convert.ToString((long)EnumsCollection.EnumEmploymentType.eetPermanent);

            p_dsx.AddToDataBase(fds,
                                ref bErrorFound,
                                ref szErrorMessage);

            XX_PrintReport(null);

        }

        private void XX_GetHighestAndLowestEmployeeIdOverCollection(ArrayList collvEmployeeIds,
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

        private void XX_PrintReport(ArrayList collEmployeeIds)
        {
                                        string szReportPath = string.Empty;
                                        F_ReportViewer f_Viewer = new F_ReportViewer(dbcx);
                                        ReportDocument doc = new ReportDocument();
                                        DataSet ds = null;
                                        DataTable dtReport = new DataTable();
                                        Reports.ReportDataSets.dsPayRoll dsPayRoll = new Reports.ReportDataSets.dsPayRoll();
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "SELECT * FROM PayRolls";
            dtReport.TableName = "Payrolls";
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

        private void XX_GetStaffNameOverComboBoxString(string szvValue,
                                                       ref string szrName)
        { 
                                        string szName = string.Empty;
            
            szName = utsx.Right(szvValue, (szvValue.Length - 4));

            szrName = szName;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XX_AddDataTodataBase();
        }
    }
}
