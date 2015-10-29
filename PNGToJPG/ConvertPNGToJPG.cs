using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNGToJPG
{
    public class ConvertPNGToJPG
    {

        public static void ConvertDir(string directory)
        {
            string[] files = Directory.GetFiles(directory, "*.png");
            foreach (string file in files)
            {
                ConvertFile(file);
            }
        }

        public static void ConvertFile(string file)
        {
            string f = file.Replace(".png", ".jpg");
            ConvertImage(file, f);
        }


        private static void ConvertImage(string filename, string newFile)
        {
            using (Image myImage = Image.FromFile(filename))
            {
                using (var b = new Bitmap(myImage.Width, myImage.Height))
                {
                    b.SetResolution(myImage.HorizontalResolution, myImage.VerticalResolution);

                    using (var g = Graphics.FromImage(b))
                    {
                        g.Clear(Color.White);
                        g.DrawImageUnscaled(myImage, 0, 0);
                    }

                    try
                    {
                        b.Save(newFile, ImageFormat.Jpeg);
                    }
                    catch (Exception)
                    {
                        //want it to die silently if it fails to convert.
                    }
                    
                }
            }
        }
    }
}
