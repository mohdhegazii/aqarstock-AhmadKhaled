using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class SubscriberProfile : System.Web.UI.Page, ISubscriberProfile
    {
        SubscriberProfileController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SubscriberProfileController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public void FillSubscriperObject()
        {
            Commons.Subsciber.Email = txtEmail.Text;
            Commons.Subsciber.FullName = txtFullName.Text;
            Commons.Subsciber.MobileNo = txtMobileNo.Text;
            Commons.Subsciber.ChangePassword = chkChangePassword.Checked;
            if (chkChangePassword.Checked)
            {
                Commons.Subsciber.Password = txtRegPassword.Text;
                Commons.Subsciber.NewPassword = txtNewPassword.Text;
            }

        }

        public void FillSubsciperControls()
        {
            txtEmail.Text = Commons.Subsciber.Email;
            txtFullName.Text = Commons.Subsciber.FullName;
            txtMobileNo.Text = Commons.Subsciber.MobileNo;
            txtUserName.Text = Commons.Subsciber.UserName;
            divPassword.Attributes.Add("style", "display:none");
            divNewPassword.Attributes.Add("style", "display:none");
            divConfirmNewPassword.Attributes.Add("style", "display:none");
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
    }
}