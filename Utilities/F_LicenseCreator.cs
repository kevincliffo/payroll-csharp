using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Utilities
{
    public partial class F_LicenseCreator : Form
    {
        private Utilities utsx = null;

        public F_LicenseCreator()
        {
            InitializeComponent();
            utsx = new Utilities();
        }

        private void F_LicenseCreator_Load(object sender, EventArgs e)
        {
            chkPayroll.CheckedChanged += new EventHandler(chkCheckBoxChanged_CheckedChanged);
            chkInventory.CheckedChanged += new EventHandler(chkCheckBoxChanged_CheckedChanged);
            chkProduction.CheckedChanged += new EventHandler(chkCheckBoxChanged_CheckedChanged);
        }

        void chkCheckBoxChanged_CheckedChanged(object sender, EventArgs e)
        {
                        CheckBox chkbox = (CheckBox)sender;
                        string szLicesnseText = string.Empty;

            txtLicesnseText.Text = string.Empty;
            
            if(chkPayroll.Checked)
            {
                szLicesnseText = szLicesnseText
                               + "Payroll"
                               + "_";
            }

            if(chkInventory.Checked)
            {
                szLicesnseText = szLicesnseText
                               + "Inventory"
                               + "_";
            }

            if(chkProduction.Checked)
            {
                szLicesnseText = szLicesnseText
                               + "Production"
                               + "_";

            }

            txtLicesnseText.Text = szLicesnseText;
        }

        private void btnCreateLicense_Click(object sender, EventArgs e)
        {
                                        string szLicenseFileName = "License.tbd";
                                        string szLicenseFilePath = string.Empty;
                                        System.IO.StreamWriter sw;

            szLicenseFilePath = Application.StartupPath
                              + "\\"
                              + szLicenseFileName;

            sw = new System.IO.StreamWriter(szLicenseFilePath);

            sw.WriteLine("[Details]");
            sw.WriteLine("LicenseText=" + txtLicense.Text);
            sw.WriteLine();
            sw.Close();

            Process.Start(szLicenseFilePath);
        }

        private void btnGenerateLicenseText_Click(object sender, EventArgs e)
        {
                                        string szEncryptedString = string.Empty;

            utsx.Encrypt(txtLicesnseText.Text,
                         ref szEncryptedString);

            txtLicense.Text = szEncryptedString;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLicense_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
