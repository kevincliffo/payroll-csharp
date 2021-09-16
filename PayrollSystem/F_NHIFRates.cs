using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Models;
using DataBaseManagement;
using CollectionClasses;
using Utilities;

namespace PayRollSystem
{
    public partial class F_NHIFRates : Form
    {
        private DatabaseConnection dbcx = null;
        private Utilities.Utilities utsx = null;
        private Form mdixParent = null;
        
        private FileAccessor fax = null;
        private NHIFRates nhifrsx = null;
        private SharedComponents scsx = null;

        private const int nxBUTTON_Height = 25;
        private const int nxBUTTON_Width = 100;

        private const int nxID_BUTTON_Left = 8;
        private const int nxFROM_BUTTON_Left = 120;
        private const int nxTO_BUTTON_Left = 233;
        private const int nxRATE_BUTTON_Left = 347;
        private int nxLastButtonTop = 0;

        public F_NHIFRates(Form mdivForm,
                           DatabaseConnection dbcv)
        {
            InitializeComponent();
            dbcx = dbcv;
            mdixParent = mdivForm;
            
            utsx = new Utilities.Utilities();
            fax = new FileAccessor();
            nhifrsx = new NHIFRates();
            scsx = new SharedComponents(dbcx);

            scsx.GetNHIFRatesCollection(ref nhifrsx);
            XX_PopulateFrmWithRates();
        }

        private void XX_PopulateFrmWithRates()
        {
                                        Button btnRate;
                                        int nTop = 103;
                                        Color cButtonColor = new Color();

            foreach (NHIFRate nhifr in nhifrsx)
            {
                if (nhifr.NHIFRateId % 2 == 0)
                {
                    cButtonColor = Color.Cyan;
                }
                else
                {
                    cButtonColor = Color.DimGray;
                }

                btnRate = new Button();
                btnRate.Left = nxID_BUTTON_Left;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nhifr.NHIFRateId);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = nxFROM_BUTTON_Left;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nhifr.From);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = nxTO_BUTTON_Left;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nhifr.To);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = nxRATE_BUTTON_Left;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nhifr.Rate);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                nTop = nTop + 27;
                nxLastButtonTop = nTop;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void F_NHIFRates_Load(object sender, EventArgs e)
        {
            this.Height = nxLastButtonTop + 50;
        }
    }
}
