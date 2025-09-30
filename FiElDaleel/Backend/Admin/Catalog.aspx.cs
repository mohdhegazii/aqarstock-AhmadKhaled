using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL;
using BrokerDLL.Backend.Controllers;
using System.IO;
using System.Configuration;

namespace BrokerWeb.Backend.Admin
{
    public partial class Catalog : System.Web.UI.Page, ICatalog
    {
        CatalogController Controller;
        public int CatalogID
        {
            get
            {
                if (ViewState["CatlogID"] != null)
                {
                    return (int)ViewState["CatlogID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CatlogID"] = value;
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

        public CatalogSearchMode SearchMode
        {
            get
            {
                if (ViewState["SearchMode"] != null)
                {
                    return (CatalogSearchMode)ViewState["SearchMode"];
                }
                else
                {
                    return CatalogSearchMode.none;
                }
            }
            set
            {
                ViewState["SearchMode"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CatalogController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public void BindList(List<RealestateCatalogProperty> Props)
        {
            gvRealestates.DataSource = Props;
            gvRealestates.DataBind();
        }

        public void FillCategoryList(List<BrokerDLL.CatalogCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }
        public void FillControls(RealEstateCatalog Catalog)
        {
            txtDescription.Text = Catalog.Description;
            txtTitle.Text = Catalog.Title;
            imgPhoto.ImageUrl = Catalog.PhotoURL;
          //  imgSocial.ImageUrl = Catalog.SocialPhotoURL;
          //  chkTags.Checked = Catalog.AllTags.Value;
            reTags.Content = Catalog.Tag;
            if(Catalog.CategoryID!=0 && Catalog.CategoryID!=null)
            {
                ddlCategories.SelectedValue = Catalog.CategoryID.ToString();
            }
            hlURL.NavigateUrl = Catalog.URL;//ConfigurationSettings.AppSettings["WebSite"] + "/كتالوجات_عقارية/" + Catalog.ID + "/" + Catalog.Title.Replace(" ", "_");
        }

        public RealEstateCatalog FillObject(RealEstateCatalog Catalog)
        {
            Catalog.Description = txtDescription.Text;
            Catalog.Title = txtTitle.Text;
           // Catalog.AllTags = chkTags.Checked;
            Catalog.Tag = reTags.Content;
            Catalog.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            if(ruPhoto.UploadedFiles.Count>0)
            { 
            Catalog.PhotoURL = "~/Resources/RealEstates/Catalogs/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                               + DateTime.Today.Day + "/" + Catalog.Code + ruPhoto.UploadedFiles[0].GetExtension();
            }
            //if(ruSocial.UploadedFiles.Count>0)
            //{ 
            //Catalog.SocialPhotoURL = "~/Resources/RealEstates/Catalogs/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
            //                   + DateTime.Today.Day + "/" + Catalog.Code+"_Social" + ruSocial.UploadedFiles[0].GetExtension();
            //}
            return Catalog;
        }

        public void FillRealestateList(List<RealEstate> Realestates)
        {
            if (SearchMode == CatalogSearchMode.ByCompany)
            {
                ddlCompanyRealestate.DataSource = Realestates;
                ddlCompanyRealestate.DataTextField = "Title";
                ddlCompanyRealestate.DataValueField = "ID";
                ddlCompanyRealestate.DataBind();
                ddlCompanyRealestate.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
            if (SearchMode == CatalogSearchMode.ByProject)
            {
                ddlProjectRealestate.DataSource = Realestates;
                ddlProjectRealestate.DataTextField = "Title";
                ddlProjectRealestate.DataValueField = "ID";
                ddlProjectRealestate.DataBind();
                ddlProjectRealestate.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
            if (SearchMode == CatalogSearchMode.ByUser)
            {
                ddlUserRealestate.DataSource = Realestates;
                ddlUserRealestate.DataTextField = "Title";
                ddlUserRealestate.DataValueField = "ID";
                ddlUserRealestate.DataBind();
                ddlUserRealestate.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
        }


        public void Upload(string Code)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                    }

                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\";
                    path += Code + ruPhoto.UploadedFiles[0].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    ruPhoto.UploadedFiles[0].SaveAs(path);
                    //System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    //ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);

            }
            //if (ruSocial.UploadedFiles.Count > 0)
            //{
            //    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year))
            //    {
            //        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year);
            //    }
            //    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
            //    {
            //        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
            //    }
            //    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
            //    {
            //        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
            //    }

            //    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Catalogs/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\";
            //    path += Code + "_Social" + ruSocial.UploadedFiles[0].GetExtension();
            //    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
            //    ruSocial.UploadedFiles[0].SaveAs(path);
            //    //System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
            //    //ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);

            //}
        }

        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            if (SearchMode == CatalogSearchMode.none)
            {
                lblMsg.Text = Msg.GetValue();
                if (Type == MessageType.Success)
                    divMsg.Attributes.Add("Class", "alert alert-success");
                else
                    divMsg.Attributes.Add("Class", "alert alert-danger");
            }
            else
            {
                lblAddMsg.Text = Msg.GetValue();
                if (Type == MessageType.Success)
                    divAddMsg.Attributes.Add("Class", "alert alert-success");
                else
                    divAddMsg.Attributes.Add("Class", "alert alert-danger");
            }
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            //if (SearchMode == CatalogSearchMode.none)
            //{
                lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
            //}
            //else
            //{
            //    lblAddMsg.Text = Msg;
            //    if (Type == MessageType.Success)
            //        divAddMsg.Attributes.Add("Class", "alert alert-success");
            //    else
            //        divAddMsg.Attributes.Add("Class", "alert alert-danger");
            //}
        }
        public void Navigate()
        {
            if (Mode == PageMode.Add)
            {
                txtDescription.Text = "";
                txtTitle.Text = "";
                hlURL.Enabled = false;
                divlogo.Visible = false;
               // divImgSocial.Visible = false;
                divRealestateList.Visible = false;
                gvRealestates.DataSource = null;
                gvRealestates.DataBind();
            }
            else
            {
                hlURL.Enabled = true;
                divlogo.Visible = true;
              //  divImgSocial.Visible = true;
                divRealestateList.Visible = true;
            }
        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvRealestates.DataKeys[item.RowIndex].Value));
        }
        protected void btnAddByCode_Click(object sender, EventArgs e)
        {
            Controller.OnAddByCode(txtCode.Text);
            txtCode.Text = "";
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.OnSelectCompany(Convert.ToInt32(ddlCompany.SelectedValue));
        }

        public void FillCompanyList(List<RealEstateCompany> Companies)
        {
            ddlCompany.DataSource = Companies;
            ddlCompany.DataTextField = "Title";
            ddlCompany.DataValueField = "ID";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        protected void btnAddByCompany_Click(object sender, EventArgs e)
        {
            Controller.OnAdd(Convert.ToInt32(ddlCompanyRealestate.SelectedValue));
        }

        protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.OnSelectProject(Convert.ToInt32(ddlProjects.SelectedValue));
        }

        protected void btnAddByProject_Click(object sender, EventArgs e)
        {
            Controller.OnAdd(Convert.ToInt32(ddlProjectRealestate.SelectedValue));
        }

        public void FillProjectList(List<RealEstateProject> Projects)
        {
            ddlProjects.DataSource = Projects;
            ddlProjects.DataTextField = "Title";
            ddlProjects.DataValueField = "ID";
            ddlProjects.DataBind();
            ddlProjects.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        protected void btnAddByUser_Click(object sender, EventArgs e)
        {
            Controller.OnAdd(Convert.ToInt32(ddlUserRealestate.SelectedValue));
        }

        public void FillUserList(List<Subscriber> Subscribers)
        {
            ddlUsers.DataSource = Subscribers;
            ddlUsers.DataTextField = "FullAndUserName";
            ddlUsers.DataValueField = "ID";
            ddlUsers.DataBind();
            ddlUsers.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.OnSelectUser(Convert.ToInt32(ddlUsers.SelectedValue));
        }

        protected void ibtnDeleteTag_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDeleteTag(Convert.ToInt32(gvTags.DataKeys[item.RowIndex].Value));
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            Controller.OnAddTag(Convert.ToInt32(ddlTags.SelectedValue));
        }
        public void BindTagList(List<RealestateCatalogTag> Tags)
        {
            gvTags.DataSource = Tags;
            gvTags.DataBind();
        }

        public void FillTagsList(List<Tag> Tags)
        {
            ddlTags.DataSource = Tags;
            ddlTags.DataTextField = "Name";
            ddlTags.DataValueField = "ID";
            ddlTags.DataBind();
            ddlTags.Items.Insert(0, new ListItem("--اختار--", "0"));
        }
    }
}