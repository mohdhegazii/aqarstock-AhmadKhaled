using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using BrokerDLL.Backend.Views;

namespace BrokerDLL.Backend.Controllers
{
    public class CompanyListController
    {
          ICompanyList View;
          public CompanyListController(ICompanyList view)
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
            View.BindGrid(Context.RealEstateCompanies.OrderBy(P=>P.Title).ToList());
            }
        }
        public void OnEdit(int ID)
        {
            HttpContext.Current.Response.RedirectToRoute("ViewCompany", new { CompanyID = ID,SubscriberLogID = 0 });
        }
    }
}
