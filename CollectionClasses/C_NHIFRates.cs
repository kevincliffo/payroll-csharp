using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
public class NHIFRates : IEnumerable
{
    private ArrayList collx = null;

    public NHIFRates()
    {
        collx = new ArrayList();
    }

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }

    public void AddNHIFRate(string szvKey,
                            ref NHIFRate nhifrr)
    {
                                        NHIFRate nhifr = new NHIFRate();
        collx.Add(nhifr);
        nhifr.Key = szvKey;
        nhifr.Index = collx.Count;
        nhifr.ParentIsNHIFRates = this;

        nhifrr = nhifr;
    }

    public NHIFRate ItemIsNHIFRate(string szvKey)
    {
                                        bool bNHIFRateFound = false;
                                        NHIFRate obj = null;

        foreach (NHIFRate nhifr in collx)
        {
            bNHIFRateFound = nhifr.Key == szvKey;

            if (bNHIFRateFound)
            {
                obj = nhifr;
                break;
            }
        }

        return obj;
    }

    public long NHIFRateCount
    {
        get
        {
            return Convert.ToInt64(collx.Count);
        }
    }

    public bool KeyExist(string szvKey)
    {
                                        bool bNHIFRateFound = false;

        foreach (NHIFRate nhifr in collx)
        {
            bNHIFRateFound = nhifr.Key == szvKey;

            if (bNHIFRateFound)
            {
                break;
            }
        }

        return bNHIFRateFound;
    }

    public void RemoveNHIFRates(string szvKey)
    {
        collx.Remove(szvKey);
    }

    public void RemoveNHIFRates(long lvIndex)
    {
        collx.Remove(lvIndex);
    }

    public void RemoveAllNHIFRates()
    {
        collx.Clear();
    }

    ~NHIFRates()
    {
        collx.Clear();
    }

}
}