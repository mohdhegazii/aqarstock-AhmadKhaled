using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
    public class ProjectRealestateController
    {
        IProjectRealestates View;
        public ProjectRealestateController(IProjectRealestates view)
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
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"] != null)
                {
                    View.ProjectID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"]);
                    RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == View.ProjectID);
                    if (Project != null)
                    {
                        View.BindRealestateList(Context.RealEstates.Where(R => R.ProjectID == View.ProjectID).ToList());
                        View.FillRealEstateDDL(Context.RealEstates.Where(R => R.Subscriber.CompanyID == Project.CompanyID && (R.ProjectID != View.ProjectID || R.ProjectID==null)).ToList());
                    }
                }
            }
        }

        public void OnAdd(int RealestateID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == RealestateID);
                RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == View.ProjectID);
                if (realestate != null)
                {
                    realestate.ProjectID = View.ProjectID;
                    Context.SaveChanges();
                    View.BindRealestateList(Context.RealEstates.Where(R => R.ProjectID == View.ProjectID).ToList());
                    View.FillRealEstateDDL(Context.RealEstates.Where(R => R.Subscriber.CompanyID == Project.CompanyID && (R.ProjectID != View.ProjectID || R.ProjectID == null)).ToList());
                    View.NotifyUser(Message.Save, MessageType.Success);
                }
            }
        }

        public void OnRemove(int RealestateID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == RealestateID);
                RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == View.ProjectID);
                if (realestate != null)
                {
                    realestate.ProjectID = null;
                    Context.SaveChanges();
                    View.BindRealestateList(Context.RealEstates.Where(R => R.ProjectID == View.ProjectID).ToList());
                    View.FillRealEstateDDL(Context.RealEstates.Where(R => R.Subscriber.CompanyID == Project.CompanyID && (R.ProjectID != View.ProjectID || R.ProjectID == null)).ToList());
                    View.NotifyUser(Message.Delete, MessageType.Success);
                }
            }
        }

    }
}
