using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class LoginController
    {
       ILogin View;

       public LoginController(ILogin view)
       {
           View = view;
           Commons.Context = new BrokerEntities();
       }

       public void OnViewInitialize()
       {
       
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
       }

       public void OnRegister()
       {
           try
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
                   Membership.CreateUser(subscriber.UserName, subscriber.Password,subscriber.Email);
                   Roles.AddUserToRole(subscriber.UserName, "Subscriber");
                   if (subscriber.IsCompanyAdmin==true)
                   {
                       Roles.AddUserToRole(subscriber.UserName, "CompanyAdmin");
                   }
                   subscriber.ActivationCode = Commons.CreateActivationCode();
                   Commons.Context.Subscribers.AddObject(subscriber);
                   Commons.Context.SaveChanges();
                   Commons.Subsciber = subscriber;
                   Commons.UserName = subscriber.UserName;
                   Dictionary<string,string> Code=new Dictionary<string,string>();
                   Code.Add("Code",subscriber.ActivationCode);
                   Commons.SendEmail(EmailType.ActivateAccount, subscriber.Email, Code);
                    Commons.SendSMS(subscriber.MobileNo, subscriber.ActivationCode);
                   HttpContext.Current.Response.RedirectToRoute("ActivateAccount");
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }

       public void OnLogin(string Username, string password)
       {
           try
           {
               if (Membership.FindUsersByName(Username).Count == 0)
               {
                   View.NotifyUser(Message.UserNameNotExist, MessageType.Error);
                   return;
               }
               if (!Membership.ValidateUser(Username, password) && !FormsAuthentication.Authenticate(Username, password))
               {
                   View.NotifyUser(Message.LoginError, MessageType.Error);
                   return;
               }
               
               Commons.UserName = Username;
               FormsAuthentication.RedirectFromLoginPage(Username, true);
               if (Roles.IsUserInRole(Username, "Admin"))
               {
                   HttpContext.Current.Response.RedirectToRoute("AdminDashboard");
               }
               if (Roles.IsUserInRole(Username, "Subscriber"))
               {
                    //Commons.Subsciber = Commons.Context.Subscribers.FirstOrDefault(S => S.UserName == "A123456a");
                    Commons.Subsciber = Commons.Context.Subscribers.FirstOrDefault(S => S.UserName == Username);
                    if (Commons.Subsciber.ActiveStatusID == (int)Activestatus.Pending)
                   {
                       HttpContext.Current.Response.RedirectToRoute("ActivateAccount");
                   }
                   else
                   {
                       HttpContext.Current.Response.RedirectToRoute("SubscriberDashboard");
                   }
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }

       public void OnForgetPassword(string Username, string Email)
       {
           MembershipUser User = Membership.GetUser(Username);
           if (User== null)
           {
               string username = Membership.GetUserNameByEmail(Email);
               if (username != "" && username != null)
               {
                   User = Membership.GetUser(username);
                   Dictionary<string, string> Code = new Dictionary<string, string>();
                   Code.Add("UserName", username);
                   Code.Add("Password", User.ResetPassword());
                   Commons.SendEmail(EmailType.ForgetPassword, User.Email, Code);
                   View.NotifyUser(Message.PasswordSentToEmail, MessageType.Success);
               }
               else
               {
                   View.NotifyUser(Message.EmailNotRegistered, MessageType.Error);
               }
           }
           else
           {
               Dictionary<string, string> Code = new Dictionary<string, string>();
               Code.Add("UserName", Username);
               Code.Add("Password", User.ResetPassword());
               Commons.SendEmail(EmailType.ForgetPassword, User.Email, Code);
               View.NotifyUser(Message.PasswordSentToEmail, MessageType.Success);
           }
       }
    }
}
