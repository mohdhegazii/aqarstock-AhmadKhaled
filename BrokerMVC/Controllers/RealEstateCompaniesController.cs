
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;
using PagedList;
using BrokerMVC.Models.ViewModel;
using ResourcesFiles;
using System.IO;
using BrokerMVC.Extensions;
using System.Configuration;
using BrokerMVC.Code.Repositories;
using System.Web.UI;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin,Roles.CompanyAdmin)]
    public class RealEstateCompaniesController : BaseController
    {
      //  private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        private CompanyRepository Repository = new CompanyRepository(new RealEstateBrokerEntities());


        // GET: RealEstateCompanies
        [AuthorizeRoles(Roles.Admin)]
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,currentFilter,searchString,sortOrder", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
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
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var Companies = Repository.GetAll(searchString, sortOrder, pageNumber, pageSize);
            return View(Companies);
        }

        // GET: RealEstateCompanies/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RealEstateCompany realEstateCompany = db.RealEstateCompanies.Find(id);
        //    if (realEstateCompany == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(realEstateCompany);
        //}

        // GET: RealEstateCompanies/Create
        public ActionResult Create()
        {
            var country = Repository.GetCountries().FirstOrDefault();
            var city = Repository.GetCities(country.ID).FirstOrDefault();
            ViewBag.CityId = new SelectList(Repository.GetCities(country.ID), "ID", "Name");
            ViewBag.CountryId = new SelectList(Repository.GetCountries(), "ID", "Name");
            ViewBag.DistrictId = new SelectList(Repository.GetDistricts(city.ID), "ID", "Name");
            return View();
        }

        // POST: RealEstateCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RealEstateCompany realEstateCompany)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = ValidateImage(realEstateCompany.LogoFile);
                if (Isvalid == true)
                {
                    Subscriber sub = Repository.GetSubscriber(Commons.UserName);
                    AddInitialData(realEstateCompany);
                    SaveImage(realEstateCompany);
                    Repository.Add(realEstateCompany, sub);
                    Repository.Save();
                    Repository.LogAction(Modules.Companies, subscriberActions.AddNew, realEstateCompany.ID, realEstateCompany.Title);
                    Repository.Save();
                    return RedirectToAction("Edit", new { id=realEstateCompany.ID});
                }
                
            }

            ViewBag.CityId = new SelectList(Repository.GetCities(realEstateCompany.CountryId), "ID", "Name", realEstateCompany.CityId);
            ViewBag.CountryId = new SelectList(Repository.GetCountries(), "ID", "Name", realEstateCompany.CountryId);
            ViewBag.DistrictId = new SelectList(Repository.GetDistricts(realEstateCompany.CityId), "ID", "Name", realEstateCompany.DistrictId);
            return View(realEstateCompany);
        }
        
        
        // GET: RealEstateCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicData basic = Repository.GetCompanyBasicDataByID(id);
            if (basic == null)
            {
                return HttpNotFound();
            }
            return View(basic);
        }

        //private static BasicData GetBasicData(RealEstateCompany realEstateCompany)
        //{
        //    BasicData basic = new BasicData();
        //    basic.ID = realEstateCompany.ID;
        //    basic.Name = realEstateCompany.Title;
        //    basic.EnName = realEstateCompany.EnTitle;
        //    basic.Description = realEstateCompany.Description;
        //    basic.EnDescription = realEstateCompany.EnDescription;
        //    basic.Summary = realEstateCompany.Summary;
        //    basic.EnSummary = realEstateCompany.EnSummary;
        //    basic.Phone = realEstateCompany.Phone;
        //    basic.Email = realEstateCompany.Email;
        //    basic.Logo = realEstateCompany.Logo;
        //    basic.Latitude = realEstateCompany.Latitude;
        //    basic.Longutide = realEstateCompany.Longutide;
        //    basic.IsSpecial = realEstateCompany.IsSpecial??false;
        //    if (realEstateCompany.Street != "" && realEstateCompany.Street != null)
        //    {
        //        basic.Address = realEstateCompany.Street + ", " + realEstateCompany.District.Name + " " + realEstateCompany.City.Name + " " + realEstateCompany.Country.Name;
        //    }
        //    else
        //    {
        //        basic.Address = realEstateCompany.District.Name + " " + realEstateCompany.City.Name + " " + realEstateCompany.Country.Name;
        //    }
        //    if(realEstateCompany.ActivateStatusID==(int)ActiveStatus.Suspended)
        //    {
        //        basic.SuspendData = new Suspend();
        //        basic.SuspendData.SuspendReason = realEstateCompany.SuspendReason.Title;
        //        basic.SuspendData.Message = realEstateCompany.SuspendMessage;
        //    }
        //    return basic;
        //}

        // POST: RealEstateCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BasicData CompanyBasicData)
        {
            if (ModelState.IsValid)
            {
                RealEstateCompany realEstateCompany = Repository.Update(CompanyBasicData);
                bool Isvalid = true;
                if (CompanyBasicData.LogoFile != null)
                {
                    Isvalid = ValidateImage(CompanyBasicData.LogoFile);
                    if (Isvalid == true)
                    {
                        realEstateCompany.LogoFile = CompanyBasicData.LogoFile;
                        SaveImage(realEstateCompany);
                        CompanyBasicData.Logo = realEstateCompany.Logo;
                    }
                }
                if (realEstateCompany.ActivateStatusID == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                {
                    Repository.LogAction(Modules.Companies, subscriberActions.Updated, realEstateCompany.ID, realEstateCompany.Title);
                }
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            }
            return View(CompanyBasicData);
        }
        public ActionResult EditAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // RealEstateCompany realEstateCompany = db.RealEstateCompanies.Find(id);
            AddressData address = Repository.GetCompanyAddressDataByID(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            

            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", address.CountryID);
            ViewBag.CityID = new SelectList(Repository.GetCities(address.CountryID), "ID", "Name", address.CityID);
            ViewBag.DistrictID = new SelectList(Repository.GetDistricts(address.CityID), "ID", "Name", address.DistrictID);
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(AddressData address)
        {
            if (ModelState.IsValid)
            {
                Repository.Update(address);
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = address.ID });
            }
            return View(address);
        }
        //private AddressData GetAddressData(RealEstateCompany realEstateCompany)
        //{
        //    AddressData address = new AddressData();
        //    address.ID = realEstateCompany.ID;
        //    address.Name = realEstateCompany.Title;
        //    address.Logo = realEstateCompany.Logo;
        //    address.CityID = realEstateCompany.CityId;
        //    address.CountryID = realEstateCompany.CountryId;
        //    address.DistrictID = realEstateCompany.DistrictId;
        //    address.EnStreet = realEstateCompany.Entreet;
        //    address.Latitude = realEstateCompany.Latitude;
        //    address.Longitude = realEstateCompany.Longutide;
        //    address.Street = realEstateCompany.Street;
        //    return address;

        //}

        public ActionResult Account()
        {
            Subscriber sub = Repository.GetSubscriber(Commons.UserName);
            return RedirectToAction("Edit", new { id = sub.CompanyID });
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Activate(int? id)
        {
            Repository.ChangeStatus(id, (int)ActiveStatus.Active);
            Repository.RemoveLog(id, (int)Modules.Companies);
            Repository.Save();
            
            this.AddInSiteMap(Repository.GetCompanyByID(id));
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult SetSpecial(int? id,bool status)
        {
            Repository.SetSpecial(id, status);
            Repository.Save();
            this.AddNotification(Messages.UpdatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        //  [HttpPost]
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetCompanyUserList(int? id)
        {
            RealEstateCompany realEstateCompany = Repository.GetCompanyByID(id);
            ViewBag.AvailableUsers = realEstateCompany.UserNos;
            ViewBag.CurrenrUsers = realEstateCompany.CurrentUserNos;
            var users =Repository.GetCompanyEmployees(id);
            return PartialView("GetCompanyUserList", users.ToList());
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]

        public ActionResult GetCompanyProjectList(int? id)
        {
            RealEstateCompany realEstateCompany = Repository.GetCompanyByID(id);
            ViewBag.CompanyID = id;
            ViewBag.AvailableProjects = realEstateCompany.ProjectNos;
            ViewBag.CurrenrProjects = realEstateCompany.CurrentProjectNos;
            var users = Repository.GetCompanyProjects(id, 5);
            return PartialView("GetCompanyProjectList", users.ToList());
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult CompanyEmployees()
        {
            Subscriber sub = Repository.GetSubscriber(Commons.UserName);
            RealEstateCompany realEstateCompany = Repository.GetCompanyByID(sub.CompanyID);
            ViewBag.CompanyID = sub.CompanyID;
            ViewBag.AvailableUsers = realEstateCompany.UserNos;
            ViewBag.CurrenrUsers = realEstateCompany.CurrentUserNos;
            var users = Repository.GetCompanyEmployees(realEstateCompany.ID);
            return View("CompanyEmployees", users.ToList());
    }

        public ActionResult AddNewUser(int?id)
        {
            RealEstateCompany company = Repository.GetCompanyByID(id);
            if (company.CurrentUserNos >= company.UserNos)
            {
                SubscriptionErrorMessage msg = new SubscriptionErrorMessage();
                msg.CurrentNo = company.CurrentUserNos;
                msg.TotalNo = company.UserNos;
                return View("CantAddUserView",msg);
            }
            
            ViewBag.CompanyName = company.Title;
            ViewBag.CompanyLogo = company.Logo;
            Subscriber user = new Subscriber();
            user.CompanyID = id;
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewUser(Subscriber user)
        {   
            bool isValid = true;
            if (ModelState.IsValid)
            {
                ValidationResult result = Security.CheckUserExist(user);
                if (result.IsValid == false)
                {
                    this.AddNotification(result.Message, NotificationType.ERROR);
                    isValid = false;
                }

                if (isValid)
                {

                    user.CreatedDate = DateTime.Now;
                    user.ActiveStatusID = (int)ActiveStatus.Pending;
                    user.ActivationCode = Commons.CreateActivationCode();
                    user.Password = new Password();
                    user.Password.password = user.ActivationCode;
                    Repository.AddEmployee(user);
                    Repository.Save();
                    Security.CreateEmployee(user);
                    Commons.ContactUser(user);
                    this.AddNotification(Messages.UserCreated, NotificationType.SUCCESS);
                    return RedirectToAction("Edit", new { id = user.CompanyID });
                }
            }
            if (!isValid || !ModelState.IsValid)
            {
                RealEstateCompany company = Repository.GetCompanyByID(user.CompanyID);
                ViewBag.CompanyName = company.Title;
                ViewBag.CompanyLogo = company.Logo;
               // return View(user);
            }
            return View(user);
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult EditCompanyUserNo(int? id)
        {
            Statistics s = Repository.GetCompanyUserNos(id);
            return PartialView("EditCompanyUserNo", s);
        }

        [HttpPost]
        public ActionResult EditCompanyUserNo(Statistics st)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateUserTotalNo(st);
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            }
            else
            {
                this.AddNotification(Messages.ValidationError, NotificationType.ERROR);
                
            }
            return RedirectToAction("Edit", new { id = st.ID });
        }

        [AuthorizeRoles(Roles.Admin)]
        public ActionResult EditCompanyProjectNo(int? id)
        {
            Statistics s = Repository.GetCompanyProjectNos(id);
            return PartialView("EditCompanyProjectNo", s);
        }

        [HttpPost]
        public ActionResult EditCompanyProjectNo(Statistics st)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateUserTotalNo(st);
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            }
            else
            {
                this.AddNotification(Messages.ValidationError, NotificationType.ERROR);
            }
            return RedirectToAction("Edit", new { id = st.ID });
        }
        public ActionResult RemoveUser(int? id)
        {
            Repository.RemoveEmployee(id);
            Repository.Save();
            return Redirect(Request.UrlReferrer.ToString());
        }

        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Suspend(int? id)
        {
            RealEstateCompany realEstateCompany = Repository.GetCompanyByID(id);
            Suspend s = new Suspend();
            s.ID = realEstateCompany.ID;
            ViewBag.SuspendReasonID = new SelectList(Repository.GetSuspendReasons(), "ID", "Title");
            return PartialView("_Suspend", s);
        }

        [HttpPost]
        public ActionResult Suspend(Suspend suspend)
        {
            if (ModelState.IsValid)
            {
                Repository.SuspendCompany(suspend);
                Repository.RemoveLog(suspend.ID, (int)Modules.Companies);
                this.NotifySubscriber(suspend);
                Repository.Save();
                this.AddNotification(Messages.SuspendedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
            else
            {
                this.AddNotification(Messages.ValidationError, NotificationType.ERROR);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
        }
        private void NotifySubscriber(Suspend suspend)
        {
            RealEstateCompany realEstateCompany = Repository.GetCompanyByID(suspend.ID);
            SuspendReason reason = Repository.GetSuspendReasonById(suspend.SuspendReasonID);
            SubscriberNotification notification;
            Email email;
            foreach (Subscriber subscriber in realEstateCompany.Subscribers.Where(S => S.IsCompanyAdmin == true))
            {
                notification = new SubscriberNotification();
                notification.CreatedDate = DateTime.Now;
                notification.Description = "تم حجب بيانات " + realEstateCompany.Title + " بعد مراجعتها<br/>";
                notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
                notification.Description += "تفاصيل: " + suspend.Message;
                notification.IsRead = false;
                notification.ObjectID = realEstateCompany.ID;
                notification.ObjectTypeID = (int)Modules.Companies;
                notification.ObjectName = realEstateCompany.Title;
                notification.SubscriberID = subscriber.ID;
                notification.Title = "تم حجب بيانات  " + realEstateCompany.Title;
                Repository.AddNotification(notification);

                //email = new Email();
                //email.EmailType = EmailType.SuspendBusiness;
                //email.HasAttachment = false;
                //email.MailCriteria = new Dictionary<string, string>();
                //email.MailCriteria.Add("Title", realEstateCompany.Title);
                //email.MailCriteria.Add("SuspendReason", reason.Title);
                //email.MailCriteria.Add("Message", suspend.Message);
                //email.Recievers = new List<string>();
                //email.Recievers.Add(subscriber.Email);
                //email.Send();
                new MailController().SuspendObject(subscriber.Email, reason.Title, suspend.Message, realEstateCompany.Title).Deliver();
            }
        }
        // GET: RealEstateCompanies/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RealEstateCompany realEstateCompany = db.RealEstateCompanies.Find(id);
        //    if (realEstateCompany == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(realEstateCompany);
        //}

        //// POST: RealEstateCompanies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateCompany realEstateCompany = db.RealEstateCompanies.Find(id);
        //    db.RealEstateCompanies.Remove(realEstateCompany);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        private bool ValidateImage(HttpPostedFileBase logo)
        {
            var Isvalid = true;
            if (logo == null || logo.ContentLength == 0)
            {
                ModelState.AddModelError("LogoFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            ValidationResult result = ImageHelper.ValidateImage(logo, ImageTypes.Logo);
            if (!result.IsValid)
            {
                ModelState.AddModelError("LogoFile", result.Message);
                Isvalid = false;
            }
            return Isvalid;
        }
        private void AddInitialData(RealEstateCompany realEstateCompany)
        {
            realEstateCompany.ActivateStatusID = (int)ActiveStatus.New;
            realEstateCompany.Code = "C-" + Guid.NewGuid().ToString();
            realEstateCompany.CreatedDate = DateTime.Now;
            realEstateCompany.CurrentProjectNos = 0;
            realEstateCompany.CurrentUserNos = 1;
            realEstateCompany.IsSpecial = false;
            realEstateCompany.ProjectNos = 5;
            realEstateCompany.ShowOnFrontEnd = false;
            realEstateCompany.UserNos = 5;
        }
        private void SaveImage(RealEstateCompany realEstateCompany)
        {
            string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Companies", realEstateCompany.Code);

            realEstateCompany.Logo = ImagePath + "/" + realEstateCompany.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateCompany.LogoFile.FileName);
            string filename = Server.MapPath(ImagePath) + "\\" + realEstateCompany.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateCompany.LogoFile.FileName);
            ImageHelper.ApplyCompressionAndSave(realEstateCompany.LogoFile, filename, 70, realEstateCompany.LogoFile.ContentType);

        }
        private void AddInSiteMap(RealEstateCompany data)
        {
            SitemapNode node;
            node = new SitemapNode();
            node.Frequency = SitemapFrequency.Weekly;
            node.LastModified = DateTime.Now;
            node.Priority = 0.3;
            node.Url = ConfigurationSettings.AppSettings["WebSite"]+"/" + Commons.EncodeText("شركات_عقارية")+"/" + data.ID + "/" + Commons.EncodeText(data.Title); ;
            node.EncodeURL = true;
            node.Images = new List<SitemapImageNode>();
            SiteMapGenerator gen = new SiteMapGenerator();
            gen.AddNewNode(node, Server.MapPath("~/SiteMap.Xml"));

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
