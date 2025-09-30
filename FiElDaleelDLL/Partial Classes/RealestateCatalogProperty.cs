using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealestateCatalogProperty
    {
        public virtual string RealestateTitle
        {
            get
            {
                return this.RealEstate.Title;
            }
        }
        //public virtual string Address
        //{
        //    get
        //    {
        //        return this.RealEstate.Street+", "+this.RealEstate.District+", "+this.RealEstate.City.Name+", "+ this.RealEstate.Country.Name;
        //    }
        //}
        public virtual string Code
        {
            get
            { return this.RealEstate.Code.ToString(); }
        }
    }
}
