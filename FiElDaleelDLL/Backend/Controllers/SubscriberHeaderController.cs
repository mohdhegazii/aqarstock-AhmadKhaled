using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
  public class SubscriberHeaderController
    {
      ISubscriberHeader View;
      public SubscriberHeaderController(ISubscriberHeader view)
      {
          View = view;
      }
      public void OnViewInitialize()
      {
          if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
          {
              HttpContext.Current.Response.RedirectToRoute("Login");
              return;
          }
          if (Roles.IsUserInRole(Commons.UserName, "CompanyAdmin"))
          {
              View.NavigatetoManagerView();
          }
          using (BrokerEntities Context = new BrokerEntities())
          {
              int NotificationCount = Context.SubscriberNotifications.Count(M => M.SubscriberID==Commons.Subsciber.ID && M.IsRead == false);
              int RequestNo = Context.RealEstatePurchaseRequests.Count(R => R.RealEstate.SubscriberID == Commons.Subsciber.ID && R.IsDeleted == false && R.IsRead == false && (R.IsInquiry==false || R.IsInquiry==null));
              int MsgNo = Context.CompanyMessages.Count(M => M.CompanyID==Commons.Subsciber.CompanyID && M.IsRead == false);
              View.CountUnReadNotification(NotificationCount);
              View.CountUnReadPurchaseRequest(RequestNo);
              View.CountUnReadMessages(MsgNo);
              //View.BindUnReadMessages(Context.SubscriperMessages.Where(M => M.FromSubscriber == false && M.To == Commons.Subsciber.ID
              //                         && M.IsClosed == false && M.IsRead == false).Take(4).ToList());
              //View.BindUnReadRequests(Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.SubscriberID == Commons.Subsciber.ID && R.IsDeleted == false && R.IsRead == false).Take(4).ToList());
          }
      }
    }
}
