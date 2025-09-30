using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using BrokerDLL;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class CompanyUserList : AqarPage, ICompanyUserList
    {
        CompanyUserListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CompanyUserListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            gvUsers.DataSource = Controller.OnNeedDataSource();
            gvUsers.DataBind();
        }


        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnRemove(Convert.ToInt32(gvUsers.DataKeys[item.RowIndex].Value));
        }

        protected void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow item = (GridViewRow)chk.NamingContainer;
            Controller.OnSetAdmin(Convert.ToInt32(gvUsers.DataKeys[item.RowIndex].Value),chk.Checked);
        }

        public int CompanyID
        {
            get
            {
                if (ViewState["CompanyId"] != null)
                {
                    return (int)ViewState["CompanyId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CompanyId"] = value;
            }
        }

        public void BindList(List<BrokerDLL.Subscriber> Subscribers)
        {
            gvUsers.DataSource = Subscribers;
            gvUsers.DataBind();
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

        public static bool CheckAdminStatus(object IsAdmin)
        {
            if (Convert.ToBoolean(IsAdmin))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}