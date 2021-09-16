import os
import ConfigParser as cnfg_pas
import M_EnumsComponent as ecx
    
class ConnectToFile():
    def __init__(self, szFileName):
        self.Connect(szFileName)

    def Connect(self, szFileName):
        self.EnumsForAccessorValues = ecx.EnumsValueType()
        self.FileName = szFileName
        self.RawConfigParser = cnfg_pas.RawConfigParser()
        self.RawConfigParser.read(szFileName)
        self.GetSections()
        
    def GetRawConfig(self):
        return self.RawConfigParser
    
    def GetValue(self, szSection, szKey, efav=0):
        bSectionExists = False
        Value = None
        while True:
            for sec in self.RawConfigParser.sections():
                if sec == szSection:
                    bSectionExists = True
                    break

            if not bSectionExists:
                break
            
            Value = self._GetValue(efav,
                                   szSection,
                                   szKey,
                                   bSectionExists)
            break
        
        return Value
        
    def _GetValue(self,
                  efav,
                  szvSection,
                  szvKey,
                  bvSectionExists):

        bWrongBooleanValue = False
        Value = ''
        while True:
            if not bvSectionExists:
                break
            
            szValue = self.RawConfigParser.get(szvSection, szvKey)
            if efav == self.EnumsForAccessorValues.efavString:
                Value = szValue
            elif efav == self.EnumsForAccessorValues.efavInteger:
                Value = int(szValue)
            elif efav == self.EnumsForAccessorValues.efavLong:
                Value = long(szValue)
            elif efav == self.EnumsForAccessorValues.efavDouble:
                Value = float(szValue)
            elif efav == self.EnumsForAccessorValues.efavBoolean:
                nValue = 0

                if szValue.upper() == 'TRUE':
                    nValue = 1
                elif szValue.upper() == 'FALSE':
                    nValue = 0
                else:
                    bWrongBooleanValue = True
                    
                Value = bool(nValue)
                
                if bWrongBooleanValue:
                    Value = "Wrong Boolean Value"
            else:
                Value = szValue
            break
        
        return Value
    
    def WriteToSection(self,
                       ssSection,
                       ssKey,
                       ssNewValue):
        
        self.RawConfigParser.set(ssSection, ssKey, ssNewValue)
        File = open(self.FileName, 'w')
        self.RawConfigParser.write(File)
        File.close()

    def GetSections(self):
        
        self._Sections = self._GetSections()
        return self._Sections
    
    def _GetSections(self):
        lcSections = []
        for sec in self.RawConfigParser.sections():
            lcSections.append(sec)

        return lcSections
    
    def GetKeysInSection(self,
                         ssSection):
        self.Keys = []
        
        for key in self.RawConfigParser.options(ssSection):
            self.Keys.append(key)

        return self.Keys

    def GetValuesInSectionAsString(self,
                                   ssSection):
        Values = []

        for key in self.RawConfigParser.options(ssSection):
            ssValue = self.RawConfigParser.get(ssSection, key)
            Values.append(ssValue)

        return Values

    def SectionExists(self, ssSection):
        bSectionExists = False
        lcSections = self._GetSections()

        for section in lcSections:
            if section == ssSection:
                bSectionExists = True
                break

        return bSectionExists
    
    Sections = property(GetSections)
    
if __name__ == '__main__':
    szPath = r'D:\700_C#_Mastering\_CurrentVersion\V11_HF\164_PPSOne_V11_SP04_PL51_HF07_CR00_CF00_Step03\CimPoolPPS\Client\_Any\TableDefinition'

    nCount = 0
    for fl in os.listdir(szPath):
        szFile = ''.join([szPath, '\\', fl])
        conn = ConnectToFile(szFile)

        try:
            szName = conn.GetValue('AddOnMembers', 'Member_1', 0)
            
            if szName.lower() == 'ppsone' or szName.lower() == 'frameworker':
                nCount = nCount + 1
                print fl, szName
                
        except Exception as err:
            pass

    print nCount
