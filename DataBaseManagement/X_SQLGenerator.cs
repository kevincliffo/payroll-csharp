using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollectionClasses;
using Utilities;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DataBaseManagement
{
public class SQLGenerator
{
    private const string szxEMPTY = "";
    private const string szxNONE = "NONE";
    private const string szxZERO = "0";

    public SQLGenerator() 
    {

    }

    public void CreateSQLQueryForFindRecord(Fields fdsv,
                                            ref string szrSQL)
    { 
                                        string szSQL = string.Empty;
                                        string szValuesTag = string.Empty;
                                        string szSQLFieldsTag = string.Empty;
                                        string szSQLFieldTag = string.Empty;
                                        PrimaryKey pk = new PrimaryKey();
                                        PrimaryKey pkTwo = new PrimaryKey();
                                        string szSQLPrimaryKeyTwo = string.Empty;
                                        string szPrimaryKeyOneValue = string.Empty;

        pk = fdsv.PrimaryKeys.ItemIsPrimaryKey(0);

        szPrimaryKeyOneValue = fdsv.ItemIsField(pk.FieldName).StringValue;

        if (szPrimaryKeyOneValue.Trim() == szxEMPTY)
        {
            szPrimaryKeyOneValue = "0";
        }
        szSQL = "SELECT * FROM " 
              + fdsv.TableName 
              + " WHERE " 
              + pk.FieldName 
              + " = "
              + szPrimaryKeyOneValue;

        if (fdsv.PrimaryKeys.PrimaryKeyCount == 2)
        {
            pkTwo = fdsv.PrimaryKeys.ItemIsPrimaryKey(1);
            szSQLPrimaryKeyTwo = " OR " + pkTwo.FieldName + " = '" + fdsv.ItemIsField(pkTwo.FieldName).StringValue + "'";
        }

        szSQL = szSQL + szSQLPrimaryKeyTwo;
        szrSQL = szSQL;
    }

    public void CreateSQLQueryForUpdateTable(Fields fdsv,
                                             ref string szrSQL)
    { 
                                        string szSQL = string.Empty;
                                        string szValuesTag = string.Empty;
                                        string szFieldsTag = string.Empty;
                                        string szStream = string.Empty;
                                        string szValue = string.Empty;
                                        string szFormat = string.Empty;

        foreach(Field fd in fdsv)
        {
            switch (fd.EnumFieldType)
            {
                case EnumsCollection.EnumFieldType.eftDouble:
                    szValue = (Convert.ToDouble(fd.StringValue).ToString("0.00"));
                    szFormat = "{0} = {1}, ";
                    break;
                case EnumsCollection.EnumFieldType.eftInteger:
                case EnumsCollection.EnumFieldType.eftLong:
                    szValue = fd.StringValue;
                    szFormat = "{0} = {1}, ";
                    break;
                default:
                    szValue = fd.StringValue;
                    szFormat = "{0} = '{1}', ";
                    break;
            }

            szStream = szStream + String.Format(szFormat, fd.Key, szValue);
        }

        szStream = szStream.Remove(szStream.Length - 2, 1);
        szSQL = String.Format("UPDATE {0}  SET {1} WHERE {2} = {3}", fdsv.TableName, szStream, fdsv.ItemIsField(0).Key, fdsv.ItemIsField(0).StringValue);

        szrSQL = szSQL;
    }

    private void XX_GetFieldTagForCreateTableQuery(Field fdv,
                                                   ref string szrFieldTag) 
    {
                                        string szFieldTag = string.Empty;
                                        string szValueRequired = string.Empty;

        if(fdv.ValueRequired){
            szValueRequired = "NOT NULL";
        }

        switch(fdv.EnumFieldType)
        {
            case EnumsCollection.EnumFieldType.eftString:
                szFieldTag = String.Format(" {0} VARCHAR({1}) {2},", fdv.Key, Convert.ToString(fdv.Length), szValueRequired);
                break;
        
            case EnumsCollection.EnumFieldType.eftLong:
            case EnumsCollection.EnumFieldType.eftInteger:
                szFieldTag = String.Format(" {0} INT {1},", fdv.Key, szValueRequired);
                if (szFieldTag == szxEMPTY) {
                    szFieldTag = szxZERO;
                }
                break;
            case EnumsCollection.EnumFieldType.eftDouble:
                szFieldTag = String.Format(" {0} DOUBLE(10,2) {1},", fdv.Key, szValueRequired);
                break;
            case EnumsCollection.EnumFieldType.eftDate:
                szFieldTag = String.Format(" {0} DATE {1},", fdv.Key, szValueRequired);
                break;
            case EnumsCollection.EnumFieldType.eftDateTime:
                szFieldTag = String.Format(" {0} DATETIME {1},", fdv.Key, szValueRequired);
                break;
            case EnumsCollection.EnumFieldType.eftTime:
                szFieldTag = String.Format(" {0} TIME {1},", fdv.Key, szValueRequired);
                break;
            default:
                szFieldTag = szxEMPTY;
                break;
        }

        szrFieldTag = szFieldTag;
    }

    public void CreateSQLQueryForCreateTable(Fields fdsv,
                                             ref string szrSQL)
    { 
                                        string szSQL = string.Empty;
                                        string szSQLFieldTag = string.Empty;
                                        string szSQLFieldsTag = string.Empty;
                                        string szPrimaryKeyTag = string.Empty;
                                        string szFieldsTagWithPrimaryKeyTag = string.Empty;

        foreach(Field fd in fdsv)
        {
            XX_GetFieldTagForCreateTableQuery(fd,
                                              ref szSQLFieldTag);

            szSQLFieldsTag = szSQLFieldsTag + szSQLFieldTag;
        }

        szSQLFieldsTag = szSQLFieldsTag.Remove(szSQLFieldsTag.Length - 1, 1);
        XX_GetPrimaryKeyTagForTableCreation(fdsv,
                                            ref szPrimaryKeyTag);

        szFieldsTagWithPrimaryKeyTag = szSQLFieldsTag
                                     + ", PRIMARY KEY ("
                                     + szPrimaryKeyTag
                                     + ")";

        szSQL = String.Format("CREATE TABLE {0} ({1})", fdsv.TableName, szFieldsTagWithPrimaryKeyTag);

        szrSQL = szSQL;
    }

    public void CreateSQLQueryForInsertOverFieldsCollection(Fields fdsv,
                                                            ref string szrSQL) 
    {
                                        string szSQL = string.Empty;
                                        string szValuesTag = string.Empty;
                                        string szFieldsTag = string.Empty;
                                        string szValue = string.Empty;
                                        string szCounter = string.Empty;
                                        string szValueFormat = string.Empty;

        foreach(Field fd in fdsv)
        {
            XX_GetFieldTagForInsert(fd,
                                    ref szValue);

            switch (fd.EnumFieldType)
            {
                case EnumsCollection.EnumFieldType.eftDouble:
                case EnumsCollection.EnumFieldType.eftInteger:
                case EnumsCollection.EnumFieldType.eftLong:
                    szValueFormat = "{0},";
                    break;
                default:
                    szValueFormat = "'{0}',";
                    break;
            }

            szValuesTag = szValuesTag + String.Format(szValueFormat, szValue);
            szFieldsTag = szFieldsTag + String.Format(" {0},", fd.Key);
        
        }
    
        szValuesTag = szValuesTag.Remove(szValuesTag.Length -1, 1);
        szFieldsTag = szFieldsTag.Remove(szFieldsTag.Length - 1, 1);
        szSQL =  String.Format("INSERT INTO {0}({1}) VALUES({2})", fdsv.TableName, szFieldsTag, szValuesTag);

        szrSQL = szSQL;
    }

    private void XX_GetFieldTagForInsert(Field fdv,
                                         ref string szrValue) 
    {
                                        string szValue = string.Empty;
                                        DateTime dtDateTime = new DateTime();
                                        string szDay = string.Empty;
                                        string szMonth = string.Empty;
                                        string szYear = string.Empty;

        switch(fdv.EnumFieldType)
        {
            case EnumsCollection.EnumFieldType.eftString:
                szValue = fdv.StringValue;
                if (szValue == szxEMPTY) {
                    szValue = szxNONE;
                }
                break;
        
            case EnumsCollection.EnumFieldType.eftLong:
            case EnumsCollection.EnumFieldType.eftInteger:
                szValue = fdv.StringValue;
                if (szValue == szxEMPTY) {
                    szValue = szxZERO;
                }
                break;
            case EnumsCollection.EnumFieldType.eftDouble:                
                szValue = fdv.StringValue;
                if (szValue == szxEMPTY) {
                    fdv.StringValue = szxZERO;
                }
                szValue = (Convert.ToDouble(fdv.StringValue).ToString("0.00"));
                break;

            case EnumsCollection.EnumFieldType.eftDateTime:
            case EnumsCollection.EnumFieldType.eftDate:
                szValue = fdv.StringValue;
                szDay = szValue.Substring(0,
                                          2);

                szMonth = szValue.Substring(3,
                                            2);

                szYear = szValue.Substring(6,
                                           4);
                if (szDay.Length == 1) {
                    szDay = "0" + szDay;
                }

                if (szMonth.Length == 1) {
                    szMonth = "0" + szMonth;
                }

                szValue = szYear
                        + "-"
                        + szMonth
                        + "-"
                        + szDay;

                if (szValue == szxEMPTY) {
                    szValue = dtDateTime.ToString("yyyy-MM-dd");
                }
                break;
            case EnumsCollection.EnumFieldType.eftTime:
                szValue = fdv.StringValue;
                if (szValue == szxEMPTY) {
                    szValue = dtDateTime.ToString("HH:mm");
                }
                break;
            default:
                szValue = szxEMPTY;
                break;
        }

        szrValue = szValue;
    
    }

    private void XX_GetPrimaryKeyTagForTableCreation(Fields fdsv,
                                                     ref string szrPrimaryKeyTag) 
    {
                                        string szPrimaryKeyTag = string.Empty;

        foreach(PrimaryKey pk in fdsv.PrimaryKeys)
        {
            szPrimaryKeyTag = szPrimaryKeyTag + pk.FieldName + ", ";
        }

        szPrimaryKeyTag = szPrimaryKeyTag.Remove(szPrimaryKeyTag.Length - 2, 1);
        szrPrimaryKeyTag = szPrimaryKeyTag;
    }

}
}
