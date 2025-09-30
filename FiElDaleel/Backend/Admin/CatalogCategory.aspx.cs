using BrokerDLL;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrokerWeb.Backend.Admin
{
    public partial class CatalogCategory : System.Web.UI.Page, ICatalogCategory
    {
        CatalogCategoryController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CatalogCategoryController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCountries.PageIndex = e.NewPageIndex;
            gvCountries.DataSource = Controller.OnNeedDataSource();
            gvCountries.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCountries.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCountries.DataKeys[item.RowIndex].Value));
        }

        public int CategoryID
        {
            get
            {
                if (ViewState["CategoryID"] != null)
                {
                    return (int)ViewState["CategoryID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CategoryID"] = value;
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

        public void BindList(List<BrokerDLL.CatalogCategory> Categories)
        {
            gvCountries.DataSource = Categories;
            gvCountries.DataBind();
        }

        public BrokerDLL.CatalogCategory FillCategoryObject()
        {
            BrokerDLL.CatalogCategory category;
            if (Mode == PageMode.Add)
            {
                category = new BrokerDLL.CatalogCategory();
            }
            else
            {
                category = Controller.OnGet();
            }
            category.Name = txtName.Text;
            return category;
        }

        public void FillCategoryControls(BrokerDLL.CatalogCategory country)
        {
            txtName.Text = country.Name;
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
                txtName.Text = "";
            }
        }
    }
}