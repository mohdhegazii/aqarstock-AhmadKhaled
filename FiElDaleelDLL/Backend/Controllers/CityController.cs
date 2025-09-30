using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class CityController:IController
    {
        ICity View;
        public CityController(ICity view)
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
            View.FillCountryList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
            View.BindCitiesList(Commons.Context.Cities.OrderBy(C=>C.Country.Name).ThenBy(C=>C.Name).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
            
        }

        public void OnSave()
        {
            try
            {
                City city = View.FillCityObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(city.Name);
                    Commons.Context.Cities.AddObject(city);
                }
                Commons.Context.SaveChanges();
                View.BindCitiesList(Commons.Context.Cities.OrderBy(C=>C.Country.Name).ThenBy(C => C.Name).ToList());
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
            View.CityId = ID;
            View.FillCityControls(Commons.Context.Cities.FirstOrDefault(C => C.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                City city = Commons.Context.Cities.FirstOrDefault(C => C.ID == ID);
                if (city != null)
                {
                    if (city.Districts.Count > 0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.Cities.DeleteObject(city);
                    Commons.Context.SaveChanges();
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    View.BindCitiesList(Commons.Context.Cities.OrderBy(C=>C.Country.Name).ThenBy(C => C.Name).ToList());

                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public City OnGet()
        {
            return Commons.Context.Cities.FirstOrDefault(C => C.ID == View.CityId);
        }

        public List<City> OnNeedDatasource()
        {
            return Commons.Context.Cities.OrderBy(C => C.Country.Name).ThenBy(C => C.Name).ToList();
        }
    }
}
