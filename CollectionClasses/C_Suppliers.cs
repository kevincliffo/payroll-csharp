using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class Suppliers : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public Suppliers()
        {
            collx = new ArrayList();
        }

        public void AddSupplier(string szvKey,
                                ref Supplier sr)
        {
                                        Supplier s = new Supplier();

            collx.Add(s);

            s.Key = szvKey;
            s.Index = collx.Count;
            s.ParentIsSuppliers = this;

            sr  = s;
        }

        public Supplier ItemIsSupplier(string szvKey)
        {
                                        bool bSupplierFound = false;
                                        Supplier sMain = null;

            foreach (Supplier s in collx)
            {
                bSupplierFound = s.Key == szvKey;

                if (bSupplierFound)
                {
                    sMain = s;
                    break;
                }
            }

            return sMain;
        }

        public long SupplierCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bSupplierFound = false;

            foreach (Supplier s in collx)
            {
                bSupplierFound = s.Key == szvKey;

                if (bSupplierFound)
                {
                    break;
                }
            }

            return bSupplierFound;
        }

        public void RemoveSupplier(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveSupplier(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllSuppliers()
        {
            collx.Clear();
        }

        ~Suppliers()
        {
            collx.Clear();
        }

    }
}