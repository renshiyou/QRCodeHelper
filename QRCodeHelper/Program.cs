using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            using (QRCodeGenerator qrCodeGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode("1234567", QRCodeGenerator.ECCLevel.Q))
                {
                    using (QRCodeHelper qrCodeHelper = new QRCodeHelper(qrCodeData))
                    {
                        Bitmap barCode = qrCodeHelper.GetGraphic(5);
                        barCode.Save("D:\\barCode.jpg");
                    }
                }
            }
        }
    }
}
