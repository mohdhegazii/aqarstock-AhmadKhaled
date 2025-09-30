using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using BrokerDLL;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucHeader : System.Web.UI.UserControl, ISubscriberHeader
    {
        SubscriberHeaderController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SubscriberHeaderController(this);
            if (!IsPostBack)
            {
               // lblTitle.Text = ConfigurationSettings.AppSettings["Name"].ToString();
                Controller.OnViewInitialize();
                //lblMsgNo.Text = Commons.CountUnReadMessages().ToString();
                //lblRequestNo.Text = Commons.CountUnReadPurchaseRequest().ToString();
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.RedirectToRoute("Login");

        }

        public void CountUnReadNotification(int count)
        {
          //  lblMsgCount.Text = count.ToString();
            lblNotificationNo.Text = count.ToString();
        }

        public void CountUnReadPurchaseRequest(int count)
        {
           // lblRequestcount.Text = count.ToString();
            lblRequestNo.Text = count.ToString();
        }

        public void BindUnReadMessages(List<SubscriperMessage> Messages)
        {
           // rptMessages.DataSource = Messages;
          //  rptMessages.DataBind();
        }

        public void BindUnReadRequests(List<RealEstatePurchaseRequest> Request)
        {
          //  rptRequest.DataSource = Request;
          //  rptRequest.DataBind();
        }


        public void NavigatetoManagerView()
        {
            liCompany.Visible = true;
            liNewProject.Visible = true;
            liProjectList.Visible = true;
            liMessages.Visible = true;
        }


        public void CountUnReadMessages(int count)
        {
            lblMsgNo.Text = count.ToString();
        }
    }
}