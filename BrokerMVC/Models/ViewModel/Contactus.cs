using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class Contactus
    {
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPhone { get; set; }
        public string SenderCountry { get; set; }
        public string Message { get; set; }
    }
}