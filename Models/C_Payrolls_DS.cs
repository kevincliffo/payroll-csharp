using System;
using System.Windows.Forms;
using DataBaseManagement;
using MySql.Data.MySqlClient;

namespace Models
{
    public class Payrolls_DS : I_DataServer
    {
        private DatabaseConnection dbcx = null;
        private Fields fdsx = null;
        private DBTable dbtx = null;
        private SQLGenerator sqlgx = null;
        private Utilities.Utilities utsx = null;
        private string szxCurrentPayrollId = "";
        private const string szxPAYROLLS_TableKey = "Payrolls";

        public Payrolls_DS(DatabaseConnection dbcv) 
        {
            dbcx = dbcv;
            fdsx = new Fields();
            utsx = new Utilities.Utilities();
            szxCurrentPayrollId = "0";
            sqlgx = new SQLGenerator();

            dbcx.DBTables.AddDBTable(szxPAYROLLS_TableKey, 
                                     ref dbtx);

            XX_GetFieldsCollectionOverTableName(ref fdsx);

            dbcx.CreateTableForFirstTimeUseIf(szxPAYROLLS_TableKey, 
                                              fdsx);

        }

        public void GetPayrollOverPayrollId(long lvPayrollId,
                                            ref Fields fdsr,
                                            ref bool brNothingFound,
                                            ref bool brErrorFound,
                                            ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            szSQL = "SELECT * FROM Payrolls WHERE PayrollId =" + Convert.ToString(lvPayrollId);

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fds);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            fdsr = fds;
            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void GetFirstRecordFromDataBase(ref Fields fdsr,
                                               ref bool brNothingFound,
                                               ref bool brErrorFound,
                                               ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            szSQL = "SELECT * FROM Payrolls ORDER BY PayrollId ASC LIMIT 1";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fds);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            fdsr = fds;
            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void GetNextRecordFromDataBase(ref Fields fdsr,
                                              ref bool brNothingFound,
                                              ref bool brErrorFound,
                                              ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            szSQL = "SELECT * FROM Payrolls WHERE PayrollId > " + fdsr.ItemIsField("PayRollId").StringValue + " ORDER BY PayrollId ASC LIMIT 1";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fds);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            fdsr = fds;
            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void GetPreviousRecordFromDataBase(ref Fields fdsr,
                                                  ref bool brNothingFound,
                                                  ref bool brErrorFound,
                                                  ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            szSQL = "SELECT * FROM Payrolls WHERE PayrollId < " + fdsr.ItemIsField("PayRollId").StringValue + " ORDER BY PayrollId DESC LIMIT 1";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fds);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            fdsr = fds;
            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void GetLastRecordFromDataBase(ref Fields fdsr,
                                              ref bool brNothingFound,
                                              ref bool brErrorFound,
                                              ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            szSQL = "SELECT * FROM Payrolls ORDER BY PayrollId DESC LIMIT 1";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fds);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            fdsr = fds;
            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void XX_MoveDataReaderValuesToFields(ref MySqlDataReader mysql_drr,
                                                     ref Fields fdsr)
        {
                                        PrimaryKey pk = null;

            pk = fdsx.PrimaryKeys.ItemIsPrimaryKey(0);
            szxCurrentPayrollId = mysql_drr[pk.FieldName].ToString();

            dbcx.MoveRecordToMemberObject(ref mysql_drr,
                                          ref fdsx);

            fdsr = fdsx;
        }

        public void AddToDataBase(Fields fdsv,
                                  ref bool brErrorFound,
                                  ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        long lPayrollId = 0;
                                        string szCounter = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            while(true)
            {
                dbcx.CheckIfFieldsHaveValidValues(fdsv,
                                                  ref bErrorFound,
                                                  ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                XX_GetNextPayrollId(ref lPayrollId);

                fdsv.ItemIsField("PayRollId").StringValue = Convert.ToString(lPayrollId);

                sqlgx.CreateSQLQueryForInsertOverFieldsCollection(fdsv,
                                                                  ref szSQL);

                dbcx.ExecuteSQL(szSQL,
                                ref bErrorFound,
                                ref szErrorMessage);
                break;
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public void RemoveAllFromDataBase(ref bool brErrorFound,
                                          ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "DELETE FROM Payrolls";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage);

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;        
        }

        public void RemoveFromDataBase(Fields fdsv,
                                       ref bool brErrorFound,
                                       ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "DELETE FROM Payrolls WHERE PayrollId = " + fdsv.ItemIsField("PayRollId").StringValue;

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage);

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        public Fields Fields 
        {
            get
            {
                return fdsx;
            }
        }

        public void GetNextHighestId(ref long lrId) 
        {
            XX_GetNextPayrollId(ref lrId);
        }

        private void XX_GetNextPayrollId(ref long lrPayrollId)
        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        long lPayrollId = 0;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "SELECT MAX(PayrollId) FROM Payrolls";

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr == null)
                {
                    break;
                }

                lPayrollId = 1;

                if (mysql_dr.Read())
                {
                    try
                    {
                        lPayrollId = Convert.ToInt32(mysql_dr[0].ToString());
                    }
                    catch
                    {
                        lPayrollId = 0;
                    }
                }
                break;
            }
            if (mysql_dr != null)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            lrPayrollId = lPayrollId + 1;
        }

        public void UpdateDataInDataBase(Fields fdsv,
                                         ref bool brErrorFound,
                                         ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            while(true)
            {
                dbcx.CheckIfFieldsHaveValidValues(fdsv,
                                                  ref bErrorFound,
                                                  ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                sqlgx.CreateSQLQueryForUpdateTable(fdsv,
                                                   ref szSQL);

                dbcx.ExecuteSQL(szSQL,
                                ref bErrorFound,
                                ref szErrorMessage);
                break;
            }

            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

        private void XX_GetFieldsCollectionOverTableName(ref Fields fdsr)
        {
                                        string szTableFilePath = string.Empty;
                                        bool bFileExists = false;

            szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath + @"\" + "Payrolls.tbl";

            while (true)
            {
                bFileExists = System.IO.File.Exists(szTableFilePath);
                if (!bFileExists)
                {
                    MessageBox.Show("Payrolls table not found",
                                    "Missing Table File");
                }

                dbtx.GetFieldsCollection(szTableFilePath,
                                         ref fdsr);

                break;
            }
        }

        public void FindRecordOverFieldValues(ref Fields fdsr,
                                              ref bool brErrorFound,
                                              ref bool brNothingFound,
                                              ref string szrErrorMessage)

        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

            sqlgx.CreateSQLQueryForFindRecord(fdsr,
                                              ref szSQL);

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage,
                            ref mysql_dr);

            while (true)
            {
                while (mysql_dr.Read())
                {
                    bNothingFound = false;
                    XX_MoveDataReaderValuesToFields(ref mysql_dr,
                                                    ref fdsr);
                }
                break;
            }

            if (!mysql_dr.IsClosed)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            brNothingFound = bNothingFound;
            brErrorFound = bErrorFound;
            szrErrorMessage = szErrorMessage;
        }

    }
}