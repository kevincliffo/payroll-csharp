using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DataBaseManagement
{
    public class PrimaryKeys : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }
        public PrimaryKeys()
        {
            collx = new ArrayList();
        }

        public void AddPrimaryKey(string szvKey,
                                  ref PrimaryKey pkr)
        {

                                        PrimaryKey pk = new PrimaryKey();

            collx.Add(pk);

            pk.Key = szvKey;
            pk.Index = collx.Count;
            pk.ParentIsPrimaryKeys = this;

            pkr = pk;
        }

        public PrimaryKey ItemIsPrimaryKey(string szvKey)
        {
                                        bool bPrimaryKeyFound = false;
                                        PrimaryKey pk = null;

            foreach (PrimaryKey p in collx)
            {
                bPrimaryKeyFound = p.Key == szvKey;

                if (bPrimaryKeyFound)
                {
                    pk = p;
                    break;
                }
            }

            return pk;
        }

        public PrimaryKey ItemIsPrimaryKey(long lvIndex)
        {
                                        bool bPrimaryKeyFound = false;
                                        PrimaryKey pk = null;

            for(int nIndex = 0; nIndex <= collx.Count; nIndex ++)
            {
                bPrimaryKeyFound = nIndex == lvIndex;

                if (bPrimaryKeyFound)
                {
                    pk = (PrimaryKey)collx[nIndex];
                    break;
                }
            }

            return pk;
        }
        public long PrimaryKeyCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExist(string szvKey)
        {
                                        bool bPrimaryKeyFound = false;

            foreach (PrimaryKey pk in collx)
            {
                bPrimaryKeyFound = pk.Key == szvKey;

                if (bPrimaryKeyFound)
                {
                    break;
                }
            }

            return bPrimaryKeyFound;
        }

        public void RemovePrimaryKey(string szvoKey)
        {

            collx.Remove(szvoKey);
        }

        public void RemovePrimaryKey(long lvoIndex)
        {

            collx.Remove(lvoIndex);
        }

        public void RemoveAllPrimaryKeys()
        {

            collx.Clear();
        }

        ~PrimaryKeys()
        {

            collx.Clear();
        }

    }
}