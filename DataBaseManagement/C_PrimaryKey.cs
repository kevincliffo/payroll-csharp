using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseManagement
{
    public class PrimaryKey
    {
        private PrimaryKeys pksxParent = null;
        private string szxrwxKey = string.Empty;
        private long lxrwxIndex = 0;
        private string szxrwFieldName = string.Empty;

        public PrimaryKeys ParentIsPrimaryKeys
        {
            get
            {
                return pksxParent;
            }
            set
            {
                pksxParent = value;
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

        public string FieldName
        {
            get
            {
                return szxrwFieldName;
            }
            set
            {
                szxrwFieldName = value;
            }
        }

        public long Index
        {
            get
            {
                return lxrwxIndex;
            }
            set
            {
                lxrwxIndex = value;
            }
        }

    }
}