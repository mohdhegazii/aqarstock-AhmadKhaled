using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace BrokerMVC
{
   public enum ImageTypes
    {
        Icon,
        Logo,
        Image,
        AdContnetSide,
        AdHomePageMainLarge,
        AdHomePageMainSmall,
        AdHomePageSide
    }
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
    }
    public static class ImageHelper
    {
        public static string[] imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
        public static System.Drawing.Image ConvertToImage(HttpPostedFileBase ImgFile)
        {
            var bytes = new byte[ImgFile.InputStream.Length];
            ImgFile.InputStream.Read(bytes, 0, bytes.Length);
            ImgFile.InputStream.Position = 0;
            // ImgFile.InputStream.CopyToAsync(ms);
            System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(bytes));
            return img;
        }
        public static ValidationResult ValidateImage(HttpPostedFileBase ImgFile,ImageTypes Type)
        {
            ValidationResult result = new ValidationResult();
            result.IsValid = true;
            
            if (ImgFile.ContentLength == 0)
            {
                //ModelState.AddModelError("LogoUpload", Messages.IconRequired);
                result.IsValid = false;
                result.Message = Messages.PhotoRequired;
                return result;
            }
            if (!ImageHelper.ValidateExtension(ImgFile.ContentType))
            {
                result.IsValid = false;
                result.Message = Messages.ValidImage;
                return result;
            }
            if(ImgFile.ContentLength> 1000000)
            {
                result.IsValid = false;
                result.Message = Messages.ValidImageSize;
                return result;
            }
            var bytes = new byte[ImgFile.InputStream.Length];
            ImgFile.InputStream.Read(bytes, 0, bytes.Length);
            ImgFile.InputStream.Position = 0;
            // ImgFile.InputStream.CopyToAsync(ms);
            System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                if (!ImageHelper.CheckHight(img.Height, Type) || !ImageHelper.CheckWidth(img.Width, Type))
                {
                    result.Message = Messages.ValidImageDimension;
                    result.IsValid = false;
                    return result;
                }
            return result;
        }
        public static ValidationResult ValidateImages(IEnumerable<HttpPostedFileBase> files, ImageTypes Type)
        {
            ValidationResult result;
            foreach (HttpPostedFileBase file in files)
            {
                result = ValidateImage(file,Type);
                if (!result.IsValid)
                {
                    return result;
                }
            }
            result = new ValidationResult();
            result.IsValid = true;
            return result;
        }
        public static bool ValidateExtension(string imagecontenttype)
        {
            return imageTypes.Contains(imagecontenttype);
        }
        public static bool CheckHight(int height,ImageTypes type)
        {
            
            switch(type)
            {
                case (ImageTypes.Icon):
                    if (height == 32)
                        return true;
                    else
                        return false;
                default:
                    return true;
            }
        }
        public static bool CheckWidth(int width, ImageTypes type)
        {

            switch (type)
            {
              
                case (ImageTypes.Icon):
                    if (width == 32)
                        return true;
                    else
                        return false;
                default:
                    return true;
            }
        }
        public static bool ValidateExtension(IEnumerable<HttpPostedFileBase> files)
        {
            foreach(HttpPostedFileBase file in files)
            {
                if(!ValidateExtension(file.ContentType))
                {
                    return false;
                }
            }
            return true;
        }
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
            img = ScaleByPercent(img);
            ApplyCompressionAndSave(img, file, compressionValue, mimeType);
        }
        public static System.Drawing.Image ApplyCompression(Image img, long compressionValue, string mimeType, bool IsThumb, int Width, int Height)
        {
            img = ScaleByPercent(img, Width, Height);
            return  ApplyCompression(img, compressionValue, mimeType);
        }
        public static void ApplyCompressionAndSave(Image img, string file, long compressionValue, string mimeType, bool IsThumb, int Percent)
        {
            img = ScaleByPercent(img, Percent);
            ApplyCompressionAndSave(img, file, compressionValue, mimeType);
        }
        public static void ApplyCompressionAndSave(Image img, string file, long compressionValue, string mimeType, bool IsThumb, int Width, int Height)
        {
            img = ScaleByPercent(img, Width, Height);
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
                if (img.Width > 1289)
                {
                    double ratio = Convert.ToDouble(img.Width) / 1289;
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
        public static void ApplyCompressionAndSave(HttpPostedFileBase ImgFile, string file, long compressionValue, string mimeType)
        {
            try
            {
                //create our EncoderParameters object and pass the values to the EncoderParameter class

                //  System.Drawing.Image img = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImgFile.InputStream,true,true);
                EncoderParameters parameters = new EncoderParameters(1);
                    parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compressionValue);
                    ImageCodecInfo codec = GetEncoderInfo(mimeType);
                    if (img.Width > 1289)
                    {
                        double ratio = Convert.ToDouble(img.Width) / 1289;
                        int height = Convert.ToInt32(Math.Round(img.Height / ratio));
                        img = ScaleByPercent(img, 1200, height);
                    }
                //now verify that the encoder returned from GetEncoderInfo isnt a null value
                if (codec != null)
                //an encoder was found so now we can save the image with the specified compression value
                {
                    img.Save(file, codec, parameters);

                }
                else
                    //no encoder was found so throw an exception
                    throw new Exception("Codec information not found for the mime type specified. Check your values and try again");
                //mss.Close();
                //fs.Close();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        public static System.Drawing.Image ApplyCompression(Image img, long compressionValue, string mimeType)
        {
            try
            {
                //create our EncoderParameters object and pass the values to the EncoderParameter class
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compressionValue);
                ImageCodecInfo codec = GetEncoderInfo(mimeType);
                if (img.Width > 1289)
                {
                    double ratio = Convert.ToDouble(img.Width) / 1289;
                    int height = Convert.ToInt32(Math.Round(img.Height / ratio));
                    img = ScaleByPercent(img, 1200, height);
                }
                //now verify that the encoder returned from GetEncoderInfo isnt a null value
                return img;
            }
            catch (Exception ex)
            {
                return img;
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
        private static System.Drawing.Image ScaleByPercent(System.Drawing.Image imgPhoto)
        {
            //   float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = 314; //(int)(sourceWidth * nPercent);
            int destHeight = 314;//(int)(sourceHeight * nPercent);

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
            //bmPhoto.
            //bmPhoto.imgQuality = CompositingQuality.HighQuality;
            //bmPhoto.SmoothingMode = SmoothingMode.HighQuality;
            //bmPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //grPhoto.CompositingMode = CompositingMode.SourceCopy;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;
            var attributes = new ImageAttributes();
            attributes.SetWrapMode(WrapMode.TileFlipXY);
            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),0,0,imgPhoto.Width,imgPhoto.Height,
                GraphicsUnit.Pixel,attributes);

            grPhoto.Dispose();
            return bmPhoto;
        }

    }
}