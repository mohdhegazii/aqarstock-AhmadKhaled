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
    public class CompanyRepository: GeneralRepository
    {
        RealEstateBrokerEntities db;
        UserRepository UserRep;
        ProjectRepository ProjRep;
        public CompanyRepository(RealEstateBrokerEntities Context):base(Context)
        {
            db = Context;
            UserRep = new UserRepository(Context);
            ProjRep = new ProjectRepository(Context);
        }
        public void Add(RealEstateCompany realEstateCompany)
        {
            db.RealEstateCompanies.Add(realEstateCompany);
            Commons.Log(Modules.Companies, subscriberActions.AddNew, realEstateCompany.ID, realEstateCompany.Title);
        }
        public void Add(RealEstateCompany realEstateCompany, Subscriber sub)
        {
            db.RealEstateCompanies.Add(realEstateCompany);
            sub.CompanyID = realEstateCompany.ID;
            sub.IsCompanyAdmin = true;
           
        }
        public IEnumerable<RealEstateCompany> GetAll()
        {
            return db.RealEstateCompanies.OrderBy(c => c.Title);
        }
        public IPagedList<RealEstateCompany> GetAll(string searchString,string sortOrder, int pageNumber, int pageSize)
        {
            var realEstateCompanies = from C in db.RealEstateCompanies select C;
            if (!String.IsNullOrEmpty(searchString))
            {
                realEstateCompanies = realEstateCompanies.Where(s => s.Title.Contains(searchString)
                                       || s.EnTitle.Contains(searchString));
            }
            switch (sortOrder)
            {

                case "name_desc":
                    realEstateCompanies = realEstateCompanies.OrderByDescending(c => c.Title);
                    break;
                case "EnName":
                    realEstateCompanies = realEstateCompanies.OrderBy(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "EnName_desc":
                    realEstateCompanies = realEstateCompanies.OrderByDescending(c => c.EnTitle).ThenBy(c => c.Title);
                    break;
                case "Special":
                    realEstateCompanies = realEstateCompanies.OrderByDescending(c => c.IsSpecial).ThenBy(c => c.Title);
                    break;
                default:
                    realEstateCompanies = realEstateCompanies.OrderBy(c => c.Title);
                    break;
            }
            return realEstateCompanies.ToPagedList(pageNumber, pageSize);
        }
        public RealEstateCompany GetCompanyByID(int? id)
        {
            return db.RealEstateCompanies.Find(id);
        }
        public BasicData GetCompanyBasicDataByID(int? id)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            BasicData basic = new BasicData();
            basic.ID = realEstateCompany.ID;
            basic.Name = realEstateCompany.Title;
            basic.EnName = realEstateCompany.EnTitle;
            basic.Description = realEstateCompany.Description;
            basic.EnDescription = realEstateCompany.EnDescription;
            basic.Summary = realEstateCompany.Summary;
            basic.EnSummary = realEstateCompany.EnSummary;
            basic.Phone = realEstateCompany.Phone;
            basic.Email = realEstateCompany.Email;
            basic.Logo = realEstateCompany.Logo;
            basic.Latitude = realEstateCompany.Latitude;
            basic.Longutide = realEstateCompany.Longutide;
            basic.IsSpecial = realEstateCompany.IsSpecial ?? false;
            if (realEstateCompany.Street != "" && realEstateCompany.Street != null)
            {
                basic.Address = realEstateCompany.Street + ", " + realEstateCompany.District.Name + " " + realEstateCompany.City.Name + " " + realEstateCompany.Country.Name;
            }
            else
            {
                basic.Address = realEstateCompany.District.Name + " " + realEstateCompany.City.Name + " " + realEstateCompany.Country.Name;
            }
            if (realEstateCompany.ActivateStatusID == (int)ActiveStatus.Suspended)
            {
                basic.SuspendData = new Suspend();
                basic.SuspendData.SuspendReason = realEstateCompany.SuspendReason.Title;
                basic.SuspendData.Message = realEstateCompany.SuspendMessage;
            }

            return basic;
        }
        public AddressData GetCompanyAddressDataByID(int? id)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            AddressData address = new AddressData();
            address.ID = realEstateCompany.ID;
            address.Name = realEstateCompany.Title;
            address.Logo = realEstateCompany.Logo;
            address.CityID = realEstateCompany.CityId;
            address.CountryID = realEstateCompany.CountryId;
            address.DistrictID = realEstateCompany.DistrictId;
            address.EnStreet = realEstateCompany.Entreet;
            address.Latitude = realEstateCompany.Latitude;
            address.Longitude = realEstateCompany.Longutide;
            address.Street = realEstateCompany.Street;
            return address;
        }
        public Statistics GetCompanyUserNos(int? id)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            Statistics s = new Statistics();
            s.ID = realEstateCompany.ID;
            s.CurrentNo = realEstateCompany.CurrentUserNos;
            s.TotalNo = realEstateCompany.UserNos;
            return s;
        }
        public Statistics GetCompanyProjectNos(int? id)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            Statistics s = new Statistics();
            s.ID = realEstateCompany.ID;
            s.CurrentNo = realEstateCompany.CurrentProjectNos;
            s.TotalNo = realEstateCompany.ProjectNos;
            return s;
        }
        public IEnumerable<Subscriber> GetCompanyEmployees(int? CompanyId)
        {
            return UserRep.GetAllByCompany(CompanyId);
        }
        public IEnumerable<RealEstateProject> GetCompanyProjects(int? CompanyId, int? pagesize)
        {
            return ProjRep.GetCompanyProjects(CompanyId,pagesize);
        }
        public void Update(RealEstateCompany realEstateCompany)
        {
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public RealEstateCompany Update(BasicData CompanyBasicData)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(CompanyBasicData.ID);
            realEstateCompany.Description = CompanyBasicData.Description;
            realEstateCompany.Email = CompanyBasicData.Email;
            realEstateCompany.EnDescription = CompanyBasicData.EnDescription;
            realEstateCompany.EnSummary = CompanyBasicData.EnSummary;
            realEstateCompany.EnTitle = CompanyBasicData.EnSummary;
            realEstateCompany.EnTitle = CompanyBasicData.EnName;
            realEstateCompany.Phone = CompanyBasicData.Phone;
            realEstateCompany.Summary = CompanyBasicData.Summary;
            realEstateCompany.Title = CompanyBasicData.Name;
       
            db.Entry(realEstateCompany).State = EntityState.Modified;
            return realEstateCompany;
        }
    
        public void Update(AddressData address)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(address.ID);
            realEstateCompany.CityId = address.CityID;
            realEstateCompany.CountryId = address.CountryID;
            realEstateCompany.DistrictId = address.DistrictID;
            realEstateCompany.Entreet = address.EnStreet;
            realEstateCompany.Latitude = address.Latitude;
            realEstateCompany.Longutide = address.Longitude;
            realEstateCompany.Street = address.Street;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void UpdateUserTotalNo(Statistics st)
        {
            RealEstateCompany realEstateCompany =GetCompanyByID(st.ID);
            realEstateCompany.UserNos = st.TotalNo;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void UpdateProjectTotalNo(Statistics st)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(st.ID);
            realEstateCompany.ProjectNos = st.TotalNo;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void UpdateProjectCurrentNo(int companyId,int number)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(companyId);
            realEstateCompany.CurrentProjectNos =number;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void ChangeStatus(int? id, int Status)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            realEstateCompany.ActivateStatusID = Status;
            realEstateCompany.StatusChangeDate = DateTime.Now;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void SetSpecial(int? id, bool status)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(id);
            realEstateCompany.IsSpecial = status;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void SuspendCompany(Suspend suspend)
        {
            RealEstateCompany realEstateCompany = GetCompanyByID(suspend.ID);
            realEstateCompany.ActivateStatusID = (int)ActiveStatus.Suspended;
            realEstateCompany.SuspendMessage = suspend.Message;
            realEstateCompany.SuspendReasonID = suspend.SuspendReasonID;
            realEstateCompany.StatusChangeDate = DateTime.Now;
            db.Entry(realEstateCompany).State = EntityState.Modified;
        }
        public void AddEmployee(Subscriber user)
        {
            RealEstateCompany company = GetCompanyByID(user.CompanyID);
            company.CurrentUserNos += 1;
            
           UserRep.Add(user);
        }
        public void RemoveEmployee(int? userID)
        {
            
            Subscriber user = UserRep.GetBySubscriberId(userID);
            RealEstateCompany company = GetCompanyByID(user.CompanyID);
            company.CurrentUserNos -= 1;
            user.CompanyID = null;
            if (user.IsCompanyAdmin == true)
            {
                user.IsCompanyAdmin = false;
                Security.RemoveUserFromRole(user.UserName, Roles.CompanyAdmin);
            }
            else
            {
                Security.RemoveUserFromRole(user.UserName, Roles.CompanyEmployee);
            }
            UserRep.Update(user);
        }
    

    }
}