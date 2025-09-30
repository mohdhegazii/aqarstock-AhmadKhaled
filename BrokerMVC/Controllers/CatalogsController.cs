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
using System.Configuration;
using BrokerMVC.Extensions;
using BrokerMVC.Models.ViewModel;
using BrokerMVC.Code.GeneralClasses;

namespace BrokerMVC.Controllers
{
    public class CatalogsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Catalogs
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
            var Cities = from C in db.Catalogs select C;

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

        // GET: Catalogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            return View(catalog);
        }

        // GET: Catalogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name");
            var country = db.Countries.FirstOrDefault();
            var city = db.Cities.Where(c => c.CountryID == country.ID).OrderBy(c => c.Name).FirstOrDefault();
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == country.ID).OrderBy(c => c.Name), "ID", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name");
            ViewBag.DistrictId = new SelectList(db.Districts.Where(D => D.CityID == city.ID).OrderBy(d => d.Name), "ID", "Name");

            //ViewBag.CityId = new SelectList(db.Cities, "ID", "Name");
            //ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name");
            //ViewBag.DistrictId = new SelectList(db.Districts, "ID", "Name");
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title");
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = ValidateImage(catalog.PhotoFile);
                if (Isvalid == true)
                {
                    catalog.Date = DateTime.Now;
                    SaveImage(catalog);
                    db.Catalogs.Add(catalog);
                    db.SaveChanges();
                    AddInSiteMap(catalog);
                    this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                    return RedirectToAction("Edit", new { id = catalog.ID });

                }
            }

            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", catalog.CategoryID);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", catalog.CountryId);
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == catalog.CountryId), "ID", "Name", catalog.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.CityID == catalog.CityId), "ID", "Name", catalog.DistrictId);
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title", catalog.TypeID);
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", catalog.CategoryID);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", catalog.CountryId);
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == catalog.CountryId), "ID", "Name", catalog.CityId);

            ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.CityID == catalog.CityId), "ID", "Name", catalog.DistrictId);
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title", catalog.TypeID);
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (catalog.PhotoFile != null)
                {
                    Isvalid = ValidateImage(catalog.PhotoFile);
                    if (Isvalid == true)
                    {
                        SaveImage(catalog);
                    }
                }
                db.Entry(catalog).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
              //  return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name", catalog.CategoryID);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name", catalog.CountryId);
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == catalog.CountryId), "ID", "Name", catalog.CityId);

            ViewBag.DistrictId = new SelectList(db.Districts.Where(d => d.CityID == catalog.CityId), "ID", "Name", catalog.DistrictId);
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title", catalog.TypeID);
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalog catalog = db.Catalogs.Find(id);
            if (catalog == null)
            {
                return HttpNotFound();
            }
            DirectoryManager.RemoveFile(catalog.PhotoURL);
            db.Catalogs.Remove(catalog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Catalogs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Catalog catalog = db.Catalogs.Find(id);
        //    db.Catalogs.Remove(catalog);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult GenerateCatalogs()
        {
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name");
            var country = db.Countries.FirstOrDefault();
            var city = db.Cities.Where(c => c.CountryID == country.ID).OrderBy(c => c.Name).FirstOrDefault();
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == country.ID).OrderBy(c => c.Name), "ID", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name");
            ViewBag.DistrictId = new SelectList(db.Districts.Where(D => D.CityID == city.ID).OrderBy(d => d.Name), "ID", "Name");
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title");
            CatlogsCriteria criteria = new CatlogsCriteria();
            return View(criteria);
        }
        [HttpPost]
        public ActionResult GenerateCatalogs(CatlogsCriteria criteria)
        {
            if (ModelState.IsValid)
            {
                List<string> Catalogs = criteria.CatlogsNames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                Catalogs.ForEach(c => c.Trim());
                Catalogs = Catalogs.Distinct().ToList();
                GenerateCatalogContent generator = new GenerateCatalogContent();
                generator.Headers = criteria.Headers;
                generator.Link = criteria.GeneralLink;
                generator.OccuranceNo = criteria.OccuranceNo;
                generator.ParagraphNo = criteria.ParagraphNo;
                generator.WordNo = criteria.WordNo;
                Catalog Catalog;
                List<Catalog> newCatalogs = new List<Catalog>();
                foreach (string cat in Catalogs)
                {
                    Catalog = new Catalog();
                    Catalog.CategoryID = criteria.CategoryID;
                    Catalog.CityId = criteria.CityID;
                    Catalog.CountryId = criteria.CountryID;
                    Catalog.Date = DateTime.Now;
                    Catalog.Description = generator.GenerateContent("<a href='" + criteria.KeywordLink + "'><strong>" + cat + "</strong></a>");
                    Catalog.DistrictId = criteria.DistrictID;
                    Catalog.Summary = cat + " - عقار ستوك . كوم";
                    Catalog.Title = cat;
                    Catalog.TypeID = criteria.TypeID;
                    Catalog.PhotoURL = GetPhoto();
                    newCatalogs.Add(Catalog);
                }
                db.Catalogs.AddRange(newCatalogs);
                db.SaveChanges();
                foreach (Catalog cat in newCatalogs)
                {
                    AddInSiteMap(cat);
                }
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.CatalogCategories, "ID", "Name",criteria.CategoryID);
            ViewBag.CityId = new SelectList(db.Cities.Where(c => c.CountryID == criteria.CategoryID).OrderBy(c => c.Name), "ID", "Name",criteria.CityID);
            ViewBag.CountryId = new SelectList(db.Countries, "ID", "Name",criteria.CountryID);
            ViewBag.DistrictId = new SelectList(db.Districts.Where(D => D.CityID == criteria.CityID).OrderBy(d => d.Name), "ID", "Name",criteria.DistrictID);
            ViewBag.TypeID = new SelectList(db.RealEstateTypes, "ID", "Title", criteria.TypeID);
            return View(criteria);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private string GetPhoto()
        {
            List<string> Photos = Directory.GetFiles(HttpContext.Server.MapPath("~/Resources/Catalogs")).ToList();
            Random r = new Random();
            return "Resources/Catalogs/" + Path.GetFileName(Photos[r.Next(Photos.Count())]);
        }
        private bool ValidateImage(HttpPostedFileBase photo)
        {
            var Isvalid = true;
            if (photo == null || photo.ContentLength == 0)
            {
                ModelState.AddModelError("LogoFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            ValidationResult result = ImageHelper.ValidateImage(photo, ImageTypes.Image);
            if (!result.IsValid)
            {
                ModelState.AddModelError("LogoFile", result.Message);
                Isvalid = false;
            }
            return Isvalid;
        }
        private void SaveImage(Catalog catalog)
        {
            string ImagePath = DirectoryManager.GetDirectory("~/Resources/Catalogs", Commons.EncodeText(catalog.Title));

            catalog.PhotoURL = ImagePath + "/" + catalog.Title.Trim().Replace(" ", "_") + Path.GetExtension(catalog.PhotoFile.FileName);
            string filename = Server.MapPath(ImagePath) + "\\" + catalog.Title.Trim().Replace(" ", "_") + Path.GetExtension(catalog.PhotoFile.FileName);
            ImageHelper.ApplyCompressionAndSave(catalog.PhotoFile, filename, 70, catalog.PhotoFile.ContentType);

        }
        private void AddInSiteMap(Catalog data)
        {
            SitemapNode node;
            node = new SitemapNode();
            node.Frequency = SitemapFrequency.Weekly;
            node.LastModified = DateTime.Now;
            node.Priority = 0.3;
            node.Url = ConfigurationSettings.AppSettings["WebSite"] + "/" + Commons.EncodeText("الكتالوج_العقارى") + "/" + data.ID + "/" + Commons.EncodeText(data.Title); ;
            node.EncodeURL = true;
            node.Images = new List<SitemapImageNode>();
            SiteMapGenerator gen = new SiteMapGenerator();
            gen.AddNewNode(node, Server.MapPath("~/CatalogSitemap.Xml"));

        }
    }
}
