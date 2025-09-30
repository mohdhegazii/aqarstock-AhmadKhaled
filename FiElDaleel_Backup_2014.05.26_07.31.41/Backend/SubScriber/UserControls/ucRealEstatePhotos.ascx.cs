using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using BrokerDLL;
using System.IO;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucRealEstatePhotos : System.Web.UI.UserControl, IRealEstatePhotos
    {
        RealEstatePhotoController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstatePhotoController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            ListViewDataItem item = (ListViewDataItem)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(lvPhotos.DataKeys[item.DisplayIndex].Value));
        }

        protected void imgSetDefault_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            ListViewDataItem item = (ListViewDataItem)ibtn.NamingContainer;
            Controller.OnSetDefault(Convert.ToInt32(lvPhotos.DataKeys[item.DisplayIndex].Value));
        }


        public int RealEstateID
        {
            get
            {
                if (ViewState["RealEstateID"] != null)
                {
                    return (int)ViewState["RealEstateID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["RealEstateID"] = value;
            }
        }

        public PageMode Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                {
                    return (PageMode)ViewState["Mode"];
                }
                else
                {
                    return PageMode.Add;
                }
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        public void BindPhotoList(List<BrokerDLL.RealEstatePhoto> Photos)
        {
            lvPhotos.DataSource = Photos;
            lvPhotos.DataBind();
        }

        public BrokerDLL.RealEstatePhoto FillRealEstatePhotoObject()
        {
            RealEstatePhoto Photo = new RealEstatePhoto();
            Photo.IsDefault = chkIsDefault.Checked;
            Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                    + DateTime.Today.Day + "/" + RealEstateID + "/" + ruPhoto.UploadedFiles[0].FileName;
            return Photo;
        }

        public void UploadRealEstatePhoto()
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year);
                }
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                }
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                }
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + RealEstateID))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + RealEstateID);
                }
                string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + RealEstateID + "\\";
                ruPhoto.UploadedFiles[0].SaveAs(path + ruPhoto.UploadedFiles[0].FileName);

            }
        }


        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg.GetValue();
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

        public void Navigate()
        {
            ruPhoto.UploadedFiles.Clear();
            chkIsDefault.Checked = false;
        }

     
        public string CheckDefault(object DefaultStatus)
        {
            string text = "";
            if ((bool)DefaultStatus)
            {
                text = "الصورة الرئيسية";
            }
            return text;
        }

    }
}