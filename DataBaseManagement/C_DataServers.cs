using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataBaseManagement
{
    public class DataServers : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }
        public DataServers()
        {

            collx = new ArrayList();
        }

        public void AddDataServer(string szvKey,
                                  ref DataServer dsr)
        {

                                        DataServer ds = new DataServer();

            collx.Add(ds);

            ds.Key = szvKey;
            ds.Index = collx.Count;
            ds.ParentIsDataServers = this;

            dsr = ds;
        }

        public DataServer ItemIsDataServer(string szvKey)
        {
                                        bool bDataServerFound = false;
                                        DataServer dsr = null;

            foreach (DataServer ds in collx)
            {
                bDataServerFound = ds.Key == szvKey;

                if (bDataServerFound)
                {
                    dsr = ds;
                    break;
                }
            }

            return dsr;
        }

        public long DataServerCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExist(string szvKey)
        {
                                        bool bDataServerFound = false;

            foreach (DataServer ds in collx)
            {
                bDataServerFound = ds.Key == szvKey;

                if (bDataServerFound)
                {
                    break;
                }
            }

            return bDataServerFound;
        }

        public void RemoveDataServer(string szvoKey)
        {

            collx.Remove(szvoKey);
        }

        public void RemoveDataServer(long lvoIndex)
        {

            collx.Remove(lvoIndex);
        }

        public void RemoveAllDataServers()
        {

            collx.Clear();
        }

        ~DataServers()
        {

            collx.Clear();
        }

    }
}