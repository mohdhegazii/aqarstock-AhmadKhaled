using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Controllers
{
    [RequireHttps]
    public class BaseController : Controller
    {

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;

            // Attempt to read the culture cookie from Request
            if (cultureName == null)
                cultureName = "ar";// Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            if (RouteData.Values["culture"] as string != cultureName)
            {

                // Force a valid culture in the URL
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too

                // Redirect user
                //Response.RedirectToRoute(RouteData.Values);
            }


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture =
   Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.Calendar = new GregorianCalendar();

            return base.BeginExecuteCore(callback, state);
        }
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    var ex = filterContext.Exception;
        //    filterContext.ExceptionHandled = true;

        //    var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

        //    //filterContext.Result = new ViewResult()
        //    //{

        //    //    ViewName = "Error"//,
        //    //                      //   ViewData = new ViewDataDictionary(model)
        //    //};

        //}

    }
}