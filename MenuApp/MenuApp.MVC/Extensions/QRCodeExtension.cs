using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApp.MVC.Extensions
{
    public class QRCodeExtension
    {
        public static byte[] CreatePngQR(string url,int size) 
        { 
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData pictureData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode picture = new PngByteQRCode(pictureData);
            byte[] bytePicture = picture.GetGraphic(size);
            return bytePicture;
        }
    }
}
