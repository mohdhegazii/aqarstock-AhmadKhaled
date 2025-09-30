using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class SubscriberRealEstate
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public IPagedList<RealEstate> RealEstates{get;set;}
    }
}