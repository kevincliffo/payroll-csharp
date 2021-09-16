import os
import shutil

szCurrentFolder = r'..\Reports'
szDestinationFolder = ''.join([os.path.abspath(os.pardir), '\\PayrollSystem\\bin\\Debug\\Reports'])

def FileIsAReportFile(szFile):
    bFileIsAReportFile = szFile.lower().endswith('.rpt')

    return bFileIsAReportFile

def GetReports():
    for fl in os.listdir(szCurrentFolder):
        szFile = ''.join([szCurrentFolder, '\\', fl])
        while True:
            if os.path.isdir(szFile):
                break
        
            bFileIsAReportFile = FileIsAReportFile(szFile)

            if bFileIsAReportFile:
                szDestination = ''.join([szDestinationFolder, '\\', fl])
                shutil.copy(szFile, szDestination)
                
            break
        
GetReports()        
