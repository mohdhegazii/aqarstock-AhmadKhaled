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
    public class CitiesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Cities
        public ActionResult Index(string currentFilter,string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CountrySortParm = sortOrder == "Country" ? "country_desc" : "Country";
            ViewBag.PrioritySortParm = sortOrder == "Sort" ? "Sort_desc" : "Sort";
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
            var Cities = from C in db.Cities select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                Cities = Cities.Where(s => s.Country.Name.Contains(searchString)
                                       || s.Country.EnName.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    Cities = Cities.OrderByDescending(c => c.Name);
                    break;
                case "EnName":
                    Cities = Cities.OrderBy(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "EnName_desc":
                    Cities = Cities.OrderByDescending(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "Country":
                    Cities = Cities.OrderBy(c => c.Country.Name).ThenBy(c => c.Name);
                    break;
                case "country_desc":
                    Cities = Cities.OrderByDescending(c => c.Country.Name).ThenBy(c => c.Name);
                    break;
                case "Sort":
                    Cities = Cities.OrderBy(c => c.Sort).ThenBy(c => c.Name);
                    break;
                case "Sort_desc":
                    Cities = Cities.OrderByDescending(c => c.Sort).ThenBy(c => c.Name);
                    break;
                default:
                    Cities = Cities.OrderBy(c => c.Name);
                    break;
            }
            return View(Cities.ToPagedList(pageNumber, pageSize));
            //var cities = db.Cities.Include(c => c.Country);
            //return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryID,Name,EnName,Sort")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", city.CountryID);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", city.CountryID);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryID,Name,EnName,Sort")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.UpdatedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", city.CountryID);
            return View(city);
        }

        // GET: Cities/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    City city = db.Cities.Find(id);
        //    if (city == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(city);
        //}

        //// POST: Cities/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                City city = db.Cities.Find(id);
                db.Cities.Remove(city);
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
