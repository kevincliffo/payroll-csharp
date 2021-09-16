using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBaseManagement;
using CollectionClasses;
using Utilities;
using System.IO;

namespace BuildingUtilities
{
public partial class Form1 : Form
{
    private DBTable dbtx = new DBTable();
    private Fields fdsx = null;
    private const string szxEMPTY = "";
    private const string szxZERO = "0";
    private const string szxNONE = "NONE";

    public Form1()
    {

        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
                                    OpenFileDialog ofd = new OpenFileDialog();
                                    Fields fds = new Fields();

        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        if (ofd.ShowDialog(this) == DialogResult.OK)
        {
            txtTableFilePath.Text = ofd.FileName;
        }

        if (txtTableFilePath.Text.Trim() != szxEMPTY)
        {
            XX_GetFieldsCollectionOverTableName(ref fds);
        }
    }

    private void XX_GetFieldsCollectionOverTableName(ref Fields fdsr)
    {
                                    string szTableFilePath = string.Empty;
                                    bool bFileExists = false;
                                    ArrayList alFieldNames = new ArrayList();
                                    Field fd = new Field();

        szTableFilePath = txtTableFilePath.Text;

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

            fdsx = fdsr;
            break;
        }

        if (fdsx.FieldCount > 0)
        {
            XX_EnableButtons(true);
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        string sz = @"""";
        string z1 = "kevin";

        z1 = sz + z1 + sz;
        txtTableFilePath.Text = @"C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayRollSystem\Step_08\PayRollSystem\bin\Debug\Tables\Teachers.tbl";
    }

    private void XX_EnableButtons(bool bvEnable)
    {
        btnCreate.Enabled = bvEnable;
        btnInsert.Enabled = bvEnable;
        btnUpdate.Enabled = bvEnable;
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
            szFieldTag = String.Format(" {0} DECIMAL {1},", fdv.Key, szValueRequired);
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

    private void XX_CreateSQLQueryForCreateTable(Fields fdsv,
                                                    ref string szrSQL)
    {
                                    string szSQL = string.Empty;
                                    string szSQLFieldTag = string.Empty;
                                    string szSQLFieldsTag = string.Empty;
                                    string szPrimaryKeyTag = string.Empty;
                                    string szFieldsTagWithPrimaryKeyTag = string.Empty;
                                    bool bFirstTime = true;

        foreach (Field fd in fdsv)
        {
            XX_GetFieldTagForCreateTableQuery(fd,
                                              ref szSQLFieldTag);

            if (bFirstTime)
            {
                szSQLFieldTag = "Counter int NOT NULL, " + szSQLFieldTag;
                bFirstTime = false;
            }

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

    private void btnCreate_Click(object sender, EventArgs e)
    {
                                    string szSQL = "";

        if(fdsx == null)
        {
            fdsx = new Fields();
            XX_GetFieldsCollectionOverTableName(ref fdsx);
        }

        XX_CreateSQLQueryForCreateTable(fdsx,
                                        ref szSQL);

        txtQuery.Text = "";
        txtQuery.Text = szSQL;
    }

    private void XX_CreateSQLQueryForInsertOverFieldsCollection(Fields fdsv,
                                                                ref string szrSQL) 
    {
                                        string szSQL = string.Empty;
                                        string szValuesTag = string.Empty;
                                        string szFieldsTag = string.Empty;
                                        string szValue = string.Empty;
                                        string szCounter = string.Empty;

        foreach(Field fd in fdsv)
        {
            XX_GetFieldTagForInsert(fd,
                                    ref szValue);

            szValuesTag = szValuesTag + String.Format("'{0}',", szValue);
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
                    szValue = szxZERO;
                }
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

    private void btnInsert_Click(object sender, EventArgs e)
    {
        string szSQL = "";

        XX_CreateSQLQueryForInsertOverFieldsCollection(fdsx,
                                                        ref szSQL);

        txtQuery.Text = "";
        txtQuery.Text = szSQL;

    }

    private void XX_CreateSQLQueryForUpdateTable(Fields fdsv,
                                                    ref string szrSQL)
    {
                                        string szSQL = string.Empty;
                                        string szValuesTag = string.Empty;
                                        string szFieldsTag = string.Empty;
                                        string szStream = string.Empty;

        foreach (Field fd in fdsv)
        {
            szStream = szStream + String.Format("{0} = '{1}', ", fd.Key, fd.StringValue);
        }

        szStream = szStream.Remove(szStream.Length - 2, 1);
        szSQL = String.Format("UPDATE {0}  SET {1} WHERE {2} = '{3}'", fdsv.TableName, szStream, fdsv.ItemIsField(0).Key, fdsv.ItemIsField(0).StringValue);

        szrSQL = szSQL;
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        string szSQL = "";

        XX_CreateSQLQueryForUpdateTable(fdsx,
                                        ref szSQL);

        txtQuery.Text = "";
        txtQuery.Text = szSQL;
    }

    private void tabPage1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnCreateDS_Click(object sender, EventArgs e)
    {
                                        string szLines = string.Empty;
                                        Fields fds = new Fields();

        txtDSClass.Clear();
        XX_GetFieldsCollectionOverTableName(ref fds);
        XX_CreateDSReferenceSection(ref szLines);
        XX_CreateDSHeaderSection(ref szLines);
        XX_CreateDSInitializeFunction(ref szLines);
        XX_GetFromDBSection(fds, ref szLines);
        XX_GetFirstRecordFromDBFunction(ref szLines);
        XX_GetNextRecordFromDBFunction(ref szLines);
        XX_GetPreviousRecordFromDBFunction(ref szLines);
        XX_GetLastRecordFromDBFunction(ref szLines);
        XX_MoveRecordToFieldsFunction(fds,
                                      ref szLines);
        XX_AddToDBFunction(ref szLines);
        XX_GetNextIdFunction(ref szLines);
        XX_GetFieldsFunction(ref szLines);
        XX_GetFieldsOverTableNameFunction(ref szLines);
        XX_RemoveFromDBFunction(ref szLines);
        XX_UpdateInDBFunction(ref szLines);
        XX_GetNextHighestIdFunction(ref szLines);
        txtDSClass.Text = szLines;
    }

    private void XX_CreateDSReferenceSection(ref string szrLines)
    { 
                                        string szLines = string.Empty;

        szLines = "using System;" + Environment.NewLine;
        szLines = szLines + "using System.Collections;" + Environment.NewLine;
        szLines = szLines + "using System.Collections.Generic;" + Environment.NewLine;
        szLines = szLines + "using System.Collections.Specialized;" + Environment.NewLine;
        szLines = szLines + "using System.Linq;" + Environment.NewLine;
        szLines = szLines + "using System.Text;" + Environment.NewLine;
        szLines = szLines + "using CollectionClasses;" + Environment.NewLine;
        szLines = szLines + "using MySql.Data;" + Environment.NewLine;
        szLines = szLines + "using MySql.Data.MySqlClient;" + Environment.NewLine;
        szLines = szLines + "using Utilities;" + Environment.NewLine;
        szLines = szLines + "using DataBaseManagement;" + Environment.NewLine;
        szLines = szLines + "using System.Windows.Forms;" + Environment.NewLine;
        szLines = szLines + "using Models;" + Environment.NewLine;
        szLines = szLines + "";
        szrLines = szLines;
    }

    private void XX_CreateDSHeaderSection(ref string szrLines)
    { 
        szrLines = szrLines + "";
        szrLines = szrLines + "namespace Models" + Environment.NewLine;
        szrLines = szrLines + "{" + Environment.NewLine;
        szrLines = szrLines + "public class " + txtClassName.Text + "s_DS : I_DataServer" + Environment.NewLine;
        szrLines = szrLines + "{" + Environment.NewLine;
        szrLines = szrLines + "    private DatabaseConnection dbcx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private " + txtClassName.Text + "s " + txtInitials.Text + "sx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private Fields fdsx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private DBTable dbtx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private SQLGenerator sqlgx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private Utilities.Utilities utsx = null;" + Environment.NewLine;
        szrLines = szrLines + "    private string szxCurrent" + txtClassName.Text + "Id = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "";

    }

    private void XX_CreateDSInitializeFunction(ref string szrLines)
    {
        szrLines = szrLines + "    public " + txtClassName.Text + "s_DS(DatabaseConnection dbcv)" + Environment.NewLine; 
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "        dbcx = dbcv;" + Environment.NewLine;
        szrLines = szrLines + "        " + txtInitials.Text + "sx = new " + txtClassName.Text + "s();" + Environment.NewLine;
        szrLines = szrLines + "        fdsx = new Fields();" + Environment.NewLine;
        szrLines = szrLines + "        utsx = new Utilities.Utilities();" + Environment.NewLine;
        szrLines = szrLines + "        szxCurrent" + txtClassName.Text + "Id = '0';" + Environment.NewLine;
        szrLines = szrLines + "        dbtx = new DBTable();" + Environment.NewLine;
        szrLines = szrLines + "        sqlgx = new SQLGenerator(dbcx);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        XX_GetFieldsCollectionOverTableName(ref fdsx);" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;    
      
    }

    private void XX_GetFromDBSection(Fields fdsv,
                                     ref string szrLines) 
    {
        szrLines = szrLines + "        public void Get" +txtClassName.Text + "sFromDataBase(ref " + txtClassName.Text + "s " + txtInitials.Text + "sr)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "                                            string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                            MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                                            " + txtClassName.Text + " " + txtInitials.Text + "= new " + txtClassName.Text + "();" + Environment.NewLine;
        szrLines = szrLines + "                                            string szKey = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                            string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                            bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "    " + Environment.NewLine;
        szrLines = szrLines + "            szSQL = 'SELECT * FROM " + (txtClassName.Text + "s").ToLower() + "';" + Environment.NewLine;
        szrLines = szrLines + "    " + Environment.NewLine;
        szrLines = szrLines + "            dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                            ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                            ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                            ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "    " + Environment.NewLine;
        szrLines = szrLines + "    " + Environment.NewLine;
        szrLines = szrLines + "            while (mysql_dr.Read()) " + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                szKey = Convert.ToString(" + txtInitials.Text + "sx." + txtClassName.Text + "Count);" + Environment.NewLine;
        szrLines = szrLines + "                " + txtInitials.Text + "sx.Add" + txtClassName.Text + "(szKey," + Environment.NewLine;
        szrLines = szrLines + "                                                                        ref " + txtInitials.Text + ");" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;

        bool bFirstField = true;
        foreach (Field fd in fdsv) 
        {
            if (bFirstField)
            {
                szrLines = szrLines + "                " + txtInitials.Text + "." + fd.Key + " = Convert.ToInt32(mysql_dr['" + fd.Key + "'].ToString());" + Environment.NewLine;
            }
            else
            {
                szrLines = szrLines + "                " + txtInitials.Text + "." + fd.Key + " = mysql_dr['" + fd.Key + "'].ToString();" + Environment.NewLine;
            }
            bFirstField = false;
        }

        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "        " + Environment.NewLine;
        szrLines = szrLines + "        mysql_dr.Close(); " + Environment.NewLine;
        szrLines = szrLines + "        mysql_dr.Dispose(); " + Environment.NewLine;
        szrLines = szrLines + "        " + Environment.NewLine;
        szrLines = szrLines + "}" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
    }

    private void XX_GetFirstRecordFromDBFunction(ref string szrLines)
    { 
        szrLines = szrLines + "    public void GetFirstRecordFromDataBase(ref Fields fdsr," + Environment.NewLine;
        szrLines = szrLines + "                                           ref bool brNothingFound," + Environment.NewLine;
        szrLines = szrLines + "                                           ref bool brErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                                           ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                                    string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    string szKey = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                                    Fields fds = new Fields();" + Environment.NewLine;
        szrLines = szrLines + "                                    string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        szSQL = 'SELECT * FROM " + (txtClassName.Text + "s").ToLower() + " ORDER BY " + txtClassName.Text + "Id ASC LIMIT 1';" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                        ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        while (true) " + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            while (mysql_dr.Read())" + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                XX_MoveRecordToMemberObject(ref mysql_dr," + Environment.NewLine;
        szrLines = szrLines + "                                            ref fds);" + Environment.NewLine;
        szrLines = szrLines + "                " + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "            break;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        if (!mysql_dr.IsClosed) " + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Close();" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Dispose();" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsr = fds;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;   
    
    }

    private void XX_GetNextRecordFromDBFunction(ref string szrLines)
    {
        szrLines = szrLines + "    public void GetNextRecordFromDataBase(ref Fields fdsr, " + Environment.NewLine;
        szrLines = szrLines + "                                          ref bool brEndOfFind, " + Environment.NewLine;
        szrLines = szrLines + "                                          ref bool brErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                                          ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                        string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                        string szKey = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                        bool bEndOfFind = true;" + Environment.NewLine;
        szrLines = szrLines + "                        MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                        Fields fds = new Fields();" + Environment.NewLine;
        szrLines = szrLines + "                        string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                        bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        szSQL = 'SELECT * FROM " + (txtClassName.Text + "s").ToLower() + " WHERE " + txtClassName.Text + "Id > ' + szxCurrent" + txtClassName.Text + "Id" + Environment.NewLine;
        szrLines = szrLines + "              + ' ORDER BY " + txtClassName.Text + "Id ASC LIMIT 1';" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                        ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        while (true)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            while (mysql_dr.Read())" + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                bEndOfFind = false;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "                XX_MoveRecordToMemberObject(ref mysql_dr," + Environment.NewLine;
        szrLines = szrLines + "                                            ref fds);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "            break;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        if (!mysql_dr.IsClosed)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Close();" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Dispose();" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsr = fds;" + Environment.NewLine;
        szrLines = szrLines + "        brEndOfFind = bEndOfFind;" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;    
    }

    private void XX_GetPreviousRecordFromDBFunction(ref string szrLines)
    { 
        szrLines = szrLines + "    public void GetPreviousRecordFromDataBase(ref Fields fdsr, " + Environment.NewLine;
        szrLines = szrLines + "                                              ref bool brEndOfFind, " + Environment.NewLine;
        szrLines = szrLines + "                                              ref bool brErrorFound," + Environment.NewLine; 
        szrLines = szrLines + "                                              ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                                    string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    string szKey = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    bool bEndOfFind = true;" + Environment.NewLine;
        szrLines = szrLines + "                                    MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                                    Fields fds = new Fields();" + Environment.NewLine;
        szrLines = szrLines + "                                    string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        szSQL = 'SELECT * FROM " + (txtClassName.Text + "s").ToLower() + " WHERE " + txtClassName.Text + "Id < ' + szxCurrent" + txtClassName.Text + "Id" + Environment.NewLine;
        szrLines = szrLines + "                + ' ORDER BY " + txtClassName.Text + "Id DESC LIMIT 1';" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                        ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        while (true)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            while (mysql_dr.Read())" + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                bEndOfFind = false;" + Environment.NewLine;
        szrLines = szrLines + "                XX_MoveRecordToMemberObject(ref mysql_dr," + Environment.NewLine;
        szrLines = szrLines + "                                            ref fds);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "            break;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        if (!mysql_dr.IsClosed)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Close();" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Dispose();" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsr = fds;" + Environment.NewLine;
        szrLines = szrLines + "        brEndOfFind = bEndOfFind;" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;    
    }

    private void XX_GetLastRecordFromDBFunction(ref string szrLines)
    {
        szrLines = szrLines + "        public void GetLastRecordFromDataBase(ref Fields fdsr, " + Environment.NewLine;
        szrLines = szrLines + "                                             ref bool brNothingFound, " + Environment.NewLine;
        szrLines = szrLines + "                                             ref bool brErrorFound, " + Environment.NewLine;
        szrLines = szrLines + "                                             ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "        							   string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    string szKey = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                                    Fields fds = new Fields();" + Environment.NewLine;
        szrLines = szrLines + "                                    string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                    bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        szSQL = 'SELECT * FROM " + (txtClassName.Text + "s").ToLower() + " ORDER BY " + txtClassName.Text + "Id DESC LIMIT 1';" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                        ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        while (true)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            while (mysql_dr.Read())" + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                XX_MoveRecordToMemberObject(ref mysql_dr," + Environment.NewLine;
        szrLines = szrLines + "                                            ref fds);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "            break;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        if (!mysql_dr.IsClosed)" + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Close();" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Dispose();" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsr = fds;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;     
    }

    private void XX_MoveRecordToFieldsFunction(Fields fdsv,
                                               ref string szrLines)
    { 
        szrLines = szrLines + "    private void XX_MoveRecordToMemberObject(ref MySqlDataReader mysql_drr," + Environment.NewLine; 
        szrLines = szrLines + "                                             ref Fields fdsr)" + Environment.NewLine; 
        szrLines = szrLines + "    {" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "        szxCurrent" + txtClassName.Text + "Id = mysql_drr['" + "szxCurrent" + txtClassName.Text + "Id'].ToString();" + Environment.NewLine;

        foreach (Field fd in fdsv)
        {
            szrLines = szrLines + "        fdsx.ItemIsField('" + fd.Key + "').StringValue = mysql_drr['" + fd.Key + "'].ToString();" + Environment.NewLine;
        }

        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsr = fdsx;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "}" + Environment.NewLine;
    }

    private void XX_AddToDBFunction(ref string szrLines) 
    {
        szrLines = szrLines + "    public void AddToDataBase(Fields fdsv, " + Environment.NewLine;
        szrLines = szrLines + "                              ref bool brErrorFound, " + Environment.NewLine;
        szrLines = szrLines + "    							 ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                                        string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        long l" + txtClassName.Text + "Id = 0;" + Environment.NewLine;
        szrLines = szrLines + "                                        string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        string szCounter = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        XX_GetNext" + txtClassName.Text + "Id(ref l" + txtClassName.Text + "Id);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        fdsv.ItemIsField('" + txtClassName.Text + "Id').StringValue = Convert.ToString(l" + txtClassName.Text + "Id);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        sqlgx.CreateSQLQueryForInsertOverFieldsCollection(fdsv," + Environment.NewLine;
        szrLines = szrLines + "                                                          ref szSQL);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        brErrorFound = bErrorFound;" + Environment.NewLine;
        szrLines = szrLines + "        szrErrorMessage = szErrorMessage;" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + " " + Environment.NewLine;    
    }

    private void XX_GetNextIdFunction(ref string szrLines)
    {
        szrLines = szrLines + "    private void XX_GetNext" + txtClassName.Text + "Id(ref long lr" + txtClassName.Text + "Id) " + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                                        string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        MySqlDataReader mysql_dr = null;" + Environment.NewLine;
        szrLines = szrLines + "                                        long l" + txtClassName.Text + "Id = 0;" + Environment.NewLine;
        szrLines = szrLines + "                                        string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        szSQL = 'SELECT MAX(" + txtClassName.Text + "Id) FROM " + (txtClassName.Text + "s").ToLower() + "';" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage," + Environment.NewLine;
        szrLines = szrLines + "                        ref mysql_dr);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        while (true) " + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            if (mysql_dr == null) " + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                break;" + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "            l" + txtClassName.Text + "Id = 1;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "            if (mysql_dr.Read())" + Environment.NewLine;
        szrLines = szrLines + "            {" + Environment.NewLine;
        szrLines = szrLines + "                try" + Environment.NewLine;
        szrLines = szrLines + "                {" + Environment.NewLine;
        szrLines = szrLines + "                    l" + txtClassName.Text + "Id = Convert.ToInt32(mysql_dr[0].ToString());" + Environment.NewLine;
        szrLines = szrLines + "                }" + Environment.NewLine;
        szrLines = szrLines + "                catch" + Environment.NewLine;
        szrLines = szrLines + "                {" + Environment.NewLine;
        szrLines = szrLines + "                    l" + txtClassName.Text + "Id = 0;" + Environment.NewLine;
        szrLines = szrLines + "                }" + Environment.NewLine;
        szrLines = szrLines + "            }" + Environment.NewLine;
        szrLines = szrLines + "            break;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        if (mysql_dr != null) " + Environment.NewLine;
        szrLines = szrLines + "        {" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Close();" + Environment.NewLine;
        szrLines = szrLines + "            mysql_dr.Dispose();" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        lr" + txtClassName.Text + "Id = l" + txtClassName.Text + "Id + 1;" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;      
    }

    private void XX_GetFieldsFunction(ref string szrLines)
    {
        szrLines = szrLines + "    public Fields Fields" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "        get {" + Environment.NewLine;
        szrLines = szrLines + "            return fdsx;" + Environment.NewLine;
        szrLines = szrLines + "        }" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;     
    }

    private void XX_GetFieldsOverTableNameFunction(ref string szrLines)
    { 
        szrLines = szrLines + "    private void XX_GetFieldsCollectionOverTableName(ref Fields fdsr)" + Environment.NewLine; 
        szrLines = szrLines + "    {" + Environment.NewLine; 
        szrLines = szrLines + "                                        string szTableFilePath = string.Empty;" + Environment.NewLine; 
        szrLines = szrLines + "                                        bool bFileExists = false;" + Environment.NewLine; 
        szrLines = szrLines + "                                        ArrayList alFieldNames = new ArrayList();" + Environment.NewLine; 
        szrLines = szrLines + "                                        Field fd = new Field();" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "        szTableFilePath = dbcx.ApplicationPathCarrier.TablesPath" + Environment.NewLine; 
        szrLines = szrLines + "                        + @'\'" + Environment.NewLine;
        szrLines = szrLines + "                        + '" + txtClassName.Text + "s.tbl';" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "        while (true)" + Environment.NewLine; 
        szrLines = szrLines + "        {" + Environment.NewLine; 
        szrLines = szrLines + "            bFileExists = System.IO.File.Exists(szTableFilePath);" + Environment.NewLine; 
        szrLines = szrLines + "            if (!bFileExists)" + Environment.NewLine; 
        szrLines = szrLines + "            {" + Environment.NewLine; 
        szrLines = szrLines + "                MessageBox.Show('Members table not found'," + Environment.NewLine; 
        szrLines = szrLines + "                                'Missing Table File');" + Environment.NewLine; 
        szrLines = szrLines + "                break;" + Environment.NewLine; 
        szrLines = szrLines + "            }" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "            dbtx.GetFieldsCollection(szTableFilePath," + Environment.NewLine; 
        szrLines = szrLines + "                                     ref fdsr);" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "            break;" + Environment.NewLine; 
        szrLines = szrLines + "        }" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "    }" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine;     
    }

    private void XX_RemoveFromDBFunction(ref string szrLines)
    { 
        szrLines = szrLines + "    public void RemoveFromDataBase(Fields fdsv," + Environment.NewLine; 
        szrLines = szrLines + "                                   ref bool brErrorFound," + Environment.NewLine; 
        szrLines = szrLines + "                                   ref string szrErrorMessage) " + Environment.NewLine; 
        szrLines = szrLines + "    {" + Environment.NewLine; 
        szrLines = szrLines + "                                    string szSQL = string.Empty;" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "        szSQL = 'DELETE FROM " + (txtClassName.Text + "s").ToLower() + " WHERE " + txtClassName.Text + "Id = ' + fdsv.ItemIsField('" + txtClassName.Text + "Id').StringValue;" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine; 
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine; 
        szrLines = szrLines + "                        ref brErrorFound," + Environment.NewLine; 
        szrLines = szrLines + "                        ref szrErrorMessage);" + Environment.NewLine; 
        szrLines = szrLines + "    }" + Environment.NewLine; 
        szrLines = szrLines + "" + Environment.NewLine;     

    }

    private void XX_UpdateInDBFunction(ref string szrLines)
    {
        szrLines = szrLines + "    public void UpdateDataInDataBase(Fields fdsv," + Environment.NewLine;
        szrLines = szrLines + "                                     ref bool brErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                                     ref string szrErrorMessage)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "                                        string szSQL = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        string szErrorMessage = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        string szCounter = string.Empty;" + Environment.NewLine;
        szrLines = szrLines + "                                        bool bErrorFound = true;" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        sqlgx.CreateSQLQueryForUpdateTable(fdsv," + Environment.NewLine;
        szrLines = szrLines + "                                           ref szSQL);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        dbcx.ExecuteSQL(szSQL," + Environment.NewLine;
        szrLines = szrLines + "                        ref bErrorFound," + Environment.NewLine;
        szrLines = szrLines + "                        ref szErrorMessage);" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "        brErrorFound = bErrorFound;" + Environment.NewLine;
        szrLines = szrLines + "        szrErrorMessage = szErrorMessage;" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;    
   
    }

    private void XX_GetNextHighestIdFunction(ref string szrLines)
    {
        szrLines = szrLines + "    public void GetNextHighestId(ref long lrId)" + Environment.NewLine;
        szrLines = szrLines + "    {" + Environment.NewLine;
        szrLines = szrLines + "        XX_GetNext" + txtClassName.Text + "Id(ref lrId);" + Environment.NewLine;
        szrLines = szrLines + "    }" + Environment.NewLine;
        szrLines = szrLines + "" + Environment.NewLine;
        szrLines = szrLines + "}" + Environment.NewLine;
        szrLines = szrLines + "}" + Environment.NewLine;
    }

    private void btnAddRow_Click(object sender, EventArgs e)
    {
        XX_AddRowIf();
    }

    private void XX_AddRowIf()
    { 
                                        int nCurrentRow = 0;
                                        bool bAddRow = false;
                                        DataGridViewCell dgvc = null;
                                        bool bFirstRow = false;
                                        bool bCellEmpty = false;

        nCurrentRow = dgvTable.RowCount;

        bFirstRow = nCurrentRow == 0;

        while (true)
        {
            if (bFirstRow)
            {
                bAddRow = true;
                break;
            }

            bAddRow = true;
            for (int nColumn = 0; nColumn <= dgvTable.ColumnCount - 1; nColumn++)
            {
                dgvc = dgvTable[nColumn, nCurrentRow - 1];

                if (dgvc.Value == null)
                {
                    bAddRow = false;
                    break;
                }

                if (dgvc.Value.ToString() == "" && dgvc.OwningColumn.Name != "InitialValue")
                {
                    bAddRow = false;
                    break;
                }

                if (bCellEmpty) 
                {
                    bAddRow = false;
                }

            }
            break;
        }

        if (bAddRow)
        {
            dgvTable.Rows.Add(1);
            dgvc = dgvTable[2, dgvTable.Rows.Count - 1];
            dgvc.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvc.Value = 0;

            dgvc = dgvTable[3, dgvTable.Rows.Count - 1];
            dgvc.Value = "";
        }
    }

    private void btnCreateTableFile_Click(object sender, EventArgs e)
    {
                                        string szLines = string.Empty;
                                        int nRowCount = 1;

        szLines = szLines + "[Table]" + Environment.NewLine;
        szLines = szLines + "Name=" + txtTableName.Text + Environment.NewLine;
        szLines = szLines + "" + Environment.NewLine;

        foreach (DataGridViewRow dgvr in dgvTable.Rows)
        {
            szLines = szLines + "[Field_" + nRowCount.ToString() + "]" + Environment.NewLine;

            szLines = szLines + "Key=" + dgvr.Cells[0].Value.ToString() + Environment.NewLine;
            szLines = szLines + "Type=" + dgvr.Cells[1].Value.ToString() + Environment.NewLine;
            szLines = szLines + "Length=" + dgvr.Cells[2].Value.ToString() + Environment.NewLine;
            szLines = szLines + "InitialValue=" + dgvr.Cells[3].Value.ToString() + Environment.NewLine;
            szLines = szLines + "LocalizedName=" + dgvr.Cells[4].Value.ToString() + Environment.NewLine;
            szLines = szLines + "ValueRequired=" + dgvr.Cells[5].Value.ToString() + Environment.NewLine;
            szLines = szLines + "" + Environment.NewLine;

            nRowCount = nRowCount + 1;
        }

        szLines = szLines + "[PrimaryKeys]" + Environment.NewLine;
        szLines = szLines + "Key_1=" + txtPrimaryKey.Text + Environment.NewLine;
        txtTableContents.Text = szLines;
    }
}
}
