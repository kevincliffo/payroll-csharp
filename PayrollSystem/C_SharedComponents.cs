using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;
using CollectionClasses;
using System.Windows;
using System.Drawing;
using CustomGrid;

namespace PayRollSystem
{
public class SharedComponents
{
    private Utilities.Utilities utsx = null;
    private DatabaseConnection dbcx = null;
    private Defaults_DS ds_dsx = null;
    private Defaults dsx = null;
    private FileAccessor fax = null;

    private const string szxEMPTY = "";

    public SharedComponents()
    {
        utsx = new Utilities.Utilities();
        fax = new FileAccessor();
    }

    public SharedComponents(DatabaseConnection dbcv)
    {
        dbcx = dbcv;
        utsx = new Utilities.Utilities();
        fax = new FileAccessor();

        ds_dsx = new Defaults_DS(dbcx);
        ds_dsx.GetAllDefaults(ref dsx);
    }

    public void CheckIfEditableControlValuesAreValid(Control.ControlCollection ccv,
                                                     ref bool brEmptyTextBoxFound,
                                                     ref string szrControlDescription)
    {
                                        bool bTextBoxEmpty = false;
                                        bool bEmptyTextBoxFound = false;
                                        string szControlDescription = string.Empty;

        foreach (Control c in ccv)
        {
            while (true)
            {
                if ((c is TextBox == false) && (c is ComboBox == false))
                {
                    break;
                }

                if (c.Tag != null)
                {
                    if ((bool)c.Tag == true)
                    {
                        break;
                    }
                }

                bTextBoxEmpty = c.Text == szxEMPTY;

                if (bTextBoxEmpty)
                {
                    bEmptyTextBoxFound = true;
                    szControlDescription = c.Name;
                    break;
                }

                break;
            }
        }

        brEmptyTextBoxFound = bEmptyTextBoxFound;
        szrControlDescription = szControlDescription;
    }

    public double WorkDaysPerMonth
    {
        get {
            return Convert.ToDouble(dsx.ItemIsDefault("WorkDaysPerMonth").Value);
        }
    }

    public double HoursPerDay
    {
        get
        {
            return Convert.ToDouble(dsx.ItemIsDefault("HoursPerDay").Value);
        }
    }

    public void CalculateHourlyRate(double dvSalary,
                                    Utilities.EnumsCollection.EnumHourlyRateCalculationType ehrctv,
                                    ref double drHourlyRate)
    {
                                        double dWorkDaysPerMonth = 0;
                                        double dHoursPerDay = 0;
                                        double dHourlyRate = 0;

        dWorkDaysPerMonth = Convert.ToDouble(dsx.ItemIsDefault("WorkDaysPerMonth").Value);
        dHoursPerDay = Convert.ToDouble(dsx.ItemIsDefault("HoursPerDay").Value);

        switch (ehrctv)
        {
            case EnumsCollection.EnumHourlyRateCalculationType.ehrctMonthly:
                dHourlyRate = dvSalary
                            / (dWorkDaysPerMonth * dHoursPerDay);
                break;

            case EnumsCollection.EnumHourlyRateCalculationType.ehrctWeekly:
                dHourlyRate = dvSalary
                            / dHoursPerDay;
                break;
        }

        drHourlyRate = dHourlyRate;
    }

    public void GetNSSFAmountPayableOverGrossSalary(double dvGrossSalary,
                                                    ref double drNSSFAmountPayable)
    {
                                        NSSFRates nssfrs = new NSSFRates();
                                        double dNSSFAmountPayable = 0;
    
        XX_GetNSSFratesCollection(ref nssfrs);

        foreach (NSSFRate nssfr in nssfrs)
        {
            if (dvGrossSalary <= nssfr.EmployeeEarnings)
            {
                dNSSFAmountPayable = nssfr.TierOneEmployeeDeductions;
                break;
            }
        }

        drNSSFAmountPayable = dNSSFAmountPayable;
    }

    public void GetNHIFAmountPayableOverGrossSalary(double dvGrossSalary,
                                                    ref double drNHIFAmountPayable)
    {
                                        NHIFRates nhifrs = new NHIFRates();
                                        double dNHIFAmountPayable = 0;

        XX_GetNHIFRatesCollection(ref nhifrs);

        foreach (NHIFRate nhifr in nhifrs)
        {
            if (dvGrossSalary >= nhifr.From && dvGrossSalary <= nhifr.To)
            {
                dNHIFAmountPayable = nhifr.Rate;
            }
        }

        drNHIFAmountPayable = dNHIFAmountPayable;
    }

    public void GetNSSFratesCollection(ref NSSFRates nssfrsr)
    {
        XX_GetNSSFratesCollection(ref nssfrsr);
    }

    private void XX_GetNSSFratesCollection(ref NSSFRates nssfrsr)
    {
                                    NSSFRate nssfr = null;
                                    NSSFRates nssfrs = new NSSFRates();
                                    string szSectionName = string.Empty;
                                    string szSectionPrefix = "Key";
                                    long lCounter = 1;
                                    string szId = string.Empty;
                                    string szFrom = string.Empty;
                                    string szTo = string.Empty;
                                    string szRate = string.Empty;
                                    bool bValueNotFound = false;
                                    bool bSectionExists = false;
                                    string szEmployeeEarnings = string.Empty;
                                    string szPensionableEarnings = string.Empty;
                                    string szTierOnePensionableEarnings = string.Empty;
                                    string szTierOneEmployeeDeductions = string.Empty;
                                    string szTierOneEmployerContribution = string.Empty;
                                    string szTierOneTotalContribution = string.Empty;
                                    string szTierTwoPensionableEarnings = string.Empty;
                                    string szTierTwoEmployeeDeductions = string.Empty;
                                    string szTierTwoEmployerContribution = string.Empty;
                                    string szTierTwoTotalContribution = string.Empty;
                                    string szTotalPensionContribution = string.Empty;

        fax.ConnectToFile(dbcx.ApplicationPathCarrier.TablesPath + "\\NSSFRates.tbl",
                          EnumsCollection.EnumFileAccessType.efatRead);
        
        while (true)
        {
            szSectionName = szSectionPrefix
                            + "_"
                            + Convert.ToString(lCounter);

            bSectionExists = fax.Sections.KeyExist(szSectionName);

            if (bSectionExists == false)
            {
                break;
            }

            nssfrs.AddNSSFRate(szSectionName,
                               ref nssfr);

            fax.GetValue(szSectionName,
                         "EmployeeEarnings",
                         ref szEmployeeEarnings,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "PensionableEarnings",
                         ref szPensionableEarnings,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierOnePensionableEarnings",
                         ref szTierOnePensionableEarnings,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierOneEmployeeDeductions",
                         ref szTierOneEmployeeDeductions,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierOneEmployerContribution",
                         ref szTierOneEmployerContribution,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierOneTotalContribution",
                         ref szTierOneTotalContribution,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierTwoPensionableEarnings",
                         ref szTierTwoPensionableEarnings,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierTwoEmployeeDeductions",
                         ref szTierTwoEmployeeDeductions,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierTwoEmployerContribution",
                         ref szTierTwoEmployerContribution,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TierTwoTotalContribution",
                         ref szTierTwoTotalContribution,
                         ref bValueNotFound);

            fax.GetValue(szSectionName,
                         "TotalPensionContribution",
                         ref szTotalPensionContribution,
                         ref bValueNotFound);               

            nssfr.Key = Convert.ToString(lCounter);
            nssfr.EmployeeEarnings = Convert.ToDouble(utsx.Replace(szEmployeeEarnings, ",", ""));
            nssfr.PensionableEarnings = Convert.ToDouble(utsx.Replace(szPensionableEarnings, ",", ""));
            nssfr.TierOnePensionableEarnings = Convert.ToDouble(utsx.Replace(szTierOnePensionableEarnings, ",", ""));
            nssfr.TierOneEmployeeDeductions = Convert.ToDouble(utsx.Replace(szTierOneEmployeeDeductions, ",", ""));
            nssfr.TierOneEmployerContribution = Convert.ToDouble(utsx.Replace(szTierOneEmployerContribution, ",", ""));
            nssfr.TierOneTotalContribution = Convert.ToDouble(utsx.Replace(szTierOneTotalContribution, ",", ""));
            nssfr.TierTwoPensionableEarnings = Convert.ToDouble(utsx.Replace(szTierTwoPensionableEarnings, ",", ""));
            nssfr.TierTwoEmployeeDeductions = Convert.ToDouble(utsx.Replace(szTierTwoEmployeeDeductions, ",", ""));
            nssfr.TierTwoEmployerContribution = Convert.ToDouble(utsx.Replace(szTierTwoEmployerContribution, ",", ""));
            nssfr.TierTwoTotalContribution = Convert.ToDouble(utsx.Replace(szTierTwoTotalContribution, ",", ""));
            nssfr.TotalPensionContribution = Convert.ToDouble(utsx.Replace(szTotalPensionContribution, ",", ""));

            lCounter = lCounter + 1;
        }

        nssfrsr = nssfrs;
    }

    public void GetNHIFRatesCollection(ref NHIFRates nhifrsr)
    {
        XX_GetNHIFRatesCollection(ref nhifrsr);
    }

    private void XX_GetNHIFRatesCollection(ref NHIFRates nhifrsr)
    {
                                    NHIFRate nhifr = null;
                                    NHIFRates nhifrs = new NHIFRates();
                                    string szSectionName = string.Empty;
                                    string szSectionPrefix = "Key";
                                    long lCounter = 1;
                                    string szId = string.Empty;
                                    string szFrom = string.Empty;
                                    string szTo = string.Empty;
                                    string szRate = string.Empty;
                                    bool bValueNotFound = false;
                                    bool bSectionExists = false;

        fax.ConnectToFile(dbcx.ApplicationPathCarrier.TablesPath + "\\NHIFRates.tbl",
                            EnumsCollection.EnumFileAccessType.efatRead);

        while (true)
        {
            szSectionName = szSectionPrefix
                            + "_"
                            + Convert.ToString(lCounter);

            bSectionExists = fax.Sections.KeyExist(szSectionName);

            if (bSectionExists == false)
            {
                break;
            }

            nhifrs.AddNHIFRate(szSectionName,
                                ref nhifr);

            fax.GetValue(szSectionName,
                            "Id",
                            ref szId,
                            ref bValueNotFound);

            fax.GetValue(szSectionName,
                            "From",
                            ref szFrom,
                            ref bValueNotFound);

            fax.GetValue(szSectionName,
                            "To",
                            ref szTo,
                            ref bValueNotFound);

            fax.GetValue(szSectionName,
                            "Rate",
                            ref szRate,
                            ref bValueNotFound);

            nhifr.Key = szId;
            nhifr.NHIFRateId = Convert.ToInt16(szId);
            nhifr.From = Convert.ToDouble(szFrom);
            nhifr.To = Convert.ToDouble(szTo);
            nhifr.Rate = Convert.ToDouble(szRate);

            lCounter = lCounter + 1;
        }

        nhifrsr = nhifrs;
    }

    public void MoveControlValuesToFields(Form fv,
                                          ref Fields fdsr)
    {
                                        string szFieldKey = string.Empty;

        foreach (Control ctr in fv.Controls)
        {
            switch (ctr.GetType().ToString())
            {
                case "TextBox":
                    utsx.GetRightPartOfStringOverIndex(ctr.Name,
                                                       3,
                                                       ref szFieldKey);
                    break;

                case "ComboBox":

                    break;

                case "DateTimePicker":

                    break;

                case "CheckBox":

                    break;
            }
        }
    }

    public void DataGridRowHasEmptyCell(DataGridViewRow dgvvRow,
                                        ref bool brRowHasEmptyCell)
    {
                                    DataGridViewCell dgvCell = null;
                                    bool bRowHasEmptyCell = false;

        for (int nCellIndex = 0; nCellIndex <= dgvvRow.Cells.Count - 1; nCellIndex++)
        {
            dgvCell = dgvvRow.Cells[nCellIndex];

            if (dgvCell.Value == null)
            {
                bRowHasEmptyCell = true;
                break;
            }
        }
        brRowHasEmptyCell = bRowHasEmptyCell;
    }

    public void MoveDataGridRowValuesToFields(DataGridViewRow dgvRow,
                                              ref Fields fdsr)
    {
        foreach (DataGridViewCell dgvc in dgvRow.Cells)
        {
            foreach (Field fd in fdsr)
            {
                if (dgvc.OwningColumn.Name == fd.Key)
                {
                    fd.StringValue = Convert.ToString(dgvc.Value);
                    break;
                }
            }
        }

    }

    public void ClearDataGridView(DataGridView dgv)
    {
                                        Dictionary<string, string> dictItemsColumns = new Dictionary<string, string>();

        dictItemsColumns = (Dictionary<string, string>)dgv.Tag;

        for (int nRow = dgv.Rows.Count - 2; nRow >= 0; nRow--)
        {
            dgv.Rows.RemoveAt(nRow);
        }

        foreach (DataGridViewCell dgvc in dgv.Rows[0].Cells)
        {
            dgvc.Value = null;
        }

        //foreach (KeyValuePair<string, string> kvpColumn in dictItemsColumns)
        //{
        //    dgv.Columns.Add(kvpColumn.Key, kvpColumn.Value);
        //}
    }

    public void MoveFieldValuesToCustomGridGridRow(CustomDataGrid cdgGrid,
                                                   Fields fdsv,
                                                   bool bvSetRowAsDisabled = false)
    {
                                        GridRow grRow = new GridRow();
                                        string[] aszFieldValues;

            aszFieldValues = new string[fdsv.FieldCount];
            foreach (Field fd in fdsv)
            {
                aszFieldValues[fd.Index - 1] = (fd.StringValue);
            }

            grRow.CreateCells(cdgGrid, aszFieldValues);
            cdgGrid.Rows.Add(grRow);

            foreach (Field fd in fdsv)
            {
                grRow.Cells[fd.Index-1].ReadOnly = true;
                grRow.Cells[fd.Index-1].Style.BackColor = Color.LightBlue;

                switch (fd.EnumFieldType)
                {
                    case EnumsCollection.EnumFieldType.eftDouble:
                    case EnumsCollection.EnumFieldType.eftInteger:
                    case EnumsCollection.EnumFieldType.eftLong:
                        grRow.Cells[fd.Index - 1].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                        break;
                }
            }
            aszFieldValues = null;
        }

    public void MoveFieldsValuesToDataGridRow(DataGridView dgv,
                                              DataGridViewRow dgvRow,
                                              Fields fdsv,
                                              bool bvSetRowAsDisabled = false)
    {

        foreach (Field fd in fdsv)
        {
            while (true)
            {
                if (dgv.Columns.Contains(fd.Key) == false)
                {
                    break;
                }

                if (dgv.Columns[fd.Key].Visible == false)
                {
                    break;
                }

                try
                {
                    dgvRow.Cells[dgv.Columns[fd.Key].Index].Value = fd.StringValue;

                    if (bvSetRowAsDisabled)
                    {
                        dgvRow.Cells[dgv.Columns[fd.Key].Index].ReadOnly = true;
                        dgvRow.Cells[dgv.Columns[fd.Key].Index].Style.BackColor = Color.LightBlue;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            }
        }
    }

    public void FormatDataGridViewCells(Fields fdsv,
                                        DataGridView dgv)
    {
                                        Tags tgs = new Tags();
                                        Tag t = null;
                                        int nColumnIndex = 0;

        dgv.AutoResizeColumns();

        foreach (Field fd in fdsv)
        {
            while (true)
            {
                if (dgv.Columns.Contains(fd.Key) == false)
                {
                    break;
                }

                if (dgv.Columns[fd.Key].Visible == false)
                {
                    break;
                }

                switch (fd.EnumFieldType)
                {
                    case EnumsCollection.EnumFieldType.eftDouble:
                    case EnumsCollection.EnumFieldType.eftInteger:
                    case EnumsCollection.EnumFieldType.eftLong:
                        tgs.AddTag(Convert.ToString(tgs.TagCount + 1),
                                   ref t);

                        t.StringValue1 = fd.Key;
                        t.StringValue2 = Convert.ToString(fd.Index - 1);
                        break;
                }

                break;
            }
        }

        foreach (Tag tag in tgs)
        {
            while (true)
            {
                if (dgv.Columns.Contains(tag.StringValue1) == false)
                {
                    break;
                }

                if (dgv.Columns[tag.StringValue1].Visible == false)
                {
                    break;
                }

                nColumnIndex = Convert.ToInt32(tag.StringValue2);
                try
                {
                    dgv.Columns[tag.StringValue1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            }
        }

        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;    
    }
}
}
