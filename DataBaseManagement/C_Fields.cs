using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataBaseManagement
{
    public class Fields : IEnumerable
    {
        private ArrayList collx = null;
        private  string szxrwTableName = "";
        private PrimaryKeys pksx;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public PrimaryKeys PrimaryKeys 
        {
            get 
            {
                return pksx;
            }
        }

        public Fields()
        {

            collx = new ArrayList();
            pksx = new PrimaryKeys();
        }

        public void AddField(string szvKey,
                             ref Field fdr)
        {

                                        Field fd = new Field();

            collx.Add(fd);

            fd.Key = szvKey;
            fd.Index = collx.Count;
            fd.ParentIsFields = this;

            fdr = fd;
        }

        public Field ItemIsField(string szvKey)
        {
                                        bool bFieldFound = false;
                                        Field fd = null;

            foreach (Field f in collx)
            {
                bFieldFound = f.Key == szvKey;

                if (bFieldFound)
                {
                    fd = f;
                    break;
                }
            }

            return fd;
        }

        public Field ItemIsField(int nvIndex)
        {
                                        Field fd = null;

            fd = (Field)collx[nvIndex];
            return fd;
        }

        public long FieldCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public string TableName
        {
            get
            {
                return szxrwTableName;
            }
            set 
            {
                szxrwTableName = value;
            }
        }

        public bool KeyExist(string szvKey)
        {
                                        bool bFieldFound = false;

            foreach (Field fd in collx)
            {
                bFieldFound = fd.Key == szvKey;

                if (bFieldFound)
                {
                    break;
                }
            }

            return bFieldFound;
        }

        public void RemoveField(string szvoKey)
        {

            collx.Remove(szvoKey);
        }

        public void RemoveField(long lvoIndex)
        {

            collx.Remove(lvoIndex);
        }

        public void RemoveAllFields()
        {

            collx.Clear();
        }

        ~Fields()
        {

            collx.Clear();
        }

    }
}