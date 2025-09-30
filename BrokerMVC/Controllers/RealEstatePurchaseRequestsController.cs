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
using ResourcesFiles;
using BrokerMVC.Extensions;

namespace BrokerMVC.Controllers
{
    
    public class RealEstatePurchaseRequestsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstatePurchaseRequests
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            Commons.UserID = subscriber.ID;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.RealEstateSortParm = sortOrder == "RealEstate" ? "RealEstate_desc" : "RealEstate";
            ViewBag.NewSortParm = sortOrder == "New" ? "New" : "New";
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
            var subscriberNotifications = from C in db.RealEstatePurchaseRequests where C.RealEstate.SubscriberID == Commons.UserID 
                                          && C.IsDeleted==false && C.IsInquiry==false select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.Title.Contains(searchString)
                                       || s.RealEstate.EnTitle.Contains(searchString));
            }

            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.Date);
                    break;
                case "RealEstate":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "RealEstate_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "New":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.IsRead).ThenByDescending(c => c.Date);
                    break;
                default:
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.Date);
                    break;
            }
            return View(subscriberNotifications.ToPagedList(pageNumber, pageSize));
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult GetRequests(string currentFilter,int? CountryID, int? CityId, int? DistrictId, string date, string searchString, int? page, string sortOrder)
        {
          
            ViewBag.date = date;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.RealEstateSortParm = sortOrder == "RealEstate" ? "RealEstate_desc" : "RealEstate";
            ViewBag.EmployeeSortParm = sortOrder == "Employee" ? "Employee_desc" : "Employee";
            ViewBag.NewSortParm = sortOrder == "New" ? "New_desc" : "New";
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
            ViewBag.Country = CountryID;
            ViewBag.City = CityId;
            ViewBag.District = DistrictId;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var subscriberNotifications = from C in db.RealEstatePurchaseRequests
                                          where  C.IsDeleted == false && C.IsInquiry == false
                                          select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.Title.Contains(searchString) || s.RealEstate.EnTitle.Contains(searchString)
                                           || s.RealEstate.RealEstateStatu.Title.Contains(searchString) || s.RealEstate.SaleType.Title.Contains(searchString)
                  || s.RealEstate.PaymentType.Title.Contains(searchString) || s.RealEstate.District.Name.Contains(searchString)
                  || s.RealEstate.City.Name.Contains(searchString) || s.RealEstate.Country.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(date))
            {
                DateTime d = Convert.ToDateTime(date);
                subscriberNotifications = subscriberNotifications.Where(s => s.Date >= d);
            }
            if (CountryID != null)
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.CountryID == CountryID);
                var project = db.Countries.Find(CountryID);
                ViewBag.CountryID = new SelectList(db.Countries.OrderBy(c => c.Name), "ID", "Name", project);
                if (CityId != null)
                {
                    subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.CityID == CityId);
                    var city = db.Cities.Find(CityId);
                    ViewBag.CityId = new SelectList(db.Cities.Where(c=>c.CountryID==CountryID).OrderBy(c => c.Name), "ID", "Name", city);
                    if (DistrictId != null)
                    {
                        subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.DistrictID == DistrictId);
                        var didtrict = db.Districts.Find(DistrictId);
                        ViewBag.DistrictId = new SelectList(db.Districts.Where(c => c.CityID == CityId).OrderBy(c => c.Name), "ID", "Name", didtrict);
                    }
                    else
                    {
                        ViewBag.DistrictId = new SelectList(db.Districts.Where(c => c.CityID == CityId).OrderBy(c => c.Name), "ID", "Name");
                    }
                }
                else
                {
                    ViewBag.CityId = new SelectList(db.Cities.Where(c=>c.CountryID==CountryID).OrderBy(c => c.Name), "ID", "Name");
                }
            }
            else
            {
                ViewBag.CountryID = new SelectList(db.Countries.OrderBy(c => c.Name), "ID", "Name");
                var country = db.Countries.OrderBy(c => c.Name).First();
                ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == CountryID).OrderBy(c => c.Name), "ID", "Name");
                var city = db.Cities.Where(c => c.CountryID == country.ID).First();
                ViewBag.DistrictId = new SelectList(db.Districts.Where(c => c.CityID == city.ID).OrderBy(c => c.Name), "ID", "Name");
            }
            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.Date);
                    break;
                case "RealEstate":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "RealEstate_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "Employee":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstate.Subscriber.FullName).ThenByDescending(c => c.Date);
                    break;
                case "Employee_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstate.Subscriber.FullName).ThenByDescending(c => c.Date);
                    break;
                case "New":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.IsRead).ThenByDescending(c => c.Date);
                    break;
                case "New_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.IsRead).ThenByDescending(c => c.Date);
                    break;
                default:
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.Date);
                    break;
            }
            return View(subscriberNotifications.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetReport(string currentFilter,int?subscriberId,string date, string searchString, int? page, string sortOrder)
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            Commons.UserID = subscriber.ID;
            var subscribers = db.Subscribers.Where(s => s.CompanyID == subscriber.CompanyID);
            ViewBag.subscriberId = new SelectList(subscribers, "ID", "FullName", subscriberId);
            ViewBag.subscriber = subscriberId;
            ViewBag.date = date;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.RealEstateSortParm = sortOrder == "RealEstate" ? "RealEstate_desc" : "RealEstate";
            ViewBag.EmployeeSortParm = sortOrder == "Employee" ? "Employee_desc" : "Employee";
            ViewBag.NewSortParm = sortOrder == "New" ? "New_desc" : "New";
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
            var subscriberNotifications = from C in db.RealEstatePurchaseRequests
                                          where C.RealEstate.Subscriber.CompanyID == subscriber.CompanyID
  && C.IsDeleted == false && C.IsInquiry == false
                                          select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.Title.Contains(searchString) || s.RealEstate.EnTitle.Contains(searchString)
                                           || s.RealEstate.RealEstateStatu.Title.Contains(searchString) || s.RealEstate.SaleType.Title.Contains(searchString)
                  || s.RealEstate.PaymentType.Title.Contains(searchString) || s.RealEstate.District.Name.Contains(searchString)
                  || s.RealEstate.City.Name.Contains(searchString) || s.RealEstate.Country.Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(date))
            {
                DateTime d = Convert.ToDateTime(date);
                subscriberNotifications = subscriberNotifications.Where(s => s.Date >= d);
            }
                if (subscriberId!=null)
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.RealEstate.SubscriberID == subscriberId);
            }
            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.Date);
                    break;
                case "RealEstate":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "RealEstate_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstate.Title).ThenByDescending(c => c.Date);
                    break;
                case "Employee":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstate.Subscriber.FullName).ThenByDescending(c => c.Date);
                    break;
                case "Employee_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstate.Subscriber.FullName).ThenByDescending(c => c.Date);
                    break;
                case "New":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.IsRead).ThenByDescending(c => c.Date);
                    break;
                case "New_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.IsRead).ThenByDescending(c => c.Date);
                    break;
                default:
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.Date);
                    break;
            }
            return View(subscriberNotifications.ToPagedList(pageNumber, pageSize));
        }
        // GET: RealEstatePurchaseRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstatePurchaseRequest realEstatePurchaseRequest = db.RealEstatePurchaseRequests.Find(id);
            if(!Security.IsUserInRole(Roles.Admin))
            { 
            realEstatePurchaseRequest.IsRead = true;
            db.SaveChanges();
            }
            if (realEstatePurchaseRequest == null)
            {
                return HttpNotFound();
            }
            return PartialView(realEstatePurchaseRequest);
        }

        // GET: RealEstatePurchaseRequests/Create
        public ActionResult Create()
        {
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street");
            return View();
        }

        // POST: RealEstatePurchaseRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RealEstateID,PurchaserName,PurchaserPhone,PurchaserEmail,Message,Date,IsDeleted,IsRead,IsInquiry")] RealEstatePurchaseRequest realEstatePurchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.RealEstatePurchaseRequests.Add(realEstatePurchaseRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstatePurchaseRequest.RealEstateID);
            return View(realEstatePurchaseRequest);
        }

        // GET: RealEstatePurchaseRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstatePurchaseRequest realEstatePurchaseRequest = db.RealEstatePurchaseRequests.Find(id);
            if (realEstatePurchaseRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstatePurchaseRequest.RealEstateID);
            return View(realEstatePurchaseRequest);
        }

        // POST: RealEstatePurchaseRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RealEstateID,PurchaserName,PurchaserPhone,PurchaserEmail,Message,Date,IsDeleted,IsRead,IsInquiry")] RealEstatePurchaseRequest realEstatePurchaseRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstatePurchaseRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstatePurchaseRequest.RealEstateID);
            return View(realEstatePurchaseRequest);
        }

        // GET: RealEstatePurchaseRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstatePurchaseRequest realEstatePurchaseRequest = db.RealEstatePurchaseRequests.Find(id);
            if (realEstatePurchaseRequest == null)
            {
                return HttpNotFound();
            }
            realEstatePurchaseRequest.IsDeleted = true;
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // POST: RealEstatePurchaseRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstatePurchaseRequest realEstatePurchaseRequest = db.RealEstatePurchaseRequests.Find(id);
        //    db.RealEstatePurchaseRequests.Remove(realEstatePurchaseRequest);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
