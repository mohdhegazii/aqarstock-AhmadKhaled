using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class ChangeRealEstateSubscriberController
    {
        IChangeRealEstateSubscriber View;
        public ChangeRealEstateSubscriberController(IChangeRealEstateSubscriber view)
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
        }
        public void OnSelectSubscriber(int SubscriberID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.BindRealEstateList(Context.RealEstates.Where(R => R.SubscriberID == SubscriberID).ToList());
              //  View.BindSubscriberList(Context.Subscribers.Where(S => S.CompanyID == Commons.Subsciber.CompanyID).ToList());

            }
        }
        public List<RealEstate> OnNeedDataSource(int SubscriberID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
               return Context.RealEstates.Where(R => R.SubscriberID == SubscriberID).ToList();
                //  View.BindSubscriberList(Context.Subscribers.Where(S => S.CompanyID == Commons.Subsciber.CompanyID).ToList());

            }
        }
        public void OnMoveRealEstates(List<int> RealEstatesID,int OldSubscriberID, int NewSubscriberID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                List<RealEstate> Realestates = Context.RealEstates.Where(R => RealEstatesID.Contains(R.ID)).ToList();
                Realestates.ForEach(R => R.SubscriberID = NewSubscriberID);
                Context.SaveChanges();
                View.BindRealEstateList(Context.RealEstates.Where(R => R.SubscriberID == OldSubscriberID).ToList());
                View.NotifyUser(Message.Save,MessageType.Success);
            }
        }
    }
}
