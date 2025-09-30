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
    public class RealEstateListController
    {
        IRealEstateList View;
        public RealEstateListController(IRealEstateList view)
        {
            View = view;
            Commons.Context = new BrokerEntities();
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            View.Mode = PageMode.View;
            View.BindRealEstateList(OnNeedDataSource());
            View.FillRealEstateTypeList(Commons.Context.RealEstateTypes.OrderBy(T => T.Title).ToList());
            View.FillDistrictList(Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name)
                .ToList());
         
        }
   
        public void OnSearch()
        {
            View.Mode = PageMode.Search;
           View.BindRealEstateList( SearchRealEstate());
        }

        private List<RealEstate> SearchRealEstate()
        {
            RealEstateSearchCriteria Criteria = View.FillSearchCriteriaObject();
            if (Criteria != null)
            {
              return  Commons.Context.RealEstates.Where(R => R.SubscriberID==Commons.Subsciber.ID && (R.Code == Criteria.Code || Criteria.Code == 0)
                    && (R.RealEstateTypeID == Criteria.RealEstateTypeID || Criteria.RealEstateTypeID == 0)
                    && (R.DistrictID == Criteria.DistrictID || Criteria.DistrictID == 0))
                    .OrderByDescending(R => R.CreatedDate).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<RealEstate> OnNeedDataSource()
        {
            if (View.Mode == PageMode.Search)
            {
                return SearchRealEstate();
            }
            else
            {
                //Commons.Context.Refresh(System.Data.Objects.RefreshMode.StoreWins, Commons.Subsciber);
                return Commons.Context.RealEstates.Where(R => R.SubscriberID == Commons.Subsciber.ID).OrderByDescending(R => R.CreatedDate).ToList();
               // return Commons.Subsciber.RealEstates.OrderByDescending(R => R.CreatedDate).ToList();
            }
        }
    }
}
