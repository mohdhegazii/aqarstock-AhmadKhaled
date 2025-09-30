using BrokerDLL.Backend.Views;
using BrokerDLL.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
    public class CatalogController
    {
        ICatalog View;
        public CatalogController(ICatalog view)
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
                View.FillCompanyList(Context.RealEstateCompanies.Where(C=>C.ActivateStatusID==(int)Activestatus.Active).OrderBy(C => C.Title).ToList());
                View.FillProjectList(Context.RealEstateProjects.Where(P => P.ActiveStatusID == (int)Activestatus.Active).OrderBy(P => P.Title).ToList());
                View.FillUserList(Context.Subscribers.Where(S => S.ActiveStatusID == (int)Activestatus.Active).OrderBy(S => S.FullName).ToList());
                View.FillCategoryList(Context.CatalogCategories.ToList());
                if (HttpContext.Current.Request.RequestContext.RouteData.Values["CatalogID"] != null)
                {
                    View.CatalogID = Convert.ToInt32(HttpContext.Current.Request.RequestContext.RouteData.Values["CatalogID"]);
                    RealEstateCatalog Catalog = Context.RealEstateCatalogs.FirstOrDefault(C => C.ID == View.CatalogID);
                    if (Catalog != null)
                    {
                        View.FillControls(Catalog);
                        GetProperties(Context);
                        View.FillTagsList(Context.Tags.Where(T => T.ParentTagID == null && T.RealestateCatalogTags.FirstOrDefault(ct=>ct.CatalogID==View.CatalogID)==null).ToList());
                        View.BindTagList(Context.RealestateCatalogTags.Where(C => C.CatalogID == View.CatalogID).ToList());
                        View.Mode = PageMode.Edit;
                        View.Navigate();
                    }
                }
                else
                {
                    View.Mode = PageMode.Add;
                    View.Navigate();
                }
            }
        }

        private void GetProperties(BrokerEntities Context)
        {
            View.BindList(Context.RealestateCatalogProperties.Where(P => P.CatalogID == View.CatalogID).ToList());
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    View.SearchMode = CatalogSearchMode.none;
                    RealEstateCatalog Catlog;
                    if (View.Mode == PageMode.Add)
                    {
                        Catlog = new RealEstateCatalog();
                        Catlog.Date = DateTime.Now;
                        Catlog.Code = "PC-" + DateTime.Now.DayOfYear + DateTime.Now.TimeOfDay.Ticks;
                        Catlog = View.FillObject(Catlog);
                        Context.RealEstateCatalogs.AddObject(Catlog);
                        Context.SaveChanges();
                        string URL = ConfigurationSettings.AppSettings["WebSite"] + "/كتالوجات_عقارية/" + Catlog.ID + "/" + Catlog.Title.Replace(" ", "_");
                        SiteMapGenerator.AddCatalogNode(URL,Catlog.Code,Catlog.Title);
                        View.FillControls(Catlog);
                        View.CatalogID = Catlog.ID;
                        View.Mode = PageMode.Edit;
                        View.Navigate();
                    }
                    else
                    {
                        Catlog = Context.RealEstateCatalogs.FirstOrDefault(C => C.ID == View.CatalogID);
                        Catlog = View.FillObject(Catlog);
                        Context.SaveChanges();
                    }
                    View.Upload(Catlog.Code);
                  
                    View.NotifyUser(Message.Save, MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnSelectCompany(int CompanyID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.SearchMode = CatalogSearchMode.ByCompany;
                RealEstateCatalog Catalog = Context.RealEstateCatalogs.FirstOrDefault(C => C.ID == View.CatalogID);
                View.FillRealestateList(Context.RealEstates.Where(R => R.Subscriber.CompanyID == CompanyID
                && R.ActiveStatusId == (int)Activestatus.Active && R.RealestateCatalogProperties.FirstOrDefault(Rc=>Rc.CatalogID==View.CatalogID)==null).OrderBy(R=>R.Title).ToList());
            }
        }
        public void OnSelectProject(int ProjectID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.SearchMode = CatalogSearchMode.ByProject;
                View.FillRealestateList(Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active 
                && R.ProjectID == ProjectID && R.RealestateCatalogProperties.FirstOrDefault(RC=>RC.CatalogID==View.CatalogID)==null).OrderBy(R=>R.Title).ToList());
            }
        }
        public void OnSelectUser(int UserId)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.SearchMode = CatalogSearchMode.ByUser;
                View.FillRealestateList(Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active 
                && R.SubscriberID == UserId && R.RealestateCatalogProperties.FirstOrDefault(RC => RC.CatalogID == View.CatalogID) == null).OrderBy(R => R.Title).ToList());
            }
        }
        public void OnDelete(int CatlogPropID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    View.SearchMode = CatalogSearchMode.none;
                    RealestateCatalogProperty CategoryProp = Context.RealestateCatalogProperties.FirstOrDefault(CP => CP.ID == CatlogPropID);
                    if (CategoryProp != null)
                    {
                        Context.RealestateCatalogProperties.DeleteObject(CategoryProp);
                        Context.SaveChanges();
                        GetProperties(Context);
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            { View.NotifyUser(ex.Message, MessageType.Error); }

        }

        public void OnAddByCode(string Code)
        {
            int code;
            List<string> CodeList = Code.Split(',').ToList();
            using (BrokerEntities Context = new BrokerEntities())
            {
                foreach (string c in CodeList)
                {
                    code = Convert.ToInt32(c);
                    RealEstate realextate = Context.RealEstates.FirstOrDefault(R => R.ID == code);
                    if (realextate != null)
                    {
                        if (realextate.ActiveStatusId == (int)Activestatus.Active)
                        {
                            RealestateCatalogProperty prop = new RealestateCatalogProperty();
                            prop.CatalogID = View.CatalogID;
                            prop.RealEstateID = realextate.ID;
                            Context.RealestateCatalogProperties.AddObject(prop);
                           
                            View.NotifyUser(Message.Save, MessageType.Success);
                        }
                        //else
                        //{
                        //    View.NotifyUser(Message.MustBeActive, MessageType.Error);
                        //}
                    }
                    //else
                    //{
                    //    View.NotifyUser(Message.CodeNotExist, MessageType.Error);
                    //}
                }
                Context.SaveChanges();
                GetProperties(Context);
            }
        }
        public void OnAdd(int RealestateID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealestateCatalogProperty prop = new RealestateCatalogProperty();
                prop.CatalogID = View.CatalogID;
                prop.RealEstateID = RealestateID;
                Context.RealestateCatalogProperties.AddObject(prop);
                Context.SaveChanges();
                GetProperties(Context);
                View.NotifyUser(Message.Save, MessageType.Success);
            }
            }
        public void OnAddTag(int TageID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealestateCatalogTag prop = new RealestateCatalogTag();
                prop.CatalogID = View.CatalogID;
                prop.TagID = TageID;
                Context.RealestateCatalogTags.AddObject(prop);
                Context.SaveChanges();
                //GetProperties(Context);
                View.FillTagsList(Context.Tags.Where(T => T.ParentTagID == null && T.RealestateCatalogTags.FirstOrDefault(ct => ct.CatalogID == View.CatalogID) == null).ToList());
                View.BindTagList(Context.RealestateCatalogTags.Where(C => C.CatalogID == View.CatalogID).ToList());
                View.NotifyUser(Message.Save, MessageType.Success);
            }
        }

        public void OnDeleteTag(int CatalogTagID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                   // View.SearchMode = CatalogSearchMode.none;
                    RealestateCatalogTag CatTag = Context.RealestateCatalogTags.FirstOrDefault(CP => CP.ID == CatalogTagID);
                    if (CatTag != null)
                    {
                        Context.RealestateCatalogTags.DeleteObject(CatTag);
                        Context.SaveChanges();
                        View.FillTagsList(Context.Tags.Where(T => T.ParentTagID == null && T.RealestateCatalogTags.FirstOrDefault(ct => ct.CatalogID == View.CatalogID) == null).ToList());
                        View.BindTagList(Context.RealestateCatalogTags.Where(C => C.CatalogID == View.CatalogID).ToList());
                        //GetProperties(Context);
                        View.NotifyUser(Message.Delete, MessageType.Success);
                    }
                }
            }
            catch (Exception ex)
            { View.NotifyUser(ex.Message, MessageType.Error); }

        }

        //private List<RealEstate> GetCatalogRealestate(BrokerEntities Context)
        //{

        //}

    }
}
