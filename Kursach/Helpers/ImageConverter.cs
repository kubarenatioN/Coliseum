using System;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kursach
{
    public static class ImageConverter
    {
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(imageIn);
                imageIn.Save(ms, bmp.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        /// <summary>
        /// Converts from byte[] to ImageSource
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static ImageSource ImageSourceFromByteArray(byte[] byteArray)
        {
            BitmapFrame bitmapFrame;
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                bitmapFrame = BitmapFrame.Create(stream,
                                                  BitmapCreateOptions.None,
                                                  BitmapCacheOption.OnLoad);
            }
            return bitmapFrame;
        }


        /// <summary>
        /// Converts image by Uri to byte[]
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static byte[] ConvertBitmapSourceToByteArray(Uri uri)
        {
            var image = new BitmapImage(uri);
            byte[] data;
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }


        /// <summary>
        /// Works too, but creates black background | I DO NOT USE IT YET
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
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
