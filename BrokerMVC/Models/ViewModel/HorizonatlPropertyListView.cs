using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class HorizonatlPropertyListView
    {
        public string Name { get; set; }
        public RealEstate SpecailProperty { get; set; }
        public List<RealEstate> ReqularProperties { get; set; }
        public Menu Type { get; set; }
    }
}