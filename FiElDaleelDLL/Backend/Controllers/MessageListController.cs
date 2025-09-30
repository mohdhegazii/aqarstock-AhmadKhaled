using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class MessageListController
    {
        IMessageList View;
        public MessageListController(IMessageList view)
        {
            View = view;
            Commons.Context = new BrokerEntities();
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            View.BindMessagesList(GetMessages());
        }

        public void OnSelectMessage(int MessageID)
        {
            HttpContext.Current.Response.RedirectToRoute("SubscriberViewMessage", new { MessageID = MessageID });
        }
        public List<SubscriperMessage> OnNeedDataSource()
        {
            return GetMessages();
        }
        public void OnDelete(int MessageID)
        {
            SubscriperMessage Message = Commons.Context.SubscriperMessages.FirstOrDefault(M =>M.ID == MessageID);
            if (Message != null)
            {
                Message.IsClosed = true;
                Commons.Context.SaveChanges();
                View.BindMessagesList(GetMessages());
                View.NotifyUser(BrokerDLL.Message.Delete, MessageType.Success);
            }
        }
        private static List<SubscriperMessage> GetMessages()
        {
            return Commons.Context.SubscriperMessages.Where(M =>M.To==Commons.Subsciber.ID && M.FromSubscriber == false
                            && M.IsClosed == false).OrderByDescending(M => M.CreatedDate).ToList();
        }
    }
}
