using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Utilities
{
public class FormItems : IEnumerable
{
    private ArrayList collx = null;

    public IEnumerator GetEnumerator()
    {
        return collx.GetEnumerator();
    }
    public FormItems() {

        collx = new ArrayList();
    }

    public void AddFormItem(string szvKey,
                            ref FormItem fir) {

                        FormItem fi = new FormItem();
                        
        collx.Add(fi);

        fi.Key = szvKey;
        fi.Index = collx.Count;
        fi.ParentIsFormItems = this;
    
        fir = fi;
    }

    public FormItem ItemIsFormItem(string szvKey) {
    
                                        bool bStudentFound = false;
                                        FormItem fi = null;

            foreach (FormItem f in collx) {
                bStudentFound = f.Key == szvKey;

                if (bStudentFound) {
                    fi = f;
                    break;
                }
            }

            return fi;
    }

    public long FormItemCount {

        get {
            return Convert.ToInt64(collx.Count);
        }
    }

    public bool KeyExist(string szvKey) {

                                        bool bItemFound = false;

            foreach (FormItem fi in collx) {
                bItemFound = fi.Key == szvKey;

                if (bItemFound)
                {
                    break;
                }
            }

            return bItemFound;
    }

    public void RemoveFormItem(string szvKey) {

        foreach (FormItem fi in collx)
        {
            if (fi.FormName == szvKey)
            {
                collx.Remove(fi);
                break;
            }
        }
    }

    public void RemoveFormItem(long lvoIndex) {

        collx.Remove(lvoIndex);
    }

    public void RemoveAllFormItems() {

        collx.Clear();
    }

    ~FormItems() {

        collx.Clear();
    }

}
}