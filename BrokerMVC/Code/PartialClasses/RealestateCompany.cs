using BrokerMVC.Code.AbstractClasses;
using BrokerMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstateCompany: CompanyBase
    {
        public string Address
        {
            get
            {
                if (this.Country != null)
                {
                    return this.Street + ", " + this.District.Name + " " + this.City.Name + " " + this.Country.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        public string EnAddress
        {
            get
            {
                if (this.Country != null)
                {
                    return this.Entreet + ", " + this.District.EnName + " " + this.City.EnName + " " + this.Country.EnName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}