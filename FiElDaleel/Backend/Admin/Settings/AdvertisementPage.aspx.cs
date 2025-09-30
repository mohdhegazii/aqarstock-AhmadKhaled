using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using System.IO;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin.Settings
{
    public partial class AdvertisementPage : System.Web.UI.Page,IAdvertisment
    {
        AdvertisementController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdvertisementController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvTypes.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvTypes.DataKeys[item.RowIndex].Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public int AdvertisementID
        {
            get
            {
                if (ViewState["AdvertisementID"] != null)
                {
                    return (int)ViewState["AdvertisementID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["AdvertisementID"] = value;
            }
        }

        public void BindList(List<BrokerDLL.Advertisement> Ads)
        {
            gvTypes.DataSource = Ads;
            gvTypes.DataBind();
        }

        public BrokerDLL.Advertisement FillObject(BrokerDLL.Advertisement Ad, string random)
        {
            Ad.Name = txtTitle.Text;
            Ad.URL = txtURL.Text;
            if (ruContentSide.UploadedFiles.Count > 0)
            {
                Ad.ContentSide = "~/Resources/Ads/" + Ad.Code + "/" + random+"_ContentSide" + ruContentSide.UploadedFiles[0].GetExtension();
                imgContentSide.ImageUrl = Ad.ContentSide;
            }
            if (ruHomePageSide.UploadedFiles.Count > 0)
            {
                Ad.HomePageSide = "~/Resources/Ads/" + Ad.Code + "/" + random + "_HomePageSide" + ruHomePageSide.UploadedFiles[0].GetExtension();
                imgContentSide.ImageUrl = Ad.HomePageSide;
            }
            if (ruHomePageMainLarge.UploadedFiles.Count > 0)
            {
                Ad.HomePageMainLarge = "~/Resources/Ads/" + Ad.Code + "/" + random + "_HomePageMainLarge" + ruHomePageMainLarge.UploadedFiles[0].GetExtension();
                imgContentSide.ImageUrl = Ad.HomePageMainLarge;
            }
            if (ruHomePageMainSmall.UploadedFiles.Count > 0)
            {
                Ad.HomePageMainSmall = "~/Resources/Ads/" + Ad.Code + "/" + random + "_HomePageMainSmall" + ruHomePageMainSmall.UploadedFiles[0].GetExtension();
                imgContentSide.ImageUrl = Ad.HomePageMainSmall;
            }
            return Ad;
        }


        public void FillControls(BrokerDLL.Advertisement Ad)
        {
            txtTitle.Text = Ad.Name;
            txtURL.Text = Ad.URL;
            imgContentSide.ImageUrl = Ad.ContentSide;
            imgHomePageMainLarge.ImageUrl = Ad.HomePageMainLarge;
            imgHomePageMainSmall.ImageUrl = Ad.HomePageMainSmall;
            imgHomePageSide.ImageUrl = Ad.HomePageSide;

        }

        public void UpLaod(string Code, string random)
        {
            if (ruContentSide.UploadedFiles.Count > 0)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\"  + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/Ads/")  + "\\" + Code + "\\";
                    path += random + "_ContentSide" + ruContentSide.UploadedFiles[0].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    //ruPhoto.UploadedFiles[0].
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ruContentSide.UploadedFiles[0].InputStream);
                    ImageCompress.ApplyCompressionAndSave(img, path, 30, ruContentSide.UploadedFiles[0].ContentType);
            }
            if (ruHomePageMainLarge.UploadedFiles.Count > 0)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code);
                }
                string path = HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code + "\\";
                path += random + "_HomePageMainLarge" + ruHomePageMainLarge.UploadedFiles[0].GetExtension();
                //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                //ruPhoto.UploadedFiles[0].
                System.Drawing.Image img = System.Drawing.Image.FromStream(ruHomePageMainLarge.UploadedFiles[0].InputStream);
                ImageCompress.ApplyCompressionAndSave(img, path, 30, ruHomePageMainLarge.UploadedFiles[0].ContentType);
            }
            if (ruHomePageMainSmall.UploadedFiles.Count > 0)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code);
                }
                string path = HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code + "\\";
                path += random + "_HomePageMainSmall" + ruHomePageMainSmall.UploadedFiles[0].GetExtension();
                //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                //ruPhoto.UploadedFiles[0].
                System.Drawing.Image img = System.Drawing.Image.FromStream(ruHomePageMainSmall.UploadedFiles[0].InputStream);
                ImageCompress.ApplyCompressionAndSave(img, path, 30, ruHomePageMainSmall.UploadedFiles[0].ContentType);
            }
            if (ruHomePageSide.UploadedFiles.Count > 0)
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code);
                }
                string path = HttpContext.Current.Server.MapPath("~/Resources/Ads/") + "\\" + Code + "\\";
                path += random + "_HomePageSide" + ruHomePageSide.UploadedFiles[0].GetExtension();
                //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                //ruPhoto.UploadedFiles[0].
               // ruHomePageSide.UploadedFiles[0].SaveAs(path);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ruHomePageSide.UploadedFiles[0].InputStream);
                ImageCompress.ApplyCompressionAndSave(img, path, 30, ruHomePageSide.UploadedFiles[0].ContentType);
            }
        }

        public BrokerDLL.PageMode Mode
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

        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg.GetValue();
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }

        public void Navigate()
        {
            if (Mode == PageMode.Add)
            {
                txtURL.Text = "";
                txtTitle.Text = "";
                ruContentSide.UploadedFiles.Clear();
                ruHomePageMainLarge.UploadedFiles.Clear();
                ruHomePageMainSmall.UploadedFiles.Clear();
                ruHomePageSide.UploadedFiles.Clear();
                divcontentSide.Visible = false;
                divHomePageMainLarge.Visible = false;
                divHomePageMainSmall.Visible = false;
                divHomePageSide.Visible = false;
            }
            if (Mode == PageMode.Edit)
            {
                divcontentSide.Visible = true;
                divHomePageMainLarge.Visible = true;
                divHomePageMainSmall.Visible = true;
                divHomePageSide.Visible = true;
            }
        }
    }
}