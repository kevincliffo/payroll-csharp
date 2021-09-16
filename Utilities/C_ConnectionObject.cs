using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
public class ConnectionObject
{
    private string szxrwServerName = string.Empty;
    private string szxrwUserName = string.Empty;
    private string szxrwDataBaseName = string.Empty;
    private string szxrwPassword = string.Empty;
    private string szxrwConnectionString = string.Empty;
    private string szxrwErroMessage = string.Empty;
    private bool bxrwErrorFound = false;

    public string ServerName
    {
        get
        {
            return szxrwServerName;
        }
        set
        {
            szxrwServerName = value;
        }
    }
    public string UserName
    {
        get
        {
            return szxrwUserName;
        }
        set
        {
            szxrwUserName = value;
        }
    }
    public string DataBaseName
    {
        get
        {
            return szxrwDataBaseName;
        }
        set
        {
            szxrwDataBaseName = value;
        }
    }
    public string Password
    {
        get
        {
            return szxrwPassword;
        }
        set
        {
            szxrwPassword = value;
        }
    }
    public string ConnectionString
    {
        get
        {
            return szxrwConnectionString;
        }
        set
        {
            szxrwConnectionString = value;
        }
    }
    public string ErroMessage
    {
        get
        {
            return szxrwErroMessage;
        }
        set
        {
            szxrwErroMessage = value;
        }
    }
    public bool ErrorFound
    {
        get
        {
            return bxrwErrorFound;
        }
        set
        {
            bxrwErrorFound = value;
        }
    }
}
}
