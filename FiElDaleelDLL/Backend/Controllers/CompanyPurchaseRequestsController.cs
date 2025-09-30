using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class CompanyPurchaseRequestsController
    {
        ICompanyPurchaseRequests View;
        public CompanyPurchaseRequestsController(ICompanyPurchaseRequests view)
        {
            View = view;
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "CompanyAdmin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillSubscriberList(Context.Subscribers.Where(S => S.CompanyID == Commons.Subsciber.CompanyID).ToList());
            }
           GetRequests(DateTime.Today, DateTime.Today.Add(new TimeSpan(11, 59, 0)), null, null);
        }

        public void OnSelectRequest(int RequestID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstatePurchaseRequest request = Context.RealEstatePurchaseRequests.FirstOrDefault(R => R.ID == RequestID);
                View.FillRequestControls(request);
            }

        }

        public void OnSearch(DateTime From, DateTime To,int? subscriberID, bool? IsRead)
        {
           GetRequests(From, To, subscriberID, IsRead);
        }

        public void OnNeedDataSource(DateTime From, DateTime To, int? SubscriberID, bool? IsRead)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                List<RealEstatePurchaseRequest> requests;
                if (IsRead != null)
                {
                    if (IsRead == true)
                    {
                        requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID == Commons.Subsciber.CompanyID
                        && (R.RealEstate.SubscriberID == SubscriberID || SubscriberID == null) && R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == true)
                        .OrderByDescending(R => R.Date).ToList();
                    }
                    else
                    {
                        requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID == Commons.Subsciber.CompanyID
                       && (R.RealEstate.SubscriberID == SubscriberID || SubscriberID == null) && R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == false)
                       .OrderByDescending(R => R.Date).ToList();
                    }
                }
                else
                {
                    requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID == Commons.Subsciber.CompanyID
                   && (R.RealEstate.SubscriberID == SubscriberID || SubscriberID == null) && R.IsDeleted == false && R.Date >= From && R.Date <= To)
                   .OrderByDescending(R => R.Date).ToList();
                }

                View.BindPurchaseRequest(requests);

            }
        }

        private void GetRequests(DateTime From, DateTime To, int? SubscriberID, bool? IsRead)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                List<RealEstatePurchaseRequest> requests;
                if (IsRead != null)
                {
                    if (IsRead == true)
                    {
                        requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID==Commons.Subsciber.CompanyID
                        &&(R.RealEstate.SubscriberID==SubscriberID ||SubscriberID==null ) && R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == true)
                        .OrderByDescending(R => R.Date).ToList();
                    }
                    else
                    {
                        requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID == Commons.Subsciber.CompanyID
                       && (R.RealEstate.SubscriberID == SubscriberID || SubscriberID == null) && R.IsDeleted == false && R.Date >= From && R.Date <= To && R.IsRead == false)
                       .OrderByDescending(R => R.Date).ToList();
                    }
                }
                else
                {
                    requests = Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.Subscriber.CompanyID == Commons.Subsciber.CompanyID
                   && (R.RealEstate.SubscriberID == SubscriberID || SubscriberID == null) && R.IsDeleted == false && R.Date >= From && R.Date <= To)
                   .OrderByDescending(R => R.Date).ToList();
                }

                 View.BindPurchaseRequest(requests);
              
            }
        }
    }
}
