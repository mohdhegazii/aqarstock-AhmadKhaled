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
    [AuthorizeRoles(Roles.Subscriber)]
    public class SubscriberNotificationsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: SubscriberNotifications
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            Commons.UserID = subscriber.ID;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "Type_desc" : "Type";
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
            var subscriberNotifications = from C in db.SubscriberNotifications where C.SubscriberID==Commons.UserID select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                subscriberNotifications = subscriberNotifications.Where(s => s.Title.Contains(searchString)
                                       || s.ObjectName.Contains(searchString));
            }

            switch (sortOrder)
            {

                case "Date":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.CreatedDate);
                    break;
                case "Type":
                    subscriberNotifications = subscriberNotifications.OrderBy(c => c.ObjectTypeID).ThenByDescending(c => c.CreatedDate);
                    break;
                case "Type_desc":
                    subscriberNotifications = subscriberNotifications.OrderByDescending(c => c.ObjectTypeID).ThenByDescending(c => c.CreatedDate);
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

        // GET: SubscriberNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberNotification subscriberNotification = db.SubscriberNotifications.Find(id);
            subscriberNotification.IsRead = true;
            db.Entry(subscriberNotification).State = EntityState.Modified;
            db.SaveChanges();
            if (subscriberNotification == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details",subscriberNotification);
        }

        // GET: SubscriberNotifications/Create
        public ActionResult Create()
        {
            ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName");
            return View();
        }

        // POST: SubscriberNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SubscriberID,Title,Description,IsRead,CreatedDate,ObjectTypeID,ObjectID,ObjectName")] SubscriberNotification subscriberNotification)
        {
            if (ModelState.IsValid)
            {
                db.SubscriberNotifications.Add(subscriberNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", subscriberNotification.SubscriberID);
            return View(subscriberNotification);
        }

        // GET: SubscriberNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberNotification subscriberNotification = db.SubscriberNotifications.Find(id);
            if (subscriberNotification == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", subscriberNotification.SubscriberID);
            return View(subscriberNotification);
        }

        // POST: SubscriberNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SubscriberID,Title,Description,IsRead,CreatedDate,ObjectTypeID,ObjectID,ObjectName")] SubscriberNotification subscriberNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriberNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubscriberID = new SelectList(db.Subscribers, "ID", "FullName", subscriberNotification.SubscriberID);
            return View(subscriberNotification);
        }

        // GET: SubscriberNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberNotification subscriberNotification = db.SubscriberNotifications.Find(id);
            if (subscriberNotification == null)
            {
                return HttpNotFound();
            }
            db.SubscriberNotifications.Remove(subscriberNotification);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // POST: SubscriberNotifications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SubscriberNotification subscriberNotification = db.SubscriberNotifications.Find(id);
        //    db.SubscriberNotifications.Remove(subscriberNotification);
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
