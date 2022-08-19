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
            ImageConverter converter = new ImageConverter();

            Image image = Image.FromStream(imagemCarregada.OpenReadStream(), false, false);

            MemoryStream ms = new MemoryStream();

            if (image.Width > image.Height)
            {
                int width = 1920;
                int height = 1080;
                var newImage = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, width, height);
                    newImage.Save(ms, ImageFormat.Jpeg);
                }
            }
            else
            {
                int width = 1200;
                int height = 1200;
                var newImage = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, width, height);
                    newImage.Save(ms, ImageFormat.Jpeg);
                }
            }
            return ms;
        }
        //public static MemoryStream TesteResizeImage(IFormFile imagemCarregada)
        //{
        //    Image image = Image.FromStream(imagemCarregada.OpenReadStream(), true, true);

        //    MemoryStream ms = new MemoryStream();

        //    if (image.Width > image.Height)
        //    {
        //        int width = 1920;
        //        int height = 1080;
        //        var newImage = new Bitmap(width, height);
        //        using (Graphics g = Graphics.FromImage(newImage))
        //        {
        //            g.DrawImage(newImage, 0, 0, width, height);
        //            newImage.Save(ms, ImageFormat.Jpeg);
        //        }
        //    }
        //    else
        //    {
        //        int width = 900;
        //        int height = 2000;

        //        float y = (image.Height - image.Width) / 2.0F;
        //        var retanguloCorte = new Rectangle(0, (int)y, image.Width, image.Width);

        //        GraphicsUnit units = GraphicsUnit.Pixel;
        //        using (Graphics g = Graphics.FromImage(image))
        //        {
        //            g.DrawImage(image, width, height, retanguloCorte, units);
        //            image.Save(ms, ImageFormat.Jpeg);
        //        }
        //    }
        //    return ms;
        //}
    }
}
