using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class ControlObjects : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public ControlObjects()
        {
            collx = new ArrayList();
        }

        public void AddControlObject(string szvKey,
                                  ref ControlObject cor)
        {
                                        ControlObject co = new ControlObject();

            collx.Add(co);

            co.Key = szvKey;
            co.Index = collx.Count;
            co.ParentIsControlObjects = this;

            cor  = co;
        }

        public ControlObject ItemIsControlObject(string szvKey)
        {
                                        bool bControlObjectFound = false;
                                        ControlObject coMain = null;

            foreach (ControlObject co in collx)
            {
                bControlObjectFound = co.Key == szvKey;

                if (bControlObjectFound)
                {
                    coMain = co;
                    break;
                }
            }

            return coMain;
        }

        public long ControlObjectCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bControlObjectFound = false;

            foreach (ControlObject co in collx)
            {
                bControlObjectFound = co.Key == szvKey;

                if (bControlObjectFound)
                {
                    break;
                }
            }

            return bControlObjectFound;
        }

        public void RemoveControlObject(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveControlObject(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllControlObjects()
        {
            collx.Clear();
        }

        ~ControlObjects()
        {
            collx.Clear();
        }

    }
}