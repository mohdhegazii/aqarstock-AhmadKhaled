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
   public class AdminViewMessageController
    {
       IAdminViewMessage View;
       public AdminViewMessageController(IAdminViewMessage view)
       {
       View=view;
       Commons.Context = new BrokerEntities();
       }
       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
           if (HttpContext.Current.Request.RequestContext.RouteData.Values["MessageID"] != null)
           {
               int id=Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["MessageID"]);
               SubscriperMessage Message = Commons.Context.SubscriperMessages.FirstOrDefault(M => M.ID == id);
         
               if (Message != null)
               {
                   Message.IsRead = true;
                   Commons.Context.SaveChanges();
                   List<SubscriperMessage> prevMsgs = new List<SubscriperMessage>();
                   if (Message.ParentMessageID != null && Message.ParentMessageID != 0)
                   {
                       View.MainMessageID = Message.ParentMessageID.Value;
                       View.MessageID = Message.ID;
                       View.FillMessageTitleControl(Message.SubscriperParentMessage.Title);
                       prevMsgs.Add(Message.SubscriperParentMessage);
                       prevMsgs.AddRange (Message.SubscriperParentMessage.SubscriperReplyMessages);
                       View.BindPrevMessagesControls(prevMsgs.OrderBy(M=>M.CreatedDate).ToList());
                   }
                   else
                   {
                       View.MainMessageID = Message.ID;
                       View.MessageID = Message.ID;
                       View.FillMessageTitleControl(Message.Title);
                       prevMsgs.Add(Message);
                       View.BindPrevMessagesControls(prevMsgs);
                   }
               }
           }
       }

       public void OnSend()
       {
           try
           {
               SubscriperMessage Message = View.FillMessageObject();
               SubscriperMessage MainMessage = Commons.Context.SubscriperMessages.FirstOrDefault(M => M.ID == View.MainMessageID);
               Message.Title = "Re: " + MainMessage.Title;
               if (MainMessage.FromSubscriber == true)
               {
                   Message.To = MainMessage.From;
               }
               else
               {
                   Message.To=MainMessage.SubscriperReplyMessages.FirstOrDefault(R => R.FromSubscriber == true).From;
               }
               MainMessage = Commons.Context.SubscriperMessages.First(M => M.ID == View.MessageID);
               MainMessage.IsClosed = true;
               Commons.Context.SubscriperMessages.AddObject(Message);
               Commons.Context.SaveChanges();
               Subscriber subscriber = Commons.Context.Subscribers.FirstOrDefault(S => S.ID == Message.To);
               Email email = new Email();
               email.EmailType = EmailType.ReplyMessage;
               email.HasAttachment = false;
               email.Recievers = new List<string>();
               email.Recievers.Add(subscriber.Email);
               email.MailCriteria = new Dictionary<string, string>();
               email.MailCriteria.Add("Title", Message.Title);
               email.MailCriteria.Add("Date", Message.CreatedDate.ToString());
               email.MailCriteria.Add("Message", Message.Body);
               email.Send();
               HttpContext.Current.Response.RedirectToRoute("MessagesList");
               View.NotifyUser(BrokerDLL.Message.Send, MessageType.Success);
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }
       public string OnGetSubscriberName(int SubscriberID)
       {
           return Commons.Context.Subscribers.FirstOrDefault(S => S.ID == SubscriberID).FullName;
       }
    }
}
