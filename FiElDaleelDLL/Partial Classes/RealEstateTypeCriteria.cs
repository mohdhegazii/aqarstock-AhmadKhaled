using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateTypeCriteria
    {
        public virtual string TypeTitle
        {
            get
            {
                if (this.RealEstateType != null)
                    return RealEstateType.Title;
                else
                    return "";
            }
        }
    }
}
