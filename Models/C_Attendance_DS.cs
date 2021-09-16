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
using System.Data;

namespace Models
{
public class Attendance_DS : I_DataServer
{
    private DatabaseConnection dbcx = null;
    private Users usrsx = null;
    private Fields fdsx = null;
    private DBTable dbtx = null;
    private SQLGenerator sqlgx = null;
    private Utilities.Utilities utsx = null;
    private string szxCurrentUserId = "";
    private const string szxATTENDANCE_TableKey = "Attendance";
    private const double dxHOURS_PER_MONTH = 189.0;

    public Attendance_DS(DatabaseConnection dbcv) 
    {
        dbcx = dbcv;
        usrsx = new Users();
        fdsx = new Fields();
        utsx = new Utilities.Utilities();
        szxCurrentUserId = "0";

        dbcx.DBTables.AddDBTable(szxATTENDANCE_TableKey,
                                 ref dbtx);

        sqlgx = new SQLGenerator();
        XX_GetFieldsCollectionOverTableName(ref fdsx);

        dbcx.CreateTableForFirstTimeUseIf(szxATTENDANCE_TableKey,
                                          fdsx);
    }

    public void CalculateMonthlyAmountOverEmployeeId(long lvEmployeeId,
                                                     double dvRatePerHour,
                                                     double dvOverTimeRate,
                                                     ref double drCalculatedAmount)
    {
                                        double dExtraHours = 0;
                                        double dAbsenceHours = 0;
                                        double dHours = 0;
                                        double dCalculatedAmount = 0;
                                        double dNormalSalary = 0;

        XX_GetExtraAttendanceHoursOverEmployeeId(lvEmployeeId,
                                                 ref dExtraHours);

        XX_GetAbsenceAttendanceHoursOverEmployeeId(lvEmployeeId,
                                                   ref dAbsenceHours);

        dHours = dExtraHours - dAbsenceHours;

        while (true)
        {
            if (dHours < 0)
            {
                dCalculatedAmount = (dxHOURS_PER_MONTH - Math.Abs(dHours)) * dvRatePerHour;
                break;
            }

            if (dHours == 0)
            {
                dCalculatedAmount = dxHOURS_PER_MONTH * dvRatePerHour;
                break;
            }

            if (dHours > 0)
            {
                dNormalSalary = dxHOURS_PER_MONTH * dvRatePerHour;
                dCalculatedAmount = dHours * dvOverTimeRate * dvRatePerHour;

                dCalculatedAmount = dCalculatedAmount + dNormalSalary;
                break;
            }
            break;
        }

        drCalculatedAmount = dCalculatedAmount;
    }

    private void XX_GetAbsenceAttendanceHoursOverEmployeeId(long lvEmployeeId,
                                                            ref double drAbsenceHours)
    {
                                        string szSQL = string.Empty;
                                        double dAbsenceHours = 0;
                                        MySqlDataReader mysql_dr = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szTotalHours = string.Empty;

        szSQL = "SELECT SUM(Hours) AS TOTAL_HOURS FROM attendance WHERE EmployeeId =" + Convert.ToString(lvEmployeeId)
              + " AND AttendanceType = " + Convert.ToString(1);

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

            if (mysql_dr.Read() == true)
            {
                try
                {
                    szTotalHours = Convert.ToString(mysql_dr["TOTAL_HOURS"].ToString());
                    dAbsenceHours = Convert.ToDouble(mysql_dr["TOTAL_HOURS"].ToString());
                }
                catch
                {
                    dAbsenceHours = 0;
                }
            }

            break;
        }

        if (!mysql_dr.IsClosed)
        {
            mysql_dr.Close();
            mysql_dr.Dispose();
        }

        drAbsenceHours = dAbsenceHours;
    }

    private void XX_GetExtraAttendanceHoursOverEmployeeId(long lvEmployeeId,
                                                          ref double drExtraHours)
    {
                                        string szSQL = string.Empty;
                                        double dExtraHours = 0;
                                        MySqlDataReader mysql_dr = null;
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;

        szSQL = "SELECT SUM(Hours) AS TOTAL_HOURS FROM attendance WHERE EmployeeId =" + Convert.ToString(lvEmployeeId)
              + " AND AttendanceType = " + Convert.ToString(0);

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

            if (mysql_dr.Read() == true)
            {
                try
                {
                    dExtraHours = Convert.ToDouble(mysql_dr["TOTAL_HOURS"].ToString());
                }
                catch
                {
                    dExtraHours = 0;
                }
            }
            break;
        }

        if (!mysql_dr.IsClosed)
        {
            mysql_dr.Close();
            mysql_dr.Dispose();
        }

        drExtraHours = dExtraHours;
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

        szSQL = "SELECT * FROM Attendance ORDER BY AttendanceId ASC LIMIT 1";

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

        szSQL = "SELECT * FROM Attendance WHERE AttendanceId > " + fdsr.ItemIsField("AttendanceId").StringValue
              + " ORDER BY AttendanceId ASC LIMIT 1";

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

        szSQL = "SELECT * FROM Attendance WHERE AttendanceId < " + fdsr.ItemIsField("AttendanceId").StringValue
              + " ORDER BY AttendanceId DESC LIMIT 1";

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

        szSQL = "SELECT * FROM Attendance ORDER BY AttendanceId DESC LIMIT 1";

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

            fdsv.ItemIsField("AttendanceId").StringValue = Convert.ToString(lUserId);

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

        szSQL = "SELECT MAX(AttendanceId) FROM Attendance";

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
                        + "Attendance.tbl";

        while (true)
        {
            bFileExists = System.IO.File.Exists(szTableFilePath);
            if (!bFileExists)
            {
                MessageBox.Show("Attendance table not found",
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

        szSQL = "DELETE FROM users WHERE AttendanceId = " + fdsv.ItemIsField("AttendanceId").StringValue;

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
