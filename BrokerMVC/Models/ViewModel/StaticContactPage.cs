using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class StaticContactPage
    {
        public Pages PageType { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}