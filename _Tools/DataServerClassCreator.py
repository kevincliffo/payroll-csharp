import os
szTAB = '    '
szSPACE = ' '
class DataServerClassCreator:
    def __init__(self, szClassName):
        self.CreateImportsSection()
        self.CreateHeader(szClassName)
        self.CreateConstructor(szClassName)
        self.CreateGetObjectOverId(szClassName)
        self.CreateGetFirstRecordFromDBSection(szClassName)
        self.CreateGetNextRecordFromDBSection(szClassName)
        self.CreateGetPreviousRecordFromDBSection(szClassName)
        self.CreateGetLastRecordFromDBSection(szClassName)
        self.CreateMoveDataReaderValuesToFieldsSection(szClassName)
        self.CreateAddToDataBaseSection(szClassName)
        self.CreateRemoveFromDBSection(szClassName)
        self.CreateGetFieldsSection(szClassName)
        self.CreateGetNextObjectIdPublic(szClassName)
        self.CreateGetNextObjectIdPrivate(szClassName)
        self.CreateUpdateToDBSection(szClassName)
        self.CreateGetFieldsCollection(szClassName)
        self.CreateFindRecordOverFieldValuesSection(szClassName)
        self.AddFooterBraces()

    def AddFooterBraces(self):
        sz = szTAB + '}\n' \
           + '}\n'

        print sz
    def CreateImportsSection(self):
        sz = 'using System;\n' \
           + 'using System.Data;\n' \
           + 'using System.Linq;\n' \
           + 'using System.Text;\n' \
           + 'using System.Windows.Forms;\n' \
           + 'using DataBaseManagement;\n' \
           + 'using MySql.Data;\n' \
           + 'using MySql.Data.MySqlClient;\n' \
           + 'using Utilities;\n'

        print sz

    def GetTableKeyOverClassName(self, szClassName):
        szPart = ''
        collParts = []
        bUpperFound = False
        
        for szChar in szClassName:
            while True:
                if szChar == szClassName[0]:
                    szPart = szPart + szChar
                    bUpperFound = True
                    break
                if szChar.isupper():
                    collParts.append(szPart)
                    szPart = ''
                    szPart = szPart + szChar
                    break

                szPart = szPart + szChar

                break
            
        nLastCharPos = len(szClassName)-1
        if (szClassName[nLastCharPos]).islower():
            collParts.append(szPart + 'S')

        szTableName = ''
        for szPart in collParts:
            szTableName = szTableName + szPart.upper() + '_'

        szTableName = 'szx' + szTableName + 'TableKey'
        return szTableName
        
    def CreateHeader(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        szTableKey = self.GetTableKeyOverClassName(szClassName)
        sz = 'namespace Models\n' \
           + '{\n' \
           + szTAB + 'public class ' + szClassName + 's_DS : I_DataServer\n' \
           + szTAB + '{\n' \
           + (szTAB * 2) + 'private DatabaseConnection dbcx = null;\n' \
           + (szTAB * 2) + 'private Fields fdsx = null;\n' \
           + (szTAB * 2) + 'private DBTable dbtx = null;\n' \
           + (szTAB * 2) + 'private SQLGenerator sqlgx = null;\n' \
           + (szTAB * 2) + 'private Utilities.Utilities utsx = null;\n' \
           + (szTAB * 2) + 'private string szxCurrent' + szClassName + 'Id = "";\n' \
           + (szTAB * 2) + 'private const string ' + szTableKey + ' = "' + szClassName + 's";\n' \

        print sz

    def CreateConstructor(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        szTableKey = self.GetTableKeyOverClassName(szClassName)
        sz = (szTAB * 2) +'public ' + szClassName + 's_DS(DatabaseConnection dbcv) \n' \
           + (szTAB *2) + '{\n' \
           + (szTAB * 3) + 'dbcx = dbcv;\n' \
           + (szTAB * 3) + 'fdsx = new Fields();\n' \
           + (szTAB * 3) + 'utsx = new Utilities.Utilities();\n' \
           + (szTAB * 3) + 'szxCurrent' + szClassName + 'Id = "0";\n' \
           + (szTAB * 3) + 'sqlgx = new SQLGenerator();\n\n'\
           + (szTAB * 3) + 'dbcx.DBTables.AddDBTable(' + szTableKey + ', \n'\
           + szSPACE * len((szTAB * 3) + 'dbcx.DBTables.AddDBTable(') + 'ref dbtx);\n\n' \
           + (szTAB * 3) + 'XX_GetFieldsCollectionOverTableName(ref fdsx);\n\n' \
           + (szTAB * 3) + 'dbcx.CreateTableForFirstTimeUseIf(' + szTableKey + ', \n'\
           + szSPACE * len((szTAB * 3) + 'dbcx.CreateTableForFirstTimeUseIf(') + 'fdsx);\n\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateGetObjectOverId(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)        
        sz = (szTAB * 2) +'public void Get' + szClassName + 'Over' + szClassName + 'Id(long lv' + szClassName + 'Id,\n' \
           + szSPACE * len((szTAB * 2) + 'public void Get' + szClassName + 'Over' + szClassName + 'Id(') + 'ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void Get' + szClassName + 'Over' + szClassName + 'Id(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void Get' + szClassName + 'Over' + szClassName + 'Id(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void Get' + szClassName + 'Over' + szClassName + 'Id(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'Fields fds = new Fields();\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT * FROM ' + szClassName + 's WHERE ' + szClassName + 'Id =" + Convert.ToString(lv' + szClassName + 'Id);\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fds);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'fdsr = fds;\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateGetFirstRecordFromDBSection(self, szClassName):
        sz = (szTAB * 2) +'public void GetFirstRecordFromDataBase(ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetFirstRecordFromDataBase(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetFirstRecordFromDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetFirstRecordFromDataBase(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'Fields fds = new Fields();\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT * FROM ' + szClassName + 's ORDER BY ' + szClassName + 'Id ASC LIMIT 1";\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fds);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'fdsr = fds;\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateGetNextRecordFromDBSection(self, szClassName):
        sz = (szTAB * 2) +'public void GetNextRecordFromDataBase(ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetNextRecordFromDataBase(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetNextRecordFromDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetNextRecordFromDataBase(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'Fields fds = new Fields();\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT * FROM ' + szClassName + 's WHERE ' + szClassName + 'Id > " + fdsr.ItemIsField("' + szClassName + 'Id").StringValue + ' + '" ORDER BY '+ szClassName + 'Id ASC LIMIT 1";\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fds);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'fdsr = fds;\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateGetPreviousRecordFromDBSection(self, szClassName):
        sz = (szTAB * 2) +'public void GetPreviousRecordFromDataBase(ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetPreviousRecordFromDataBase(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetPreviousRecordFromDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetPreviousRecordFromDataBase(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'Fields fds = new Fields();\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT * FROM ' + szClassName + 's WHERE ' + szClassName + 'Id < " + fdsr.ItemIsField("' + szClassName + 'Id").StringValue + ' + '" ORDER BY ' + szClassName + 'Id DESC LIMIT 1";\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fds);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'fdsr = fds;\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateGetLastRecordFromDBSection(self, szClassName):
        sz = (szTAB * 2) +'public void GetLastRecordFromDataBase(ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetLastRecordFromDataBase(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetLastRecordFromDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void GetLastRecordFromDataBase(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'Fields fds = new Fields();\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT * FROM ' + szClassName + 's ORDER BY '+ szClassName + 'Id DESC LIMIT 1";\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fds);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'fdsr = fds;\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz
        
    def CreateMoveDataReaderValuesToFieldsSection(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        sz = (szTAB * 2) +'private void XX_MoveDataReaderValuesToFields(ref MySqlDataReader mysql_drr,\n' \
           + szSPACE * len((szTAB * 2) + 'private void XX_MoveDataReaderValuesToFields(') + 'ref Fields fdsr)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'PrimaryKey pk = null;\n\n' \
           + (szTAB * 3) + 'pk = fdsx.PrimaryKeys.ItemIsPrimaryKey(0);\n' \
           + (szTAB * 3) + 'szxCurrent' + szClassName + 'Id = mysql_drr[pk.FieldName].ToString();\n\n' \
           + (szTAB * 3) + 'dbcx.MoveRecordToMemberObject(ref mysql_drr,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.MoveRecordToMemberObject(') + 'ref fdsx);\n\n' \
           + (szTAB * 3) + 'fdsr = fdsx;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz

    def CreateAddToDataBaseSection(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        sz = (szTAB * 2) +'public void AddToDataBase(Fields fdsv,\n' \
           + szSPACE * len((szTAB * 2) + 'public void AddToDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void AddToDataBase(') + 'ref string szrErrorMessage)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'long l' + szClassName + 'Id = 0;\n'\
           + (szTAB * 10) + 'string szCounter = string.Empty;\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n\n'\
           + (szTAB * 3) + 'XX_GetNext' + szClassName + 'Id(ref l' + szClassName + 'Id);\n\n' \
           + (szTAB * 3) + 'fdsv.ItemIsField("' + szClassName + 'Id").StringValue = Convert.ToString(l' + szClassName + 'Id);\n\n' \
           + (szTAB * 3) + 'sqlgx.CreateSQLQueryForInsertOverFieldsCollection(fdsv,\n' \
           + szSPACE * len((szTAB * 3) + 'sqlgx.CreateSQLQueryForInsertOverFieldsCollection(') + 'ref szSQL);\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage);\n\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB *2) + '}\n' \
           
        print sz

    def CreateRemoveFromDBSection(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        sz = (szTAB * 2) +'public void RemoveFromDataBase(Fields fdsv,\n' \
           + szSPACE * len((szTAB * 2) + 'public void RemoveFromDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void RemoveFromDataBase(') + 'ref string szrErrorMessage)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n\n'\
           + (szTAB * 3) + 'szSQL = "DELETE FROM ' + szClassName + 's WHERE ' + szClassName + 'Id = " + fdsv.ItemIsField("' + szClassName + 'Id").StringValue;\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage);\n\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB *2) + '}\n' \
           
        print sz

    def CreateGetFieldsSection(self, szClassName):
        sz = (szTAB * 2) +'public Fields Fields \n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 3) + 'get\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'return fdsx;\n' \
           + (szTAB * 3) + '}\n' \
           + (szTAB * 2) + '}\n' \

        print sz
        
    def CreateGetNextObjectIdPublic(self, szClassName):
        sz = (szTAB * 2) +'public void GetNextHighestId(ref long lrId) \n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 3) + 'XX_GetNext' + szClassName + 'Id(ref lrId);\n' \
           + (szTAB * 2) + '}\n' \

        print sz
        
    def CreateGetNextObjectIdPrivate(self, szClassName):
        sz = (szTAB * 2) +'private void XX_GetNext' + szClassName + 'Id(ref long lr' + szClassName + 'Id)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'long l' + szClassName + 'Id = 0;\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n\n'\
           + (szTAB * 3) + 'szSQL = "SELECT MAX(' + szClassName + 'Id) FROM ' + szClassName + 's";\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr == null)\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'break;\n' \
           + (szTAB * 4) + '}\n\n' \
           + (szTAB * 4) + 'l' + szClassName + 'Id = 1;\n\n' \
           + (szTAB * 4) + 'if (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'try\n' \
           + (szTAB * 5) + '{\n' \
           + (szTAB * 6) + 'l' + szClassName + 'Id = Convert.ToInt32(mysql_dr[0].ToString());\n' \
           + (szTAB * 5) + '}\n' \
           + (szTAB * 5) + 'catch\n' \
           + (szTAB * 5) + '{\n' \
           + (szTAB * 6) + 'l' + szClassName + 'Id = 0;\n' \
           + (szTAB * 5) + '}\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n' \
           + (szTAB * 3) + 'if (mysql_dr != null)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'lr' + szClassName + 'Id = l' + szClassName + 'Id + 1;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz
        
    def CreateUpdateToDBSection(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        sz = (szTAB * 2) +'public void UpdateDataInDataBase(Fields fdsv,\n' \
           + szSPACE * len((szTAB * 2) + 'public void UpdateDataInDataBase(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void UpdateDataInDataBase(') + 'ref string szrErrorMessage)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n\n'\
           + (szTAB * 3) + 'sqlgx.CreateSQLQueryForUpdateTable(fdsv,\n' \
           + szSPACE * len((szTAB * 3) + 'sqlgx.CreateSQLQueryForUpdateTable(') + 'ref szSQL);\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage);\n\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz
        
    def CreateGetFieldsCollection(self, szClassName):
        ##szInitials = self.GetClassInitials(szClassName)
        sz = (szTAB * 2) +'private void XX_GetFieldsCollectionOverTableName(ref Fields fdsr)\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szTableFilePath = string.Empty;\n'\
           + (szTAB * 10) + 'bool bFileExists = false;\n\n'\
           + (szTAB * 3) + 'szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath + @"\\"' + ' + "' + szClassName + 's.tbl";\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'bFileExists = System.IO.File.Exists(szTableFilePath);\n' \
           + (szTAB * 4) + 'if (!bFileExists)\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'MessageBox.Show("' + szClassName + 's table not found",\n' \
           + szSPACE * len((szTAB * 5) + 'MessageBox.Show(') + '"Missing Table File");\n' \
           + (szTAB * 4) + '}\n\n' \
           + (szTAB * 4) + 'dbtx.GetFieldsCollection(szTableFilePath,\n' \
           + szSPACE * len((szTAB * 4) + 'dbtx.GetFieldsCollection(') + 'ref fdsr);\n\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n' \
           + (szTAB * 2) + '}\n' \

        print sz
    def CreateFindRecordOverFieldValuesSection(self, szClassName):
        sz = (szTAB * 2) +'public void FindRecordOverFieldValues(ref Fields fdsr,\n' \
           + szSPACE * len((szTAB * 2) + 'public void FindRecordOverFieldValues(') + 'ref bool brErrorFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void FindRecordOverFieldValues(') + 'ref bool brNothingFound,\n' \
           + szSPACE * len((szTAB * 2) + 'public void FindRecordOverFieldValues(') + 'ref string szrErrorMessage)\n\n' \
           + (szTAB * 2) + '{\n' \
           + (szTAB * 10) + 'string szSQL = string.Empty;\n'\
           + (szTAB * 10) + 'MySqlDataReader mysql_dr = null;\n'\
           + (szTAB * 10) + 'string szErrorMessage = string.Empty;\n'\
           + (szTAB * 10) + 'bool bErrorFound = false;\n'\
           + (szTAB * 10) + 'bool bNothingFound = true;\n\n'\
           + (szTAB * 3) + 'sqlgx.CreateSQLQueryForFindRecord(fdsr,\n' \
           + szSPACE * len((szTAB * 3) + 'sqlgx.CreateSQLQueryForFindRecord(') + 'ref szSQL);\n\n' \
           + (szTAB * 3) + 'dbcx.ExecuteSQL(szSQL,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref bErrorFound,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref szErrorMessage,\n' \
           + szSPACE * len((szTAB * 3) + 'dbcx.ExecuteSQL(') + 'ref mysql_dr);\n\n' \
           + (szTAB * 3) + 'while (true)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'while (mysql_dr.Read())\n' \
           + (szTAB * 4) + '{\n' \
           + (szTAB * 5) + 'bNothingFound = false;\n' \
           + (szTAB * 5) + 'XX_MoveDataReaderValuesToFields(ref mysql_dr,\n' \
           + szSPACE * len((szTAB * 5) + 'XX_MoveDataReaderValuesToFields(') + 'ref fdsr);\n' \
           + (szTAB * 4) + '}\n' \
           + (szTAB * 4) + 'break;\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'if (!mysql_dr.IsClosed)\n' \
           + (szTAB * 3) + '{\n' \
           + (szTAB * 4) + 'mysql_dr.Close();\n' \
           + (szTAB * 4) + 'mysql_dr.Dispose();\n' \
           + (szTAB * 3) + '}\n\n' \
           + (szTAB * 3) + 'brNothingFound = bNothingFound;\n' \
           + (szTAB * 3) + 'brErrorFound = bErrorFound;\n' \
           + (szTAB * 3) + 'szrErrorMessage = szErrorMessage;\n' \
           + (szTAB * 2) + '}\n' \
           
        print sz
if __name__ == '__main__':
    szClassName = 'PayrollsList'
    DataServerClassCreator(szClassName)
