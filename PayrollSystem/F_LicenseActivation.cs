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
using System.IO;
using CollectionClasses;

namespace PayRollSystem
{
    public partial class F_LicenseActivation : Form
    {
        private DatabaseConnection dbcx = null;
        private Form mdixParent = null;
        private Utilities.Utilities utsx = null;
        private Modules msx = null;
        private License_DS l_dsx = null;

        private const string szxEMPTY = "";

        public F_LicenseActivation(Form mdivForm,
                                   DatabaseConnection dbcv,
                                   Modules msv)
        {
            InitializeComponent();

            msx = msv;
            utsx = new Utilities.Utilities();
            dbcx = dbcv;
            l_dsx = new License_DS(dbcx);
            mdixParent = mdivForm;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "License Files (*.tbd)|*.tbd";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtLicenseFile.Text = openFileDialog.FileName;
                btnDisplayLicenseText.Enabled = true;
            }
        }

        private void btnDisplayLicenseText_Click(object sender, EventArgs e)
        {
                                        string szLicenseText = string.Empty;
                                        string szValue = string.Empty;
                                        bool bValueNotFound = false;
                                        FileAccessor fa = new FileAccessor();

            while (true)
            {
                if (txtLicenseFile.Text.Trim() == szxEMPTY)
                {
                    utsx.ShowMessage("Select License Path",
                                     "Path Error",
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                if (File.Exists(txtLicenseFile.Text) == false)
                {
                    utsx.ShowMessage("Path does not exist",
                                     "Path Error",
                                     EnumsCollection.EnumMessageType.emtError);
                    break;
                }

                btnActivateLicense.Enabled = true;
                fa.ConnectToFile(txtLicenseFile.Text,
                                 EnumsCollection.EnumFileAccessType.efatRead);

                fa.GetValue("Details",
                            "LicenseText",
                            ref szValue,
                            ref bValueNotFound);

                if (bValueNotFound == false)
                {
                    txtLicenseText.Text = szValue;
                }

                break;
            }
        }

        private void XX_AddLicenseTextToDataBase(Tags tgsv,
                                                 string szvLicenseText)
        {
                                        Fields fds = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szDateString = string.Empty;
                                        string szTime = string.Empty;
        
            fds = l_dsx.Fields;

            fds.ItemIsField("LicenseKey").StringValue = tgsv.TagCount.ToString();
            fds.ItemIsField("LicenseValue").StringValue = szvLicenseText;
            utsx.GetDateStringValueOverDate(DateTime.Now,
                                            ref szDateString,
                                            ref szTime);
            fds.ItemIsField("ActivationDate").StringValue = szDateString;
            fds.ItemIsField("ActivationTime").StringValue = szTime;

            l_dsx.AddToDataBase(fds,
                                ref bErrorFound,
                                ref szErrorMessage);

        }

        private void btnActivateLicense_Click(object sender, System.EventArgs e)
        {
                                        string szDecryptedLicenseText = string.Empty;
                                        string szActivatedModulesMessageString = string.Empty;
                                        string szNotActivatedModulesMessageString = string.Empty;
                                        string szMessage = string.Empty;
                                        bool bModuleFound = false;
                                        string[] aszModules;
                                        Tags tgs = new Tags();
                                        Tag t = null;

            while(true)
            {
                if (txtLicenseText.Text == szxEMPTY)
                {
                    break;
                }

                utsx.Decrypt(txtLicenseText.Text,
                             ref szDecryptedLicenseText);

                szDecryptedLicenseText = szDecryptedLicenseText.Substring(0, szDecryptedLicenseText.Length - 1);

                aszModules = szDecryptedLicenseText.Split('_');

                foreach (string szModule in aszModules)
                {
                    foreach (Module m in msx)
                    {
                        if (m.ModuleName == szModule)
                        {
                            bModuleFound = true;
                            break;
                        }
                    }

                    if (bModuleFound)
                    {
                        tgs.AddTag(szModule,
                                   ref t);
                        t.Bool = bModuleFound;
                        t.StringValue1 = szModule;
                    }
                }

                bModuleFound = false;
                foreach (Tag tag in tgs)
                {
                    if (tag.Bool == true)
                    {
                        bModuleFound = true;
                        szActivatedModulesMessageString = szActivatedModulesMessageString
                                                        + tag.StringValue1
                                                        + " Activated Successfully\n";
                    }
                    else
                    {
                        szNotActivatedModulesMessageString = szNotActivatedModulesMessageString
                                                           + tag.StringValue1
                                                           + " Activated Successfully\n";
                    }
                }

                szMessage = szActivatedModulesMessageString
                          + "\n"
                          + szNotActivatedModulesMessageString;

                utsx.ShowMessage(szMessage,
                                 "Activation Message",
                                  EnumsCollection.EnumMessageType.emtInformation);

                if (bModuleFound)
                {
                    XX_AddLicenseTextToDataBase(tgs,
                                                txtLicenseText.Text);
                    this.Hide();

                    utsx.ShowMessage("Application will now shut down, please restart \n to activate new License",
                                     "New License Message",
                                     EnumsCollection.EnumMessageType.emtInformation);
                    mdixParent.Close();
                }

                break;
            }

        }
        
        private void F_LicenseActivation_Load(object sender, EventArgs e)
        {
            btnDisplayLicenseText.Enabled = false;
            btnActivateLicense.Enabled = false;
        }
    }
}
