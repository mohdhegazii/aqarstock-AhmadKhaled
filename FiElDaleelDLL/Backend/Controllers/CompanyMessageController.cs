using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class CompanyMessageController
    {
           ICompanyMessage View;
           public CompanyMessageController(ICompanyMessage view)
       {
           View = view;
           Commons.Context = new BrokerEntities();
       }
       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "CompanyAdmin"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
           View.BindList(GetMessages());
           //if (HttpContext.Current.Request.RequestContext.RouteData.Values["Me"] != null)
           //{
           //    OnSelectRequest(Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["NotificationID"]));
           //    View.OpenNotification();
           //}
          
       }

       public void OnSelectRequest(int RequestID)
       {
           CompanyMessage request = Commons.Context.CompanyMessages.FirstOrDefault(R => R.ID == RequestID);
           View.FillControls(request);
           request.IsRead = true;
           Commons.Context.SaveChanges();
       }

       public void OnDelete(int RequestID)
       {
           CompanyMessage request = Commons.Context.CompanyMessages.FirstOrDefault(R => R.ID == RequestID);
           if (request != null)
           {
               Commons.Context.CompanyMessages.DeleteObject(request);
               Commons.Context.SaveChanges();
               View.BindList(GetMessages());
               View.NotifyUser(Message.Delete, MessageType.Success);
           }
       }

       public List<CompanyMessage> OnNeedDataSource()
       {
           return GetMessages();
       }

       private List<CompanyMessage> GetMessages()
       {
           return Commons.Context.CompanyMessages.Where(R => R.CompanyID ==Commons.Subsciber.CompanyID)
               .OrderByDescending(R => R.CreatedDate).ToList();
       }
    }
}
