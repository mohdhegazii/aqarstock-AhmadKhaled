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
    public partial class ucProjectModel : System.Web.UI.UserControl,IProjectModel
    {
        ProjectModelController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ProjectModelController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvModels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvModels.PageIndex = e.NewPageIndex;
            gvModels.DataSource = Controller.OnNeedDataSource();
            gvModels.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvModels.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvModels.DataKeys[item.RowIndex].Value));
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

        public int ModelID
        {
            get
            {
                if (ViewState["ModelID"] != null)
                {
                    return (int)ViewState["ModelID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["ModelID"] = value;
            }
        }

        public void FillRealEstateTypeList(List<BrokerDLL.RealEstateType> Type)
        {
            ddlType.DataSource = Type;
            ddlType.DataTextField = "Title";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void BindList(List<BrokerDLL.RealEstateProjectModel> Models)
        {
            gvModels.DataSource = Models;
            gvModels.DataBind();
        }

        public BrokerDLL.RealEstateProjectModel FillObject(BrokerDLL.RealEstateProjectModel Model, string Code,string random)
        {
            Model.Area = Convert.ToInt32(txtArea.Text);
            Model.Description = txtDescription.Text;
            Model.Price=Convert.ToInt32(txtPrice.Text);
            Model.RealEstateTypeID=Convert.ToInt32(ddlType.SelectedValue);
            Model.Title=txtTitle.Text;
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                Model.PlanImgURL = "~/Resources/RealEstates/Projects/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/"
                        + DateTime.Now.Day + "/" + Code + "/" + random + ruPhoto.UploadedFiles[0].GetExtension();
                imgLogo.ImageUrl = Model.PlanImgURL;
            }
            return Model;
        }

        public void FillControls(BrokerDLL.RealEstateProjectModel Model)
        {
            txtTitle.Text = Model.Title;
            txtPrice.Text = Model.Price.ToString();
            txtDescription.Text = Model.Description;
            txtArea.Text = Model.Area.ToString();
            imgLogo.ImageUrl = Model.PlanImgURL;
            ddlType.SelectedValue = Model.RealEstateTypeID.ToString();
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
                    path += random + ruPhoto.UploadedFiles[i].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    //ruPhoto.UploadedFiles[0].SaveAs(path);
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[0].InputStream);
                    ImageCompress.ApplyCompressionAndSave(img, path, 70, ruPhoto.UploadedFiles[0].ContentType);
                    //System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    //ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);

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
                txtArea.Text = "";
                txtPrice.Text = "";
                txtTitle.Text = "";
                txtDescription.Text = "";
                ddlType.SelectedIndex = 0;
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
    }
}