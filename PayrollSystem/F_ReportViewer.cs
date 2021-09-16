using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Utilities;
using DataBaseManagement;
using Models;

namespace PayRollSystem
{
    public partial class F_ReportViewer : Form
    {
        private DatabaseConnection dbcx = null;
        public F_ReportViewer(DatabaseConnection dbcv)
        {
            dbcx = dbcv;
            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void F_ReportViewer_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.crViewer.RefreshReport();
        }

        public void LaunchReport(string szvTitle,
                                 ReportDocument rptvDocument)
        {
            this.Text = szvTitle;
            this.crViewer.ReportSource = rptvDocument;
            this.crViewer.RefreshReport();
        }
    }
}
