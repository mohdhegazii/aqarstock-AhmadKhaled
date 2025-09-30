using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin.UserControls
{
    public partial class ucChangePassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser User = Membership.GetUser("Admin");
                User.ChangePassword(txtRegPassword.Text, txtNewPassword.Text);
                NotifyUser(Message.Save.GetValue(), MessageType.Success);
            }
            catch (Exception ex)
            {
                NotifyUser(ex.Message, MessageType.Error);
            }
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