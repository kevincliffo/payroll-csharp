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
    public class WorkOrderTemplates_DS : I_DataServer
    {
        private DatabaseConnection dbcx = null;
        private Fields fdsx = null;
        private DBTable dbtx = null;
        private SQLGenerator sqlgx = null;
        private Utilities.Utilities utsx = null;
        private string szxCurrentWorkOrderTemplateId = "";
        private const string szxWORK_ORDER_TEMPLATES_TableKey = "WorkOrderTemplates";

        public WorkOrderTemplates_DS(DatabaseConnection dbcv) 
        {
            dbcx = dbcv;
            fdsx = new Fields();
            utsx = new Utilities.Utilities();
            szxCurrentWorkOrderTemplateId = "0";
            sqlgx = new SQLGenerator();

            dbcx.DBTables.AddDBTable(szxWORK_ORDER_TEMPLATES_TableKey, 
                                     ref dbtx);

            XX_GetFieldsCollectionOverTableName(ref fdsx);

            dbcx.CreateTableForFirstTimeUseIf(szxWORK_ORDER_TEMPLATES_TableKey, 
                                              fdsx);

        }

        public void GetWorkOrderTemplateOverWorkOrderTemplateId(long lvWorkOrderTemplateId,
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

            szSQL = "SELECT * FROM WorkOrderTemplates WHERE WorkOrderTemplateId =" + Convert.ToString(lvWorkOrderTemplateId);

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

            szSQL = "SELECT * FROM WorkOrderTemplates ORDER BY WorkOrderTemplateId ASC LIMIT 1";

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

            szSQL = "SELECT * FROM WorkOrderTemplates WHERE WorkOrderTemplateId > " + fdsr.ItemIsField("WorkOrderTemplateId").StringValue + " ORDER BY + WorkOrderTemplateId ASC LIMIT 1";

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

            szSQL = "SELECT * FROM WorkOrderTemplates WHERE WorkOrderTemplateId < " + fdsr.ItemIsField("WorkOrderTemplateId").StringValue + " ORDER BY WorkOrderTemplateId DESC LIMIT 1";

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

            szSQL = "SELECT * FROM WorkOrderTemplates ORDER BY WorkOrderTemplateId DESC LIMIT 1";

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
            szxCurrentWorkOrderTemplateId = mysql_drr[pk.FieldName].ToString();

            dbcx.MoveRecordToMemberObject(ref mysql_drr,
                                          ref fdsx);

            fdsr = fdsx;
        }

        public void AddToDataBase(Fields fdsv,
                                  ref bool brErrorFound,
                                  ref string szrErrorMessage)
        {
                                        string szSQL = string.Empty;
                                        long lWorkOrderTemplateId = 0;
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

                XX_GetNextWorkOrderTemplateId(ref lWorkOrderTemplateId);

                fdsv.ItemIsField("WorkOrderTemplateId").StringValue = Convert.ToString(lWorkOrderTemplateId);

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

            szSQL = "DELETE FROM WorkOrderTemplates WHERE WorkOrderTemplateId = " + fdsv.ItemIsField("WorkOrderTemplateId").StringValue;

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
            XX_GetNextWorkOrderTemplateId(ref lrId);
        }

        private void XX_GetNextWorkOrderTemplateId(ref long lrWorkOrderTemplateId)
        {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        long lWorkOrderTemplateId = 0;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

            szSQL = "SELECT MAX(WorkOrderTemplateId) FROM WorkOrderTemplates";

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

                lWorkOrderTemplateId = 1;

                if (mysql_dr.Read())
                {
                    try
                    {
                        lWorkOrderTemplateId = Convert.ToInt32(mysql_dr[0].ToString());
                    }
                    catch
                    {
                        lWorkOrderTemplateId = 0;
                    }
                }
                break;
            }
            if (mysql_dr != null)
            {
                mysql_dr.Close();
                mysql_dr.Dispose();
            }

            lrWorkOrderTemplateId = lWorkOrderTemplateId + 1;
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

            szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath + @"\" + "WorkOrderTemplates.tbl";

            while (true)
            {
                bFileExists = System.IO.File.Exists(szTableFilePath);
                if (!bFileExists)
                {
                    MessageBox.Show("WorkOrderTemplates table not found",
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