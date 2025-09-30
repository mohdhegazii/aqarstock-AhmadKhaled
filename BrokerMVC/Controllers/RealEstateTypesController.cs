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
    public class RealEstateTypesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateTypes
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EnNameSortParm = sortOrder == "EnName" ? "EnName_desc" : "EnName";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
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
            var Types = from C in db.RealEstateTypes select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                Types = Types.Where(s => s.RealEstateCategory.Title.Contains(searchString)
                                       || s.RealEstateCategory.EnTitle.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    Types = Types.OrderByDescending(c => c.Title);
                    break;
                case "EnName":
                    Types = Types.OrderBy(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "EnName_desc":
                    Types = Types.OrderByDescending(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "Category":
                    Types = Types.OrderBy(c => c.RealEstateCategory.Title).ThenBy(c => c.Title);
                    break;
                case "category_desc":
                    Types = Types.OrderByDescending(c => c.RealEstateCategory.Title).ThenBy(c => c.Title);
                    break;
                case "Sort":
                    Types = Types.OrderBy(c => c.Sort).ThenBy(c => c.Title);
                    break;
                case "Sort_desc":
                    Types = Types.OrderByDescending(c => c.Sort).ThenBy(c => c.Title);
                    break;
                default:
                    Types = Types.OrderBy(c => c.Title);
                    break;
            }
            return View(Types.ToPagedList(pageNumber, pageSize));
            //var realEstateTypes = db.RealEstateTypes.Include(r => r.RealEstateCategory);
            //return View(realEstateTypes.ToList());
        }

        // GET: RealEstateTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateType realEstateType = db.RealEstateTypes.Find(id);
            if (realEstateType == null)
            {
                return HttpNotFound();
            }
            return View(realEstateType);
        }

        // GET: RealEstateTypes/Create
        public ActionResult Create()
        {
            ViewBag.RealEstateCategoryId = new SelectList(db.RealEstateCategories, "ID", "Title");
            return View();
        }

        // POST: RealEstateTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RealEstateCategoryId,Title,EnTitle,Icon,IconFile,Sort")] RealEstateType realEstateType)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateType.IconFile == null || realEstateType.IconFile.ContentLength == 0)
                {
                    ModelState.AddModelError("IconFile", Messages.PhotoRequired);
                    Isvalid = false;
                }
                else
                {
                    ValidationResult result = ImageHelper.ValidateImage(realEstateType.IconFile, ImageTypes.Icon);
                    if (!result.IsValid)
                    {
                        ModelState.AddModelError("IconFile", result.Message);
                        Isvalid = false;
                    }
                }
                if (Isvalid == true)
                {
                    string ImagePath = "~/Resources/RealEstates/Types";

                    realEstateType.Icon = ImagePath + "/" + realEstateType.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateType.IconFile.FileName);
                    db.RealEstateTypes.Add(realEstateType);
                    db.SaveChanges();
                    realEstateType.IconFile.SaveAs(Server.MapPath(ImagePath) + "\\" + realEstateType.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateType.IconFile.FileName));
                    this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                    return RedirectToAction("Edit", realEstateType);
                }
                else
                {
                    ViewBag.RealEstateCategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateType.RealEstateCategoryId);
                    return View(realEstateType);
                }
            }
            else
            {
                ViewBag.RealEstateCategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateType.RealEstateCategoryId);
                return View(realEstateType);
            }
        }

        // GET: RealEstateTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateType realEstateType = db.RealEstateTypes.Find(id);
            if (realEstateType == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealEstateCategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateType.RealEstateCategoryId);
            return View(realEstateType);
        }

        // POST: RealEstateTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RealEstateCategoryId,Title,EnTitle,Icon,IconFile,Sort")] RealEstateType realEstateType)
        {
            if (ModelState.IsValid)
            {

                
                bool Isvalid = true;
                if (realEstateType.IconFile != null)
                {
                    if (realEstateType.IconFile.ContentLength == 0)
                    {
                        ModelState.AddModelError("IconFile", Messages.PhotoRequired);
                        Isvalid = false;
                    }
                    else
                    {
                        ValidationResult result = ImageHelper.ValidateImage(realEstateType.IconFile, ImageTypes.Icon);
                        if (!result.IsValid)
                        {
                            ModelState.AddModelError("IconFile", result.Message);
                            Isvalid = false;
                        }
                    }
                    if (Isvalid == true)
                    {
                        string ImagePath = "~/Resources/RealEstates/Types";

                        realEstateType.Icon = ImagePath + "/" + realEstateType.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateType.IconFile.FileName);
                        realEstateType.IconFile.SaveAs(Server.MapPath(ImagePath) + "\\" + realEstateType.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateType.IconFile.FileName));
                    }
                }
               
                    db.Entry(realEstateType).State = EntityState.Modified;
                    db.SaveChanges();
                    this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                    return RedirectToAction("Edit", realEstateType);
            }
            ViewBag.RealEstateCategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateType.RealEstateCategoryId);
            return View(realEstateType);
        }

          [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee, Roles.Subscriber)]
      //  [AllowAnonymous]
        public ActionResult GetTypes(int? id)
        {
            var cities = db.RealEstateTypes.Where(C => C.RealEstateCategoryId == id);
            ViewBag.CityID = new SelectList(db.RealEstateTypes.Where(C => C.RealEstateCategoryId == id), "ID", "Name");
            return Json(cities.Select(c => new { Id = c.ID, Name = c.Title, CountryID = c.RealEstateCategoryId }), JsonRequestBehavior.AllowGet);
            //(new { Id = cities.Id }(cities, JsonRequestBehavior.AllowGet);
        }
        // GET: RealEstateTypes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    RealEstateType realEstateType = db.RealEstateTypes.Find(id);
        //    if (realEstateType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(realEstateType);
        //}

        //// POST: RealEstateTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateType realEstateType = db.RealEstateTypes.Find(id);
        //    db.RealEstateTypes.Remove(realEstateType);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Delete(int id)
        {
            try
            {
                RealEstateType type = db.RealEstateTypes.Find(id);
                db.RealEstateTypes.Remove(type);
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
