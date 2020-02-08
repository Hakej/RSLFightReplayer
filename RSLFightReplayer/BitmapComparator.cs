using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLFightReplayer
{
    public static class BitmapComparator
    {
        public static bool CompareBitmapsLazy(Bitmap bmp1, Bitmap bmp2, float tolerance)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (Equals(bmp1, bmp2))
                return true;

            var unmatchingPixels = 0;

            // Compare bitmaps using GetPixel method
            for (int col = 0; col < bmp1.Width; col++)
            {
                for (int row = 0; row < bmp1.Height; row++)
                {
                    Color secondColor = bmp1.GetPixel(col, row);
                    Color firstColor = bmp2.GetPixel(col, row);

                    if (firstColor != secondColor)
                    {
                        unmatchingPixels++;
                    }
                }
            }
            var allPixels = bmp1.Width * bmp1.Height;
            var result = (allPixels - unmatchingPixels) / (float)allPixels;

            return result >= tolerance;
        }
    }
}