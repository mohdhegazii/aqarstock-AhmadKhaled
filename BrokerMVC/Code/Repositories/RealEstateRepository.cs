using BrokerMVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.Repositories
{
    public class RealEstateRepository: GeneralRepository
    {
        RealEstateBrokerEntities db;
        public RealEstateRepository(RealEstateBrokerEntities Context):base(Context)
        {
            db = Context;
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            return db.Currencies.OrderBy(c=>c.Sort).ThenBy(c=>c.Name);
        }
        public IEnumerable<PaymentType> GetPaymentTypes()
        {
            return db.PaymentTypes.OrderBy(c => c.Title);
        }
        public IEnumerable<RealEstateCategory> GetRealestateCategories()
        {
            return db.RealEstateCategories.OrderBy(c => c.Title);
        }
        public IEnumerable<RealEstateStatu> GetRealestateStatus(int categoryid)
        {
            return db.RealEstateStatus.Where(s => s.RealEstateCategoryID == categoryid).OrderBy(c=>c.Title);
        }
        public IEnumerable<RealEstateType> GetRealestateTypes(int categoryid)
        {
            return db.RealEstateTypes.Where(s => s.RealEstateCategoryId == categoryid).OrderBy(t=>t.Sort).ThenBy(t=>t.Title);
        }
        public IEnumerable<RealEstateTypeCriteria> GetRealestateTypeCriteria(int typeID)
        {
            return db.RealEstateTypeCriterias.Where(s => s.RealEstateTypeID == typeID).OrderByDescending(c => c.ValueType).ThenBy(c=>c.Title);
        }
        public IEnumerable<RealEstateTypeCriteria> GetRealestateTypeCriteria(int typeID, int realestateId)
        {
            return db.RealEstateTypeCriterias.Where(rc => rc.RealEstateTypeID == typeID
            && db.RealEstateCriterias.FirstOrDefault(re => re.RealEstateID == realestateId && re.RealEstateTypeCriteriaID == rc.ID) == null).ToList();

        }
        public IEnumerable<RealEstateCriteria> GetRealestateNonBooleanCriteria(int realestateid)
        {
            return db.RealEstateCriterias.Where(c => c.RealEstateID == realestateid && c.RealEstateTypeCriteria.ValueType + "_Type" != CriteriaValueType.bool_Type.ToString());
        }
        public IEnumerable<SaleType> GetSaleTypes()
        {
            return db.SaleTypes;
        }
        public RealEstate GetByRealestateID(int? id)
        {
            return db.RealEstates.Find(id);
        }
        public IPagedList<RealEstate> GetAll(int? page, string sortOrder, string searchString, int pageNumber, int pageSize)
        {
            var realestates = from C in db.RealEstates select C;
            return GetRealEstates(sortOrder, searchString, pageNumber, pageSize, ref realestates);
        }
        public IPagedList<RealEstate> GetByCompny(int CompanyID,int? page, string sortOrder, string searchString, int pageNumber, int pageSize)
        {
            var realestates = from C in db.RealEstates select C;
            realestates = realestates.Where(p => p.Subscriber.CompanyID == CompanyID);
            return GetRealEstates(sortOrder, searchString, pageNumber, pageSize, ref realestates);
        }
        public IPagedList<RealEstate> GetBySubscrber(int SubscriberID, int? page, string sortOrder, string searchString, int pageNumber, int pageSize)
        {
            var realestates = from C in db.RealEstates select C;
            realestates = realestates.Where(p => p.SubscriberID == SubscriberID);
            return GetRealEstates(sortOrder, searchString, pageNumber, pageSize, ref realestates);
        }

        public IEnumerable<RealEstatePhoto> GetPhotos(int realestateid)
        {
            return db.RealEstatePhotos.Where(p => p.RealEstateID == realestateid);
        }
        public RealEstatePhoto GetPhoto(int? Id)
        {
            return db.RealEstatePhotos.Find(Id);
        }
        private static IPagedList<RealEstate> GetRealEstates(string sortOrder, string searchString, int pageNumber, int pageSize, ref IQueryable<RealEstate> realestates)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                realestates = realestates.Where(r => r.Title.Contains(searchString) ||r.Code.ToString()==searchString
                || r.RealEstateType.Title.Contains(searchString)
                  || r.RealEstateStatu.Title.Contains(searchString) || r.SaleType.Title.Contains(searchString)
                  || r.PaymentType.Title.Contains(searchString) || r.District.Name.Contains(searchString)
                  || r.City.Name.Contains(searchString) || r.Country.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name":
                    realestates = realestates.OrderBy(c => c.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "name_desc":
                    realestates = realestates.OrderByDescending(c => c.Title).ThenByDescending(c => c.CreatedDate);
                    break;
                case "Special":
                    realestates = realestates.OrderByDescending(c => c.IsSpecialOffer).ThenByDescending(c => c.CreatedDate);
                    break;
                default:
                    realestates = realestates.OrderByDescending(c => c.CreatedDate);
                    break;
            }
            return realestates.ToPagedList(pageNumber, pageSize);
        }

        public IEnumerable<RealEstate> GetAllByProject(int? ProjectID)
        {
            return db.RealEstates.Where(v => v.ProjectID == ProjectID);
        }
        public IEnumerable<RealEstate> GetSubscriberOtherRealestates(int subscribrID, int realestateid)
        {
            return db.RealEstates.Where(r => r.SubscriberID == subscribrID && r.ID != realestateid);
        }
        public int GetLastCode()
        {
            return db.RealEstates.Max(r => r.Code);
        }
        public IEnumerable<RealEstate> GetCompanyIndividualRealEstates(int? CompanyId,int? ProjectID)
        {
            var realestate = db.RealEstates.Where(r => r.Subscriber.CompanyID == CompanyId && r.ProjectID != ProjectID &&
            (r.ActiveStatusId!=(int)ActiveStatus.IncompleteAddress && r.ActiveStatusId != (int)ActiveStatus.IncompletePhotos && r.ActiveStatusId != (int)ActiveStatus.Suspended));

            return realestate;
        }
        public IPagedList<RealEstate> GetSuspendedRealestates(string from,string to,int?ReasonId, int PageNumber,int pageSize)
        {
            IQueryable<RealEstate> realestates = GetSuspendedRealEstates(from, to, ReasonId);

            return realestates.OrderBy(r => r.ChangeActiveStatus).ToPagedList(PageNumber, pageSize);
        }
        public void RemoveSuspendedRealestate(string from, string to, int? ReasonId)
        {
            var realestates= GetSuspendedRealEstates(from, to, ReasonId);
            foreach(RealEstate r in realestates)
            {
                Delete(r.ID);
            }
        }
        private IQueryable<RealEstate> GetSuspendedRealEstates(string from, string to, int? ReasonId)
        {
            var realestates = from c in db.RealEstates where c.ActiveStatusId == (int)ActiveStatus.Suspended select c;
            if (!String.IsNullOrEmpty(from))
            {
                DateTime fromdate = Convert.ToDateTime(from);
                realestates = realestates.Where(r => r.ChangeActiveStatus >= fromdate);
            }
            if (!String.IsNullOrEmpty(to))
            {
                DateTime todate = Convert.ToDateTime(to);
                realestates = realestates.Where(r => r.ChangeActiveStatus <= todate);
            }
            if (ReasonId != null)
            {
                realestates = realestates.Where(r => r.RealEstateSuspendeds.Where(rs => rs.SuspendReasonId == ReasonId).FirstOrDefault() != null);
            }

            return realestates;
        }

        public void Add(RealEstate realestate)
        {
            db.RealEstates.Add(realestate);
        }
        public void AddCriteria(RealEstateCriteria rc)
        {
            db.RealEstateCriterias.Add(rc);
        }
        public void AddPhoto(RealEstatePhoto photo)
        {
            db.RealEstatePhotos.Add(photo);
        }
        public void AddSuspended(RealEstateSuspended susspended)
        {
            db.RealEstateSuspendeds.Add(susspended);
        }
        public void Update(RealEstate realEstate)
        {
            db.Entry(realEstate).State = EntityState.Modified;
        }
        public void UpdateCriteria(int? Id,string value)
        {
           var c= db.RealEstateCriterias.Find(Id);
            c.Value = value;
            db.Entry(c).State = EntityState.Modified;
        }
        public void UpdatePhoto(RealEstatePhoto photo)
        {
            db.Entry(photo).State = EntityState.Modified;
        }
        public int RemoveFromProject(int? id)
        {
            RealEstate real = GetByRealestateID(id);
            int ProjectId = real.ProjectID.Value;
            real.ProjectID = null;
            Update(real);
            return ProjectId;
        }
        public void RemoveSuspended(int?id)
        {
            RealEstateSuspended susspended = db.RealEstateSuspendeds.FirstOrDefault(IS => IS.RealEstateID == id);
            if (susspended != null)
            {
                db.RealEstateSuspendeds.Remove(susspended);
            }
        }
        public int DelereCriteria(int? id)
        {
            RealEstateCriteria cr = db.RealEstateCriterias.Find(id);
          int  RealestateId = cr.RealEstateID.Value;
            db.RealEstateCriterias.Remove(cr);
            return RealestateId;
        }
        public void DeletePhoto(int?id)
        {
            RealEstatePhoto realEstateProjectPhoto = db.RealEstatePhotos.Find(id);
            db.RealEstatePhotos.Remove(realEstateProjectPhoto);
        }
        public void Delete(int?id)
        {
            RealEstate realEstate = GetByRealestateID(id);
            if (realEstate.RealEstatePhotos.Count > 0)
            {
                realEstate.RealEstatePhotos.ToList().ForEach(p => DirectoryManager.RemoveFile(p.PhotoName));
            }
            db.RealEstatePurchaseRequests.RemoveRange(realEstate.RealEstatePurchaseRequests);
            db.RealEstateComplains.RemoveRange(realEstate.RealEstateComplains);
            db.RealEstateCriterias.RemoveRange(realEstate.RealEstateCriterias);
            db.RealEstatePhotos.RemoveRange(realEstate.RealEstatePhotos);
            db.RealEstateSuspendeds.RemoveRange(realEstate.RealEstateSuspendeds);
            db.SubscriberFavouriteRealEstates.RemoveRange(realEstate.SubscriberFavouriteRealEstates);
            db.RealestateCatalogProperties.RemoveRange(realEstate.RealestateCatalogProperties);
            SubscriberLog log = db.SubscriberLogs.FirstOrDefault(l => l.ObjectID == realEstate.ID && l.ObjectTypeID == (int)Modules.RealEstates);
            if (log != null)
            {
                db.SubscriberLogs.Remove(log);
            }
            db.RealEstates.Remove(realEstate);
        }

        public IEnumerable<SubscriberLog> GetSubscriberLogList()
        {
            var subLogRealEstates = from reSubscriberLogs in db.SubscriberLogs.Where(x => x.ObjectTypeID == (int)Modules.RealEstates)
                                    join re in db.RealEstates on reSubscriberLogs.ObjectID equals re.ID
                                    select reSubscriberLogs;
            var subLogRealEstateProjects = from repSubscriberLogs in db.SubscriberLogs.Where(x => x.ObjectTypeID == (int)Modules.Projects)
                join re in db.RealEstateProjects on repSubscriberLogs.ObjectID equals re.ID
                select repSubscriberLogs;
            var subLogRealEstateCompanies = from recSubscriberLogs in db.SubscriberLogs.Where(x => x.ObjectTypeID == (int)Modules.Companies)
                join re in db.RealEstateCompanies on recSubscriberLogs.ObjectID equals re.ID
                select recSubscriberLogs;
            var subscriberLogList=new List<SubscriberLog>();
            subscriberLogList.AddRange(subLogRealEstates.ToList());
            subscriberLogList.AddRange(subLogRealEstateProjects.ToList());
            subscriberLogList.AddRange(subLogRealEstateCompanies.ToList());
            return subscriberLogList;
        }
    }
}