using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrokerMVC.Code.Repositories
{
    public class HomeRepository : GeneralRepository
    {
        private RealEstateBrokerEntities _db;
        private IQueryable<RealEstate> _properties;

        public HomeRepository(RealEstateBrokerEntities Context) : base(Context)
        {
            _db = Context;
            var todayDate = DateTime.Now;
            var dateLastMonthsOfLastYear = DateTime.Now.AddMonths(-3);
            _properties = from prop in _db.RealEstates
                          where prop.CreatedDate.Value.Year == todayDate.Year || prop.CreatedDate.Value >= dateLastMonthsOfLastYear
                          select prop;
        }

        public RealEstateProject GetBannerProject()
        {
            return _db.RealEstateProjects.Where(p => p.AdPackageID == (int)AdPackage.Banner).OrderBy(p => Guid.NewGuid()).First();
        }

        public List<RealEstateProject> GetHomeProject()
        {
            return _db.RealEstateProjects.Where(p => p.AdPackageID == (int)AdPackage.HomePage).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
        }

        public IQueryable<RealEstate> GetProperties()
        {
            return _properties.Where(p => p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetPropertiesBySaleType(int? saleTypeId)
        {
            return _properties.Where(p => p.SaleTypeId == saleTypeId && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetPropertiesByCategory(int? categoryId)
        {
            return _properties.Where(p => p.RealEstateCategoryID == categoryId && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetPropertiesByType(int? typeId)
        {
            return _properties.Where(p => p.RealEstateTypeID == typeId && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetPropertiesByProject(int? projectId)
        {
            return _properties.Where(p => p.ProjectID == projectId && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetPropertiesByCompany(int? companyId)
        {
            return _properties.Where(p => p.Subscriber.CompanyID == companyId && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public IQueryable<RealEstate> GetSpecailProperties()
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
        }

        public int CountSpecailProperties()
        {
            var count = _properties.Count(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false);
            return count;
        }

        public IQueryable<RealEstate> GetSpecailProperties(int categoryId)
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false
            && p.RealEstateCategoryID == categoryId);
        }

        public IQueryable<RealEstate> GetSpecailPropertiesBySaleType(int saleType)
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false
            && p.SaleTypeId == saleType);
        }

        public IQueryable<RealEstate> GetSpecailPropertiesByType(int typeId)
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.IsSold == false
            && p.RealEstateTypeID == typeId);
        }

        public IQueryable<RealEstate> GetSpecailPropertiesByProject(int? projectId)
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active
            && p.ProjectID == projectId);
        }

        public IQueryable<RealEstate> GetSpecailPropertiesByCompany(int? companyId)
        {
            return _properties.Where(p => p.IsSpecialOffer == true && p.ActiveStatusId == (int)ActiveStatus.Active && p.Subscriber.CompanyID == companyId);
        }

        public IQueryable<RealEstateProject> GetSpecailProjects()
        {
            var projects = from prop in _db.RealEstateProjects select prop;
            projects = projects.Where(p => (p.AdPackageID == (int)AdPackage.HomePage || p.AdPackageID == (int)AdPackage.Banner) && p.ActiveStatusID == (int)ActiveStatus.Active);
            return projects;
        }

        public IQueryable<RealEstateProject> GetSpecailProjects(int? companyId)
        {
            var projects = from prop in _db.RealEstateProjects select prop;
            projects = projects.Where(p => p.CompanyID == companyId && (p.AdPackageID == (int)AdPackage.HomePage || p.AdPackageID == (int)AdPackage.Banner) && p.ActiveStatusID == (int)ActiveStatus.Active);
            return projects;
        }

        public IQueryable<RealEstateCompany> GetSpecialCompanies()
        {
            var companies = from prop in _db.RealEstateCompanies select prop;
            companies = companies.Where(p => p.IsSpecial == true && p.ActivateStatusID == (int)ActiveStatus.Active);
            return companies;
        }

        public IQueryable<RealEstateCompany> GetCompanies()
        {
            var companies = from prop in _db.RealEstateCompanies select prop;
            companies = companies.Where(p => p.ActivateStatusID == (int)ActiveStatus.Active);
            return companies;
        }

        public IQueryable<RealEstateProject> GetProjects()
        {
            var projects = from prop in _db.RealEstateProjects select prop;
            projects = projects.Where(p => p.ActiveStatusID == (int)ActiveStatus.Active);
            return projects;
        }

        public IQueryable<RealEstateProject> GetCompanyProjects(int? companyId)
        {
            var projects = from prop in _db.RealEstateProjects select prop;
            projects = projects.Where(p => p.CompanyID == companyId && p.ActiveStatusID == (int)ActiveStatus.Active);
            return projects;
        }

        public List<SearchKeyword> GetMainKeywords()
        {
            return _db.SearchKeywords.Where(k => k.ParentID == null).OrderBy(k => k.Keywords).ToList();
        }

        public RealEstate GetProperty(int? id)
        {
            return _db.RealEstates.Find(id);
        }

        public RealEstateProject GetProject(int? id)
        {
            return _db.RealEstateProjects.Find(id);
        }

        public RealEstateProjectModel GetModel(int? id)
        {
            return _db.RealEstateProjectModels.Find(id);
        }

        public RealEstateCompany GetCompany(int? id)
        {
            return _db.RealEstateCompanies.Find(id);
        }

        public Catalog GetCatlog(int? ID)
        {
            return _db.Catalogs.Find(ID);
        }

        public List<RealEstate> GetCatalogProperties(int? id)
        {
            var catalog = _db.Catalogs.Find(id);
            var realestate = from prop in _db.RealEstates select prop;
            realestate = realestate.Where(r => r.IsSold == false && r.ActiveStatusId == (int)ActiveStatus.Active);
            realestate = realestate.Where(r => r.DistrictID == catalog.DistrictId && r.RealEstateTypeID == catalog.TypeID);
            return realestate.OrderByDescending(r => r.ChangeActiveStatus).Take(10).ToList();
        }

        public RealEstateCatalog GetOldCatalog(int? Id)
        {
            return _db.RealEstateCatalogs.Find(Id);
        }

        public Advertisement GetAd()
        {
            return _db.Advertisements.OrderBy(a => Guid.NewGuid()).First();
        }

        public IQueryable<RealEstateProjectModel> GetProjectModels(int? projectId)
        {
            var projectModels = from prop in _db.RealEstateProjectModels select prop;
            projectModels = projectModels.Where(p => p.ProjectID == projectId);
            return projectModels;
        }

        internal StaticPage GetContent(Pages page)
        {
            return _db.StaticPages.FirstOrDefault(p => p.ID == (int)page);
        }

        public void AddNotifyService(NotifyService notify)
        {
            _db.NotifyServices.Add(notify);
        }

        public void AddComplain(RealEstateComplain complain)
        {
            _db.RealEstateComplains.Add(complain);
        }

        public void AddRequest(RealEstatePurchaseRequest complain)
        {
            _db.RealEstatePurchaseRequests.Add(complain);
        }

        public void AddCompanyMessage(CompanyMessage complain)
        {
            _db.CompanyMessages.Add(complain);
        }

        public void AddSubscriber(Subscriber sub)
        {
            _db.Subscribers.Add(sub);
        }

        internal void AddFavorite(SubscriberFavouriteRealEstate fav)
        {
            _db.SubscriberFavouriteRealEstates.Add(fav);
        }
    }
}