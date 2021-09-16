using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Utilities
{
public class FileAccessor
{
    private StreamWriter swx;
    private StreamReader srx;
    private Sections ssx = null;
    private Utilities utsx = null;

    public FileAccessor() {
        ssx = new Sections();
        utsx = new Utilities();
    }

    public Sections Sections 
    {
        get 
        {
            return ssx;
        }
    }

    public void ReleaseSections()
    {
        
    }

    private void XX_ReleaseSections()
    {
        ssx.RemoveAllSections();
    }

    public void ConnectToFile(string szvFileName,
                              EnumsCollection.EnumFileAccessType efatv) {

                                  bool bFileExists = false;
        while(true){
            XX_FileExists(szvFileName,
                          ref bFileExists);

            if (!bFileExists) {
                break;
            }

            XX_ReleaseSections();

            switch(efatv){
                case EnumsCollection.EnumFileAccessType.efatRead:
                    srx = new StreamReader(szvFileName);
                    XX_GetSections();
                    srx.Close();
                    break;

                case EnumsCollection.EnumFileAccessType.efatWrite:
                    swx = new StreamWriter(szvFileName);
                    break;
            }
            break;
        }
        
    }

    public void FileIsLocked(string szvFullFileName,
                             ref bool brFileIsLocked)
    {
                                        bool bFileIsLocked = false;

        try
        {
            File.OpenWrite(szvFullFileName);
            bFileIsLocked = false;
        }
        catch
        {
            bFileIsLocked = true;
        }
        brFileIsLocked = bFileIsLocked;
    }

    public void FileExists(string szvFileName,
                           ref bool brFileExists) 
    {
        XX_FileExists(szvFileName,
                      ref brFileExists);
    }

    private void XX_FileExists(string szvFileName,  
                               ref bool brFileExists) { 

                                        bool bFileExists = false;

        bFileExists = File.Exists(szvFileName);
        brFileExists = bFileExists;
    }

    private void XX_GetSections() {

                                            Dictionary<string, string> dcSections = new Dictionary<string, string>();
                                            string szLine = string.Empty;
                                            bool bLineIsSectionHeader = false;
                                            bool bSectionHeaderFound = false;
                                            string szSection = string.Empty;
                                            Section s = new Section();
                                            SectionLine sl = null;
                                            string szKey = string.Empty;
                                            string szValue = string.Empty;

        szLine = srx.ReadLine();
        while(!srx.EndOfStream){
            if (szLine.Trim() == "") {
                bSectionHeaderFound = false;
            }

            if (bSectionHeaderFound) {
                XX_SplitSectionLines(szLine,
                                     ref szKey,
                                     ref szValue);

                s.SectionLines.AddSectionLine(szKey,
                                              ref sl);
                sl.Value = szValue;
            }

            XX_LineIsSectionHeader(szLine,
                                   ref bLineIsSectionHeader);

            if (bLineIsSectionHeader) {
                bSectionHeaderFound = true;
                XX_GetSectionOverLine(szLine,
                                      ref szSection);

                ssx.AddSection(szSection,
                               ref s);
            }

            szLine = srx.ReadLine();
        }

    }

    private void XX_LineIsSectionHeader(string szvLine,
                                        ref bool brLineIsSectionHeader) { 
    
                                        bool bLineIsSectionHeader = false;

        if(szvLine.StartsWith("[")){
            if (szvLine.EndsWith("]")) {
                bLineIsSectionHeader = true;
            }
        }

        brLineIsSectionHeader = bLineIsSectionHeader;
    }

    private void XX_GetSectionOverLine(string szvLine,
                                       ref string szrSection) { 
                        
                                        string szSection = string.Empty;
                                        int nLength = 0;

        szSection = szvLine.Remove(0, 1);
        nLength = szSection.Length;
        szSection = szSection.Remove(nLength - 1, 1);

        szrSection = szSection;
    
    }

    private void XX_SplitSectionLines(string szvLine,
                                      ref string szrKey,
                                      ref string szrValue) {

                                          string szKey = string.Empty;
                                          string szValue = string.Empty;

        szKey = szvLine.Split('=')[0];
        szValue = szvLine.Split('=')[1];
        utsx.SplitStringOnDelimiterOnFirstOccurrence(szvLine,
                                                     "=",
                                                     ref szKey,
                                                     ref szValue);
        szrKey = szKey;
        szrValue = szValue;
    }

    public bool KeyExists(string szvSection,
                          string szvKey) 
    {
        return ssx.ItemIsSection(szvSection).SectionLines.KeyExist(szvKey);
    }

    public void GetValue(string szvSection,
                         string szvKey,
                         ref string szrValue,
                         ref bool brValueNotFound)
    { 
    
                                            bool bKeyExists = false;
                                            bool bValueNotFound = false;
                                            string szValue = string.Empty;

        bKeyExists = ssx.KeyExist(szvSection);

        if (bKeyExists) 
        {
            bKeyExists = ssx.ItemIsSection(szvSection).SectionLines.KeyExist(szvKey);
            bValueNotFound = true;
            if (bKeyExists) {
                szValue = ssx.ItemIsSection(szvSection).SectionLines.ItemIsSectionLine(szvKey).Value;
                bValueNotFound = szValue.Trim() == string.Empty;
            }
        }

        brValueNotFound = bValueNotFound;
        szrValue = szValue;
    }


}
}
