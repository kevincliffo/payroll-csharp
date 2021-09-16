using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Specialized;

namespace Utilities
{
public class SectionLines : IEnumerable
{
    private ArrayList collx = null;

    public SectionLines(){
        collx = new ArrayList();
    }


    public void AddSectionLine(string szvKey,
                               ref SectionLine slr){

                                   SectionLine sl = new SectionLine();

        collx.Add(sl);

        sl.ParentIsSectionLines = this;
        sl.Key = szvKey;
        sl.Index = collx.Count;

        slr = sl;
    }

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }

    public long SectionLinesCount { 
        get{
            return collx.Count;
        }

    }

    public SectionLine ItemIsSectionLine(string szvKey){

                                            SectionLine secl = null;

        foreach (SectionLine sl in collx) {
            if (sl.Key == szvKey) {
                secl = sl;
                break;
            }
        }

        return secl;
    }

    public bool KeyExist(string szvKey){

                                        bool bKeyExists = false;

        foreach (SectionLine sl in collx){
            if (sl.Key == szvKey){
                bKeyExists = true;
                break;
            }
        }

        return bKeyExists;
    }

    public void RemoveSectionLine(string szvKey) {

                                            bool bKeyExists = false;
                                            SectionLine secl = null;

        foreach (SectionLine sl in collx){
            if (sl.Key == szvKey){
                bKeyExists = true;
                secl = sl;
                break;
            }
        }

        if (bKeyExists) {
            collx.Remove(secl);
        }
    }

    public void RemoveAllSectionLines(){
        
        collx.Clear();
    }

    ~ SectionLines() {
        collx.Clear();
    }
}
}
