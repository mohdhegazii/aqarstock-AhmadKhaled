using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using BrokerDLL;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class CompanyUserData : AqarPage,ICompanyUser
    {
        CompanyUserController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CompanyUserController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void txtRegUserNamr_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9_.]+$");
            if (rgx.IsMatch(txtUserName.Text))
            {
                Controller.OnCheckUserNameAvailability(txtUserName.Text);
            }
            else
            {
                NotifyUser(Message.UserNameInvalidChars, MessageType.Error);

            }
        }
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Controller.OnCheckEmailAvailability(txtEmail.Text);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnRegister();
        }

        public int UserID
        {
            get
            {
                if (ViewState["UserID"] != null)
                {
                    return (int)ViewState["UserID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["UserID"] = value;
            }
        }

        public int CompanyId
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

        public Subscriber FillSubscriberObject()
        {
            Subscriber subscriber = new Subscriber();
            subscriber.Email = txtEmail.Text;
            subscriber.FullName = txtFullName.Text;
            subscriber.MobileNo = txtMobileNo.Text;
            subscriber.Password = txtPassword.Text;
            subscriber.UserName = txtUserName.Text;
            subscriber.CreatedDate = DateTime.Now;
            subscriber.IsCompanyAdmin = chkIsAdmin.Checked;
            subscriber.CompanyID = CompanyId;
            subscriber.ActiveStatusID = (int)Activestatus.Pending;
            return subscriber;
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

        public void NotifyUser(Message Msg, MessageType Type)
        {
            if (Msg == Message.UsernameNotAvailable)
            {
                lblUserNameMsg.Text = Msg.GetValue();
                lblUserNameMsg.CssClass = "Validator";
            }
            if (Msg == Message.UserNameInvalidChars)
            {
                lblUserNameMsg.Text = Msg.GetValue();
                lblUserNameMsg.CssClass = "Validator";
            }
            if (Msg == Message.UsernameAvailable)
            {
                lblUserNameMsg.Text = Msg.GetValue();
                lblUserNameMsg.CssClass = "Valid";
            }
            if (Msg == Message.EmailRegistered)
            {
                lblEmailMsg.Text = Msg.GetValue();
                lblEmailMsg.CssClass = "Validator";

            }
            if (Msg == Message.EmailValid)
            {
                lblEmailMsg.Text = ""; //Msg.GetValue();
               // lblEmailMsg.CssClass = "Valid";

            }
            if(Msg==Message.SaveNewCompanyUser)
            {
                lblMsg.Text = Msg.GetValue();
                divMsg.Attributes.Add("Class", "alert alert-success");
            }
            if (Msg == Message.UserCompanyNotExist || Msg==Message.CompanyInvalidUserNos)
            {
                lblMsg.Text = Msg.GetValue();
                divMsg.Attributes.Add("Class", "alert alert-danger");
            }


          
        }

        public void NotifyUser(string Msg, MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

        public void Navigate()
        {
            txtConfirmNewPassword.Text = "";
            txtEmail.Text = "";
            txtFullName.Text = "";
            txtMobileNo.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            chkIsAdmin.Checked = false;
            lblEmailMsg.Text = "";
            lblUserNameMsg.Text = "";
            if (Mode == PageMode.Disable)
            {
                txtConfirmNewPassword.Enabled = false;
                txtEmail.Enabled = false;
                txtFullName.Enabled = false;
                txtMobileNo.Enabled = false;
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
                btnSave.Enabled = false;
                chkIsAdmin.Enabled = false;
            }
        }
    }
}