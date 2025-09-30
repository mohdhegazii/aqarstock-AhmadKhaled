using BrokerMVC.Code.Repositories;
using BrokerMVC.Extensions;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using PagedList;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BrokerMVC.Controllers
{
    public class HomeController : BaseController
    {
        // private RealEstateBrokerEntities db = new RealEstateBrokerEntities();
        HomeRepository Repository = new HomeRepository(new RealEstateBrokerEntities());
        [OutputCache(CacheProfile = "Rare", VaryByParam = "id")]
        public ActionResult GetImportantTypes(int? id)
        {
            var Types = Repository.GetTypes(id).Take(5);
            string URl = "/" + Commons.EncodeText(Menu.Type.GetValue()) + "/";
            return Json(Types.Select(c => new
            {
                Id = c.ID,
                Name = Commons.Culture.Contains("ar") ? c.Title : c.EnTitle,
                URL = URl + c.ID.ToString() + "/" + Commons.EncodeText(Commons.Culture.Contains("ar") ? c.Title : c.EnTitle),
                CatID = c.RealEstateCategoryId
            }), JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Sometime")]
        public ActionResult Index()
        {
            HomePage view = new HomePage();
            view.BannerProject = Repository.GetBannerProject();
            view.Projects = Repository.GetHomeProject();
            //var Properties = Repository.GetSpecailProperties().OrderByDescending(p => p.ChangeActiveStatus).Take(7);
            //view.SpecialProp = Properties.First();
            //view.SpecialPropList = Properties.Skip(1).ToList();
            return View(view);

        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page;PageSize")]
        public ActionResult GeSpecialtProperties(int? Page, int PageSize)
        {
            int pageNumber = (Page ?? 1);
            HorizonatlPropertyListView View = new HorizonatlPropertyListView();
            View.SpecailProperty = Repository.GetSpecailProperties().OrderByDescending(p => p.ChangeActiveStatus).FirstOrDefault();
            if (pageNumber == 0)
            {
                View.ReqularProperties = Repository.GetSpecailProperties().OrderByDescending(p => p.ChangeActiveStatus).Take(PageSize).ToList();
            }
            else
            {
                var count = Repository.CountSpecailProperties();
                if (count > (pageNumber * PageSize) + PageSize)
                {
                    View.ReqularProperties = Repository.GetSpecailProperties().OrderByDescending(p => p.ChangeActiveStatus).Skip((pageNumber * PageSize) + PageSize).Take(PageSize).ToList();
                }
                else
                {
                    View.ReqularProperties = new List<RealEstate>();
                }
            }
            View.Name = General.SpecialPropList;
            return PartialView("Partial/SpecialProperties", View);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "SaleTypeID;Page;PageSize")]
        public ActionResult GetPropertiesBySaleType(int SaleTypeID, int? Page, int PageSize)
        {
            int pageNumber = (Page ?? 1);
            HorizonatlPropertyListView View = new HorizonatlPropertyListView();
            View.SpecailProperty = Repository.GetSpecailProperties().OrderByDescending(p => Guid.NewGuid()).FirstOrDefault();
            if (pageNumber == 0)
            {
                View.ReqularProperties = Repository.GetPropertiesBySaleType(SaleTypeID).OrderByDescending(p => p.ChangeActiveStatus).Take(PageSize).ToList();
            }
            else
            {
                View.ReqularProperties = Repository.GetPropertiesBySaleType(SaleTypeID).OrderByDescending(p => p.ChangeActiveStatus).Skip((pageNumber * PageSize) + PageSize).Take(PageSize).ToList();
            }
            if (SaleTypeID == (int)SaleTypes.Sale)
                View.Name = General.LatestAddedForSale;
            else
                View.Name = General.LatestAddedForRent;
            return PartialView("Partial/PropHorizentalList", View);
        }
        //[OutputCache(CacheProfile = "Often", VaryByParam = "Page,PageSize")]
        //public ActionResult GetHomeForRentProperties( int? Page, int PageSize)
        //{
        //    int pageNumber = (Page ?? 1);
        //    HorizonatlPropertyListView View = new HorizonatlPropertyListView();
        //    View.SpecailProperty = Repository.GetSpecailProperties().OrderByDescending(p => Guid.NewGuid()).FirstOrDefault();
        //    View.ReqularProperties = Repository.GetPropertiesBySaleType(2).OrderByDescending(p => p.ChangeActiveStatus).Skip((pageNumber * PageSize) + PageSize).Take(PageSize).ToList();
        //    View.Name = General.LatestAddedForRent;
        //    return PartialView("Partial/PropHorizentalList", View);
        //}
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page")]
        public ActionResult GetPropertiesForRent(int? Page)
        {
            int pageNumber = (Page ?? 1);
            PropertyListView view = new PropertyListView();
            view.Name = General.LatestAddedForRent;
            view.SpecailProperties = Repository.GetSpecailPropertiesBySaleType((int)SaleTypes.Rent).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProperties = Repository.GetPropertiesBySaleType((int)SaleTypes.Rent).OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
            view.Type = Menu.Rent;
            return View("PropertyList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "SaleTypeID;Page;PageSize")]
        public ActionResult GetLatestPropertiesBySaleType(int? SaleTypeID, int? Page, int PageSize)
        {
            int pageNumber = (Page ?? 1);

            var Props = Repository.GetPropertiesBySaleType(SaleTypeID).OrderByDescending(p => p.ChangeActiveStatus).Skip((pageNumber * PageSize) + PageSize).Take(PageSize);

            return PartialView("Partial/HorizentalPropSlides", Props);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page;PageSize")]
        public ActionResult GetSpecialProperties(int? Page, int PageSize)
        {
            int pageNumber = (Page ?? 1);
            var Props = Repository.GetSpecailProperties().OrderByDescending(p => p.ChangeActiveStatus).Skip((pageNumber * PageSize) + PageSize + 1).Take(PageSize);

            return PartialView("Partial/SpecialPropSlides", Props);
        }

        public ActionResult ContentAd()
        {
            var view = Repository.GetAd();
            return PartialView("Partial/ContentAd", view);
        }
        public ActionResult userinfo()
        {
            //  var view = Repository.GetAd();
            return PartialView("Partial/userinfo");
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "page")]
        public ActionResult GetPageContent(string page)
        {
            Pages Page = (Pages)Enum.Parse(typeof(Pages), page);
            var view = Repository.GetContent(Page);
            return PartialView("Partial/GetPageContent", view);
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "Page")]
        public ActionResult GetLatestProperties(int? Page)
        {
            int pageNumber = (Page ?? 1);
            PropertyListView view = new PropertyListView();
            view.Name = General.LatestAdded;
            view.SpecailProperties = Repository.GetSpecailProperties().OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProperties = Repository.GetProperties().OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
            view.Type = Menu.LatestAdded;
            return View("PropertyList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "catid;page")]
        public ActionResult PropertyByCategory(int catid, string catname, int? page)
        {
            int pageNumber = (page ?? 1);
            PropertyListView view = new PropertyListView();
            view.Name = catname.Trim().Replace("_", " ");
            view.SpecailProperties = Repository.GetSpecailProperties(catid).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProperties = Repository.GetPropertiesByCategory(catid).OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
            switch (catid)
            {
                case 1:
                    view.Type = Menu.Resdintial;
                    break;
                case 2:
                    view.Type = Menu.Commercial;
                    break;
                case 3:
                    view.Type = Menu.Lands;
                    break;
                default:
                    view.Type = Menu.Resdintial;
                    break;
            }
            return View("PropertyList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Typeid;page")]
        public ActionResult PropertyByType(int Typeid, string Typename, int? page)
        {
            int pageNumber = (page ?? 1);
            PropertyListView view = new PropertyListView();
            view.Name = Typename.Trim().Replace("_", " ");
            view.SpecailProperties = Repository.GetSpecailPropertiesByType(Typeid).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProperties = Repository.GetPropertiesByType(Typeid).OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
            return View("PropertyList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ProjectID;Type;page")]
        public ActionResult PropertyByProject(int? ProjectID, string Type, int? page)
        {
            int pageNumber = (page ?? 1);
            RealEstateProject Project = Repository.GetProject(ProjectID);
            if (Type == "InDetails")
            {

                ViewBag.ID = Project.ID;
                ViewBag.Name = Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle;
                ViewBag.URL = Menu.Projects.GetValue() + "/" + Project.ID + "/" + Commons.EncodeText(ViewBag.Name) + "/ProjectProperties";
                var Prop = Repository.GetPropertiesByProject(ProjectID).OrderByDescending(p => p.ChangeActiveStatus).Take(4).ToList();
                return PartialView("Partial/ProjectProperties", Prop);
            }
            else
            {
                PropertyListView view = new PropertyListView();
                view.Name = (Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle);
                view.SpecailProperties = Repository.GetSpecailPropertiesByProject(ProjectID).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
                view.ReqularProperties = Repository.GetPropertiesByProject(ProjectID).OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
                return View("PropertyList", view);
            }
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "CompanyID;Type;page")]
        public ActionResult PropertyByCompany(int? CompanyID, string Type, int? page)
        {
            int pageNumber = (page ?? 1);
            RealEstateCompany Project = Repository.GetCompany(CompanyID);
            if (Type == "InDetails")
            {

                ViewBag.ID = Project.ID;
                ViewBag.Name = Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle;
                ViewBag.URL = Menu.Companys.GetValue() + "/" + Project.ID + "/" + Commons.EncodeText(ViewBag.Name) + "/Properties";
                var Prop = Repository.GetPropertiesByCompany(CompanyID).OrderByDescending(p => p.ChangeActiveStatus).Take(4).ToList();
                return PartialView("Partial/ProjectProperties", Prop);
            }
            else
            {
                PropertyListView view = new PropertyListView();
                view.Name = (Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle);
                view.SpecailProperties = Repository.GetSpecailPropertiesByCompany(CompanyID).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
                view.ReqularProperties = Repository.GetPropertiesByCompany(CompanyID).OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
                return View("PropertyList", view);
            }
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ProjectID;Type;page")]
        public ActionResult ProjectModels(int? ProjectID, string Type, int? page)
        {
            int pageNumber = (page ?? 1);
            RealEstateProject Project = Repository.GetProject(ProjectID);

            ViewBag.ID = Project.ID;
            ViewBag.Name = Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle;
            if (Type == "InDetails")
            {

                var Prop = Repository.GetProjectModels(ProjectID).OrderByDescending(p => Guid.NewGuid()).Take(4).ToList();
                return PartialView("Partial/ProjectModels", Prop);
            }
            else
            {
                ModelListView view = new ModelListView();
                view.Project = Project;
                view.Models = Repository.GetProjectModels(ProjectID).ToList();
                return View("ProjectModelsList", view);
            }
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "CompanyID;Type;page")]
        public ActionResult CompanyProjects(int? CompanyID, string Type, int? page)
        {
            int pageNumber = (page ?? 1);
            RealEstateCompany Project = Repository.GetCompany(CompanyID);
            if (Type == "InDetails")
            {

                ViewBag.ID = Project.ID;
                ViewBag.Name = Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle;
                var Prop = Repository.GetCompanyProjects(CompanyID).OrderByDescending(p => p.StatusChangeDate).Take(4).ToList();
                return PartialView("Partial/CompanyProject", Prop);
            }
            else
            {
                ProjectListView view = new ProjectListView();
                view.Name = (Commons.Culture.Contains("ar") ? Project.Title : Project.EnTitle);
                view.SpecailProjects = Repository.GetSpecailProjects(CompanyID).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
                view.ReqularProjects = Repository.GetCompanyProjects(CompanyID).OrderByDescending(p => p.StatusChangeDate).ToPagedList(pageNumber, 8);
                return View("ProjectList", view);
            }
        }
        [OutputCache(CacheProfile = "Often")]
        public ActionResult PropertyList()
        {
            return View();
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page")]
        public ActionResult ProjectList(int? Page)
        {
            int pageNumber = (Page ?? 1);
            ProjectListView view = new ProjectListView();
            view.Name = General.ProjectList;
            view.SpecailProjects = Repository.GetSpecailProjects().OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProjects = Repository.GetProjects().OrderByDescending(p => p.StatusChangeDate).ToPagedList(pageNumber, 8);
            view.Type = Menu.Projects;
            return View("ProjectList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page")]

        public ActionResult CompanyList(int? Page)
        {
            int pageNumber = (Page ?? 1);
            CompanyListView view = new CompanyListView();
            view.Name = General.Companies;
            view.SpecialCompany = Repository.GetSpecialCompanies().OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularCompany = Repository.GetCompanies().OrderByDescending(p => p.StatusChangeDate).ToPagedList(pageNumber, 8);
            return View("CompanyList", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ID")]
        public ActionResult ProjectDetail(int? ID, string ProjectName)
        {
            var view = Repository.GetProject(ID);
            return View(view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ID")]
        public ActionResult PropertyDetail(int? ID, string Name)
        {
            var view = Repository.GetProperty(ID);
            return View(view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ModelID")]
        public ActionResult ModelDetail(int? ModelID)
        {
            var view = Repository.GetModel(ModelID);
            return View("ModelDetail", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "CompanyID")]
        public ActionResult CompanyDetail(int? CompanyID)
        {
            var view = Repository.GetCompany(CompanyID);
            return View("CompanyDetails", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ID")]
        public ActionResult CatalogDetail(int? ID)
        {
            var view = Repository.GetCatlog(ID);
            return View("Catalogs", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ID")]
        public ActionResult CatalogProperties(int? ID)
        {
            var view = Repository.GetCatalogProperties(ID);
            return PartialView("Partial/CatalogProperties", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "ID")]
        public ActionResult OldCatalogDetail(int? ID)
        {
            var view = Repository.GetCatlog(ID);
            return View("OldCatalog", view);
        }

        [OutputCache(CacheProfile = "Often", VaryByParam = "type")]
        public ActionResult Search(string type)
        {
            SearchCriteria criteria = new SearchCriteria();
            ViewBag.CID = new SelectList(Repository.GetCountries(), "ID", "Name");
            ViewBag.TID = new SelectList(Repository.GetTypes(), "ID", "Title");
            ViewBag.CuID = new SelectList(Repository.GetCurrencies(), "ID", "Name");
            ViewBag.PID = new SelectList(Repository.GetPaymenTypes(), "ID", "Title");
            ViewBag.SID = new SelectList(Commons.GetSaleTypeList(), "Value", "Text");
            ViewBag.Price = new SelectList(Commons.GetPriceList(), "Value", "Text");
            ViewBag.Area = new SelectList(Commons.GetAreaList(), "Value", "Text");

            ViewBag.CyId = new SelectList(new List<City>(), "ID", "Name");
            ViewBag.DID = new SelectList(new List<District>(), "ID", "Name");
            ViewBag.STID = new SelectList(new List<RealEstateStatu>(), "ID", "Name");
            if (type == "HomePage")
            {
                return PartialView("Partial/HomeSearch", criteria);
            }
            else
            {
                return PartialView("Partial/InnerSearch", criteria);
            }
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "Page;SID;TID;CID;CyId;DID;Price;Area;STID;PID;CUID")]
        public ActionResult SearchResult(int? Page, int? SID, int? TID, int? CID, int? CyId, int? DID, int? Price, int? Area, int? STID, int? PID, int? CUID)
        {
            int pageNumber = (Page ?? 1);
            PropertyListView view = new PropertyListView();
            view.Name = General.SearchResult;

            IQueryable<RealEstate> Props = GetSearchResult(Repository.GetProperties(), SID, TID, CID, CyId, DID, Price, Area, STID, PID, CUID);
            IQueryable<RealEstate> SpecialProps = GetSearchResult(Repository.GetSpecailProperties(), SID, TID, CID, CyId, DID, Price, Area, STID, PID, CUID);
            view.SpecailProperties = SpecialProps.OrderBy(p => Guid.NewGuid()).Take(2).ToList();


            view.ReqularProperties = Props.OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 8);
            return View("SearchResult", view);
        }
        [OutputCache(CacheProfile = "Often", VaryByParam = "CID;Page;CyId;DID")]
        public ActionResult SearchProject(int? Page, int? CID, int? CyId, int? DID)
        {
            int pageNumber = (Page ?? 1);
            ProjectListView view = new ProjectListView();
            view.Name = General.SearchResult;
            view.SpecailProjects = GetProjectSearchResult(Repository.GetSpecailProjects(), CID, CyId, DID).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
            view.ReqularProjects = GetProjectSearchResult(Repository.GetProjects(), CID, CyId, DID).OrderByDescending(p => p.StatusChangeDate).ToPagedList(pageNumber, 8);

            return View("ProjectList", view);
        }

        private IQueryable<RealEstate> GetSearchResult(IQueryable<RealEstate> Props, int? SID, int? TID, int? CID, int? CyId, int? DID, int? Price, int? Area, int? STID, int? PID, int? CUID)
        {

            if (SID != null && SID > 0)
            {
                Props = Props.Where(p => p.SaleTypeId == SID);
                ViewBag.SID = SID;
            }
            if (TID != null && TID > 0)
            {
                Props = Props.Where(p => p.RealEstateTypeID == TID);
                ViewBag.TID = TID;
            }
            if (CID != null && CID > 0)
            {
                Props = Props.Where(p => p.CountryID == CID);
                ViewBag.CID = CID;
            }
            if (CyId != null && CyId > 0)
            {
                Props = Props.Where(p => p.CityID == CyId);
                ViewBag.CyId = CyId;
            }
            if (DID != null && DID > 0)
            {
                Props = Props.Where(p => p.DistrictID == DID);
                ViewBag.DID = DID;
            }
            if (PID != null && PID > 0)
            {
                Props = Props.Where(p => p.PaymentTypeID == PID);
                ViewBag.PID = PID;
            }
            if (CUID != null && CUID > 0)
            {
                Props = Props.Where(p => p.CurrencyID == CUID);
                ViewBag.CUID = CUID;
            }
            if (STID != null && STID > 0)
            {
                Props = Props.Where(p => p.RealEstateStatusID == STID);
                ViewBag.STID = STID;
            }
            if (Price != null && Price > 0)
            {
                Props = Props.Where(p => p.Price <= Price);
                ViewBag.Price = Price;
            }
            if (Area != null && Area > 0)
            {
                Props = Props.Where(p => p.Area <= Area);
                ViewBag.Area = Area;
            }

            return Props;
        }
        private IQueryable<RealEstateProject> GetProjectSearchResult(IQueryable<RealEstateProject> Props, int? CID, int? CyId, int? DID)
        {
            if (CID != null && CID > 0)
            {
                Props = Props.Where(p => p.CountryID == CID);
                ViewBag.CID = CID;
            }
            if (CyId != null && CyId > 0)
            {
                Props = Props.Where(p => p.CityID == CyId);
                ViewBag.CyId = CyId;
            }
            if (DID != null && DID > 0)
            {
                Props = Props.Where(p => p.DistrictID == DID);
                ViewBag.DID = DID;
            }

            return Props;
        }

        [OutputCache(CacheProfile = "Rare")]
        public ActionResult NotifyService()
        {
            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name");
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetTypes(), "ID", "Title");
            ViewBag.SaleTypeID = new SelectList(Commons.GetSaleTypeList(), "Value", "Text");
            ViewBag.Price = new SelectList(Commons.GetPriceList(), "Value", "Text");
            ViewBag.Area = new SelectList(Commons.GetAreaList(), "Value", "Text");

            ViewBag.CityId = new SelectList(new List<City>(), "ID", "Name");
            ViewBag.DistrictID = new SelectList(new List<District>(), "ID", "Name");
            return PartialView("Partial/NotifyService");
        }
        [HttpPost]
        public ActionResult NotifyService(NotifyService notify)
        {
            if (ModelState.IsValid)
            {
                notify.Date = DateTime.Now;
                Repository.AddNotifyService(notify);
                Repository.Save();
                notify.City = Repository.GetCity(notify.CityID);
                notify.Country = Repository.GetCountry(notify.CountryID);
                notify.District = Repository.GetDistrict(notify.DistrictID);
                notify.RealEstateType = Repository.GetType(notify.RealEstateTypeID);
                notify.SaleType = Repository.GetSaletype(notify.SaleTypeID);
                new MailController().NotifyService(notify).Deliver();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            ViewBag.CountryID = new SelectList(Repository.GetCountries(), "ID", "Name", notify.CountryID);
            ViewBag.RealEstateTypeID = new SelectList(Repository.GetTypes(), "ID", "Title", notify.RealEstateTypeID);
            ViewBag.SaleTypeID = new SelectList(Commons.GetSaleTypeList(), "Value", "Text", notify.SaleTypeID);
            ViewBag.Price = new SelectList(Commons.GetPriceList(), "Value", "Text", notify.Price);
            ViewBag.Area = new SelectList(Commons.GetAreaList(), "Value", "Text", notify.Area);
            if (notify.CityID > 0)
            {
                ViewBag.CityId = new SelectList(Repository.GetCities(notify.CountryID), "ID", "Name", notify.CityID);
            }
            else
            {
                ViewBag.CityId = new SelectList(new List<City>(), "ID", "Name");
            }
            if (notify.DistrictID > 0)
            {
                ViewBag.DistrictID = new SelectList(Repository.GetDistricts(notify.DistrictID), "ID", "Name", notify.DistrictID);
            }
            else
            {
                ViewBag.DistrictID = new SelectList(new List<District>(), "ID", "Name");
            }
            return PartialView("Partial/NotifyService", notify);
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult FooterKeywords()
        {
            List<SearchKeyword> view = Repository.GetMainKeywords();
            return PartialView("Partial/FooterKeyWords", view);
        }
        public ActionResult SendComplain(int? ID)
        {
            var Complain = new RealEstateComplain();

            Complain.RealEstateID = ID;
            return PartialView("Partial/Complain");
        }
        [HttpPost]
        public ActionResult SendComplain(RealEstateComplain Complain)
        {
            if (ModelState.IsValid)
            {
                Complain.CreatedDate = DateTime.Now;
                Complain.IsRead = false;
                Repository.AddComplain(Complain);
                Repository.Save();
                //  new MailController().ComplainEmail(Complain).Deliver();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            return PartialView("Partial/Complain", Complain);
        }
        public ActionResult SendRequest(int? ID)
        {
            var Complain = new RealEstatePurchaseRequest();

            Complain.RealEstateID = ID;
            return PartialView("Partial/Request");
        }
        [HttpPost]
        public ActionResult SendRequest(RealEstatePurchaseRequest Request)
        {
            if (ModelState.IsValid)
            {
                Request.Date = DateTime.Now;
                Request.IsRead = false;
                Request.IsDeleted = false;
                Request.IsInquiry = false;

                var realestate = Repository.GetProperty(Request.RealEstateID);

                //var notification = new SubscriberNotification();
                //notification.CreatedDate = DateTime.Now;
                //notification.IsRead = false;
                //notification.ObjectID = realestate.ID;
                //notification.ObjectName = realestate.Title;
                //notification.ObjectTypeID = (int)Modules.RealEstates;
                //notification.SubscriberID = realestate.SubscriberID;
                //notification.Title = "تم ارسال طلب شراء جديد للعقار :" + realestate.Title;
                //notification.Title = "تم ارسال طلب شراء جديد للعقار :" + realestate.Title;

                Repository.AddRequest(Request);
                // Repository.AddNotification(notification);
                Repository.Save();
                new MailController().RequestEmail(Request, realestate).Deliver();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            return PartialView("Partial/Request", Request);
        }
        [HttpPost]
        public ActionResult SendCompanyMessage(CompanyMessage CompanyMessage)
        {
            if (ModelState.IsValid)
            {
                CompanyMessage.CreatedDate = DateTime.Now;
                CompanyMessage.IsRead = false;
                CompanyMessage.IsDeleted = false;
                // Message.IsInquiry = false;
                RealEstateCompany Company = Repository.GetCompany(CompanyMessage.CompanyID);
                RealEstateProject Project;
                if (CompanyMessage.ProjectID > 0 && CompanyMessage.ProjectID != null)
                {
                    Project = Repository.GetProject(CompanyMessage.ProjectID);
                }
                else
                {
                    Project = null;
                }
                Repository.AddCompanyMessage(CompanyMessage);
                Repository.Save();
                new MailController().CompanyMessageEmail(CompanyMessage, Company.Email, Project).Deliver();
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            return PartialView("Partial/CompanyMessage", CompanyMessage);
        }
        [OutputCache(CacheProfile = "Sometime", VaryByParam = "type", Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult CompareList(string type)
        {
            if (type == "List")
            {
                return View("CompareList", Commons.CompareList);
            }
            else
            {
                return PartialView("Partial/ComparisonMenu", Commons.CompareList);
            }
        }
        public ActionResult AddToCompareList(int? ID)
        {
            if (Commons.CompareList.Count < 4)
            {
                if (Commons.CompareList.FindIndex(P => P.ID == ID) < 0)
                {
                    var r = Repository.GetProperty(ID);

                    Commons.CompareList.Add(r);
                }
                return PartialView("Partial/ComparisonMenu", Commons.CompareList);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Conflict;
                return View();
            }
        }
        public ActionResult RemoveFromCompareList(int? ID)
        {
            if (Commons.CompareList.Count > 0)
            {
                Commons.CompareList.Remove(Commons.CompareList.Find(r => r.ID == ID));
                return PartialView("Partial/ComparisonMenu", Commons.CompareList);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Conflict;
                return View();
            }
        }
        public ActionResult AddToFavorite(int? ID)
        {
            string status = "";
            if (HttpContext.User.Identity.IsAuthenticated && Security.IsUserInRole(Roles.Subscriber))
            {
                var sub = Repository.GetSubscriber(Commons.UserName);
                SubscriberFavouriteRealEstate Fav = new SubscriberFavouriteRealEstate();
                Fav.RealEstateID = ID;
                Fav.SubScriberID = sub.ID;
                Repository.AddFavorite(Fav);
                Repository.Save();
                status = "Success";
            }
            else
            {
                status = "Error";
            }
            return Json(new
            {
                Response = new
                {
                    status = status
                }
            }, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "CountryID")]
        public ActionResult GetCities(int? CountryID)
        {
            var Cities = Repository.GetCities(CountryID);
            return Json(Cities.Select(c => new
            {
                Id = c.ID,
                Name = Commons.Culture.Contains("ar") ? c.Name : c.EnName,
            }), JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "MsgType")]
        public ActionResult GetMessage(string MsgType)
        {
            string title = "", content = "";
            switch (MsgType)
            {
                case "SendSuccess":
                    content = Messages.SendSuccessfully;
                    title = Messages.ThanksTitleMsg;
                    break;
                case "SendFailed":
                    content = Messages.ErrorMsg;
                    title = Messages.ErrorTitleMsg;
                    break;
                case "AddingCompareProp":
                    content = Messages.AddingCompareFailed;
                    title = Messages.ErrorTitleMsg;
                    break;
                case "RemocingCompareProp":
                    content = Messages.ErrorMsg;
                    title = Messages.ErrorTitleMsg;
                    break;
                case "AddingFavorite":
                    content = Messages.FavoritePropMsg;
                    title = Messages.ThanksTitleMsg;
                    break;
                case "AddingFavoriteError":
                    content = Messages.FavoritePropErrorMsg;
                    title = Messages.ErrorTitleMsg;
                    break;
                case "SendAccount":
                    content = Messages.GeneratePasswordMsg;
                    title = Messages.ThanksTitleMsg;
                    break;
                default:
                    break;
            }
            return Json(new
            {
                Msg = new
                {
                    Title = title,
                    Content = content,
                }
            }, JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "CityId")]
        public ActionResult GetDistricts(int? CityId)
        {
            var Cities = Repository.GetDistricts(CityId);
            return Json(Cities.Select(c => new
            {
                Id = c.ID,
                Name = Commons.Culture.Contains("ar") ? c.Name : c.EnName,
            }), JsonRequestBehavior.AllowGet);
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "TypeId")]
        public ActionResult GetStatus(int? TypeId)
        {
            var Cities = Repository.GetStatus(TypeId);
            return Json(Cities.Select(c => new
            {
                Id = c.ID,
                Name = Commons.Culture.Contains("ar") ? c.Title : c.EnTitle,
            }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPropertyOwner(int? ID)
        {
            var view = Repository.GetProperty(ID);
            return PartialView("Partial/PropertyOwnerdata", view);
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult PropertyLogin()
        {
            return PartialView("Partial/LoginForm");
        }
        [HttpPost]
        public ActionResult PropertyLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ValidationResult result = Security.ValidateUser(model.Email, model.Password);
                if (!result.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    this.AddNotification(result.Message, NotificationType.ERROR);
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }
            return PartialView("Partial/LoginForm", model);
        }
        [OutputCache(CacheProfile = "Rare", VaryByParam = "realestateID;ProjectID;CompanyID;Type")]
        public ActionResult PropertyRegister(int? realestateID, int? ProjectID, int? CompanyID, string Type)
        {
            RegisterInquiry inqury = new RegisterInquiry();
            if (Type == InquiryType.PurchaseRequest.ToString())
            {
                inqury.RealestateID = realestateID;
                inqury.type = InquiryType.PurchaseRequest;
            }
            if (Type == InquiryType.CompanyMessage.ToString())
            {
                inqury.CompanyID = CompanyID;
                inqury.type = InquiryType.CompanyMessage;
                if (ProjectID != null)
                {
                    inqury.ProjectID = ProjectID;
                }
            }
            inqury.Subscriber = new Subscriber();
            return PartialView("Partial/RegisterForm");
        }
        [HttpPost]
        public ActionResult PropertyRegister(RegisterInquiry inquery)
        {
            bool isValid = true;
            if (ModelState.IsValid)
            {
                ValidationResult result = Security.CheckUserExist(inquery.Subscriber);
                if (result.IsValid == false)
                {
                    this.AddNotification(result.Message, NotificationType.ERROR);
                    isValid = false;
                }
                if (isValid)
                {
                    inquery.Subscriber.IsCompanyAdmin = false;
                    inquery.Subscriber.CreatedDate = DateTime.Now;
                    inquery.Subscriber.ActiveStatusID = (int)ActiveStatus.Pending;
                    inquery.Subscriber.ActivationCode = Commons.CreateActivationCode();
                    inquery.Subscriber.Password = new Password();
                    inquery.Subscriber.Password.password = inquery.Subscriber.ActivationCode;
                    Repository.AddSubscriber(inquery.Subscriber);
                    Repository.Save();

                    Security.CreateUser(inquery.Subscriber);
                    Security.AddUserToRole(inquery.Subscriber.UserName, Roles.Subscriber);

                    Commons.SendSMS(inquery.Subscriber.MobileNo, inquery.Subscriber.ActivationCode, SMSMessages.ForgetPassword);
                    new MailController().GeneratePassword(inquery.Subscriber).Deliver();

                    if (inquery.type == InquiryType.PurchaseRequest)
                    {
                        RealEstatePurchaseRequest Request = new RealEstatePurchaseRequest();
                        Request.Date = DateTime.Now;
                        Request.IsDeleted = false;
                        Request.IsRead = false;
                        Request.IsInquiry = true;
                        Request.PurchaserEmail = inquery.Subscriber.Email;
                        Request.PurchaserName = inquery.Subscriber.FullName;
                        Request.PurchaserPhone = inquery.Subscriber.MobileNo;
                        Request.RealEstateID = inquery.RealestateID;
                        Repository.AddRequest(Request);
                        Repository.Save();
                    }
                    if (inquery.type == InquiryType.CompanyMessage)
                    {
                        CompanyMessage companyMessage = new CompanyMessage();
                        companyMessage.CreatedDate = DateTime.Now;
                        companyMessage.IsDeleted = false;
                        companyMessage.IsInquiry = true;
                        companyMessage.IsRead = false;
                        companyMessage.Name = inquery.Subscriber.FullName;
                        companyMessage.Phone = inquery.Subscriber.MobileNo;
                        companyMessage.Email = inquery.Subscriber.Email;
                        companyMessage.CompanyID = inquery.CompanyID;
                        companyMessage.ProjectID = inquery.ProjectID;
                        Repository.AddCompanyMessage(companyMessage);
                        Repository.Save();
                    }
                    this.AddNotification(Messages.GeneratePasswordMsg, NotificationType.SUCCESS);
                    //   return PartialView("Partial/LoginForm");
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                }
                //  new MailController().ActivateAccount(user);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
            }

            return PartialView("Partial/RegisterForm", inquery);
        }
        //public ActionResult ActivateUser(int? SubscriberId,int? realestateID, string Code)
        //{
        //    if (!String.IsNullOrEmpty(Code))
        //    {
        //        Subscriber subscriber =Repository.GetSubscriber(SubscriberId);
        //        if (subscriber.ActivationCode == Code)
        //        {
        //            subscriber.ActivationCode = null;
        //            subscriber.ActiveStatusID = (int)ActiveStatus.Active;
        //            Repository.Save();
        //            Security.ValidateUser();
        //        }
        //        else
        //        {
        //            Response.StatusCode = (int)HttpStatusCode.Created;
        //            this.AddNotification(Messages.CodeNotMatch, NotificationType.ERROR);
        //        }
        //    }
        //    ViewBag.ID = SubscriberId;
        //    return PartialView("Partial/ActivateAccount");
        //}
        //public ActionResult Resend(int? SubscriberId)
        //{
        //    Subscriber subscriber = Repository.GetSubscriber(SubscriberId);
        //    subscriber.ActivationCode = Commons.CreateActivationCode();
        //    Repository.Save();
        //    //Dictionary<string, string> Code = new Dictionary<string, string>();
        //    //Code.Add("Code", subscriber.ActivationCode);
        //    //Commons.SendEmail(EmailType.GeneratePassword, subscriber.Email, Code);
        //    new MailController().GeneratePassword(subscriber).Deliver();
        //    Commons.SendSMS(subscriber.MobileNo, subscriber.ActivationCode, SMSMessages.TempPassword);
        //    this.AddNotification(Messages.CodeSentSuccessfuly, NotificationType.SUCCESS);
        //    ViewBag.SubscriberId = 19713;
        //    return PartialView("Partial/ActivateAccount");
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Contactus()
        {
            return PartialView("Partial/Contactus");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contactus(Contactus contact)
        {
            new MailController().Contactus(contact).Deliver();

            return Redirect(Request.UrlReferrer.ToString());
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult TechnicalSupport()
        {
            var view = Repository.GetContent(Pages.TechnicalSupport);
            //  ViewBag.Message = "Your contact page.";

            return View(view);
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult SupscriptionTypes()
        {
            StaticContactPage page = new StaticContactPage();

            StaticPage staticcontent = Repository.GetContent(Pages.SupscriptionTypes);
            page.PageType = Pages.SupscriptionTypes;
            page.Title = General.SupscriptionTypes;
            page.Content = Commons.Culture.Contains("ar") ? staticcontent.Content : staticcontent.EngContent;
            //  ViewBag.Message = "Your contact page.";

            return View("StaticContactPage", page);
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult MarketingServices()
        {
            StaticContactPage page = new StaticContactPage();

            StaticPage staticcontent = Repository.GetContent(Pages.Services);
            page.PageType = Pages.Services;
            page.Title = General.MarketingServices;
            page.Content = Commons.Culture.Contains("ar") ? staticcontent.Content : staticcontent.EngContent;
            //  ViewBag.Message = "Your contact page.";

            return View("StaticContactPage", page);
        }
        [OutputCache(CacheProfile = "Rare")]
        public ActionResult Register()
        {
            Subscriber sub = new Subscriber();
            sub.Password = new Password();
            sub.IsCompanyAdmin = true;
            return View(sub);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Subscriber user)
        {
            bool isValid = true;
            if (ModelState.IsValid)
            {
                ValidationResult result = Security.CheckUserExist(user);
                if (result.IsValid == false)
                {
                    this.AddNotification(result.Message, NotificationType.ERROR);
                    isValid = false;
                }
                result = Security.MatchPassword(user);
                if (result.IsValid == false)
                {
                    this.AddNotification(result.Message, NotificationType.ERROR);
                    isValid = false;
                }
                if (isValid)
                {

                    user.CreatedDate = DateTime.Now;
                    user.ActiveStatusID = (int)ActiveStatus.Pending;
                    user.ActivationCode = Commons.CreateActivationCode();
                    Repository.AddSubscriber(user);
                    Repository.Save();
                    Security.CreateUser(user);
                    Security.AddUserToRole(user.UserName, Roles.Subscriber);
                    if (user.IsCompanyAdmin == true)
                    {
                        Security.AddUserToRole(user.UserName, Roles.CompanyAdmin);
                    }
                    try
                    {
                        new MailController().ActivateAccount(user).Deliver();
                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        Commons.SendSMS(user.MobileNo, user.ActivationCode, SMSMessages.ActivateCode);
                    }
                    catch (Exception ex)
                    {
                    }
                    return RedirectToAction("Pending", "Activation", new { id = user.ID });
                }
                //  new MailController().ActivateAccount(user);
            }

            return View(user);
        }
        public ActionResult SearchKeywords(string Query)
        {
            var parm = Query.Split('/');
            return RedirectToAction("SearchResult", new
            {
                Page = Convert.ToInt32(parm[0]),
                SID = Convert.ToInt32(parm[1]),
                TID = Convert.ToInt32(parm[2]),
                CID = Convert.ToInt32(parm[3]),
                CyId = Convert.ToInt32(parm[4]),
                DID = Convert.ToInt32(parm[5]),
                Price = Convert.ToInt32(parm[6]),
                Area = Convert.ToInt32(parm[7]),
                STID = Convert.ToInt32(parm[8]),
                PID = Convert.ToInt32(parm[9]),
                CUId = Convert.ToInt32(parm[10])
            });
            //view.Name = General.SearchResult;
            //view.ReqularProperties = Props.OrderByDescending(p => p.ChangeActiveStatus).ToPagedList(pageNumber, 6); ;
            //view.SpecailProperties = SpecialProps.OrderBy(p => Guid.NewGuid()).Take(2).ToList(); ;
            // return View("SearchResult", view);
        }
        public ActionResult NotFound()
        {
            return View("_NotFound");
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.Result = new PartialViewResult
            {
                ViewName = "_Notifications"
            };
        }
    }
}