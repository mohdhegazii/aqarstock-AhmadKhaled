using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.Repositories
{
    public class ProjectRepository:GeneralRepository
    {
        RealEstateBrokerEntities db;
        RealEstateRepository RealEstateRep;
        public ProjectRepository(RealEstateBrokerEntities Context):base(Context)
        {
            db = Context;
            RealEstateRep = new RealEstateRepository(db);
        }
        public IPagedList<RealEstateProject> GetAll(int? CompanyID,string searchString, string sortOrder, int pageNumber, int pageSize)
        {
            var realEstateProjects = from C in db.RealEstateProjects select C;
            if (CompanyID != null)
            {
                realEstateProjects = realEstateProjects.Where(p => p.CompanyID == CompanyID);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                realEstateProjects = realEstateProjects.Where(s => s.Title.Contains(searchString)
                                       || s.EnTitle.Contains(searchString));
            }
        
            realEstateProjects = SortList(realEstateProjects, sortOrder);
            return realEstateProjects.ToPagedList(pageNumber, pageSize);

        }
        public IPagedList<RealEstateProject> GetAllBySubscriber( int? SubscriberID, string searchString, string sortOrder, int pageNumber, int pageSize)
        {
            var realEstateProjects = from C in db.RealEstateProjects select C;
            if (SubscriberID != null)
            {
                realEstateProjects = realEstateProjects.Where(p => p.SubscriberID == SubscriberID);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                realEstateProjects = realEstateProjects.Where(s => s.Title.Contains(searchString)
                                       || s.EnTitle.Contains(searchString));
            }

            realEstateProjects = SortList(realEstateProjects, sortOrder);
            return realEstateProjects.ToPagedList(pageNumber, pageSize);

        }
        public IEnumerable<RealEstateProject> GetCompanyProjects(int? CompanyID,int?pagesize)
        {
            var projects= db.RealEstateProjects.Where(s => s.CompanyID == CompanyID).OrderByDescending(p => p.CreatedDate);
            if(pagesize==null)
            {
                return projects;
            }
            else
            {
                return projects.Take(pagesize.Value);
            }
        }
        public RealEstateProject GetByProjectID(int? ID)
        {
            return db.RealEstateProjects.Find(ID);
        }
        public AddressData GetProjectAddress(int? ID)
        {
            RealEstateProject realEstateCompany = GetByProjectID(ID);
            AddressData address = new AddressData();
            address.ID = realEstateCompany.ID;
            address.Name = realEstateCompany.Title;
            address.Logo = realEstateCompany.Logo;
            address.CityID = realEstateCompany.CityID;
            address.CountryID = realEstateCompany.CountryID;
            address.DistrictID = realEstateCompany.DistrictID;
            address.Latitude = realEstateCompany.Latitude;
            address.Longitude = realEstateCompany.Longitude;
            return address;
        }
  
        public IEnumerable<RealEstateProjectVideo> GetProjectVideos(int? ID)
        {
            return db.RealEstateProjectVideos.Where(v => v.ProjectID == ID);
        }
        public IEnumerable<RealEstateProjectModel> GetProjectModels(int? ID)
        {
            return db.RealEstateProjectModels.Where(v => v.ProjectID == ID);
        }
        public IEnumerable<RealEstate> GetProjectRealestates(int? ID)
        {   
            return RealEstateRep.GetAllByProject(ID);
        }
        public IEnumerable<RealEstate> GetCompanyIndividualRealEstates(RealEstateProject Project)
        {
            return RealEstateRep.GetCompanyIndividualRealEstates(Project.CompanyID, Project.ID);
        }
        public void Add(RealEstateProject realEstateProject)
        {
            db.RealEstateProjects.Add(realEstateProject);
        }
        
        public void AddToProject(int ProjectID,int realestateID)
        {
            RealEstate realestate = RealEstateRep.GetByRealestateID(realestateID);
            realestate.ProjectID = ProjectID;
            RealEstateRep.Update(realestate);
        }
        public void Update(RealEstateProject realEstateProject)
        {
            db.Entry(realEstateProject).State = EntityState.Modified;
        }
        public void UpdateCompanyProjectNo(int companyId,int number)
        {
            CompanyRepository  CompRep= new CompanyRepository(db);
            CompRep.UpdateProjectCurrentNo(companyId, number);
        }
        public int RemoveRealestate(int? RealEstateId)
        {
           return RealEstateRep.RemoveFromProject(RealEstateId);
        }
        public void Delete(int id)
        {
            RealEstateProject realEstateProject = GetByProjectID(id);
            DeletePhotosFiles(realEstateProject);
            DeleteProjectRelatedData(realEstateProject);
            RemoveProjectFromCompany(realEstateProject);

            RemoveLog(realEstateProject.ID, (int)Modules.Projects);

            db.RealEstateProjects.Remove(realEstateProject);

        }

        private void RemoveProjectFromCompany(RealEstateProject realEstateProject)
        {
            CompanyRepository CompRep = new CompanyRepository(db);
            var Company = CompRep.GetCompanyByID(realEstateProject.CompanyID);
            Company.CurrentProjectNos -= 1;
            CompRep.Update(Company);
        }

        private void DeleteProjectRelatedData(RealEstateProject realEstateProject)
        {
            db.RealEstateProjectPhotos.RemoveRange(realEstateProject.RealEstateProjectPhotos);
            db.RealEstateProjectModels.RemoveRange(realEstateProject.RealEstateProjectModels);
            db.RealEstateProjectVideos.RemoveRange(realEstateProject.RealEstateProjectVideos);
            db.CompanyMessages.RemoveRange(realEstateProject.CompanyMessages);
            List<RealEstate> realestates = realEstateProject.RealEstates.ToList();
            realestates.ForEach(r => RealEstateRep.RemoveFromProject(r.ID));
        }

        private static void DeletePhotosFiles(RealEstateProject realEstateProject)
        {
            if (realEstateProject.RealEstateProjectPhotos.Count > 0)
            {
                realEstateProject.RealEstateProjectPhotos.ToList().ForEach(p => DirectoryManager.RemoveFile(p.PhotoURL));
            }
            if (realEstateProject.RealEstateProjectModels.Count > 0)
            {
                realEstateProject.RealEstateProjectModels.ToList().ForEach(p => DirectoryManager.RemoveFile(p.PlanImgURL));
            }
            DirectoryManager.RemoveFile(realEstateProject.Logo);
        }

        private IQueryable<RealEstateProject> SortList(IQueryable<RealEstateProject> realEstateProjects,string sortOrder)
        {
            switch (sortOrder)
            {

                case "name_desc":
                    realEstateProjects = realEstateProjects.OrderByDescending(c => c.Title);
                    break;
                case "EnName":
                    realEstateProjects = realEstateProjects.OrderBy(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "EnName_desc":
                    realEstateProjects = realEstateProjects.OrderByDescending(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "Company":
                    realEstateProjects = realEstateProjects.OrderBy(c => c.RealEstateCompany.Title).ThenBy(c => c.Title);
                    break;
                case "Company_desc":
                    realEstateProjects = realEstateProjects.OrderByDescending(c => c.RealEstateCompany.Title).ThenBy(c => c.Title);
                    break;
                case "Special":
                    realEstateProjects = realEstateProjects.OrderBy(c => c.AdPackageID).ThenBy(c => c.Title);
                    break;
                case "Special_desc":
                    realEstateProjects = realEstateProjects.OrderByDescending(c => c.AdPackageID).ThenBy(c => c.Title);
                    break;
                default:
                    realEstateProjects = realEstateProjects.OrderByDescending(c => c.CreatedDate);
                    break;
            }
            return realEstateProjects;
        }
    }
}