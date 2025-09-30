using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;
using BrokerDLL.General;
using System.Configuration;

namespace BrokerDLL.Backend.Controllers
{
  public class PartnerController
    {
      IPartner View;
      public PartnerController(IPartner view)
      {
          View = view;
      }
      public void OnViewInitialize()
      {
          if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
          {
              HttpContext.Current.Response.RedirectToRoute("Login");
              return;
          }
          using(BrokerEntities Context=new BrokerEntities())
          {
              View.FillSubscriberList(Context.Subscribers.OrderBy(S => S.UserName).ToList());
              if (HttpContext.Current.Request.RequestContext.RouteData.Values["PartnerID"] == null)
              {
                  View.Mode = PageMode.Add;
                  View.Navigate();
              }
              else
              {
                  View.PartnerID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["PartnerID"]);
                  View.Mode = PageMode.Edit;
                  View.Navigate();
                  View.FillControls(Context.Partners.FirstOrDefault(R => R.ID == View.PartnerID));
              }
          }
      }

      public void OnSave()
      {
          try
          {
              using (BrokerEntities Context = new BrokerEntities())
              {
                  Partner partner;
                  if (View.Mode == PageMode.Add)
                  {
                      partner = new Partner();
                      partner.Code = "Page-" + DateTime.Now.Ticks.ToString();
                      partner = View.FillObject(partner);
                     // partner.Code = "Page-"+DateTime.Now.Ticks.ToString();
                      Context.Partners.AddObject(partner);
                      View.UploadRealEstatePhoto(partner.Code);
                      SiteMapGenerator.AddGeneralNode(ConfigurationSettings.AppSettings["WebSite"]  + partner.URL, partner.Code, partner.Title);
                  }
                  else {
                      partner = View.FillObject(Context.Partners.FirstOrDefault(C => C.ID == View.PartnerID));
                      View.UploadRealEstatePhoto(partner.Code);
                      SiteMapGenerator.EditGeneralNode(ConfigurationSettings.AppSettings["WebSite"]  + partner.URL, partner.Code, partner.Title);
                  }
                  Context.SaveChanges();
                  View.NotifyUser(Message.Save, MessageType.Success);
                  View.Mode = PageMode.Edit;
                  View.Navigate();
              }
          }
          catch (Exception ex)
          {
              View.NotifyUser(ex.Message, MessageType.Error);
          }
      
      }
      public Partner OnGet()
      {
          return Commons.Context.Partners.FirstOrDefault(C => C.ID == View.PartnerID);
      }
    }
}
