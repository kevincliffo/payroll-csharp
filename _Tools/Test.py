import os

szPath = r'C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayrollSystem\Step_40\Models'

def GetClassInitials(szClassName):
    szInitials = ''

    for szChar in szClassName:
        if szChar.isupper():
            szInitials = szInitials + szChar

    szInitials = szInitials.lower()

    return szInitials

def GetClassNameOverFileName(szFileName):
    szName = szFileName[2:]
    szName = szName[:len(szName) -3]

    return szName

for t in os.listdir(szPath):
    if t.endswith('_DS.cs'):
        szName = GetClassNameOverFileName(t)
        szInitials = GetClassInitials(szName)
        szInitials = (szInitials.split('ds')[0]) + '_dsx' 
##        print 'private ' + szName + ' ' + szInitials + ' = null;'
        print szInitials + ' = new ' + szName + '(dbcx);'

    
