using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class RemoveSuspended
    {
        public int? SuspendReasonID { get; set; }
        public string From{get;set;}
        public string To { get; set; }

    }
}