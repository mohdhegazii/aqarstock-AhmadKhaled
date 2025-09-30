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
    [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee)]
    public class RealEstateProjectPhotoesController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
     //   private int? projectid;

        // GET: RealEstateProjectPhotoes
        public ActionResult Index()
        {
            var realEstateProjectPhotos = db.RealEstateProjectPhotos.Include(r => r.RealEstateProject);
            return View(realEstateProjectPhotos.ToList());
        }

        // GET: RealEstateProjectPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectPhoto realEstateProjectPhoto = db.RealEstateProjectPhotos.Find(id);
            if (realEstateProjectPhoto == null)
            {
                return HttpNotFound();
            }
            return View(realEstateProjectPhoto);
        }

        // GET: RealEstateProjectPhotoes/Create
        public ActionResult Create(int? id)
        {
            RealEstateProjectPhoto Photo = new RealEstateProjectPhoto();
            Photo.ProjectID = id;
            Photo.IsDefault = false;
            ViewBag.returnUrl = Request.UrlReferrer;
            // ViewBag.ProjectID = new SelectList(db.RealEstateProjects, "ID", "Longitude");
            return PartialView("Create", Photo);
        }

        // POST: RealEstateProjectPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RealEstateProjectPhoto realEstateProjectPhoto,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                if (realEstateProjectPhoto.PhotoFile==null || realEstateProjectPhoto.PhotoFile.ContentLength==0)
                {
                    ModelState.AddModelError("PhotoFile", Messages.PhotoRequired);
                    this.AddNotification(Messages.PhotoRequired, NotificationType.ERROR);
                    Isvalid = false;
                }
                else
                {
                    ValidationResult result = ImageHelper.ValidateImage(realEstateProjectPhoto.PhotoFile, ImageTypes.Image);
                    if (!result.IsValid)
                    {
                        ModelState.AddModelError("PhotoFile", result.Message);
                        this.AddNotification(result.Message, NotificationType.ERROR);
                        Isvalid = false;
                    }
                    if (Isvalid == true)
                    {
                        RealEstateProject project = db.RealEstateProjects.Find(realEstateProjectPhoto.ProjectID);
                        realEstateProjectPhoto.Date = DateTime.Now;
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Projects", project.Code);
                        Guid g=Guid.NewGuid();
                        realEstateProjectPhoto.PhotoURL = ImagePath + "/" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateProjectPhoto.PhotoFile, filename, 70, realEstateProjectPhoto.PhotoFile.ContentType);
                        if(realEstateProjectPhoto.IsDefault==true)
                        {
                            foreach (var p in db.RealEstateProjectPhotos.Where(p => p.ProjectID == realEstateProjectPhoto.ProjectID))
                            {
                                p.IsDefault = false;
                                db.Entry(p).State = EntityState.Modified;
                            }
                        }
                        if (project.ActiveStatusID == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                        {
                            Commons.Log(Modules.Projects, subscriberActions.Updated, project.ID, project.Title);
                        }
                        db.RealEstateProjectPhotos.Add(realEstateProjectPhoto);
                        this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                        db.SaveChanges();
                    }
                }
             
                return Redirect(returnUrl);
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        this.AddNotification(error.ErrorMessage, NotificationType.ERROR);
                    }
                }
                return Redirect(returnUrl);
            }
        }

        // GET: RealEstateProjectPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectPhoto realEstateProjectPhoto = db.RealEstateProjectPhotos.Find(id);
            if (realEstateProjectPhoto == null)
            {
                return HttpNotFound();
            }
           
            return PartialView("Edit", realEstateProjectPhoto);
        }

        // POST: RealEstateProjectPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RealEstateProjectPhoto realEstateProjectPhoto)
        {
            if (ModelState.IsValid)
            {
                bool Isvalid = true;
                RealEstateProject project = db.RealEstateProjects.Find(realEstateProjectPhoto.ProjectID);
                if (realEstateProjectPhoto.PhotoFile != null)
                {
                    if (realEstateProjectPhoto.PhotoFile.ContentLength == 0)
                    {
                        ModelState.AddModelError("PhotoFile", Messages.PhotoRequired);
                        this.AddNotification(Messages.PhotoRequired, NotificationType.ERROR);
                        Isvalid = false;
                    }
                    else
                    {
                        ValidationResult result = ImageHelper.ValidateImage(realEstateProjectPhoto.PhotoFile, ImageTypes.Logo);
                        if (!result.IsValid)
                        {
                            ModelState.AddModelError("PhotoFile", result.Message);
                            this.AddNotification(result.Message, NotificationType.ERROR);
                            Isvalid = false;
                        }
                    }
                    
                    if (Isvalid == true)
                    {
                        
                        realEstateProjectPhoto.Date = DateTime.Now;
                        string ImagePath = DirectoryManager.GetDirectory("~/Resources/RealEstates/Projects", project.Code);
                        Guid g = Guid.NewGuid();
                        realEstateProjectPhoto.PhotoURL = ImagePath + "/" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        string filename = Server.MapPath(ImagePath) + "\\" + g + Path.GetExtension(realEstateProjectPhoto.PhotoFile.FileName);
                        ImageHelper.ApplyCompressionAndSave(realEstateProjectPhoto.PhotoFile, filename, 70, realEstateProjectPhoto.PhotoFile.ContentType);
                    
                    }
                }
             
                db.Entry(realEstateProjectPhoto).State = EntityState.Modified;
                db.SaveChanges();
                if (project.ActiveStatusID == (int)ActiveStatus.Suspended && !Security.IsUserInRole(Roles.Admin))
                {
                    Commons.Log(Modules.Projects, subscriberActions.Updated, project.ID, project.Title);
                }
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            }
            else
            {
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        this.AddNotification(error.ErrorMessage, NotificationType.ERROR);
                    }
                }
            }
                return RedirectToAction("ProjectPhotos", "RealEstateProjects", new { id=realEstateProjectPhoto.ProjectID, type ="List"});
        }
        public ActionResult SetDefault(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectPhoto realEstateProjectPhoto = db.RealEstateProjectPhotos.Find(id);
            if (realEstateProjectPhoto == null)
            {
                return HttpNotFound();
            }
            //db.RealEstateProjectPhotos.Where(p => p.ProjectID == id).ToList().ForEach(p=>p.IsDefault=false);
            foreach(var p in db.RealEstateProjectPhotos.Where(p => p.ProjectID == realEstateProjectPhoto.ProjectID))
            {
                p.IsDefault = false;
                db.Entry(p).State = EntityState.Modified;
            }
            realEstateProjectPhoto.IsDefault = true;
            db.SaveChanges();
            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("ProjectPhotos", "RealEstateProjects", new { id = realEstateProjectPhoto.ProjectID, type = "List" });
        }

        // GET: RealEstateProjectPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                RealEstateProjectPhoto realEstateProjectPhoto = db.RealEstateProjectPhotos.Find(id);
                db.RealEstateProjectPhotos.Remove(realEstateProjectPhoto);
                db.SaveChanges();
                
            }
          return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: RealEstateProjectPhotoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateProjectPhoto realEstateProjectPhoto = db.RealEstateProjectPhotos.Find(id);
        //    db.RealEstateProjectPhotos.Remove(realEstateProjectPhoto);
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
