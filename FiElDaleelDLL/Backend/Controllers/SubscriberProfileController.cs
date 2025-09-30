using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class SubscriberProfileController
    {
       ISubscriberProfile View;
       public SubscriberProfileController(ISubscriberProfile view)
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
           View.FillSubsciperControls();
       }
       public void OnSave()
       {
           try
           {
               using (BrokerEntities Context = new BrokerEntities())
               {
                   Subscriber subscriber = Context.Subscribers.FirstOrDefault(S => S.ID == Commons.Subsciber.ID);
                  subscriber= View.FillSubscriperObject(subscriber);
                   if (subscriber.IsCompanyAdmin == true && Roles.IsUserInRole(subscriber.UserName, "CompanyAdmin") == false)
                   {
                       Roles.AddUserToRole(subscriber.UserName, "CompanyAdmin");
                   }
                   if (subscriber.IsCompanyAdmin == false && Roles.IsUserInRole(subscriber.UserName, "CompanyAdmin") == true)
                   {
                       Roles.RemoveUserFromRole(subscriber.UserName, "CompanyAdmin");
                   }
                   Context.SaveChanges();
                   if (subscriber.ChangePassword)
                   {
                       MembershipUser User = Membership.GetUser(subscriber.UserName);
                       User.ChangePassword(subscriber.Password, subscriber.NewPassword);
                   }
                   Commons.Subsciber = subscriber;
                   View.NotifyUser(Message.Save, MessageType.Success);
                   View.ClearPasswordControle();
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }
    }
}
