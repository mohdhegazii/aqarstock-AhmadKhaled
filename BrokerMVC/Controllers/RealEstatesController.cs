using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using BrokerMVC.Extensions;
using ResourcesFiles;
using System.IO;
using System.Configuration;
using PagedList;
using BrokerMVC.Code.Repositories;
using System.Web.UI;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee, Roles.Subscriber)]
    public class RealEstatesController : BaseController
    {
        // private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        private RealEstateRepository Repository = new RealEstateRepository(new RealEstateBrokerEntities());

        // GET: RealEstates
        [AuthorizeRoles(Roles.Admin)]
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,sortOrder,currentFilter,searchString", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult Index(int? page, string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.SpecialSortParm = sortOrder == "Special" ? "Special" : "Special";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            Subscriber sub = Repository.GetSubscriber(Commons.UserName);
            var realestates = Repository.GetAll(page, sortOrder, searchString, pageNumber, pageSize);
            return View(realestates);
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,sortOrder,currentFilter,searchString,type", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetRealestates(int? page, string sortOrder, string type, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.type = type;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            Subscriber sub = Repository.GetSubscriber(Commons.UserName);
            if (!String.IsNullOrEmpty(type))
            {

                return View(Repository.GetByCompny(sub.CompanyID.Value, page, sortOrder, searchString, pageNumber, pageSize));
            }
            else
            {
                return View(Repository.GetBySubscrber(sub.ID, page, sortOrder, searchString, pageNumber, pageSize));
                // realestates = realestates.Where(p => p.SubscriberID == sub.ID);
            }

            // return View(realestates.ToPagedList(pageNumber, pageSize));
        }

        [AuthorizeRoles(Roles.Admin)]
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,from,to,ReasonId", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetSuspendedRealestates(int? page, string from, string to, int? ReasonId)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var realestates = Repository.GetSuspendedRealestates(from, to, ReasonId, pageNumber, pageSize);
            ViewBag.ReasonId = new SelectList(Repository.GetSuspendReasons(), "ID", "Title", (ReasonId ?? null));
            ViewBag.from = from;
            ViewBag.to = to;
            return View("GetSuspendedRealestates", realestates);
        }

        [AuthorizeRoles(Roles.Admin)]
        public ActionResult DeleteSuspendedRealestates()
        {

            ViewBag.SuspendReasonID = new SelectList(Repository.GetSuspendReasons(), "ID", "Title");
            return View("DeleteSuspendedRealestates");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSuspendedRealestates(RemoveSuspended suspended)
        {
            Repository.RemoveSuspendedRealestate(suspended.From, suspended.To, suspended.SuspendReasonID);
            Repository.Save();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            ViewBag.SuspendReasonID = new SelectList(Repository.GetSuspendReasons(), "ID", "Title", suspended.SuspendReasonID);
            return View("DeleteSuspendedRealestates", suspended);
        }
        // GET: RealEstates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = Repository.GetByRealestateID(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // GET: RealEstates/Create
        public ActionResult Create()
        {
            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            //ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");

            //ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name");
            //ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName");

            //ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude");
            //ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name");
            //ViewBag.PaymentTypeID = new SelectList(db.PaymentTypes, "ID", "Title");
            //ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title");
            //ViewBag.RealEstateStatusID = new SelectList(db.RealEstateStatus, "ID", "Title");
            //ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title");
            //ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "ID", "Title");
            return View();
        }

        // POST: RealEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubscriberID,ProjectID,RealEstateCategoryID,RealEstateStatusID,RealEstateTypeID,PaymentTypeID,CurrencyID,SaleTypeId,CountryID,CityID,DistrictID,Code,Street,EnStreet,Title,EnTitle,Description,EnDescription,Price,Area,Longitude,Latitude,OwnerName,OwnerMobile,OwnerEmail,IsSold,ActiveStatusId,CreatedDate,UseContactInfo,IsMigrated,IsSpecialOffer,ChangeActiveStatus")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                //db.RealEstates.Add(realEstate);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", realEstate.CityID);
            //ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", realEstate.CountryID);
            //ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", realEstate.CurrencyID);
            //ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", realEstate.DistrictID);
            //ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title", realEstate.RealEstateCategoryID);
            //ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude", realEstate.ProjectID);
            //ViewBag.RealEstateStatusID = new SelectList(db.RealEstateStatus, "ID", "Title", realEstate.RealEstateStatusID);
            //ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", realEstate.RealEstateTypeID);
            //ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", realEstate.SubscriberID);
            //ViewBag.PaymentTypeID = new SelectList(db.PaymentTypes, "ID", "Title", realEstate.PaymentTypeID);
            //ViewBag.SaleTypeId = new SelectList(db.SaleTypes, "ID", "Title", realEstate.SaleTypeId);
            return View(realEstate);
        }

        // GET: RealEstates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = Repository.GetByRealestateID(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            RealEstateBasicData basic = GetRealestateBasicData(realEstate);
            ViewBag.CurrencyID = new SelectList(Repository.GetCurrencies(), "ID", "Name", basic.CurrencyID);
            ViewBag.PaymentTypeID = new SelectList(Repository.GetPaymentTypes(), "ID", "Title", basic.PaymentTypeID);
            ViewBag.RealEstateCategoryID = new SelectList(Repository.GetRealestateCategories(), "ID", "Title", basic.RealEstateCategoryID);
            ViewBag.RealEstateStatusID = new SelectList(Repository.GetRealestateStatus(basic.RealEstateCategoryID.Value), "ID", "Title", basic.RealEstateStatusID);
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetRealestateTypes(basic.RealEstateCategoryID.Value), "ID", "Title", basic.RealEstateTypeID);
            ViewBag.SaleTypeId = new SelectList(Repository.GetSaleTypes(), "ID", "Title", basic.SaleTypeId);
            ViewBag.ActivestatusID = realEstate.ActiveStatusId;
            return View(basic);
        }

        private RealEstateBasicData GetRealestateBasicData(RealEstate realEstate)
        {
            RealEstateBasicData basic = new RealEstateBasicData();
            basic.ID = realEstate.ID;
            basic.Code = realEstate.Code.ToString();
            basic.RealEstateCategoryID = realEstate.RealEstateCategoryID;
            basic.RealEstateStatusID = realEstate.RealEstateStatusID;
            basic.RealEstateTypeID = realEstate.RealEstateTypeID;
            basic.SaleTypeId = realEstate.SaleTypeId;
            basic.Description = realEstate.Description;
            basic.EnDescription = realEstate.EnDescription;
            basic.EnName = realEstate.EnTitle;
            basic.Latitude = realEstate.Latitude;
            basic.Longutide = realEstate.Longitude;
            basic.Name = realEstate.Title;
            basic.Address = realEstate.Address;
            basic.IsSpecial = realEstate.IsSpecialOffer;
            basic.IsSold = realEstate.IsSold;
            basic.Area = Convert.ToInt32(realEstate.Area);
            basic.CurrencyID = realEstate.CurrencyID;
            basic.PaymentTypeID = realEstate.PaymentTypeID;
            basic.Price = Convert.ToInt32(realEstate.Price);
            basic.SuspendData = realEstate.SuspendData;
            basic.Project = realEstate.RealEstateProject;
            basic.Subscriber = realEstate.Subscriber;
            basic.Owner = realEstate.Owner;
            return basic;

        }

        // POST: RealEstates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RealEstateBasicData basic)
        {
            var realEstate = Repository.GetByRealestateID(basic.ID);
            if (ModelState.IsValid)
            {

                EditRealEstateData(basic, realEstate);
                Repository.Update(realEstate);
                if (realEstate.ActiveStatusId == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                {
                    Repository.LogAction(Modules.RealEstates, subscriberActions.Updated, realEstate.ID, realEstate.Title);
                }
                Repository.Save();

                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                //   return RedirectToAction("Index");
            }
            basic.SuspendData = realEstate.SuspendData;
            basic.Project = realEstate.RealEstateProject;
            basic.Subscriber = realEstate.Subscriber;
            basic.Owner = realEstate.Owner;
            ViewBag.CurrencyID = new SelectList(Repository.GetCurrencies(), "ID", "Name", basic.CurrencyID);
            ViewBag.PaymentTypeID = new SelectList(Repository.GetPaymentTypes(), "ID", "Title", basic.PaymentTypeID);
            ViewBag.RealEstateCategoryID = new SelectList(Repository.GetRealestateCategories(), "ID", "Title", basic.RealEstateCategoryID);
            ViewBag.RealEstateStatusID = new SelectList(Repository.GetRealestateStatus(basic.RealEstateCategoryID.Value), "ID", "Title", basic.RealEstateStatusID);
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetRealestateTypes(basic.RealEstateCategoryID.Value), "ID", "Title", basic.RealEstateTypeID);
            ViewBag.SaleTypeId = new SelectList(Repository.GetSaleTypes(), "ID", "Title", basic.SaleTypeId);
            ViewBag.ActivestatusID = realEstate.ActiveStatusId;

            return View(basic);
        }

        public ActionResult Add()
        {
            Subscriber subscriber = Repository.GetSubscriber(Commons.UserName);
            if (subscriber.ActiveStatusID == (int)ActiveStatus.Suspended)
            {
                return RedirectToAction("Suspended", "Activation", new { id = subscriber.ID });
            }
            var cat = Repository.GetRealestateCategories().FirstOrDefault();
            ViewBag.CurrencyID = new SelectList(Repository.GetCurrencies(), "ID", "Name");
            ViewBag.PaymentTypeID = new SelectList(Repository.GetPaymentTypes(), "ID", "Title");
            ViewBag.RealEstateCategoryID = new SelectList(Repository.GetRealestateCategories(), "ID", "Title");
            ViewBag.RealEstateStatusID = new SelectList(Repository.GetRealestateStatus(cat.ID), "ID", "Title");
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetRealestateTypes(cat.ID), "ID", "Title");
            ViewBag.SaleTypeId = new SelectList(Repository.GetSaleTypes(), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RealEstateBasicData basic)
        {
            if (ModelState.IsValid)
            {
                Subscriber sub = Repository.GetSubscriber(Commons.UserName);
                RealEstate realestate = new RealEstate();
                EditRealEstateData(basic, realestate);
                realestate.ActiveStatusId = (int)ActiveStatus.IncompleteAddress;
                realestate.Code = Repository.GetLastCode() + 1;
                realestate.CreatedDate = DateTime.Now;
                realestate.IsMigrated = false;
                realestate.IsSold = false;
                realestate.IsSpecialOffer = false;
                realestate.SubscriberID = sub.ID;
                realestate.UseContactInfo = true;
                Repository.Add(realestate);
                Repository.Save();
                return RedirectToAction("AddAddress", new { id = realestate.ID });
            }
            ViewBag.CurrencyID = new SelectList(Repository.GetCurrencies(), "ID", "Name");
            ViewBag.PaymentTypeID = new SelectList(Repository.GetPaymentTypes(), "ID", "Title");
            ViewBag.RealEstateCategoryID = new SelectList(Repository.GetRealestateCategories(), "ID", "Title");
            ViewBag.RealEstateStatusID = new SelectList(Repository.GetRealestateStatus(basic.RealEstateCategoryID.Value), "ID", "Title");
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetRealestateTypes(basic.RealEstateCategoryID.Value), "ID", "Title");
            ViewBag.SaleTypeId = new SelectList(Repository.GetSaleTypes(), "ID", "Title");

            return View(basic);
        }
        public ActionResult AddAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            if (realEstateCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.Add = true;
            AddressData address = new AddressData();
            address.ID = realEstateCompany.ID;
            address.Name = realEstateCompany.Title;
            address.Latitude = null;
            address.Longitude = null;
            var country = Repository.GetCountries().FirstOrDefault();
            var city = Repository.GetCities(country.ID).FirstOrDefault();
            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", country);
            ViewBag.CityID = new SelectList(Repository.GetCities(country.ID), "ID", "Name", city.ID);
            ViewBag.DistrictID = new SelectList(Repository.GetDistricts(city.ID), "ID", "Name");
            return View("EditAddress", address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAddress(AddressData address)
        {
            if (ModelState.IsValid)
            {
                RealEstate realEstate = Repository.GetByRealestateID(address.ID);
                realEstate.CityID = address.CityID;
                realEstate.CountryID = address.CountryID;
                realEstate.DistrictID = address.DistrictID;
                realEstate.Latitude = address.Latitude;
                realEstate.Longitude = address.Longitude;
                realEstate.Street = address.Street;
                realEstate.EnStreet = address.EnStreet;
                realEstate.ActiveStatusId = (int)ActiveStatus.IncompletePhotos;
                Repository.Update(realEstate);
                Repository.Save();
                return RedirectToAction("AddAditionalData", new { id = address.ID });
            }
            return View(address);
        }
        public ActionResult AddAditionalData(int? id)
        {
            RealEstate realEstate = Repository.GetByRealestateID(id);
            AddRealEstateAditionalData add = new AddRealEstateAditionalData();
            add.ID = realEstate.ID;
            add.RealestateName = realEstate.Title;
            add.TypeCriterias = Repository.GetRealestateTypeCriteria(realEstate.RealEstateTypeID.Value).ToList();
            add.UseContactInfo = true;
            add.Owner = new OwnerData();
            add.Owner.Name = realEstate.Subscriber.FullName;
            add.Owner.Phone = realEstate.Subscriber.MobileNo;
            add.Owner.Email = realEstate.Subscriber.Email;
            return View(add);
        }
        [HttpPost]
        public ActionResult AddAditionalData(AddRealEstateAditionalData add)
        {
            RealEstate realEstate = Repository.GetByRealestateID(add.ID);
            if (ModelState.IsValid)
            {

                bool IsValid = true;
                if (add.PhotosUpload.FirstOrDefault() == null)
                {
                    ModelState.AddModelError("PhotoURL", Messages.PhotoRequired);
                    IsValid = false;
                }
                else
                {
                    ValidationResult result = ImageHelper.ValidateImages(add.PhotosUpload, ImageTypes.Image);
                    if (!result.IsValid)
                    {
                        ModelState.AddModelError("PhotoURL", result.Message);
                        IsValid = false;
                    }
                }

                if (IsValid)
                {
                    SaveCriterias(add);
                    SavePhotos(add, realEstate.Code.ToString());
                    if (add.UseContactInfo == false)
                    {
                        realEstate.OwnerEmail = add.Owner.Email;
                        realEstate.OwnerMobile = add.Owner.Phone;
                        realEstate.OwnerName = add.Owner.Name;
                    }
                    realEstate.ActiveStatusId = (int)ActiveStatus.New;
                    Repository.Update(realEstate);
                    Repository.LogAction(Modules.RealEstates, subscriberActions.AddNew, realEstate.ID, realEstate.Title);
                    Repository.Save();
                    return RedirectToAction("Edit", new { id = add.ID });
                }
            }
            add.Owner = new OwnerData();
            add.Owner.Name = realEstate.Subscriber.FullName;
            add.Owner.Phone = realEstate.Subscriber.MobileNo;
            add.Owner.Email = realEstate.Subscriber.Email;
            return View(add);

        }

        private void SavePhotos(AddRealEstateAditionalData add, string Code)
        {
            RealEstatePhoto photo;
            Guid g;
            string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/", Code);
            foreach (HttpPostedFileBase file in add.PhotosUpload)
            {
                photo = new RealEstatePhoto();
                g = Guid.NewGuid();
                photo.RealEstateID = add.ID;
                photo.IsDefault = false;
                photo.PhotoName = ImagePath + "/" + g + Path.GetExtension(file.FileName);
                string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(file.FileName);
                ImageHelper.ApplyCompressionAndSave(file, filename, 70, file.ContentType);
                Repository.AddPhoto(photo);
            }


        }
        private void SaveCriterias(AddRealEstateAditionalData add)
        {
            RealEstateCriteria RC;
            foreach (RealEstateTypeCriteria c in add.TypeCriterias?.Where(c => c.BoolValue == true))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = add.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = "true";
                Repository.AddCriteria(RC);
            }
            foreach (RealEstateTypeCriteria c in add.TypeCriterias?.Where(c => c.intValue != null))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = add.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = c.intValue.ToString();
                Repository.AddCriteria(RC);
            }
            foreach (RealEstateTypeCriteria c in add.TypeCriterias?.Where(c => c.Value != null))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = add.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = c.Value;
                Repository.AddCriteria(RC);
            }
        }

        private void EditRealEstateData(RealEstateBasicData basic, RealEstate realEstate)
        {
            realEstate.Area = basic.Area;
            realEstate.CurrencyID = basic.CurrencyID;
            realEstate.Description = basic.Description;
            realEstate.EnDescription = basic.EnDescription;
            realEstate.EnTitle = basic.EnName;
            realEstate.PaymentTypeID = basic.PaymentTypeID;
            realEstate.Price = basic.Price;
            realEstate.RealEstateCategoryID = basic.RealEstateCategoryID;
            realEstate.RealEstateStatusID = basic.RealEstateStatusID;
            realEstate.RealEstateTypeID = basic.RealEstateTypeID;
            realEstate.SaleTypeId = basic.SaleTypeId;
            realEstate.Title = basic.Name;
        }
        public ActionResult SetSpecial(int? id, bool status)
        {
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            realEstateCompany.IsSpecialOffer = status;
            Repository.Update(realEstateCompany);
            Repository.Save();
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult SetSold(int? id, bool status)
        {
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            realEstateCompany.IsSold = status;
            Repository.Update(realEstateCompany);
            Repository.Save();
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult Activate(int? id)
        {
            RealEstate realEstate = Repository.GetByRealestateID(id);
            realEstate.ActiveStatusId = (int)ActiveStatus.Active;
            realEstate.ChangeActiveStatus = DateTime.Now;
            Repository.Update(realEstate);
            Repository.RemoveSuspended(id);
            Commons.RemoveLog(realEstate.ID, (int)Modules.RealEstates);
            Repository.Save();

            this.AddInSiteMap(realEstate);
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult Suspend(int? id)
        {
            RealEstate realEstate = Repository.GetByRealestateID(id);
            Suspend s = new Suspend();
            s.ID = realEstate.ID;
            ViewBag.SuspendReasonID = new SelectList(Repository.GetSuspendReasons(), "ID", "Title");
            return PartialView("_Suspend", s);
        }

        [HttpPost]
        public ActionResult Suspend(Suspend suspend)
        {
            if (ModelState.IsValid)
            {
                RealEstate realEstate = Repository.GetByRealestateID(suspend.ID);
                realEstate.ActiveStatusId = (int)ActiveStatus.Suspended;
                realEstate.ChangeActiveStatus = DateTime.Now;

                RealEstateSuspended susspended = new RealEstateSuspended();
                susspended.RealEstateID = suspend.ID;
                susspended.Message = suspend.Message;
                susspended.SuspendReasonId = suspend.SuspendReasonID;
                Repository.AddSuspended(susspended);
                Repository.Update(realEstate);
                Repository.RemoveLog(realEstate.ID, (int)Modules.RealEstates);
                SuspendReason reason = Repository.GetSuspendReasonById(suspend.SuspendReasonID);
                SubscriberNotification notification = new SubscriberNotification();
                notification.CreatedDate = DateTime.Now;
                notification.Description = "تم حجب بيانات " + realEstate.Title + " بعد مراجعتها<br/>";
                notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
                notification.Description += "تفاصيل: " + suspend.Message;
                notification.IsRead = false;
                notification.ObjectID = realEstate.ID;
                notification.ObjectTypeID = (int)Modules.RealEstates;
                notification.ObjectName = realEstate.Title;
                notification.SubscriberID = realEstate.SubscriberID;
                notification.Title = "تم حجب بيانات  " + realEstate.Title;
                Repository.AddNotification(notification);
                Repository.Save();

                //Email email = new Email();
                //email.EmailType = EmailType.SuspendBusiness;
                //email.HasAttachment = false;
                //email.MailCriteria = new Dictionary<string, string>();
                //email.MailCriteria.Add("Title", realEstateCompany.Title);
                //email.MailCriteria.Add("SuspendReason", reason.Title);
                //email.MailCriteria.Add("Message", suspend.Message);
                //email.Recievers = new List<string>();
                //email.Recievers.Add(realEstateCompany.Subscriber.Email);
                //email.Send();
                new MailController().SuspendObject(realEstate.Subscriber.Email, reason.Title, suspend.Message, realEstate.Title).Deliver();
                this.AddNotification(Messages.SuspendedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
            else
            {
                this.AddNotification(Messages.ValidationError, NotificationType.ERROR);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
        }
        public ActionResult EditAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            if (realEstateCompany == null)
            {
                return HttpNotFound();
            }
            AddressData address = GetAddressData(realEstateCompany);
            if (realEstateCompany.ActiveStatusId != (int)ActiveStatus.IncompleteAddress)
            {
                ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", realEstateCompany.CountryID);
                ViewBag.CityID = new SelectList(Repository.GetCities(realEstateCompany.CountryID), "ID", "Name", realEstateCompany.CityID);
                ViewBag.DistrictID = new SelectList(Repository.GetDistricts(realEstateCompany.CityID), "ID", "Name", realEstateCompany.DistrictID);
            }
            else
            {
                var country = Repository.GetCountries().FirstOrDefault();
                var city = Repository.GetCities(country.ID).FirstOrDefault();
                ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", country);
                ViewBag.CityID = new SelectList(Repository.GetCities(country.ID), "ID", "Name", city.ID);
                ViewBag.DistrictID = new SelectList(Repository.GetDistricts(city.ID), "ID", "Name");
            }
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(AddressData address)
        {
            if (ModelState.IsValid)
            {
                RealEstate realEstateCompany = Repository.GetByRealestateID(address.ID);
                realEstateCompany.CityID = address.CityID;
                realEstateCompany.CountryID = address.CountryID;
                realEstateCompany.DistrictID = address.DistrictID;
                realEstateCompany.Latitude = address.Latitude;
                realEstateCompany.Longitude = address.Longitude;
                realEstateCompany.Street = address.Street;
                realEstateCompany.EnStreet = address.EnStreet;
                if (realEstateCompany.ActiveStatusId == (int)ActiveStatus.IncompleteAddress)
                {
                    realEstateCompany.ActiveStatusId = (int)ActiveStatus.IncompletePhotos;
                }
                Repository.Update(realEstateCompany);
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = address.ID });
            }
            return View(address);
        }
        private AddressData GetAddressData(RealEstate realEstateCompany)
        {
            AddressData address = new AddressData();
            address.ID = realEstateCompany.ID;
            address.Name = realEstateCompany.Title;
            address.CityID = realEstateCompany.CityID;
            address.CountryID = realEstateCompany.CountryID;
            address.DistrictID = realEstateCompany.DistrictID;
            address.Latitude = realEstateCompany.Latitude;
            address.Longitude = realEstateCompany.Longitude;
            address.Street = realEstateCompany.Street;
            address.EnStreet = realEstateCompany.EnStreet;
            return address;

        }
        public ActionResult SubscriberOtherRealestates(int? id)
        {
            RealEstate realestate = Repository.GetByRealestateID(id);

            ViewBag.UserID = realestate.SubscriberID;
            var realestates = Repository.GetSubscriberOtherRealestates(realestate.SubscriberID.Value, realestate.ID);
            ViewBag.RealestateCount = realestates.Count();
            realestates = realestates.OrderByDescending(r => r.CreatedDate).Take(5);
            return PartialView("SubscriberOtherRealestates", realestates.ToList());
        }

        public ActionResult RealestateCriterias(int? id)
        {
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            ViewBag.RealEstateID = id;
            return PartialView("RealestateCriterias", realEstateCompany.RealEstateCriterias.OrderBy(r => r.RealEstateTypeCriteria.ValueType));

        }
        public ActionResult AddCriterias(int? id)
        {
            RealEstate realestate = Repository.GetByRealestateID(id);
            Criteria c = new Criteria();
            c.ID = realestate.ID;
            c.RealestateName = realestate.Title;
            c.TypeCriterias = Repository.GetRealestateTypeCriteria(realestate.RealEstateTypeID.Value, realestate.ID).ToList();
            return View("AddCriterias", c);
        }
        [HttpPost]
        public ActionResult AddCriterias(Criteria criteria)
        {
            RealEstateCriteria RC;
            foreach (RealEstateTypeCriteria c in criteria.TypeCriterias.Where(c => c.BoolValue == true))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = criteria.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = "true";
                Repository.AddCriteria(RC);
            }
            foreach (RealEstateTypeCriteria c in criteria.TypeCriterias.Where(c => c.intValue != null))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = criteria.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = c.intValue.ToString();
                Repository.AddCriteria(RC);
            }
            foreach (RealEstateTypeCriteria c in criteria.TypeCriterias.Where(c => c.Value != null))
            {
                RC = new RealEstateCriteria();
                RC.RealEstateID = criteria.ID;
                RC.RealEstateTypeCriteriaID = c.ID;
                RC.Value = c.Value;
                Repository.AddCriteria(RC);
            }
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = criteria.ID });
        }
        public ActionResult EditCriterias(int? id)
        {
            RealEstate realestate = Repository.GetByRealestateID(id);
            Criteria cr = new Criteria();
            cr.ID = realestate.ID;
            cr.Criterias = Repository.GetRealestateNonBooleanCriteria(realestate.ID).ToList();
            return PartialView("EditCriterias", cr);
        }
        [HttpPost]
        public ActionResult EditCriterias(Criteria Criteria)
        {
            //  RealEstateCriteria c;
            foreach (RealEstateCriteria RC in Criteria.Criterias)
            {

                Repository.UpdateCriteria(RC.ID, RC.Value);
            }
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = Criteria.ID });
        }
        public ActionResult DeleteCriteria(int? id)
        {
            int? RealestateId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                RealestateId = Repository.DelereCriteria(id);
                Repository.Save();
                this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);

            }
            return RedirectToAction("Edit", new { id = RealestateId });
        }
        public ActionResult AddOwnerData(int? id)
        {
            //  RealEstate realEstate = Repository.GetByRealestateID(id);
            OwnerData owner = new OwnerData();
            owner.Id = id;
            return PartialView("AddOwnerData", owner);
        }
        [HttpPost]
        public ActionResult AddOwnerData(OwnerData owner)
        {
            RealEstate realEstate = Repository.GetByRealestateID(owner.Id);
            realEstate.OwnerEmail = owner.Email;
            realEstate.OwnerMobile = owner.Phone;
            realEstate.OwnerName = owner.Name;
            realEstate.UseContactInfo = false;
            Repository.Update(realEstate);
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = owner.Id });
        }
        public ActionResult EditOwnerData(int? id)
        {
            RealEstate realEstate = Repository.GetByRealestateID(id);
            OwnerData owner = realEstate.Owner;
            return PartialView("EditOwnerData", owner);
        }
        [HttpPost]
        public ActionResult EditOwnerData(OwnerData owner)
        {
            RealEstate realEstate = Repository.GetByRealestateID(owner.Id);
            realEstate.OwnerEmail = owner.Email;
            realEstate.OwnerMobile = owner.Phone;
            realEstate.OwnerName = owner.Name;
            Repository.Update(realEstate);
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = owner.Id });
        }
        public ActionResult DeleteOwnerData(int? id)
        {
            RealEstate realEstate = Repository.GetByRealestateID(id);
            realEstate.UseContactInfo = true;
            realEstate.OwnerEmail = null;
            realEstate.OwnerMobile = null;
            realEstate.OwnerName = null;
            Repository.Update(realEstate);
            Repository.Save();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult RealestatePhotos(int? id, string type)
        {
            RealEstate realEstateCompany = Repository.GetByRealestateID(id);
            ViewBag.RealEstateID = id;
            if (type == "List")
            {
                ViewBag.RealEstateName = realEstateCompany.Title;
                // ViewBag.Logo = realEstateCompany.Logo;
                return View("PhotosList", realEstateCompany.RealEstatePhotos);

            }
            else
            {
                return PartialView("PhotosSlider", realEstateCompany.RealEstatePhotos);
            }
        }
        public ActionResult AddPhoto(int? id)
        {
            RealEstatePhoto Photo = new RealEstatePhoto();
            Photo.RealEstateID = id;
            Photo.IsDefault = false;
            ViewBag.returnUrl = Request.UrlReferrer;
            // ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude");
            return PartialView("AddPhoto", Photo);
        }

        // POST: RealEstateProjectPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPhoto(RealEstatePhoto realEstateProjectPhoto, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateProjectPhoto.PhotoFile == null || realEstateProjectPhoto.PhotoFile.ContentLength == 0)
                {
                    ModelState.AddModelError("PhotoFile", Messages.PhotoRequired);
                    this.AddNotification(Messages.PhotoRequired, NotificationType.ERROR);
                    Isvalid = false;
                }
                else
                {
                    ValidationResult result = ImageHelper.ValidateImage(realEstateProjectPhoto.PhotoFile, ImageTypes.Image);
                    if (!result.IsValid)
                    {
                        ModelState.AddModelError("PhotoFile", result.Message);
                        this.AddNotification(result.Message, NotificationType.ERROR);
                        Isvalid = false;
                    }
                    if (Isvalid == true)
                    {
                        RealEstate project = Repository.GetByRealestateID(realEstateProjectPhoto.RealEstateID);
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/", project.Code.ToString());
                        Guid g = Guid.NewGuid();
                        realEstateProjectPhoto.PhotoName = ImagePath + "/" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateProjectPhoto.PhotoFile, filename, 70, realEstateProjectPhoto.PhotoFile.ContentType);
                        if (realEstateProjectPhoto.IsDefault == true)
                        {
                            foreach (var p in Repository.GetPhotos(realEstateProjectPhoto.RealEstateID.Value))
                            {
                                p.IsDefault = false;
                                Repository.UpdatePhoto(p);
                            }
                        }
                        Repository.AddPhoto(realEstateProjectPhoto);
                        bool InComplete = false;
                        if (project.ActiveStatusId == (int)ActiveStatus.IncompletePhotos)
                        {
                            InComplete = true;
                            project.ActiveStatusId = (int)ActiveStatus.New;
                        }
                        Repository.Update(project);

                        if (project.ActiveStatusId == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                        {
                            Repository.LogAction(Modules.RealEstates, subscriberActions.Updated, project.ID, project.Title);
                        }
                        if (InComplete == true && !Security.IsUserInRole(Roles.Admin))
                        {
                            Repository.LogAction(Modules.RealEstates, subscriberActions.AddNew, project.ID, project.Title);
                        }
                        Repository.Save();
                        this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                    }
                }

                return Redirect(returnUrl);
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        this.AddNotification(error.ErrorMessage, NotificationType.ERROR);
                    }
                }
                return Redirect(returnUrl);
            }
        }
        public ActionResult SetDefault(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstatePhoto realEstateProjectPhoto = Repository.GetPhoto(id);
            if (realEstateProjectPhoto == null)
            {
                return HttpNotFound();
            }
            //db.RealEstateProjectPhotos.Where(p => p.ProjectID == id).ToList().ForEach(p=>p.IsDefault=false);
            foreach (var p in Repository.GetPhotos(realEstateProjectPhoto.RealEstateID.Value))
            {
                p.IsDefault = false;
                Repository.UpdatePhoto(p);
            }
            realEstateProjectPhoto.IsDefault = true;
            Repository.UpdatePhoto(realEstateProjectPhoto);
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("RealestatePhotos", new { id = realEstateProjectPhoto.RealEstateID, type = "List" });
        }
        public ActionResult DeletePhoto(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Repository.DeletePhoto(id);
                Repository.Save();
                this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: RealEstates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = Repository.GetByRealestateID(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }

            return View(realEstate);
        }

        // POST: RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            Repository.Save();
            return RedirectToAction("GetRealestates");
        }


        private void AddInSiteMap(RealEstate data)
        {
            SitemapNode node;
            node = new SitemapNode();
            node.Frequency = SitemapFrequency.Weekly;
            node.LastModified = DateTime.Now;
            node.Priority = 0.3;
            node.Url = ConfigurationSettings.AppSettings["WebSite"] + "/Details" + "/" + data.ID + "/" + Commons.EncodeText(data.Title); ;
            node.EncodeURL = true;
            node.Images = new List<SitemapImageNode>();
            //if (data.ProductPhotos.Count > 0)
            //{
            //    AddProductPhotoNode(node, data);
            //}
            SiteMapGenerator gen = new SiteMapGenerator();
            gen.AddNewNode(node, Server.MapPath("~/SiteMap.Xml"));
            Code.GeneralClasses.AqarFeedsGenerator.GenerateProductFeedItem(data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
