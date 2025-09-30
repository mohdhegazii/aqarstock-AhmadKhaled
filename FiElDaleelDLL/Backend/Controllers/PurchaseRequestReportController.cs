using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class PurchaseRequestReportController
    {
       IPurchaseRequestReport View;
       public PurchaseRequestReportController(IPurchaseRequestReport view)
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
           GetRequests(DateTime.Today,DateTime.Today.Add(new TimeSpan(11,59,0)),null);
       }

       public void OnSelectRequest(int RequestID)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               RealEstatePurchaseRequest request = Context.RealEstatePurchaseRequests.FirstOrDefault(R => R.ID == RequestID);
               View.FillRequestControls(request);
           }
         
       }

       public void OnSearch(DateTime From, DateTime To, bool? IsRead)
       {
           GetRequests(From, To, IsRead);
       }

       private void  GetRequests(DateTime From,DateTime To, bool? IsRead)
       {
           using(BrokerEntities Context=new BrokerEntities())
           {
               List<RealEstatePurchaseRequest> requests;
               if (IsRead != null)
               {
                   if (IsRead == true)
                   {
                       requests = Context.RealEstatePurchaseRequests.Where(R => R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == true && R.IsInquiry==false)
                   .OrderByDescending(R => R.Date).ToList();
                   }
                   else
                   {
                       requests = Context.RealEstatePurchaseRequests.Where(R => R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == false)
                   .OrderByDescending(R => R.Date).ToList();
                   }
               }
               else
               {
                   requests = Context.RealEstatePurchaseRequests.Where(R => R.IsDeleted == false && R.Date >= From && R.Date <= To)
                                  .OrderByDescending(R => R.Date).ToList();
               }
               View.BindPurchaseRequest(requests);
           }
       }
    }
}
