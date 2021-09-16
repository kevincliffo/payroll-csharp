using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Utilities;
using CollectionClasses;

namespace DataBaseManagement
{
public class DBTable
{
    private string szxrwxKey = string.Empty;
    private long lxrwxIndex = 0;
    private DBTables dbtsxParent = null;
    private Fields fdsx = null;

    public string Key
    {
        get
        {
            return szxrwxKey;
        }
        set
        {
            szxrwxKey = value;
        }
    }
    public long Index
    {
        get
        {
            return lxrwxIndex;
        }
        set
        {
            lxrwxIndex = value;
        }
    }

    public DBTables ParentIsDBTables
    {
        get
        {
            return dbtsxParent;
        }
        set
        {
            dbtsxParent = value;
        }
    }

    public Fields Fields
    {
        get
        {
            return fdsx;
        }

    }

    public void GetFieldsCollection(string szvTableFileName,
                                    ref Fields fdsr)
    {
                                        FileAccessor fa = new FileAccessor();
                                        bool bValueNotFound = false;
                                        long lCounter = 1;
                                        string szKey = string.Empty;
                                        bool bKeyExists = false;
                                        string szTableName = string.Empty;
                                        string szSection = string.Empty;
                                        string szValue = string.Empty;
                                        Field fd = null;
                                        EnumsCollection.EnumFieldType eft = new EnumsCollection.EnumFieldType();
                                        PrimaryKey pk = new PrimaryKey();

            fa.ConnectToFile(szvTableFileName,
                             EnumsCollection.EnumFileAccessType.efatRead);

            fa.GetValue("Table",
                        "Name",
                        ref szTableName,
                        ref bValueNotFound);

            fdsr.TableName = szTableName;
            while (true)
            {
                szSection = "Field_"
                          + Convert.ToString(lCounter);

                bKeyExists = fa.Sections.KeyExist(szSection);
                if (!bKeyExists)
                {
                    break;
                }

                fa.GetValue(szSection,
                            "Key",
                            ref szKey,
                            ref bValueNotFound);

                fdsr.AddField(szKey,
                              ref fd);

                fa.GetValue(szSection,
                            "Type",
                            ref szValue,
                            ref bValueNotFound);
                XX_GetFieldType(szValue,
                                ref eft);
                fd.EnumFieldType = eft;

                fa.GetValue(szSection,
                            "Length",
                            ref szValue,
                            ref bValueNotFound);
                fd.Length = Convert.ToInt16(szValue);

                fa.GetValue(szSection,
                            "InitialValue",
                            ref szValue,
                            ref bValueNotFound);
                fd.StringValue = szValue;

                fa.GetValue(szSection,
                            "LocalizedName",
                            ref szValue,
                            ref bValueNotFound);
                fd.LocalizedName = szValue;

                fa.GetValue(szSection,
                            "ValueRequired",
                            ref szValue,
                            ref bValueNotFound);

                fd.ValueRequired = szValue == "True";
                lCounter = lCounter + 1;

                switch (fd.EnumFieldType)
                {
                    case EnumsCollection.EnumFieldType.eftInteger:
                    case EnumsCollection.EnumFieldType.eftLong:
                    case EnumsCollection.EnumFieldType.eftDouble:
                        fd.StringValue = "0";
                        break;

                    case EnumsCollection.EnumFieldType.eftString:

                        fd.StringValue = "";
                        break;

                }
            }

            lCounter = 1;
            szSection = "PrimaryKeys";

            szKey = "Key_";
            while (true) 
            {
                szKey = "Key_"
                      + Convert.ToString(lCounter);

                bKeyExists = fa.KeyExists(szSection,
                                          szKey);

                if (!bKeyExists) 
                {
                    break;
                }

                fa.GetValue(szSection,
                            szKey,
                            ref szValue,
                            ref bValueNotFound);

                fdsr.PrimaryKeys.AddPrimaryKey(szKey,
                                               ref pk);
                pk.FieldName = szValue;
                lCounter = lCounter + 1;
            }

            fdsx = fdsr;
        }

        private void XX_GetFieldType(string szvType,
                                     ref EnumsCollection.EnumFieldType eftr) {

                                         EnumsCollection.EnumFieldType eft = new EnumsCollection.EnumFieldType();

            switch(szvType){
                case "String":
                    eft = EnumsCollection.EnumFieldType.eftString;
                    break;
                case "Integer":
                    eft = EnumsCollection.EnumFieldType.eftInteger;
                    break;
                case "Long":
                    eft = EnumsCollection.EnumFieldType.eftLong;
                    break;
                case "Double":
                    eft = EnumsCollection.EnumFieldType.eftDouble;
                    break;
                case "DateTime":
                    eft = EnumsCollection.EnumFieldType.eftDateTime;
                    break;
                case "Date":
                    eft = EnumsCollection.EnumFieldType.eftDate;
                    break;
                case "Time":
                    eft = EnumsCollection.EnumFieldType.eftTime;
                    break;
            }

            eftr = eft;

        }
}
}
