using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public partial class SubscriberNotification
    {
       public virtual string Type
       {
           get
           {
               
               return Commons.GetValue((Modules)Enum.Parse(typeof(Modules),this.ObjectTypeID.ToString()));//.GetName(typeof(Modules), this.ObjectTypeID);
           }
       }
       //public virtual string Code
       //{
       //    get
       //    {
       //        return this.RealEstate.Code.ToString();
       //    }
       //}
    }
}
