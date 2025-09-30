using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateStatusController:IController
    {
        IRealEstateStatus View;
        public RealEstateStatusController(IRealEstateStatus view)
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
            BindStatusList();
            View.FillCategoryList(Commons.Context.RealEstateCategories.OrderBy(C => C.Title).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                RealEstateStatus status = View.FillRealEstateStatusObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(status.Title);
                    Commons.Context.RealEstateStatuses.AddObject(status);
                }
                Commons.Context.SaveChanges();
                BindStatusList();
                View.Mode = PageMode.Add;
                View.Navigate();
                View.NotifyUser(Message.Save, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {
            View.RealEstateStatusID = ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillRealEstateStatusControls(Commons.Context.RealEstateStatuses.FirstOrDefault(S => S.ID == ID));
        }

        public void OnDelete(int ID)
        {
            try
            {
                RealEstateStatus status = Commons.Context.RealEstateStatuses.FirstOrDefault(S => S.ID == ID);
                if (status != null)
                {
                    if (status.RealEstates.Count > 0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.RealEstateStatuses.DeleteObject(status);
                    Commons.Context.SaveChanges();
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    BindStatusList();
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public RealEstateStatus OnGetById()
        {
            return Commons.Context.RealEstateStatuses.FirstOrDefault(S => S.ID == View.RealEstateStatusID);
        }

        private void BindStatusList()
        {
            View.BindRealEstateStatusList(Commons.Context.RealEstateStatuses.OrderBy(S => S.RealEstateCategory.Title).ThenBy(S => S.Title).ToList());
        }
    }
}
