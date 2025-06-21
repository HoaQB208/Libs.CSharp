using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Libs.CSharp
{
    public class ImageUtils
    {
        public static void SaveImageToFile(BitmapSource image, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(fileStream);
            }
        }

        public static BitmapImage GetBitmapImage(string filePath, int? width = null, int? height = null)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                if (width.HasValue) bitmapImage.DecodePixelWidth = width.Value;
                if (height.HasValue) bitmapImage.DecodePixelHeight = height.Value;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }

        public static BitmapImage ToBitmapImage(byte[] array)
        {
            if (array == null || array.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(array))
            {
                ms.Position = 0;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }

        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }

        public static byte[] ToBytes(BitmapImage imageSource)
        {
            byte[] buffer = null;
            if (imageSource != null)
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                if (encoder != null)
                {
                    encoder.Frames.Add(BitmapFrame.Create(imageSource));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        buffer = ms.ToArray();
                    }
                }
            }
            return buffer;
        }
    }
}
