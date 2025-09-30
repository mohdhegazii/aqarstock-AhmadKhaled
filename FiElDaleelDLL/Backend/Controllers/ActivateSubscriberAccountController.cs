using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class ActivateSubscriberAccountController
    {
        IActivateSubscriberAccount View;
        public ActivateSubscriberAccountController(IActivateSubscriberAccount view)
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
        }
        public void OnActivate(string Code)
        {
            try
            {
                if (Code == Commons.Subsciber.ActivationCode)
                {
                    using (BrokerDLL.BrokerEntities Context = new BrokerEntities())
                    {
                        Subscriber sub = Context.Subscribers.FirstOrDefault(S => S.ID == Commons.Subsciber.ID);
                        if(sub!=null)
                        {
                            sub.ActivationCode = "";
                            sub.ActiveStatusID = (int)Activestatus.Active;
                            Context.SaveChanges();
                        }
                    Commons.Subsciber.ActiveStatusID = (int)Activestatus.Active;
                    Commons.Subsciber.ActivationCode = "";

                }
                    HttpContext.Current.Response.RedirectToRoute("SubscriberDashboard");
                }
                else
                {
                    View.NotifyUser(Message.AccountActivationFailed, MessageType.Error);
                }
            }
            catch (Exception ex)
            { 
            View.NotifyUser(ex.Message,MessageType.Error);
            }
        }
        public void OnSendNewActivationCode()
        {
            try
            {
                Commons.Subsciber.ActivationCode = Commons.CreateActivationCode();
                Commons.Context.SaveChanges();
                Dictionary<string, string> Code = new Dictionary<string, string>();
                Code.Add("Code", Commons.Subsciber.ActivationCode);
                Commons.SendEmail(EmailType.ActivateAccount, Commons.Subsciber.Email, Code);
                Commons.SendSMS(Commons.Subsciber.MobileNo, Commons.Subsciber.ActivationCode);
                View.NotifyUser(Message.ActivationCodeSent, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
    }
}
