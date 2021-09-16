﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using Utilities;
using Models;

namespace PayRollSystem
{
    public partial class F_Suppliers : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Utilities.Utilities utsx = null;
        private SharedComponents scx = null;
        private Suppliers_DS ss_dsx = null;

        public F_Suppliers(Form mdivForm,
                           DatabaseConnection dbcv,
                           
                           Fields fdsvUpdateFields,
                           EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            mdixParent = mdivForm;
            
            ss_dsx = new Suppliers_DS(dbcx);
            utsx = new Utilities.Utilities();
            scx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void F_Suppliers_Load(object sender, EventArgs e)
        {
                                        string szCode = string.Empty;

            string szKey = utsx.Right("txtName", 3);

            ss_dsx.GetNextSupplierCode(ref szCode);
            txtSupplierCode.Text = szCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                                        Fields fds = null;

            fds = ss_dsx.Fields;
            scx.MoveControlValuesToFields(this,
                                          ref fds);
        }


    }
}
