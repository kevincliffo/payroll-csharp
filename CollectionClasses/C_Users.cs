using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace CollectionClasses
{
    public class Users : IEnumerable
    {
        private ArrayList collx = null;

        public IEnumerator GetEnumerator()
        {
            return collx.GetEnumerator();
        }
        public Users()
        {

            collx = new ArrayList();
        }

        public void AddUser(string szvKey,
                            ref User usr)
        {

            User us = new User();

            collx.Add(us);

            us.Key = szvKey;
            us.Index = collx.Count;
            us.ParentIsUsers = this;

            usr = us;
        }

        public User ItemIsUser(string szvKey)
        {
                                        bool bUserFound = false;
                                        User usr = null;

            foreach (User us in collx) {
                bUserFound = us.Key == szvKey;

                if (bUserFound) {
                    usr = us;
                    break;
                }
            }

            return usr;
        }

        public long UserCount
        {
            get
            {
                return Convert.ToInt64(collx.Count);
            }
        }

        public bool KeyExist(string szvKey)
        {
                                        bool bUserFound = false;

            foreach (User us in collx) {
                bUserFound = us.Key == szvKey;

                if (bUserFound) {
                    break;
                }
            }

            return bUserFound;
        }

        public void RemoveUser(string szvoKey)
        {

            collx.Remove(szvoKey);
        }

        public void RemoveUser(long lvoIndex)
        {

            collx.Remove(lvoIndex);
        }

        public void RemoveAllUsers()
        {

            collx.Clear();
        }

        ~Users()
        {

            collx.Clear();
        }

    }
}