using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class CompanyUserController
    {
        ICompanyUser View;
        public CompanyUserController(ICompanyUser view)
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
                    View.CompanyId = Company.ID;
                    if (Company.CurrentUserNos >= Company.UserNos)
                    {
                        View.NotifyUser(Message.CompanyInvalidUserNos, MessageType.Error);
                        View.Mode = PageMode.Disable;
                        View.Navigate();
                    }
                    else
                    {
                        View.Mode = PageMode.Add;
                        View.Navigate();
                    }
                }
                else
                {
                    View.NotifyUser(Message.UserCompanyNotExist, MessageType.Error);
                    View.Mode = PageMode.Disable;
                    View.Navigate();
                }
            }
        }

        public void OnCheckUserNameAvailability(string UserName)
        {
            if (Membership.FindUsersByName(UserName).Count > 0)
            {
                View.NotifyUser(Message.UsernameNotAvailable, MessageType.Error);
            }
            else
            {
                View.NotifyUser(Message.UsernameAvailable, MessageType.Success);
            }
        }

        public void OnCheckEmailAvailability(string Email)
        {
            if (Membership.FindUsersByEmail(Email).Count > 0)
            {
                View.NotifyUser(Message.EmailRegistered, MessageType.Error);
            }
            else
            {
                View.NotifyUser(Message.EmailValid, MessageType.Success);
            }
        }

        public void OnRegister()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Subscriber subscriber = View.FillSubscriberObject();
                    if (Membership.FindUsersByName(subscriber.UserName).Count > 0)
                    {
                        View.NotifyUser(Message.UsernameNotAvailable, MessageType.Error);
                        return;
                    }
                    else
                    {
                        if (Membership.FindUsersByEmail(subscriber.Email).Count > 0)
                        {
                            View.NotifyUser(Message.EmailRegistered, MessageType.Error);
                            return;
                        }
                 
                        subscriber.ActivationCode = Commons.CreateActivationCode();
                        Context.Subscribers.AddObject(subscriber);
                        RealEstateCompany Company = Context.RealEstateCompanies.First(C => C.ID == Commons.Subsciber.CompanyID);
                        Company.CurrentUserNos += 1;
                        Context.SaveChanges();
                        Membership.CreateUser(subscriber.UserName, subscriber.Password, subscriber.Email);
                        Roles.AddUserToRole(subscriber.UserName, "Subscriber");
                        Roles.AddUserToRole(subscriber.UserName, "CompanyEmployee");
                        if (subscriber.IsCompanyAdmin == true)
                        {
                            Roles.AddUserToRole(subscriber.UserName, "CompanyAdmin");
                        }
                        Dictionary<string, string> Code = new Dictionary<string, string>();
                        Code.Add("Code", subscriber.ActivationCode);
                        Commons.SendEmail(EmailType.ActivateAccount, subscriber.Email, Code);
                        View.NotifyUser(Message.SaveNewCompanyUser,MessageType.Success);
                        View.Mode=PageMode.Add;
                        View.Navigate();
                      //  HttpContext.Current.Response.RedirectToRoute("ActivateAccount");
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

    }
}
