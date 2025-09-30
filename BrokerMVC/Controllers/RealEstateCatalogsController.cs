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
using System.IO;
using BrokerMVC.Models.ViewModel;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin)]
    public class RealEstateCatalogsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateCatalogs
        public ActionResult Index(int? CategoryID, int? currentFilter, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.CurrentSort = sortOrder;
            if (CategoryID != null)
            {
                page = 1;

            }
            else
            {
                CategoryID = currentFilter;
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", (CategoryID ?? null));
            int pageSize = 10;

            int pageNumber = (page ?? 1);
            var Cities = from C in db.RealEstateCatalogs select C;
      
            ViewBag.CurrentFilter = CategoryID;
            if (CategoryID != null)
            {
                Cities = Cities.Where(s => s.CategoryID == CategoryID);
            }
            switch (sortOrder)
            {

                case "name_desc":
                    Cities = Cities.OrderByDescending(c => c.Title);
                    break;
                case "Category":
                    Cities = Cities.OrderBy(c => c.CatalogCategory.Name).ThenBy(c => c.Title);
                    break;
                case "Category_desc":
                    Cities = Cities.OrderByDescending(c => c.CatalogCategory.Name).ThenBy(c => c.Title);
                    break;
                default:
                    Cities = Cities.OrderBy(c => c.Title);
                    break;
            }
            return View(Cities.ToPagedList(pageNumber, pageSize));
            //var cities = db.Cities.Include(c => c.Country);
            //return View(cities.ToList());
        }

        // GET: RealEstateCatalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateCatalog realEstateCatalog = db.RealEstateCatalogs.Find(id);
            if (realEstateCatalog == null)
            {
                return HttpNotFound();
            }
            return View(realEstateCatalog);
        }

        // GET: RealEstateCatalogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name");
            return View();
        }

        // POST: RealEstateCatalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryID,Code,Date,Title,Description,Tag,PhotoURL,SocialPhotoURL,AllTags")] RealEstateCatalog realEstateCatalog)
        {
            if (ModelState.IsValid)
            {
                db.RealEstateCatalogs.Add(realEstateCatalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", realEstateCatalog.CategoryID);
            return View(realEstateCatalog);
        }

        public ActionResult GenerateCatalogs()
        {
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name");
            CatlogsCriteria criteria = new CatlogsCriteria();
            return View(criteria);
        }
        [HttpPost]
        public ActionResult GenerateCatalogs(CatlogsCriteria criteria)
        {
            var Catalogs = criteria.CatlogsNames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Catalogs.ForEach(c => c.Trim());
            Catalogs = Catalogs.Distinct().ToList();
            foreach (string catalog in Catalogs)
            {

            }
            return RedirectToAction("Index");
        }
        public ActionResult AddRealEstate(int?id)
        {
            AddRealestateToCatalog CatlogRealestate = new AddRealestateToCatalog();
            CatlogRealestate.CatalogID = id;
            return PartialView(CatlogRealestate);
        }
        [HttpPost]
        public ActionResult AddRealEstate(AddRealestateToCatalog CatlogRealestate)
        {
            RealestateCatalogProperty prop;
            RealEstate realestate;
            foreach(string code in CatlogRealestate.Codes.Split(','))
            {
                realestate = db.RealEstates.FirstOrDefault(r => r.Code.ToString() == code);
                if(realestate!=null)
                {
                    prop = db.RealestateCatalogProperties.FirstOrDefault(r => r.CatalogID == CatlogRealestate.CatalogID && r.RealEstateID == realestate.ID);
                    if(prop==null)
                    {
                        prop = new RealestateCatalogProperty();
                        prop.CatalogID = CatlogRealestate.CatalogID;
                        prop.RealEstateID = realestate.ID;
                        db.RealestateCatalogProperties.Add(prop);
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = CatlogRealestate.CatalogID });
        }
        // GET: RealEstateCatalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateCatalog realEstateCatalog = db.RealEstateCatalogs.Find(id);
            if (realEstateCatalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", realEstateCatalog.CategoryID);
            return View(realEstateCatalog);
        }

        // POST: RealEstateCatalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RealEstateCatalog realEstateCatalog)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateCatalog.PhotoFile != null)
                {
                    Isvalid = ValidateImage(realEstateCatalog.PhotoFile);
                    if (Isvalid == true)
                    {
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Catalogs", realEstateCatalog.Code);

                        realEstateCatalog.PhotoURL = ImagePath + "/" + realEstateCatalog.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateCatalog.PhotoFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + realEstateCatalog.Title.Trim().Replace(" ", "_") + "_icon" + Path.GetExtension(realEstateCatalog.PhotoFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateCatalog.PhotoFile, filename, 70, realEstateCatalog.PhotoFile.ContentType);

                    }
                }
                db.Entry(realEstateCatalog).State = EntityState.Modified;
                db.SaveChanges();
              //  return RedirectToAction("Edit",new);
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", realEstateCatalog.CategoryID);
            return View(realEstateCatalog);
        }
        
        // GET: RealEstateCatalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateCatalog realEstateCatalog = db.RealEstateCatalogs.Find(id);
            if (realEstateCatalog == null)
            {
                return HttpNotFound();
            }
            db.RealestateCatalogProperties.RemoveRange(db.RealestateCatalogProperties.Where(r => r.CatalogID == realEstateCatalog.ID));
            db.RealEstateCatalogs.Remove(realEstateCatalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRealestate(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealestateCatalogProperty realEstateCatalog = db.RealestateCatalogProperties.Find(id);
            if (realEstateCatalog == null)
            {
                return HttpNotFound();
            }
            int? CatalogID = realEstateCatalog.CatalogID;
            db.RealestateCatalogProperties.Remove(realEstateCatalog);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id= CatalogID });
        }

        // POST: RealEstateCatalogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateCatalog realEstateCatalog = db.RealEstateCatalogs.Find(id);
        //    db.RealEstateCatalogs.Remove(realEstateCatalog);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        private bool ValidateImage(HttpPostedFileBase logo)
        {
            var Isvalid = true;
            if (logo == null || logo.ContentLength == 0)
            {
                ModelState.AddModelError("LogoFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            ValidationResult result = ImageHelper.ValidateImage(logo, ImageTypes.Image);
            if (!result.IsValid)
            {
                ModelState.AddModelError("LogoFile", result.Message);
                Isvalid = false;
            }
            return Isvalid;
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
