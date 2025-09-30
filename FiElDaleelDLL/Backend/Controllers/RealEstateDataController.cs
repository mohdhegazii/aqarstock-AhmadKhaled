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
   public class RealEstateDataController:IController
    {
       IRealEstateData View;
       RealEstate realestate;
       public RealEstateDataController(IRealEstateData view)
       {
           View = view;
           Commons.Context = new BrokerEntities();
       }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Subscriber") && !Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            View.FillCountryList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
            View.FillCategoryList(Commons.Context.RealEstateCategories.OrderBy(C=>C.Title).ToList());
            View.FillKeywordList(Commons.Context.Keywords.OrderBy(K => K.Title).ToList());
            View.FillPaymentList(Commons.Context.PaymentTypes.OrderBy(P => P.Title).ToList());
            View.FillCurrencyList(Commons.Context.Currencies.OrderBy(C => C.Name).ToList());
            View.FillSaleTypeList(Commons.Context.SaleTypes.OrderBy(S => S.Title).ToList());
            //View.FillBusinessList(Commons.Subsciber.Businesses.ToList());
            if (HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"] == null)
            {
                View.Mode = PageMode.Add;
                View.Navigate();
            }
            else
            {
                View.RealEstateID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["RealEstateID"]);
                View.Mode = PageMode.Edit;
                View.Navigate();
                View.FillRealEstateControls(Commons.Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID));
            }
        }

        public void OnSave()
        {
         
            try
            {
                if (View.Mode == PageMode.Add)
                {
                    realestate = new RealEstate();
                    realestate.Code = Commons.Context.RealEstates.Max(R => R.Code)+1;
                    string random = DateTime.Now.Ticks.ToString();
                    realestate = View.FillRealEstateObject(realestate,random);
                    
                    Commons.Context.RealEstates.AddObject(realestate);
                    Commons.Context.SaveChanges();
                    View.RealEstateID = realestate.ID;
                    // string tmp = realestate.Code.ToString()+"-" + DateTime.Now.ToLongTimeString();
                    View.UploadRealEstatePhoto(realestate.Code,random);
                    View.BindPhotoList(realestate.RealEstatePhotos.ToList());
                    View.Mode = PageMode.EditNew;
                    View.Navigate();
                    if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
                    {
                        LogAction.Log(Modules.RealEstates, subscriberActions.AddNew, realestate.ID, realestate.Title);
                    }
                    View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                }
                else
                {
                    string random = DateTime.Now.Ticks.ToString();
                    realestate = View.FillRealEstateObject(OnGet(),random);
                   // Commons.Context.a.Attach(realestate);
                    Commons.Context.SaveChanges();
                    View.UploadRealEstatePhoto(realestate.Code,random);
                    View.BindPhotoList(realestate.RealEstatePhotos.ToList());
                    if (realestate.ActiveStatusId == (int)Activestatus.Suspended && !Roles.IsUserInRole(Commons.UserName, "Admin"))
                    {
                            LogAction.Log(Modules.RealEstates, subscriberActions.Updated, realestate.ID, realestate.Title);
                         View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                    }
                    else
                    {
                        View.NotifyUser(Message.Save, MessageType.Success);
                    }
                }
           
               
            }
            catch (Exception ex)
            {
                Commons.Context.Detach(realestate);
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }


        public void OnEdit(int ID)
        {
            View.RealEstateID = ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillRealEstateControls(Commons.Context.RealEstates.FirstOrDefault(R => R.ID == ID));
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
        public void OnSetDefault(int PhotoID)
        {
            RealEstatePhoto Photo = Commons.Context.RealEstatePhotos.FirstOrDefault(P => P.ID == PhotoID);
            if (Photo != null)
            {
                Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList().ForEach(P => P.IsDefault = false);
                Photo.IsDefault = true;
                Commons.Context.SaveChanges();
                View.NotifyUser(Message.DefaultPhotoChanged, MessageType.Success);
                View.BindPhotoList(Commons.Context.RealEstatePhotos.Where(P => P.RealEstateID == View.RealEstateID).ToList());
            }
        }
        public void OnPostBack()
        {
            View.FillKeywordList(Commons.Context.Keywords.OrderBy(K => K.Title).ToList());
        }
        public RealEstate OnGet()
        {
            return Commons.Context.RealEstates.FirstOrDefault(R => R.ID == View.RealEstateID);
        }
        public void OnSelectCountry(int CountryID)
        {
            View.FillCityList(Commons.Context.Cities.Where(C => C.CountryID == CountryID).OrderBy(C => C.Name).ToList());
        }
        public void OnSelectCity(int CityID)
        {
            View.FillDistrictList(Commons.Context.Districts.Where(D => D.CityID == CityID).OrderBy(D => D.Name).ToList());
        }
        public void OnSelectCategory(int CategoryID)
        {
            View.FillTypeList(Commons.Context.RealEstateTypes.Where(T => T.RealEstateCategoryId == CategoryID).OrderBy(T => T.Title).ToList());
            View.FillStatusList(Commons.Context.RealEstateStatuses.Where(S => S.RealEstateCategoryID == CategoryID && S.IsSearchVisible==true).OrderBy(S => S.Title).ToList());
        }
        public void OnSelectType(int TypeID)
        {
            View.FillRealEstateTypeCriteriaList(Commons.Context.RealEstateTypeCriterias.Where(TC=>TC.RealEstateTypeID==TypeID).OrderByDescending(TC => TC.ValueType).ThenBy(TC => TC.Title).ToList());
        }
        //public void OnSelectBusiness(int BusinessID)
        //{
        //    bool? IsSingleBranch = Commons.Context.BusinessBranches.First(BB => BB.BusinessID == BusinessID && BB.IsMain == true).IsSingleBranch;
        //    if (IsSingleBranch.HasValue)
        //    {
        //        if (IsSingleBranch.Value == false)
        //        {
        //            View.FillBranchesList(Commons.Context.BusinessBranches.Where(BB => BB.BusinessID == BusinessID && BB.IsMain == false).ToList());
        //        }
        //        else
        //        {
        //            View.FillBranchesList(null);
        //        }
        //    }
        //    else
        //    {
        //        View.FillBranchesList(null);
        //    }
        //}
        public void OnDeleteCriteria(RealEstateCriteria realEstateCriteria)
        {
            Commons.Context.RealEstateCriterias.DeleteObject(realEstateCriteria);
        }
    }
}
