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
   public class ProjectVedioController:IController
    {
       IProjectVedio View;
       public ProjectVedioController(IProjectVedio view)
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
                    View.BindList(Context.RealEstateProjectVideos.Where(P => P.ProjectID == View.ProjectID).ToList());
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
                    RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == View.ProjectID);
                    if (Project != null)
                    {
                        RealEstateProjectVideo Video;
                        if (View.Mode == PageMode.Add)
                        {
                            Video = new RealEstateProjectVideo();
                            Video = View.FillObject(Video);
                            Project.RealEstateProjectVideos.Add(Video);
                        }
                        else
                        {
                            Video = Project.RealEstateProjectVideos.FirstOrDefault(p => p.ID == View.VideoID);
                            Video = View.FillObject(Video);
                        }

                        Context.SaveChanges();
                        View.BindList(Project.RealEstateProjectVideos.ToList());
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
                View.VideoID = ID;
                RealEstateProjectVideo Vedio = Context.RealEstateProjectVideos.FirstOrDefault(P => P.ID == ID);
                View.FillControls(Vedio);
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
                    RealEstateProjectVideo Vedio = Context.RealEstateProjectVideos.FirstOrDefault(P => P.ID == ID);
                    if (Vedio != null)
                    {
                        Context.RealEstateProjectVideos.DeleteObject(Vedio);
                        Context.SaveChanges();
                        View.BindList(Context.RealEstateProjectVideos.Where(P => P.ProjectID == View.ProjectID).ToList());
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }
        public List<RealEstateProjectVideo> OnNeedDataSource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.RealEstateProjectVideos.Where(P => P.ProjectID == View.ProjectID).ToList();
            }
        }
    }
}
