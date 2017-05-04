using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeHelper
{
    public class QRCodeHelper:IDisposable
    {
        public QRCodeData QrCodeData { get; set; }

        public QRCodeHelper(QRCodeData qrCodeData)
        {
            this.QrCodeData = qrCodeData;
        }

        public Bitmap GetGraphic(int pixelsPerModule, bool drawQuietZones = true)
        {
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new Bitmap(size, size);
            var gfx = Graphics.FromImage(bmp);
            for (var x = 0; x < size + offset; x = x + pixelsPerModule)
            {
                for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                {
                    var module = this.QrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1];
                    if (module)
                    {
                        gfx.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x - offset, y - offset, pixelsPerModule, pixelsPerModule));
                    }
                    else
                    {
                        gfx.FillRectangle(new SolidBrush(Color.White), new Rectangle(x - offset, y - offset, pixelsPerModule, pixelsPerModule));
                    }
                }
            }

            gfx.Save();
            return bmp;
        }

        public void Dispose()
        {
            this.QrCodeData = null;
        }
    }
}
