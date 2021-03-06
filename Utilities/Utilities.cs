using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Utilities
{
public class Utilities
{
    private static byte[] bytKey = new byte[8] {1, 2, 3, 4, 5, 6, 7, 8};
    private static byte[] bytValue = new byte[8] {1, 2, 3, 4, 5, 6, 7, 8};

    public delegate void delDisplayMessageInStatusBar(string szvMessage,
                                                      EnumsCollection.EnumMessageType emtv);

    public event delDisplayMessageInStatusBar DisplayMessageInStatusBar;
    //private ApplicationSettings asx = null;

    public Utilities()
    {
        //asx = new ApplicationSettings();
    }

    //public ApplicationSettings ApplicationSettings
    //{
    //    get
    //    {
    //        return asx;
    //    }
    //    set
    //    {
    //        asx = value;
    //    }
    //}

    public void PadString(string szvString,
                          char szvCharacter,
                          int nLength,
                          ref string szrPaddedString)
    {
    
                                        string szPaddedString = string.Empty;

        szPaddedString = szvString.PadLeft(nLength,
                                           szvCharacter);

        szrPaddedString = szPaddedString;
    }

    public bool ConvertLongToBoolean(long lvValue)
    {
                                        bool bValue = false;
        switch (lvValue)
        {
            case 0:
                bValue = false;
                break;

            case 1:
                bValue = true;
                break;

            default:
                bValue = false;
                break;
        }

        return bValue;
    }

    public long ConvertBooleanToLong(bool bv)
    {
                                        long lValue = 0;
        switch (bv)
        {
            case true:
                lValue = 1;
                break;

            case false:
                lValue = 0;
                break;
        }

        return lValue;
    }

    public bool ConvertStringToBoolean(string szvValue)
    {
                                        bool b = false;
        switch(szvValue)
        {
            case "True":
                b = true;
                break;

            case "False":
                b = false;
                break;

            default:
                b = false;
                break;
        }

        return b;
    }

    public string ConvertBooleanToString(bool bv)
    {
                                        string szValue = string.Empty;
        switch(bv)
        {
            case true:
                szValue = "True";
                break;

            case false:
                szValue = "False";
                break;
        }

        return szValue;
    }

    public string Replace(string szvSource, 
                          string szvFind,
                          string szvReplace)
    {
                                        string szReplaced = string.Empty;
    
        szReplaced = szvSource.Replace(szvFind, szvReplace);
        return szReplaced;
    }

    public void CopyFile(string szvSource, 
                         string szvNewFileName,
                         string szvDestination,
                         ref bool brErrorFound,
                         ref string szrErrorMessage)
    {
                                        bool bErrorFound = false;
                                        string szErrorMessage = string.Empty;
                                        string szDestination = string.Empty;


        try
        {
            szDestination = szvDestination
                          + "\\"
                          + szvNewFileName;

            File.Copy(szvSource, 
                      szDestination, 
                      true);
        }
        catch(Exception ex)
        {
            bErrorFound = true;
            szErrorMessage = ex.Message;
        }

        brErrorFound = bErrorFound;
        szrErrorMessage = szErrorMessage;
    }

    public string Mid(string szvString, 
                      int nvStart,
                      int nvlength) 
    {
                                        string szMidString = string.Empty;
                                        bool bLastIndexOutOfScope = false;
                                        bool bStringIsEmpty = false;

        while (true) {

            bStringIsEmpty = szvString == string.Empty;

            if (bStringIsEmpty) 
            {
                szMidString = string.Empty;
                break;
            }

            bLastIndexOutOfScope = (nvStart + nvlength) > szvString.Length;

            if (bLastIndexOutOfScope) {
                szMidString = szvString.Substring(nvStart - 1, 
                                                  szvString.Length - nvStart + 1);
                break;
            }

            szMidString = szvString.Substring(nvStart - 1,
                                              nvlength);

            break;
            
        }
        return szMidString;
    }

    public string Mid(string szvString, 
                      int nvStart) 
    {

                                                string szMidString = string.Empty;

        szMidString = szvString.Substring(nvStart-1); 

        return szMidString;
    }

    public string Left(string szvString,
                       int nvLength) {
    
                                        string szReturn = "";

        if (nvLength > szvString.Length) {
            return szvString;
        }
        else {
            szReturn = szvString.Substring(0,nvLength);
            return szReturn;
        }
    }

    public void GetRightPartOfStringOverIndex(string szvSource,
                                             int nvCharacterIndex,
                                             ref string szrRight)
    {
                                        string szRight = string.Empty;

 
        szRight = szvSource.Substring(nvCharacterIndex, szvSource.Length - nvCharacterIndex);
        szrRight = szRight;
    
    }

    public void SplitStringOnDelimiter(string szvSource,
                                       string szvDelimiter,
                                       ref string szrLeft,
                                       ref string szrRight,
                                       bool bvLeftWithDelimiter = false,
                                       bool bvRightWithDelimiter = false)
    { 
                                        string szLeft = string.Empty;
                                        string szRight = string.Empty;
                                        int nDelimiterPosition = 0;

        nDelimiterPosition = szvSource.LastIndexOf(szvDelimiter);

        while (true)
        {
            if (nDelimiterPosition < 0)
            {
                break;
            }

            if (bvLeftWithDelimiter)
            {
                szLeft = szvSource.Substring(0, nDelimiterPosition + 1);
            }
            else
            {
                szLeft = szvSource.Substring(0, nDelimiterPosition);
            }

            if (bvRightWithDelimiter)
            {
                szRight = szvSource.Substring(nDelimiterPosition);
            }
            else
            {
                szRight = szvSource.Substring(nDelimiterPosition + 1);
            }
            break;
        }

        szrLeft = szLeft;
        szrRight = szRight;
    
    }

    public void SplitStringOnDelimiterOnFirstOccurrence(string szvSource,
                                                        string szvDelimiter,
                                                        ref string szrLeft,
                                                        ref string szrRight,
                                                        bool bvLeftWithDelimiter = false,
                                                        bool bvRightWithDelimiter = false)
    { 
                                        string szLeft = string.Empty;
                                        string szRight = string.Empty;
                                        int nDelimiterPosition = 0;

        nDelimiterPosition = szvSource.IndexOf(szvDelimiter);

        while (true)
        {
            if (nDelimiterPosition < 0)
            {
                break;
            }

            if (bvLeftWithDelimiter)
            {
                szLeft = szvSource.Substring(0, nDelimiterPosition + 1);
            }
            else
            {
                szLeft = szvSource.Substring(0, nDelimiterPosition);
            }

            if (bvRightWithDelimiter)
            {
                szRight = szvSource.Substring(nDelimiterPosition);
            }
            else
            {
                szRight = szvSource.Substring(nDelimiterPosition + 1);
            }
            break;
        }

        szrLeft = szLeft;
        szrRight = szRight;
    
    }

    public string Right(string szvString,
                        int nvLength) {

                                        string szReturn = "";

        if (nvLength > szvString.Length) {
            return szvString;
        }
        else {
            szReturn = szvString.Substring(szvString.Length - nvLength);
            return szReturn;
        }
    }

    public void ShowMessage(string szvMessage,
                            string szvTitle,
                            EnumsCollection.EnumMessageType emtv)
    {
        XX_ShowMessage(szvMessage,
                        szvTitle,
                        emtv);
    }

    public void ShowMessage(string szvMessage,
                            EnumsCollection.EnumMessageType emtv)
    {
        XX_ShowMessage(szvMessage,
                        string.Empty,
                        emtv);
        
    }

    private void XX_ShowMessage(string szvMessage,
                                string szvTitle,
                                EnumsCollection.EnumMessageType emtv) 
    {
                                        string szTitle = string.Empty;
                                        MessageBoxIcon mb_i = new MessageBoxIcon();
                                        MessageBoxButtons mb_b = new MessageBoxButtons();

        switch (emtv) 
        {
            case EnumsCollection.EnumMessageType.emtError:
                szTitle = "Error";
                mb_i = MessageBoxIcon.Error;
                mb_b = MessageBoxButtons.OK;
                break;

            case EnumsCollection.EnumMessageType.emtInformation:
                szTitle = "Information";
                mb_i = MessageBoxIcon.Information;
                mb_b = MessageBoxButtons.OK;
                break;

            case EnumsCollection.EnumMessageType.emtSuccess:
                szTitle = "Success";
                mb_i = MessageBoxIcon.Asterisk;
                mb_b = MessageBoxButtons.OK;
                break;
            
        }

        if (szvTitle != string.Empty)
        {
            szTitle = szvTitle;
        }

        MessageBox.Show(szvMessage,
                        szTitle,
                        mb_b,
                        mb_i);

        if (DisplayMessageInStatusBar != null)
        {
            DisplayMessageInStatusBar(szvMessage,
                                      emtv);
        }
    }

    public bool StringValueIsNumeric(string szValue)
    {

                                        bool bIsNumeric = false;
                                        double dResult = 0;

        bIsNumeric = Double.TryParse(szValue,
                                     out dResult);
        return bIsNumeric;
    }

    public void Encrypt(string szvString,
                        ref string szrEncryptedString) 
    {
                                        SymmetricAlgorithm algorithm = DES.Create();
                                        ICryptoTransform transform = algorithm.CreateEncryptor(bytKey, bytValue);
                                        byte[] bytInputBuffer = Encoding.Unicode.GetBytes(szvString);
                                        byte[] bytOutputBuffer = transform.TransformFinalBlock(bytInputBuffer, 0, bytInputBuffer.Length);

        szrEncryptedString = Convert.ToBase64String(bytOutputBuffer);
    }

    public void Decrypt(string szvEncryptedString,
                        ref string szrString)
    {
                                        SymmetricAlgorithm algorithm = DES.Create();
                                        ICryptoTransform transform = algorithm.CreateDecryptor(bytKey, bytValue);
                                        byte[] bytInputBuffer = Convert.FromBase64String(szvEncryptedString);
                                        byte[] bytOutputBuffer = transform.TransformFinalBlock(bytInputBuffer, 0, bytInputBuffer.Length);

        szrString = Encoding.Unicode.GetString(bytOutputBuffer);
    }

    public void GetDateValueOverStringDate(string szvDate,
                                           ref DateTime dtrDate,
                                           ref bool brErrorFound,
                                           ref string szrErrorMessage)
    { 
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        DateTime dtDate = new DateTime();
                                        string szDay = string.Empty;
                                        string szMonth = string.Empty;
                                        string szYear = string.Empty;
                                        int nDay = 0;
                                        int nMonth = 0;
                                        int nYear = 0;

        while(true)
        {            
            szDay = szvDate.Substring(0,
                                      2);
            nDay = Convert.ToInt16(szDay);

            szMonth = szvDate.Substring(3,
                                        2);
            nMonth = Convert.ToInt16(szMonth);

            szYear = szvDate.Substring(6,
                                       4);
            nYear = Convert.ToInt16(szYear);

            dtDate = new DateTime(nYear,
                                  nMonth,
                                  nDay);
            break;
        }

        brErrorFound = bErrorFound;
        szrErrorMessage = szErrorMessage;
        dtrDate = dtDate;
    }

    private void XX_CheckIfStringDateIsValid(string szvStringDate,
                                             ref bool brValid)
    { 
                                        bool bValid = false;
    
        while(true)
        {
            if (szvStringDate == string.Empty)
            {
                bValid = false;
                break;
            }

            if (szvStringDate.Length != 10)
            {
                bValid = false;
                break;
            }

            if (szvStringDate.IndexOf(".") < 0)
            {
                bValid = false;
                break;
            }
            
            break;
        }

        brValid = bValid;
    }

    public void GetDateStringValueOverDate(DateTime dtDate,
                                           bool bvUseApplicationDefaultInitialDate,
                                           ref string szrDateString,
                                           ref string szrTime)
    {
        XX_GetDateStringValueOverDate(dtDate,
                                      bvUseApplicationDefaultInitialDate,
                                      ref szrDateString,
                                      ref szrTime);
    }

    public void GetDateStringValueOverDate(DateTime dtDate,
                                           ref string szrDateString,
                                           ref string szrTime)
    {
        XX_GetDateStringValueOverDate(dtDate,
                                      false,
                                      ref szrDateString,
                                      ref szrTime);    
    }

    private void XX_GetDateStringValueOverDate(DateTime dtDate,
                                               bool bvUseApplicationDefaultInitialDate,
                                               ref string szrDateString,
                                               ref string szrTime) 
    {
                                        string szYear = string.Empty;
                                        string szMonth = string.Empty;
                                        string szDay = string.Empty;
                                        string szDate = string.Empty;
                                        string szHour = string.Empty;
                                        string szMinute = string.Empty;
                                        string szSecond = string.Empty;
                                        string szTime = string.Empty;

        if(bvUseApplicationDefaultInitialDate)
        {
            dtDate = new DateTime(2000,
                                  dtDate.Month,
                                  dtDate.Day);
        }

        szYear = Convert.ToString(dtDate.Year);
        szMonth = Convert.ToString(dtDate.Month);
        if (szMonth.Length == 1) {
            szMonth = "0" + szMonth;
        }

        szDay = Convert.ToString(dtDate.Day);
        if (szDay.Length == 1) {
            szDay = "0" + szDay;
        }

        szDate = szDay
                + "."
                + szMonth
                + "."
                + szYear;


        szHour = Convert.ToString(dtDate.Hour);
        if (szHour.Length == 1) 
        {
            szHour = "0" + szHour;
        }
        szMinute = Convert.ToString(dtDate.Minute);
        if (szMinute.Length == 1)
        {
            szMinute = "0" + szMinute;
        }
        szSecond = Convert.ToString(dtDate.Second);
        if (szSecond.Length == 1)
        {
            szSecond = "0" + szSecond;
        }

        szTime = szHour
               + ":"
               + szMinute
               + ":"
               + szSecond;

        szrDateString = szDate;
        szrTime = szTime;
    }

    public void GetDayStringValueOverDayEnum(DayOfWeek edowv,
                                             ref string szrDayOfWeek) 
    {
                                        string szDayOfWeek = string.Empty;

        switch (edowv) 
        {
            case DayOfWeek.Monday:
                szDayOfWeek = "Monday";
                break;
            case DayOfWeek.Tuesday:
                szDayOfWeek = "Tuesday";
                break;
            case DayOfWeek.Wednesday:
                szDayOfWeek = "Wednesday";
                break;
            case DayOfWeek.Thursday:
                szDayOfWeek = "Thursday";
                break;
            case DayOfWeek.Friday:
                szDayOfWeek = "Friday";
                break;
            case DayOfWeek.Saturday:
                szDayOfWeek = "Saturday";
                break;
            case DayOfWeek.Sunday:
                szDayOfWeek = "Sunday";
                break;
        }

        szrDayOfWeek = szDayOfWeek;
    
    }
}
}
