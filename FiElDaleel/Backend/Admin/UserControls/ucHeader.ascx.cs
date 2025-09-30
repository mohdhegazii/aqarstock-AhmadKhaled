using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using System.Web.Security;
using System.Configuration;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin.UserControls
{
    public partial class ucHeader : System.Web.UI.UserControl, IAdminHeader
    {
        AdminHeaderController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminHeaderController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
               // lblTitle.Text = ConfigurationSettings.AppSettings["Name"].ToString();
            }
        }

        public void FillControls(int MessageNo, int ComplainsNo)
        {
            lblUnReadMsgNo.Text = MessageNo.ToString();
            lblComplains.Text = ComplainsNo.ToString();
        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.RedirectToRoute("Login");

        }

   


    
    }
}