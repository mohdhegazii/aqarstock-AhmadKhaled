using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BrokerDLL;

namespace BrokerWeb.Initial
{
    public partial class Start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRoles_Click(object sender, EventArgs e)
        {
            Roles.CreateRole("Admin");
            Roles.CreateRole("Subscriber");
            Roles.CreateRole("Employee");
            lblMsg.Text = "Roles Created";
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Membership.CreateUser("Admin", "Admin@Broker");
            Roles.AddUserToRole("Admin", "Admin");
            lblMsg.Text = "User Created";
        }

        protected void btnActiveStatus_Click(object sender, EventArgs e)
        {
            Lookups.InsertActiveStatus("New");
            Lookups.InsertActiveStatus("Reviewing");
            Lookups.InsertActiveStatus("Reviewed");
            Lookups.InsertActiveStatus("Suspended");
            Lookups.InsertActiveStatus("updated");
            Lookups.InsertActiveStatus("Pending");
            Lookups.InsertActiveStatus("Active");
            lblMsg.Text = "Active Status Created";
        }

        protected void btnPaymentType_Click(object sender, EventArgs e)
        {
            Lookups.InsertPaymentType("كاش");
            Lookups.InsertPaymentType("تقسيط");
            lblMsg.Text = "Payment Types Created";
        }

        protected void btnSaleType_Click(object sender, EventArgs e)
        {
            Lookups.InsertSaleType("للبيع");
            Lookups.InsertSaleType("للايجار");
            lblMsg.Text="Sale Types Created";
        }

        protected void btnItemStatus_Click(object sender, EventArgs e)
        {
        
        }

        protected void btnOfferCategory_Click(object sender, EventArgs e)
        {
         
        }

        protected void btnOfferTypes_Click(object sender, EventArgs e)
        {
          
        }

  
        protected void btnSuspendReasons_Click(object sender, EventArgs e)
        {
            Lookups.InserSusspendReasson("بيانات الحساب غير صحيحة");
            Lookups.InserSusspendReasson("بيانات الاتصال غير صحيحة");
            Lookups.InserSusspendReasson("البيانات غير صحيحة");
            Lookups.InserSusspendReasson("الصور غير صحيحة"); 
            Lookups.InserSusspendReasson("تلقى شكاوى ");
            lblMsg.Text = "Susspend reasons Created";
        }

        protected void btnMessageTypes_Click(object sender, EventArgs e)
        {
            Lookups.InserMessageType("شكوى");
            Lookups.InserMessageType("اقتراح");
            lblMsg.Text = "Message Types Created";
        }
    }
}