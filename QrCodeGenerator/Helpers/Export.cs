using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QrCodeGenerator.Helpers
{
    public class Export
    {
     

        public static void PNG(BitmapImage imgQr)
        {
            string path = Guid.NewGuid().ToString() + ".png";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                path = fileName;
            }

            using (FileStream fileStream = new FileStream(path+".png",FileMode.Create))
            {
                PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                pngBitmapEncoder.Frames.Add(BitmapFrame.Create(imgQr));
                pngBitmapEncoder.Save(fileStream);
                fileStream.Close();
            }
        }
    }
}
