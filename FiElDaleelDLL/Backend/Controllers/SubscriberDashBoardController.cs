using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class SubscriberDashBoardController
    {
       ISubscriberDashboard View;
       public SubscriberDashBoardController(ISubscriberDashboard view)
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
           if (Commons.Subsciber.ActiveStatusID == (int)Activestatus.Pending)
           {
               HttpContext.Current.Response.RedirectToRoute("ActivateAccount");
               return;
           }
         View.BindRealEstateList(GetRealEstates());
         //int Count = Commons.Context.SubscriperMessages.Count(M => M.FromSubscriber == false && M.To==Commons.Subsciber.ID
         //                    && M.IsClosed == false && M.IsRead == false);
         //int RequestNo = Commons.Context.RealEstatePurchaseRequests.Count(R => R.RealEstate.SubscriberID == Commons.Subsciber.ID && R.IsDeleted == false && R.IsRead==false);
         //View.FillControls(Count,RequestNo);
       }


       private List<RealEstate> GetRealEstates()
       {
           //Commons.Context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Commons.Subsciber);
           return Commons.Context.RealEstates.Where(R => R.SubscriberID == Commons.Subsciber.ID).OrderByDescending(R=>R.CreatedDate).Take(9).ToList();
       }


    }
}
