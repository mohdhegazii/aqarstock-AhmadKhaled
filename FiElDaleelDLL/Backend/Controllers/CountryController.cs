using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class CountryController:IController
    {
        ICountry View;
        public CountryController(ICountry view)
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
            View.BindCountriesList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
          
        }

        public void OnSave()
        {
            try
            {
                Country country = View.FillCountryObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(country.Name);
                    Commons.Context.Countries.AddObject(country);
                }
                Commons.Context.SaveChanges();
                View.BindCountriesList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
                View.Mode = PageMode.Add;
                View.Navigate();
                View.NotifyUser(Message.Save, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {
            View.CountryID = ID;
            View.FillCountryControls(Commons.Context.Countries.FirstOrDefault(C => C.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                Country country = Commons.Context.Countries.FirstOrDefault(C => C.ID == ID);
                if (country != null)
                {
                    if (country.Cities.Count>0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                        Commons.Context.Countries.DeleteObject(country);
                        Commons.Context.SaveChanges();
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindCountriesList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
                   
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public Country OnGet()
        {
            return Commons.Context.Countries.FirstOrDefault(C => C.ID == View.CountryID);
        }

        public List<Country> OnNeedDataSource()
        {
            return Commons.Context.Countries.OrderBy(C => C.Name).ToList();
        }
    }
}
