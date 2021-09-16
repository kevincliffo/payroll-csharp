using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomGrid;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace CustomGrid
{
    public class DataRowComparer : IComparer
    {
        ListSortDirection lsdxDirection;
        private int nxColumnIndex;

        public DataRowComparer(int nvColumnIndex, ListSortDirection lsdvDirection)
        {
            this.nxColumnIndex = nvColumnIndex;
            this.lsdxDirection = lsdvDirection;
        }

        #region IComparer Members

        public int Compare(object objvX, object objvY)
        {
            DataRow drObjx = (DataRow)objvX;
            DataRow drObjy = (DataRow)objvY;
            return string.Compare(drObjx[nxColumnIndex].ToString(), drObjy[nxColumnIndex].ToString()) * (lsdxDirection == ListSortDirection.Ascending ? 1 : -1);
        }
        #endregion
    }
}
