using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using BrokerDLL;
using System.Web.Security;

namespace BrokerWeb.Backend.Admin.Settings
{
    public partial class GenerateSiteMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
        }

        protected void btnGenerateSiteMAp_Click(object sender, EventArgs e)
        {
            bool Success=SiteMapGenerator.GenerateSiteMap();
            if (Success)
            {
                lblMsg.Text = Message.ActivateObject.GetValue();
            }
        }

        protected void btnAddGeneralLinks_Click(object sender, EventArgs e)
        {
            bool Success = SiteMapGenerator.AddGeneralLinks();
            if (Success)
            {
                lblMsg.Text = Message.ActivateObject.GetValue();
            } 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool Success = SiteMapGenerator.GenerateCatalogSiteMap();
            if (Success)
            {
                lblMsg.Text = Message.ActivateObject.GetValue();
            }
        }
    }
}