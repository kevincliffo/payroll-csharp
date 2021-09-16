using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
public class Defaults : IEnumerable
{
    private ArrayList collx = null;

    public Defaults()
    {
        collx = new ArrayList();
    }

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }

    public void AddDefault(string szvKey,
                               ref Default dr)
    {
                                        Default d = new Default();
        collx.Add(d);
        d.Key = szvKey;
        d.Index = collx.Count;
        d.ParentIsDefaults = this;

        dr = d;
    }

    public Default ItemIsDefault(string szvKey)
    {
                                        bool bDefaultFound = false;
                                        Default obj = null;
        foreach (Default d in collx)
        {
            bDefaultFound = d.Key == szvKey;

            if (bDefaultFound)
            {
                obj = d;
                break;
            }
        }
        
        return obj;
    }

    public long DefaultCount
    {
        get
        {
            return Convert.ToInt64(collx.Count);
        }
    }

    public bool KeyExist(string szvKey)
    {
                                        bool bDefaultFound = false;

        foreach (Default d in collx)
        {
            bDefaultFound = d.Key == szvKey;

            if (bDefaultFound)
            {
                break;
            }
        }

        return bDefaultFound;
    }

    public void RemoveDefaults(string szvKey)
    {
        collx.Remove(szvKey);
    }

    public void RemoveDefaults(long lvIndex)
    {
        collx.Remove(lvIndex);
    }

    public void RemoveAllDefaults()
    {
        collx.Clear();
    }

    ~Defaults()
    {
        collx.Clear();
    }

}
}
