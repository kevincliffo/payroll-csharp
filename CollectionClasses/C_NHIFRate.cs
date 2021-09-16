using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
public class NHIFRate
{
    private NHIFRates fssxParent = null;
    private string szxrwKey = string.Empty;
    private long lxrwIndex = 0;
    private int nxrwNHIFRateId = 0;
    private double dxrwFrom = 0;
    private double dxrwTo = 0;
    private double dxrwRate = 0;

    public NHIFRates ParentIsNHIFRates
    {
        get
        {
            return fssxParent;
        }
        set
        {
            fssxParent = value;
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

    public int NHIFRateId
    {
        get
        {
            return nxrwNHIFRateId;
        }
        set
        {
            nxrwNHIFRateId = value;
        }
    }

    public double From
    {
        get
        {
            return dxrwFrom;
        }
        set
        {
            dxrwFrom = value;
        }
    }

    public double To
    {
        get
        {
            return dxrwTo;
        }
        set
        {
            dxrwTo = value;
        }
    }

    public double Rate
    {
        get
        {
            return dxrwRate;
        }
        set
        {
            dxrwRate = value;
        }
    }
}
}