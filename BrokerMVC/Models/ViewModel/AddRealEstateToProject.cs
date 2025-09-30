using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Models.ViewModel
{
    public class AddRealEstateToProject
    {
        public int? ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLogo { get; set; }
        public List<SelectListItem> Realestates { get; set; }
    }
}