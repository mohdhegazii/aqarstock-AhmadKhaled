using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateCategoryController:IController
    {
        IRealEstateCategory View;
        public RealEstateCategoryController(IRealEstateCategory view)
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
            BindCategoriesList();
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                RealEstateCategory category = View.FillCategoryObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(category.Title);
                    Commons.Context.RealEstateCategories.AddObject(category);
                }
                Commons.Context.SaveChanges();
                View.UploadCategoryIcon();
                BindCategoriesList();
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
            View.CategoryId = ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillCategoryControls(Commons.Context.RealEstateCategories.FirstOrDefault(C => C.ID == ID));
        }

        public void OnDelete(int ID)
        {
            try
            {
                RealEstateCategory Category = Commons.Context.RealEstateCategories.FirstOrDefault(C => C.ID == ID);
                if (Category != null)
                {
                    if (Category.RealEstates.Count > 0|| Category.RealEstateTypes.Count>0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.RealEstateCategories.DeleteObject(Category);
                    Commons.Context.SaveChanges();
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(Category.Icon));
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    BindCategoriesList();
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public RealEstateCategory OnGetById()
        {
            return Commons.Context.RealEstateCategories.FirstOrDefault(C => C.ID == View.CategoryId);
        }

        private void BindCategoriesList()
        {
            View.BindCategoriesList(Commons.Context.RealEstateCategories.OrderBy(C => C.Title).ToList());
        }
    }
}
