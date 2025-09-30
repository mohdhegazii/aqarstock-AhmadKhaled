using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class CompanyListView
    {
        public string Name { get; set; }
        public List<RealEstateCompany> SpecialCompany { get; set; }
        public IPagedList<RealEstateCompany> ReqularCompany { get; set; }
    }
}