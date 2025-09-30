using BrokerMVC.Extensions;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using PagedList;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BrokerMVC.Controllers
{
    [AuthorizeRoles(Roles.Subscriber)]
    public class UserDashBoardController : BaseController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        // GET: UserDashBoard
        public ActionResult Index()
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            if(subscriber.ActiveStatusID==(int)ActiveStatus.Suspended)
            {
                return RedirectToAction("Suspended", "Activation",new { id=subscriber.ID});
            }
            Commons.UserID = subscriber.ID;
            UserViewData user = new UserViewData();
            if (Security.IsUserInRole(Roles.CompanyAdmin))
            {
                user.Subscriptiontype = SupscriptionType.CompanyAdmin;
                if (subscriber.CompanyID == null)
                {
                    this.AddNotification(Messages.CompanyDataRequired, NotificationType.ERROR);
                    return RedirectToAction("Create", "RealEstateCompanies");
                }
                else
                {
                    user.Company = subscriber.RealEstateCompany;
                    if (subscriber.RealEstateCompany.ActivateStatusID == (int)ActiveStatus.Suspended)
                    {
                        user.SuspendData = new Suspend();
                        user.SuspendData.Message = subscriber.RealEstateCompany.SuspendMessage;
                        user.SuspendData.SuspendReasonID = subscriber.RealEstateCompany.SuspendReasonID;
                        user.SuspendData.SuspendReason = subscriber.RealEstateCompany.SuspendReason.Title;
                        user.SuspendData.ID = subscriber.RealEstateCompany.ID;
                    }
                }
            }
            else
            {
                if (Security.IsUserInRole(Roles.CompanyEmployee))
                {
                    user.Subscriptiontype = SupscriptionType.CompanyEmployee;
                }
                else
                {
                    user.Subscriptiontype = SupscriptionType.Individual;
                }
            }

            if (user != null)
            {
                user.ID = subscriber.ID;
                user.Name = subscriber.FullName;
                user.UserName = subscriber.UserName;
                user.ActiveStatusID = subscriber.ActiveStatusID;
                user.Company = subscriber.RealEstateCompany;
                //if (subscriber.ActiveStatusID == (int)ActiveStatus.Suspended)
                //{
                //    user.SuspendData = new Suspend();
                //    user.SuspendData.ID = subscriber.ID;
                //    user.SuspendData.Message = subscriber.SuspendMessage;
                //    user.SuspendData.SuspendReasonID = subscriber.SuspendReasonID;
                //}


            }
            return View(user);
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetNotifications()
        {
            if (Commons.UserID != null)
            {
                var notifications = db.SubscriberNotifications.Where(n => n.IsRead == false && n.SubscriberID == Commons.UserID);
                ViewBag.NotificationsNo = notifications.Count();
                return PartialView("GetNotifications", notifications.OrderByDescending(n => n.CreatedDate).Take(5).ToList());
            }
            return null;
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetPurchaseRequest()
        {
            if (Commons.UserID != null)
            {
                var notifications = db.RealEstatePurchaseRequests.Where(n => n.IsRead == false && n.IsInquiry != true && n.IsDeleted == false);
                notifications = notifications.Where(n => n.RealEstate.SubscriberID == Commons.UserID);
                ViewBag.RequestsNo = notifications.Count();
                return PartialView("GetPurchaseRequest", notifications.OrderByDescending(n => n.Date).Take(5).ToList());
            }
            return null;
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetCompanyPurchaseRequest()
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            if (Commons.UserID != null)
            {
                var notifications = db.RealEstatePurchaseRequests.Where(n => n.IsRead == false && n.IsInquiry != true && n.IsDeleted == false);
                notifications = notifications.Where(n => n.RealEstate.SubscriberID != Commons.UserID && n.RealEstate.Subscriber.CompanyID == subscriber.CompanyID);
                ViewBag.RequestsNo = notifications.Count();
                return PartialView("GetCompanyPurchaseRequest", notifications.OrderByDescending(n => n.Date).Take(5));
            }
            return null;
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetProjectInquiries()
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            if (Commons.UserID != null)
            {
                var notifications = db.CompanyMessages.Where(n => n.IsRead == false && n.IsDeleted != true && n.IsInquiry!=true && n.CompanyID == subscriber.CompanyID);
                ViewBag.InquiriesNo = notifications.Count();
                return PartialView("GetProjectInquiries", notifications.OrderByDescending(n => n.CreatedDate).Take(5).ToList());
            }
            return null;
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetIncompleteRealEstate()
        {
            var realestates = db.RealEstates.Where(r => r.SubscriberID == Commons.UserID
              && (r.ActiveStatusId == (int)ActiveStatus.IncompleteAddress || r.ActiveStatusId == (int)ActiveStatus.IncompletePhotos));
            return PartialView(realestates);
        }
        [OutputCache(CacheProfile = "Sometime", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetFavouriteRealEstate()
        {
            Subscriber sub = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            return View(sub.SubscriberFavouriteRealEstates);
        }
        public ActionResult DeleteFavouriteRealestate(int? id)
        {
            SubscriberFavouriteRealEstate Fav = db.SubscriberFavouriteRealEstates.Find(id);
            db.SubscriberFavouriteRealEstates.Remove(Fav);
            this.AddNotification(Messages.DeletedSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("GetFavouriteRealEstate");
        }
        public ActionResult MoveRealEstates(int? OldOwnerID, int? NewOwnerID)
        {
            Subscriber sub = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            var subscribers = db.Subscribers.Where(s => s.CompanyID == sub.CompanyID);
            MoveRealestates mr = new MoveRealestates();
            if (OldOwnerID != null)
            {
                ViewBag.OldOwnerID = new SelectList(subscribers, "ID", "FullName", OldOwnerID);
                mr.OldOwnerID = OldOwnerID;
                mr.Realestates = db.RealEstates.Where(r => r.SubscriberID == OldOwnerID).Select(r => new SelectListItem
                {
                    Text = r.Title,
                    Value = r.ID.ToString(),
                    Selected = false
                }).ToList();
            }
            else
            {
                ViewBag.OldOwnerID = new SelectList(subscribers, "ID", "FullName");
                mr.Realestates = new List<SelectListItem>();
            }
            //if (NewOwnerID != null)
            //{
            //    ViewBag.NewOwnerID = new SelectList(subscribers, "ID", "FullName", NewOwnerID);
            //    mr.NewOwnerID = NewOwnerID;
            //}
            //else
            //{
            ViewBag.NewOwnerID = new SelectList(subscribers, "ID", "FullName");
            // mr.NewOwnerID = NewOwnerID;
            //}
            return View(mr);
        }

        [HttpPost]
        public ActionResult MoveRealEstates(MoveRealestates mr)
        {
            if (mr.NewOwnerID != null)
            {
                RealEstate realestate;
                foreach (SelectListItem item in mr.Realestates.Where(r => r.Selected == true))
                {
                    realestate = db.RealEstates.Find(Convert.ToInt32(item.Value));
                    realestate.SubscriberID = mr.NewOwnerID;

                }
                db.SaveChanges();
                mr.Realestates = db.RealEstates.Where(r => r.SubscriberID == mr.OldOwnerID).Select(r => new SelectListItem
                {
                    Text = r.Title,
                    Value = r.ID.ToString(),
                    Selected = false
                }).ToList();
                this.AddNotification(Messages.SavedSuccessfully, NotificationType.SUCCESS);
            }
            else
            {
                this.AddNotification(Messages.MovetoRequired, NotificationType.ERROR);
            }
            Subscriber sub = db.Subscribers.Find(mr.OldOwnerID);
            var subscribers = db.Subscribers.Where(s => s.CompanyID == sub.CompanyID);
            ViewBag.OldOwnerID = new SelectList(subscribers, "ID", "FullName", sub);
            ViewBag.NewOwnerID = new SelectList(subscribers, "ID", "FullName");
            return View(mr);
        }

        [OutputCache(CacheProfile = "Sometime", VaryByParam = "page", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult GetMessages(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 20;
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            var Messages = db.SubscriperMessages.Where(m => m.FromSubscriber != true && m.To==subscriber.ID).OrderByDescending(m => m.CreatedDate);
            return View(Messages.ToPagedList(pageNumber, pageSize));
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "id", Location = OutputCacheLocation.Client, NoStore = true)]
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
            Subscriber sub = db.Subscribers.FirstOrDefault(s=>s.UserName==Commons.UserName);
            message.CreatedDate = DateTime.Now;
            message.FromSubscriber = true;
            message.IsRead = false;
            message.IsClosed = false;
            message.Title = "Re: " + Parent.Title;
            message.From = sub.ID;
            db.SubscriperMessages.Add(message);
            db.SaveChanges();
            this.AddNotification(Messages.SendSuccessfully, NotificationType.SUCCESS);
            return RedirectToAction("GetMessage", new { id = message.ID });
        }
        public ActionResult SendMsg()
        {
            ViewBag.MessageTypeID = new SelectList(db.SubscriperMessageTypes, "ID", "Title");
            return PartialView("SendMsg");
        }
        [HttpPost]
        public ActionResult SendMsg(SubscriperMessage message)
        {
            Subscriber subscriber = db.Subscribers.FirstOrDefault(s => s.UserName == Commons.UserName);
            message.IsClosed = false;
            message.IsRead = false;
            message.CreatedDate = DateTime.Now;
            message.FromSubscriber = true;
            message.From = subscriber.ID;
            db.SubscriperMessages.Add(message);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}