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
    public class SearchKeywordsController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();

        // GET: SearchKeywords
        public ActionResult Index(string currentFilter, string searchString, int? page, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ParentParm = sortOrder == "Parent" ? "Parent_desc" : "Parent";
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
            var searchKeywords = from C in db.SearchKeywords select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchKeywords = searchKeywords.Where(s => s.BasicKeyword.Keywords.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    searchKeywords = searchKeywords.OrderByDescending(c => c.Keywords);
                    break;
             
                case "Parent":
                    searchKeywords = searchKeywords.OrderBy(c => c.BasicKeyword.Keywords).ThenBy(c => c.Keywords);
                    break;
                case "Parent_desc":
                    searchKeywords = searchKeywords.OrderByDescending(c => c.BasicKeyword.Keywords).ThenBy(c => c.Keywords);
                    break;
           
                default:
                    searchKeywords = searchKeywords.OrderBy(c => c.Keywords);
                    break;
            }
            return View(searchKeywords.ToPagedList(pageNumber, pageSize));
        }

        // GET: SearchKeywords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchKeyword searchKeyword = db.SearchKeywords.Find(id);
            if (searchKeyword == null)
            {
                return HttpNotFound();
            }
            return View(searchKeyword);
        }

        // GET: SearchKeywords/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.SearchKeywords.Where(K => K.ParentID == null), "ID", "Keywords");
            return View();
        }

        // POST: SearchKeywords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ParentID,Code,Keywords,URL")] SearchKeyword searchKeyword)
        {
            if (ModelState.IsValid)
            {
                searchKeyword.Code = "Gen-" + Guid.NewGuid();
                db.SearchKeywords.Add(searchKeyword);
                db.SaveChanges();
                this.AddInSiteMap(searchKeyword);
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                return RedirectToAction("Edit",searchKeyword);
            }

            ViewBag.ParentID = new SelectList(db.SearchKeywords.Where(K => K.ParentID == null), "ID", "Keywords", searchKeyword.ParentID);
            return View(searchKeyword);
        }

        // GET: SearchKeywords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchKeyword searchKeyword = db.SearchKeywords.Find(id);
            if (searchKeyword == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.SearchKeywords.Where(K => K.ParentID == null), "ID", "Keywords", searchKeyword.ParentID);
            return View(searchKeyword);
        }

        // POST: SearchKeywords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ParentID,Code,Keywords,URL")] SearchKeyword searchKeyword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchKeyword).State = EntityState.Modified;
                db.SaveChanges();
                this.AddInSiteMap(searchKeyword);
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
                //  return RedirectToAction("Edit");
            }
            ViewBag.ParentID = new SelectList(db.SearchKeywords.Where(K => K.ParentID == null), "ID", "Keywords", searchKeyword.ParentID);
            return View(searchKeyword);
        }

        // GET: SearchKeywords/Delete/5
        public ActionResult Delete(int? id)
        {
            SearchKeyword searchKeyword = db.SearchKeywords.Find(id);
            db.SearchKeywords.Remove(searchKeyword);
            db.SaveChanges();
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("Index");
        }

        // POST: SearchKeywords/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    SearchKeyword searchKeyword = db.SearchKeywords.Find(id);
        //    db.SearchKeywords.Remove(searchKeyword);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        private void AddInSiteMap(SearchKeyword tag)
        {
            SitemapNode node;
            node = new SitemapNode();
            node.Frequency = SitemapFrequency.Weekly;
            node.LastModified = DateTime.Now;
            node.Priority = 0.3;
            node.Url = tag.URL;
            node.EncodeURL = false;
            node.Images = new List<SitemapImageNode>();
            SiteMapGenerator gen = new SiteMapGenerator();
            gen.AddNewNode(node, Server.MapPath("~/SiteMap.Xml"));

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
