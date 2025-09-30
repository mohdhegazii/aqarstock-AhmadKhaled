using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class RealEstateViewController
    {
       IRealEstateView View;
       public RealEstateViewController(IRealEstateView view)
       {
           View = view;
           Commons.Context = new BrokerEntities();
       }
       public void OnViewInitialize()
       {
           using (BrokerDLL.BrokerEntities Context = new BrokerEntities())
           {
               if (!Roles.IsUserInRole(Commons.UserName, "Subscriber"))
               {
                   HttpContext.Current.Response.RedirectToRoute("Login");
                   return;
               }
               if (HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"] != null)
               {
                   View.RealEstateID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"]);
                   RealEstate realestate=Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID);
                   View.FillRealEstateControls(realestate);
                   if (realestate.SubscriberID != Commons.Subsciber.ID)
                   {
                       View.ShowEditControls(false);
                   }
               }
           }
       }

       public void OnDelete()
       {
           try
           {
               RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID);
               if (realestate != null)
               {
                   realestate.RealEstateCriterias.ToList().ForEach(RC => Commons.Context.RealEstateCriterias.DeleteObject(RC));
                   realestate.RealEstatePhotos.ToList().ForEach(P => DeletePhoto(P));
                   realestate.RealEstateKeywords.ToList().ForEach(K => Commons.Context.RealEstateKeywords.DeleteObject(K));
                   realestate.RealEstatePurchaseRequests.ToList().ForEach(K => Commons.Context.RealEstatePurchaseRequests.DeleteObject(K));
                   realestate.RealEstateSuspendeds.ToList().ForEach(S => Commons.Context.RealEstateSuspendeds.DeleteObject(S));
                    realestate.RealestateCatalogProperties.ToList().ForEach(C => Commons.Context.RealestateCatalogProperties.DeleteObject(C));
                    realestate.RealEstateComplains.ToList().ForEach(C => Commons.Context.RealEstateComplains.DeleteObject(C));
                   Commons.Context.RealEstates.DeleteObject(realestate);
                   Commons.Context.SaveChanges();
                   HttpContext.Current.Response.RedirectToRoute("SubscriberDashboard");
               }
           }
           catch (Exception ex)
           { 
           View.NotifyUser(ex.Message,MessageType.Error);
           }
       }

       public List<RealEstatePhoto> OnGetPhotos()
       {
           return Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList();
       }

       private void DeletePhoto(RealEstatePhoto Photo)
       {
           if (Photo.PhotoName != "" && Photo.PhotoName != null)
           {
               System.IO.File.Delete(HttpContext.Current.Server.MapPath(Photo.PhotoName));
           }
           Commons.Context.RealEstatePhotos.DeleteObject(Photo);
       }
    }
}
