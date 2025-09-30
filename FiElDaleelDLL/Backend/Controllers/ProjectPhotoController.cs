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
   public class ProjectPhotoController:IController
    {
       IProjectPhoto View;
       public ProjectPhotoController(IProjectPhoto view)
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
                    View.BindList(Context.RealEstateProjectPhotos.Where(P => P.ProjectID == View.ProjectID).ToList());
               }
                View.Mode = PageMode.Add;
                View.Navigate();
            }
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P=>P.ID==View.ProjectID);
                    string random = DateTime.Now.Ticks.ToString();
                    if (Project != null)
                    {
                        RealEstateProjectPhoto Photo;
                        if (View.Mode == PageMode.Add)
                        {
                            Photo = new RealEstateProjectPhoto();
                            
                            Photo = View.FillObject(Photo,Project.Code,random);
                            if (Photo.IsDefault == true)
                            {
                                Project.RealEstateProjectPhotos.ToList().ForEach(P => P.IsDefault = false);
                            }
                            Project.RealEstateProjectPhotos.Add(Photo);
                        }
                        else
                        {
                            Photo = Project.RealEstateProjectPhotos.FirstOrDefault(p => p.ID == View.PhotoID);
                            Photo = View.FillObject(Photo,Project.Code,random);
                            if (Photo.IsDefault == true)
                            {
                                Project.RealEstateProjectPhotos.Where(P=>P.ID!=Photo.ID).ToList().ForEach(P => P.IsDefault = false);
                            }
                        }

                        Context.SaveChanges();
                        View.UpLaod(Project.Code,random);
                        View.BindList(Project.RealEstateProjectPhotos.ToList());
                        View.Mode = PageMode.Add;
                        View.Navigate();
                        if (Project.ActiveStatusID == (int)Activestatus.Suspended && !Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Projects, subscriberActions.Updated, Project.ID, Project.Title);
                            View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                        }
                        View.NotifyUser(Message.Save, MessageType.Success);
                    }
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
                View.PhotoID = ID;
                RealEstateProjectPhoto Photo = Context.RealEstateProjectPhotos.FirstOrDefault(P => P.ID == ID);
                View.FillControls(Photo);
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
                    RealEstateProjectPhoto Photo = Context.RealEstateProjectPhotos.FirstOrDefault(P => P.ID == ID);
                    if (Photo != null)
                    {
                        Context.RealEstateProjectPhotos.DeleteObject(Photo);
                        Context.SaveChanges();
                        View.BindList(Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==View.ProjectID).ToList());
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Photo.PhotoURL));
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public List<RealEstateProjectPhoto> OnNeedDataSource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.RealEstateProjectPhotos.Where(P => P.ProjectID == View.ProjectID).ToList();
            }
        }
    }
}
