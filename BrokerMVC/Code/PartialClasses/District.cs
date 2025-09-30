using BrokerMVC.Code.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class District: LookupBase
    {
        public virtual string CountryName
        {
            get
            {
               return this.City.Country.Name;
            }
        }
        public virtual int? CountryId
        {
            get
            {
                return this.City.CountryID;
            }
        }
        public virtual string CityName
        {
            get
            {
                return this.City.Name;
            }
        }
    }
}