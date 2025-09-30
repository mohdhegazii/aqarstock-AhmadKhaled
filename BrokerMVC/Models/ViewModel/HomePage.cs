using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class HomePage
    {
        public RealEstateProject BannerProject { get; set; }
        public List<RealEstateProject> Projects { get; set; }
        public RealEstate SpecialProp { get; set; }
        public List<RealEstate> SpecialPropList { get; set; }
    }
}