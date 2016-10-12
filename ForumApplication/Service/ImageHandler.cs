using System.Drawing;
using System.IO;
using System.Web;

namespace ForumApplication.Service
{
    public class ImageHandler
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] GetImageByteArray(HttpPostedFileBase file)
        {
            if (file != null)
            {
                MemoryStream target = new MemoryStream();
                file.InputStream.CopyTo(target);
                return target.ToArray();
            }

            Image avatar = new Bitmap(HttpContext.Current.Server.MapPath("~/Content/img/avatar.png"));
            return ImageToByteArray(avatar);
        }
    }
}