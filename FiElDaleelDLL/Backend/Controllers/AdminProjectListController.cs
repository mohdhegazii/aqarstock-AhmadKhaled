using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class AdminProjectListController
    {
        IAdminProjectList View;
        public AdminProjectListController(IAdminProjectList view)
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
                View.FillCompanyDLL(Context.RealEstateCompanies.OrderBy(C => C.Title).ToList());
                View.BindGrid(Context.RealEstateProjects.OrderBy(P => P.Title).ToList());
            }
        }

        public void OnSelectCompany(int CompanyID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.BindGrid(Context.RealEstateProjects.Where(P=>P.CompanyID==CompanyID).OrderBy(P => P.Title).ToList());
            }
        }
        public void OnEdit(int ID)
        {
            HttpContext.Current.Response.RedirectToRoute("ViewProject", new { ProjectID = ID, SubscriberLogID = 0 });
        }
    }
}
