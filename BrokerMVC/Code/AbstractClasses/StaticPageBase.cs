using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class StaticPageBase
    {
        [AllowHtml]
        string Content { get; set; }
        [AllowHtml]
        string EngContent { get; set; }
    }
}