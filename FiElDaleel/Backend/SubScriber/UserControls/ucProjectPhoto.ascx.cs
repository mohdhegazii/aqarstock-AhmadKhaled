using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using System.Text.RegularExpressions;
using System.IO;
using BrokerDLL;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucProjectPhoto : System.Web.UI.UserControl,IProjectPhoto
    {
        ProjectPhotoController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ProjectPhotoController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
                rdpDate.SelectedDate = DateTime.Now;
            }
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvPhotos.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvPhotos.DataKeys[item.RowIndex].Value));
        }

        protected void gvPhotos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPhotos.PageIndex = e.NewPageIndex;
            gvPhotos.DataSource = Controller.OnNeedDataSource();
            gvPhotos.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public int ProjectID
        {
            get
            {
                if (ViewState["ProjectID"] != null)
                {
                    return (int)ViewState["ProjectID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["ProjectID"] = value;
            }
        }

        public int PhotoID
        {
            get
            {
                if (ViewState["PhotoID"] != null)
                {
                    return (int)ViewState["PhotoID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["PhotoID"] = value;
            }
        }

        public void BindList(List<BrokerDLL.RealEstateProjectPhoto> Photos)
        {
            gvPhotos.DataSource = Photos;
            gvPhotos.DataBind();
        }

        public BrokerDLL.RealEstateProjectPhoto FillObject(BrokerDLL.RealEstateProjectPhoto Photo, string Code,string random)
        {
            Photo.Date = rdpDate.SelectedDate;
            Photo.Description = txtDescription.Text;
            Photo.IsDefault = chkIsDefault.Checked;
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                Photo.PhotoURL = "~/Resources/RealEstates/Projects/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/"
                        + DateTime.Now.Day + "/" + Code + "/" + random + ruPhoto.UploadedFiles[0].GetExtension();
                imgLogo.ImageUrl = Photo.PhotoURL;
            }
            return Photo;
        }
        

        public void FillControls(BrokerDLL.RealEstateProjectPhoto Photo)
        {
            imgLogo.ImageUrl = Photo.PhotoURL;
            chkIsDefault.Checked = Photo.IsDefault.Value;
            rdpDate.SelectedDate = Photo.Date;
            txtDescription.Text = Photo.Description;

        }

        public void UpLaod(string Code,string random)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code + "\\";
                    path += random+ ruPhoto.UploadedFiles[i].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                   // ruPhoto.UploadedFiles[0].SaveAs(path);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    ImageCompress.ApplyCompressionAndSave(img, path, 70, ruPhoto.UploadedFiles[i].ContentType);

                }
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
                rdpDate.SelectedDate = DateTime.Now;
                txtDescription.Text = "";
                chkIsDefault.Checked = false;
                ruPhoto.UploadedFiles.Clear();
                divlogo.Visible = false;
            }
            if (Mode == PageMode.Edit)
            {
                divlogo.Visible = true;
            }
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            if (Mode != PageMode.Add)
            {
                Mode = PageMode.Add;
                Navigate();
            }
        }

        //public static void SetMode()
        //{

        //}
    }
}