using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
   public class CatalogCategoryController : IController
    {
        ICatalogCategory View;
        public CatalogCategoryController(ICatalogCategory view)
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
            View.BindList(Commons.Context.CatalogCategories.OrderBy(C => C.Name).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();

        }

        public void OnSave()
        {
            try
            {
                CatalogCategory Category = View.FillCategoryObject();
                if (View.Mode == PageMode.Add)
                {
                    //Commons.SaveKeyword(Category.Name);

                    CatalogCategory Cat = Commons.Context.CatalogCategories.FirstOrDefault(C => C.Name.Trim() == Category.Name.Trim());
                    if(Cat==null)
                    { 
                    Commons.Context.CatalogCategories.AddObject(Category);
                    }
                    else
                    {
                        View.NotifyUser(Message.AlreadyExist, MessageType.Error);
                        return;
                    }
                }
                Commons.Context.SaveChanges();
                View.BindList(Commons.Context.CatalogCategories.OrderBy(C => C.Name).ToList());
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
            View.CategoryID = ID;
            View.FillCategoryControls(Commons.Context.CatalogCategories.FirstOrDefault(C => C.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                CatalogCategory category = Commons.Context.CatalogCategories.FirstOrDefault(C => C.ID == ID);
                if (category != null)
                {
                    if (category.RealEstateCatalogs.Count > 0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.CatalogCategories.DeleteObject(category);
                    Commons.Context.SaveChanges();
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    View.BindList(Commons.Context.CatalogCategories.OrderBy(C => C.Name).ToList());

                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public CatalogCategory OnGet()
        {
            return Commons.Context.CatalogCategories.FirstOrDefault(C => C.ID == View.CategoryID);
        }

        public List<CatalogCategory> OnNeedDataSource()
        {
            return Commons.Context.CatalogCategories.OrderBy(C => C.Name).ToList();
        }
    }
}
