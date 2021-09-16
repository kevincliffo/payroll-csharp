using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class SubDepartment
{
    private SubDepartments sdsxParent = null;
    private int nxrwIndex = 0;
    private string szxrwKey = string.Empty;
    private int nxrwDepartmentId = 0;
    private string szxrwDepartmentName = string.Empty;
    private int nxrwSubDepartmentId = 0;
    private string szxrwSubDepartmentName = string.Empty;

    public SubDepartments ParentIsSubDepartments
    {
        get
        {
            return sdsxParent;
        }
        set
        {
            sdsxParent = value;
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

    public int DepartmentId
    {
        get
        {
            return nxrwDepartmentId;
        }
        set
        {
            nxrwDepartmentId = value;
        }
    }

    public string DepartmentName
    {
        get
        {
            return szxrwDepartmentName;
        }
        set
        {
            szxrwDepartmentName = value;
        }
    }

    public int SubDepartmentId
    {
        get
        {
            return nxrwSubDepartmentId;
        }
        set
        {
            nxrwSubDepartmentId = value;
        }
    }

    public string SubDepartmentName
    {
        get
        {
            return szxrwSubDepartmentName;
        }
        set
        {
            szxrwSubDepartmentName = value;
        }
    }

}
}