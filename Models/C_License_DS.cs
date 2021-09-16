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
public class License_DS : I_DataServer
{
    private DatabaseConnection dbcx = null;
    private Fields fdsx = null;
    private DBTable dbtx = null;
    private SQLGenerator sqlgx = null;
    private Utilities.Utilities utsx = null;
    private string szxCurrentLicenseCode = "";
    private const string szxLICENSE_TableKey = "License";

    public License_DS(DatabaseConnection dbcv) 
    {
        dbcx = dbcv;
        fdsx = new Fields();
        utsx = new Utilities.Utilities();
        szxCurrentLicenseCode = "0";

        dbcx.DBTables.AddDBTable(szxLICENSE_TableKey,
                                 ref dbtx);

        sqlgx = new SQLGenerator();
        XX_GetFieldsCollectionOverTableName(ref fdsx);

        dbcx.CreateTableForFirstTimeUseIf(szxLICENSE_TableKey,
                                          fdsx);

        //XX_InitializeLicenseTableIf();
    }

    public void SetApplicationStartUseDate()
    {
                                        string szStartDate = string.Empty;
                                        string szStartTime = string.Empty;

        utsx.GetDateStringValueOverDate(DateTime.Now,
                                        ref szStartDate,
                                        ref szStartTime);

    }

    private void XX_InitializeLicenseTableIf()
    { 
                                    string szErrorMessage = string.Empty;
                                    bool bErrorFound = false;
                                    bool bNothingFound = true;
                                    string szEncryptedString = string.Empty;
                                    Fields fds = null;

        XX_GetFirstRecordFromDataBase(ref fds,
                                      ref bNothingFound,
                                      ref bErrorFound,
                                      ref szErrorMessage);

        while (true)
        {
            if (bNothingFound == false)
            {
                break;
            }

            if (bErrorFound)
            {
                utsx.ShowMessage(szErrorMessage,
                                 EnumsCollection.EnumMessageType.emtError);
                break;
            }

            utsx.Encrypt("1",
                         ref szEncryptedString);

            fdsx.ItemIsField("LicenseKey").StringValue = "1";
            fdsx.ItemIsField("LicenseValue").StringValue = szEncryptedString;

            AddToDataBase(fdsx,
                          ref bErrorFound,
                          ref szErrorMessage);

            break;
        }
    }

    public void GetFirstRecordFromDataBase(ref Fields fdsr,
                                           ref bool brNothingFound,
                                           ref bool brErrorFound,
                                           ref string szrErrorMessage)
    {
        XX_GetFirstRecordFromDataBase(ref fdsr,
                                      ref brNothingFound,
                                      ref brErrorFound,
                                      ref szrErrorMessage);
    }

    private void XX_GetFirstRecordFromDataBase(ref Fields fdsr, 
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

        szSQL = "SELECT * FROM License ORDER BY Code ASC LIMIT 1";

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
        XX_GetNextRecordFromDataBase(ref fdsr,
                                     ref brEndOfFind,
                                     ref brErrorFound,
                                     ref szrErrorMessage);
    }

    private void XX_GetNextRecordFromDataBase(ref Fields fdsr, 
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

        szSQL = "SELECT * FROM License WHERE Code > " + fdsr.ItemIsField("Code").StringValue
              + " ORDER BY Code ASC LIMIT 1";

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

        szSQL = "SELECT * FROM License WHERE Code < " + fdsr.ItemIsField("Code").StringValue
              + " ORDER BY Code DESC LIMIT 1";

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

        szSQL = "SELECT * FROM License ORDER BY Code DESC LIMIT 1";

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
        szxCurrentLicenseCode = mysql_drr[pk.FieldName].ToString();

        dbcx.MoveRecordToMemberObject(ref mysql_drr,
                                      ref fdsx);

        fdsr = fdsx;
    }

    public void AddToDataBase(Fields fdsv, 
                              ref bool brErrorFound, 
                              ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;
                                        long lLicenseCode = 0;
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

            XX_GetNextLicenseCode(ref lLicenseCode);

            fdsv.ItemIsField("Code").StringValue = Convert.ToString(lLicenseCode);

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

    private void XX_GetNextLicenseCode(ref long lrLicenseCode) 
    {
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        long lLicenseCode = 0;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = true;

        szSQL = "SELECT MAX(Code) FROM License";

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

            lLicenseCode = 1;

            if (mysql_dr.Read())
            {
                try
                {
                    lLicenseCode = Convert.ToInt32(mysql_dr[0].ToString());
                }
                catch
                {
                    lLicenseCode = 0;
                }
            }
            break;
        }

        if (mysql_dr != null) 
        {
            mysql_dr.Close();
            mysql_dr.Dispose();
        }

        lrLicenseCode = lLicenseCode + 1;
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
                        + "License.tbl";

        while (true)
        {
            bFileExists = System.IO.File.Exists(szTableFilePath);
            if (!bFileExists)
            {
                MessageBox.Show("License table not found",
                                "Missing Table File");
                break;
            }

            dbtx.GetFieldsCollection(szTableFilePath,
                                     ref fdsr);

            break;
        }

    }

    public void RemoveAllFromDataBase(ref bool brErrorFound,
                                      ref string szrErrorMessage)
    {
                                        string szSQL = string.Empty;

        szSQL = "DELETE FROM License";

        dbcx.ExecuteSQL(szSQL,
                        ref brErrorFound,
                        ref szrErrorMessage);
    }

    public void RemoveFromDataBase(Fields fdsv,
                                   ref bool brErrorFound,
                                   ref string szrErrorMessage) 
    {
                                    string szSQL = string.Empty;

        szSQL = "DELETE FROM License WHERE Code = " + fdsv.ItemIsField("Code").StringValue;

        dbcx.ExecuteSQL(szSQL,
                        ref brErrorFound,
                        ref szrErrorMessage);
    }

    public void UpdateDataInDataBase(Fields fdsv,
                                     ref bool brErrorFound,
                                     ref string szrErrorMessage)
    {
        XX_UpdateDataInDataBase(fdsv,
                                ref brErrorFound,
                                ref szrErrorMessage);
    }

    private void XX_UpdateDataInDataBase(Fields fdsv,
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
        XX_GetNextLicenseCode(ref lrId);
    }

}
}
