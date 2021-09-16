using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace CollectionClasses
{
public class ControlObject
{
    private ControlObjects cosxParent = null;
    private string szxrwxKey = string.Empty;
    private long lxrwxIndex = 0;
    private Control cx = null;
    private bool bxrwByPassControl = false;

    public bool ByPassControl
    {
        get
        {
            return bxrwByPassControl;
        }
        set
        {
            bxrwByPassControl = value;
        }
    }

    public Control Control
    {
        get
        {
            return cx;
        }
        set
        {
            cx = value;
        }
    }

    public ControlObjects ParentIsControlObjects
    {
        get
        {
            return cosxParent;
        }
        set
        {
            cosxParent = value;
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