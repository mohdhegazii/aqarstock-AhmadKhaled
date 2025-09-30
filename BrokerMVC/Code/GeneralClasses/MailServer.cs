using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.GeneralClasses
{
    public static class MailServer
    {
       private static string FromMail
        {
            get
            {
                return ConfigurationSettings.AppSettings["MailFrom"].ToString();
            }
        }
        private static string FromName
        {
            get
            {
                return ConfigurationSettings.AppSettings["Name"].ToString();
            }
        }
        public static string From
        {
            get
            {
                return FromName + " <" + FromMail + ">";
            }
        }
        public static string BCC
        {
            get
            {
                return ConfigurationSettings.AppSettings["MonitorEMail"].ToString();
            }
        }
        public static string To
        {
            get
            {
                return ConfigurationSettings.AppSettings["ContactUsEMail"].ToString();
            }
        }
    }
}