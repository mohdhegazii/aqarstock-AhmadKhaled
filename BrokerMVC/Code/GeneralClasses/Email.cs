using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace BrokerMVC
{
    public class Email
    {
        EmailType _EmailType;
        private List<string> _Recievers = new List<string>();
        private List<string> _CC = new List<string>();
        private List<string> _BC = new List<string>();
        private bool _HasAttachment;
        private Attachment _Attachement;
        private Dictionary<string, string> _MailCriteria;

        string ServerName
        {
            get
            {
                return ConfigurationSettings.AppSettings["MailServer"].ToString();
            }
        }
        int Port
        {
            get
            {
                return Convert.ToInt32(ConfigurationSettings.AppSettings["MailServerPort"]);
            }
        }
        string FromMail
        {
            get
            {
                return ConfigurationSettings.AppSettings["MailFrom"].ToString();
            }
        }
        string UserName
        {
            get
            {
                return ConfigurationSettings.AppSettings["MailUserName"].ToString();
            }
        }
        string Password
        {
            get
            {
                return ConfigurationSettings.AppSettings["MailPassword"].ToString();
            }
        }

        public EmailType EmailType
        {
            get { return _EmailType; }
            set { _EmailType = value; }
        }
        public List<string> Recievers
        {
            get { return _Recievers; }
            set { _Recievers = value; }
        }
        public List<string> CC
        {
            get { return _CC; }
            set { _CC = value; }
        }
        public List<string> BC
        {
            get { return _BC; }
            set { _BC = value; }
        }
        public bool HasAttachment
        {
            get { return _HasAttachment; }
            set { _HasAttachment = value; }
        }
        public Attachment Attachement
        {
            get { return _Attachement; }
            set { _Attachement = value; }
        }
        public Dictionary<string, string> MailCriteria
        {
            get { return _MailCriteria; }
            set { _MailCriteria = value; }
        }

        public bool Send()
        {
            System.Net.Mail.SmtpClient client = ConfigureMailServer();
            MailMessage mailmessage = new MailMessage();
            MailAddress fromAddress = new MailAddress(FromMail, ConfigurationSettings.AppSettings["Name"].ToString());
            mailmessage.IsBodyHtml = true;
            mailmessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailmessage.From = fromAddress;
            mailmessage.Subject = EmailType.GetValue();
            mailmessage.Body = BuildMessage();
            if (Recievers.Count > 0)
            {
                SetMessageRecievers(mailmessage);
            }
            else
            {
                return false;
            }
            if (HasAttachment)
            {
                mailmessage.Attachments.Add(Attachement);
            }

            client.Send(mailmessage);
            return true;
        }

        private string BuildMessage()
        {
            string Message = "<html>";
            Message += BuildMessgaeHeader();
            Message += BuildMessageBody();
            Message += "</html>";
            return Message;
        }

        private string BuildMessageBody()
        {
            string Body = "<body>";
            Body += " <table style='width:70%; direction:rtl;' align='center'>";
            Body += BuildBodyHeader();
            Body += BuildMessageDetails();
            Body += BuildMessageFooter();
            Body += "</table>";
            Body += "</body>";
            return Body;
        }

        private string BuildMessageFooter()
        {
            string Message = "  <p style='float: left; margin-left:10px;'><b>خدمة عملاء " + ConfigurationSettings.AppSettings["Name"].ToString() + " </b> <br /><small>";
            Message += "<a href='" + ConfigurationSettings.AppSettings["WebSite"].ToString() + "' target='_blank' style='float: left; display: inline-block'>" + ConfigurationSettings.AppSettings["WebSite"].ToString() + "</a></small></p>";
            Message += "   </td>  </tr> ";
            return Message;
        }

        private string BuildMessageDetails()
        {
            switch (EmailType)
            {
                case EmailType.ActivateAccount:
                     return BuildActivationMessage();
                case EmailType.ForgetPassword:
                     return BuildForgetPassMessage();
                case EmailType.ReplyMessage:
                    return BuildReplyMessage();
                case EmailType.ActivateBusiness:
                    return BuildActivateObjectMessage();
                case EmailType.SuspendBusiness:
                    return BuildSuspendObjectMessage();
                case EmailType.ContactUs:
                    return BuildContactUsMessage();
                case EmailType.ContactCompany:
                    return BuildContactUsMessage();
                case EmailType.NotifyRequest:
                    return BuildNotifyMessage();
                case EmailType.PurchaseRequest:
                    return BuildPurchaseRequestMessage();
                case EmailType.ValidateAccount:
                    return BuildValidateContactMessage();
                case EmailType.GeneratePassword:
                    return BuildGeneratePasswordMessage();
                case EmailType.SMSNotWorking:
                    return BuildSMSNotWorkingMessage();
                default:
                    return"";
            }
        }

        private string BuildPurchaseRequestMessage()
        {
            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "  <b style='margin-right:10px;'>تم ارسال طلب شراء لاحد عقاراتك المسجلة على النظام </b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>رقم العقار</td>";
            Message += "<td>" + MailCriteria["Code"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>عنوان اعلان العقار</td>";
            Message += "<td>" + MailCriteria["Title"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }

        private string BuildSuspendObjectMessage()
        {
            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "  <b style='margin-right:10px;'>تم حجب بيانات <span style='  background-color: #D9534F; color: #FFFFFF; padding:3px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'>  ";
            Message += MailCriteria["Title"];
            Message += "  </span> بعد مراجعتها</b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>سبب الحجب</td>";
            Message += "<td>" + MailCriteria["SuspendReason"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>رسالة الادارة</td>";
            Message += "<td>" + MailCriteria["Message"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }

        private string BuildActivateObjectMessage()
        {
            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "  <b style='margin-right:10px;'> تم مراجعة بيانات  <span style='  background-color: #D9534F; color: #FFFFFF; padding:3px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'> ";
            Message += MailCriteria["Title"];
            Message += " </span>  و الموافقة عليها </b> </p>";
            return Message;
        }

        private string BuildForgetPassMessage()
        {
            string Message = "<tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>كود استعادة كلمة المرور برجاء استخدام الكود الموضح ادناه</ b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>اسم المستخدم</td>";
            Message += "<td>" + MailCriteria["UserName"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>كلمة السر</td>";
            Message += "<td>" + MailCriteria["Password"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }

        private string BuildContactUsMessage()
        {
            string Message = "<tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  </h4>";
            Message += "<b style='margin-right:10px;'> تم ارسال رسالة من احد العملاء  </b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>اسم العميل</td>";
            Message += "<td>" + MailCriteria["Name"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>رقم الهاتف</td>";
            Message += "<td>" + MailCriteria["Phone"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>البريدالالكترونى</td>";
            Message += "<td>" + MailCriteria["Email"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>الرسالة</td>";
            Message += "<td>" + MailCriteria["Message"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }
        private string BuildNotifyMessage()
        {
            string Message = "<tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  </h4>";
            Message += "<b style='margin-right:10px;'> تم ارسال رسالة من احد العملاء  </b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>اسم العميل</td>";
            Message += "<td>" + MailCriteria["Name"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>رقم الهاتف</td>";
            Message += "<td>" + MailCriteria["Phone"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>البريدالالكترونى</td>";
            Message += "<td>" + MailCriteria["Email"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>النوع</td>";
            Message += "<td>" + MailCriteria["RealEstateType"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>النظام</td>";
            Message += "<td>" + MailCriteria["SaleType"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>البلد</td>";
            Message += "<td>" + MailCriteria["Country"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>المحافظة</td>";
            Message += "<td>" + MailCriteria["City"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>الحى</td>";
            Message += "<td>" + MailCriteria["District"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>السعر</td>";
            Message += "<td>" + MailCriteria["Price"] + "</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>المساحة</td>";
            Message += "<td>" + MailCriteria["Area"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }

        private string BuildActivationMessage()
        {

            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>شكراً لاشتراكك معنا, لتفعيل حسابك يرجى نسخ الرمز التالي </b>";
            Message += "              <br /> <span style='  background-color: #D9534F;border-radius: 0.25em;  color: #FFFFFF; display: block;font-size: 75%; font-weight: 700; line-height: 1; padding:10px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'>";
            Message += MailCriteria["Code"];
            Message += " </span> </p>";
            return Message;
        }
        private string BuildValidateContactMessage()
        {

            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>لرؤية بيانات المالك قم بادخال الرمز التالي :  </b>";
            Message += "              <br /> <span style='  background-color: #D9534F;border-radius: 0.25em;  color: #FFFFFF; display: block;font-size: 75%; font-weight: 700; line-height: 1; padding:10px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'>";
            Message += MailCriteria["Code"];
            Message += " </span> </p>";
            return Message;
        }
        private string BuildGeneratePasswordMessage()
        {

            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>تم انشاء كلمة سر مؤقته للدخول الي حسابك هى  :  </b>";
            Message += "              <br /> <span style='  background-color: #D9534F;border-radius: 0.25em;  color: #FFFFFF; display: block;font-size: 75%; font-weight: 700; line-height: 1; padding:10px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'>";
            Message += MailCriteria["Code"];
            Message += " </span> </p>";
            return Message;
        }
        private string BuildSMSNotWorkingMessage()
        {

            string Message = " <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>خدمة الرسائل متوقفة و ترسل الخطأ التالى  :  </b>";
            Message += "              <br /> <span style='  background-color: #D9534F;border-radius: 0.25em;  color: #FFFFFF; display: block;font-size: 75%; font-weight: 700; line-height: 1; padding:10px; text-align: right;vertical-align: baseline; white-space: nowrap; margin:10px'>";
            Message += MailCriteria["Code"];
            Message += " </span> </p>";
            return Message;
        }

        private string BuildReplyMessage()
        {
            string Message = "  <tr style='background-color: #E4E5E7; width: 100%;'> <td> <p> <h4 style='margin-right:10px;'>  عزيزى العميل , </h4>";
            Message += "<b style='margin-right:10px;'>تم ارسال رد على الرسالة التى ارسلتها الى الادارة </b>";
            Message += " <table style='margin-right:10px; margin-left:10px; margin-top:5px; '>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>عنوان الرسالة</td>";
            Message+="<td>"+MailCriteria["Title"]+"</td></tr>";
            Message += " <tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>التاريخ</td>";
            Message += "<td>" + MailCriteria["Date"] + "</td></tr>";
            Message += "<tr style='background-color:#FEFEC6;'><td style='font-weight: bold; padding: 5px;  text-align: center; width: 10%; vertical-align: top;'>الرسالة</td>";
            Message += "<td>" + MailCriteria["Message"] + "</td></tr>";
            Message += "</table> </p>";
            return Message;
        }

        private string BuildBodyHeader()
        {
            string divHeader = "  <tr style='background-color: #403F41; color: #FFFFFF; margin-top: 0; width: 100%; border-bottom: 3px solid #FF0000;'>";
            divHeader += "   <td> <table style='width:100%'><tr><td><h2 style='margin-right:10px; color: #FFFFFF;'> " + ConfigurationSettings.AppSettings["Name"].ToString() + " </h2> </td>";
            divHeader += " <td  style='margin-top: 10px; float:left;'>";
            divHeader += "   <a href='" + ConfigurationSettings.AppSettings["FaceBook"].ToString() + "' target='_blank' style='float: left;  display: inline-block;margin-right:3px;'>";
            divHeader += " <img src='http://icons.iconarchive.com/icons/yootheme/social-bookmark/32/social-facebook-button-blue-icon.png'></img></a>";
            divHeader += "   <a href='" + ConfigurationSettings.AppSettings["Twitter"].ToString() + "' target='_blank' style='float: left; display: inline-block;margin-right:3px;'>";
            divHeader += "  <img src='http://icons.iconarchive.com/icons/matiasam/ios7-style/32/Twitter-icon.png'></img></a>";
            divHeader += " <a href='" + ConfigurationSettings.AppSettings["Google"].ToString() + "' target='_blank' style='float: left;  display: inline-block;margin-right:3px;'>";
            divHeader += "   <img src='http://icons.iconarchive.com/icons/martz90/circle/32/google-plus-icon.png'></img></a>";
            divHeader += " </td></tr> </table></td> </tr>";
            return divHeader;
        }

        private string BuildMessgaeHeader()
        {
            string Head = "<head>";
            Head += "<title></title>";
            Head += "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'>";
            Head += "</head>";
            return Head;
        }

        private void SetMessageRecievers(MailMessage mailmessage)
        {
            foreach (string to in Recievers)
            {
                mailmessage.To.Add(to);
            }
            foreach (string cc in CC)
            {
                mailmessage.CC.Add(cc);
            }

            foreach (string bc in BC)
            {
                mailmessage.Bcc.Add(bc);
            }
        }

        private System.Net.Mail.SmtpClient ConfigureMailServer()
        {
          //  SmtpServer oServer = new SmtpServer("smtp.emailarchitect.net");

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(ServerName, Port);
            client.Credentials = new NetworkCredential(UserName, Password);
           // client.UseDefaultCredentials = false;
           // client.EnableSsl = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            
           
            return client;
        }

    }
}
