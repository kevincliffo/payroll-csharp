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
using MySql.Data.MySqlClient;

namespace PayRollSystem
{
    public partial class F_PayrollCasual : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Staffs_DS s_dsx = null;
        private Payrolls_DS p_dsx = null;
        private Utilities.Utilities utsx = null;
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Staffs ssx = null;
        private SharedComponents scsx = null;
        private PAYECalculator pcx = null;

        public F_PayrollCasual(Form mdivForm,
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
            p_dsx = new Payrolls_DS(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtRegularTime.Text = (Convert.ToDouble(txtMonday.Text)
                                + Convert.ToDouble(txtTuesday.Text)
                                + Convert.ToDouble(txtWednesday.Text)
                                + Convert.ToDouble(txtThursday.Text)
                                + Convert.ToDouble(txtFriday.Text)).ToString("0.00");

            txtOvertimeTime.Text = (Convert.ToDouble(txtSaturday.Text)
                                 + Convert.ToDouble(txtSunday.Text)).ToString("0.00");

            txtRegularPayAmount.Text = (Convert.ToDouble(txtHourlySalary.Text) * (Convert.ToDouble(txtRegularTime.Text))).ToString("0.00");
            txtOvertimePayAmount.Text = (Convert.ToDouble(txtHourlySalary.Text) * (Convert.ToDouble(txtOvertimeTime.Text)) * 1.1).ToString("0.00");

            txtGrossSalary.Text = (Convert.ToDouble(txtRegularPayAmount.Text)
                               + Convert.ToDouble(txtOvertimePayAmount.Text)).ToString("0.00");

            txtBalanceBroughtForward.Text = (Convert.ToDouble(txtAmountPaid.Text) - Convert.ToDouble(txtNetSalary.Text)).ToString("0.00");
            XX_CalculateNetSalary(Convert.ToDouble(txtGrossSalary.Text));

            btnPrint.Enabled = true;
        }

        private void XX_CalculateNetSalary(double dvGrossSalary)
        {
                                        double dTaxDeduction = 0;
                                        double dNHIFAmountPayable = 0;
                                        double dNSSFAmountPayable = 0;
                                        double dTotalDeductions = 0;
                                        double dNetSalary = 0;
                                        Staff s = null;
                                        string szStaffName = string.Empty;
                                        string szStaffId = string.Empty;

            XX_SplitComboBoxStringValue(cbStaffName.Text,
                                        ref szStaffId,
                                        ref szStaffName);

            s = ssx.ItemIsStaff(szStaffId);
            pcx.GetTaxDeductionOverGrossSalary(dvGrossSalary,
                                               ref dTaxDeduction);
            dTaxDeduction = dTaxDeduction / 4;
            s.PayeDeduction = dTaxDeduction;

            scsx.GetNHIFAmountPayableOverGrossSalary(dvGrossSalary,
                                                     ref dNHIFAmountPayable);
            dNHIFAmountPayable = dNHIFAmountPayable / 4;
            s.NHIFAmountPayable = dNHIFAmountPayable;

            scsx.GetNSSFAmountPayableOverGrossSalary(dvGrossSalary,
                                                     ref dNSSFAmountPayable);
            dNSSFAmountPayable = dNSSFAmountPayable / 4;
            s.NSSFAmountPayable = dNSSFAmountPayable;

            dTotalDeductions = dNHIFAmountPayable
                             + dNSSFAmountPayable
                             + dTaxDeduction;

            dNetSalary = dvGrossSalary
                       - dTotalDeductions;

            txtNetSalary.Text = dNetSalary.ToString("0.00");

        }

        private void F_PayrollCasual_Load(object sender, EventArgs e)
        {
            XX_AddStaffToComboBox();
            cbStaffName.SelectedIndexChanged += new EventHandler(cbStaffName_SelectedIndexChanged);
            btnPrint.Enabled = false;
            btnCalculate.Enabled = false;
        }

        void cbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
                                        ComboBox cb = (ComboBox)sender;

            switch(cb.Name)
            {
                case "cbStaffName":
                    btnCalculate.Enabled = true;
                    XX_DisplayAdditionalData();
                    break;
            }
        }

        private void XX_DisplayAdditionalData()
        {
                                        string szStaffId = string.Empty;
                                        Staff s = null;
                                        double dGrossSalary = 0;
                                        double dHourlyRate = 0;

            szStaffId = cbStaffName.Text.Substring(0, 1);

            s = ssx.ItemIsStaff(szStaffId);

            dGrossSalary = Convert.ToDouble(s.BasicSalary);
            scsx.CalculateHourlyRate(dGrossSalary,
                                     EnumsCollection.EnumHourlyRateCalculationType.ehrctWeekly,
                                     ref dHourlyRate);

            txtHourlySalary.Text = dHourlyRate.ToString("0.00");
            txtDepartment.Text = s.Department;
            txtSubDepartment.Text = s.SubDepartment;
            txtBalanceBroughtForward.Text = Convert.ToString(s.BalanceBroughtForward);
        }

        private void XX_SplitComboBoxStringValue(string szvStringValue,
                                                 ref string szrStaffId,
                                                 ref string szrStaffName)
        { 
                                        string szStaffName = string.Empty;
                                        string szStaffId = string.Empty;

            szStaffName = utsx.Right(szvStringValue, (szvStringValue.Length - 4));
            szStaffId = szvStringValue.Substring(0, 1);

            szrStaffId = szStaffId;
            szrStaffName = szStaffName;        
        }

        private void XX_AddPayRollToDataBase()
        {
                                        Fields fds = null;
                                        Staff s = null;
                                        string szName = string.Empty;
                                        string szStaffId = string.Empty;
                                        string szDate = string.Empty;
                                        string szTime = string.Empty;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            fds = p_dsx.Fields;                       
            
            XX_SplitComboBoxStringValue(cbStaffName.Text,
                                        ref szStaffId,
                                        ref szName);

            s = ssx.ItemIsStaff(szStaffId);
            fds.ItemIsField("StaffId").StringValue = szStaffId;
            fds.ItemIsField("StaffName").StringValue = szName;
            fds.ItemIsField("Department").StringValue = txtDepartment.Text;
            fds.ItemIsField("SubDepartment").StringValue = txtSubDepartment.Text;

            utsx.GetDateStringValueOverDate(DateTime.Now,
                                            ref szDate,
                                            ref szTime);

            fds.ItemIsField("Date").StringValue = szDate;
            fds.ItemIsField("HouseAllowance").StringValue = "0.00";
            fds.ItemIsField("TravelAllowance").StringValue = "0.00";
            fds.ItemIsField("MedicalAllowance").StringValue = "0.00";
            fds.ItemIsField("AllowanceTotal").StringValue = "0.00";
            fds.ItemIsField("NHIF").StringValue = s.NHIFAmountPayable.ToString("0.00");
            fds.ItemIsField("NSSF").StringValue = s.NSSFAmountPayable.ToString("0.00");
            fds.ItemIsField("Pension").StringValue = "0.00";
            fds.ItemIsField("PAYE").StringValue = s.PayeDeduction.ToString("0.00");
            fds.ItemIsField("GrossSalary").StringValue = txtGrossSalary.Text;
            fds.ItemIsField("NetSalary").StringValue = txtNetSalary.Text;

            fds.ItemIsField("EmployeeType").StringValue = Convert.ToString((long)EnumsCollection.EnumEmploymentType.eetCasual);
            fds.ItemIsField("BalanceBroughtForward").StringValue = txtBalanceBroughtForward.Text;
            fds.ItemIsField("AmountPaid").StringValue = txtAmountPaid.Text;

            p_dsx.AddToDataBase(fds,
                                ref bErrorFound,
                                ref szErrorMessage);

            //XX_PrintReport(null);
        }

        private void XX_GetLatestBalanceBroughtForwardForSelectedStaff(long lvStaffId,
                                                                       ref double drBalanceBroughtForward)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        MySqlDataReader mysql_dr = null;
                                        double dBalanceBroughtForward = 0;

            szSQL = "SELECT BalanceBroughtForward FROM payrolls WHERE StaffId = " + Convert.ToString(lvStaffId) + " ORDER BY PayRollId DESC LIMIT 1";

            while (true)
            {
                dbcx.ExecuteSQL(szSQL,
                                ref bErrorFound,
                                ref szErrorMessage,
                                ref mysql_dr);

                while (true)
                {
                    if (mysql_dr == null)
                    {
                        break;
                    }

                    if (!mysql_dr.Read())
                    {
                        break;
                    }

                    dBalanceBroughtForward = Convert.ToDouble(mysql_dr["BalanceBroughtForward"].ToString());
                    break;
                }

                if (mysql_dr != null)
                {
                    mysql_dr.Close();
                    mysql_dr.Dispose();
                    mysql_dr = null;
                }

                break;
            }

            drBalanceBroughtForward = dBalanceBroughtForward;
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
                                        double dBalanceBroughtForward = 0;

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

                    if (fds.ItemIsField("EmployeeType").StringValue == "Casual")
                    {
                        ssx.AddStaff(fds.ItemIsField("StaffId").StringValue,
                                     ref s);

                        s.EmployeeType = fds.ItemIsField("EmployeeType").StringValue;
                        s.Surname = fds.ItemIsField("Surname").StringValue;
                        s.OtherNames = fds.ItemIsField("OtherNames").StringValue;
                        s.StaffId = Convert.ToInt16(fds.ItemIsField("StaffId").StringValue);
                        s.Department = fds.ItemIsField("Department").StringValue;
                        s.SubDepartment = fds.ItemIsField("SubDepartment").StringValue;
                        s.BasicSalary = Convert.ToDouble(fds.ItemIsField("BasicSalary").StringValue);

                        XX_GetLatestBalanceBroughtForwardForSelectedStaff(s.StaffId,
                                                                          ref dBalanceBroughtForward);

                        s.BalanceBroughtForward = dBalanceBroughtForward;

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XX_AddPayRollToDataBase();
        }
    }
}
