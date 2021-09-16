using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities
{
public class FormUtilities
{
    private FormItems fisx = null;
    private Utilities utsx = null;

    public FormUtilities()
    {
        utsx = new Utilities();
        fisx = new FormItems();
    }

    public void AddFormItem(Form fv,
                            EnumsCollection.EnumFormType eftv)
    { 
                                        string szKey = string.Empty;
                                        string szNewFormName = string.Empty;
                                        FormItem fItem = null;
                                        string szFormName = string.Empty;
                                        string szFormCount = string.Empty;
                                        long lCount = 0;
                                        long lHighestCount = 0;
                                        string szHighestCount = string.Empty;
                                        bool bFormGroupTypeFound = false;

        while (true)
        {
            if (fisx.FormItemCount == 0)
            {
                szKey = "X_"
                      + Convert.ToString(fisx.FormItemCount);

                szNewFormName = fv.Name + "_01";
                fisx.AddFormItem(szKey,
                                 ref fItem);
                fItem.FormName = szNewFormName;
                fItem.GroupFormName = fv.Name;
                fItem.EnumFormType = eftv;
                break;
            }

            foreach (FormItem fi in fisx)
            {
                if (fi.GroupFormName == fv.Name)
                {
                    bFormGroupTypeFound = true;
                    utsx.SplitStringOnDelimiter(fi.FormName,
                                                "_",
                                                ref szFormName,
                                                ref szFormCount);

                    lCount = Convert.ToInt64(szFormCount);

                    if (lCount > lHighestCount)
                    {
                        lHighestCount = lCount;
                    }
                }
            }

            if (!bFormGroupTypeFound)
            {
                szKey = "X_"
                      + Convert.ToString(fisx.FormItemCount);

                szNewFormName = fv.Name + "_01";
                fisx.AddFormItem(szKey,
                                 ref fItem);
                fItem.FormName = szNewFormName;
                fItem.GroupFormName = fv.Name;
                fItem.EnumFormType = eftv;
                break;
            }

            szHighestCount = Convert.ToString(lHighestCount + 1);

            if (szHighestCount.Length == 1)
            {
                szHighestCount = "0"
                               + szHighestCount;
            }

            szNewFormName = fv.Name
                          + "_"
                          + szHighestCount;

            szKey = "X_"
                  + Convert.ToString(fisx.FormItemCount);

            fisx.AddFormItem(szKey,
                             ref fItem);
            fItem.FormName = szNewFormName;
            fItem.GroupFormName = fv.Name;
            fItem.EnumFormType = eftv;

            break;
        }

        fv.Name = szNewFormName;
    }

    public void DrawGroupBox(GroupBox box,
                             Graphics g,
                             Color textColor,
                             Color borderColor,
                             Color backcolor)
    {
        if (box != null)
        {
            Brush textBrush = new SolidBrush(textColor);
            Brush borderBrush = new SolidBrush(borderColor);
            Pen borderPen = new Pen(borderBrush);
            SizeF strSize = g.MeasureString(box.Text, box.Font);
            Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                           box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                           box.ClientRectangle.Width - 1,
                                           box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

            // Clear text and border
            g.Clear(backcolor);

            // Draw text
            g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

            // Drawing Border
            //Left
            g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
            //Right
            g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            //Bottom
            g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            //Top1
            g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
            //Top2
            g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
        }
    }

    public void RemoveFormItem(Form fv)
    {
        fisx.RemoveFormItem(fv.Name);
    }

}
}
