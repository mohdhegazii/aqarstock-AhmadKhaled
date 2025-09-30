using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Controllers
{
    public class AdminViewCompanyController
    {
        IAdminViewCompany View;
        public AdminViewCompanyController(IAdminViewCompany view)
        {
            View = view;
            Commons.Context = new BrokerEntities();
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["CompanyID"] != null)
            {
                View.CompanyID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["CompanyID"]);
                View.SubscriberLogID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["SubscriberLogID"]);
                View.FillControls(Commons.Context.RealEstateCompanies.FirstOrDefault(R => R.ID == View.CompanyID));
                View.FillSuspendReasonList(Commons.Context.SuspendReasons.OrderBy(SR => SR.Title).ToList());
            }
        }
        public void OnActivate()
        {
            try
            {
                RealEstateCompany Company = Commons.Context.RealEstateCompanies.FirstOrDefault(I => I.ID == View.CompanyID);
                Company.ActivateStatusID = (int)Activestatus.Active;
                Company.SuspendReasonID = null;
                Company.SuspendMessage = "";
              //  Commons.Context.SaveChanges();
                List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.CompanyID).ToList();
                if (Logs != null && Logs.Count > 0)
                {
                    Logs.ForEach(Log => Commons.Context.SubscriberLogs.DeleteObject(Log));
                }
                foreach (Subscriber subscriber in Company.Subscribers.Where(S => S.IsCompanyAdmin == true))
                {
                    SubscriberNotification notification = new SubscriberNotification();
                    notification.CreatedDate = DateTime.Now;
                    notification.Description = "تم مراجعة بيانات " + Company.Title + " و الموافقة عليه";
                    notification.IsRead = false;
                    notification.ObjectID = Company.ID;
                    notification.ObjectTypeID = (int)Modules.Companies;
                    notification.ObjectName = Company.Title;
                    notification.SubscriberID = subscriber.ID;
                    notification.Title = "تم الموافقة على " + Company.Title;
                    Commons.Context.SubscriberNotifications.AddObject(notification);
                    Commons.Context.SaveChanges();
                    Email email = new Email();
                    email.EmailType = EmailType.ActivateBusiness;
                    email.HasAttachment = false;
                    email.MailCriteria = new Dictionary<string, string>();
                    email.MailCriteria.Add("Title", Company.Title);
                    email.Recievers = new List<string>();
                    email.Recievers.Add(subscriber.Email);
                    email.Send();
                }
                SiteMapGenerator.AddCompanyNode(Company.ID);
                View.NotifyUser(Message.ActivateObject, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
        public void OnSuspend(int SuspendReasonID, string SuspendMessage)
        {
            try
            {
                RealEstateCompany company = Commons.Context.RealEstateCompanies.FirstOrDefault(I => I.ID == View.CompanyID);
                SuspendReason reason = Commons.Context.SuspendReasons.FirstOrDefault(SR => SR.ID == SuspendReasonID);
                company.ActivateStatusID = (int)Activestatus.Suspended;
                company.SuspendReasonID = SuspendReasonID;
                company.SuspendMessage = SuspendMessage;
                List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.CompanyID).ToList();
                if (Logs != null && Logs.Count > 0)
                {
                    Logs.ForEach(log => Commons.Context.SubscriberLogs.DeleteObject(log));
                }
                foreach (Subscriber subscriber in company.Subscribers.Where(S => S.IsCompanyAdmin == true))
                {
                    SubscriberNotification notification = new SubscriberNotification();
                    notification.CreatedDate = DateTime.Now;
                    notification.Description = "تم حجب بيانات " + company.Title + " بعد مراجعتها<br/>";
                    notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
                    notification.Description += "تفاصيل: " + SuspendMessage;
                    notification.IsRead = false;
                    notification.ObjectID = company.ID;
                    notification.ObjectTypeID = (int)Modules.Companies;
                    notification.ObjectName = company.Title;
                    notification.SubscriberID = subscriber.ID;
                    notification.Title = "تم حجب بيانات  " + company.Title;
                    Commons.Context.SubscriberNotifications.AddObject(notification);
                    Commons.Context.SaveChanges();
                    Email email = new Email();
                    email.EmailType = EmailType.SuspendBusiness;
                    email.HasAttachment = false;
                    email.MailCriteria = new Dictionary<string, string>();
                    email.MailCriteria.Add("Title", company.Title);
                    email.MailCriteria.Add("SuspendReason", reason.Title);
                    email.MailCriteria.Add("Message", SuspendMessage);
                    email.Recievers = new List<string>();
                    email.Recievers.Add(subscriber.Email);
                    email.Send();
                }
                View.NotifyUser(Message.SuspendedObject, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
    }
}
