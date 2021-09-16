using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionClasses
{
    public class Department
    {
        private Departments dsxParent = null;
        private int nxrwIndex = 0;
        private string szxrwKey = string.Empty;
        private int nxrwDepartmentId = 0;
        private string szxrwDepartmentName = string.Empty;

        public Departments ParentIsDepartments
        {
            get
            {
                return dsxParent;
            }
            set
            {
                dsxParent = value;
            }
        }

        public string Key
        {
            get
            {
                return szxrwKey;
            }
            set
            {
                szxrwKey = value;
            }
        }

        public int Index
        {
            get
            {
                return nxrwIndex;
            }
            set
            {
                nxrwIndex = value;
            }
        }

        public int DepartmentId
        {
            get
            {
                return nxrwDepartmentId;
            }
            set
            {
                nxrwDepartmentId = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return szxrwDepartmentName;
            }
            set
            {
                szxrwDepartmentName = value;
            }
        }

    }
}