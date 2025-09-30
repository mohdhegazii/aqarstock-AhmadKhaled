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
    public class RealEstatePhotoController:IController
    {
        IRealEstatePhotos View;
        public RealEstatePhotoController(IRealEstatePhotos view)
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
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"] != null)
            {
                View.RealEstateID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"]);
                View.BindPhotoList(Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList());
            }
        }

        public void OnSave()
        {
            try
            {
                using(BrokerEntities Context=new BrokerEntities())
                {
                RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID);
                string tmp = realestate.Code.ToString()+"-" + DateTime.Now.ToLongTimeString();
                RealEstatePhoto Photo = View.FillRealEstatePhotoObject(tmp);
                
                if (realestate != null)
                {
                    if (Photo.IsDefault.Value)
                    {
                        realestate.RealEstatePhotos.ToList().ForEach(P => P.IsDefault = false);
                    }
                    if (realestate.ActiveStatusId != (int)Activestatus.Suspended)
                    {
                        realestate.ActiveStatusId = (int)Activestatus.Updated;
                    }
                    realestate.RealEstatePhotos.Add(Photo);
                    Context.SaveChanges();
                    View.UploadRealEstatePhoto(tmp);
                    View.BindPhotoList(realestate.RealEstatePhotos.ToList()); 
                }
                    View.Mode = PageMode.Add;
                    View.Navigate();
                    View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                    LogAction.Log(Modules.RealEstates, subscriberActions.AddPhoto, realestate.ID, realestate.Title);
               
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {

        }

        public void OnDelete(int ID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    RealEstatePhoto Photo = Context.RealEstatePhotos.FirstOrDefault(P => P.ID == ID);
                    if (Photo != null)
                    {
                        RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID);
                        Context.RealEstatePhotos.DeleteObject(Photo);
                        if (realestate.ActiveStatusId == (int)Activestatus.Suspended)
                        {
                            LogAction.Log(Modules.RealEstates, subscriberActions.Updated, realestate.ID, realestate.Title);
                        }
                        Context.SaveChanges();
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Photo.PhotoName));
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindPhotoList(Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnGetBusinessPhotos(int RealEstateID)
        {

            View.RealEstateID = RealEstateID;
            View.BindPhotoList(Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList());
        }
        public void OnSetDefault(int PhotoID)
        {
            RealEstatePhoto Photo = Commons.Context.RealEstatePhotos.FirstOrDefault(P => P.ID == PhotoID);
            if (Photo != null)
            {
                Commons.Context.RealEstatePhotos.Where(P=>P.RealEstateID==View.RealEstateID).ToList().ForEach(P => P.IsDefault = false);
                Photo.IsDefault = true;
                Commons.Context.SaveChanges();
                View.NotifyUser(Message.DefaultPhotoChanged, MessageType.Success);
                View.BindPhotoList(Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList());
            }
        }
    }
}
