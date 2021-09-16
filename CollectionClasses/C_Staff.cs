using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class Staff
{
    private Staffs ssxParent = null;
    private int nxrwIndex = 0;
    private string szxrwKey = string.Empty;
    private int nxrwStaffId = 0;
    private string szxrwSurname = string.Empty;
    private string szxrwOtherNames = string.Empty;
    private string szxrwIdentificationNumber = string.Empty;
    private string szxrwMobileNo = string.Empty;
    private string szxrwEmailAddress = string.Empty;
    private string szxrwEmploymentDate = string.Empty;
    private string szxrwDepartment = string.Empty;
    private string szxrwSubDepartment = string.Empty;
    private string szxrwEmployeeType = string.Empty;
    private string szxrwAddress = string.Empty;
    private string szxrwKRAPin = string.Empty;
    private string szxrwNHIFNumber = string.Empty;
    private string szxrwNSSFNumber = string.Empty;
    private double dxrwBasicSalary = 0;
    private string szxrwNextOfKinName = string.Empty;
    private string szxrwNextOfKinMobileNumber = string.Empty;
    private string szxrwNextOfKinEmail = string.Empty;
    private double dxrwNHIFAmountPayable = 0;
    private double dxrwNSSFAmountPayable = 0;
    private double dxrwPayeDeduction = 0;
    private double dxrwHouseAllowance = 0;
    private double dxrwMedicalAllowance = 0;
    private double dxrwTravelAllowance = 0;
    private double dxrwPension = 0;
    private double dxrwBalanceBroughtForward = 0;

    public Staffs ParentIsStaffs
    {
        get
        {
            return ssxParent;
        }
        set
        {
            ssxParent = value;
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

    public int StaffId
    {
        get
        {
            return nxrwStaffId;
        }
        set
        {
            nxrwStaffId = value;
        }
    }

    public string Surname
    {
        get
        {
            return szxrwSurname;
        }
        set
        {
            szxrwSurname = value;
        }
    }

    public string OtherNames
    {
        get
        {
            return szxrwOtherNames;
        }
        set
        {
            szxrwOtherNames = value;
        }
    }

    public string IdentificationNumber
    {
        get
        {
            return szxrwIdentificationNumber;
        }
        set
        {
            szxrwIdentificationNumber = value;
        }
    }

    public string MobileNo
    {
        get
        {
            return szxrwMobileNo;
        }
        set
        {
            szxrwMobileNo = value;
        }
    }

    public string EmailAddress
    {
        get
        {
            return szxrwEmailAddress;
        }
        set
        {
            szxrwEmailAddress = value;
        }
    }

    public string EmploymentDate
    {
        get
        {
            return szxrwEmploymentDate;
        }
        set
        {
            szxrwEmploymentDate = value;
        }
    }

    public string Department
    {
        get
        {
            return szxrwDepartment;
        }
        set
        {
            szxrwDepartment = value;
        }
    }

    public string SubDepartment
    {
        get
        {
            return szxrwSubDepartment;
        }
        set
        {
            szxrwSubDepartment = value;
        }
    }

    public string EmployeeType
    {
        get
        {
            return szxrwEmployeeType;
        }
        set
        {
            szxrwEmployeeType = value;
        }
    }

    public string Address
    {
        get
        {
            return szxrwAddress;
        }
        set
        {
            szxrwAddress = value;
        }
    }

    public string KRAPin
    {
        get
        {
            return szxrwKRAPin;
        }
        set
        {
            szxrwKRAPin = value;
        }
    }

    public string NHIFNumber
    {
        get
        {
            return szxrwNHIFNumber;
        }
        set
        {
            szxrwNHIFNumber = value;
        }
    }

    public string NSSFNumber
    {
        get
        {
            return szxrwNSSFNumber;
        }
        set
        {
            szxrwNSSFNumber = value;
        }
    }

    public double BasicSalary
    {
        get
        {
            return dxrwBasicSalary;
        }
        set
        {
            dxrwBasicSalary = value;
        }
    }

    public string NextOfKinName
    {
        get
        {
            return szxrwNextOfKinName;
        }
        set
        {
            szxrwNextOfKinName = value;
        }
    }

    public string NextOfKinMobileNumber
    {
        get
        {
            return szxrwNextOfKinMobileNumber;
        }
        set
        {
            szxrwNextOfKinMobileNumber = value;
        }
    }

    public string NextOfKinEmail
    {
        get
        {
            return szxrwNextOfKinEmail;
        }
        set
        {
            szxrwNextOfKinEmail = value;
        }
    }

    public double NHIFAmountPayable
    {
        get
        {
            return dxrwNHIFAmountPayable;
        }
        set
        {
            dxrwNHIFAmountPayable = value;
        }
    }

    public double NSSFAmountPayable
    {
        get
        {
            return dxrwNSSFAmountPayable;
        }
        set
        {
            dxrwNSSFAmountPayable = value;
        }
    }

    public double PayeDeduction
    {
        get
        {
            return dxrwPayeDeduction;
        }
        set
        {
            dxrwPayeDeduction = value;
        }
    }

    public double HouseAllowance
    {
        get
        {
            return dxrwHouseAllowance;
        }
        set
        {
            dxrwHouseAllowance = value;
        }
    }

    public double MedicalAllowance
    {
        get
        {
            return dxrwMedicalAllowance;
        }
        set
        {
            dxrwMedicalAllowance = value;
        }
    }

    public double TravelAllowance
    {
        get
        {
            return dxrwTravelAllowance;
        }
        set
        {
            dxrwTravelAllowance = value;
        }
    }

    public double Pension
    {
        get
        {
            return dxrwPension;
        }
        set
        {
            dxrwPension = value;
        }
    }

    public double BalanceBroughtForward
    {
        get
        {
            return dxrwBalanceBroughtForward;
        }
        set
        {
            dxrwBalanceBroughtForward = value;
        }
    }
}
}