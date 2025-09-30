using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Models.ViewModel
{
    public class MoveRealestates
    {
        public int? OldOwnerID { get; set; }
        public int? NewOwnerID { get; set; }

        public List<SelectListItem> Realestates { get; set; }
    }
}