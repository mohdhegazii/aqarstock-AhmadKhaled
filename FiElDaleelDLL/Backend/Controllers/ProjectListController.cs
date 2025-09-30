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
   public class ProjectListController
    {
         IProjectList View;
       public ProjectListController (IProjectList view)
       {
           View = view;
       }

       public void OnViewInitialize()
       {
           if (!Roles.IsUserInRole(Commons.UserName, "CompanyAdmin"))
           {
               HttpContext.Current.Response.RedirectToRoute("Login");
               return;
           }
           using (BrokerEntities Context = new BrokerEntities())
           { 
             RealEstateCompany Company = Commons.Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Commons.Subsciber.CompanyID);
                if (Company != null)
                {
                    View.CompanyID = Company.ID;
                   View.BindList(Company.RealEstateProjects.OrderBy(P=>P.Title).ThenBy(P=>P.Country.Name).ToList());
                }
                else
                {
                    View.NotifyUser(Message.ProjectCompanyNotExist, MessageType.Error);
                }
            }
           
           }
       
       public void OnRemove(int ProjectID)
       {
           try
           {
               using (BrokerEntities Context = new BrokerEntities())
               {
                   RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == ProjectID);
                   if (Project != null)
                   {
                       DeletePhoto(Project.Logo);
                       Project.RealEstateProjectVideos.ToList().ForEach(V => Context.RealEstateProjectVideos.DeleteObject(V));
                       foreach (RealEstateProjectPhoto Photo in Project.RealEstateProjectPhotos)
                       {
                           DeletePhoto(Photo.PhotoURL);
                           
                       }
                       Project.RealEstateProjectPhotos.ToList().ForEach(p=>Context.RealEstateProjectPhotos.DeleteObject(p));
                        foreach (RealEstateProjectModel Model in Project.RealEstateProjectModels)
                       {
                           DeletePhoto(Model.PlanImgURL);
                           
                       }
                        Project.RealEstateProjectModels.ToList().ForEach(m=>Context.RealEstateProjectModels.DeleteObject(m));
                        Context.RealEstateProjects.DeleteObject(Project);
                       RealEstateCompany Company = Context.RealEstateCompanies.FirstOrDefault(C => C.ID == View.CompanyID);
                       Company.CurrentProjectNos = Company.CurrentProjectNos - 1;
                       Context.SaveChanges();
                       SiteMapGenerator.DeleteGeneralNode(Project.Code);
                       View.BindList(Context.RealEstateProjects.Where(P => P.CompanyID == View.CompanyID).OrderBy(P=>P.Title).ThenBy(P=>P.Country.Name).ToList());
                       View.NotifyUser(Message.Delete, MessageType.Success);
                   }
                   
               }
           }
           catch (Exception ex)
           {
               View.NotifyUser(ex.Message, MessageType.Error);
           }
       }

       private void DeletePhoto(string PhotoURL)
       {
           if (PhotoURL != "" && PhotoURL != null)
           {
                if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(PhotoURL)))
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath(PhotoURL));
                }
           }
          // Commons.Context.RealEstateProjectPhotos.DeleteObject(Photo);
       }

       public List<RealEstateProject> OnNeedDataSource()
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
                RealEstateCompany Company = Commons.Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Commons.Subsciber.CompanyID);
                if (Company != null)
                {
                    View.CompanyID = Company.ID;
                    return Company.RealEstateProjects.OrderBy(P => P.Title).ThenBy(P => P.Country.Name).ToList();
                }
                else
                {
                    View.NotifyUser(Message.ProjectCompanyNotExist, MessageType.Error);
                    return null;
                }
                // return Context.Subscribers.Where(S => S.CompanyID == View.CompanyID).OrderBy(S => S.FullName).ToList();
            }
       }
    }
}
