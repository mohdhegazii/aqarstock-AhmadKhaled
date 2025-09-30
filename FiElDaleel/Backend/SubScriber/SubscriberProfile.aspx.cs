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
    public partial class SubscriberProfile : AqarPage, ISubscriberProfile
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

        public Subscriber FillSubscriperObject(Subscriber subscriber)
        {
            subscriber.Email = txtEmail.Text;
            subscriber.FullName = txtFullName.Text;
            subscriber.MobileNo = txtMobileNo.Text;
            subscriber.ChangePassword = chkChangePassword.Checked;
            if (chkChangePassword.Checked)
            {
                subscriber.Password = txtRegPassword.Text;
                subscriber.NewPassword = txtNewPassword.Text;
            }
            if (rbtnl.SelectedIndex == 1)
            {
                subscriber.IsCompanyAdmin = true;
            }
            else
            {
                subscriber.IsCompanyAdmin = false;
            }
            return subscriber;

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
            if (Commons.Subsciber.IsCompanyAdmin == true)
            {
                rbtnl.SelectedIndex = 1;
            }
            else
            {
                rbtnl.SelectedIndex = 0;
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


        public void ClearPasswordControle()
        {
            chkChangePassword.Checked = false;
            txtConfirmNewPassword.Text = "";
            txtNewPassword.Text = "";
            txtRegPassword.Text = "";
        }
    }
}