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
     public  class AdminRealEstateListController
    {
           IAdminRealEstateList View;
           public AdminRealEstateListController(IAdminRealEstateList view)
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
            View.FillRealEstateCategoryList(Commons.Context.RealEstateCategories.OrderBy(T => T.Title).ToList());
            View.FillDistrictList(Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name)
                .ToList());
            View.FillSaleTypeList(Commons.Context.SaleTypes.OrderBy(S=>S.Title).ToList());
            View.FillSubscriberList(Commons.Context.Subscribers.OrderBy(S => S.FullName).ToList());
        }

        public void OnSelectCategory(int CategoryID)
        {
            View.FillRealEstateStatusList(Commons.Context.RealEstateStatuses.Where(RS => RS.RealEstateCategoryID == CategoryID).OrderBy(RS => RS.Title).ToList());
            View.FillRealEstateTypeList(Commons.Context.RealEstateTypes.Where(T => T.RealEstateCategoryId == CategoryID).OrderBy(T => T.Title).ToList());
        }

        public void OnSearch()
        {
           View.BindRealEstateList( SearchRealEstate());
        }

        private List<RealEstate> SearchRealEstate()
        {
            RealEstateSearchCriteria Criteria = View.FillSearchCriteriaObject();
            if (Criteria != null)
            {
              return  Commons.Context.RealEstates.Where(R => (R.Code == Criteria.Code || Criteria.Code == 0)
                  &&(R.RealEstateCategoryID==Criteria.RealEstateCategoryID || Criteria.RealEstateCategoryID==0)
                  &&(R.RealEstateStatusID==Criteria.RealEstateStatusID || Criteria.RealEstateStatusID==0)
                  && (R.RealEstateTypeID == Criteria.RealEstateTypeID || Criteria.RealEstateTypeID == 0)
                    && (R.DistrictID == Criteria.DistrictID || Criteria.DistrictID == 0)
                    && (R.SaleTypeId==Criteria.SaleTypeID || Criteria.SaleTypeID==0)
                    &&(R.SubscriberID==Criteria.SubscriberID  || Criteria.SubscriberID==0)
                    &&(R.CreatedDate>=Criteria.FromDate || Criteria.FromDate==DateTime.MinValue)
                    &&(R.CreatedDate<=Criteria.ToDate || Criteria.ToDate==DateTime.MinValue)
                    ).OrderByDescending(R => R.CreatedDate).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<RealEstate> OnNeedDataSource()
        {
                return SearchRealEstate();
        }
    }
}
