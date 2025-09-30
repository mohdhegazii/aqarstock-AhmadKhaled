using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;

namespace BrokerWeb.Backend.Admin
{
    public partial class MessagesList : System.Web.UI.Page,IAdminMessageList
    {
        AdminMessageListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminMessageListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnSelectMessage(Convert.ToInt32(gvMessages.DataKeys[item.RowIndex].Value));
        }

        protected void gvMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMessages.PageIndex = e.NewPageIndex;
            gvMessages.DataSource = Controller.OnNeedDataSource();
            gvMessages.DataBind();
        }

        public void BindMessagesList(List<BrokerDLL.SubscriperMessage> Messages)
        {
            gvMessages.DataSource = Messages;
            gvMessages.DataBind();
        }
    }
}