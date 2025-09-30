using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace BrokerMVC.Models.ViewModel
{
    public class PropertyListView
    {
        public string Name { get; set; }
        public List<RealEstate> SpecailProperties { get; set; }
        public IPagedList<RealEstate> ReqularProperties { get; set; }
        public Menu Type { get; set; }
    }
}