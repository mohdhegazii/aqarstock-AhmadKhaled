using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class CompanyMessage
    {
        public virtual string CompanyName
        {
            get
            {
                return this.RealEstateCompany.Title;
            }
        }

        public virtual string ProjectName
        {
            get
            {
                if (this.ProjectID > 0)
                {
                    return this.RealEstateProject.Title;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
