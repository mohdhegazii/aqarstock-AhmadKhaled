using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class AdminMessageListController
    {
        IAdminMessageList View;
        public AdminMessageListController(IAdminMessageList view)
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
            View.BindMessagesList(GetMessages());
        }

        public void OnSelectMessage(int MessageID)
        { 
        HttpContext.Current.Response.RedirectToRoute("ViewMessage",new {MessageID=MessageID});
        }
        public List<SubscriperMessage> OnNeedDataSource()
        {
            return GetMessages();
        }
        private static List<SubscriperMessage> GetMessages()
        {
            return Commons.Context.SubscriperMessages.Where(M => M.FromSubscriber == true
                            && M.IsClosed == false).OrderBy(M => M.CreatedDate).ToList();
        }
    }
}
