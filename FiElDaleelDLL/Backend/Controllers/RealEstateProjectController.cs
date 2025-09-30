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
   public class RealEstateProjectController:IController
    {
       IRealEstateProject View;
       public RealEstateProjectController(IRealEstateProject view)
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
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillCountryList(Context.Countries.OrderBy(C => C.Name).ToList());
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"] == null)
                {
                    RealEstateCompany Company = Commons.Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Commons.Subsciber.CompanyID);
                    if (Company != null)
                    {
                        if (Company.CurrentProjectNos >= Company.ProjectNos)
                        {
                            View.NotifyUser(Message.CompanyInvalidProjectNos, MessageType.Error);
                            View.Mode = PageMode.Disable;
                            View.Navigate();
                        }
                        else
                        {
                            View.Mode = PageMode.Add;
                            View.Navigate();
                        }
                    }
                    else
                    {
                        View.NotifyUser(Message.ProjectCompanyNotExist, MessageType.Error);
                        View.Mode = PageMode.Disable;
                        View.Navigate();
                    }
                }
                else
                {
                    View.ProjectID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"]);
                    View.Mode = PageMode.Edit;
                    View.Navigate();
                    View.FillControls(Context.RealEstateProjects.FirstOrDefault(R => R.ID == View.ProjectID));
                }
            }
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    RealEstateProject Project;
                    if (View.Mode == PageMode.Add)
                    {
                        Project = new RealEstateProject();
                        Project.Code = "P-" + DateTime.Now.DayOfYear + DateTime.Now.TimeOfDay.Ticks;
                        Project.CreatedDate = DateTime.Now;
                        Project.ActiveStatusID = (int)Activestatus.New;
                        Project.SubscriberID = Commons.Subsciber.ID;
                        Project.CompanyID = Commons.Subsciber.CompanyID;
                        Project.AdPackageID = (int)AdvPackage.Normal;
                        RealEstateCompany Company = Context.RealEstateCompanies.First(C => C.ID == Commons.Subsciber.CompanyID);
                        Company.CurrentProjectNos += 1;
                        Project = View.FillObject(Project);
                        Context.RealEstateProjects.AddObject(Project);
                        Context.SaveChanges();
                        View.upload(Project.Code);
                        View.ProjectID = Project.ID;
                        if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Projects, subscriberActions.AddNew, Project.ID, Project.Title);
                        }
                    }
                    else
                    {
                        Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == View.ProjectID);
                        Project = View.FillObject(Project);
                        Context.SaveChanges();
                        View.upload(Project.Code);
                        if (Project.ActiveStatusID == (int)Activestatus.Suspended && !Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Projects, subscriberActions.Updated, Project.ID, Project.Title);
                            View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                        }
                    }

                
                    View.Mode = PageMode.Edit;
                    View.Navigate();
                    View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnSelectCountry(int CountryID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillCityList(Context.Cities.Where(C => C.CountryID == CountryID).OrderBy(C => C.Name).ToList());
            }
        }

        public void OnSelectCity(int CityID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillDistrictList(Context.Districts.Where(D => D.CityID == CityID).OrderBy(D => D.Name).ToList());
            }
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
