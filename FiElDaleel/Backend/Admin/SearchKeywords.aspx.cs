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
    public partial class SearchKeywords : System.Web.UI.Page, ISearchKeyword
    {
        SearchKeywordController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SearchKeywordController(this);
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
            gvkeywords.PageIndex = e.NewPageIndex;
            gvkeywords.DataSource = Controller.OnNeedDataSource();
            gvkeywords.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvkeywords.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvkeywords.DataKeys[item.RowIndex].Value));
        }

        public int KeywordId
        {
            get
            {
                if (ViewState["KeywordId"] != null)
                {
                    return (int)ViewState["KeywordId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["KeywordId"] = value;
            }
        }

        public void BindList(List<BrokerDLL.SearchKeyword> Keywords)
        {
            gvkeywords.DataSource = Keywords;
            gvkeywords.DataBind();
        }

        public BrokerDLL.SearchKeyword FillObject(  SearchKeyword keyword)
        {
            keyword.Keywords = txtKeyWord.Text;
            keyword.URL = Server.UrlDecode(txtURL.Text);
            keyword.URL = keyword.URL.Replace("#/", "");
            if (keyword.URL.Contains("نتيجة_البحث"))
            {
                keyword.URL = keyword.URL.Replace("نتيجة_البحث", "كلمات_البحث");
                if (keyword.URL.LastIndexOf('/') == keyword.URL.Length - 1)
                {
                    keyword.URL += txtKeyWord.Text.Replace(' ', '_');
                }
                else
                {
                    keyword.URL += "/" + txtKeyWord.Text.Replace(' ', '_'); 
                }
            }
            if (ddlParent.SelectedIndex > 0)
            {
                keyword.ParentID = Convert.ToInt32(ddlParent.SelectedValue);
            }
            return keyword;
        }

        public void FillControls(BrokerDLL.SearchKeyword keyword)
        {
            txtURL.Text = keyword.URL;
            txtKeyWord.Text = keyword.Keywords;
            if (keyword.ParentID != null)
            {
                ddlParent.SelectedValue = keyword.ParentID.ToString();
            }
            else
            {
                ddlParent.SelectedIndex = 0;
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
                txtKeyWord.Text = "";
                txtURL.Text = "";
                ddlParent.SelectedIndex = 0;
            }
        }


        public void FillParentKeywordsList(List<SearchKeyword> Parents)
        {
            ddlParent.DataSource = Parents;
            ddlParent.DataTextField = "Keywords";
            ddlParent.DataValueField = "ID";
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("--اختار--", "0"));
        }
    }
}