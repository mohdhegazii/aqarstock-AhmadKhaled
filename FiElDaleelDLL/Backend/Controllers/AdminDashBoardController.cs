using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class AdminDashBoardController
    {
        IAdminDashboard View;
        public AdminDashBoardController(IAdminDashboard view)
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
            View.BindNewObjects(Commons.Context.SubscriberLogs.OrderBy(SL => SL.Date).ToList());
        }
        public void OnSelectModule(int ModuleID)
        {
            if (ModuleID > 0)
            {
                View.BindNewObjects(Commons.Context.SubscriberLogs.Where(SL => SL.ObjectTypeID == ModuleID).OrderBy(SL => SL.Date).ToList());
            }
            else
            {
                View.BindNewObjects(Commons.Context.SubscriberLogs.OrderBy(SL => SL.Date).ToList());
            }
        }
        public List<SubscriberLog> OnNeedDataSource(int ModuleID)
        {
            if (ModuleID > 0)
            {
                return Commons.Context.SubscriberLogs.Where(SL => SL.ObjectTypeID == ModuleID).OrderBy(SL => SL.Date).ToList();
            }
            else
            {
                return Commons.Context.SubscriberLogs.OrderBy(SL => SL.Date).ToList();
            }
        }
    }
}
