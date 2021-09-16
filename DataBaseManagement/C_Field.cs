using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace DataBaseManagement
{
    public class Field
    {
        private Fields fdsxParent = null;
        private string szxrwxKey = string.Empty;
        private int nxrwxIndex = 0;
        private int nxrwLength = 0;
        private string szxrwStringValue = string.Empty;
        private EnumsCollection.EnumFieldType eftrwx = new EnumsCollection.EnumFieldType();
        private bool bxrwValueRequired = false;
        private string szxrwLocalizedName = "";

        public Fields ParentIsFields
        {
            get
            {
                return fdsxParent;
            }
            set
            {
                fdsxParent = value;
            }
        }

        public EnumsCollection.EnumFieldType EnumFieldType
        {
            get
            {
                return eftrwx;
            }
            set
            {
                eftrwx = value;
            }
        }

        public bool ValueRequired
        {
            get
            {
                return bxrwValueRequired;
            }
            set
            {
                bxrwValueRequired = value;
            }
        }
        public string Key
        {
            get
            {
                return szxrwxKey;
            }
            set
            {
                szxrwxKey = value;
            }
        }

        public string LocalizedName
        {
            get
            {
                return szxrwLocalizedName;
            }
            set
            {
                szxrwLocalizedName = value;
            }
        }

        public int Length
        {
            get
            {
                return nxrwLength;
            }
            set
            {
                nxrwLength = value;
            }
        }

        public int Index
        {
            get
            {
                return nxrwxIndex;
            }
            set
            {
                nxrwxIndex = value;
            }
        }

        public string StringValue
        {
            get
            {
                return szxrwStringValue;
            }
            set
            {
                szxrwStringValue = value;
            }
        }
    }
}