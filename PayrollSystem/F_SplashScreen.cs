using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using Models;

namespace PayRollSystem
{
    public partial class F_SplashScreen : Form
    {
        private DatabaseConnection dbcx = null;
        public delegate void delEnableMDIFormControls();
        public event delEnableMDIFormControls EnableMDIFormControls;

        public F_SplashScreen(DatabaseConnection dbcv)
        {
            InitializeComponent();

            dbcx = dbcv;
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_SplashScreen_Load(object sender, EventArgs e)
        {
            int nCounter = 0;
            pbProgressBar.Minimum = 0;
            pbProgressBar.Maximum = 100;

            for (nCounter = 0; nCounter <= 100; nCounter++)
            {               
                pbProgressBar.Value = nCounter;
            }
        }

        private void F_SplashScreen_Shown(object sender, EventArgs e)
        {
            tmTimer = new Timer();
            tmTimer.Interval = 1500;
            tmTimer.Start();
            tmTimer.Tick += new EventHandler(tmTimer_Tick);
        }

        void tmTimer_Tick(object sender, EventArgs e)
        {
            tmTimer.Stop();
            this.Hide();
            EnableMDIFormControls();
        }

        private void F_SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

