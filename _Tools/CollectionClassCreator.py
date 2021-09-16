import M_ConfigFileAccessor as cfax

class Section(object):
    def __init__(self):
        self._Index = 0
        self._Key = ''
        self._Name = ''
        self._Type = ''

    def _getKey(self):
        return self._Key
    def _setKey(self, value):
        self._Key = value

    def _getName(self):
        return self._Name
    def _setName(self, value):
        self._Name = value

    def _getIndex(self):
        return self._Index
    def _setIndex(self, value):
        self._Index = value

    def _getType(self):
        return self._Type
    def _setType(self, value):
        self._Type = value

    Key = property(_getKey, _setKey)
    Name = property(_getName, _setName)
    Index = property(_getIndex, _setIndex)
    Type = property(_getType, _setType)
    
class Main:
    def __init__(self, szTableFileName):
        self._TAB = '    '
        cfa = cfax.ConnectToFile(szTableFileName)
        szName = cfa.GetValue('Table', 'Name', 0)
        szName = szName[:len(szName) -1]
        self._lcSections = []
        nIndex = 0
        
        for sec in cfa.Sections:
            if sec.startswith('Field_'):
                szKey = cfa.GetValue(sec, 'Key', 0)
                szType = cfa.GetValue(sec, 'Type', 0)
                s = Section()
                s.Index = nIndex
                s.Key = szKey
                s.Name = szKey
                s.Type = szType

                self._lcSections.append(s)
                nIndex = nIndex + 1
        
        self.CreateHeader(szName)
        self.CreateProperties(szName)

        self.CreateCollectionClassHeader(szName)
    def GetClassInitials(self, szClassName):
        szInitials = ''

        for szChar in szClassName:
            if szChar.isupper():
                szInitials = szInitials + szChar

        szInitials = szInitials.lower()

        return szInitials
    
    def CreateHeader(self, szName):
        szInitials = self.GetClassInitials(szName)
        print 'using System;'
        print 'using System.Collections.Generic;'
        print 'using System.Text;'
        print ''
        print 'namespace CollectionClasses'
        print '{'
        print 'public class ' + szName
        print '{'

        print self._TAB + 'private ' + szName + 's ' + szInitials +'sxParent = null;'
        print self._TAB + 'private int nxrwIndex = 0;'
        print self._TAB + 'private string szxrwKey = string.Empty;'
        for sec in self._lcSections:
            if sec.Type == 'String':
                szTypePrefix = 'string szxrw'
                szDefaultValue = 'string.Empty'
            elif sec.Type == 'Integer':
                szTypePrefix = 'int nxrw'
                szDefaultValue = '0'
            elif sec.Type == 'Long':
                szTypePrefix = 'long lxrw'
                szDefaultValue = '0'
            elif sec.Type == 'Double':
                szTypePrefix = 'double dxrw'
                szDefaultValue = '0'
            elif sec.Type == 'Decimal':
                szTypePrefix = 'decimal dcxrw'
                szDefaultValue = '0'

            szDeclaration = 'private ' + szTypePrefix + sec.Name + ' = ' + szDefaultValue + ';'
            print self._TAB + szDeclaration

        print ''

    def CreateProperties(self, szName):
        szInitials = self.GetClassInitials(szName)
        print self._TAB + 'public ' + szName + 's ParentIs' + szName + 's'
        print self._TAB + '{'
        print (self._TAB * 2) + 'get'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'return ' + szInitials +'sxParent;'
        print (self._TAB * 2) + '}'
        print (self._TAB * 2) + 'set'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + szInitials +'sxParent = value;'
        print (self._TAB * 2) + '}'
        print self._TAB + '}'
        print ''
        print self._TAB + 'public string Key'
        print self._TAB + '{'
        print (self._TAB * 2) + 'get'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'return szxrwKey;'
        print (self._TAB * 2) + '}'
        print (self._TAB * 2) + 'set'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'szxrwKey = value;'
        print (self._TAB * 2) + '}'
        print self._TAB + '}'
        print ''
        print self._TAB + 'public int Index'
        print self._TAB + '{'
        print (self._TAB * 2) + 'get'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'return nxrwIndex;'
        print (self._TAB * 2) + '}'
        print (self._TAB * 2) + 'set'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'nxrwIndex = value;'
        print (self._TAB * 2) + '}'
        print self._TAB + '}'
        print ''        
        for sec in self._lcSections:
            if sec.Type == 'String':
                szType = 'string'
                szDefaultValue = 'szxrw'
            elif sec.Type == 'Integer':
                szType = 'int'
                szDefaultValue = 'nxrw'
            elif sec.Type == 'Long':
                szType = 'long'
                szDefaultValue = 'lxrw'
            elif sec.Type == 'Double':
                szType = 'double'
                szDefaultValue = 'dxrw'
            elif sec.Type == 'Decimal':
                szType = 'decimal'
                szDefaultValue = 'dcrw'

            print self._TAB + 'public ' + szType + ' ' + sec.Name
            print self._TAB + '{'
            print (self._TAB * 2) + 'get'
            print (self._TAB * 2) + '{'
            print (self._TAB * 3) + 'return ' + szDefaultValue + sec.Name + ';'
            print (self._TAB * 2) + '}'
            print (self._TAB * 2) + 'set'
            print (self._TAB * 2) + '{'
            print (self._TAB * 3) + szDefaultValue + sec.Name + ' = value;'
            print (self._TAB * 2) + '}'
            print self._TAB + '}'
            print ''
            
        print '}'
        print '}'
        print '*****=====================================================================*****'

    def CreateCollectionClassHeader(self, szName):
        szInitials = self.GetClassInitials(szName)
        print 'using System;'
        print 'using System.Collections;'
        print 'using System.Collections.Generic;'
        print 'using System.Collections.Specialized;'
        print 'using System.Text;'
        print ''
        print 'namespace CollectionClasses'
        print '{'
        print self._TAB + 'public class ' + szName + 's : IEnumerable'
        print self._TAB + '{'
        print (self._TAB * 2) + 'private ArrayList collx = null;'
        print ''
        print (self._TAB * 2) + 'public IEnumerator GetEnumerator()'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'return collx.GetEnumerator();'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public ' + szName + 's()'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'collx = new ArrayList();'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public void Add' + szName + '(string szvKey,'
        print ' ' * len((self._TAB * 2) + 'public void Add' + szName + '(') + 'ref ' + szName + ' ' + szInitials + 'r)'
        print (self._TAB * 2) + '{'
        print (self._TAB * 10) + szName + ' ' + szInitials + ' = new ' + szName + '();'
        print ''
        print (self._TAB * 3) + 'collx.Add(' + szInitials + ');'
        print ''
        print (self._TAB * 3) + szInitials + '.Key = szvKey;'
        print (self._TAB * 3) + szInitials + '.Index = collx.Count;'
        print (self._TAB * 3) + szInitials + '.ParentIs' + szName + 's = this;'
        print ''
        print (self._TAB * 3) + szInitials + 'r  = ' + szInitials + ';'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public ' + szName + ' ItemIs' + szName + '(string szvKey)'
        print (self._TAB * 2) + '{'
        print (self._TAB * 10) + 'bool b' + szName + 'Found = false;'
        print (self._TAB * 10) + szName + ' ' + szInitials + 'Main = null;'
        print ''
        print (self._TAB * 3) + 'foreach (' + szName + ' ' +  szInitials + ' in collx)'
        print (self._TAB * 3) + '{'
        print (self._TAB * 4) + 'b' + szName + 'Found = ' + szInitials + '.Key == szvKey;'
        print ''
        print (self._TAB * 4) + 'if (b' + szName + 'Found)'
        print (self._TAB * 4) + '{'
        print (self._TAB * 5) + szInitials + 'Main = ' + szInitials + ';'
        print (self._TAB * 5) + 'break;'
        print (self._TAB * 4) + '}'
        print (self._TAB * 3) + '}'
        print ''
        print (self._TAB * 3) + 'return ' + szInitials + 'Main;'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public long ' + szName + 'Count'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'get'
        print (self._TAB * 3) + '{'
        print (self._TAB * 4) + 'return Convert.ToInt64(collx.Count);'
        print (self._TAB * 3) + '}'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public bool KeyExists(string szvKey)'
        print (self._TAB * 2) + '{'
        print (self._TAB * 10) + 'bool b' + szName + 'Found = false;'
        print ''
        print (self._TAB * 3) + 'foreach (' + szName + ' ' +  szInitials + ' in collx)'
        print (self._TAB * 3) + '{'
        print (self._TAB * 4) + 'b' + szName + 'Found = ' + szInitials + '.Key == szvKey;'
        print ''
        print (self._TAB * 4) + 'if (b' + szName + 'Found)'
        print (self._TAB * 4) + '{'
        print (self._TAB * 5) + 'break;'
        print (self._TAB * 4) + '}'
        print (self._TAB * 3) + '}'
        print ''
        print (self._TAB * 3) + 'return b' + szName + 'Found;'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public void Remove' + szName + '(string szvKey)'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'collx.Remove(szvKey);'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public void Remove' + szName + '(long lvKey)'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'collx.Remove(lvKey);'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + 'public void RemoveAll' + szName + 's()'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'collx.Clear();'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 2) + '~' + szName + 's()'
        print (self._TAB * 2) + '{'
        print (self._TAB * 3) + 'collx.Clear();'
        print (self._TAB * 2) + '}'
        print ''
        print (self._TAB * 1) + '}'
        print '}'
if __name__ == '__main__':
    szPath = r'C:\Users\Kevin\Documents\Visual Studio 2010\Projects\PayrollSystem\Step_48\PayrollSystem\bin\Debug\Tables\Tags.tbl'
    Main(szPath)
