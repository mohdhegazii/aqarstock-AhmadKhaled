using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IPartner:IView
    {
        int PartnerID { get; set; }
        void FillSubscriberList(List<Subscriber> Subscribers);
        void FillControls(Partner partner);
        Partner FillObject(Partner partner);
        void UploadRealEstatePhoto(string Code);
    }
}
