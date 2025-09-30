using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class SubscriberReportController
    {
       ISubscriberReport View;
       public SubscriberReportController(ISubscriberReport view)
       {
           View = view;
       }

       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
           DateTime From=DateTime.Today;
           DateTime To=DateTime.Today.Add(new TimeSpan(23,59,0));
          View.BindGrid( GetSubscribers(From, To,null));
       }
       public void OnSearch(DateTime From, DateTime To, bool? IsActive)
       { 
       View.BindGrid(GetSubscribers(From,To,IsActive));
       }
       private  List<Subscriber> GetSubscribers(DateTime From, DateTime To,bool? IsActive)
       {
           List<Subscriber> Subscribers;
           using (BrokerEntities Context = new BrokerEntities())
           {
               if (IsActive != null)
               {
                   if (IsActive == true)
                   {
                       Subscribers = Context.Subscribers.Where(S => S.CreatedDate <= To && S.CreatedDate >= From && S.ActiveStatusID == (int)Activestatus.Active).OrderByDescending(S=>S.CreatedDate).ToList();
                   }
                   else
                   {
                       Subscribers = Context.Subscribers.Where(S => S.CreatedDate <= To && S.CreatedDate >= From && S.ActiveStatusID != (int)Activestatus.Active).OrderByDescending(S => S.CreatedDate).ToList();
                   }
               }
               else
               {
                   Subscribers = Context.Subscribers.Where(S => S.CreatedDate <= To && S.CreatedDate >= From).OrderByDescending(S => S.CreatedDate).ToList();
               }
           }
           return Subscribers;
       }
    }
}
