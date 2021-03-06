using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using CollectionClasses;
using MySql.Data;
using MySql.Data.MySqlClient;
using Utilities;
using DataBaseManagement;
using System.Windows.Forms;
using Models;

namespace Models
{
public class Users_DS : I_DataServer
{
    private DatabaseConnection dbcx = null;
    private Users usrsx = null;
    private Fields fdsx = null;
    private DBTable dbtx = null;
    private SQLGenerator sqlgx = null;
    private Utilities.Utilities utsx = null;
    private string szxCurrentUserId = "";
    private const string szxUSERS_TableKey = "Users";

    public Users_DS(DatabaseConnection dbcv) 
    {
        dbcx = dbcv;
        usrsx = new Users();
        fdsx = new Fields();
        utsx = new Utilities.Utilities();
        szxCurrentUserId = "0";

        dbcx.DBTables.AddDBTable(szxUSERS_TableKey,
                                 ref dbtx);

        sqlgx = new SQLGenerator();
        XX_GetFieldsCollectionOverTableName(ref fdsx);

        dbcx.CreateTableForFirstTimeUseIf(szxUSERS_TableKey,
                                          fdsx);
    }

    public void GetUsersFromDataBase(ref Users usrsr) 
    {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        User us = new User();
                                        string szKey = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = true;

        szSQL = "SELECT * FROM users";

        dbcx.ExecuteSQL(szSQL,
                        ref bErrorFound,
                        ref szErrorMessage,
                        ref mysql_dr);


        while (mysql_dr.Read()) 
        {
            szKey = Convert.ToString(usrsx.UserCount);
            usrsx.AddUser(szKey,
                          ref us);

            us.UserId = Convert.ToInt32(mysql_dr["UserId"].ToString());
            us.UserName = mysql_dr["UserName"].ToString();
            us.Password = mysql_dr["Password"].ToString();
            us.FirstName = mysql_dr["FirstName"].ToString();
            us.LastName = mysql_dr["LastName"].ToString();
            us.OtherName = mysql_dr["OtherName"].ToString();
            us.Email = mysql_dr["Email"].ToString();

        }

        mysql_dr.Close();
        mysql_dr.Dispose();
    }

    public void GetUserOverUserId(long lvUserId,
                                  ref Fields fdsr,
                                  ref bool brNothingFound,
                                  ref bool brErrorFound,
                                  ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        string szKey = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        Fields fds = new Fields();
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        bool bNothingFound = true;

        szSQL = "SELECT * FROM Users WHERE UserId =" + Convert.ToString(lvUserId);

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
                                    string szKey = string.Empty;
                                    MySqlDataReader mysql_dr = null;
                                    Fields fds = new Fields();
                                    string szErrorMessage = string.Empty;
                                    bool bErrorFound = false;
                                    bool bNothingFound = true;

        szSQL = "SELECT * FROM users ORDER BY UserId ASC LIMIT 1";

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
                                          ref bool brEndOfFind, 
                                          ref bool brErrorFound, 
                                          ref string szrErrorMessage)
    {
                        string szSQL = string.Empty;
                        string szKey = string.Empty;
                        bool bEndOfFind = true;
                        MySqlDataReader mysql_dr = null;
                        Fields fds = new Fields();
                        string szErrorMessage = string.Empty;
                        bool bErrorFound = true;

        szSQL = "SELECT * FROM users WHERE UserId > " + fdsr.ItemIsField("UserId").StringValue
              + " ORDER BY UserId ASC LIMIT 1";

        dbcx.ExecuteSQL(szSQL,
                        ref bErrorFound,
                        ref szErrorMessage,
                        ref mysql_dr);

        while (true)
        {
            while (mysql_dr.Read())
            {
                bEndOfFind = false;

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
        brEndOfFind = bEndOfFind;
        brErrorFound = bErrorFound;
        szrErrorMessage = szErrorMessage;
    }

    public void GetPreviousRecordFromDataBase(ref Fields fdsr, 
                                              ref bool brEndOfFind, 
                                              ref bool brErrorFound, 
                                              ref string szrErrorMessage)
    {
                                    string szSQL = string.Empty;
                                    string szKey = string.Empty;
                                    bool bEndOfFind = true;
                                    MySqlDataReader mysql_dr = null;
                                    Fields fds = new Fields();
                                    string szErrorMessage = string.Empty;
                                    bool bErrorFound = true;

        szSQL = "SELECT * FROM users WHERE UserId < " + fdsr.ItemIsField("UserId").StringValue
              + " ORDER BY UserId DESC LIMIT 1";

        dbcx.ExecuteSQL(szSQL,
                        ref bErrorFound,
                        ref szErrorMessage,
                        ref mysql_dr);

        while (true)
        {
            while (mysql_dr.Read())
            {
                bEndOfFind = false;
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
        brEndOfFind = bEndOfFind;
        brErrorFound = bErrorFound;
        szrErrorMessage = szErrorMessage;
    }

    public void GetLastRecordFromDataBase(ref Fields fdsr, 
                                          ref bool brNothingFound, 
                                          ref bool brErrorFound, 
                                          ref string szrErrorMessage)
    {
                                    string szSQL = string.Empty;
                                    string szKey = string.Empty;
                                    MySqlDataReader mysql_dr = null;
                                    Fields fds = new Fields();
                                    string szErrorMessage = string.Empty;
                                    bool bErrorFound = true;
                                    bool bNothingFound = true;

        szSQL = "SELECT * FROM users ORDER BY UserId DESC LIMIT 1";

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
        szxCurrentUserId = mysql_drr[pk.FieldName].ToString();

        dbcx.MoveRecordToMemberObject(ref mysql_drr,
                                      ref fdsx);

        fdsr = fdsx;
    }

    public void AddToDataBaseFirstTime(Fields fdsv, 
                                       ref bool brErrorFound, 
                                       ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        string szCounter = string.Empty;
                                        bool bErrorFound = true;


        while(true)
        {
            sqlgx.CreateSQLQueryForCreateTable(fdsv,
                                               ref szSQL);

            dbcx.ExecuteSQL(szSQL,
                            ref bErrorFound,
                            ref szErrorMessage);

            if (bErrorFound)
            {
                break;
            }

            //fdsv.ItemIsField("UserId").StringValue = Convert.ToString(lUserId);

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

    public void AddToDataBase(Fields fdsv, 
                              ref bool brErrorFound, 
                              ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        long lUserId = 0;
                                        string szErrorMessage = string.Empty;
                                        string szCounter = string.Empty;
                                        bool bErrorFound = true;
        
        while(true)
        {
            dbcx.CheckIfFieldsHaveValidValues(fdsv,
                                                ref bErrorFound,
                                                ref szErrorMessage);

            if (bErrorFound)
            {
                break;
            }

            XX_GetNextUserId(ref lUserId);

            fdsv.ItemIsField("UserId").StringValue = Convert.ToString(lUserId);

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

    private void XX_GetNextUserId(ref long lrUserId) 
    {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        long lUserId = 0;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = true;

        szSQL = "SELECT MAX(UserId) FROM users";

        dbcx.ExecuteSQL(szSQL,
                        ref bErrorFound,
                        ref szErrorMessage,
                        ref mysql_dr);

        while (true) 
        {
            if (mysql_dr == null) 
            {
                break;
            }

            lUserId = 1;

            if (mysql_dr.Read())
            {
                try
                {
                    lUserId = Convert.ToInt32(mysql_dr[0].ToString());
                }
                catch
                {
                    lUserId = 0;
                }
            }
            break;
        }

        if (mysql_dr != null) 
        {
            mysql_dr.Close();
            mysql_dr.Dispose();
        }

        lrUserId = lUserId + 1;
    }

    public Fields Fields
    {
        get {
            return fdsx;
        }
    }

    private void XX_GetFieldsCollectionOverTableName(ref Fields fdsr)
    {
                                        string szTableFilePath = string.Empty;
                                        bool bFileExists = false;
                                        ArrayList alFieldNames = new ArrayList();
                                        Field fd = new Field();

        szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath
                        + @"\"
                        + "Users.tbl";

        while (true)
        {
            bFileExists = System.IO.File.Exists(szTableFilePath);
            if (!bFileExists)
            {
                MessageBox.Show("Members table not found",
                                "Missing Table File");
                break;
            }

            dbtx.GetFieldsCollection(szTableFilePath,
                                     ref fdsr);

            break;
        }

    }

    public void RemoveFromDataBase(Fields fdsv,
                                   ref bool brErrorFound,
                                   ref string szrErrorMessage) 
    {
                                    string szSQL = string.Empty;

        szSQL = "DELETE FROM users WHERE UserId = " + fdsv.ItemIsField("UserId").StringValue;

        dbcx.ExecuteSQL(szSQL,
                        ref brErrorFound,
                        ref szrErrorMessage);
    }

    public void UpdateDataInDataBase(Fields fdsv,
                                     ref bool brErrorFound,
                                     ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        string szCounter = string.Empty;
                                        bool bErrorFound = true;
        
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

    public void FindRecordOverFieldValues(ref Fields fdsr, 
                                          ref bool brErrorFound,
                                          ref bool brNothingFound,
                                          ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = true;
                                        MySqlDataReader mysql_dr = null;
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

    public void GetNextHighestId(ref long lrId)
    {
        XX_GetNextUserId(ref lrId);
    }

}
}
