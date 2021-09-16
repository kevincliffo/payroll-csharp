using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class EnumsCollection
{
    public enum EnumWorkType
    {
        ewtInternal = 0,
        ewtExternal = 1
    }

    public enum EnumMaterialManagementType
    {
        emmtNone = 0,
        emmtSerial = 1,
        emmtBatch = 2
    }

    public enum EnumAttendanceTimeType
    { 
        eattExtraTime = 0,
        eattAbscenceTime = 1
    }

    public enum EnumFileAccessType
    { 
        efatRead,
        efatWrite
    }

    public enum EnumFieldType 
    { 
        eftString,
        eftInteger,
        eftLong,
        eftDouble,
        eftDateTime,
        eftDate,
        eftTime
    }

    public enum EnumUserType 
    {
        eutAdministrator = 0,
        eutUser = 1,
        eutVisitor = 2
    }

    public enum EnumMessageType 
    {
        emtNone,
        emtSuccess,
        emtInformation,
        emtError,
        emtFirstTimeLaunch
    }

    public enum EnumFormMode 
    {
        efmOk,
        efmAdd,
        efmUpdate,
        efmFind,
        efmFirstTimeUse
    }

    public enum EnumFormType
    {
        eftMDIForm = 0,
        eftMaster = 1,
        eftService = 2
    }

    public enum EnumChooseFromListTableType 
    {
        ecflttNone,
        ecflttUsers,
        ecflttTeachers,
        ecflttStudents,
        ecflttStaff
    }

    public enum EnumBirthdayDateTime 
    {
        ebdtPast,
        ebdtPresent,
        ebdtFuture
    }

    public enum EnumDataBaseConnectionError
    {
        edbceNone,
        edbceUnableToConnectToHost,
        edbceUnKnownDataBase
    }

    public enum EnumDaysOfWeek 
    {
        edowMonday,
        edowTuesday,
        edowWednesday,
        edowThursday,
        edowFriday,
        edowSaturday,
        edowSunday
    
    }

    public enum EnumDataBaseTasks 
    {
        edbtNone = 0,
        edbtCreate = 1,
        edbtUpdate = 2,
        edbtDelete = 3
    }

    public enum EnumRecordNavigationTasks
    { 
        erntNewRecord,
        erntFindRecord,
        erntRemoveRecord,
        erntMoveToFirstRecord,
        erntMoveToPreviousRecord,
        erntMoveToNextRecord,
        erntMoveToLastRecord,
    }

    public enum EnumEmploymentType
    { 
        eetPermanent = 0,
        eetCasual = 1
    }

    public enum EnumHourlyRateCalculationType
    { 
        ehrctMonthly = 0,
        ehrctWeekly = 1
    }
}
}
