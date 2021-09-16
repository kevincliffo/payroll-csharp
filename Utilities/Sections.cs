using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Utilities
{
public class Sections : IEnumerable
{
    private ArrayList collx = null;

    public Sections() {
        collx = new ArrayList();
    }


    public void AddSection(string szvKey,
                           ref Section sr) {

                                Section s = new Section();
                                SectionLines sls = new SectionLines();

        collx.Add(s);

        s.ParentIsSections = this;
        s.Key = szvKey;
        s.Index = collx.Count;
        s.SectionLines = sls;

        sr = s;
    }

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }

    public long SectionsCount { 
        get{
            return collx.Count;
        }

    }

    public Section ItemIsSection(string szvKey){

                                            Section sec = null;

        foreach (Section s in collx) {
            if (s.Key == szvKey) {
                sec = s;
                break;
            }
        }

        return sec;
    }

    public bool KeyExist(string szvKey){

                                        bool bKeyExists = false;

        foreach (Section s in collx){
            if (s.Key == szvKey){
                bKeyExists = true;
                break;
            }
        }

        return bKeyExists;
    }

    public void RemoveSection(string szvKey) {

                                            bool bKeyExists = false;
                                            Section sec = null;

        foreach (Section s in collx){
            if (s.Key == szvKey){
                bKeyExists = true;
                sec = s;
                break;
            }
        }

        if (bKeyExists) {
            collx.Remove(sec);
        }
    }

    public void RemoveAllSections(){
        
        collx.Clear();
    }

    ~Sections() {
        collx.Clear();
    }
}
}
