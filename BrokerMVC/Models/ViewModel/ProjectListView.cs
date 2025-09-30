using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class ProjectListView
    {
        public string Name { get; set; }
        public List<RealEstateProject> SpecailProjects { get; set; }
        public IPagedList<RealEstateProject> ReqularProjects { get; set; }
        public Menu Type { get; set; }
    }
}