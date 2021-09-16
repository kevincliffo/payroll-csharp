using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class SubDepartments : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public SubDepartments()
        {
            collx = new ArrayList();
        }

        public void AddSubDepartment(string szvKey,
                                     ref SubDepartment sdr)
        {
                                        SubDepartment sd = new SubDepartment();

            collx.Add(sd);

            sd.Key = szvKey;
            sd.Index = collx.Count;
            sd.ParentIsSubDepartments = this;

            sdr  = sd;
        }

        public SubDepartment ItemIsSubDepartment(string szvKey)
        {
                                        bool bSubDepartmentFound = false;
                                        SubDepartment sdMain = null;

            foreach (SubDepartment sd in collx)
            {
                bSubDepartmentFound = sd.Key == szvKey;

                if (bSubDepartmentFound)
                {
                    sdMain = sd;
                    break;
                }
            }

            return sdMain;
        }

        public long SubDepartmentCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bSubDepartmentFound = false;

            foreach (SubDepartment sd in collx)
            {
                bSubDepartmentFound = sd.Key == szvKey;

                if (bSubDepartmentFound)
                {
                    break;
                }
            }

            return bSubDepartmentFound;
        }

        public void RemoveSubDepartment(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveSubDepartment(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllSubDepartments()
        {
            collx.Clear();
        }

        ~SubDepartments()
        {
            collx.Clear();
        }

    }
}