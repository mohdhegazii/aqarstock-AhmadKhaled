using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
    public class CatalogListController
    {
        ICatalogList View;
        public CatalogListController(ICatalogList view)
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
             //   View.BindList(Context.RealEstateCatalogs.OrderByDescending(C => C.Date).ToList());
                View.FillCategoryList(Context.CatalogCategories.OrderBy(C => C.Name).ToList());
            }
        }
        public void OnEdit(int CatalogID)
        {
            HttpContext.Current.Response.RedirectToRoute("EditCatalog", new { CatalogID=CatalogID});
        }
        public void OnFilterList()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.BindList(Context.RealEstateCatalogs.Where(C => C.CategoryID == View.CategoryID).OrderByDescending(C => C.Date).ToList());
                    }
        }
        public void OnDelete(int CatalogID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    RealEstateCatalog Catalog = Context.RealEstateCatalogs.First(C => C.ID == CatalogID);
                    if (Catalog != null)
                    {
                        Catalog.RealestateCatalogProperties.ToList().ForEach(C => Context.DeleteObject(C));
                        Catalog.RealestateCatalogTags.ToList().ForEach(T => Context.DeleteObject(T));
                        if (Directory.Exists(Catalog.PhotoURL))
                        {
                            Directory.Delete(Catalog.PhotoURL);
                        }
                        Context.RealEstateCatalogs.DeleteObject(Catalog);
                        Context.SaveChanges();
                        View.BindList(Context.RealEstateCatalogs.Where(C=>(C.CategoryID==View.CategoryID||View.CategoryID==0)).OrderByDescending(C => C.Date).ToList());
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            { View.NotifyUser(ex.Message, MessageType.Error); }
        }

        public void OnNeedDatasource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                //View.BindList(Context.RealEstateCatalogs.OrderByDescending(C=>C.Date).ToList());
                View.BindList(Context.RealEstateCatalogs.Where(C => (C.CategoryID == View.CategoryID || View.CategoryID == 0)).OrderByDescending(C => C.Date).ToList());
            }
        }
    }
}
