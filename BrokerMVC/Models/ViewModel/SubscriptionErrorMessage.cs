using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class SubscriptionErrorMessage
    {
        public SupscriptionType type { get; set; }
        public int? TotalNo { get; set; }
        public int? CurrentNo { get; set; }
    }
}