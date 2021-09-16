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
    public partial class F_NSSFRates : Form
    {
        private DatabaseConnection dbcx = null;
        private Utilities.Utilities utsx = null;
        private Form mdixParent = null;
        
        private FileAccessor fax = null;
        private NSSFRates nssfrsx = null;
        private SharedComponents scsx = null;

        private const int nxBUTTON_Height = 25;
        private const int nxBUTTON_Width = 110;

        private const int nxID_BUTTON_Left = 8;
        private const int nxFROM_BUTTON_Left = 120;
        private const int nxTO_BUTTON_Left = 233;
        private const int nxRATE_BUTTON_Left = 347;
        private int nxFooterLabelTop = 0;

        public F_NSSFRates(Form mdivForm,
                           DatabaseConnection dbcv)
        {
            InitializeComponent();

            dbcx = dbcv;
            mdixParent = mdivForm;
            
            utsx = new Utilities.Utilities();
            fax = new FileAccessor();
            nssfrsx = new NSSFRates();
            scsx = new SharedComponents(dbcx);

            //XX_Initializenssfrates();
            scsx.GetNSSFratesCollection(ref nssfrsx);
            XX_PopulateFrmWithRates();
        }

        private void XX_PopulateFrmWithRates()
        {
                                        Button btnRate;
                                        int nTop = 150;
                                        Color cButtonColor = new Color();

            foreach (NSSFRate nssfr in nssfrsx)
            {
                if (nssfr.Index % 2 == 0)
                {
                    cButtonColor = Color.Cyan;
                }
                else
                {
                    cButtonColor = Color.DimGray;
                }

                btnRate = new Button();
                btnRate.Left = 18;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.EmployeeEarnings);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 139;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.PensionableEarnings);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 260;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierOnePensionableEarnings);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 381;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierOneEmployeeDeductions);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 502;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierOneEmployerContribution);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 623;
                btnRate.Width = nxBUTTON_Width;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierOneTotalContribution);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 744;
                btnRate.Width = 107;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierTwoPensionableEarnings);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 865;
                btnRate.Width = 99;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierTwoEmployeeDeductions);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 986;
                btnRate.Width = 110;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierTwoEmployerContribution);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 1107;
                btnRate.Width = 110;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TierTwoTotalContribution);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();

                btnRate = new Button();
                btnRate.Left = 1228;
                btnRate.Width = 110;
                btnRate.Height = nxBUTTON_Height;
                btnRate.Top = nTop;
                btnRate.FlatStyle = FlatStyle.Flat;
                btnRate.Text = Convert.ToString(nssfr.TotalPensionContribution);
                btnRate.TextAlign = ContentAlignment.BottomRight;
                btnRate.BackColor = cButtonColor;
                btnRate.Parent = this;
                btnRate.Show();
                
                nTop = nTop + 27;
                nxFooterLabelTop = nTop;
            }

        }
        private void F_NSSFRates_Load(object sender, EventArgs e)
        {
                                        Label lblFooter = new Label();

            lblFooter.AutoSize = false;
            lblFooter.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            lblFooter.Width = this.Width;
            lblFooter.Height = 5;
            lblFooter.Left = 1;
            lblFooter.Top = this.Height - 150;
            lblFooter.BackColor = Color.Gray;
            lblFooter.Parent = this;
            lblFooter.Show();
        }
    }
}
