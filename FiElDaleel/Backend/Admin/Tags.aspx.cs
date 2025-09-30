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
    public partial class Tags : System.Web.UI.Page, ITag
    {
        TagController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new TagController(this);
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

        public int TagId
        {
            get
            {
                if (ViewState["TagId"] != null)
                {
                    return (int)ViewState["TagId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["TagId"] = value;
            }
        }

        public void BindList(List<BrokerDLL.Tag> Keywords)
        {
            gvkeywords.DataSource = Keywords;
            gvkeywords.DataBind();
        }

        public BrokerDLL.Tag FillObject(BrokerDLL.Tag keyword)
        {
            keyword.Name = txtKeyWord.Text;
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
                keyword.ParentTagID = Convert.ToInt32(ddlParent.SelectedValue);
            }
            return keyword;
        }

        public void FillControls(BrokerDLL.Tag keyword)
        {
            txtURL.Text = keyword.URL;
            txtKeyWord.Text = keyword.Name;
            if (keyword.ParentTagID != null)
            {
                ddlParent.SelectedValue = keyword.ParentTagID.ToString();
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


        public void FillParentTagsList(List<Tag> Parents)
        {
            ddlParent.DataSource = Parents;
            ddlParent.DataTextField = "Name";
            ddlParent.DataValueField = "ID";
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("--اختار--", "0"));
        }
    }
}