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
    [AuthorizeRoles(Roles.Admin)]
    public class RealEstateComplainsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateComplains
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var realEstateComplains = db.RealEstateComplains.Include(r => r.RealEstate);
            return View(realEstateComplains.OrderByDescending(c=>c.CreatedDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: RealEstateComplains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateComplain realEstateComplain = db.RealEstateComplains.Find(id);
            if (realEstateComplain == null)
            {
                return HttpNotFound();
            }
            realEstateComplain.IsRead = true;
            db.SaveChanges();
            return PartialView(realEstateComplain);
        }

        // GET: RealEstateComplains/Create
        public ActionResult Create()
        {
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street");
            return View();
        }

        // POST: RealEstateComplains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RealEstateID,ComplainerName,ComplainerEmail,ComplainerPhone,ComplainTitle,ComplainDetails,CreatedDate,IsRead")] RealEstateComplain realEstateComplain)
        {
            if (ModelState.IsValid)
            {
                db.RealEstateComplains.Add(realEstateComplain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstateComplain.RealEstateID);
            return View(realEstateComplain);
        }

        // GET: RealEstateComplains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateComplain realEstateComplain = db.RealEstateComplains.Find(id);
            if (realEstateComplain == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstateComplain.RealEstateID);
            return View(realEstateComplain);
        }

        // POST: RealEstateComplains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RealEstateID,ComplainerName,ComplainerEmail,ComplainerPhone,ComplainTitle,ComplainDetails,CreatedDate,IsRead")] RealEstateComplain realEstateComplain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstateComplain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RealEstateID = new SelectList(db.RealEstates, "ID", "Street", realEstateComplain.RealEstateID);
            return View(realEstateComplain);
        }

        // GET: RealEstateComplains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateComplain realEstateComplain = db.RealEstateComplains.Find(id);
            if (realEstateComplain == null)
            {
                return HttpNotFound();
            }
            db.RealEstateComplains.Remove(realEstateComplain);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // POST: RealEstateComplains/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateComplain realEstateComplain = db.RealEstateComplains.Find(id);
        //    db.RealEstateComplains.Remove(realEstateComplain);
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
