using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateTypeController:IController
    {
        IRealEstateType View;
        public RealEstateTypeController(IRealEstateType view)
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
            BindTypesList();
            View.FillCategoryList(Commons.Context.RealEstateCategories.OrderBy(C => C.Title).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                RealEstateType type = View.FillRealEstateTypeObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(type.Title);
                    Commons.Context.RealEstateTypes.AddObject(type);
                }
                Commons.Context.SaveChanges();
                View.UploadRealEstateIcon();
                BindTypesList();
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
            View.RealEstateTypeID = ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillRealEstateTypeControls(Commons.Context.RealEstateTypes.FirstOrDefault(T => T.ID == ID));
        }

        public void OnDelete(int ID)
        {
            try
            {
                RealEstateType type = Commons.Context.RealEstateTypes.FirstOrDefault(T => T.ID == ID);
                if (type != null)
                {
                    if (type.RealEstates.Count > 0|| type.RealEstateTypeCriterias.Count>0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.RealEstateTypes.DeleteObject(type);
                    Commons.Context.SaveChanges();
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(type.Icon));
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    BindTypesList();
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public RealEstateType OnGetById()
        {
            return Commons.Context.RealEstateTypes.FirstOrDefault(T => T.ID == View.RealEstateTypeID);
        }

        private void BindTypesList()
        {
            View.BindRealEstateTypeList(Commons.Context.RealEstateTypes.OrderBy(T => T.RealEstateCategory.Title).ThenBy(T=>T.Title).ToList());
        }
    }
}
