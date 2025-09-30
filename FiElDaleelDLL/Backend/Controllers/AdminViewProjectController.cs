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
   public class AdminViewProjectController
    {
         IAdminViewProject View;
         public AdminViewProjectController(IAdminViewProject view)
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
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"] != null)
            {
                View.ProjectID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"]);
                View.SubscriberLogID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["SubscriberLogID"]);
                View.FillControls(Commons.Context.RealEstateProjects.FirstOrDefault(R => R.ID == View.ProjectID));
                View.FillSuspendReasonList(Commons.Context.SuspendReasons.OrderBy(SR => SR.Title).ToList());
            }
        }
        public void OnActivate()
        {
            try
            {
                RealEstateProject Project = Commons.Context.RealEstateProjects.FirstOrDefault(I => I.ID == View.ProjectID);
                Project.ActiveStatusID = (int)Activestatus.Active;
                Project.SuspendReasonID = null;
                Project.SuspendMessage = "";

                List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.ProjectID).ToList();
                if (Logs != null && Logs.Count > 0)
                {
                    Logs.ForEach(Log => Commons.Context.SubscriberLogs.DeleteObject(Log));
                }
                SubscriberNotification notification = new SubscriberNotification();
                notification.CreatedDate = DateTime.Now;
                notification.Description = "تم مراجعة بيانات " + Project.Title + " و الموافقة عليه";
                notification.IsRead = false;
                notification.ObjectID = Project.ID;
                notification.ObjectTypeID = (int)Modules.Projects;
                notification.ObjectName = Project.Title;
                notification.SubscriberID = Project.SubscriberID;
                notification.Title = "تم الموافقة على " + Project.Title;
                Commons.Context.SubscriberNotifications.AddObject(notification);
                Commons.Context.SaveChanges();
                Email email = new Email();
                email.EmailType = EmailType.ActivateBusiness;
                email.HasAttachment = false;
                email.MailCriteria = new Dictionary<string, string>();
                email.MailCriteria.Add("Title", Project.Title);
                email.Recievers = new List<string>();
                email.Recievers.Add(Project.Subscriber.Email);
                email.Send();
                SiteMapGenerator.AddProjectNode(Project.ID);
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
                RealEstateProject Project = Commons.Context.RealEstateProjects.FirstOrDefault(I => I.ID == View.ProjectID);
                SuspendReason reason = Commons.Context.SuspendReasons.FirstOrDefault(SR => SR.ID == SuspendReasonID);
                Project.ActiveStatusID = (int)Activestatus.Suspended;
                Project.SuspendReasonID = SuspendReasonID;
                Project.SuspendMessage = SuspendMessage;
                Project.RealEstateCompany.CurrentProjectNos -= 1;
                List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.ProjectID).ToList();
                if (Logs != null && Logs.Count > 0)
                {
                    Logs.ForEach(log => Commons.Context.SubscriberLogs.DeleteObject(log));
                }
                    SubscriberNotification notification = new SubscriberNotification();
                    notification.CreatedDate = DateTime.Now;
                    notification.Description = "تم حجب بيانات " + Project.Title + " بعد مراجعتها<br/>";
                    notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
                    notification.Description += "تفاصيل: " + SuspendMessage;
                    notification.IsRead = false;
                    notification.ObjectID = Project.ID;
                    notification.ObjectTypeID = (int)Modules.Projects;
                    notification.ObjectName = Project.Title;
                    notification.SubscriberID = Project.SubscriberID;
                    notification.Title = "تم حجب بيانات  " + Project.Title;
                    Commons.Context.SubscriberNotifications.AddObject(notification);
                    Commons.Context.SaveChanges();
                    Email email = new Email();
                    email.EmailType = EmailType.SuspendBusiness;
                    email.HasAttachment = false;
                    email.MailCriteria = new Dictionary<string, string>();
                    email.MailCriteria.Add("Title", Project.Title);
                    email.MailCriteria.Add("SuspendReason", reason.Title);
                    email.MailCriteria.Add("Message", SuspendMessage);
                    email.Recievers = new List<string>();
                    email.Recievers.Add(Project.Subscriber.Email);
                    email.Send();
                View.NotifyUser(Message.SuspendedObject, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnSetAdPackage(int AdPackageID)
        {
            RealEstateProject Project = Commons.Context.RealEstateProjects.FirstOrDefault(I => I.ID == View.ProjectID);
            Project.AdPackageID = AdPackageID;
            Commons.Context.SaveChanges();
            View.NotifyUser(Message.ClosedSuccessfully, MessageType.Success);
        }
    }
}
