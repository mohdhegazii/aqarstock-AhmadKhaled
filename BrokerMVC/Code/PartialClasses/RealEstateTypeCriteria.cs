using BrokerMVC.Code.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstateTypeCriteria : CategoryBase
    {

        public virtual int? CategoryId
        {
            get
            {
                return this.RealEstateType.RealEstateCategoryId;
            }
        }
        public string Value { get; set; }
        public bool BoolValue
        {
            get; set;
        }
        public int? intValue
        {
            get; set;
        }
    }
}