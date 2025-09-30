using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Models.ViewModel
{
    public class Criteria
    {
        public int? ID { get; set; }
        public string RealestateName { get; set; }

        public List<RealEstateTypeCriteria> TypeCriterias { get; set; }
        public List<RealEstateCriteria> Criterias { get; set; }
    }
}