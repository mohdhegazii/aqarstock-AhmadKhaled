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
using System.IO;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin)]
    public class RealEstateStatusController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateStatus
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "Category_desc" : "Category";
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
            var realEstateStatus = from C in db.RealEstateStatus select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                realEstateStatus = realEstateStatus.Where(s => s.RealEstateCategory.Title.Contains(searchString)
                                       || s.RealEstateCategory.EnTitle.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    realEstateStatus = realEstateStatus.OrderByDescending(c => c.Title);
                    break;
                case "EnName":
                    realEstateStatus = realEstateStatus.OrderBy(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "EnName_desc":
                    realEstateStatus = realEstateStatus.OrderByDescending(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "Category":
                    realEstateStatus = realEstateStatus.OrderBy(c => c.RealEstateCategory.Title).ThenBy(c => c.Title);
                    break;
                case "Category_desc":
                    realEstateStatus = realEstateStatus.OrderByDescending(c => c.RealEstateCategory.Title).ThenBy(c => c.Title);
                    break;
                default:
                    realEstateStatus = realEstateStatus.OrderBy(c => c.Title);
                    break;
            }
            return View(realEstateStatus.ToPagedList(pageNumber, pageSize));
        }

        // GET: RealEstateStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateStatu realEstateStatu = db.RealEstateStatus.Find(id);
            if (realEstateStatu == null)
            {
                return HttpNotFound();
            }
            return View(realEstateStatu);
        }

        // GET: RealEstateStatus/Create
        public ActionResult Create()
        {
            ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title");
            return View();
        }

        // POST: RealEstateStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RealEstateCategoryID,Title,EnTitle,IsSearchVisible")] RealEstateStatu realEstateStatu)
        {
            if (ModelState.IsValid)
            {
                realEstateStatu.IsSearchVisible = true;
                db.RealEstateStatus.Add(realEstateStatu);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateStatu.RealEstateCategoryID);
            return View(realEstateStatu);
        }

        // GET: RealEstateStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateStatu realEstateStatu = db.RealEstateStatus.Find(id);
            if (realEstateStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateStatu.RealEstateCategoryID);
            return View(realEstateStatu);
        }

        // POST: RealEstateStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RealEstateCategoryID,Title,EnTitle,IsSearchVisible")] RealEstateStatu realEstateStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstateStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RealEstateCategoryID = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateStatu.RealEstateCategoryID);
            return View(realEstateStatu);
        }

        // GET: RealEstateStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            RealEstateStatu realEstateStatu = db.RealEstateStatus.Find(id);
            db.RealEstateStatus.Remove(realEstateStatu);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee, Roles.Subscriber)]
        public ActionResult GetStatus(int?id)
        {
            var cities = db.RealEstateStatus.Where(C => C.RealEstateCategoryID == id);
            ViewBag.CityID = new SelectList(db.RealEstateTypes.Where(C => C.RealEstateCategoryId == id), "ID", "Name");
            return Json(cities.Select(c => new { Id = c.ID, Name = c.Title, CountryID = c.RealEstateCategoryID }), JsonRequestBehavior.AllowGet);
        }

        // POST: RealEstateStatus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateStatu realEstateStatu = db.RealEstateStatus.Find(id);
        //    db.RealEstateStatus.Remove(realEstateStatu);
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
