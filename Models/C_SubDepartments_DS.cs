using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utilities;

namespace Models
{
    public class SubDepartments_DS : I_DataServer
    {
        private DatabaseConnection dbcx = null;
        private Fields fdsx = null;
        private DBTable dbtx = null;
        private SQLGenerator sqlgx = null;
        private Utilities.Utilities utsx = null;
        private string szxCurrentSubDepartmentId = "";
        private const string szxSUB_DEPARTMENTS_TableKey = "SubDepartments";

        public SubDepartments_DS(DatabaseConnection dbcv) 
        {
            dbcx = dbcv;
            fdsx = new Fields();
            utsx = new Utilities.Utilities();
            szxCurrentSubDepartmentId = "0";
            sqlgx = new SQLGenerator();

            dbcx.DBTables.AddDBTable(szxSUB_DEPARTMENTS_TableKey, 
                                     ref dbtx);

            XX_GetFieldsCollectionOverTableName(ref fdsx);

            dbcx.CreateTableForFirstTimeUseIf(szxSUB_DEPARTMENTS_TableKey, 
                                              fdsx);

        }

        public void GetSubDepartmentOverSubDepartmentId(long lvSubDepartmentId,
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

            szSQL = "SELECT * FROM SubDepartments WHERE SubDepartmentId =" + Convert.ToString(lvSubDepartmentId);

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

            szSQL = "SELECT * FROM SubDepartments "
                  + " WHERE DepartmentName   = '" + fdsr.ItemIsField("DepartmentName").StringValue + "' "
                  + " ORDER BY SubDepartmentId ASC LIMIT 1";

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

            szSQL = "SELECT * FROM SubDepartments "
                  + " WHERE SubDepartmentId > " + fdsr.ItemIsField("SubDepartmentId").StringValue
                  + " AND   DepartmentName   = '" + fdsr.ItemIsField("DepartmentName").StringValue + "' "
                  + " ORDER BY SubDepartmentId ASC LIMIT 1";

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

            szSQL = "SELECT * FROM SubDepartments "
                  + " WHERE SubDepartmentId < " + fdsr.ItemIsField("SubDepartmentId").StringValue
                  + " AND   DepartmentName   = '" + fdsr.ItemIsField("DepartmentName").StringValue + "' "
                  + " ORDER BY SubDepartmentId DESC LIMIT 1";

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

        public void RemoveAllSubDepartmentsFromDataBaseOverDepartmentName(Fields fdsv,
                                                                          ref bool brErrorFound,
                                                                          ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;

            szSQL = "DELETE FROM SubDepartments "
                  + " WHERE   "
                  + " DepartmentName   = '" + fdsv.ItemIsField("DepartmentName").StringValue + "' ";

            dbcx.ExecuteSQL(szSQL,
                            ref brErrorFound,
                            ref szrErrorMessage);
        }

        public void RemoveFromDataBaseOverDepartmentName(Fields fdsv,
                                                         ref bool brErrorFound,
                                                         ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;

            szSQL = "DELETE FROM SubDepartments "
                  + " WHERE   "
                  + " SubDepartmentId = " + fdsv.ItemIsField("SubDepartmentId").StringValue
                  + " AND DepartmentName   = '" + fdsv.ItemIsField("DepartmentName").StringValue + "' ";

            dbcx.ExecuteSQL(szSQL,
                            ref brErrorFound,
                            ref szrErrorMessage);
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

            szSQL = "SELECT * FROM SubDepartments "
                  + " WHERE   DepartmentName   = '" + fdsr.ItemIsField("DepartmentName").StringValue + "' "
                  + "ORDER BY SubDepartmentId DESC LIMIT 1";

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
            szxCurrentSubDepartmentId = mysql_drr[pk.FieldName].ToString();

            dbcx.MoveRecordToMemberObject(ref mysql_drr,
                                          ref fdsx);

            fdsr = fdsx;
        }

        public void AddToDataBase(Fields fdsv,
                                  ref bool brErrorFound,
                                  ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        long lSubDepartmentId = 0;
                                        string szCounter = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        long lDepartmentId = 0;
            
            while(true)
            {
                dbcx.CheckIfFieldsHaveValidValues(fdsv,
                                                  ref bErrorFound,
                                                  ref szErrorMessage);

                if (bErrorFound)
                {
                    break;
                }

                lDepartmentId = Convert.ToInt32(fdsv.ItemIsField("DepartmentId").StringValue);
                XX_GetNextSubDepartmentId(ref lSubDepartmentId,
                                          lDepartmentId);

                fdsv.ItemIsField("SubDepartmentId").StringValue = Convert.ToString(lSubDepartmentId);

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

        public void RemoveFromDataBase(Fields fdsv,
                                       ref bool brErrorFound,
                                       ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "DELETE FROM SubDepartments WHERE SubDepartmentId = " + fdsv.ItemIsField("SubDepartmentId").StringValue;

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
            XX_GetNextSubDepartmentId(ref lrId);
        }

        private void XX_GetNextSubDepartmentId(ref long lrSubDepartmentId,
                                               long lvDepartmentId = 0)
        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        long lSubDepartmentId = 0;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "SELECT MAX(SubDepartmentId) FROM SubDepartments WHERE DepartmentId = " + Convert.ToString(lvDepartmentId);

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

                lSubDepartmentId = 1;

                if (mysql_dr.Read())
                {
                    try
                    {
                        lSubDepartmentId = Convert.ToInt32(mysql_dr[0].ToString());
                    }
                    catch
                    {
                        lSubDepartmentId = 0;
                    }
                }
                break;
            }
            if (mysql_dr != null)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            lrSubDepartmentId = lSubDepartmentId + 1;
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

            szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath + @"\" + "SubDepartments.tbl";

            while (true)
            {
                bFileExists = System.IO.File.Exists(szTableFilePath);
                if (!bFileExists)
                {
                    MessageBox.Show("SubDepartments table not found",
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