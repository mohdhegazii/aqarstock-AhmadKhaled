using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL;
using BrokerDLL.Backend.Controllers;

namespace BrokerWeb.Backend.Admin
{
    public partial class CatalogList : System.Web.UI.Page,ICatalogList
    {
        CatalogListController Controller;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CatalogListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCatalogs.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCatalogs.DataKeys[item.RowIndex].Value));
        }

        public void BindList(List<RealEstateCatalog> Catalogs)
        {
            gvCatalogs.DataSource = Catalogs;
            gvCatalogs.DataBind();
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

        protected void gvCatalogs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCatalogs.PageIndex = e.NewPageIndex;
            Controller.OnNeedDatasource();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            Controller.OnFilterList();
        }

        public void FillCategoryList(List<BrokerDLL.CatalogCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }
    }
}