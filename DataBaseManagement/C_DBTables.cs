using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataBaseManagement
{
    public class DBTables : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }
        public DBTables()
        {

            collx = new ArrayList();
        }

        public void AddDBTable(string szvKey,
                              ref DBTable dbtr)
        {

                                        DBTable dbt = new DBTable();

            collx.Add(dbt);

            dbt.Key = szvKey;
            dbt.Index = collx.Count;
            dbt.ParentIsDBTables = this;
            dbtr = dbt;
        }

        public DBTable ItemIsDBTable(string szvKey)
        {
                                        bool bDBTableFound = false;
                                        DBTable dbt = null;

            foreach (DBTable t in collx)
            {
                bDBTableFound = t.Key == szvKey;

                if (bDBTableFound)
                {
                    dbt = t;
                    break;
                }
            }

            return dbt;
        }

        public long DBTableCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExist(string szvKey)
        {
                                        bool bDBTableFound = false;

            foreach (DBTable dbt in collx)
            {
                bDBTableFound = dbt.Key == szvKey;

                if (bDBTableFound)
                {
                    break;
                }
            }

            return bDBTableFound;
        }

        public void RemoveDBTable(string szvoKey)
        {

            collx.Remove(szvoKey);
        }

        public void RemoveDBTable(long lvoIndex)
        {

            collx.Remove(lvoIndex);
        }

        public void RemoveAllDBTables()
        {

            collx.Clear();
        }

        ~DBTables()
        {

            collx.Clear();
        }

    }
}