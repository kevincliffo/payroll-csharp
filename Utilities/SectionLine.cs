using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class SectionLine
{
    private SectionLines slsxParent = null;
    private string szxKey;
    private string szxValue;
    private string szxName;
    private long lxIndex;

    public long Index {

        get {
            return lxIndex;
        }
        set {
            lxIndex = value;
        }
    }

    public string Key {

        get {
            return szxKey;
        }
        set {
            szxKey = value;
        }
    }

    public string Value {

        get {
            return szxValue;
        }
        set {
            szxValue = value;
        }
    }

    public string Name {

        get {
            return szxName;
        }
        set {
            szxName = value;
        }
    }

    public SectionLines ParentIsSectionLines{

        get  {
            return slsxParent;
        }
        set {
            slsxParent = value;
        }
    }
}
}
