using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealestateCatalogTag
    {
        public virtual string TagName
        {
            get
            {
                return this.Tag.Name;
            }
        }
    }
}
