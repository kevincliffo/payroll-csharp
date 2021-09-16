using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace CollectionClasses
{
public class User
{
    private Users usrsxParent = null;
    private string szxrwxKey = string.Empty;
    private long lxrwUserId = 0;
    private string szxrwUserName = string.Empty;
    private string szxrwPassword = string.Empty;
    private string szxrwFirstName = string.Empty;
    private string szxrwLastName = string.Empty;
    private string szxrwOtherName = string.Empty;
    private string szxrwEmail = string.Empty;
    private string szxrwTelephone = string.Empty;
    private long lxrwxIndex = 0;
    private EnumsCollection.EnumUserType eutx = new EnumsCollection.EnumUserType();

    public Users ParentIsUsers
    {
        get
        {
            return usrsxParent;
        }
        set
        {
            usrsxParent = value;
        }
    }
  
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

    public long UserId
    {
        get
        {
            return lxrwUserId;
        }
        set
        {
            lxrwUserId = value;
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
    public string FirstName
    {
        get
        {
            return szxrwFirstName;
        }
        set
        {
            szxrwFirstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return szxrwLastName;
        }
        set
        {
            szxrwLastName = value;
        }
    }
    public string OtherName
    {
        get
        {
            return szxrwOtherName;
        }
        set
        {
            szxrwOtherName = value;
        }
    }
    public string Email
    {
        get
        {
            return szxrwEmail;
        }
        set
        {
            szxrwEmail = value;
        }
    }

    public EnumsCollection.EnumUserType EnumUserType 
    {
        get 
        {
            return eutx;
        }
        set 
        {
            eutx = value;
        }
    }

    public string Telephone
    {
        get
        {
            return szxrwTelephone;
        }
        set
        {
            szxrwTelephone = value;
        }
    }
}
}
