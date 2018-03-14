using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace SplitImageSeries
{
    class SplitMerge
    {
        public static Bitmap Split(byte[] bytes, int count)
        {
            Bitmap bmp = new Bitmap(ConvertImageByteArray.ByteArrayToImage(bytes));
            Bitmap cloneBmp = new Bitmap(1, bmp.Height);
            Graphics gr = Graphics.FromImage(cloneBmp);
            gr.DrawImage(bmp,
                        new Rectangle(0, 0, 1, bmp.Height),
                        new Rectangle(count, 0, count + 1, bmp.Height),
                        GraphicsUnit.Pixel);
            bmp.Dispose();
            gr.Dispose();
            return cloneBmp;
        }

        public static Bitmap Merge(List<Bitmap> bmpArray,Image img)
        {
            Bitmap _finalBmp = null;
            try
            {
                Bitmap a = new Bitmap(img);
                Graphics g = Graphics.FromImage(a);
                g.Clear(Color.Empty);
                _finalBmp = new Bitmap(a);
                using (Graphics gr = Graphics.FromImage(_finalBmp))
                {
                    int offset = 0;
                    foreach (Bitmap bmp in bmpArray)
                    {
                        gr.DrawImage(bmp,
                            new Rectangle(offset, 0, bmp.Width, bmp.Height));
                        offset += bmp.Width;
                    }
                }
                return _finalBmp;
            }
            catch (Exception e)
            {
                if (_finalBmp != null)
                    _finalBmp.Dispose();
                throw e;
            }
            finally
            {
                foreach (Bitmap bmp in bmpArray)
                {
                    bmp.Dispose();
                }
            }
        }
    }
}
