using QrCodeGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace QrCodeGenerator.Models
{
    public  class MainModel
    {
        public MainModel()
        {
            
        }
        public BitmapImage DoQr(string code)
        {
            return Qr.Generator(code);
        }
        public void ExportFile(BitmapImage imgQr)
        {
            Export.PNG(imgQr);
        }

    }
}
