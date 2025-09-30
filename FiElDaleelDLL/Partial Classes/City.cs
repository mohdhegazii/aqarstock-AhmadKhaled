using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class City
    {
        public virtual string CountryName
        {
    get
    {
        return this.Country.Name;
    }
    }
    }
}
