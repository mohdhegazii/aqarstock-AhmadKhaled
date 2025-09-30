using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateTypeCriteriaController:IController
    {
        IRealEstateTypeCriteria View;
        public RealEstateTypeCriteriaController(IRealEstateTypeCriteria view)
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
            BindTypeCriteraList();
            View.FillCategoryList(Commons.Context.RealEstateCategories.OrderBy(C => C.Title).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                RealEstateTypeCriteria criteria = View.FillRealEstateTypeCriteriaObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(criteria.Title);
                    Commons.Context.RealEstateTypeCriterias.AddObject(criteria);
                }
                Commons.Context.SaveChanges();
                BindTypeCriteraList();
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
            View.RealEstateCriteriaID = ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillRealEstateTypeCriteriaControls(Commons.Context.RealEstateTypeCriterias.FirstOrDefault(TC => TC.ID == ID));
        }

        public void OnDelete(int ID)
        {
            try
            {
                RealEstateTypeCriteria criteria = Commons.Context.RealEstateTypeCriterias.FirstOrDefault(TC => TC.ID == ID);
                if (criteria != null)
                {
                    if (criteria.RealEstateCriterias.Count > 0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.RealEstateTypeCriterias.DeleteObject(criteria);
                    Commons.Context.SaveChanges();
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    BindTypeCriteraList();
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public RealEstateTypeCriteria OnGetById()
        {
            return Commons.Context.RealEstateTypeCriterias.FirstOrDefault(TC => TC.ID == View.RealEstateCriteriaID);
        }

        public void OnSelectCategory(int CategoryID)
        {
            View.FillTypeList(Commons.Context.RealEstateTypes.Where(T => T.RealEstateCategoryId == CategoryID).OrderBy(T => T.Title).ToList());
        }

        private void BindTypeCriteraList()
        {
            View.BindRealEstateTypeCriteriaList(Commons.Context.RealEstateTypeCriterias.OrderBy(TC => TC.RealEstateType.Title).ThenBy(TC => TC.Title).ToList());
        }

        public object OnNeedDatasource()
        {
            return Commons.Context.RealEstateTypeCriterias.OrderBy(TC => TC.RealEstateType.Title).ThenBy(TC => TC.Title).ToList();
        }
    }
}
