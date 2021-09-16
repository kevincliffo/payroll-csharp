using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class Staffs : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public Staffs()
        {
            collx = new ArrayList();
        }

        public void AddStaff(string szvKey,
                             ref Staff sr)
        {
                                        Staff s = new Staff();

            collx.Add(s);

            s.Key = szvKey;
            s.Index = collx.Count;
            s.ParentIsStaffs = this;

            sr  = s;
        }

        public Staff ItemIsStaff(string szvKey)
        {
                                        bool bStaffFound = false;
                                        Staff sMain = null;

            foreach (Staff s in collx)
            {
                bStaffFound = s.Key == szvKey;

                if (bStaffFound)
                {
                    sMain = s;
                    break;
                }
            }

            return sMain;
        }

        public long StaffCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bStaffFound = false;

            foreach (Staff s in collx)
            {
                bStaffFound = s.Key == szvKey;

                if (bStaffFound)
                {
                    break;
                }
            }

            return bStaffFound;
        }

        public void RemoveStaff(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveStaff(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllStaffs()
        {
            collx.Clear();
        }

        ~Staffs()
        {
            collx.Clear();
        }

    }
}