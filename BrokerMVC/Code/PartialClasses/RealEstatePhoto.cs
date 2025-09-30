using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstatePhoto
    {
        public HttpPostedFileBase PhotoFile
        {
            get;
            set;
        }
    }
}