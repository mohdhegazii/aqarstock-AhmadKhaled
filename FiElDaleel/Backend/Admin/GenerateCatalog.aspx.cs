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
    public partial class GenerateCatalog : System.Web.UI.Page, IGenerateCatalogs
    {
        GenerateCatalogController Controller;
        public string CatalogNames
        {
            get
            {
                if (ViewState["CatalogNames"] != null)
                {
                    return ViewState["CatalogNames"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["CatalogNames"] = value;
            }
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

        public string CatalogDescriptions
        {
            get
            {
                if (ViewState["CatalogDescriptions"] != null)
                {
                    return ViewState["CatalogDescriptions"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["CatalogDescriptions"] = value;
            }
        }

        public void FillCategoryList(List<BrokerDLL.CatalogCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Name";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public ContentGenerator FillObject()
        {
            CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            CatalogNames = txtCatalogs.Text;
            ContentGenerator gen = new ContentGenerator();
            gen.CategoryID = 9;//Convert.ToInt32(ddlTagCategories.SelectedValue);
            gen.GeneralLink = txtGeneralLink.Text;
            gen.Headers = txtHeaders.Text;
            gen.KeywordLink = txtKeywordLink.Text;
           // gen.KeywordText = txtKeywordText.Text;
            gen.OccuranceNo = Convert.ToInt32(txtOccuranceNo.Text);
            gen.ParagraphNo = Convert.ToInt32(txtParagraphNo.Text);
            gen.TagNo = Convert.ToInt32(txtTagsNo.Text);
            return gen;
        }

        public void FillTagCategoryList(List<ContentTagCategory> Categories)
        {
            //ddlTagCategories.DataSource = Categories;
            //ddlTagCategories.DataTextField = "Name";
            //ddlTagCategories.DataValueField = "ID";
            //ddlTagCategories.DataBind();
            //ddlTagCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new GenerateCatalogController(this);
            if(!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnGenerate();
        }
    }
}