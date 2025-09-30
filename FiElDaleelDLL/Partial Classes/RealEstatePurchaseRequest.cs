using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class RealEstatePurchaseRequest
    {
        public virtual string RealEstateTitle
        {
            get
            {
                return this.RealEstate.Title;
            }
        }
        public virtual string SubscriberName
        {
            get
            {
                if (this.RealEstate.UseContactInfo==true)
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
        public virtual string EmployeeName
        {
            get
            {
                return this.RealEstate.Subscriber.FullName;
            }
        }
    }
}
