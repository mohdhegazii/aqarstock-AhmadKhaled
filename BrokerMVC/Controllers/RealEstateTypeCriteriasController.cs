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
using ResourcesFiles;
using BrokerMVC.Extensions;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin)]
    public class RealEstateTypeCriteriasController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateTypeCriterias
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter.Contains("+")?currentFilter.Replace("+"," "):currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var realEstateTypeCriterias = from C in db.RealEstateTypeCriterias select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                realEstateTypeCriterias = realEstateTypeCriterias.Where(s => s.RealEstateType.Title.Contains(searchString)
                                       || s.RealEstateType.EnTitle.Contains(searchString) || s.Title.Contains(searchString)
                                       || s.EnTitle.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderByDescending(c => c.Title);
                    break;
                case "EnName":
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderBy(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "EnName_desc":
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderByDescending(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "Category":
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderBy(c => c.RealEstateType.Title).ThenBy(c => c.Title);
                    break;
                case "category_desc":
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderByDescending(c => c.RealEstateType.Title).ThenBy(c => c.Title);
                    break;
             
                default:
                    realEstateTypeCriterias = realEstateTypeCriterias.OrderBy(c => c.Title);
                    break;
            }
            return View(realEstateTypeCriterias.ToPagedList(pageNumber, pageSize));
        }

        // GET: RealEstateTypeCriterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateTypeCriteria realEstateTypeCriteria = db.RealEstateTypeCriterias.Find(id);
            if (realEstateTypeCriteria == null)
            {
                return HttpNotFound();
            }
            return View(realEstateTypeCriteria);
        }

        // GET: RealEstateTypeCriterias/Create
        public ActionResult Create()
        {
            RealEstateCategory category = db.RealEstateCategories.FirstOrDefault();
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", category.ID);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes.Where(C => C.RealEstateCategoryId == category.ID), "ID", "Title");
            ViewBag.ValueType = Commons.GetCriteriaValueList();
            return View();
        }

        // POST: RealEstateTypeCriterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RealEstateTypeID,Title,EnTitle,ValueType")] RealEstateTypeCriteria realEstateTypeCriteria)
        {
            if (ModelState.IsValid)
            {
                db.RealEstateTypeCriterias.Add(realEstateTypeCriteria);
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit",realEstateTypeCriteria);
            }

            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", realEstateTypeCriteria.RealEstateTypeID);
            return View(realEstateTypeCriteria);
        }

        // GET: RealEstateTypeCriterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateTypeCriteria realEstateTypeCriteria = db.RealEstateTypeCriterias.Find(id);
            if (realEstateTypeCriteria == null)
            {
                return HttpNotFound();
            }

            RealEstateCategory category = db.RealEstateCategories.FirstOrDefault(c=>c.ID==realEstateTypeCriteria.RealEstateType.RealEstateCategoryId);
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", category.ID);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", realEstateTypeCriteria.RealEstateTypeID);
            ViewBag.ValueType = new SelectList(Commons.GetCriteriaValueList(), "Value", "Text", realEstateTypeCriteria);
            return View(realEstateTypeCriteria);
        }

        // POST: RealEstateTypeCriterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RealEstateTypeID,Title,EnTitle,ValueType")] RealEstateTypeCriteria realEstateTypeCriteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstateTypeCriteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes, "ID", "Title", realEstateTypeCriteria.RealEstateTypeID);
            return View(realEstateTypeCriteria);
        }

        // GET: RealEstateTypeCriterias/Delete/5
        public ActionResult Delete(int? id)
        {
            RealEstateTypeCriteria realEstateTypeCriteria = db.RealEstateTypeCriterias.Find(id);
            db.RealEstateTypeCriterias.Remove(realEstateTypeCriteria);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: RealEstateTypeCriterias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateTypeCriteria realEstateTypeCriteria = db.RealEstateTypeCriterias.Find(id);
        //    db.RealEstateTypeCriterias.Remove(realEstateTypeCriteria);
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
