using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstateCatalog
    {
        public virtual string URL
        {
            get
            {
                return ConfigurationSettings.AppSettings["WebSite"] + "/كتالوجات_عقارية/" + this.ID + "/" + this.Title.Replace(" ", "_");
            }
        }
    }
}
