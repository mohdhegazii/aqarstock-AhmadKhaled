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
    public class CatalogCategoriesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: CatalogCategories
        public ActionResult Index(int? page, string sortOrder)
        {
            ViewBag.ArabicNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var cats = from C in db.CatalogCategories select C;
            switch (sortOrder)
            {

                case "name_desc":
                    cats = cats.OrderByDescending(c => c.Name);
                    break;
                default:
                    cats = cats.OrderBy(c => c.Name);
                    break;
            }
            return View(cats.ToPagedList(pageNumber, pageSize));
        }

        // GET: CatalogCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogCategory catalogCategory = db.CatalogCategories.Find(id);
            if (catalogCategory == null)
            {
                return HttpNotFound();
            }
            return View(catalogCategory);
        }

        // GET: CatalogCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] CatalogCategory catalogCategory)
        {
            if (ModelState.IsValid)
            {
                db.CatalogCategories.Add(catalogCategory);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            return View(catalogCategory);
        }

        // GET: CatalogCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogCategory catalogCategory = db.CatalogCategories.Find(id);
            if (catalogCategory == null)
            {
                return HttpNotFound();
            }
            return View(catalogCategory);
        }

        // POST: CatalogCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] CatalogCategory catalogCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalogCategory).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(catalogCategory);
        }

        // GET: CatalogCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatalogCategory catalogCategory = db.CatalogCategories.Find(id);
            if (catalogCategory == null)
            {
                return HttpNotFound();
            }
            db.CatalogCategories.Remove(catalogCategory);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        //// POST: CatalogCategories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CatalogCategory catalogCategory = db.CatalogCategories.Find(id);
        //    db.CatalogCategories.Remove(catalogCategory);
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
