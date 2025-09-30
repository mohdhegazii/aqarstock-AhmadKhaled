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
    public partial class Keywords : System.Web.UI.Page,IKeyword
    {
        KeywordController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new KeywordController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvKeywords.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvKeywords.DataKeys[item.RowIndex].Value));
        }

        public int KeywordID
        {
            get
            {
                if (ViewState["KeywordID"] != null)
                {
                    return (int)ViewState["KeywordID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["KeywordID"] = value;
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

        public void BindKeywordsList(List<BrokerDLL.Keyword> Keywords)
        {
            gvKeywords.DataSource = Keywords;
            gvKeywords.DataBind();
        }

        public Keyword FillKeywordObject()
        {
            Keyword keyword;
            if (Mode == PageMode.Add)
            {
                keyword = new Keyword();
            }
            else
            {   
                keyword = Controller.OnGetById();
            }
            keyword.Title = txtTitle.Text;
            return keyword;
        }

        public void FillKeywordControls(BrokerDLL.Keyword keyword)
        {
            txtTitle.Text = keyword.Title;
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
                txtTitle.Text="";
            }
        }

        protected void gvKeywords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvKeywords.PageIndex = e.NewPageIndex;
            gvKeywords.DataSource = Controller.OnNeedDatasource();
            gvKeywords.DataBind();
        }
      
    }
}