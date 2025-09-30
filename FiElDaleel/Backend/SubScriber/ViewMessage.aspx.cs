using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using Telerik.Web.UI;
using BrokerDLL;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class ViewMessage : AqarPage, IMessageView
    {
        MessageViewController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new MessageViewController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSend();
        }

        protected void rlvPrevMessages_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                RadListViewDataItem Item = (RadListViewDataItem)e.Item;
                SubscriperMessage Message = (SubscriperMessage)Item.DataItem;
                Label lblSenderName = (Label)Item.FindControl("lblSender");
                if (Message.FromSubscriber == true)
                {
                    lblSenderName.Text = Commons.Subsciber.FullName;
                }
                else
                {
                    lblSenderName.Text = "الادارة";
                }
            }
        }

        public int MainMessageID
        {
            get
            {
                if (ViewState["MainMessageID"] != null)
                {
                    return (int)ViewState["MainMessageID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["MainMessageID"] = value;
            }
        }

        public int MessageID
        {
            get
            {
                if (ViewState["MessageID"] != null)
                {
                    return (int)ViewState["MessageID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["MessageID"] = value;
            }
        }

        public void BindPrevMessagesControls(List<SubscriperMessage> PrevMessages)
        {
            rlvPrevMessages.DataSource = PrevMessages;
            rlvPrevMessages.DataBind();
        }

        public BrokerDLL.SubscriperMessage FillMessageObject()
        {
            SubscriperMessage Message = new SubscriperMessage();
            Message.Body = txtMessage.Text;
            Message.CreatedDate = DateTime.Now;
            Message.FromSubscriber = true;
            Message.From = Commons.Subsciber.ID;
            Message.IsClosed = false;
            Message.ParentMessageID = MainMessageID;
            Message.IsRead = false;

            return Message;
        }

        public void FillMessageTitleControl(string Title)
        {
            lblTitle.Text = Title;
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

    }
}