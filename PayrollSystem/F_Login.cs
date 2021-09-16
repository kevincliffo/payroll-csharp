using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using System.Threading;

namespace PayRollSystem
{
    public partial class F_Login : Form
    {
        private DatabaseConnection dbcx = null;
        private FileAccessor fax = null;
        private ApplicationPathCarrier apcx = null;
        private Utilities.Utilities utsx = null;
        private const string szxEMPTY = "";

        public delegate void delConnectionSucceeded(DatabaseConnection dbcv,
                                                    bool bvConnectionSucceeded);
        public event delConnectionSucceeded ConnectionSucceeded;

        public F_Login()
        {
            apcx = new ApplicationPathCarrier(Application.StartupPath);
            fax = new FileAccessor();
            utsx = new Utilities.Utilities();
            InitializeComponent();
            this.Tag = Utilities.EnumsCollection.EnumFormType.eftService;
        }

        private void XX_ShowSplashScreen()
        {
            F_SplashScreen f_SplashScreen = new F_SplashScreen(dbcx);
            f_SplashScreen.Show();

        }

        private void XX_CreateDataBaseForFirstTimeUseIf(string szvServer,
                                                        string szvUser,
                                                        string szvPassword,
                                                        string szvDataBaseName,
                                                        ref bool brErrorFound)
        {
                                        string szConnectionString = string.Empty;
                                        MySqlConnection mysql_con = null;
                                        MySqlCommand mysql_cmd = null;
                                        bool bErrorFound = false;

            szConnectionString = "server=" + szvServer
                               + ";user=" + szvUser
                               + ";password=" + szvPassword + ";";

            try
            {
                mysql_con = new MySqlConnection(szConnectionString);
                mysql_cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS " + szvDataBaseName, mysql_con);
                mysql_con.Open();
                mysql_cmd.ExecuteNonQuery();
                mysql_con.Close();
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                MessageBox.Show(ex.Message,
                                "Connection Error");
            }

            brErrorFound = bErrorFound;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }


        private void F_Login_Load(object sender, EventArgs e)
        {
                                        Icon ic = new Icon(apcx.IconsPath + "\\system.ico");

            while(true)
            {
                this.Icon = ic;
                this.ActiveControl = txtUserName;
                break;
            }
        }

        private void XX_CheckIfFirstTimeLaunch(ref bool brFirstTimeUse,
                                       ref bool brErrorFound,
                                       ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bFirstTimeUse = false;
                                        MySqlDataReader mysql_dr = null;

            szSQL = "SELECT * FROM users";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            bFirstTimeUse = true;
            
            while (true)
            {
                if (mysql_dr == null)
                {
                    bErrorFound = true;
                    break;
                }

                while (mysql_dr.Read())
                {
                    bFirstTimeUse = false;
                    break;
                }
                break;
            }

            if (mysql_dr != null)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            brFirstTimeUse = bFirstTimeUse;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void XX_ConnectToDataBaseOverLoginDetails(ref Utilities.EnumsCollection.EnumMessageType emtr,
                                                          ref string szrErrorMessage,
                                                          ref bool brFirstLaunch)
        {
                                        string szDBUserName = string.Empty;
                                        string szServer = string.Empty;
                                        string szDatabaseName = string.Empty;
                                        string szServerPassword = string.Empty;
                                        string szDBPassword = string.Empty;
                                        string szValue = string.Empty;
                                        string szMessage = string.Empty;
                                        string szFileName = Application.StartupPath + @"\Connection.info";
                                        string szUserName = string.Empty;
                                        string szPassword = string.Empty;
                                        string szSQL = string.Empty;
                                        bool bFileExists = false;
                                        bool bConnectionSuccessful = false;
                                        bool bValueNotFound = false;
                                        MySqlDataReader mysql_dr = null;
                                        EnumsCollection.EnumMessageType emt = new EnumsCollection.EnumMessageType();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bExitWhile = false;
                                        bool bFirstLaunch = false;
                                        string szEncryptedPassword = string.Empty;
                                        ConnectionObject co = new ConnectionObject();
                                        EnumsCollection.EnumDataBaseConnectionError edbce = new EnumsCollection.EnumDataBaseConnectionError();

            while (true)
            {
                fax.FileExists(szFileName,
                               ref bFileExists);

                if (!bFileExists)
                {
                    szMessage = "File Not Found " + szFileName;
                    MessageBox.Show(szMessage,
                                    "Connection File Missing",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
                }

                fax.ConnectToFile(szFileName,
                                  EnumsCollection.EnumFileAccessType.efatRead);

                fax.GetValue("Details",
                             "UserName",
                             ref szValue,
                             ref bValueNotFound);
                szDBUserName = szValue;

                fax.GetValue("Details",
                             "ServerName",
                             ref szValue,
                             ref bValueNotFound);
                szServer = szValue;

                fax.GetValue("Details",
                             "DatabaseName",
                             ref szValue,
                             ref bValueNotFound);
                szDatabaseName = szValue;

                fax.GetValue("Details",
                             "Password",
                             ref szValue,
                             ref bValueNotFound);
                szServerPassword = szValue;

                co.ServerName = szServer;
                co.UserName = szDBUserName;
                co.DataBaseName = szDatabaseName;
                co.Password = szServerPassword;

                XX_CreateDataBaseForFirstTimeUseIf(szServer,
                                                   szDBUserName,
                                                   szServerPassword,
                                                   szDatabaseName,
                                                   ref bErrorFound);

                if (bErrorFound)
                {
                    break;
                }

                dbcx = new DatabaseConnection(co);
               
                dbcx.Connect(ref bConnectionSuccessful,
                             ref szMessage,
                             ref edbce);

                switch (edbce)
                {
                    case EnumsCollection.EnumDataBaseConnectionError.edbceUnableToConnectToHost:
                        emt = EnumsCollection.EnumMessageType.emtError;
                        bExitWhile = true;
                        break;

                    case EnumsCollection.EnumDataBaseConnectionError.edbceNone:
                        emt = EnumsCollection.EnumMessageType.emtSuccess;
                        bExitWhile = false;
                        break;

                }

                if (bExitWhile)
                {
                    break;
                }

                dbcx.ApplicationPathCarrier = apcx;

                if (bErrorFound)
                {
                    break;
                }

                XX_CheckIfFirstTimeLaunch(ref bFirstLaunch,
                                          ref bErrorFound,
                                          ref szErrorMessage);

                if (bFirstLaunch)
                {
                    break;
                }

                szUserName = txtUserName.Text;
                szPassword = txtPassword.Text;

                if (szUserName.Trim() == szxEMPTY)
                {
                    szMessage = "UserName field cannot be empty";
                    emt = EnumsCollection.EnumMessageType.emtError;
                    txtUserName.Focus();
                    break;
                }

                if (szPassword.Trim() == szxEMPTY)
                {
                    szMessage = "Password field cannot be empty";
                    emt = EnumsCollection.EnumMessageType.emtError;
                    txtPassword.Focus();
                    break;
                }

                utsx.Encrypt(txtPassword.Text,
                             ref szEncryptedPassword);

                szSQL = "SELECT UserId, FirstName, UserType FROM users WHERE UserName = "
                      + "'" + szUserName + "' "
                      + " AND Password = "
                      + "'" + szEncryptedPassword + "'";

                dbcx.ExecuteSQL(szSQL,
                                ref bErrorFound,
                                ref szErrorMessage,
                                ref mysql_dr);

                while (true)
                {
                    szMessage = "Wrong Login Details";
                    emt = EnumsCollection.EnumMessageType.emtError;

                    if (mysql_dr.Read())
                    {
                        try
                        {
                            dbcx.EnumUserType = (EnumsCollection.EnumUserType)Convert.ToInt32(mysql_dr["UserType"].ToString());
                            dbcx.CurrentUserName = Convert.ToString(mysql_dr["FirstName"]);

                            emt = EnumsCollection.EnumMessageType.emtSuccess;
                            szMessage = "Login Succeded";
                        }
                        catch (Exception ex)
                        {
                            emt = EnumsCollection.EnumMessageType.emtError;
                            szMessage = ex.Message;
                        }
                    }

                    break;
                }

                break;
            }

            if (mysql_dr != null)
            {
                if (!mysql_dr.IsClosed)
                {
                    mysql_dr.Close();
                }
            }

            emtr = emt;
            szrErrorMessage = szMessage;
            brFirstLaunch = bFirstLaunch;
        }

        private void XX_CreateDataBaseIf(string szvServer,
                                         string szvDataBaseName)
        {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            dbcx.ExecuteSQL("CREATE DATABASE IF NOT EXISTS " + szvDataBaseName,
                            ref bErrorFound,
                            ref szErrorMessage);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
                                            EnumsCollection.EnumMessageType emt = new EnumsCollection.EnumMessageType();
                                            string szMessage = string.Empty;
                                            string szCaption = string.Empty;
                                            bool bFirstLaunch = false;

            while (true)
            {
                XX_ConnectToDataBaseOverLoginDetails(ref emt,
                                                     ref szMessage,
                                                     ref bFirstLaunch);

                if (bFirstLaunch)
                {
                    dbcx.ApplicationPathCarrier.FirstTimeLaunch = true;
                    F_Users f_Users = new F_Users(null,
                                                  dbcx,
                                                  null,
                                                  EnumsCollection.EnumFormMode.efmFirstTimeUse);
                    f_Users.Show();
                    this.Hide();
                    break;
                }

                switch (emt)
                {
                    case EnumsCollection.EnumMessageType.emtSuccess:
                        szCaption = "Success";
                        break;

                    case EnumsCollection.EnumMessageType.emtError:
                        szCaption = "Error";
                        break;

                    case EnumsCollection.EnumMessageType.emtInformation:
                        szCaption = "Information";
                        break;

                }

                if (emt == EnumsCollection.EnumMessageType.emtError
                    || emt == EnumsCollection.EnumMessageType.emtInformation)
                {
                    utsx.ShowMessage(szMessage,
                                     emt);
                    break;
                }

                if (dbcx == null)
                {
                    break;
                }

                dbcx.ApplicationPathCarrier = apcx;

                utsx.ShowMessage("Login Succeeded", 
                                 EnumsCollection.EnumMessageType.emtSuccess);
                this.Hide();

                ConnectionSucceeded(dbcx,
                                    true);
                break;
            }
        }
    }
}
