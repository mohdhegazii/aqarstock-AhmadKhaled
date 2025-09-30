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
   
    public class DistrictsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Districts
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";
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
            var districts = from C in db.Districts select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                districts = districts.Where(s => s.City.Name.Contains(searchString)
                                       || s.City.EnName.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    districts = districts.OrderByDescending(c => c.Name);
                    break;
                case "EnName":
                    districts = districts.OrderBy(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "EnName_desc":
                    districts = districts.OrderByDescending(c => c.EnName).ThenBy(c => c.Name);
                    break;
                case "City":
                    districts = districts.OrderBy(c => c.City.Name).ThenBy(c => c.Name);
                    break;
                case "city_desc":
                    districts = districts.OrderByDescending(c => c.City.Name).ThenBy(c => c.Name);
                    break;
                case "Country":
                    districts = districts.OrderBy(c => c.City.Country.Name).ThenBy(c => c.Name);
                    break;
                case "country_desc":
                    districts = districts.OrderByDescending(c => c.City.Country.Name).ThenBy(c => c.Name);
                    break;
                case "Sort":
                    districts = districts.OrderBy(c => c.Sort).ThenBy(c => c.Name);
                    break;
                case "Sort_desc":
                    districts = districts.OrderByDescending(c => c.Sort).ThenBy(c => c.Name);
                    break;
                default:
                    districts = districts.OrderBy(c => c.Name);
                    break;
            }
            return View(districts.ToPagedList(pageNumber, pageSize));
            
        }

        // GET: Districts/Details/5
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: Districts/Create
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Create()
        {
            Country TopCountry = db.Countries.OrderBy(c => c.Sort).First();
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name",TopCountry.ID);

            ViewBag.CityID = new SelectList(db.Cities.Where(C=>C.CountryID==TopCountry.ID), "ID", "Name");
            return View();
        }
        [AuthorizeRoles(Roles.Admin,Roles.Subscriber)]
        public ActionResult GetCities(int CountryID)
        {
            var cities = db.Cities.Where(C => C.CountryID == CountryID);
            ViewBag.CityID= new SelectList(db.Cities.Where(C => C.CountryID == CountryID), "ID", "Name");
            return Json(cities.Select(c => new { Id = c.ID, Name = c.Name,CountryID=c.CountryID }), JsonRequestBehavior.AllowGet);
                //(new { Id = cities.Id }(cities, JsonRequestBehavior.AllowGet);
        }
        [AuthorizeRoles(Roles.Admin, Roles.Subscriber)]
        public ActionResult GetDistricts(int CityID)
        {
            var districts = db.Districts.Where(C => C.CityID == CityID);
          //  ViewBag.CityID = new SelectList(db.Districts.Where(C => C.CityID == CountryID), "ID", "Name");
            return Json(districts.Select(c => new { Id = c.ID, Name = c.Name, CityID = c.CityID }), JsonRequestBehavior.AllowGet);
            //(new { Id = cities.Id }(cities, JsonRequestBehavior.AllowGet);
        }

        // POST: Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityID,Name,EnName,Sort")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", district.CityID);
            //ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name",district.CountryId);
            return View(district);
        }

        // GET: Districts/Edit/5
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "Name", district.CountryId);
            ViewBag.CityID = new SelectList(db.Cities.Where(c=>c.CountryID==district.CountryId), "ID", "Name", district.CityID);
            return View(district);
        }

        // POST: Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityID,Name,EnName,Sort")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.UpdatedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", district.CityID);
            return View(district);
        }

        // GET: Districts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    District district = db.Districts.Find(id);
        //    if (district == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(district);
        //}

        // POST: Districts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [AuthorizeRoles(Roles.Admin)]
        public ActionResult Delete(int id)
        {
            try
            { 
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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
    }
}
