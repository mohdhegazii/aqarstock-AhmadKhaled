using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Migration.Classes;

namespace BrokerWeb.Backend.Admin
{
    public partial class Migrate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PropertyFinderXMLMigration Migration = new PropertyFinderXMLMigration();
            bool result = Migration.UpDateMigratedRealEstateLatAndLng();
            if (result)
            {
                lblMsg.Text = "success";
            }
            else
            {
                lblMsg.Text = "failure";
            }
        }
    }
}