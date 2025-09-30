using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class DistrictController:IController
    {
        IDistrict View;
        public DistrictController(IDistrict view)
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
            View.BindDistrictList(Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                District district = View.FillDistrictObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(district.Name);
                    Commons.Context.Districts.AddObject(district);
                }
                Commons.Context.SaveChanges();
                View.BindDistrictList(Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name).ToList());
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
            View.DistrictId = ID;
            View.FillDistrictControls(Commons.Context.Districts.FirstOrDefault(D => D.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                District district = Commons.Context.Districts.FirstOrDefault(D => D.ID == ID);
                if (district != null)
                {
                    if (district.RealEstates.Count>0)
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                        return;
                    }
                    Commons.Context.Districts.DeleteObject(district);
                    Commons.Context.SaveChanges();
                    View.NotifyUser(Message.Delete, MessageType.Success);
                    View.BindDistrictList(Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name).ToList());

                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnSelectCountry(int CountryID)
        {
            View.FillCityList(Commons.Context.Cities.Where(C => C.CountryID == CountryID).OrderBy(C => C.Name).ToList());
        }

        public District OnGet()
        {
            return Commons.Context.Districts.FirstOrDefault(D => D.ID == View.DistrictId);
        }
        public List<District> OnNeedDatasource()
        {
            return Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name).ToList();
        }
    }
}
