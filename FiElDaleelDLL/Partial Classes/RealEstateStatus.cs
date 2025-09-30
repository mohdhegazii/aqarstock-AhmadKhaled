using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateStatus
    {
        public virtual string CategoryTitle
        {
            get
            {
                if (this.RealEstateCategory != null)
                    return RealEstateCategory.Title;
                else
                    return "";
            }
        }
    }
}
