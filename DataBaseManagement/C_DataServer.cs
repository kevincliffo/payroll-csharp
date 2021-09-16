using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseManagement
{
public class DataServer
{
    private DataServers dssxParent = null;
    private string szxrwxKey = string.Empty;
    private long lxrwxIndex = 0;
    private dynamic dyxDataServerObject = null;

    public DataServers ParentIsDataServers
    {
        get
        {
            return dssxParent;
        }
        set
        {
            dssxParent = value;
        }
    }

    public dynamic DataServerObject
    {
        get
        {
            return dyxDataServerObject;
        }
        set
        {
            dyxDataServerObject = value;
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
}
}