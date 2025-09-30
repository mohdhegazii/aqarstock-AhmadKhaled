using ActionMailer.Net.Mvc;
using BrokerMVC.Code.GeneralClasses;
using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Controllers
{
    public class MailController : MailerBase
    {
        // GET: Mail
        public EmailResult ComplainEmail(RealEstateComplain model)
        {
            To.Add("zahra.osman@masteryit.com");
            From = "test send<no-reply@mycoolsite.com>";
            Subject = "Welcome to My Cool Site!";
            return Email("ComplainEmail", model);
        }
        public EmailResult RequestEmail(RealEstatePurchaseRequest model, RealEstate realestate)
        {

            //To.Add("zahra.osman@masteryit.com");
            //To.Add("zoa.zone@gmail.com");
            To.Add(realestate.Subscriber.Email);
            if (realestate.UseContactInfo == false)
            { To.Add(realestate.OwnerEmail); }
            From = MailServer.From;
            Subject = EmailType.PurchaseRequest.GetValue();
            BCC.Add(MailServer.BCC);
            ViewBag.Realestate = realestate.Title;
            ViewBag.URL = ConfigurationSettings.AppSettings["WebSite"].ToString() + "/Details/" + realestate.ID + "/" + Commons.EncodeText(realestate.Title);
            return Email("RequestEmail", model);
        }
        public EmailResult NotifyService(NotifyService model)
        {

            //To.Add("zahra.osman@masteryit.com");
            //To.Add("zoa.zone@gmail.com");
            To.Add(MailServer.To);

            From = MailServer.From;
            Subject = EmailType.NotifyRequest.GetValue();
            return Email("NotifyRequest", model);
        }
        public EmailResult Contactus(Models.ViewModel.Contactus model)
        {
            //To.Add("zahra.osman@masteryit.com");
            //  To.Add("zoa.zone@gmail.com");
            To.Add(MailServer.To);

            From = MailServer.From;
            Subject = EmailType.ContactUs.GetValue();
            // BCC.Add(MailServer.BCC);

            return Email("Contactus", model);
        }

        public EmailResult CompanyMessageEmail(CompanyMessage model, string email, RealEstateProject Project)
        {
            // To.Add("zahra.osman@masteryit.com");
            //To.Add("zoa.zone@gmail.com");
            To.Add(email);
            From = MailServer.From;
            Subject = EmailType.ContactCompany.GetValue();

            if (model != null)
                CC.Add(model.Email);

            BCC.Add(MailServer.BCC);

            if (Project == null) 
                return Email("CompanyMessageEmail", model);

            ViewBag.Project = Project.Title;
            ViewBag.URL = ConfigurationSettings.AppSettings["WebSite"].ToString() + "/" + Menu.Projects.GetValue() + "/" + Project.ID + "/" + Commons.EncodeText(Project.Title);
            return Email("CompanyMessageEmail", model);
        }
        public EmailResult ActivateAccount(Subscriber model)
        {
            To.Add(model.Email);
            From = MailServer.From;
            Subject = EmailType.ActivateAccount.GetValue();
            BCC.Add(MailServer.BCC);
            return Email("ActivateAccount", model);
        }
        public EmailResult ForgetPassword(Subscriber model)
        {
            To.Add(model.Email);
            From = MailServer.From;
            Subject = EmailType.ForgetPassword.GetValue();
            BCC.Add(MailServer.BCC);
            return Email("ForgetPassword", model);
        }
        public EmailResult SuspendObject(string email, string reason, string Message, string Object)
        {
            To.Add(email);
            From = MailServer.From;
            Subject = EmailType.SuspendBusiness.GetValue();
            BCC.Add(MailServer.BCC);
            ViewBag.Object = Object;
            ViewBag.Reason = reason;
            ViewBag.Message = Message;
            return Email("Suspend");
        }
        public EmailResult GeneratePassword(Subscriber model)
        {
            To.Add(model.Email);
            From = MailServer.From;
            Subject = EmailType.ActivateAccount.GetValue();
            BCC.Add(MailServer.BCC);
            return Email("GeneratePassword", model);
        }
    }
}