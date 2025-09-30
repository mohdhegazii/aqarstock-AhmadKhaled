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
    public class CurrenciesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Currencies
        public ActionResult Index(string currentFilter, int? page, string sortOrder)
        {
            ViewBag.ArabicNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnglishNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.PrioritySortParm = sortOrder == "Sort" ? "Sort_desc" : "Sort";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var Currencies = from C in db.Currencies select C;
            switch (sortOrder)
            {

                case "name_desc":
                    Currencies = Currencies.OrderByDescending(c => c.Name);
                    break;
                case "EnName":
                    Currencies = Currencies.OrderBy(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "EnName_desc":
                    Currencies = Currencies.OrderByDescending(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "Sort":
                    Currencies = Currencies.OrderBy(c => c.Sort).ThenBy(c => c.Name);
                    break;
                case "Sort_desc":
                    Currencies = Currencies.OrderByDescending(c => c.Sort).ThenBy(c => c.Name);
                    break;
                default:
                    Currencies = Currencies.OrderBy(c => c.Name);
                    break;
            }
            return View(Currencies.ToPagedList(pageNumber, pageSize));

            //return View(db.Currencies.ToList());
        }

        // GET: Currencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // GET: Currencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,EnName,Sort")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Currencies.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        // GET: Currencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,EnName,Sort")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        // GET: Currencies/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Currency currency = db.Currencies.Find(id);
        //    if (currency == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(currency);
        //}

        //// POST: Currencies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Currency currency = db.Currencies.Find(id);
        //    db.Currencies.Remove(currency);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Currency currency = db.Currencies.Find(id);
                db.Currencies.Remove(currency);
                db.SaveChanges();
                this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                this.AddNotification(ex.Message, NotificationType.ERROR);
                return RedirectToAction("Index");
            }
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
