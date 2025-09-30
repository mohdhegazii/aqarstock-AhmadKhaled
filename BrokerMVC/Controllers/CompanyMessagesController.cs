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
using BrokerMVC.Extensions;
using ResourcesFiles;

namespace BrokerMVC.Controllers
{
    public class CompanyMessagesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: CompanyMessages
        public ActionResult Index( int? ProjectID,int? currentFilter, int? page, string sortOrder)
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            Commons.UserID = subscriber.ID;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.ProjectSortParm = sortOrder == "Project" ? "Project_desc" : "Project";
            ViewBag.NewSortParm = sortOrder == "New" ? "New" : "New";
            if (ProjectID != null)
            {
                page = 1;
            }
            else
            {
                ProjectID = currentFilter;
            }

            ViewBag.CurrentFilter = ProjectID;
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var subscriberNotifications = from C in db.CompanyMessages where C.CompanyID == subscriber.CompanyID
                                          && C.IsDeleted != true && C.IsInquiry != true select C;
            if (ProjectID!=null)
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.ProjectID==ProjectID);
                var project = db.RealEstateProjects.Find(ProjectID);
                ViewBag.ProjectID = new SelectList(db.RealEstateProjects.Where(p=>p.CompanyID==subscriber.CompanyID).OrderBy(c => c.Title), "ID", "Title", project);
            }
            else
            {
                ViewBag.ProjectID = new SelectList(db.RealEstateProjects.Where(p => p.CompanyID == subscriber.CompanyID).OrderBy(c => c.Title), "ID", "Title");
            }

            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.CreatedDate);
                    break;
                case "Project":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstateProject.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "Project_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstateProject.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "New":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.IsRead).ThenByDescending(c => c.CreatedDate);
                    break;
                default:
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.CreatedDate);
                    break;
            }
            return View(subscriberNotifications.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetMessages(int? ProjectID, string date, int? currentFilter, int? page, string sortOrder)
        {
            //Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            //Commons.UserID = subscriber.ID;
            ViewBag.date = date;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.ProjectSortParm = sortOrder == "Project" ? "Project_desc" : "Project";
            ViewBag.NewSortParm = sortOrder == "New" ? "New" : "New";
            if (ProjectID != null)
            {
                page = 1;
            }
            else
            {
                ProjectID = currentFilter;
            }

            ViewBag.CurrentFilter = ProjectID;
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var subscriberNotifications = from C in db.CompanyMessages
                                          where  C.IsDeleted != true && C.IsInquiry != true
                                          select C;
            if (!String.IsNullOrEmpty(date))
            {
                DateTime d = Convert.ToDateTime(date);
                subscriberNotifications = subscriberNotifications.Where(s => s.CreatedDate >= d);
            }
            if (ProjectID != null)
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.ProjectID == ProjectID);
                var project = db.RealEstateProjects.Find(ProjectID);
                ViewBag.ProjectID = new SelectList(db.RealEstateProjects.OrderBy(c => c.Title), "ID", "Title", project);
            }
            else
            {
                ViewBag.ProjectID = new SelectList(db.RealEstateProjects.OrderBy(c => c.Title), "ID", "Title");
            }
   
            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.CreatedDate);
                    break;
                case "Project":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.RealEstateProject.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "Project_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.RealEstateProject.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "New":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.IsRead).ThenByDescending(c => c.CreatedDate);
                    break;
                default:
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.CreatedDate);
                    break;
            }
            return View(subscriberNotifications.ToPagedList(pageNumber, pageSize));
        }

        // GET: CompanyMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyMessage companyMessage = db.CompanyMessages.Find(id);
            if (companyMessage == null)
            {
                return HttpNotFound();
            }
            if(!Security.IsUserInRole(Roles.Admin))
            { 
            companyMessage.IsRead = true;
            db.SaveChanges();
            }
            return PartialView(companyMessage);
        }

        // GET: CompanyMessages/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code");
            ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude");
            return View();
        }

        // POST: CompanyMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,ProjectID,Name,Phone,Email,Message,CreatedDate,IsRead,IsDeleted")] CompanyMessage companyMessage)
        {
            if (ModelState.IsValid)
            {
                db.CompanyMessages.Add(companyMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", companyMessage.CompanyID);
            ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude", companyMessage.ProjectID);
            return View(companyMessage);
        }

        // GET: CompanyMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyMessage companyMessage = db.CompanyMessages.Find(id);
            if (companyMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", companyMessage.CompanyID);
            ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude", companyMessage.ProjectID);
            return View(companyMessage);
        }

        // POST: CompanyMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,ProjectID,Name,Phone,Email,Message,CreatedDate,IsRead,IsDeleted")] CompanyMessage companyMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.RealEstateCompanies, "ID", "Code", companyMessage.CompanyID);
            ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude", companyMessage.ProjectID);
            return View(companyMessage);
        }

        // GET: CompanyMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyMessage companyMessage = db.CompanyMessages.Find(id);
            if (companyMessage == null)
            {
                return HttpNotFound();
            }
            companyMessage.IsDeleted = true;
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // POST: CompanyMessages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CompanyMessage companyMessage = db.CompanyMessages.Find(id);
        //    db.CompanyMessages.Remove(companyMessage);
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
