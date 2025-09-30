using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateProject
    {
        public virtual string CountryName
        {
            get
            {
              return  this.Country.Name;
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
