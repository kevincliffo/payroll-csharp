using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class Module
{
    private Modules msxParent = null;
    private string szxrwxKey = string.Empty;
    private long lxrwxIndex = 0;
    private string szxrwModuleName = string.Empty;
    private bool bxrwModuleEnabled = false;

    public Modules ParentIsModules
    {
        get
        {
            return msxParent;
        }
        set
        {
            msxParent = value;
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
    public string ModuleName
    {
        get
        {
            return szxrwModuleName;
        }
        set
        {
            szxrwModuleName = value;
        }
    }
    public bool ModuleEnabled
    {
        get
        {
            return bxrwModuleEnabled;
        }
        set
        {
            bxrwModuleEnabled = value;
        }
    }
}
}