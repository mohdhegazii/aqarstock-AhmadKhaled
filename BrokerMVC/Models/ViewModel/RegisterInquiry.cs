using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
 
    public class RegisterInquiry
    {
        public Subscriber Subscriber { get; set; }
        public int? RealestateID { get; set; }
        public int? ProjectID { get; set; }
        public int? CompanyID { get; set; }
        public InquiryType type { get; set; }
    }
}