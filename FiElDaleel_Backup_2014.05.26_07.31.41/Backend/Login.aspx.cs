using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL;
using BrokerDLL.Backend.Controllers;

namespace BrokerWeb.Backend
{
    public partial class Login : System.Web.UI.Page,ILogin
    {
        LoginController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller=new LoginController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        public Subscriber FillSubscriberObject()
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Email = txtEmail.Text;
            subscriber.FullName = txtFullName.Text;
            subscriber.MobileNo = txtMobileNo.Text;
            subscriber.Password = txtRegPassword.Text;
            subscriber.UserName = txtRegUserNamr.Text;
            subscriber.CreatedDate = DateTime.Now;
            subscriber.ActiveStatusID = (int)Activestatus.Pending;
            return subscriber;
        }

        public void NotifyUser(Message Msg, BrokerDLL.MessageType Type)
        {
            if (Msg == Message.LoginError || Msg==Message.UserNameNotExist)
            {
                lblLoginMsg.Text = Msg.GetValue();
                if (Type == MessageType.Success)
                    divMsg.Attributes.Add("Class", "alert alert-success");
                else
                    divMsg.Attributes.Add("Class", "alert alert-danger");
            }
            if (Msg == Message.UsernameNotAvailable)
            {
                lblUserNameMsg.Text = Msg.GetValue();
            }
            if (Msg == Message.UsernameAvailable)
            {
                lblUserNameMsg.Text = Msg.GetValue();
                lblUserNameMsg.CssClass = "Valid";
            }
            if (Msg == Message.EmailRegistered)
            {
                lblEmailMsg.Text = Msg.GetValue();

            }
            if (Msg == Message.PasswordSentToEmail || Msg == Message.EmailNotRegistered)
            {
                lblForgetPasswordMsg.Text = Msg.GetValue();
                if (Type == MessageType.Success)
                    divForgetPasswordMsg.Attributes.Add("Class", "alert alert-success");
                else
                    divForgetPasswordMsg.Attributes.Add("Class", "alert alert-danger");
            }
            
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblLoginMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

        protected void txtRegUserNamr_TextChanged(object sender, EventArgs e)
        {
            Controller.OnCheckUserNameAvailability(txtRegUserNamr.Text);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Controller.OnLogin(txtUserName.Text, txtPassword.Text);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Controller.OnRegister();
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Controller.OnCheckEmailAvailability(txtEmail.Text);
        }

        protected void btnForgetPassword_Click(object sender, EventArgs e)
        {
            Controller.OnForgetPassword(txtFPUserName.Text, txtFPEmail.Text);
        }
    }
}