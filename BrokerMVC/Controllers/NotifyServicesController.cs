using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;

namespace BrokerMVC.Controllers
{
    public class NotifyServicesController : Controller
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: NotifyServices
        public ActionResult Index()
        {
            var notifyServices = db.NotifyServices.Include(n => n.City).Include(n => n.Country).Include(n => n.District).Include(n => n.RealEstateType).Include(n => n.SaleType);
            return View(notifyServices.ToList());
        }

        // GET: NotifyServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotifyService notifyService = db.NotifyServices.Find(id);
            if (notifyService == null)
            {
                return HttpNotFound();
            }
            return View(notifyService);
        }

        // GET: NotifyServices/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name");
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title");
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes, "ID", "Title");
            return View();
        }

        // POST: NotifyServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Email,Date,SaleTypeID,RealEstateTypeID,CountryID,CityID,DistrictID,Price,Area")] NotifyService notifyService)
        {
            if (ModelState.IsValid)
            {
                db.NotifyServices.Add(notifyService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", notifyService.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", notifyService.CountryID);
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", notifyService.DistrictID);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", notifyService.RealEstateTypeID);
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes, "ID", "Title", notifyService.SaleTypeID);
            return View(notifyService);
        }

        // GET: NotifyServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotifyService notifyService = db.NotifyServices.Find(id);
            if (notifyService == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", notifyService.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", notifyService.CountryID);
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", notifyService.DistrictID);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", notifyService.RealEstateTypeID);
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes, "ID", "Title", notifyService.SaleTypeID);
            return View(notifyService);
        }

        // POST: NotifyServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Email,Date,SaleTypeID,RealEstateTypeID,CountryID,CityID,DistrictID,Price,Area")] NotifyService notifyService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifyService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", notifyService.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", notifyService.CountryID);
            ViewBag.DistrictID = new SelectList(db.Districts, "ID", "Name", notifyService.DistrictID);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", notifyService.RealEstateTypeID);
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes, "ID", "Title", notifyService.SaleTypeID);
            return View(notifyService);
        }

        // GET: NotifyServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotifyService notifyService = db.NotifyServices.Find(id);
            if (notifyService == null)
            {
                return HttpNotFound();
            }
            return View(notifyService);
        }

        // POST: NotifyServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotifyService notifyService = db.NotifyServices.Find(id);
            db.NotifyServices.Remove(notifyService);
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
