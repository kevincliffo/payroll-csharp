using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class Tag
{
    private Tags tsxParent = null;
    private int nxrwIndex = 0;
    private string szxrwKey = string.Empty;
    private string szxrwStringValue1 = string.Empty;
    private string szxrwStringValue2 = string.Empty;
    private bool bxrwBool = false;

    public Tags ParentIsTags
    {
        get
        {
            return tsxParent;
        }
        set
        {
            tsxParent = value;
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

    public string StringValue1
    {
        get
        {
            return szxrwStringValue1;
        }
        set
        {
            szxrwStringValue1 = value;
        }
    }

    public string StringValue2
    {
        get
        {
            return szxrwStringValue2;
        }
        set
        {
            szxrwStringValue2 = value;
        }
    }

    public bool Bool
    {
        get
        {
            return bxrwBool;
        }
        set
        {
            bxrwBool = value;
        }
    }

}
}