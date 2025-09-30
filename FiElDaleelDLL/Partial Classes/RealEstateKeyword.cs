using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateKeyword
    {
        public virtual string KeywordTitle
        {
            get
            {
                return this.Keyword.Title;
            }
        }
    }
}
