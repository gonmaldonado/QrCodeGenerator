using MessagingToolkit.QRCode.Codec;
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
    public class Qr
    {
        public static BitmapImage Generator(string code)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(code);
            BitmapImage bitmapimage = new BitmapImage();
            System.Drawing.Image QR = (System.Drawing.Image)img;
            var bitmapImage = new Bitmap(img);

            using (MemoryStream memory = new MemoryStream())
            {
                QR.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                
            }
            return bitmapimage;



        }
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
