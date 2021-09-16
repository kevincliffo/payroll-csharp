using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace Utilities
{
public class FormItem
{
    private FormItems fisxParent = null;
    private string szxrwKey = string.Empty;
    private long lxrwIndex = 0;
    private EnumsCollection.EnumFormType eftxrw = new EnumsCollection.EnumFormType();
    private string szxrwFormName = string.Empty;
    private string szxrwGroupFormName = string.Empty;

    public FormItems ParentIsFormItems
    {
        get
        {
            return fisxParent;
        }
        set
        {
            fisxParent = value;
        }
    }

    public EnumsCollection.EnumFormType EnumFormType
    {
        get 
        {
            return eftxrw;
        }
        set 
        {
            eftxrw = value;
        }
    }

    public string FormName
    {
        get
        {
            return szxrwFormName;
        }
        set
        {
            szxrwFormName = value;
        }
    }

    public string GroupFormName
    {
        get
        {
            return szxrwGroupFormName;
        }
        set
        {
            szxrwGroupFormName = value;
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
    public long Index
    {
        get
        {
            return lxrwIndex;
        }
        set
        {
            lxrwIndex = value;
        }
    }
}
}