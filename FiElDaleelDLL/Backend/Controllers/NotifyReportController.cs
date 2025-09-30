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
   public class NotifyReportController
    {
       INotifyReport View;
       public NotifyReportController(INotifyReport view)
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
               View.FillCountryList(Context.Countries.OrderBy(C => C.Name).ToList());
               View.FillRealEstateTypeList(Context.RealEstateTypes.OrderBy(T => T.Title).ToList());
               View.FillSaleTypeList(Context.SaleTypes.OrderBy(S => S.Title).ToList());
           }

       }

       public void OnSelectCountry(int CountryID)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               View.FillCityList(Context.Cities.Where(C => C.CountryID == CountryID).OrderBy(C => C.Name).ToList());
           }
       }

       public void OnSelectCity(int CityID)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               View.FillDistrictList(Context.Districts.Where(C => C.CityID == CityID).OrderBy(C => C.Name).ToList());
           }
       }
       public void OnSelectRequest(int RequestID)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               NotifyService request = Context.NotifyServices.FirstOrDefault(R => R.ID == RequestID);
               View.FillRequestControls(request);
           }
       }
       public void OnSearch()
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               View.BindList(Search(Context));
           }
       }

       public List<NotifyService> OnNeedDataSource()
       {
           //using (BrokerEntities Context = new BrokerEntities())
           //{
               return Search(Commons.Context);
          // }
       }
       private List<NotifyService> Search(BrokerEntities Context)
       {
           RealEstateSearchCriteria Criteria = View.FillSearchCriteriaObject();
           if (Criteria != null)
           {
            
                   return Context.NotifyServices.Where(R => (R.RealEstateTypeID == Criteria.RealEstateTypeID || Criteria.RealEstateTypeID == 0)
                         && (R.DistrictID == Criteria.DistrictID || Criteria.DistrictID == 0)
                         && (R.CountryID == Criteria.CountryID || Criteria.CountryID == 0)
                         && (R.CityID == Criteria.CityID || Criteria.CityID == 0)
                         && (R.SaleTypeID == Criteria.SaleTypeID || Criteria.SaleTypeID == 0)
                         && (R.Price >= Criteria.Price || Criteria.Price == 0)
                         && (R.Area >= Criteria.Area || Criteria.Area == 0)
                         && (R.Date >= Criteria.FromDate || Criteria.FromDate == DateTime.MinValue)
                         && (R.Date <= Criteria.ToDate || Criteria.ToDate == DateTime.MinValue)
                         ).Distinct().OrderByDescending(R => R.Date).ToList();
               
           }
           else
           {
               return null;
           }
       }
    }
}
