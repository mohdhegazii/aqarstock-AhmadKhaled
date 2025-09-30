using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class District
    {
        public virtual string CountryName
        {
            get
            {
                return this.City.CountryName;
            }
        }
        public virtual string CityName
        {
            get
            {
                return this.City.Name;
            }
        }
        public virtual string FullName
        {
            get
            {
                return this.Name + ", " + this.CityName + ", " + this.CountryName;
            }
        }
    }
}
