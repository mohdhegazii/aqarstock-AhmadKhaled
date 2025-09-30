using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class AdvertisementController : IController
    {
        IAdvertisment View;
        public AdvertisementController(IAdvertisment view)
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
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.BindList(Context.Advertisements.OrderBy(A => A.Name).ToList());
            }
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Advertisement Ad;
                    if (View.Mode == PageMode.Add)
                    {
                        Ad = new Advertisement();
                        string random = DateTime.Now.Ticks.ToString();
                        Ad.Code = "C-" + DateTime.Now.DayOfYear + DateTime.Now.TimeOfDay.Ticks;
                        
                        Ad = View.FillObject(Ad, random);
                        Context.Advertisements.AddObject(Ad);
                        Context.SaveChanges();
                        View.UpLaod(Ad.Code, random);
                        Context.SaveChanges();
                        View.NotifyUser(Message.Save, MessageType.Success);
                    }
                    else
                    {
                        Ad = Context.Advertisements.FirstOrDefault(C => C.ID == View.AdvertisementID);
                        string random = DateTime.Now.Ticks.ToString();
                        Ad = View.FillObject(Ad, random);
                        Context.SaveChanges();
                        View.UpLaod(Ad.Code, random);

                        View.NotifyUser(Message.Save, MessageType.Success);
                    }

                    View.BindList(Context.Advertisements.OrderBy(A => A.Name).ToList());
                    View.Mode = PageMode.Add;
                    View.Navigate();

                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }


        public void OnEdit(int ID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.AdvertisementID = ID;
                Advertisement Ad = Context.Advertisements.FirstOrDefault(P => P.ID == ID);
                View.FillControls(Ad);
                View.Mode = PageMode.Edit;
                View.Navigate();
            }
        }

        public void OnDelete(int ID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Advertisement Ad = Context.Advertisements.FirstOrDefault(P => P.ID == ID);
                    if (Ad != null)
                    {
                        Context.Advertisements.DeleteObject(Ad);
                        Context.SaveChanges();
                        View.BindList(Context.Advertisements.OrderBy(A => A.Name).ToList());
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Ad.ContentSide));
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Ad.HomePageMainLarge));
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Ad.HomePageMainSmall));
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Ad.HomePageSide));
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
    }
}
