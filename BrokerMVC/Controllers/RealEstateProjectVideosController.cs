using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;
using BrokerMVC.Extensions;
using ResourcesFiles;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin, Roles.CompanyAdmin, Roles.CompanyEmployee)]
    public class RealEstateProjectVideosController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: RealEstateProjectVideos
        public ActionResult Index()
        {
            var realEstateProjectVideos = db.RealEstateProjectVideos.Include(r => r.RealEstateProject);
            return View(realEstateProjectVideos.ToList());
        }

        // GET: RealEstateProjectVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectVideo realEstateProjectVideo = db.RealEstateProjectVideos.Find(id);
            if (realEstateProjectVideo == null)
            {
                return HttpNotFound();
            }
            return View(realEstateProjectVideo);
        }

        // GET: RealEstateProjectVideos/Create
        public ActionResult Create(int?id)
        {
            RealEstateProjectVideo Video = new RealEstateProjectVideo();
            Video.ProjectID = id;
            return PartialView("Create",Video);
        }

        // POST: RealEstateProjectVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,TiTle,EnTitle,URL,EmedCode")] RealEstateProjectVideo realEstateProjectVideo)
        {
            if (ModelState.IsValid)
            {
                db.RealEstateProjectVideos.Add(realEstateProjectVideo);
                db.SaveChanges();
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
            return RedirectToAction("Edit", "RealEstateProjects", new { id = realEstateProjectVideo.ProjectID });
        }

        // GET: RealEstateProjectVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectVideo realEstateProjectVideo = db.RealEstateProjectVideos.Find(id);
            if (realEstateProjectVideo == null)
            {
                return HttpNotFound();
            }
            return PartialView("Edit", realEstateProjectVideo);
        }

        // POST: RealEstateProjectVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,TiTle,EnTitle,URL,EmedCode")] RealEstateProjectVideo realEstateProjectVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realEstateProjectVideo).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                //  return RedirectToAction("Index");
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
            return RedirectToAction("Edit", "RealEstateProjects", new { id = realEstateProjectVideo.ProjectID });
        }

        // GET: RealEstateProjectVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstateProjectVideo realEstateProjectVideo = db.RealEstateProjectVideos.Find(id);
            int projectID = realEstateProjectVideo.ProjectID.Value;
            db.RealEstateProjectVideos.Remove(realEstateProjectVideo);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Edit", "RealEstateProjects", new { id = projectID });
        }

        // POST: RealEstateProjectVideos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    RealEstateProjectVideo realEstateProjectVideo = db.RealEstateProjectVideos.Find(id);
        //    db.RealEstateProjectVideos.Remove(realEstateProjectVideo);
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
