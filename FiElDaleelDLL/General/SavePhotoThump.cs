using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;

namespace BrokerDLL
{
   public static class SavePhotoThump
    {
       public static void SaveThumb(string ImageURL, string ThumbURL, int Percent)
       {
           System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(ImageURL);
           System.Drawing.Image LargeImage = ScaleByPercent(OriginalImage, Percent);
          // string TumbName = Path + Thumb + System.IO.Path.GetExtension(FileName);
           LargeImage.Save(ThumbURL);
       }
       public static void SaveThumb(System.Drawing.Image OriginalImage, string ThumbURL, int Percent)
       {
          // System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(ImageURL);
           System.Drawing.Image LargeImage = ScaleByPercent(OriginalImage, Percent);
           // string TumbName = Path + Thumb + System.IO.Path.GetExtension(FileName);
           LargeImage.Save(ThumbURL);
       }
       public static void SaveThumb(System.Drawing.Image OriginalImage, string ThumbURL, int width, int height)
       {
         //  System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(ImageURL);
           System.Drawing.Image LargeImage = ScaleByPercent(OriginalImage, width, height);
           // string TumbName = Path + Thumb + System.IO.Path.GetExtension(FileName);
           LargeImage.Save(ThumbURL);
       }
       public static void SaveThumb(string ImageURL, string ThumbURL, int width,int height)
       {
           System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(ImageURL);
           System.Drawing.Image LargeImage = ScaleByPercent(OriginalImage, width,height);
           // string TumbName = Path + Thumb + System.IO.Path.GetExtension(FileName);
           LargeImage.Save(ThumbURL);
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

           Graphics grPhoto = Graphics.FromImage(bmPhoto);
           grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

           grPhoto.DrawImage(imgPhoto,
               new Rectangle(destX, destY, destWidth, destHeight),
               new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
               GraphicsUnit.Pixel);

           grPhoto.Dispose();
           return bmPhoto;
       }
       private static System.Drawing.Image ScaleByPercent(System.Drawing.Image imgPhoto, int width, int height)
       {
         //  float nPercent = ((float)Percent / 100);

           int sourceWidth = imgPhoto.Width;
           int sourceHeight = imgPhoto.Height;
           int sourceX = 0;
           int sourceY = 0;

           int destX = 0;
           int destY = 0;
           int destWidth = width;
           int destHeight = height;

           Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                    PixelFormat.Format24bppRgb);
           bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                   imgPhoto.VerticalResolution);

           Graphics grPhoto = Graphics.FromImage(bmPhoto);
           grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

           grPhoto.DrawImage(imgPhoto,
               new Rectangle(destX, destY, destWidth, destHeight),
               new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
               GraphicsUnit.Pixel);

           grPhoto.Dispose();
           return bmPhoto;
       }
    }
}
