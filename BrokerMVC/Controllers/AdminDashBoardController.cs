using BrokerMVC.Code.GeneralClasses;
using BrokerMVC.Code.Repositories;
using BrokerMVC.Extensions;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using PagedList;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Admin)]
    public class AdminDashBoardController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        // GET: AdminDashBoard
        public ActionResult Index(int? page, string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "Type_desc" : "Type";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sortOrder;
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            var realEstateRepository=new RealEstateRepository(db);
            var realEstates = realEstateRepository.GetSubscriberLogList();
            switch (sortOrder)
            {
                case "name":
                    realEstates = realEstates.OrderBy(c => c.ObjectName).ThenBy(c => c.Date);
                    break;
                case "name_desc":
                    realEstates = realEstates.OrderByDescending(c => c.ObjectName).ThenBy(c => c.Date);
                    break;
                case "Type":
                    realEstates = realEstates.OrderBy(c => c.ObjectTypeID).ThenBy(c => c.Date);
                    break;
                case "Type_desc":
                    realEstates = realEstates.OrderByDescending(c => c.ObjectTypeID).ThenBy(c => c.Date);
                    break;
                default:
                    realEstates = realEstates.OrderByDescending(c => c.Date);
                    break;
            }
            return View(realEstates.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int? id)
        {
            SubscriberLog log = db.SubscriberLogs.Find(id);
            Modules objectType = (Modules)Enum.Parse(typeof(Modules), log.ObjectTypeID.ToString());
            switch (objectType)
            {
                case Modules.Companies:
                    return RedirectToAction("Edit", "RealEstateCompanies", new { id = log.ObjectID });
                case Modules.Projects:
                    return RedirectToAction("Edit", "RealEstateProjects", new { id = log.ObjectID });
                case Modules.RealEstates:
                    return RedirectToAction("Edit", "RealEstates", new { id = log.ObjectID });
                default:
                    return RedirectToAction("Edit", "RealEstates", new { id = log.ObjectID });
            }
        }

        public ActionResult ActivateBefore2020(int id)
        {
            var repository = new RealEstateRepository(new RealEstateBrokerEntities());
            var logs = db.SubscriberLogs.Where(x => x.Date < new DateTime(2020, 1, 1) && x.ObjectTypeID == (int)Modules.RealEstates).ToList();
            logs.ForEach(x =>
            {
                var realEstate = repository.GetByRealestateID(x.ObjectID);
                if (realEstate == null)
                    return;
                realEstate.ActiveStatusId = (int)ActiveStatus.Active;
                realEstate.ChangeActiveStatus = DateTime.Now;
                repository.Update(realEstate);
                repository.RemoveSuspended(realEstate.ID);
                Commons.RemoveLog(realEstate.ID, id);
                repository.Save();

                SitemapNode node;
                node = new SitemapNode
                {
                    Frequency = SitemapFrequency.Weekly,
                    LastModified = DateTime.Now,
                    Priority = 0.3,
                    Url = ConfigurationSettings.AppSettings["WebSite"] + "/Details" + "/" + realEstate.ID + "/" +
                          Commons.EncodeText(realEstate.Title),
                    EncodeURL = true,
                    Images = new List<SitemapImageNode>()
                };

                //if (data.ProductPhotos.Count > 0)
                //{
                //    AddProductPhotoNode(node, data);
                //}
                var gen = new SiteMapGenerator();
                gen.AddNewNode(node, Server.MapPath("~/SiteMap.Xml"));
                Code.GeneralClasses.AqarFeedsGenerator.GenerateProductFeedItem(realEstate);
            });
            return Json("done");
        }

        public ActionResult GetNewMsgByUser()
        {
            int ComplainsNo = db.RealEstateComplains.Where(c => c.IsRead == false).Count();
            int MsgNo = db.SubscriperMessages.Where(m => m.IsRead == false && m.IsClosed == false && m.FromSubscriber == true).Count();
            return Json(new { ComplainsNo = ComplainsNo, MsgNo = MsgNo }, JsonRequestBehavior.AllowGet);
            //(new { Id = cities.Id }(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetComplains()
        {
            return View();
        }
        public ActionResult GetMessages(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            var Messages = db.SubscriperMessages.Where(m => m.FromSubscriber == true).OrderByDescending(m => m.CreatedDate);
            return View(Messages.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult GetMessage(int? id)
        {
            SubscriperMessage Message = db.SubscriperMessages.Find(id);
            Subscriber sub = new Subscriber();
            if (Message.To != null)
            {
                sub = db.Subscribers.Find(Message.To);
            }
            if (Message.From != null)
            {
                sub = db.Subscribers.Find(Message.From);
            }
            ViewBag.Subscriber = sub.FullName;
            if (Message != null)
            {
                if (Message.IsRead != true)
                {
                    Message.IsRead = true;
                    db.SaveChanges();
                }
                if (Message.ParentMessageID != null)
                {
                    return View("GetMessage", Message.ParentMessage);
                }
                else return View("GetMessage", Message);
            }
            else
            {
                return View();
            }
        }
        public ActionResult SendReply(int? ID)
        {
            SubscriperMessage Message = new SubscriperMessage();
            Message.ParentMessageID = ID;
            return PartialView(Message);
        }
        [HttpPost]
        public ActionResult SendReply(SubscriperMessage message)
        {
            SubscriperMessage Parent = db.SubscriperMessages.Find(message.ParentMessageID);
            message.CreatedDate = DateTime.Now;
            message.FromSubscriber = false;
            message.IsRead = false;
            message.IsClosed = false;
            message.Title = "Re: " + Parent.Title;
            if (Parent.To != null)
            {
                message.To = Parent.To;
            }
            if (Parent.From != null)
            {
                message.To = Parent.From;
            }
            Parent.IsClosed = true;
            db.SubscriperMessages.Add(message);
            db.SaveChanges();
            Subscriber sub = db.Subscribers.Find(message.To);
            Dictionary<string, string> mail = new Dictionary<string, string>();
            mail.Add("Title", message.Title);
            mail.Add("Date", message.CreatedDate.ToString());
            mail.Add("Message", message.Body);
            Commons.SendEmail(EmailType.ReplyMessage, sub.Email, mail);
            this.AddNotification(Messages.SendSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("GetMessage", new { id = message.ID });
        }
        public ActionResult GetRequstedRealEstates(int? page)
        {
            int pageNumber = (page ?? 1);
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes.OrderBy(r => r.Title), "ID", "Title");
            ViewBag.TypeId = new SelectList(db.RealEstateTypes.OrderBy(r => r.Sort).ThenBy(r => r.Title), "ID", "Title");
            GeneralRepository Repository = new GeneralRepository(db);
            //   SelectList List = new SelectList(new List<District>(), "ID", "Name");
            //  List.
            ViewBag.CityId = new SelectList(new List<City>(), "ID", "Name");
            ViewBag.CountryId = new SelectList(Repository.GetCountries(), "ID", "Name");
            ViewBag.DistrictId = new SelectList(new List<District>(), "ID", "Name");
            var SearchCriteria = new RequestedRealestateSearchCriteria();

            SearchCriteria.RequestedRealestates = db.NotifyServices.OrderByDescending(r => r.Date).ToPagedList(pageNumber, 20);//.Take(10);
            return View(SearchCriteria);
        }
        [HttpPost]
        public ActionResult GetRequstedRealEstates(RequestedRealestateSearchCriteria criteria, int? page)
        {
            int pageNumber = (page ?? 1);
            // var SearchCriteria = new RequestedRealestateSearchCriteria();
            var realesteates = from r in db.NotifyServices select r;
            realesteates = FilterRequests(criteria, realesteates);
            criteria.RequestedRealestates = realesteates.OrderByDescending(r => r.Date).ToPagedList(pageNumber, 20);
            ViewBag.SaleTypeID = new SelectList(db.SaleTypes.OrderBy(r => r.Title), "ID", "Title", criteria.SaleTypeID);
            ViewBag.TypeId = new SelectList(db.RealEstateTypes.OrderBy(r => r.Sort).ThenBy(r => r.Title), "ID", "Title", criteria.TypeId);
            GeneralRepository Repository = new GeneralRepository(db);
            // var country = Repository.GetCountries().Where(c);
            //var city = Repository.GetCities(country.ID).FirstOrDefault();
            ViewBag.CountryId = new SelectList(Repository.GetCountries(), "ID", "Name");
            if (criteria.CountryID != null)
            {
                ViewBag.CityId = new SelectList(Repository.GetCities(criteria.CountryID), "ID", "Name", criteria.CityID);
            }
            else
            {
                ViewBag.CityId = new SelectList(new List<City>(), "ID", "Name");
            }
            if (criteria.CityID != null)
            {
                ViewBag.DistrictId = new SelectList(Repository.GetDistricts(criteria.CityID), "ID", "Name", criteria.DistrictID);
            }
            else
            {
                var country = Repository.GetCountries().FirstOrDefault();
                ViewBag.DistrictId = new SelectList(new List<District>(), "ID", "Name");
            }

            return View(criteria);
        }
        public ActionResult GenerateXMl()
        {
            return View();

        }
        public ActionResult GenerateRealestateFeedItems()
        {
            AqarFeedsGenerator.GenerateRealestateFeedItems();

            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("GenerateXMl");
        }
        public ActionResult GenerateProjectFeedItems()
        {
            AqarFeedsGenerator.GenerateProjectsFeedItems();

            this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("GenerateXMl");
        }

        private static IQueryable<NotifyService> FilterRequests(RequestedRealestateSearchCriteria criteria, IQueryable<NotifyService> realesteates)
        {
            if (criteria.SaleTypeID != null)
            {
                realesteates = realesteates.Where(r => r.SaleTypeID == criteria.SaleTypeID);
            }
            if (criteria.TypeId != null)
            {
                realesteates = realesteates.Where(r => r.RealEstateTypeID == criteria.TypeId);
            }
            if (criteria.CountryID != null)
            {
                realesteates = realesteates.Where(r => r.CountryID == criteria.CountryID);
            }
            if (criteria.CityID != null)
            {
                realesteates = realesteates.Where(r => r.CityID == criteria.CityID);
            }
            if (criteria.DistrictID != null)
            {
                realesteates = realesteates.Where(r => r.DistrictID == criteria.DistrictID);
            }
            if (criteria.Price != null)
            {
                realesteates = realesteates.Where(r => r.Price <= criteria.Price);
            }
            if (criteria.Area != null)
            {
                realesteates = realesteates.Where(r => r.Area == criteria.Area);
            }
            if (criteria.FromDate != null)
            {
                realesteates = realesteates.Where(r => r.Date >= criteria.FromDate);
            }
            if (criteria.ToDate != null)
            {
                realesteates = realesteates.Where(r => r.Date <= criteria.ToDate);
            }

            return realesteates;
        }
    }
}