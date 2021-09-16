using Utilities;
using MySql.Data.MySqlClient;

namespace DataBaseManagement
{
public class DatabaseUtilities
{
    private DatabaseConnection dbcx = null;
    private FileAccessor fax = null;
    public DatabaseUtilities(DatabaseConnection dbcv)
    {
        dbcx = dbcv;
        fax = new FileAccessor();
    }

    public void ReadDataBaseTaskFromDefinitionFile(string szvFilePath)
    {
                                        string szSection = string.Empty;
                                        string szKey = string.Empty;
                                        string szValue = string.Empty;
                                        string szTask = string.Empty;
                                        string szTableName = string.Empty;
                                        Fields fds = null;
                                        bool bValueNotFound = false;
                                        EnumsCollection.EnumDataBaseTasks edbt = new EnumsCollection.EnumDataBaseTasks();

        fax.ConnectToFile(szvFilePath, 
                          EnumsCollection.EnumFileAccessType.efatRead);
        fax.GetValue(szSection,
                     szKey,
                     ref szValue,
                     ref bValueNotFound);

        switch (szTask)
        { 
            case "CREATE":
                edbt = EnumsCollection.EnumDataBaseTasks.edbtCreate;
                break;

            case "UPDATE":
                edbt = EnumsCollection.EnumDataBaseTasks.edbtUpdate;
                break;

            case "DELETE":
                edbt = EnumsCollection.EnumDataBaseTasks.edbtDelete;
                break;
        }

        XX_CreateSQLStatementOverDataBaseTaskEnum(edbt,
                                                    szTableName,
                                                    fds);

    }

    private void XX_CreateSQLStatementOverDataBaseTaskEnum(EnumsCollection.EnumDataBaseTasks edbtv,
                                                           string szvTableName,
                                                           Fields fdsv)
    {
                                        string szSQL = string.Empty;
                                        string szDataType = string.Empty;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;

        switch (edbtv)
        { 
            case EnumsCollection.EnumDataBaseTasks.edbtCreate:

                break;

            case EnumsCollection.EnumDataBaseTasks.edbtUpdate:
                //szSQL = "ALTER TABLE " + szvTableName + " ADD column_name datatype";
                foreach (Field fd in fdsv)
                {
                    switch (fd.EnumFieldType)
                    { 
                        case EnumsCollection.EnumFieldType.eftString:
                            szDataType = "VARCHAR(" + fd.Length.ToString() + ")";
                            break;

                        case EnumsCollection.EnumFieldType.eftDouble:
                            szDataType = "FLOAT";
                            break;

                        case EnumsCollection.EnumFieldType.eftLong:
                            szDataType = "BIGINT(20)";
                            break;

                        case EnumsCollection.EnumFieldType.eftInteger:
                            szDataType = "INT(11)";
                            break;

                    }

                    szSQL = "ALTER TABLE " + szvTableName + " ADD " + fd.Key + " " + szDataType;
                    dbcx.ExecuteSQL(szSQL,
                                    ref bErrorFound,
                                    ref szErrorMessage);
                }

                break;

            case EnumsCollection.EnumDataBaseTasks.edbtDelete:

                break;
        }
    }

    private void XX_GetCollectionOfNewFieldsFromTableDefinition(string szvTableName,
                                                                ref Fields fdsrNew)
    { 
                                        string szSQL = string.Empty;
                                        MySqlDataReader mysql_dr = null;
                                        string szErrorMessage = string.Empty;
                                        bool bErrorFound = false;
                                        Fields fdsDatabase = new Fields();
                                        Fields fdsTableDefinition = new Fields();
                                        Fields fdsNew = new Fields();
                                        Field fd = null;
                                        string szFieldKey = string.Empty;
                                        DBTable dbt = null;

        szSQL = "SHOW COLUMNS FROM " + szvTableName;

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

            if (!mysql_dr.Read())
            {
                break;
            }

            szFieldKey = mysql_dr[0].ToString();
            fdsDatabase.AddField(szFieldKey,
                                 ref fd);

        }

        dbt = dbcx.DBTables.ItemIsDBTable(szvTableName);

        foreach (Field f in dbt.Fields)
        {
            fdsTableDefinition.AddField(f.Key,
                                        ref fd);
        }

        bool bNewField = false;
        foreach (Field fdTable in fdsTableDefinition)
        {
            bNewField = true;
            foreach (Field fdDataBase in fdsDatabase)
            {
                if (fdDataBase.Key == fdTable.Key)
                {
                    bNewField = false;
                    break;
                }
            }

            if (bNewField)
            {
                fdsNew.AddField(fdTable.Key,
                                ref fd);
            }
        }

        if (!mysql_dr.IsClosed)
        {
            mysql_dr.Close();
            mysql_dr.Dispose();
        }

        fdsrNew = fdsNew;
    }
                                                   
}
}
