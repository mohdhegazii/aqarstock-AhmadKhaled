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
    public class CountriesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        //private readonly INotifier notifier;
        //public CountriesController(INotifier notifier)
        //{
        //    this.notifier = notifier;
        //}

        //public ActionResult NotifyTest()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult NotifyTest(FormCollection form)
        //{
        //    notifier.Success("A success message");
        //    return RedirectToAction("NotifyTest");
        //}
        // GET: Countries
        public ActionResult Index(string currentFilter, int? page, string sortOrder)
        {
            ViewBag.ArabicNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnglishNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.PrioritySortParm = sortOrder == "Sort" ? "Sort_desc" : "Sort";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var Countries = from C in db.Countries select C;
            switch (sortOrder)
            {

                case "name_desc":
                    Countries = Countries.OrderByDescending(c => c.Name);
                    break;
                case "EnName":
                    Countries = Countries.OrderBy(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "EnName_desc":
                    Countries = Countries.OrderByDescending(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "Sort":
                    Countries = Countries.OrderBy(c => c.Sort).ThenBy(c => c.Name);
                    break;
                case "Sort_desc":
                    Countries = Countries.OrderByDescending(c => c.Sort).ThenBy(c => c.Name);
                    break;
                default:
                    Countries = Countries.OrderBy(c => c.Name);
                    break;
            }
           return View(Countries.ToPagedList(pageNumber, pageSize));
            //   return View(db.Countries.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,EnName,Sort")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,EnName,Sort")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.UpdatedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(country);
        }

        ////// GET: Countries/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Country country = db.Countries.Find(id);
        //    if (country == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(country);
        //}

       // POST: Countries/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Country country = db.Countries.Find(id);
        //    db.Countries.Remove(country);
        //    db.SaveChanges();
        //    this.AddNotification("Deleted", NotificationType.SUCCESS);
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                Country country = db.Countries.Find(id);
                db.Countries.Remove(country);
                db.SaveChanges();
                this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
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

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            //if (culture == "")
            //    culture = "en";
            culture = CultureHelper.GetImplementedCulture(culture);
            RouteData.Values["culture"] = culture;  // set culture


            return RedirectToAction("Index");
        }
    }
}
