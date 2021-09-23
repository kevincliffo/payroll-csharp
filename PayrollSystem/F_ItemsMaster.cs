using System;
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
    public partial class F_ItemsMaster : Form
    {
        private DatabaseConnection dbcx = null;
        private EnumsCollection.EnumFormMode efmx = new EnumsCollection.EnumFormMode();
        private Fields fdsxUpdateFields = null;
        private Form mdixParent = null;
        
        private Utilities.Utilities utsx = null;
        private SharedComponents scx = null;

        public F_ItemsMaster(Form mdivForm,
                             DatabaseConnection dbcv,
                             
                             Fields fdsvUpdateFields,
                             EnumsCollection.EnumFormMode efmv)
        {
            InitializeComponent();

            dbcx = dbcv;
            efmx = efmv;
            fdsxUpdateFields = fdsvUpdateFields;
            mdixParent = mdivForm;
            
            utsx = new Utilities.Utilities();
            scx = new SharedComponents(dbcx);
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftMaster;
        }

        private void F_ItemsMaster_Load(object sender, EventArgs e)
        {

        }
    }
}
