using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
public class ApplicationPathCarrier
{
    private string szxApplicationPath = "";
    private bool bxrwFirstTimeLaunch = false;

    public ApplicationPathCarrier(string szvApplicationPath) 
    {
        szxApplicationPath = szvApplicationPath;
    }

    public bool FirstTimeLaunch
    {
        get
        {
            return bxrwFirstTimeLaunch;
        }
        set
        {
            bxrwFirstTimeLaunch = value;
        }
    }

    public string ApplicationPath 
    {
        get 
        {
            return szxApplicationPath;
        }
    }

    public string StudentImagesPath
    {
        get
        {
            string szStudentImagesPath = string.Empty;
            szStudentImagesPath = szxApplicationPath
                         + @"\Images\StudentImages";
            return szStudentImagesPath;
        }
    }

    public string ImagesPath
    {
        get
        {
            string szImagesPath = string.Empty;
            szImagesPath = szxApplicationPath
                         + @"\Images";
            return szImagesPath;
        }
    }

    public string ReportsPath
    {
        get
        {
            string szReportsPath = string.Empty;
            szReportsPath = szxApplicationPath
                          + @"\Reports";
            return szReportsPath;
        }
    }

    public string TablesPath
    {
        get
        {
            string szTablesPath = string.Empty;
            szTablesPath = szxApplicationPath
                         + @"\Tables";
            return szTablesPath;
        }
    }

    public string IconsPath
    {
        get
        {
            string szIconsPath = string.Empty;
            szIconsPath = szxApplicationPath
                        + @"\Icons";
            return szIconsPath;
        }
    }
}
}
