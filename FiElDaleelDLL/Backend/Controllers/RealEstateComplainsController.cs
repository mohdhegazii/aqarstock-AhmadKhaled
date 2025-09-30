using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateComplainsController
    {
          IRealEstateComplains View;
          public RealEstateComplainsController(IRealEstateComplains view)
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
           View.BindComplains(GetComplains());
       }

       public void OnSelectRequest(int ComplainId)
       {
           RealEstateComplain Complain = Commons.Context.RealEstateComplains.FirstOrDefault(R => R.ID == ComplainId);
           View.FillComplainControls(Complain);
           Complain.IsRead = true;
           Commons.Context.SaveChanges();
       }

       public void OnDelete(int ComplainId)
       {
           RealEstateComplain Complain = Commons.Context.RealEstateComplains.FirstOrDefault(R => R.ID == ComplainId);
           if (Complain != null)
           {
               Commons.Context.RealEstateComplains.DeleteObject(Complain);
               Commons.Context.SaveChanges();
               View.BindComplains(GetComplains());
               View.NotifyUser(Message.Delete, MessageType.Success);
           }
       }

       public List<RealEstateComplain> OnNeedDataSource()
       {
           return GetComplains();
       }

       private List<RealEstateComplain> GetComplains()
       {
           return Commons.Context.RealEstateComplains.OrderByDescending(R => R.CreatedDate).ToList();
       }
    }
}
