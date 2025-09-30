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
   public class PartnerListController:IController
    {
       IPartnerList View;
       public PartnerListController(IPartnerList view)
       {
           View = view;
       }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            using (BrokerEntities Context = new BrokerEntities())
            { 
            View.BindGrid(Context.Partners.OrderBy(P=>P.Title).ToList());
            }
        }

        public void OnSave()
        {
            throw new NotImplementedException();
        }

        public void OnEdit(int ID)
        {
            HttpContext.Current.Response.RedirectToRoute("Partner", new { PartnerID = ID });
        }

        public void OnDelete(int ID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Partner partner = Context.Partners.FirstOrDefault(P => P.ID == ID);
                    if (partner != null)
                    {
                        Context.Partners.DeleteObject(partner);
                        Context.SaveChanges();
                        if (System.IO.File.Exists(partner.Logo))
                        {
                            System.IO.File.Delete(partner.Logo);
                        }
                        SiteMapGenerator.DeleteGeneralNode(partner.Code);
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindGrid(Context.Partners.OrderBy(P => P.Title).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
    }
}
