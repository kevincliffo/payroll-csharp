using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class Supplier
{
    private Suppliers ssxParent = null;
    private int nxrwIndex = 0;
    private string szxrwKey = string.Empty;
    private int nxrwSupplierId = 0;
    private string szxrwSupplierCode = string.Empty;
    private string szxrwSupplierName = string.Empty;
    private string szxrwMobileNumber = string.Empty;
    private string szxrwEmail = string.Empty;
    private string szxrwAddress = string.Empty;
    private string szxrwTown = string.Empty;
    private string szxrwCity = string.Empty;
    private string szxrwCountry = string.Empty;

    public Suppliers ParentIsSuppliers
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

    public int SupplierId
    {
        get
        {
            return nxrwSupplierId;
        }
        set
        {
            nxrwSupplierId = value;
        }
    }

    public string SupplierCode
    {
        get
        {
            return szxrwSupplierCode;
        }
        set
        {
            szxrwSupplierCode = value;
        }
    }

    public string SupplierName
    {
        get
        {
            return szxrwSupplierName;
        }
        set
        {
            szxrwSupplierName = value;
        }
    }

    public string MobileNumber
    {
        get
        {
            return szxrwMobileNumber;
        }
        set
        {
            szxrwMobileNumber = value;
        }
    }

    public string Email
    {
        get
        {
            return szxrwEmail;
        }
        set
        {
            szxrwEmail = value;
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

    public string Town
    {
        get
        {
            return szxrwTown;
        }
        set
        {
            szxrwTown = value;
        }
    }

    public string City
    {
        get
        {
            return szxrwCity;
        }
        set
        {
            szxrwCity = value;
        }
    }

    public string Country
    {
        get
        {
            return szxrwCountry;
        }
        set
        {
            szxrwCountry = value;
        }
    }

}
}