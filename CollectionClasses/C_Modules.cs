using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
public class Modules : IEnumerable
{
    private ArrayList collx = null;

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }
    public Modules() {

        collx = new  ArrayList();
    }

    public void AddModule(string szvKey,
                          ref Module mor) {

                        Module m = new Module();
                        
        collx.Add(m);

        m.Key = szvKey;
        m.Index = collx.Count;
        m.ParentIsModules = this;
    
        mor = m;
    }

    public Module ItemIsModule(string szvKey)
    {
                                        bool bDefaultFound = false;
                                        Module obj = null;

        foreach (Module mod in collx)
        {
            bDefaultFound = mod.Key == szvKey;

            if (bDefaultFound)
            {
                obj = mod;
                break;
            }
        }

        return obj;
    }

    public long ModuleCount {

        get {
            return Convert.ToInt64(collx.Count);
        }
    }

    public bool KeyExist(string szvKey) {

                                        bool bExists = false;

        foreach (Module mod in collx)
        {
            bExists = mod.Key == szvKey;

            if (bExists)
            {
                break;
            }
        }

        return bExists;
    }

    public void RemoveModule(string szvoKey) {

        collx.Remove(szvoKey);
    }

    public void RemoveModule(long lvoIndex) {

        collx.Remove(lvoIndex);
    }

    public void RemoveAllModules() {

        collx.Clear();
    }

    ~Modules() {

        collx.Clear();
    }

}
}