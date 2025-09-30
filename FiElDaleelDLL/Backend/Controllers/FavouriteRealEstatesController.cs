using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class FavouriteRealEstatesController
    {
       IFavouriteRealEstates View;
       public FavouriteRealEstatesController(IFavouriteRealEstates view)
       {
           View = view;
       }
       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
       
         View.BindRealEstateList(GetRealEstates());
       }

       public List<RealEstate> OnNeedDataSource()
       {
           return GetRealEstates();
       }
       private List<RealEstate> GetRealEstates()
       {
           List<RealEstate> realestates=new List<RealEstate>();
           Commons.Subsciber.SubscriberFavouriteRealEstates.ToList().ForEach(FR => realestates.Add(FR.RealEstate));
           return realestates;
       }

    }
}
