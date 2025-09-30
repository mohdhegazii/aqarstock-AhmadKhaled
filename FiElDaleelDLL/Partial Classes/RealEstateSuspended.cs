using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public partial class RealEstateSuspended
    {
       public virtual string Title
       {
           get
           {
               return this.RealEstate.Title;
           }
       }
       public virtual int Code
       {
           get
           {
               return this.RealEstate.Code;
           }
       }
       public virtual string Reason
       {
           get
           {
               return this.SuspendReason.Title;
           }
       }
       public virtual string SubscriberName
       {
           get
           {
               if (this.RealEstate.UseContactInfo == true)
               {
                   return this.RealEstate.Subscriber.FullName;
               }
               else
               {
                   return this.RealEstate.OwnerName;
               }
           }
       }
       public virtual string SubscriberMobile
       {
           get
           {
               if (this.RealEstate.UseContactInfo == true)
               {
                   return this.RealEstate.Subscriber.MobileNo;
               }
               else
               {
                   return this.RealEstate.OwnerMobile;
               }
           }
       }

    }
}
