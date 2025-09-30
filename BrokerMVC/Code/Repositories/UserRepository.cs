using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.Repositories
{
    public class UserRepository:GeneralRepository
    {
        RealEstateBrokerEntities db;
        public UserRepository(RealEstateBrokerEntities Context):base(Context)
        {
            db = Context;
        }

        public void Add(Subscriber user)
        {
            db.Subscribers.Add(user);
        }
        public IEnumerable<Subscriber> GetAllByCompany(int? companyId)
        {
            return db.Subscribers.Where(s => s.CompanyID == companyId);
        }
        public Subscriber GetBySubscriberId(int?id)
        {
            return db.Subscribers.Find(id);
        }
        public void Update(Subscriber user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
    }
}