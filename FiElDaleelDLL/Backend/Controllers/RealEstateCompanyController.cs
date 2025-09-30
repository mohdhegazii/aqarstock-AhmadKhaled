using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Controllers
{
    public class RealEstateCompanyController:IController
    {
        IRealEstateCompany View;
        public RealEstateCompanyController(IRealEstateCompany view)
        {
            View = view;
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "CompanyAdmin") && !Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            using(BrokerEntities Context=new BrokerEntities())
            {
                View.FillCountryList(Commons.Context.Countries.OrderBy(C => C.Name).ToList());
                RealEstateCompany Company;
                if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
                {
                    Company = Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Commons.Subsciber.CompanyID);
                }
                else
                {
                    View.CompanyId = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["CompanyID"]);
                    Company = Context.RealEstateCompanies.FirstOrDefault(C => C.ID == View.CompanyId);
                }
                if (Company != null)
                {
                    ShowEditMode(Company);
                }
                else
                {
                    View.Mode = PageMode.Add;
                    View.Navigate();
                }
            }
        }

        private void ShowEditMode(RealEstateCompany Company)
        {
            View.CompanyId = Company.ID;
            View.Mode = PageMode.Edit;
            View.Navigate();
            View.FillControls(Company);
        }

        public void OnSave()
        {
            try
            {
                using(BrokerEntities Context=new BrokerEntities())
                {
                    RealEstateCompany Company;
                    if (View.Mode == PageMode.Add)
                    {
                        Company = new RealEstateCompany();
                        Company.CreatedDate = DateTime.Now;
                        Company.Code = "C-" + DateTime.Now.DayOfYear+DateTime.Now.TimeOfDay.Ticks;
                        Company.ActivateStatusID = (int)Activestatus.New;
                        Company.UserNos = 5;
                        Company.CurrentUserNos = 1;
                        Company.ProjectNos = 5;
                        Company.CurrentProjectNos = 0;
                        Company = View.FillObject(Company);
                        Context.RealEstateCompanies.AddObject(Company);
                        Context.SaveChanges();
                        View.UploadLogo(Company.Code);
                        Context.Subscribers.First(S => S.ID == Commons.Subsciber.ID).CompanyID = Company.ID;
                        Commons.Subsciber.CompanyID = Company.ID;
                        Commons.Subsciber.IsCompanyAdmin = true;
                        Context.SaveChanges();
                        View.CompanyId = Company.ID;
                        if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Companies, subscriberActions.AddNew, Company.ID, Company.Title);
                            View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                        }
                        else
                        {
                            View.NotifyUser(Message.Save, MessageType.Success);
                        }
                        //SiteMapGenerator.AddGeneralNode("",Company.Code,Company.Title.Replace(' ','-');
                    }
                    else
                    {
                        Company = Context.RealEstateCompanies.FirstOrDefault(C=>C.ID==View.CompanyId);
                        Company = View.FillObject(Company);
                        Context.SaveChanges();
                        View.UploadLogo(Company.Code);
                        if (Company.ActivateStatusID == (int)Activestatus.Suspended && !Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Companies, subscriberActions.Updated, Company.ID, Company.Title);
                            View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                        }
                        else
                        {
                            View.NotifyUser(Message.Save, MessageType.Success);
                        }
                        //SiteMapGenerator.EditGeneralNode("",Company.Code,Company.Title.Replace(' ','-');
                    }
                
                //    View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                    ShowEditMode(Company);
                 
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
        public void OnSelectCity(int CityID)
        {
            View.FillDistrictList(Commons.Context.Districts.Where(D => D.CityID == CityID).OrderBy(D => D.Name).ToList());
        }

        public void OnEdit(int ID)
        {
            throw new NotImplementedException();
        }

        public void OnDelete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
