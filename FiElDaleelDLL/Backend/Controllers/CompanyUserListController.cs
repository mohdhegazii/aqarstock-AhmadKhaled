using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class CompanyUserListController
    {
       ICompanyUserList View;
       public CompanyUserListController(ICompanyUserList view)
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
             RealEstateCompany Company = Commons.Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Commons.Subsciber.CompanyID);
                if (Company != null)
                {
                    View.CompanyID = Company.ID;
                   View.BindList(Company.Subscribers.OrderBy(S=>S.FullName).ToList());
                }
                else
                {
                    View.NotifyUser(Message.UserCompanyNotExist, MessageType.Error);
                }
            }
           
           }
       
       public void OnRemove(int SubscriberID)
       {
           try
           {
               using (BrokerEntities Context = new BrokerEntities())
               {
                   Subscriber subscriber = Context.Subscribers.FirstOrDefault(S => S.ID == SubscriberID);
                   if (subscriber != null)
                   {
                       int Count = subscriber.RealEstates.Count;
                       if (Count <= 0)
                       {
                           RealEstateCompany Company = Context.RealEstateCompanies.FirstOrDefault(C => C.ID == View.CompanyID);
                           Company.CurrentUserNos = Company.CurrentUserNos - 1;
                           subscriber.CompanyID = null;
                           subscriber.IsCompanyAdmin = false;
                           Context.SaveChanges();
                           View.NotifyUser(Message.Delete, MessageType.Success);
                       }
                       else
                       {
                           View.NotifyUser(Message.UserCantBeDeleted, MessageType.Error);
                       }

                   }
                   
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }

       public void OnSetAdmin(int SubscriberID, bool IsAdmin)
       {
           try
           {
               using (BrokerEntities Context = new BrokerEntities())
               {
                   Subscriber subscriber = Context.Subscribers.FirstOrDefault(S => S.ID == SubscriberID);
                   if (subscriber != null)
                   {
                       subscriber.IsCompanyAdmin = IsAdmin;
                       Context.SaveChanges();
                       View.NotifyUser(Message.Save, MessageType.Success);
                   }
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }


       public List<Subscriber> OnNeedDataSource()
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               return Context.Subscribers.Where(S => S.CompanyID == View.CompanyID).OrderBy(S => S.FullName).ToList();
           }
       }
    }
}
