using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utilities
{
    public class ImageUtilities
    {
        public ImageUtilities()
        { 
        
        }

        public Bitmap CropBitmap(Bitmap bvBitmap, 
                                 int nCropX, 
                                 int nCropY, 
                                 int nCropWidth, 
                                 int nCropHeight)
        {
                                        Rectangle rect = new Rectangle(nCropX, nCropY, nCropWidth, nCropHeight);

            Bitmap bBitmap = new Bitmap(nCropWidth, nCropHeight);
            Graphics gGraphics = Graphics.FromImage(bBitmap);
            gGraphics.DrawImage(bvBitmap, new Rectangle(0, 0, nCropWidth, nCropHeight), nCropX, nCropY, nCropWidth, nCropHeight, GraphicsUnit.Pixel);
            gGraphics.Dispose();

            return bBitmap;

        }


    }

}
