using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
  public  class RealEstatePurchaseRequestController
    {
         IRealEstatePurchaseRequest View;
         public RealEstatePurchaseRequestController(IRealEstatePurchaseRequest view)
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
           View.BindPurchaseRequest(GetRequests());
           if (HttpContext.Current.Request.RequestContext.RouteData.Values["RequestID"] != null)
           {
               OnSelectRequest(Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["RequestID"]));
               View.OpenRequest();
           }
          
       }

       public void OnSelectRequest(int RequestID)
       {
           RealEstatePurchaseRequest request = Commons.Context.RealEstatePurchaseRequests.FirstOrDefault(R => R.ID == RequestID);
           View.FillRequestControls(request);
           request.IsRead = true;
           Commons.Context.SaveChanges();
       }

       public void OnDelete(int RequestID)
       {
           RealEstatePurchaseRequest request = Commons.Context.RealEstatePurchaseRequests.FirstOrDefault(R => R.ID == RequestID);
           if (request != null)
           {
               request.IsDeleted = true;
               Commons.Context.SaveChanges();
               View.BindPurchaseRequest(GetRequests());
               View.NotifyUser(Message.Delete, MessageType.Success);
           }
       }

       public List<RealEstatePurchaseRequest> OnNeedDataSource()
       {
           return GetRequests();
       }

       private List<RealEstatePurchaseRequest> GetRequests()
       {
           return Commons.Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.SubscriberID ==Commons.Subsciber.ID && R.IsDeleted == false&& (R.IsInquiry==false|| R.IsInquiry == null))
               .OrderByDescending(R => R.Date).ToList();
       }
    }
}
