using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateProjectModel
    {
        public virtual string Type
        {
            get
            {
                return this.RealEstateType.Title;
            }
        }
    }
}
