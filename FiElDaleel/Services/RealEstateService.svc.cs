using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BrokerDLL.Serializable;
using System.Web.Script.Serialization;
using System.Configuration;
using System.ServiceModel.Activation;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RealEstateService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RealEstateService : IRealEstateService
    {

        public List<RealEstateType> GetRealEstateTypes()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<RealEstateType> Types = new List<RealEstateType>();
                Context.RealEstateTypes.OrderBy(RT => RT.Title).ToList()
                    .ForEach(RT => Types.Add(new RealEstateType(RT.ID, RT.RealEstateCategoryId.Value, RT.Title)));
                return Types;
            }
        }


        public List<BrokerDLL.Serializable.RealEstate> GetRealEstates(string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }


        public List<RealEstateCategory> GetRealEstateCategories()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<RealEstateCategory> Categories = new List<RealEstateCategory>();
                Context.RealEstateCategories.OrderBy(C => C.Title).ToList()
                    .ForEach(C => Categories.Add(new RealEstateCategory(C.ID, C.Title)));
                return Categories;
            }
        }

        public List<RealEstateType> GetRealEstateTypesByCategory(string RealEstateCategoryID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<RealEstateType> Types = new List<RealEstateType>();
                int categoryId = Convert.ToInt32(RealEstateCategoryID);
                Context.RealEstateTypes.Where(RT => RT.RealEstateCategoryId == categoryId)
                     .OrderBy(RT => RT.Title).ToList().ForEach(RT => Types.Add(new RealEstateType(RT.ID, RT.RealEstateCategoryId.Value, RT.Title)));
                return Types;
            }
        }

        public List<RealEstateStatus> GetRealEstateStaus(string RealEstateCategoryID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<RealEstateStatus> Status = new List<RealEstateStatus>();
                int CategoryID = Convert.ToInt32(RealEstateCategoryID);
                Context.RealEstateStatuses.Where(RS => RS.RealEstateCategoryID == CategoryID && RS.IsSearchVisible==true)
                     .OrderBy(RS => RS.Title).ToList().ForEach(RS => Status.Add(new RealEstateStatus(RS.ID, RS.RealEstateCategoryID.Value, RS.Title)));
                return Status;
            }
        }

        public List<RealEstateStatus> GetRealEstateStausByType(string RealEstateTypeID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<RealEstateStatus> Status = new List<RealEstateStatus>();
                int TypeID = Convert.ToInt32(RealEstateTypeID);
                Context.RealEstateStatuses.Where(RS => RS.RealEstateCategory.RealEstateTypes.FirstOrDefault(T => T.ID == TypeID)!=null && RS.IsSearchVisible == true)
                     .OrderBy(RS => RS.Title).ToList().ForEach(RS => Status.Add(new RealEstateStatus(RS.ID, RS.RealEstateCategoryID.Value, RS.Title)));
                return Status;
            }
        }

        public BrokerDLL.Serializable.RealEstate GetRealEstate(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == id && R.ActiveStatusId==(int)BrokerDLL.Activestatus.Active && R.IsSold==false);
                return new BrokerDLL.Serializable.RealEstate(realestate);
            }
        }
       public BrokerDLL.Serializable.Subscriber GetSubscriber(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == id && R.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && R.IsSold == false);
                if(realestate.UseContactInfo==true)
                {
                    return new BrokerDLL.Serializable.Subscriber(realestate.Subscriber);
                }
                else
                {
                    return new BrokerDLL.Serializable.Subscriber(realestate.OwnerName,realestate.OwnerMobile,realestate.OwnerEmail);
                }
            }
        }

        public List<RealEstatePhoto> GetRealEstatePhotos(string RealEstateID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<BrokerDLL.Serializable.RealEstatePhoto> Photos = new List<RealEstatePhoto>();
                int realestateId = Convert.ToInt32(RealEstateID);
                Context.RealEstatePhotos.Where(P => P.RealEstateID == realestateId).ToList()
                    .ForEach(P => Photos.Add(new RealEstatePhoto(P.PhotoName, P.IsDefault.Value)));
                return Photos;
            }
        }

        public List<RealEstateKeyword> GetRealEstateKeywords(string RealEstateID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<BrokerDLL.Serializable.RealEstateKeyword> Keywords = new List<RealEstateKeyword>();
                int realestateId = Convert.ToInt32(RealEstateID);
                Context.RealEstateKeywords.Where(K => K.RealEstateID == realestateId).ToList()
                    .ForEach(K => Keywords.Add(new RealEstateKeyword(K.KeywordTitle)));
                return Keywords;
            }
        }

        public List<RealEstateCriteria> GetRealEstateCriterias(string RealEstateID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<BrokerDLL.Serializable.RealEstateCriteria> Criterias = new List<RealEstateCriteria>();
                int realestateId = Convert.ToInt32(RealEstateID);
                Context.RealEstateCriterias.Where(C => C.RealEstateID == realestateId).ToList()
                    .ForEach(C => Criterias.Add(new RealEstateCriteria(C.RealEstateTypeCriteria.Title, C.Value)));
                return Criterias;
            }
        }

        public List<BrokerDLL.Serializable.RealEstate> Search(string PageSize, string PageIndex, string SaleType,string Type,string Status, string Country, string City, string District, string Area, string Price, string PaymentType, string Currency)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Size = Convert.ToInt32(PageSize);
                int index = Convert.ToInt32(PageIndex);
                int SaleTypeId = Convert.ToInt32(SaleType);
                int TypeID = Convert.ToInt32(Type);
                int StatusID = Convert.ToInt32(Status);
                int CountryId = Convert.ToInt32(Country);
                int CityId = Convert.ToInt32(City);
                int DistrictID = Convert.ToInt32(District);
                int area = Convert.ToInt32(Area);
                int price = Convert.ToInt32(Price);
                int PaymentTypeID = Convert.ToInt32(PaymentType);
                int CurrrencyID = Convert.ToInt32(Currency);
                int Start=(Size*index)-Size;
                int End=(Size*index);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                Context.SearchRealEstate(SaleTypeId, TypeID, StatusID, CountryId, CityId, DistrictID, area,price, PaymentTypeID, CurrrencyID,Start,End).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
            //return BrokerDLL.General.Search.SearchRealEstates(RealEstateSearchCriteria);
        }

        public List<int> CountResult(string PageSize, string SaleType, string Type, string Status, string Country, string City, string District, string Area, string Price, string PaymentType, string Currency)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Size = Convert.ToInt32(PageSize);
                int SaleTypeId = Convert.ToInt32(SaleType);
                int TypeID = Convert.ToInt32(Type);
                int StatusID = Convert.ToInt32(Status);
                int CountryId = Convert.ToInt32(Country);
                int CityId = Convert.ToInt32(City);
                int DistrictID = Convert.ToInt32(District);
                int area = Convert.ToInt32(Area);
                int price = Convert.ToInt32(Price);
                int PaymentTypeID = Convert.ToInt32(PaymentType);
                int CurrrencyID = Convert.ToInt32(Currency);
                int Count = Context.CountSearchRealEstate(SaleTypeId, TypeID, StatusID,
                    CountryId, CityId, DistrictID, area,price, PaymentTypeID, CurrrencyID).First().Value;
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
            //return BrokerDLL.General.Search.CountRealEstates(RealEstateSearchCriteria);
        }
        public string SendComplain(Complain complain)
        {
            //try
            //{
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                BrokerDLL.RealEstateComplain Complain = new BrokerDLL.RealEstateComplain();
                Complain.ComplainDetails = complain.Message;
                Complain.ComplainerEmail = complain.Email;
                Complain.ComplainerName = complain.Name;
                Complain.ComplainerPhone = complain.Phone;
                Complain.ComplainTitle = complain.ComplainTitle;
                Complain.CreatedDate = DateTime.Now;
                Complain.IsRead = false;
                Complain.RealEstateID = complain.RealEstateID;
                Context.RealEstateComplains.AddObject(Complain);
                Context.SaveChanges();
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
            }
            //}
            //catch (Exception ex)
            //{
            //    return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Error);
            //}
        }

        public string PurchaseRequest(PurchaseRequest request)
        {
            try
            {
                using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
                {
                    BrokerDLL.RealEstatePurchaseRequest Request = new BrokerDLL.RealEstatePurchaseRequest();
                    Request.Date = DateTime.Now;
                    Request.IsDeleted = false;
                    Request.IsRead = false;
                    Request.Message = request.Message;
                    Request.PurchaserEmail = request.Email;
                    Request.PurchaserName = request.Name;
                    Request.PurchaserPhone = request.Phone;
                    Request.RealEstateID = request.RealEstateID;
                    Context.RealEstatePurchaseRequests.AddObject(Request);
                    Context.SaveChanges();
                    BrokerDLL.RealEstate realestate =Context.RealEstates.FirstOrDefault(R => R.ID == request.RealEstateID);
                    if (realestate != null)
                    {
                        BrokerDLL.SubscriberNotification notification = new BrokerDLL.SubscriberNotification();
                        notification.CreatedDate = DateTime.Now;
                        notification.Description = "تم ارسال طلب شراء جديد للعقار رقم:" + realestate.Code;
                        notification.IsRead = false;
                        notification.ObjectID = realestate.ID;
                        notification.ObjectName = realestate.Title;
                        notification.ObjectTypeID = (int)BrokerDLL.Modules.RealEstates;
                        notification.SubscriberID = realestate.SubscriberID;
                        notification.Title = "تم ارسال طلب شراء جديد للعقار رقم:" + realestate.Code;
                        Context.SubscriberNotifications.AddObject(notification);
                        Context.SaveChanges();
                        BrokerDLL.General.Email email = new BrokerDLL.General.Email();
                        email.EmailType = BrokerDLL.EmailType.PurchaseRequest;
                        email.HasAttachment = false;
                        email.MailCriteria = new Dictionary<string, string>();
                        email.MailCriteria.Add("Title", realestate.Title);
                        email.MailCriteria.Add("Code", realestate.Code.ToString());
                        email.Recievers = new List<string>();
                        email.Recievers.Add(realestate.Subscriber.Email);
                        if (realestate.UseContactInfo == false)
                        { 
                        email.Recievers.Add(realestate.OwnerEmail);
                        }
                        email.BC = new List<string>();
                        email.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
                        email.Send();
                    }
                  
                }
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
            }
            catch (Exception ex)
            {
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Error);

            }
        }

        public List<BrokerDLL.Serializable.RealEstate> GetLatestRealEstatesBySaleType(string SaleType, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int SaleTypeID = Convert.ToInt32(SaleType);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.SaleTypeId==SaleTypeID)
                    .Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
                //.OrderByDescending(B => B.CreatedDate)
            }
        }


        public List<BrokerDLL.Serializable.RealEstate> GetRealEstatesByCompany(string CompanyID, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int Companyid = Convert.ToInt32(CompanyID);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.Subscriber.CompanyID == Companyid)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }


        public List<int> GetRealEstatesNoByCompany(string CompanyID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                //  int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int Companyid = Convert.ToInt32(CompanyID);
                List<int> Pages = new List<int>();
                int Count = Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.Subscriber.CompanyID == Companyid).Count();

                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
                //return Companies;
            }
        }


        public List<BrokerDLL.Serializable.RealEstate> GetSpecailRealEstates(string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false && RS.IsSpecialOffer==true)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }


        public List<int> CountSpecialRealEstates(string PageSize)
        {
              using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
            int Size = Convert.ToInt32(PageSize);
            int Count=Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false && RS.IsSpecialOffer == true).Count();
            List<int> Pages = new List<int>();
            double counter = Convert.ToDouble(Count) / Size;
            if (counter <= 0)
            {
                return null;
            }
            double pagecount = Math.Ceiling(counter);
            for (int i = 1; i <= pagecount; i++)
            {
                Pages.Add(i);
            }
            return Pages;
              }
        }


        public List<BrokerDLL.Serializable.RealEstate> GeRealEstatesBySaleType(string SaleType, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int SaleTypeID = Convert.ToInt32(SaleType);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.SaleTypeId == SaleTypeID).OrderByDescending(RS=>RS.IsSpecialOffer)
                    .ThenByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }


        public List<int> CountRealEstatesByType(string SaleType, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Size = Convert.ToInt32(PageSize);
                int SaleTypeID = Convert.ToInt32(SaleType);
                int Count = Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false && RS.SaleTypeId == SaleTypeID).Count();
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
        }


        public List<BrokerDLL.Serializable.RealEstate> GeRealEstatesByCategory(string Category, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int CategoryID = Convert.ToInt32(Category);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.RealEstateCategoryID == CategoryID).OrderByDescending(RS => RS.IsSpecialOffer)
                    .ThenByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }

        public List<int> CountRealEstatesByCategory(string Category, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Size = Convert.ToInt32(PageSize);
                int CategoryID = Convert.ToInt32(Category);
                int Count = Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false && RS.RealEstateCategoryID == CategoryID).Count();
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
        }


        public List<int> CountRealEstates(string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Size = Convert.ToInt32(PageSize);
                int Count = Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false).Count();
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
        }

        public List<BrokerDLL.Serializable.RealEstate> GetRealEstatesByCatalog(string CatalogID, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int Catalogid = Convert.ToInt32(CatalogID);
                List<BrokerDLL.Serializable.RealEstate> RealEstates = new List<BrokerDLL.Serializable.RealEstate>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.RealestateCatalogProperties.FirstOrDefault(C=>C.CatalogID== Catalogid) != null)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
                return RealEstates;
            }
        }

        public List<int> GetRealEstatesNoByCatalog(string Catalog, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                //  int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int Catalogid = Convert.ToInt32(Catalog);
                List<int> Pages = new List<int>();
                int Count = Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold == false
                    && RS.RealestateCatalogProperties.FirstOrDefault(C=>C.CatalogID==Catalogid) != null).Count();

                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
                //return Companies;
            }
        }

       public string ValidateContactData(PurchaseRequest contact)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                string Code = BrokerDLL.Commons.CreateActivationCode();
               // string Password = BrokerDLL.Commons.CreatePasswordCode();
                BrokerDLL.Subscriber subscriber = new BrokerDLL.Subscriber();
                subscriber.ActiveStatusID = (int)BrokerDLL.Activestatus.Pending;
                subscriber.ActivationCode = Code;
                subscriber.CreatedDate = DateTime.Now;
                subscriber.Email = contact.Email;
                subscriber.IsCompanyAdmin = false;
                subscriber.MobileNo = contact.Phone;
                subscriber.UserName = contact.UserName;
                subscriber.FullName = contact.Name;

                Regex rgx = new Regex(@"^[a-zA-Z0-9_.]+$");
                if (!rgx.IsMatch(contact.UserName))
                {
                    return "Error:" + BrokerDLL.Commons.GetValue(BrokerDLL.Message.UserNameInvalidChars);
                }
                    if (Membership.FindUsersByName(contact.UserName).Count > 0)
                {
                    return "Error:" + BrokerDLL.Commons.GetValue(BrokerDLL.Message.UsernameNotAvailable);
                }
                //if (Membership.FindUsersByEmail(contact.Email).Count > 0)
                //{
                //    return "Error:" + BrokerDLL.Commons.GetValue(BrokerDLL.Message.EmailRegistered);
                //}
                Membership.CreateUser(contact.UserName, Code, contact.Email);
                Roles.AddUserToRole(contact.UserName, "Subscriber");
                Context.Subscribers.AddObject(subscriber);
                Context.SaveChanges();
                BrokerDLL.Commons.Subsciber = subscriber;
                BrokerDLL.Commons.UserName = subscriber.UserName;

                BrokerDLL.General.SMS sms = new BrokerDLL.General.SMS();
                sms.Lang = BrokerDLL.General.SMSLanguage.A;
                sms.Receiver = contact.Phone;
                sms.Text = "تم انشاء كلمة سر مؤقته بمكنك استخدمها للدخول الي حسابك و لرؤية بيانات المالك :" + Code;
                sms.Send();

                BrokerDLL.General.Email email = new BrokerDLL.General.Email();
                email.EmailType = BrokerDLL.EmailType.GeneratePassword;
                email.HasAttachment = false;
                email.MailCriteria = new Dictionary<string, string>();
                email.MailCriteria.Add("Code", Code);
                email.Recievers = new List<string>();
                email.Recievers.Add(contact.Email);
                email.BC = new List<string>();
                email.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
                email.Send();


                //BrokerDLL.General.Email Cemail = new BrokerDLL.General.Email();
                //Cemail.EmailType = BrokerDLL.EmailType.ValidateAccount;
                //Cemail.HasAttachment = false;
                //Cemail.MailCriteria = new Dictionary<string, string>();
                //Cemail.MailCriteria.Add("Code", Code);
                //Cemail.Recievers = new List<string>();
                //Cemail.Recievers.Add(contact.Email);
                //Cemail.BC = new List<string>();
                //Cemail.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
                //Cemail.Send();
                //  return new object{ Code };
                JavaScriptSerializer serialize = new JavaScriptSerializer();

                return serialize.Serialize(Code);
            }
        }
        public string InqueryRequest(PurchaseRequest request)
        {
            try
            {
                using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
                {
                    BrokerDLL.Subscriber subscriber = Context.Subscribers.FirstOrDefault(s => s.UserName == request.UserName);
                    if(subscriber!=null)
                    {
                        subscriber.ActivationCode = "";
                        subscriber.ActiveStatusID = (int)BrokerDLL.Activestatus.Active;
                        Context.SaveChanges();
                    }
                    
                    BrokerDLL.RealEstatePurchaseRequest Request = new BrokerDLL.RealEstatePurchaseRequest();
                    Request.Date = DateTime.Now;
                    Request.IsDeleted = false;
                    Request.IsRead = false;
                    Request.IsInquiry = true;
                    Request.Message = request.Message;
                    Request.PurchaserEmail = request.Email;
                    Request.PurchaserName = request.Name;
                    Request.PurchaserPhone = request.Phone;
                    Request.RealEstateID = request.RealEstateID;
                    Context.RealEstatePurchaseRequests.AddObject(Request);
                    Context.SaveChanges();
                    //BrokerDLL.RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == request.RealEstateID);
                 

                }
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
            }
            catch (Exception ex)
            {
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Error);

            }
        }
    }
}
