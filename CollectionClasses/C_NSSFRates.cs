using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class NSSFRates : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public NSSFRates()
        {
            collx = new ArrayList();
        }

        public void AddNSSFRate(string szvKey,
                                ref NSSFRate nssfrr)
        {
                                        NSSFRate nssfr = new NSSFRate();

            collx.Add(nssfr);

            nssfr.Key = szvKey;
            nssfr.Index = collx.Count;
            nssfr.ParentIsNSSFRates = this;

            nssfrr  = nssfr;
        }

        public NSSFRate ItemIsNSSFRate(string szvKey)
        {
                                        bool bNSSFRateFound = false;
                                        NSSFRate nssfrMain = null;

            foreach (NSSFRate nssfr in collx)
            {
                bNSSFRateFound = nssfr.Key == szvKey;

                if (bNSSFRateFound)
                {
                    nssfrMain = nssfr;
                    break;
                }
            }

            return nssfrMain;
        }

        public long NSSFRateCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bNSSFRateFound = false;

            foreach (NSSFRate nssfr in collx)
            {
                bNSSFRateFound = nssfr.Key == szvKey;

                if (bNSSFRateFound)
                {
                    break;
                }
            }

            return bNSSFRateFound;
        }

        public void RemoveNSSFRate(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveNSSFRate(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllNSSFRates()
        {
            collx.Clear();
        }

        ~NSSFRates()
        {
            collx.Clear();
        }

    }
}