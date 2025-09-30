using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class SuspendedRealEstateReportController
    {
       ISuspendedRealEstatesReport View;
       public SuspendedRealEstateReportController(ISuspendedRealEstatesReport view)
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
           View.FillReasonList(Context.SuspendReasons.OrderBy(S=>S.Title).ToList());
           }
       }
       public void OnSearch(int ReasonId, DateTime FromDate, DateTime ToDate)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               List<RealEstateSuspended> SuspendedRealEstates;
               if (ReasonId == 0)
               {
                   SuspendedRealEstates = Context.RealEstateSuspendeds.Where(SR => SR.RealEstate.CreatedDate >= FromDate && SR.RealEstate.CreatedDate <= ToDate).OrderByDescending(RS => RS.RealEstate.CreatedDate).ToList();
               }
               else
               {
                   SuspendedRealEstates = Context.RealEstateSuspendeds.Where(SR => SR.RealEstate.CreatedDate >= FromDate && SR.RealEstate.CreatedDate <= ToDate && SR.SuspendReasonId==ReasonId).OrderByDescending(RS => RS.RealEstate.CreatedDate).ToList();
               }
               View.BindList(SuspendedRealEstates);
           }
       }

       public void OnDelete(int id)
       {
           try
           {
               RealEstate realestate = Commons.Context.RealEstates.FirstOrDefault(R => R.ID == id);
               if (realestate != null)
               {
                   realestate.RealEstateCriterias.ToList().ForEach(RC => Commons.Context.RealEstateCriterias.DeleteObject(RC));
                   realestate.RealEstatePhotos.ToList().ForEach(P => DeletePhoto(P));
                   realestate.RealEstateKeywords.ToList().ForEach(K => Commons.Context.RealEstateKeywords.DeleteObject(K));
                   realestate.RealEstatePurchaseRequests.ToList().ForEach(K => Commons.Context.RealEstatePurchaseRequests.DeleteObject(K));
                   realestate.RealEstateSuspendeds.ToList().ForEach(S => Commons.Context.RealEstateSuspendeds.DeleteObject(S));
                   Commons.Context.RealEstates.DeleteObject(realestate);
                   Commons.Context.SaveChanges();
                   HttpContext.Current.Response.RedirectToRoute("SubscriberDashboard");
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }

       private void DeletePhoto(RealEstatePhoto Photo)
       {
           if (Photo.PhotoName != "" && Photo.PhotoName != null)
           {
               if(System.IO.File.Exists(HttpContext.Current.Server.MapPath(Photo.PhotoName)))
               {
               System.IO.File.Delete(HttpContext.Current.Server.MapPath(Photo.PhotoName));
               }
           }
           Commons.Context.RealEstatePhotos.DeleteObject(Photo);
       }

    }
}
