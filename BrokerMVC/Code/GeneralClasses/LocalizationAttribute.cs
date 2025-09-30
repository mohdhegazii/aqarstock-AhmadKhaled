
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC
{
    public class LocalizationAttribute: ActionFilterAttribute
    {
        private string _DefaultLanguage = "ar";

        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext!=null)
            {
                if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(SkipCustomnAttribute), false).Any())
                {
                    Thread.CurrentThread.CurrentCulture =
                      Thread.CurrentThread.CurrentUICulture = new CultureInfo(Commons.Culture);
                    return;
                }
                string lang = (string)filterContext.RouteData.Values["culture"] ?? Commons.Culture;//_DefaultLanguage;
                Thread.CurrentThread.CurrentCulture =
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();
                if (lang != Commons.Culture)
            {
                try
                {
                      //  HttpContext.Current.Response.Cookies.Set(new HttpCookie("culture", lang));
                      //  Commons.Culture = lang;
                        
                    //    Thread.CurrentThread.CurrentCulture =
                    //Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                     //   Commons.Culture = lang;
                    
                }
                catch (Exception e)
                {
                 //   throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }
            }
        }
    }
}