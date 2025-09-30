using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class RealEstateCategories : System.Web.UI.Page,IRealEstateCategory
    {
        RealEstateCategoryController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateCategoryController(this);
            if(!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }


        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCategories.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCategories.DataKeys[item.RowIndex].Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }


        public int CategoryId
        {
            get
            {
                if (ViewState["CategoryId"] != null)
                {
                    return (int)ViewState["CategoryId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CategoryId"] = value;
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

        public void BindCategoriesList(List<BrokerDLL.RealEstateCategory> Categories)
        {
            gvCategories.DataSource = Categories;
            gvCategories.DataBind();
        }

        public BrokerDLL.RealEstateCategory FillCategoryObject()
        {
            RealEstateCategory Category;
            if (Mode == PageMode.Add)
            {
                Category = new RealEstateCategory();
            }
            else
            {
                Category = Controller.OnGetById();
            }
            Category.Title = txtTitle.Text;
            if (ruIcon.UploadedFiles.Count > 0)
            {
                Category.Icon = "~/Resources/RealEstates/Categories/" + txtTitle.Text + "_icon" + ruIcon.UploadedFiles[0].GetExtension();
            }
            return Category;
        }

        public void FillCategoryControls(BrokerDLL.RealEstateCategory Category)
        {
            txtTitle.Text = Category.Title;
            if (Category.Icon != "" && Category.Icon != null)
            {
                imgIcon.ImageUrl = Category.Icon;
            }
            else
            {
                divlogo.Visible = false;
            }
        }

        public void UploadCategoryIcon()
        {
            if (ruIcon.UploadedFiles.Count > 0)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Categories");
                ruIcon.UploadedFiles[0].SaveAs(Path + "\\" + txtTitle.Text + "_icon" + ruIcon.UploadedFiles[0].GetExtension());
               
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
            if (Mode == PageMode.Add)
            {
                txtTitle.Text = "";
                divlogo.Visible = false;
                ruIcon.UploadedFiles.Clear();
            }
            if (Mode == PageMode.Edit)
            {
                divlogo.Visible = true;
            }
        }
    }
}