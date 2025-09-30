using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Code.Repositories;
using BrokerMVC.Models;
using PagedList;
using BrokerMVC.Extensions;
using ResourcesFiles;
using BrokerMVC.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee, Roles.Employee, Roles.Subscriber)]
    public class SubscribersController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Subscribers
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.ArabicNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnglishNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.UserNameSortParm = sortOrder == "UserName" ? "UserName_desc" : "UserName";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var subscribers = from C in db.Subscribers select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                subscribers = subscribers.Where(s => s.FullName.Contains(searchString)
                                       || s.EnFullName.Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.MobileNo.Contains(searchString)
                                       || s.UserName.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    subscribers = subscribers.OrderByDescending(c => c.FullName);
                    break;
                case "EnName":
                    subscribers = subscribers.OrderBy(c => c.EnFullName).ThenBy(c => c.FullName);
                    break;
                case "EnName_desc":
                    subscribers = subscribers.OrderByDescending(c => c.EnFullName).ThenBy(c => c.FullName);
                    break;
                case "UserName":
                    subscribers = subscribers.OrderBy(c => c.UserName).ThenBy(c => c.FullName);
                    break;
                case "UserName_desc":
                    subscribers = subscribers.OrderByDescending(c => c.UserName).ThenBy(c => c.FullName);
                    break;
                default:
                    subscribers = subscribers.OrderBy(c => c.FullName);
                    break;
            }
            return View(subscribers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Subscribers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code");
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,FullName,EnFullName,MobileNo,Email,UserName,CreatedDate,ActiveStatusID,ActivationCode,IsCompanyAdmin")] Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Subscribers.Add(subscriber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", subscriber.CompanyID);
            return View(subscriber);
        }

        // GET: Subscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            //   ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", subscriber.CompanyID);
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriber).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                // return RedirectToAction("Index");
            }
            subscriber.RealEstateCompany = db.RealEstateCompanies.FirstOrDefault(c => c.ID == subscriber.CompanyID);
            // ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", subscriber.CompanyID);
            return View(subscriber);
        }

        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Activate(int? id)
        {
            Subscriber user = db.Subscribers.Find(id);
            user.ActiveStatusID = (int)ActiveStatus.Active;
            user.ActivationCode = "";
            user.SuspendReasonID = null;
            user.SuspendMessage = "";
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            this.AddNotification(Messages.ActivatedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = id });
        }
        [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.Subscriber)]
        public ActionResult UpgradeUser(int? id)
        {
            Subscriber user = db.Subscribers.Find(id);
            user.IsCompanyAdmin = true;
            Security.AddUserToRole(user.UserName, Roles.CompanyAdmin);

            db.SaveChanges();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin)]
        public ActionResult DowndgradeUser(int? id)
        {
            Subscriber user = db.Subscribers.Find(id);
            user.IsCompanyAdmin = false;
            //  db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            Security.RemoveUserFromRole(user.UserName, Roles.CompanyAdmin);
            Security.AddUserToRole(user.UserName, Roles.CompanyEmployee);

            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return Redirect(Request.UrlReferrer.ToString());
        }
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Suspend(int? id)
        {
            Subscriber user = db.Subscribers.Find(id);
            Suspend s = new Suspend();
            s.ID = user.ID;
            ViewBag.SuspendReasonID = new SelectList(db.SuspendReasons, "ID", "Title");
            return PartialView("_Suspend", s);
        }

        [HttpPost]
        public ActionResult Suspend(Suspend suspend)
        {
            if (ModelState.IsValid)
            {
                Subscriber user = db.Subscribers.Find(suspend.ID);
                user.ActiveStatusID = (int)ActiveStatus.Suspended;
                user.SuspendMessage = suspend.Message;
                user.SuspendReasonID = suspend.SuspendReasonID;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SuspendedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
            else
            {
                this.AddNotification(Messages.ValidationError, NotificationType.ERROR);
                return RedirectToAction("Edit", new { id = suspend.ID });
            }
        }
        public ActionResult ResetPassword(int? id)
        {
            Password changePassword = new Password();
            changePassword.ID = id;
            return PartialView("ResetPassword", changePassword);
        }
        [HttpPost]
        public ActionResult ResetPassword(Password changePassword)
        {
            Subscriber user = db.Subscribers.Find(changePassword.ID);
            ApplicationDbContext context = new ApplicationDbContext();
            var um = new UserManager<ApplicationUser>(
            new UserStore<ApplicationUser>(context));
            var u = um.FindByName(user.UserName);
            um.RemovePassword(u.Id);
            um.AddPassword(u.Id, changePassword.password);
            this.AddNotification(Messages.ResetPassword, NotificationType.SUCCESS);
            return RedirectToAction("Edit", new { id = changePassword.ID });
        }
        public ActionResult SubscriberLatestRealestates(int? id)
        {
            ViewBag.UserID = id;
            var realestates = db.RealEstates.Where(r => r.SubscriberID == id);
            ViewBag.RealestateCount = realestates.Count();
            realestates = realestates.OrderByDescending(r => r.CreatedDate).Take(5);
            return PartialView("SubscriberLatestRealestates", realestates.ToList());
        }
        public ActionResult SubscriberRealestates(int? id, int? page, string sortOrder, string currentFilter, string searchString)
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
            var realestates = from C in db.RealEstates.Where(r => r.SubscriberID == id) select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                realestates = realestates.Where(r => r.Title.Contains(searchString) || r.Code.ToString() == searchString
                || r.RealEstateType.Title.Contains(searchString)
                  || r.RealEstateStatu.Title.Contains(searchString) || r.SaleType.Title.Contains(searchString)
                  || r.PaymentType.Title.Contains(searchString) || r.District.Name.Contains(searchString)
                  || r.City.Name.Contains(searchString) || r.Country.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    realestates = realestates.OrderBy(c => c.Title).ThenBy(c => c.CreatedDate);
                    break;
                case "name_desc":
                    realestates = realestates.OrderByDescending(c => c.Title).ThenBy(c => c.CreatedDate);
                    break;
                case "Special":
                    realestates = realestates.OrderByDescending(c => c.IsSpecialOffer).ThenBy(c => c.CreatedDate);
                    break;
                default:
                    realestates = realestates.OrderBy(c => c.CreatedDate);
                    break;
            }

            SubscriberRealEstate subestate = new SubscriberRealEstate();
            Subscriber sub = db.Subscribers.Find(id);
            subestate.ID = id;
            subestate.Name = sub.FullName;
            subestate.RealEstates = realestates.ToPagedList(pageNumber, pageSize);
            return View(subestate);
        }
        // GET: Subscribers/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subscriber = db.Subscribers.Include(p => p.RealEstateProjects).Include(p => p.RealEstates).Include(p => p.SubscriberFavouriteRealEstates).FirstOrDefault(p => p.ID == id);

            if (subscriber == null)
                return RedirectToAction("Index");

            var repository = new RealEstateRepository(new RealEstateBrokerEntities());
            foreach (var subscriberRealEstate in subscriber.RealEstates)
            {
                repository.Delete(subscriberRealEstate.ID);
            }
            repository.Save();
            //db.SubscriberFavouriteRealEstates.RemoveRange(subscriber.SubscriberFavouriteRealEstates);

            db.Subscribers.Remove(subscriber);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

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
