using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class Default
{
    private Defaults dsxParent = null;
    private string szxrwxKey = string.Empty;
    private long lxrwxIndex = 0;
    private long lxrwDefaultId = 0;
    private string szxrwDefaultName = string.Empty;
    private string szxrwDefaultDescription = string.Empty;
    private string szxrwValue = string.Empty;

    public Defaults ParentIsDefaults
    {
        get
        {
            return dsxParent;
        }
        set
        {
            dsxParent = value;
        }
    }

    public string Key
    {
        get
        {
            return szxrwxKey;
        }
        set
        {
            szxrwxKey = value;
        }
    }
    public long Index
    {
        get
        {
            return lxrwxIndex;
        }
        set
        {
            lxrwxIndex = value;
        }
    }
    public long DefaultId
    {
        get
        {
            return lxrwDefaultId;
        }
        set
        {
            lxrwDefaultId = value;
        }
    }
    public string DefaultName
    {
        get
        {
            return szxrwDefaultName;
        }
        set
        {
            szxrwDefaultName = value;
        }
    }
    public string DefaultDescription
    {
        get
        {
            return szxrwDefaultDescription;
        }
        set
        {
            szxrwDefaultDescription = value;
        }
    }
    public string Value
    {
        get
        {
            return szxrwValue;
        }
        set
        {
            szxrwValue = value;
        }
    }

}
}