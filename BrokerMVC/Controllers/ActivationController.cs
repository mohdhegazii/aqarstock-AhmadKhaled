using BrokerMVC.Extensions;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Controllers
{
    public class ActivationController : LoginController
    {
        private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        // GET: Activation
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Suspended(int? id)
        {
            Subscriber  subscriber = db.Subscribers.Find(id);
            Suspend suspend = subscriber.SuspendData;
            Security.SignOut();
            return View(suspend);
        }
        public ActionResult Pending(int? id,string Code)
        {
            if(!String.IsNullOrEmpty(Code))
            {
                Subscriber subscriber = db.Subscribers.Find(id);
                if(subscriber.ActivationCode==Code)
                {
                    subscriber.ActivationCode = null;
                    subscriber.ActiveStatusID = (int)ActiveStatus.Active;
                    db.SaveChanges();
                    ValidateUser(subscriber.Email, null, true);
                    return RedirectToAction("Index", "UserDashBoard", new { id = id });
                }
                else
                {
                    this.AddNotification(Messages.CodeNotMatch, NotificationType.ERROR);
                }
            }
            ViewBag.ID = id;
            return View();
        }
        public ActionResult Resend(int?id)
        {
            Subscriber subscriber = db.Subscribers.Find(id);
            subscriber.ActivationCode= Commons.CreateActivationCode();
            db.SaveChanges();
            //Dictionary<string, string> Code = new Dictionary<string, string>();
            //Code.Add("Code", subscriber.ActivationCode);
            //Commons.SendEmail(EmailType.GeneratePassword, subscriber.Email, Code);
            try
            {
                new MailController().ActivateAccount(subscriber).Deliver();
            }
            catch (Exception ex)
            {

            }
            try
            {
                Commons.SendSMS(subscriber.MobileNo, subscriber.ActivationCode, SMSMessages.ActivateCode);
            }
            catch(Exception ex)
            {

            }
            this.AddNotification(Messages.CodeSentSuccessfuly, NotificationType.SUCCESS);
            return RedirectToAction("Pending", new { id = id });
        }
    
    }
}