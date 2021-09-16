using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace Utilities
{
public class StatusBarHandler
{
    private ToolStripStatusLabel tsslx = null;
    private System.Timers.Timer tmx = null;

    public StatusBarHandler(ToolStripStatusLabel tsslv) 
    {
        tsslx = tsslv;
    
    }

    public void ShowStatusBarMessage(string szvMessage,
                                     EnumsCollection.EnumMessageType emtv) 
    {

                                        Color clrForeColor = new Color();

        switch (emtv)
        {
            case EnumsCollection.EnumMessageType.emtError:
                clrForeColor = Color.Red;
                break;

            case EnumsCollection.EnumMessageType.emtInformation:
                clrForeColor = Color.Green;
                break;

            case EnumsCollection.EnumMessageType.emtSuccess:
                clrForeColor = Color.Blue;
                break;

        }

        tsslx.ForeColor = clrForeColor;
        tsslx.Text = szvMessage;
        tmx = new System.Timers.Timer(5000);
        tmx.Enabled = true;
        tmx.Elapsed += new ElapsedEventHandler(tmx_Elapsed);
    }

    void tmx_Elapsed(object sender, ElapsedEventArgs e)
    {
        try
        {
            tsslx.Text = "";
        }
        catch { }

        if (tmx != null)
        {
            tmx.Stop();
            tmx.Elapsed -= new ElapsedEventHandler(tmx_Elapsed);
            tmx = null;
        }
    }

}
}
