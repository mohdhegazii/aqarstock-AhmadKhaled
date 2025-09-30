using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucNewMessage : System.Web.UI.UserControl, INewMessage
    {
        NewMessageController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new NewMessageController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public void FillMessageTypesList(List<BrokerDLL.SubscriperMessageType> Types)
        {
            ddlMessageType.DataSource = Types;
            ddlMessageType.DataTextField = "Title";
            ddlMessageType.DataValueField = "ID";
            ddlMessageType.DataBind();
            ddlMessageType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public BrokerDLL.SubscriperMessage FillMessageObject()
        {
            SubscriperMessage Message = new SubscriperMessage();
            Message.Body = txtDescription.Text;
            Message.CreatedDate = DateTime.Now;
            Message.From = Commons.Subsciber.ID;
            Message.FromSubscriber = true;
            Message.IsRead = false;
            Message.IsClosed = false;
            Message.MessageTypeID = Convert.ToInt32(ddlMessageType.SelectedValue);
            Message.Title = txtTitle.Text;
            return Message;
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

        public void Navigate()
        {
            if (Mode == PageMode.Add)
            {
                txtTitle.Text = "";
                txtDescription.Text = "";
                ddlMessageType.SelectedIndex = 0;
            }
        }
    }
}