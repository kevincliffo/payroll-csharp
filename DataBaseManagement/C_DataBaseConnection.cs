using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Sql;
using Utilities;
using System.Windows.Forms;
using CollectionClasses;

namespace DataBaseManagement
{
    public class DatabaseConnection
    {
        private string szxConnectionString;
        private MySqlConnection msql_cnx = null;
        private EnumsCollection.EnumUserType eutx = new EnumsCollection.EnumUserType();
        private string szxrwCurrentUserName = string.Empty;
        private ApplicationPathCarrier apcx = null;
        private ConnectionObject cox = null;
        private const int nxUN_ABLE_TO_CONNECT_TO_HOST_ErrorNumber = 1042;
        private const int nxUN_KNOWN_DATA_BASE_ErrorNumber = 1049;
        private long lxCounter = 1;
        private DBTables dbtrwx = null;
        private Utilities.Utilities utsx = null;
        private SQLGenerator sqlgx = null;
        private NHIFRates nhifrsx = null;
        private Modules msx = null;

        private const string szxGOOSE_FEET_Char = @"""";
        private const string szxEMPTY = "";
        public DatabaseConnection(ConnectionObject cov)
        {
            cox = cov;
            dbtrwx = new DBTables();
            utsx = new Utilities.Utilities();
            sqlgx = new SQLGenerator();

            szxConnectionString = string.Format("SERVER={0}; DATABASE={1}; UID={2}; PASSWORD={3};",
                                                 cox.ServerName,
                                                 cox.DataBaseName,
                                                 cox.UserName,
                                                 cox.Password);
        }

        public void CheckIfFieldsHaveValidValues(Fields fdsv,
                                                 ref bool brErrorFound,
                                                 ref string szrErrorMessage)
        {
                                        bool bErrorFound = false;
                                        bool bIsNumeric = false;
                                        int nIntegerValue = 0;
                                        double dDoubleValue = 0;
                                        string szErrorMessage = string.Empty;
                                        string szMessage = string.Empty;
            
            foreach(Field fd in fdsv)
            {
                switch (fd.EnumFieldType)
                { 
                    case EnumsCollection.EnumFieldType.eftString:
                        if(fd.StringValue == szxEMPTY)
                        {
                            if(fd.ValueRequired)
                            {
                                bErrorFound = true;
                                szMessage = "Value Required for field "
                                          + fd.LocalizedName;
                                break;
                            }
                        }
                        break;
                    case EnumsCollection.EnumFieldType.eftInteger:
                    case EnumsCollection.EnumFieldType.eftLong:
                        bIsNumeric = int.TryParse(fd.StringValue,
                                                  out nIntegerValue);
                        bErrorFound = bIsNumeric == false;

                        if (bErrorFound)
                        {
                            szMessage = szxGOOSE_FEET_Char
                                      + fd.LocalizedName
                                      + szxGOOSE_FEET_Char 
                                      + " Field should Contain value of type Interger/Long";
                        }

                        break;
                    case EnumsCollection.EnumFieldType.eftDouble:
                        bIsNumeric = double.TryParse(fd.StringValue,
                                                     out dDoubleValue);
                        bErrorFound = bIsNumeric == false;
                        if (bErrorFound)
                        {
                            szMessage = szxGOOSE_FEET_Char
                                      + fd.LocalizedName
                                      + szxGOOSE_FEET_Char 
                                      + " Field should Contain value of type Double";
                        }

                        break;
                    case EnumsCollection.EnumFieldType.eftDate:
                    case EnumsCollection.EnumFieldType.eftDateTime:  
                        break;
                    case EnumsCollection.EnumFieldType.eftTime:

                        break;
                }

                if (bErrorFound)
                {
                    szErrorMessage = szMessage;
                    break;
                }
            }

            szrErrorMessage = szErrorMessage;
            brErrorFound = bErrorFound;
        }

        public void CreateTableForFirstTimeUseIf(string szvTableName,
                                                 Fields fdsv)
        { 
                                            string szSQL = string.Empty;
                                            MySqlDataReader mysql_dr = null;
                                            string szErrorMessage = string.Empty;
                                            bool bErrorFound = true;
                                            int nTableCount = 0;

            szSQL = "SELECT COUNT(*) AS TableCount"
                  + " FROM information_schema.tables "
                  + " WHERE table_schema = '" + this.DataBaseName + "' "
                  + " AND table_name = '" + szvTableName.ToLower() + "'";

            XX_ExecuteSQL(szSQL,
                          ref bErrorFound,
                          ref szErrorMessage,
                          ref mysql_dr);

            while (true)
            {
                if (mysql_dr == null) 
                {
                    break;
                }

                if (!mysql_dr.Read())
                {
                    break;
                }

                nTableCount = Convert.ToInt16(mysql_dr["TableCount"].ToString());
                break;
            }

            if (mysql_dr != null)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
                mysql_dr = null;
            }

            if(nTableCount == 0)
            {
                XX_CreateTableForFirstTimeUse(szvTableName,
                                              fdsv);
            }
        
        }

        private void XX_CreateTableForFirstTimeUse(string szvTableName,
                                                   Fields fdsv)
        { 
                                            string szSQL = string.Empty;
                                            string szErrorMessage = string.Empty;
                                            string szMessage = string.Empty;
                                            bool bErrorFound = true;
                                            EnumsCollection.EnumMessageType emt = new EnumsCollection.EnumMessageType();

            sqlgx.CreateSQLQueryForCreateTable(fdsv,
                                               ref szSQL);

            XX_ExecuteSQL(szSQL,
                          ref bErrorFound,
                          ref szErrorMessage);

            szMessage = szvTableName
                      + " table created successfully";
            emt = EnumsCollection.EnumMessageType.emtSuccess;
            if (bErrorFound)
            {
                emt = EnumsCollection.EnumMessageType.emtError;
                szMessage = szErrorMessage
                          + " "
                          + szvTableName;
            }

            if (szvTableName != "Users")
            {
                utsx.ShowMessage(szMessage,
                                 emt);
            }
        }

        public void MoveRecordToMemberObject(ref MySqlDataReader mysql_drr,
                                             ref Fields fdsr)
        {
            foreach (Field fd in fdsr)
            {
                switch (fd.EnumFieldType)
                {
                    case EnumsCollection.EnumFieldType.eftDouble:
                        fdsr.ItemIsField(fd.Key).StringValue = (Convert.ToDouble(mysql_drr[fd.Key]).ToString("0.00"));
                        break;
                    default:
                        fdsr.ItemIsField(fd.Key).StringValue = mysql_drr[fd.Key].ToString();
                        break;
                }

            }
        }

        public Modules ApplicationModules
        {
            get
            {
                return msx;
            }
            set
            {
                msx = value;
            }
        }

        public NHIFRates NHIFRates
        {
            get
            {
                return nhifrsx;
            }
            set
            {
                nhifrsx = value;
            }

        }

        public DBTables DBTables
        {
            get 
            {
                return dbtrwx;
            }
            set
            {
                dbtrwx = value;
            }

        }

        public long Counter 
        {
            get {
                lxCounter = lxCounter + 1;
                return lxCounter;
            }
        }

        public EnumsCollection.EnumUserType EnumUserType
        {
            get
            {
                return eutx;
            }
            set
            {
                eutx = value;
            }
        }
        public MySqlConnection Connection
        {
            get
            {
                return msql_cnx;
            }
        }

        public ApplicationPathCarrier ApplicationPathCarrier 
        {
            get 
            {
                return apcx;
            }
            set 
            {
                apcx = value;
            }
        }
        public void Connect(ref bool brConnectionSuccessful,
                            ref string szrErrorMessage,
                            ref EnumsCollection.EnumDataBaseConnectionError edbcer)
        {
                                        int nErrorNumber = 0;
                                        EnumsCollection.EnumDataBaseConnectionError edbce = new EnumsCollection.EnumDataBaseConnectionError();

            try
            {
                msql_cnx = new MySqlConnection(szxConnectionString);
                msql_cnx.Open();
                brConnectionSuccessful = true;
            }
            catch (MySqlException mysqlexc) 
            {
                brConnectionSuccessful = false;
                szrErrorMessage = mysqlexc.Message;
                nErrorNumber = mysqlexc.Number;

                edbce = EnumsCollection.EnumDataBaseConnectionError.edbceNone;
                switch (nErrorNumber) 
                {
                    case nxUN_ABLE_TO_CONNECT_TO_HOST_ErrorNumber:
                        edbce = EnumsCollection.EnumDataBaseConnectionError.edbceUnableToConnectToHost;
                        break;

                    case nxUN_KNOWN_DATA_BASE_ErrorNumber:
                        edbce = EnumsCollection.EnumDataBaseConnectionError.edbceUnKnownDataBase;
                        break;
                }
            }

            edbcer = edbce;

        }

        public string CurrentUserName
        {
            get
            {
                return szxrwCurrentUserName;
            }
            set 
            {
                szxrwCurrentUserName = value;
            }

        }

        public string ServerName
        {
            get
            {
                return cox.ServerName;
            }
        }

        public string UserName
        {
            get
            {
                return cox.UserName;
            }
        }

        public string DataBaseName
        {
            get
            {
                return cox.DataBaseName;
            }
        }

        public string Password
        {
            get
            {
                return cox.Password;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return cox.ErroMessage;
            }
        }

        public bool ErrorFound
        {
            get
            {
                return cox.ErrorFound;
            }
        }

        public void ExecuteSQL(string szSQL, 
                               ref DataSet dsr,
                               ref bool brErrorFound,
                               ref string szrErrorMessage)
        {
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            if (msql_cnx.State == ConnectionState.Open)
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(szSQL, msql_cnx);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dsr = ds;
                }
                catch (Exception exc)
                {
                    bErrorFound = true;
                    szErrorMessage = exc.Message;
                }

            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void ExecuteSQL(string szvSQL,
                               ref bool brErrorFound,
                               ref string szrErrorMessage)
        {
            XX_ExecuteSQL(szvSQL,
                          ref brErrorFound,
                          ref szrErrorMessage);
        }

        private void XX_ExecuteSQL(string szvSQL,
                                   ref bool brErrorFound,
                                   ref string szrErrorMessage)
        {

                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

            if (msql_cnx.State == ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(szvSQL, msql_cnx);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    szErrorMessage = exc.Message;
                    bErrorFound = true;

                    cox.ErrorFound = true;
                    cox.ErroMessage = exc.Message;
                }
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void ExecuteSQL(string szvSQL,
                               ref bool brErrorFound,
                               ref string szrErrorMessage,
                               ref MySqlDataReader msql_drr)
        {
            XX_ExecuteSQL(szvSQL,
                          ref brErrorFound,
                          ref szrErrorMessage,
                          ref msql_drr);
        }

        private void XX_ExecuteSQL(string szvSQL,
                                   ref bool brErrorFound,
                                   ref string szrErrorMessage,
                                   ref MySqlDataReader msql_drr)
        {
                                            bool bErrorFound = false;
                                            string szErrorMessage = string.Empty;
                                            MySqlDataReader msql_dr = null;

            if(msql_drr != null)
            {
                msql_drr.Dispose();
                msql_drr = null;
            }
            if (msql_cnx.State == ConnectionState.Open)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(szvSQL, msql_cnx);
                    msql_dr = cmd.ExecuteReader();
                    cmd.Dispose();
                    
                }
                catch (Exception exc)
                {
                    cox.ErrorFound = true;
                    bErrorFound = true;
                    cox.ErroMessage = exc.Message;
                    szErrorMessage = exc.Message;
                }

            }

            
            msql_drr = msql_dr;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }
      
    }
}
