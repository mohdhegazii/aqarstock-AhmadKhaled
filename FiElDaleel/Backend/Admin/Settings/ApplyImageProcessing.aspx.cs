using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL;
using System.Drawing.Imaging;

namespace BrokerWeb.Backend.Admin.Settings
{
    public partial class ApplyImageProcessing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProjects_Click(object sender, EventArgs e)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                foreach (RealEstateProjectPhoto ProjectPhoto in Context.RealEstateProjectPhotos)
                { 
                    System.Drawing.Image img = System.Drawing.Image.FromFile(ProjectPhoto.PhotoURL);
                    if (img.Width > 1200)
                    {
                        string MimeType = GetMimeType(img.RawFormat.Guid);
                        ImageCompress.ApplyCompressionAndSave(img, ProjectPhoto.PhotoURL, 70, MimeType);
                    }
                }
            }
        }

        protected void btnRealestates_Click(object sender, EventArgs e)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                foreach (RealEstatePhoto Photo in Context.RealEstatePhotos)
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(Photo.PhotoName);
                    if (img.Width > 1200)
                    {
                        string MimeType = GetMimeType(img.RawFormat.Guid);
                        ImageCompress.ApplyCompressionAndSave(img, Photo.PhotoName, 70, MimeType);
                    }
                }
            }
        }

        private string GetMimeType(Guid guid)
        {
            string mimeType="unknown";
            if (guid == ImageFormat.Png.Guid)
            {
                mimeType = "image/png";
            }
            else if (guid == ImageFormat.Bmp.Guid)
            {
                mimeType = "image/bmp";
            }
            else if (guid == ImageFormat.Emf.Guid)
            {
                mimeType = "image/x-emf";
            }
            else if (guid == ImageFormat.Exif.Guid)
            {
                mimeType = "image/jpeg";
            }
            else if (guid == ImageFormat.Gif.Guid)
            {
                mimeType = "image/gif";
            }
            else if (guid == ImageFormat.Icon.Guid)
            {
                mimeType = "image/ico";
            }
            else if (guid == ImageFormat.Jpeg.Guid)
            {
                mimeType = "image/jpeg";
            }
            else if (guid == ImageFormat.MemoryBmp.Guid)
            {
                mimeType = "image/bmp";
            }
            else if (guid == ImageFormat.Tiff.Guid)
            {
                mimeType = "image/tiff";
            }
            else if (guid == ImageFormat.Wmf.Guid)
            {
                mimeType = "image/wmf";
            }
            return mimeType;
        }

    }
}