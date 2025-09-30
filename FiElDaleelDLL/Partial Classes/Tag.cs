using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public partial class Tag
    {
        public virtual string ParentName
        {
            get
            {
                if (this.ParentTag != null)
                {
                    return this.ParentTag.Name;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
