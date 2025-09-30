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
    public class ProjectModelController:IController
    {
        IProjectModel View;
        public ProjectModelController(IProjectModel view)
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
                View.FillRealEstateTypeList(Context.RealEstateTypes.OrderBy(T => T.Title).ToList());
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"] != null)
                {
                   
                    View.ProjectID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["ProjectID"]);
                    View.BindList(Context.RealEstateProjectModels.Where(P => P.ProjectID == View.ProjectID).ToList());
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
                        RealEstateProjectModel Model;
                        string random = DateTime.Now.Ticks.ToString();
                        if (View.Mode == PageMode.Add)
                        {
                            Model = new RealEstateProjectModel();
                            Model = View.FillObject(Model, Project.Code,random);
                            Project.RealEstateProjectModels.Add(Model);
                        }
                        else
                        {
                            Model = Project.RealEstateProjectModels.FirstOrDefault(p => p.ID == View.ModelID);
                            Model = View.FillObject(Model, Project.Code,random);
                        }

                        Context.SaveChanges();
                        View.UpLaod(Project.Code,random);
                        if (Project.ActiveStatusID == (int)Activestatus.Suspended && !Roles.IsUserInRole(Commons.UserName, "Admin"))
                        {
                            LogAction.Log(Modules.Projects, subscriberActions.Updated, Project.ID, Project.Title);
                            View.NotifyUser(Message.SaveAndMessage, MessageType.Success);
                        }
                        View.BindList(Project.RealEstateProjectModels.ToList());
                        View.Mode = PageMode.Add;
                        View.Navigate();
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
                View.ModelID = ID;
                RealEstateProjectModel Model = Context.RealEstateProjectModels.FirstOrDefault(P => P.ID == ID);
                View.FillControls(Model);
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
                    RealEstateProjectModel Model = Context.RealEstateProjectModels.FirstOrDefault(P => P.ID == ID);
                    if (Model != null)
                    {
                        Context.RealEstateProjectModels.DeleteObject(Model);
                        Context.SaveChanges();
                        View.BindList(Context.RealEstateProjectModels.Where(P => P.ProjectID == View.ProjectID).ToList());
                        System.IO.File.Delete(HttpContext.Current.Server.MapPath(Model.PlanImgURL));
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public List<RealEstateProjectModel> OnNeedDataSource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.RealEstateProjectModels.Where(P => P.ProjectID == View.ProjectID).ToList();
            }
        }
    }
}
