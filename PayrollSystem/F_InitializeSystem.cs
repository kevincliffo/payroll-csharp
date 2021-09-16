using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Utilities;

namespace PayRollSystem
{
    public partial class F_InitializeSystem : Form
    {
        private MySqlConnection mysql_conx = null;
        private string szxAPPLICATION_START_UP_PATH_String = Application.StartupPath;
        private Utilities.Utilities utsx = null;
        private SharedComponents scx = null;

        public F_InitializeSystem()
        {
            InitializeComponent();

            utsx = new Utilities.Utilities();
            scx = new SharedComponents();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
                                        bool bEmptyTextBoxFound = false;
                                        string szConnectionString = string.Empty;
                                        bool bErrorFound = false;
                                        string szMessage = string.Empty;

            while (true)
            {
                XX_CheckIfAllTextBoxValuesAreValid(ref bEmptyTextBoxFound);

                if (bEmptyTextBoxFound)
                {
                    break;
                }

                XX_CreateDataBaseForFirstTimeUseIf(ref bErrorFound);

                if (bErrorFound)
                {
                    break;
                }

                XX_CreateUsersTableForFirstTimeUse(ref bErrorFound);

                if (bErrorFound)
                {
                    break;
                }

                XX_AddAdminToDataBase(ref bErrorFound);

                if (bErrorFound)
                {
                    break;
                }

                XX_CreateConnectionFile(ref bErrorFound);

                if (bErrorFound)
                {
                    break;
                }

                szMessage = "Welcome "
                          + txtFirstName.Text
                          + " "
                          + " (" + txtAdminUserName.Text + ")\n"
                          + "The application will now shut down and you will be required to login with the created credentials, good day!";

                MessageBox.Show(szMessage, 
                                "Success");

                this.Close();
                break;
            }
        }

        private void XX_AddAdminToDataBase(ref bool brErrorFound)
        { 
                                        string szSQL = string.Empty;
                                        string szConnectionString = string.Empty;
                                        MySqlCommand mysql_cmd = null;
                                        bool bErrorFound = false;
                                        string szEncryptedPassword = string.Empty;

            utsx.Encrypt(txtAdminPassword.Text,
                         ref szEncryptedPassword);

            szSQL = "INSERT INTO users(UserId, UserName, Password, UserType, FirstName, LastName, OtherName, Email, MobileNo, InventoryModuleEnabled, ProductionModuleEnabled, PayrollModuleEnabled) "
                  + " VALUES(1,'"
                  + txtAdminUserName.Text + "','" + szEncryptedPassword + "'," + "0,'" + txtFirstName.Text + "','" 
                  + txtLastName.Text + "','"      + txtOtherName.Text + " ','" + txtEmail.Text + "','" + txtMobileNo.Text + "', 1, 1, 1);";

            szConnectionString = string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};",
                                               txtServerName.Text,
                                               txtDatabaseName.Text,
                                               txtUserName.Text,
                                               txtPassword.Text);
            try
            {
                if (mysql_conx != null)
                {
                    mysql_conx = null;
                }

                mysql_conx = new MySqlConnection(szConnectionString);
                mysql_cmd = new MySqlCommand(szSQL, mysql_conx);
                mysql_conx.Open();
                mysql_cmd.ExecuteNonQuery();
                mysql_conx.Close();
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                MessageBox.Show(ex.Message,
                                "Connection Error");
            }

            brErrorFound = bErrorFound;
        }

        private void XX_CreateConnectionFile(ref bool brErrorFound)
        {
                                                StreamWriter sw;
                                                string szConnectionFilePath = string.Empty;
                                                bool bErrorFound = false;

            szConnectionFilePath = szxAPPLICATION_START_UP_PATH_String
                                 + "\\Connection.info";

            try
            {
                sw = new StreamWriter(szConnectionFilePath);

                sw.WriteLine("[Details]");
                sw.WriteLine("UserName=" + txtUserName.Text);
                sw.WriteLine("ServerName=" + txtServerName.Text);
                sw.WriteLine("DatabaseName=" + txtDatabaseName.Text);
                sw.WriteLine("Password=" + txtPassword.Text);
                sw.WriteLine("\n");
                sw.Close();
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                MessageBox.Show(ex.Message);
            }
            brErrorFound = bErrorFound;
        }

        private void XX_CreateUsersTableForFirstTimeUse(ref bool brErrorFound)
        {
                                        string szSQL = string.Empty;
                                        string szConnectionString = string.Empty;
                                        MySqlCommand mysql_cmd = null;
                                        bool bErrorFound = false;
        
            szSQL = "CREATE TABLE IF NOT EXISTS users ( "
                  + " UserId INT NOT NULL, UserName VARCHAR(100) NOT NULL, "
                  + " Password VARCHAR(100) NOT NULL, "
                  + " UserType INT NOT NULL, "
                  + " FirstName VARCHAR(100) NOT NULL, "
                  + " LastName VARCHAR(100) NOT NULL, "
                  + " OtherName VARCHAR(100) NOT NULL, "
                  + " Email VARCHAR(100) NOT NULL, "
                  + " MobileNo VARCHAR(100) NOT NULL, "
                  + " InventoryModuleEnabled INT NOT NULL, "
                  + " ProductionModuleEnabled INT NOT NULL, "
                  + " PayrollModuleEnabled INT NOT NULL, "
                  + " PRIMARY KEY (UserId ))";

            szConnectionString = string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};",
                                               txtServerName.Text,
                                               txtDatabaseName.Text,
                                               txtUserName.Text,
                                               txtPassword.Text);
            try
            {
                if (mysql_conx != null)
                {
                    mysql_conx = null;
                }

                mysql_conx = new MySqlConnection(szConnectionString);
                mysql_cmd = new MySqlCommand(szSQL, mysql_conx);
                mysql_conx.Open();
                mysql_cmd.ExecuteNonQuery();
                mysql_conx.Close();
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                MessageBox.Show(ex.Message,
                                "Connection Error");
            }

            brErrorFound = bErrorFound;
        }

        private void XX_CreateDataBaseForFirstTimeUseIf(ref bool brErrorFound)
        {
                                        string szConnectionString = string.Empty;
                                        MySqlCommand mysql_cmd = null;
                                        bool bErrorFound = false;

            szConnectionString = string.Format("SERVER={0}; UID={1}; PASSWORD={2};",
                                 txtServerName.Text,
                                 txtUserName.Text,
                                 txtPassword.Text);

            try
            {
                mysql_conx = new MySqlConnection(szConnectionString);
                mysql_cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS " + txtDatabaseName.Text, mysql_conx);
                mysql_conx.Open();
                mysql_cmd.ExecuteNonQuery();
                mysql_conx.Close();
            }
            catch (Exception ex)
            {
                bErrorFound = true;
                MessageBox.Show(ex.Message,
                                "Connection Error");
            }

            brErrorFound = bErrorFound;
        }

        private void XX_CheckIfAllTextBoxValuesAreValid(ref bool brEmptyTextBoxFound)
        {
                                        bool bEmptyTextBoxFound = false;
                                        string szEmpty = string.Empty;
                                        string szControlDescription = string.Empty;

            while(true)
            {
                txtPassword.Tag = true;
                scx.CheckIfEditableControlValuesAreValid(gbDatabaseDetails.Controls,
                                                         ref bEmptyTextBoxFound,
                                                         ref szControlDescription);

                if (bEmptyTextBoxFound)
                {
                    break;
                }

                scx.CheckIfEditableControlValuesAreValid(gbAdminDetails.Controls,
                                                         ref bEmptyTextBoxFound,
                                                         ref szControlDescription);
                break;
            }

            if (bEmptyTextBoxFound)
            {
                utsx.ShowMessage("Enter Value for '" + szControlDescription + "' Field",
                                 EnumsCollection.EnumMessageType.emtError);
            }

            brEmptyTextBoxFound = bEmptyTextBoxFound;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_InitializeSystem_Load(object sender, EventArgs e)
        {
                                        string szIconsPath = string.Empty;

            szIconsPath = szxAPPLICATION_START_UP_PATH_String
                        + "\\Icons";

            Icon ic = new Icon(szIconsPath + "\\system.ico");
            this.Icon = ic;
        }
    }
}
