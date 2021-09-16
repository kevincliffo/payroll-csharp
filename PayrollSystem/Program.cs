using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PayRollSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                                        bool bConnectionFileExists = false;

            while(true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                XX_CheckIfConnectionFileExists(ref bConnectionFileExists);

                switch (bConnectionFileExists)
                {
                    case true:
                        //Application.Run(new F_Login());
                        Application.Run(new F_Main());
                        break;

                    case false:
                        Application.Run(new F_InitializeSystem());
                        break;
                }

                break;
            }
        }

        private static void XX_CheckIfConnectionFileExists(ref bool brConnectionFileExists)
        {
                                        string szConnectionFileFileName = string.Empty;
                                        bool bConnectionFileExists = false;
            
            szConnectionFileFileName = Application.StartupPath
                                     + "\\Connection.info";

            bConnectionFileExists = System.IO.File.Exists(szConnectionFileFileName);

            brConnectionFileExists = bConnectionFileExists;
        }
    }
}
