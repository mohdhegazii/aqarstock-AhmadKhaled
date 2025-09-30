using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public  class NewMessageController
    {
       INewMessage View;
       public NewMessageController(INewMessage view)
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
           View.FillMessageTypesList(Commons.Context.SubscriperMessageTypes.OrderBy(M=>M.Title).ToList());
       }
       public void OnSave()
       {
           try
           {
               SubscriperMessage message = View.FillMessageObject();
               if (View.Mode == PageMode.Add)
               {
                   Commons.Context.SubscriperMessages.AddObject(message);
               }
               Commons.Context.SaveChanges();
               View.Mode = PageMode.Add;
               View.Navigate();
               View.NotifyUser(Message.Save, MessageType.Success);
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }
    }
}
