using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrokerMVC.Models;
using System.IO;
using ResourcesFiles;
using BrokerMVC.Extensions;

namespace BrokerMVC.Controllers
{
    public class AdvertisementsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: Advertisements
        public ActionResult Index()
        {
            return View(db.Advertisements.ToList());
        }

        // GET: Advertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertisements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                string ImagePath = DirectoryManager.GetDirectory("~/Resources/Ads/", advertisement.Code);
                var Isvalid = true;
                var random = Guid.NewGuid();
                advertisement.Code= "C-" + DateTime.Now.DayOfYear + DateTime.Now.TimeOfDay.Ticks;
                Isvalid = ValidateContentAd(advertisement, ImagePath, random.ToString());
                Isvalid = ValidateHomePageLargeAd(advertisement, ImagePath, random.ToString());
                Isvalid = ValidateHomePageSmallAd(advertisement, ImagePath, random.ToString());
                Isvalid = ValidateHomePageSideAd(advertisement, ImagePath, random.ToString());
                if (Isvalid == true)
                {
                    db.Advertisements.Add(advertisement);
                    db.SaveChanges();
                    this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                    return RedirectToAction("Edit", new { id = advertisement.ID });
                }
            }

            return View(advertisement);
        }

        // GET: Advertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                string ImagePath = DirectoryManager.GetDirectory("~/Resources/Ads/", advertisement.Code);
                var Isvalid = true;
                var random = Guid.NewGuid();
                if (advertisement.ContentSideFile != null)
                {
                    Isvalid = ValidateContentAd(advertisement, ImagePath, random.ToString());
                }
                if (advertisement.HomePageMainLargeFile != null)
                {
                    Isvalid = ValidateHomePageLargeAd(advertisement, ImagePath, random.ToString());
                }
                if (advertisement.HomePageMainSmallFile != null)
                {
                    Isvalid = ValidateHomePageSmallAd(advertisement, ImagePath, random.ToString());
                }
                if (advertisement.HomePageSideFile != null)
                {
                    Isvalid = ValidateHomePageSideAd(advertisement, ImagePath, random.ToString());

                }
                if (Isvalid == true)
                {
                    db.Entry(advertisement).State = EntityState.Modified;
                    db.SaveChanges();
                    this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                }
                return RedirectToAction("Edit", new { id = advertisement.ID });
            }
            return View(advertisement);
        }


        // GET: Advertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = db.Advertisements.Find(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            DirectoryManager.RemoveFile(advertisement.HomePageMainLarge);
            DirectoryManager.RemoveFile(advertisement.HomePageMainSmall);
            DirectoryManager.RemoveFile(advertisement.HomePageSide);
            DirectoryManager.RemoveFile(advertisement.ContentSide);
            db.Advertisements.Remove(advertisement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Advertisements/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Advertisement advertisement = db.Advertisements.Find(id);
        //    db.Advertisements.Remove(advertisement);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        private bool ValidateHomePageLargeAd(Advertisement advertisement, string ImagePath, string random)
        {
            bool Isvalid = true;

            if (advertisement.HomePageMainLargeFile == null || advertisement.HomePageMainLargeFile.ContentLength == 0)
            {
                ModelState.AddModelError("HomePageMainLargeFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            else
            {
                ValidationResult result = ImageHelper.ValidateImage(advertisement.HomePageMainLargeFile, ImageTypes.AdHomePageMainLarge);
                if (!result.IsValid)
                {
                    ModelState.AddModelError("HomePageMainLargeFile", result.Message);
                    Isvalid = false;
                }
                else
                {
                    SaveImage(advertisement.HomePageMainLargeFile, AdsTypes._HomePageMainLarge, ImagePath, advertisement.Code, random.ToString());
                    advertisement.HomePageMainLarge = ImagePath + "/" + random + AdsTypes._HomePageMainLarge.ToString() + Path.GetExtension(advertisement.HomePageMainLargeFile.FileName);
                }
            }
            return Isvalid;
        }
        private bool ValidateHomePageSmallAd(Advertisement advertisement, string ImagePath, string random)
        {
            bool Isvalid = true;

            if (advertisement.HomePageMainSmallFile == null || advertisement.HomePageMainSmallFile.ContentLength == 0)
            {
                ModelState.AddModelError("HomePageMainSmallFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            else
            {
                ValidationResult result = ImageHelper.ValidateImage(advertisement.HomePageMainSmallFile, ImageTypes.AdHomePageMainSmall);
                if (!result.IsValid)
                {
                    ModelState.AddModelError("HomePageMainSmallFile", result.Message);
                    Isvalid = false;
                }
                else
                {
                    SaveImage(advertisement.HomePageMainSmallFile, AdsTypes._HomePageMainSmall, ImagePath, advertisement.Code, random.ToString());
                    advertisement.HomePageMainSmall = ImagePath + "/" + random + AdsTypes._HomePageMainSmall.ToString() + Path.GetExtension(advertisement.HomePageMainSmallFile.FileName);
                }
            }
            return Isvalid;
        }
        private bool ValidateHomePageSideAd(Advertisement advertisement, string ImagePath, string random)
        {
            bool Isvalid = true;
            if (advertisement.HomePageSideFile == null || advertisement.HomePageSideFile.ContentLength == 0)
            {
                ModelState.AddModelError("HomePageSideFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            else
            {
                ValidationResult result = ImageHelper.ValidateImage(advertisement.HomePageSideFile, ImageTypes.AdHomePageSide);
                if (!result.IsValid)
                {
                    ModelState.AddModelError("HomePageSideFile", result.Message);
                    Isvalid = false;
                }
                else
                {
                    SaveImage(advertisement.HomePageSideFile, AdsTypes._HomePageSide, ImagePath, advertisement.Code, random.ToString());
                    advertisement.HomePageSide = ImagePath + "/" + random + AdsTypes._HomePageSide.ToString() + Path.GetExtension(advertisement.HomePageSideFile.FileName);
                }
            }
            return Isvalid;
        }
        private bool ValidateContentAd(Advertisement advertisement, string ImagePath, string random)
        {
            bool Isvalid = true;
            if (advertisement.ContentSideFile == null || advertisement.ContentSideFile.ContentLength == 0)
            {
                ModelState.AddModelError("ContentSideFile", Messages.PhotoRequired);
                Isvalid = false;
            }
            else
            {
                ValidationResult result = ImageHelper.ValidateImage(advertisement.ContentSideFile, ImageTypes.AdContnetSide);
                if (!result.IsValid)
                {
                    ModelState.AddModelError("ContentSideFile", result.Message);
                    Isvalid = false;
                }
                else
                {
                    SaveImage(advertisement.ContentSideFile, AdsTypes._ContnetSide, ImagePath, advertisement.Code, random);
                    advertisement.ContentSide = ImagePath + "/" + random + AdsTypes._ContnetSide.ToString() + Path.GetExtension(advertisement.ContentSideFile.FileName);
                }
            }
            return Isvalid;
        }
        private void SaveImage(HttpPostedFileBase Photo, AdsTypes type, string ImagePath, string Code, string random)
        {
            string filename = Server.MapPath(ImagePath) + "\\" + random + type.ToString() + Path.GetExtension(Photo.FileName);
            ImageHelper.ApplyCompressionAndSave(Photo, filename, 30, Photo.ContentType);

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
