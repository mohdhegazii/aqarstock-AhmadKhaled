using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class RemoveSuspendedRealestatesController
    {
          IRemoveSuspendedRealEstates View;
          public RemoveSuspendedRealestatesController(IRemoveSuspendedRealEstates view)
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
        
            //View.Mode = PageMode.Add;
            //View.Navigate();
        }

        public void OnRemove(DateTime date)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                List<RealEstate> Realestates=Context.RealEstates.Where(R=>R.ActiveStatusId==(int)Activestatus.Suspended && R.CreatedDate<=date).ToList();
                foreach (RealEstate realestate in Realestates)
                {
                    realestate.RealEstateCriterias.ToList().ForEach(RC => Context.RealEstateCriterias.DeleteObject(RC));
                    realestate.RealEstatePhotos.ToList().ForEach(P => DeletePhoto(P, Context));
                    realestate.RealEstateKeywords.ToList().ForEach(K => Context.RealEstateKeywords.DeleteObject(K));
                    realestate.RealEstatePurchaseRequests.ToList().ForEach(K => Context.RealEstatePurchaseRequests.DeleteObject(K));
                    realestate.RealEstateSuspendeds.ToList().ForEach(S => Context.RealEstateSuspendeds.DeleteObject(S));
                    realestate.RealestateCatalogProperties.ToList().ForEach(S => Context.RealestateCatalogProperties.DeleteObject(S));
                    Context.RealEstates.DeleteObject(realestate);
                    Context.SaveChanges();
                }
                View.NotifyUser(Message.Delete, MessageType.Success);
            }
        }
        private void DeletePhoto(RealEstatePhoto Photo, BrokerEntities Context)
        {
            if (Photo.PhotoName != "" && Photo.PhotoName != null)
            {
                if(System.IO.File.Exists(HttpContext.Current.Server.MapPath(Photo.PhotoName)))
                {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath(Photo.PhotoName));
                }
            }
            Context.RealEstatePhotos.DeleteObject(Photo);
        }
    }
}
