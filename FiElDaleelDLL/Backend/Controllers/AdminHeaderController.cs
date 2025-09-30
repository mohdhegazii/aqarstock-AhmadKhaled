using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
    public class AdminHeaderController
    {
        IAdminHeader View;
        public AdminHeaderController(IAdminHeader view)
        {
            View = view;
        }
        public void OnViewInitialize()
        {
            int MsgCount = Commons.Context.SubscriperMessages.Count(M => M.FromSubscriber == true
                                && M.IsClosed == false && M.IsRead == false);
            int ComplainsCount = Commons.Context.RealEstateComplains.Count(C => C.IsRead == false);
            View.FillControls(MsgCount,ComplainsCount);
        }

    }
}
