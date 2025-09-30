using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class UserViewData
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public SupscriptionType Subscriptiontype { get; set; }

        public int? ActiveStatusID { get; set; }

        public Suspend SuspendData { get; set; }
        public RealEstateCompany Company { get; set; }
     //   public List<SubscriberNotification> Notifications { get; set; }
    }
}