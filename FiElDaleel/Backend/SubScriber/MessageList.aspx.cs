using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class MessageList : AqarPage, IMessageList
    {
        MessageListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new MessageListController(this);
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

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvMessages.DataKeys[item.RowIndex].Value));
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

        public static bool CheckReadStatus(object IsRead)
        {
            if (Convert.ToBoolean(IsRead))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}