using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using BrokerDLL;
using Telerik.Web.UI;
using System.Web.Security;
using BrokerDLL.Migration.Classes;

namespace BrokerWeb
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //   SendSMS();
            //  Membership.DeleteUser("Gomaa");
            //Membership.CreateUser("Shahizidan", "789293");
            //Roles.AddUserToRole("Shahizidan", "Subscriber");
            //  TextBox1.Text = HtmlPageGenerator.BuildPage("new Page");
            //Roles.CreateRole("CompanyAdmin");
            //Roles.CreateRole("CompanyEmployee");
            //Roles.AddUserToRole("AqarEmp", "Admin");
            //Roles.AddUserToRole("hesham.hafez", "CompanyAdmin");
            //Roles.AddUserToRole("PME", "CompanyAdmin");
            //Roles.AddUserToRole("Ahmed Abd.Elhady", "CompanyAdmin");
            //PropertyFinderXMLMigration Migration = new PropertyFinderXMLMigration();
            //Migration.MigrateToBrokerDB(347);
            //MembershipUser user = Membership.GetUser("muhamed");
            //user.ChangePassword(user.ResetPassword(), "masharef@aqar");
            //SiteMapGenerator.GenerateSiteMap();
            //PropertyFinderXMLMigration Migration = new PropertyFinderXMLMigration();
            //Migration.Migrate("Test");
            //Class1 clas = new Class1();
            //clas.test();
            //  //TextBox1.Text = RadAsyncUpload1.UploadedFiles[0].ContentType;
            //  //System.Drawing.Image img = System.Drawing.Image.FromStream(RadAsyncUpload1.UploadedFiles[0].InputStream);
            //  //string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/")+"\\"+RadAsyncUpload1.UploadedFiles[0].FileName;
            //  //ImageCompress.ApplyCompressionAndSave(img, path, 30, RadAsyncUpload1.UploadedFiles[0].ContentType);
            ////  Membership.DeleteUser("new user");
            //  //MembershipUser user = Membership.GetUser("hassan aly");

            //  ////TextBox1.Text =
            //  //    user.ChangePassword(user.ResetPassword(),"123456");
        }

        private void SendSMS()
        {
            SMS sms = new SMS();
            sms.Lang = SMSLanguage.A;
            sms.Receiver = "01224761337";
            sms.Text = "اختبار خدمة";
            sms.Send();
        }
    }
}