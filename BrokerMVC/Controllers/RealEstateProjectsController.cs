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
using System.IO;
using ResourcesFiles;
using BrokerMVC.Extensions;
using System.Configuration;
using BrokerMVC.Code.Repositories;
using System.Web.UI;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin, Roles.CompanyEmployee, Roles.CompanyAdmin)]
    public class RealEstateProjectsController : BaseController
    {
       // private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        private ProjectRepository Repository = new ProjectRepository(new RealEstateBrokerEntities());
        // GET: RealEstateProjects
        [AuthorizeRoles(Roles.Admin)]
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,currentFilter,searchString,CompanyID,sortOrder", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult Index(string currentFilter, string searchString, int? CompanyID, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CompanySortParm = sortOrder == "Company" ? "Company_desc" : "Company";
            ViewBag.SpecialSortParm = sortOrder == "Special_desc" ? "Special" : "Special_desc";
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
            ViewBag.Company = CompanyID;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var projects = Repository.GetAll(CompanyID, searchString, sortOrder, pageNumber, pageSize);
            CompanyRepository CompanyRep = new CompanyRepository(new RealEstateBrokerEntities());
            if (CompanyID != null)
            {

                var company = CompanyRep.GetCompanyByID(CompanyID);
                ViewBag.CompanyID = new SelectList(CompanyRep.GetAll(), "ID", "Title", company);
            }
            else
            {
                ViewBag.CompanyID = new SelectList(CompanyRep.GetAll(), "ID", "Title");
            }

            return View(projects);
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page,currentFilter,searchString,type,sortOrder", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetProjects(string currentFilter, string searchString, string type, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
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
            IPagedList<RealEstateProject> realEstateProjects;
            if (!String.IsNullOrEmpty(type))
            {

                realEstateProjects = Repository.GetAll(sub.CompanyID, searchString, sortOrder, pageNumber, pageSize);
            }
            else
            {
                realEstateProjects = Repository.GetAllBySubscriber(sub.ID, searchString, sortOrder, pageNumber, pageSize);
            }
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //}
            //else
            //{
            //    ViewBag.CompanyID = new SelectList(db.RealEstateCompanies.OrderBy(c => c.Title), "ID", "Title");
            //}
            return View(realEstateProjects.ToPagedList(pageNumber, pageSize));
        }
        // GET: RealEstateProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProject realEstateProject = Repository.GetByProjectID(id);
            if (realEstateProject == null)
            {
                return HttpNotFound();
            }
            return View(realEstateProject);
        }

        // GET: RealEstateProjects/Create
        [AuthorizeRoles(Roles.CompanyAdmin, Roles.CompanyEmployee)]
        public ActionResult Create()
        {
            Subscriber sub = Repository.GetSubscriber(Commons.UserName);
            RealEstateCompany comp = Repository.GetCompany(sub.CompanyID);
    
                if (comp.CurrentProjectNos >= comp.ProjectNos)
            {
                SubscriptionErrorMessage msg = new SubscriptionErrorMessage();
                msg.CurrentNo = comp.CurrentProjectNos;
                msg.TotalNo = comp.ProjectNos;
                //msg.type=Commons.
                return View("CantAddProjectView", msg);
            }
            else
            {
                var Countries = Repository.GetCountries();
                var country =Countries.FirstOrDefault();
                var cities = Repository.GetCities(country.ID);
                var city = cities.FirstOrDefault() ;
                ViewBag.CityID = new SelectList(cities, "ID", "Name");
                ViewBag.CountryID = new SelectList(Countries, "ID", "Name");
                ViewBag.DistrictID = new SelectList(Repository.GetDistricts(city.ID), "ID", "Name");
                return View();
            }
        }

   
        // POST: RealEstateProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RealEstateProject realEstateProject)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = ValidateImage(realEstateProject.LogoFile);
                if (Isvalid == true)
                {
                    Subscriber sub = Repository.GetSubscriber(Commons.UserName);
                    RealEstateCompany comp = Repository.GetCompany(sub.CompanyID);
                    realEstateProject.Code = "P-" + Guid.NewGuid().ToString();
                    realEstateProject.ActiveStatusID = (int)ActiveStatus.New;
                    realEstateProject.AdPackageID = (int)AdPackage.Normal;
                    realEstateProject.CreatedDate = DateTime.Now;
                    realEstateProject.CompanyID = sub.CompanyID;
                    realEstateProject.SubscriberID = sub.ID;
                    SaveImage(realEstateProject);
                    Repository.Add(realEstateProject);
                    int number = comp.CurrentProjectNos.Value+1;
                    Repository.UpdateCompanyProjectNo(comp.ID,number);
                    Repository.Save();
                    Repository.LogAction(Modules.Projects, subscriberActions.AddNew, realEstateProject.ID, realEstateProject.Title);
                    Repository.Save();
                   
                    return RedirectToAction("Edit", new { id = realEstateProject.ID });
                }

            }

            ViewBag.CityID = new SelectList(Repository.GetCities(realEstateProject.CountryID), "ID", "Name", realEstateProject.CityID);
            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", realEstateProject.CountryID);
            ViewBag.DistrictID = new SelectList(Repository.GetDistricts(realEstateProject.CityID), "ID", "Name", realEstateProject.DistrictID);
            return View(realEstateProject);
        }

        // GET: RealEstateProjects/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProject realEstateProject = Repository.GetByProjectID(id);
            if (realEstateProject == null)
            {
                return HttpNotFound();
            }
            ProjectBasicData basic = GetProjectBasicData(realEstateProject);

            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", realEstateProject.CityID);
            //ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", realEstateProject.CountryID);
            //ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", realEstateProject.DistrictID);
            //ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", realEstateProject.CompanyID);
            //ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", realEstateProject.SubscriberID);
            return View(basic);
        }

        // POST: RealEstateProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectBasicData basic)
        {
            if (ModelState.IsValid)
            {
                RealEstateProject realEstateproject = Repository.GetByProjectID(basic.ID);
                realEstateproject.Description = basic.Description;
                realEstateproject.EnDesctiption = basic.EnDescription;
                realEstateproject.EnSologan = basic.EnSlogan;
                realEstateproject.EnTitle = basic.EnName;
                realEstateproject.Sologan = basic.Slogan;
                realEstateproject.Title = basic.Name;
                realEstateproject.EnSummary = basic.EnSummary;
                realEstateproject.Summary = basic.Summary;
                if (basic.LogoFile != null)
                {
                    realEstateproject.LogoFile = basic.LogoFile;
                   bool Isvalid = ValidateImage(realEstateproject.LogoFile);
                    if (Isvalid == true)
                    {
                        SaveImage(realEstateproject);
                    }
                }
                Repository.Update(realEstateproject);
                if (realEstateproject.ActiveStatusID == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                {
                    Repository.LogAction(Modules.Projects, subscriberActions.Updated, realEstateproject.ID, realEstateproject.Title);
                }
                Repository.Save();
                GetBasicAdditionalData(realEstateproject, basic);
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                //return RedirectToAction("Index");
            }
            //ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", realEstateProject.CityID);
            //ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", realEstateProject.CountryID);
            //ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", realEstateProject.DistrictID);
            //ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", realEstateProject.CompanyID);
            //ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", realEstateProject.SubscriberID);
            return View(basic);
        }
        public ActionResult EditAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressData address = Repository.GetProjectAddress(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            

            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", address.CountryID);
            ViewBag.CityID = new SelectList(Repository.GetCities( address.CountryID), "ID", "Name", address.CityID);
            ViewBag.DistrictID = new SelectList(Repository.GetDistricts(address.CityID), "ID", "Name", address.DistrictID);
            return View(address);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(AddressData address)
        {
            if (ModelState.IsValid)
            {
                RealEstateProject realEstateCompany = Repository.GetByProjectID(address.ID);
                realEstateCompany.CityID = address.CityID;
                realEstateCompany.CountryID = address.CountryID;
                realEstateCompany.DistrictID = address.DistrictID;
                realEstateCompany.Latitude = address.Latitude;
                realEstateCompany.Longitude = address.Longitude;
                Repository.Update(realEstateCompany);
                Repository.Save();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = address.ID });
            }
            return View(address);
        }
        //private AddressData GetAddressData(RealEstateProject realEstateCompany)
        //{
        //    AddressData address = new AddressData();
        //    address.ID = realEstateCompany.ID;
        //    address.Name = realEstateCompany.Title;
        //    address.Logo = realEstateCompany.Logo;
        //    address.CityID = realEstateCompany.CityID;
        //    address.CountryID = realEstateCompany.CountryID;
        //    address.DistrictID = realEstateCompany.DistrictID;
        //    address.Latitude = realEstateCompany.Latitude;
        //    address.Longitude = realEstateCompany.Longitude;
        //    return address;

        //}

        [AuthorizeRoles(Roles.Admin)]
        public ActionResult SetAdPackage(int? id, int? AdPackageID)
        {
            RealEstateProject realEstateCompany = Repository.GetByProjectID(id);
            realEstateCompany.AdPackageID = AdPackageID;
            Repository.Update(realEstateCompany);
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Activate(int? id)
        {
            RealEstateProject realEstateCompany =Repository.GetByProjectID(id);
            realEstateCompany.ActiveStatusID = (int)ActiveStatus.Active;
            realEstateCompany.StatusChangeDate = DateTime.Now;
            Repository.Update(realEstateCompany);
            Repository.RemoveLog(realEstateCompany.ID, (int)Modules.Projects);
            Repository.Save();
            this.AddInSiteMap(realEstateCompany);
            
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Suspend(int? id)
        {
            RealEstateProject realEstateCompany = Repository.GetByProjectID(id);
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
                RealEstateProject realEstateCompany = Repository.GetByProjectID(suspend.ID);
                realEstateCompany.ActiveStatusID = (int)ActiveStatus.Suspended;
                realEstateCompany.SuspendMessage = suspend.Message;
                realEstateCompany.SuspendReasonID = suspend.SuspendReasonID;
                realEstateCompany.StatusChangeDate = DateTime.Now;
                Repository.Update(realEstateCompany);
                Repository.RemoveLog(realEstateCompany.ID, (int)Modules.Projects);
                this.NotifySubscriber(suspend, realEstateCompany);
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
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id,type", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult ProjectPhotos(int? id, string type)
        {
            RealEstateProject realEstateCompany = Repository.GetByProjectID(id);
            ViewBag.ProjectID = id;
            if (type == "List")
            {
                ViewBag.ProjectName = realEstateCompany.Title;
                ViewBag.Logo = realEstateCompany.Logo;
                return View("ProjectPhotosList", realEstateCompany.RealEstateProjectPhotos);

            }
            else
            {
                return PartialView("ProjectPhotosSlider", realEstateCompany.RealEstateProjectPhotos);
            }
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult ProjectVideos(int? id)
        {
            var Videos = Repository.GetProjectVideos(id);
            ViewBag.ProjectID = id;
            return PartialView("ProjectVideos", Videos.ToList());

        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult ProjectModels(int? id)
        {

            var Videos = Repository.GetProjectModels(id);
            ViewBag.ProjectID = id;
            return PartialView("ProjectModels", Videos.ToList());

        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult ProjectRealEstates(int? id)
        {

            var Videos = Repository.GetProjectRealestates(id);
            ViewBag.ProjectID = id;
            return PartialView("ProjectRealEstates", Videos.ToList());

        }
        public ActionResult RemoveRealEstates(int? id)
        {
            int ProjectID = Repository.RemoveRealestate(id);
            Repository.Save();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = ProjectID });
        }
        public ActionResult AddRealEstates(int? id)
        {
            AddRealEstateToProject addrealestate = new AddRealEstateToProject();
            RealEstateProject project = Repository.GetByProjectID(id);
            addrealestate.ProjectID = project.ID;
            addrealestate.ProjectLogo = project.Logo;
            addrealestate.ProjectName = project.Title;
            var realestate = Repository.GetCompanyIndividualRealEstates(project);
            addrealestate.Realestates = realestate.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.ID.ToString(),
                Selected = false
            }).ToList();
            return View(addrealestate);
        }
        [HttpPost]
        public ActionResult AddRealEstates(AddRealEstateToProject addrealestate)
        {
            foreach (SelectListItem item in addrealestate.Realestates.Where(r => r.Selected == true))
            {
                Repository.AddToProject(addrealestate.ProjectID.Value, Convert.ToInt32(item.Value));
            }
            Repository.Save();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = addrealestate.ProjectID });
        }
        // GET: RealEstateProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProject realEstateProject = Repository.GetByProjectID(id);
            if (realEstateProject == null)
            {
                return HttpNotFound();
            }
            return View(realEstateProject);
        }

        // POST: RealEstateProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.Delete(id);
            Repository.Save();
            return RedirectToAction("GetProjects");
        }
        private static ProjectBasicData GetProjectBasicData(RealEstateProject realEstateProject)
        {
            ProjectBasicData basic = new ProjectBasicData();
            basic.ID = realEstateProject.ID;
            basic.AdPackageID = realEstateProject.AdPackageID;
            basic.Description = realEstateProject.Description;
            basic.EnDescription = realEstateProject.EnDesctiption;
            basic.EnName = realEstateProject.EnTitle;
            basic.EnSlogan = realEstateProject.EnSologan;
            basic.Latitude = realEstateProject.Latitude;
            basic.Logo = realEstateProject.Logo;
            basic.Longutide = realEstateProject.Longitude;
            basic.Name = realEstateProject.Title;
            basic.Slogan = realEstateProject.Sologan;
            basic.Summary = realEstateProject.Summary;
            basic.EnSummary = realEstateProject.EnSummary;
            basic.Address = realEstateProject.District.Name + " " + realEstateProject.City.Name + " " + realEstateProject.Country.Name;

            GetBasicAdditionalData(realEstateProject, basic);

            return basic;
        }

        private static void GetBasicAdditionalData(RealEstateProject realEstateProject, ProjectBasicData basic)
        {
            basic.UserId = realEstateProject.Subscriber.ID;
            basic.UserEmail = realEstateProject.Subscriber.Email;
            basic.UserName = realEstateProject.Subscriber.FullName;
            basic.UserPhone = realEstateProject.Subscriber.MobileNo;

            basic.CompanyID = realEstateProject.RealEstateCompany.ID;
            basic.CompanyName = realEstateProject.RealEstateCompany.Title;
            basic.CompanyEmail = realEstateProject.RealEstateCompany.Email;
            basic.CompanyPhone = realEstateProject.RealEstateCompany.Phone;

            if (realEstateProject.ActiveStatusID == (int)ActiveStatus.Suspended)
            {
                basic.SuspendData = new Suspend();
                basic.SuspendData.SuspendReason = realEstateProject.SuspendReason.Title;
                basic.SuspendData.Message = realEstateProject.SuspendMessage;
            }
            //  return basic;
        }

        private void SaveImage(RealEstateProject realEstateProject)
        {
            string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Projects", realEstateProject.Code);
            realEstateProject.Logo = ImagePath + "/" + realEstateProject.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateProject.LogoFile.FileName);
            string filename = Server.MapPath(ImagePath) + "\\" + realEstateProject.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateProject.LogoFile.FileName);
            ImageHelper.ApplyCompressionAndSave(realEstateProject.LogoFile, filename, 70, realEstateProject.LogoFile.ContentType);

        }
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
        private void NotifySubscriber(Suspend suspend, RealEstateProject realEstateCompany)
        {
            SuspendReason reason = Repository.GetSuspendReasonById(suspend.SuspendReasonID);
            SubscriberNotification notification = new SubscriberNotification();
            notification.CreatedDate = DateTime.Now;
            notification.Description = "تم حجب بيانات " + realEstateCompany.Title + " بعد مراجعتها<br/>";
            notification.Description += "سبب الحجب: " + reason.Title + "<br/>";
            notification.Description += "تفاصيل: " + suspend.Message;
            notification.IsRead = false;
            notification.ObjectID = realEstateCompany.ID;
            notification.ObjectTypeID = (int)Modules.Projects;
            notification.ObjectName = realEstateCompany.Title;
            notification.SubscriberID = realEstateCompany.SubscriberID;
            notification.Title = "تم حجب بيانات  " + realEstateCompany.Title;
            Repository.AddNotification(notification);

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
            new MailController().SuspendObject(realEstateCompany.Subscriber.Email, reason.Title, suspend.Message, realEstateCompany.Title).Deliver();
        }
        private void AddInSiteMap(RealEstateProject data)
        {
            SitemapNode node;
            node = new SitemapNode();
            node.Frequency = SitemapFrequency.Weekly;
            node.LastModified = DateTime.Now;
            node.Priority = 0.3;
            node.Url = ConfigurationSettings.AppSettings["WebSite"]+'/' + Commons.EncodeText("مشاريع_عقارية") + "/" + data.ID + "/" + Commons.EncodeText(data.Title); ;
            node.EncodeURL = true;
            node.Images = new List<SitemapImageNode>();
            //if (data.ProductPhotos.Count > 0)
            //{
            //    AddProductPhotoNode(node, data);
            //}
            SiteMapGenerator gen = new SiteMapGenerator();
            gen.AddNewNode(node, Server.MapPath("~/SiteMap.Xml"));
            Code.GeneralClasses.AqarFeedsGenerator.GenerateProjectFeedItem(data);
        }
        private static void AddProjectPhotoNode(SitemapNode node, RealEstateProject product)
        {
            SitemapImageNode imgNode;

            //foreach (ProductPhoto photo in product.ProductPhotos)
            //{
            //    imgNode = new SitemapImageNode();
            //    imgNode.Caption = product.Name + " - " + product.EnName;
            //    imgNode.Title = product.Name + " - " + product.EnName;
            //    imgNode.Loc = Commons.Website + "/" + photo.PhotoURL;
            //    node.Images.Add(imgNode);
            //}
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
