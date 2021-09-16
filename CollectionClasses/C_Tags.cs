using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class Tags : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }

        public Tags()
        {
            collx = new ArrayList();
        }

        public void AddTag(string szvKey,
                           ref Tag tr)
        {
                                        Tag t = new Tag();

            collx.Add(t);

            t.Key = szvKey;
            t.Index = collx.Count;
            t.ParentIsTags = this;

            tr  = t;
        }

        public Tag ItemIsTag(string szvKey)
        {
                                        bool bTagFound = false;
                                        Tag tMain = null;

            foreach (Tag t in collx)
            {
                bTagFound = t.Key == szvKey;

                if (bTagFound)
                {
                    tMain = t;
                    break;
                }
            }

            return tMain;
        }

        public long TagCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExists(string szvKey)
        {
                                        bool bTagFound = false;

            foreach (Tag t in collx)
            {
                bTagFound = t.Key == szvKey;

                if (bTagFound)
                {
                    break;
                }
            }

            return bTagFound;
        }

        public void RemoveTag(string szvKey)
        {
            collx.Remove(szvKey);
        }

        public void RemoveTag(long lvKey)
        {
            collx.Remove(lvKey);
        }

        public void RemoveAllTags()
        {
            collx.Clear();
        }

        ~Tags()
        {
            collx.Clear();
        }

    }
}