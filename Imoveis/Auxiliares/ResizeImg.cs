using Imoveis.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Imoveis.Auxiliares
{
    public class ResizeImg
    {
        public static MemoryStream ResizeImage(IFormFile imagemCarregada)
        {
            int width = 1920;
            int height = 1080;
            Image image = Image.FromStream(imagemCarregada.OpenReadStream(), true, true);
            var newImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                MemoryStream ms = new MemoryStream();
                g.DrawImage(image, 0, 0, width, height);
                newImage.Save(ms, ImageFormat.Jpeg);
                return ms;
            }
        }
    }
}
