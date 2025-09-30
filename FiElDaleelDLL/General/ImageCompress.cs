using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BrokerDLL
{
   public static class ImageCompress
    {
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }
        public static void ApplyCompressionAndSave(Image img, string file, long compressionValue, string mimeType, bool IsThumb)
        {
            img = ScaleByPercent(img,50);
            ApplyCompressionAndSave(img, file, compressionValue, mimeType);
        }
        public static void ApplyCompressionAndSave(Image img, string file, long compressionValue, string mimeType)
        {
            try
            {
                //create our EncoderParameters object and pass the values to the EncoderParameter class
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compressionValue);
                ImageCodecInfo codec = GetEncoderInfo(mimeType);
                if (img.Width > 1200)
                {
                    double ratio = Convert.ToDouble(img.Width) / 1200;
                    int height = Convert.ToInt32(Math.Round(img.Height / ratio));
                    img = ScaleByPercent(img, 1200, height);
                }
                //now verify that the encoder returned from GetEncoderInfo isnt a null value
                if (codec != null)
                    //an encoder was found so now we can save the image with the specified compression value
                    img.Save(file, codec, parameters);
                else
                    //no encoder was found so throw an exception
                    throw new Exception("Codec information not found for the mime type specified. Check your values and try again");
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        private static System.Drawing.Image ScaleByPercent(System.Drawing.Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            //bmPhoto.imgQuality = CompositingQuality.HighQuality;
            //bmPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //bmPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        private static System.Drawing.Image ScaleByPercent(System.Drawing.Image imgPhoto, int width, int height)
        {
            //   float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = width; //(int)(sourceWidth * nPercent);
            int destHeight = height;//(int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            //bmPhoto.imgQuality = CompositingQuality.HighQuality;
            //bmPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //bmPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}
