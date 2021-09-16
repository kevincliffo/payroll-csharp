using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class Departments : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public Departments()
        {
            collx = new ArrayList();
        }

        public void AddDepartment(string szvKey,
                                  ref Department dr)
        {
                                        Department d = new Department();

            collx.Add(d);

            d.Key = szvKey;
            d.Index = collx.Count;
            d.ParentIsDepartments = this;

            dr  = d;
        }

        public Department ItemIsDepartment(string szvKey)
        {
                                        bool bDepartmentFound = false;
                                        Department dMain = null;

            foreach (Department d in collx)
            {
                bDepartmentFound = d.Key == szvKey;

                if (bDepartmentFound)
                {
                    dMain = d;
                    break;
                }
            }

            return dMain;
        }

        public long DepartmentCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bDepartmentFound = false;

            foreach (Department d in collx)
            {
                bDepartmentFound = d.Key == szvKey;

                if (bDepartmentFound)
                {
                    break;
                }
            }

            return bDepartmentFound;
        }

        public void RemoveDepartment(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveDepartment(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllDepartments()
        {
            collx.Clear();
        }

        ~Departments()
        {
            collx.Clear();
        }

    }
}