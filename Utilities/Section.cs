using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class Section
{
    private Sections ssxParent = null;
    private SectionLines slsx = null;
    private string szxKey;
    private string szxName;
    private long lxIndex;

    public Section() {
        slsx = new SectionLines();
    }

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

    public string Name {

        get {
            return szxName;
        }
        set {
            szxName = value;
        }
    }

    public Sections ParentIsSections {

        get  {
            return ssxParent;
        }
        set {
            ssxParent = value;
        }
    }

    public SectionLines SectionLines {

        get  {
            return slsx;
        }
        set {
            slsx = value;
        }
    }

}
}
