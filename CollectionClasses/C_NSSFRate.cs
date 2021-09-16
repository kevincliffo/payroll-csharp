using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class NSSFRate
{
    private NSSFRates nssfrsxParent = null;
    private int nxrwIndex = 0;
    private string szxrwKey = string.Empty;
    private double dxrwEmployeeEarnings = 0;
    private double dxrwPensionableEarnings = 0;
    private double dxrwTierOnePensionableEarnings = 0;
    private double dxrwTierOneEmployeeDeductions = 0;
    private double dxrwTierOneEmployerContribution = 0;
    private double dxrwTierOneTotalContribution = 0;
    private double dxrwTierTwoPensionableEarnings = 0;
    private double dxrwTierTwoEmployeeDeductions = 0;
    private double dxrwTierTwoEmployerContribution = 0;
    private double dxrwTierTwoTotalContribution = 0;
    private double dxrwTotalPensionContribution = 0;

    public NSSFRates ParentIsNSSFRates
    {
        get
        {
            return nssfrsxParent;
        }
        set
        {
            nssfrsxParent = value;
        }
    }

    public string Key
    {
        get
        {
            return szxrwKey;
        }
        set
        {
            szxrwKey = value;
        }
    }

    public int Index
    {
        get
        {
            return nxrwIndex;
        }
        set
        {
            nxrwIndex = value;
        }
    }

    public double EmployeeEarnings
    {
        get
        {
            return dxrwEmployeeEarnings;
        }
        set
        {
            dxrwEmployeeEarnings = value;
        }
    }
    public double PensionableEarnings
    {
        get
        {
            return dxrwPensionableEarnings;
        }
        set
        {
            dxrwPensionableEarnings = value;
        }
    }
    public double TierOnePensionableEarnings
    {
        get
        {
            return dxrwTierOnePensionableEarnings;
        }
        set
        {
            dxrwTierOnePensionableEarnings = value;
        }
    }
    public double TierOneEmployeeDeductions
    {
        get
        {
            return dxrwTierOneEmployeeDeductions;
        }
        set
        {
            dxrwTierOneEmployeeDeductions = value;
        }
    }
    public double TierOneEmployerContribution
    {
        get
        {
            return dxrwTierOneEmployerContribution;
        }
        set
        {
            dxrwTierOneEmployerContribution = value;
        }
    }
    public double TierOneTotalContribution
    {
        get
        {
            return dxrwTierOneTotalContribution;
        }
        set
        {
            dxrwTierOneTotalContribution = value;
        }
    }
    public double TierTwoPensionableEarnings
    {
        get
        {
            return dxrwTierTwoPensionableEarnings;
        }
        set
        {
            dxrwTierTwoPensionableEarnings = value;
        }
    }
    public double TierTwoEmployeeDeductions
    {
        get
        {
            return dxrwTierTwoEmployeeDeductions;
        }
        set
        {
            dxrwTierTwoEmployeeDeductions = value;
        }
    }
    public double TierTwoEmployerContribution
    {
        get
        {
            return dxrwTierTwoEmployerContribution;
        }
        set
        {
            dxrwTierTwoEmployerContribution = value;
        }
    }
    public double TierTwoTotalContribution
    {
        get
        {
            return dxrwTierTwoTotalContribution;
        }
        set
        {
            dxrwTierTwoTotalContribution = value;
        }
    }
    public double TotalPensionContribution
    {
        get
        {
            return dxrwTotalPensionContribution;
        }
        set
        {
            dxrwTotalPensionContribution = value;
        }
    }
}
}