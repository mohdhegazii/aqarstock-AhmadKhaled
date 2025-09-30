using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class ModelListView
    {
       public RealEstateProject Project { get; set; }
       public List<RealEstateProjectModel> Models { get; set; }
    }
}