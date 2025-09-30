using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.Repositories
{
    public class GeneralRepository
    {
        RealEstateBrokerEntities db;
        public GeneralRepository(RealEstateBrokerEntities Context)
        {
            db = Context;
        }
        public bool Save()
        {
            db.SaveChanges();
            return true;
        }
        public IEnumerable<Country> GetCountries()
        {
            return db.Countries.OrderBy(c => c.Sort).ThenBy(c => c.Name);
        }
        public Country GetCountry(int? id)
        {
            return db.Countries.Find(id);
        }

        public IEnumerable<SuspendReason> GetSuspendReasons()
        {
            return db.SuspendReasons.OrderBy(s => s.Title);
        }
        public SuspendReason GetSuspendReasonById(int? id)
        {
            return db.SuspendReasons.Find(id);
        }
        public IEnumerable<City> GetCities(int? CountryID)
        {
            return db.Cities.Where(c => c.CountryID == CountryID).OrderBy(c => c.Sort).ThenBy(c => c.Name);
        }
        public City GetCity(int? id)
        {
            return db.Cities.Find(id);
        }
        public IEnumerable<District> GetDistricts(int? CityID)
        {
            return db.Districts.Where(c => c.CityID == CityID).OrderBy(d => d.Sort).ThenBy(d => d.Name);
        }
        public District GetDistrict(int? id)
        {
            return db.Districts.Find(id);
        }
        public IEnumerable<RealEstateType> GetTypes()
        {
            return db.RealEstateTypes.OrderBy(d => d.Sort).ThenBy(d => d.Title);
        }
        public RealEstateType GetType(int? id)
        {
            return db.RealEstateTypes.Find(id);
        }
        public IEnumerable<SaleType> GetSaleTypes()
        {
            return db.SaleTypes.OrderBy(d => d.Title);
        }
        public SaleType GetSaletype(int? id)
        {
            return db.SaleTypes.Find(id);
        }
        public IEnumerable<RealEstateStatu> GetStatus(int? TypeID)
        {
            RealEstateType type = db.RealEstateTypes.Find(TypeID);
            return db.RealEstateStatus.Where(s => s.RealEstateCategoryID == type.RealEstateCategoryId).OrderBy(d => d.Title);
        }
        public IEnumerable<Currency> GetCurrencies()
        {
            return db.Currencies.OrderBy(d => d.Name);
        }
        public IEnumerable<PaymentType> GetPaymenTypes()
        {
            return db.PaymentTypes.OrderBy(d => d.Title);
        }
        public IEnumerable<RealEstateType> GetTypes(int? categoryId)
        {
            return db.RealEstateTypes.Where(c => c.RealEstateCategoryId == categoryId).OrderBy(d => d.Sort).ThenBy(d => d.Title);
        }

        public Subscriber GetSubscriber(string userName)
        {
            return db.Subscribers.FirstOrDefault(s => s.UserName == userName);
        }
        public Subscriber GetSubscriber(int? id)
        {
            return db.Subscribers.Find(id);
        }
        public Subscriber GetSubscriberByMailOrPhoneNumber(string emailOrPhoneNumber)
        {
            return db.Subscribers.FirstOrDefault(p => p.Email == emailOrPhoneNumber || p.MobileNo == emailOrPhoneNumber);
        }
        public Subscriber GetSubscriberByMail(string email)
        {
            return db.Subscribers.FirstOrDefault(p => p.Email.ToLower() == email.ToLower());
        }
        public Subscriber GetSubscriberByPhoneNumber(string phoneNumber)
        {
            return db.Subscribers.FirstOrDefault(p => p.MobileNo == phoneNumber);
        }
        public Subscriber GetSubscriberByUsername(string username)
        {
            return db.Subscribers.FirstOrDefault(p => p.UserName.ToLower() == username);
        }

        public Subscriber GetSubscriberForLogin(string usernameOrMobileNoOrMail)
        {
            return db.Subscribers.FirstOrDefault(p => p.UserName.ToLower() == usernameOrMobileNoOrMail.ToLower()|| p.MobileNo == usernameOrMobileNoOrMail|| p.Email.ToLower() == usernameOrMobileNoOrMail.ToLower());
        }

        public RealEstateCompany GetCompany(int? companyId)
        {
            return db.RealEstateCompanies.FirstOrDefault(s => s.ID == companyId);
        }
        public void AddNotification(SubscriberNotification notification)
        {
            db.SubscriberNotifications.Add(notification);
        }
        public void LogAction(Modules module, subscriberActions action, int objectId, string objectName)
        {
            SubscriberLog logger;
            if (action != subscriberActions.AddNew)
            {
                logger = db.SubscriberLogs.FirstOrDefault(SL => SL.ObjectTypeID == (int)module && SL.ObjectID == objectId);
                if (logger != null)
                {
                    if (logger.ActionID == (int)subscriberActions.AddNew)
                    {
                        return;
                    }
                    if (action == subscriberActions.Updated && logger.ActionID == (int)subscriberActions.Updated)
                    {
                        return;
                    }
                }
            }
            logger = new SubscriberLog();
            logger.ActionID = (int)action;
            logger.Date = DateTime.Now;
            logger.ObjectID = objectId;
            logger.ObjectTypeID = (int)module;
            logger.ObjectName = objectName;
            db.SubscriberLogs.Add(logger);
        }
        public void RemoveLog(int? objectId, int objectTypeId)
        {
            List<SubscriberLog> Logs = db.SubscriberLogs.Where(L => L.ObjectID == objectId && L.ObjectTypeID == objectTypeId).ToList();
            if (Logs != null && Logs.Count > 0)
            {
                Logs.ForEach(Log => db.SubscriberLogs.Remove(Log));
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}