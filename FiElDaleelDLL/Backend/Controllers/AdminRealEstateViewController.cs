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
    public class AdminRealEstateViewController
    {
       IAdminRealEstateView View;
       public AdminRealEstateViewController(IAdminRealEstateView view)
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
           if (HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"] != null)
           {
               View.RealEstateID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"]);
               View.SubscriberLogID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["SubscriberLogID"]);
               View.FillRealEstateControls(Commons.Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID));
               View.FillSuspendReasonList(Commons.Context.SuspendReasons.OrderBy(SR => SR.Title).ToList());
           }
       }
       public void OnClose()
       {
           RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(I => I.ID == View.RealEstateID);
           realestate.IsSold = true;
           Commons.Context.SaveChanges();
           View.NotifyUser(Message.ClosedSuccessfully, MessageType.Success);
       }
       public void OnSetSpecialOffer(bool IsSpecial)
       {
           RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(I => I.ID == View.RealEstateID);
           realestate.IsSpecialOffer = IsSpecial;
           Commons.Context.SaveChanges();
           View.NotifyUser(Message.ClosedSuccessfully, MessageType.Success);
       }
       public void OnActivate()
       {
           try
           {
               RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(I => I.ID == View.RealEstateID);
               realestate.ActiveStatusId = (int)Activestatus.Active;
               List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.RealEstateID).ToList();
               if (Logs != null && Logs.Count>0)
               {
                   Logs.ForEach(Log=>Commons.Context.SubscriberLogs.DeleteObject(Log));
               }
               RealEstateSuspended susspended = Commons.Context.RealEstateSuspendeds.FirstOrDefault(IS => IS.RealEstateID == realestate.ID);
               if (susspended != null)
               {
                   Commons.Context.RealEstateSuspendeds.DeleteObject(susspended);
               }
               SubscriberNotification notification = new SubscriberNotification();
               notification.CreatedDate = DateTime.Now;
               notification.Description = "تم مراجعة بيانات " + realestate.Title + " و الموافقة عليه";
               notification.IsRead = false;
               notification.ObjectID = realestate.ID;
               notification.ObjectTypeID = (int)Modules.RealEstates;
               notification.ObjectName = realestate.Title;
               notification.SubscriberID = realestate.SubscriberID;
               notification.Title = "تم الموافقة على " + realestate.Title;
               Commons.Context.SubscriberNotifications.AddObject(notification);
               Commons.Context.SaveChanges();
               Email email = new Email();
               email.EmailType = EmailType.ActivateBusiness;
               email.HasAttachment = false;
               email.MailCriteria = new Dictionary<string, string>();
               email.MailCriteria.Add("Title", realestate.Title);
               email.Recievers = new List<string>();
               email.Recievers.Add(realestate.Subscriber.Email);
               if (realestate.UseContactInfo == false)
               {
                   email.Recievers.Add(realestate.OwnerEmail);
               }
               email.Send();
               SiteMapGenerator.AddRealEstateNde(realestate.ID);
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
               RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(I => I.ID == View.RealEstateID);
               SuspendReason reason = Commons.Context.SuspendReasons.FirstOrDefault(SR => SR.ID == SuspendReasonID);
               realestate.ActiveStatusId = (int)Activestatus.Suspended;
               List<SubscriberLog> Logs = Commons.Context.SubscriberLogs.Where(L => L.ObjectID == View.RealEstateID).ToList();
               if (Logs != null && Logs.Count>0)
               {
                   Logs.ForEach(log=>Commons.Context.SubscriberLogs.DeleteObject(log));
               }
               RealEstateSuspended suspended = new RealEstateSuspended();
               suspended.RealEstateID = realestate.ID;
               suspended.SuspendReasonId = SuspendReasonID;
               suspended.Message = SuspendMessage;
               Commons.Context.RealEstateSuspendeds.AddObject(suspended);
               SubscriberNotification notification = new SubscriberNotification();
               notification.CreatedDate = DateTime.Now;
               notification.Description = "تم حجب بيانات " + realestate.Title + " بعد مراجعتها<br/>";
               notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
               notification.Description += "تفاصيل: " + SuspendMessage;
               notification.IsRead = false;
               notification.ObjectID = realestate.ID;
               notification.ObjectTypeID = (int)Modules.RealEstates;
               notification.ObjectName = realestate.Title;
               notification.SubscriberID = realestate.SubscriberID;
               notification.Title = "تم حجب بيانات  " + realestate.Title;
               Commons.Context.SubscriberNotifications.AddObject(notification);
               Commons.Context.SaveChanges();
               Email email = new Email();
               email.EmailType = EmailType.SuspendBusiness;
               email.HasAttachment = false;
               email.MailCriteria = new Dictionary<string, string>();
               email.MailCriteria.Add("Title", realestate.Title);
               email.MailCriteria.Add("SuspendReason", reason.Title);
               email.MailCriteria.Add("Message", SuspendMessage);
               email.Recievers = new List<string>();
               email.Recievers.Add(realestate.Subscriber.Email);
               if (realestate.UseContactInfo == false)
               {
                   email.Recievers.Add(realestate.OwnerEmail);
               }
               email.Send();
               View.NotifyUser(Message.SuspendedObject, MessageType.Success);
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }
    }
}
