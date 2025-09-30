using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BrokerMVC
{
    public enum SMSMessages
    {
        [EnumValue("كود استعادة كلمة المرور لحسابك على الموقع: ")]
        ForgetPassword,
        [EnumValue("كود تفعيل حسابك على الموقع: ")]
        ActivateCode
    }
    public enum SMSLanguage
    {
        E,
        A
    }
    public class SMS
    {
        string _Text;
        SMSLanguage _Lang;
        string _Receiver;
        string Sender
        {
            get
            {
                return ConfigurationSettings.AppSettings["SMSFrom"].ToString();
            }
        }
        string UserName
        {
            get
            {
                return ConfigurationSettings.AppSettings["SMSUser"].ToString();
            }
        }
        string Password
        {
            get
            {
                return ConfigurationSettings.AppSettings["SMSPassword"].ToString();
            }
        }

        public string Text
        {
            get
            {
                return _Text;
            }

            set
            {
                _Text = value;
            }
        }

        public SMSLanguage Lang
        {
            get
            {
                return _Lang;
            }

            set
            {
                _Lang = value;
            }
        }

        public string Receiver
        {
            get
            {
                return _Receiver;
            }

            set
            {
                _Receiver = value;
            }
        }
        public bool Send()
        {
            SMSServiceReference.ServiceSoapClient service = new SMSServiceReference.ServiceSoapClient();
            int r = service.SendSMS(UserName, Password, Text, Lang.ToString(), Sender, Receiver);
            if (r == -5)
            {
                Email Cemail = new Email();
                Cemail.EmailType = EmailType.SMSNotWorking;
                Cemail.HasAttachment = false;
                Cemail.MailCriteria = new Dictionary<string, string>();
                Cemail.MailCriteria.Add("Code", r.ToString());
                Cemail.Recievers = new List<string>();
                Cemail.Recievers.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
                Cemail.BC = new List<string>();
                Cemail.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
                Cemail.Send();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}