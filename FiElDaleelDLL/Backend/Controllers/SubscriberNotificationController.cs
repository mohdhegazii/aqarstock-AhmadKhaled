using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class SubscriberNotificationController
    {
            ISubscriberNotification View;
            public SubscriberNotificationController(ISubscriberNotification view)
       {
           View = view;
           Commons.Context = new BrokerEntities();
       }
       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
           View.BindList(GetNotifications());
           if (HttpContext.Current.Request.RequestContext.RouteData.Values["NotificationID"] != null)
           {
               OnSelectRequest(Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["NotificationID"]));
               View.OpenNotification();
           }
          
       }

       public void OnSelectRequest(int RequestID)
       {
           SubscriberNotification request = Commons.Context.SubscriberNotifications.FirstOrDefault(R => R.ID == RequestID);
           View.FillNotificationControls(request);
           request.IsRead = true;
           Commons.Context.SaveChanges();
       }

       public void OnDelete(int RequestID)
       {
           SubscriberNotification request = Commons.Context.SubscriberNotifications.FirstOrDefault(R => R.ID == RequestID);
           if (request != null)
           {
               Commons.Context.SubscriberNotifications.DeleteObject(request);
               Commons.Context.SaveChanges();
               View.BindList(GetNotifications());
               View.NotifyUser(Message.Delete, MessageType.Success);
           }
       }

       public List<SubscriberNotification> OnNeedDataSource()
       {
           return GetNotifications();
       }

       private List<SubscriberNotification> GetNotifications()
       {
           return Commons.Context.SubscriberNotifications.Where(R => R.SubscriberID ==Commons.Subsciber.ID)
               .OrderByDescending(R => R.CreatedDate).ToList();
       }
    }
}
