using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace SplitImageSeries
{
    class ConvertImageByteArray
    {
        public static Image ByteArrayToImage(byte[] imageArray)
        {
            MemoryStream ms = new MemoryStream(imageArray);
            Image image = Image.FromStream(ms);
            ms = null;
            return image;
        }

        public static byte[] ImageToByteArray(string imageFilePath)
        {
            byte[] imageArray = File.ReadAllBytes(imageFilePath);
            return imageArray;
        }
    }
}
