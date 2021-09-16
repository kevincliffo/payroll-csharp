using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomGrid
{
    public class ContactInfo
    {
        private int szxrwId;
        private string szxrwName;
        private DateTime dtxrwDate;
        private string szxrwSubject;
        private double dxrwConcentration;

        public ContactInfo()
        {
        }
        public ContactInfo(int szvId, string szvName, DateTime dtv, string szvSubject, double con)
        {
            this.szxrwId = szvId;
            this.szxrwName = szvName;
            this.dtxrwDate = dtv;
            this.szxrwSubject = szvSubject;
            this.dxrwConcentration = con;
        }

        public int Id
        {
            get { return szxrwId; }
            set { szxrwId = value; }
        }

        public string Name
        {
            get { return szxrwName; }
            set { szxrwName = value; }
        }

        public DateTime Date
        {
            get { return dtxrwDate; }
            set { dtxrwDate = value; }
        }

        public string Subject
        {
            get { return szxrwSubject; }
            set { szxrwSubject = value; }
        }

        public double Concentration
        {
            get { return dxrwConcentration; }
            set { dxrwConcentration = value; }
        }

    }
}
