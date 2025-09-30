using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public partial class RealEstate
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
