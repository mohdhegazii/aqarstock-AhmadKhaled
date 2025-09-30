using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;
using ResourcesFiles;
using System.IO;
using BrokerMVC.Extensions;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin,Roles.CompanyAdmin,Roles.CompanyEmployee)]
    public class RealEstateProjectModelsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateProjectModels
        public ActionResult Index()
        {
            var realEstateProjectModels = db.RealEstateProjectModels.Include(r => r.RealEstateProject).Include(r => r.RealEstateType);
            return View(realEstateProjectModels.ToList());
        }

        // GET: RealEstateProjectModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectModel realEstateProjectModel = db.RealEstateProjectModels.Find(id);
            if (realEstateProjectModel == null)
            {
                return HttpNotFound();
            }
            return View(realEstateProjectModel);
        }

        // GET: RealEstateProjectModels/Create
        public ActionResult Create(int? id)
        {
            //ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude");
            RealEstateProjectModel model = new RealEstateProjectModel();
            RealEstateProject project = db.RealEstateProjects.Find(id);
            ViewBag.ProjectName = project.Title;
            ViewBag.ProjectLogo = project.Logo;
            model.ProjectID = id;
            var cat = db.RealEstateCategories.OrderBy(c => c.Title).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories.OrderBy(c=>c.Title), "ID", "Title");
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes.Where(t=>t.RealEstateCategoryId==cat.ID).OrderBy(t=>t.Sort).ThenBy(t=>t.Title), "ID", "Title",cat);
            return View(model);
        }

        // POST: RealEstateProjectModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RealEstateProjectModel realEstateProjectModel)
        {
            RealEstateProject project = db.RealEstateProjects.Find(realEstateProjectModel.ProjectID);
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateProjectModel.ImageFile == null || realEstateProjectModel.ImageFile.ContentLength == 0)
                {
                    ModelState.AddModelError("ImageFile", Messages.PhotoRequired);
                    Isvalid = false;
                }
                else
                {
                    ValidationResult result = ImageHelper.ValidateImage(realEstateProjectModel.ImageFile, ImageTypes.Image);
                    if (!result.IsValid)
                    {
                        ModelState.AddModelError("ImageFile", result.Message);
                        Isvalid = false;
                    }
                    if (Isvalid == true)
                    {
                        
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Projects", project.Code);
                        Guid g = Guid.NewGuid();
                        realEstateProjectModel.PlanImgURL = ImagePath + "/" + g + Path.GetExtension(realEstateProjectModel.ImageFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(realEstateProjectModel.ImageFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateProjectModel.ImageFile, filename, 70, realEstateProjectModel.ImageFile.ContentType);
                        db.RealEstateProjectModels.Add(realEstateProjectModel);
                        db.SaveChanges();
                        this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                        return RedirectToAction("Edit", new { id = realEstateProjectModel.ID });
                    }
                    }
           
            }
            ViewBag.ProjectName = project.Title;
            ViewBag.ProjectLogo = project.Logo;
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories.OrderBy(t => t.Title), "ID", "Title",realEstateProjectModel.CategoryId);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes.Where(t => t.RealEstateCategoryId == realEstateProjectModel.CategoryId).OrderBy(t => t.Sort).ThenBy(t => t.Title), "ID", "Title",realEstateProjectModel.RealEstateTypeID);
            return View(realEstateProjectModel);
        }

        // GET: RealEstateProjectModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectModel realEstateProjectModel = db.RealEstateProjectModels.Find(id);
            if (realEstateProjectModel == null)
            {
                return HttpNotFound();
            }
            RealEstateProject project = db.RealEstateProjects.Find(realEstateProjectModel.ProjectID);
            ViewBag.ProjectName = project.Title;
            ViewBag.ProjectLogo = project.Logo;
            var cat = db.RealEstateCategories.OrderBy(t => t.Title).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories.OrderBy(t => t.Title), "ID", "Title");
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes.Where(t => t.RealEstateCategoryId == cat.ID).OrderBy(t => t.Sort).ThenBy(t => t.Title), "ID", "Title", cat);
            return View(realEstateProjectModel);
        }

        // POST: RealEstateProjectModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RealEstateProjectModel realEstateProjectModel)
        {
            RealEstateProject project = db.RealEstateProjects.Find(realEstateProjectModel.ProjectID);
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateProjectModel.ImageFile != null)
                {
                    if (realEstateProjectModel.ImageFile.ContentLength == 0)
                    {
                        ModelState.AddModelError("ImageFile", Messages.PhotoRequired);
                        Isvalid = false;
                    }
                    else
                    {
                        ValidationResult result = ImageHelper.ValidateImage(realEstateProjectModel.ImageFile, ImageTypes.Logo);
                        if (!result.IsValid)
                        {
                            ModelState.AddModelError("ImageFile", result.Message);
                            Isvalid = false;
                        }
                    }
                    if (Isvalid == true)
                    {
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Projects", project.Code);
                        Guid g = Guid.NewGuid();
                        realEstateProjectModel.PlanImgURL = ImagePath + "/" + g + Path.GetExtension(realEstateProjectModel.ImageFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(realEstateProjectModel.ImageFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateProjectModel.ImageFile, filename, 70, realEstateProjectModel.ImageFile.ContentType);
                    }
                }
                    db.Entry(realEstateProjectModel).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
              //  return View(realEstateProjectModel);
            }
            ViewBag.ProjectName = project.Title;
            ViewBag.ProjectLogo = project.Logo;
            ViewBag.CategoryId = new SelectList(db.RealEstateCategories, "ID", "Title", realEstateProjectModel.CategoryId);
            ViewBag.RealEstateTypeID = new SelectList(db.RealEstateTypes.Where(t => t.RealEstateCategoryId == realEstateProjectModel.CategoryId), "ID", "Title", realEstateProjectModel.RealEstateTypeID);
            return View(realEstateProjectModel);
        }

        // GET: RealEstateProjectModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectModel realEstateProjectModel = db.RealEstateProjectModels.Find(id);
            if (realEstateProjectModel == null)
            {
                return HttpNotFound();
            }
            int projectID = realEstateProjectModel.ProjectID.Value;
            db.RealEstateProjectModels.Remove(realEstateProjectModel);
            db.SaveChanges();
            return RedirectToAction("Edit", "RealEstateProjects", new { id = projectID});
        }

        // POST: RealEstateProjectModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateProjectModel realEstateProjectModel = db.RealEstateProjectModels.Find(id);
        //    db.RealEstateProjectModels.Remove(realEstateProjectModel);
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
