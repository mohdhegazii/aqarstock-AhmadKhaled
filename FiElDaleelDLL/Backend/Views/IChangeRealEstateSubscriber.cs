using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IChangeRealEstateSubscriber
    {
       void FillSubscriberList(List<Subscriber> Subscribers);
      // void BindSubscriberList(List<Subscriber> Subscribers);
       void BindRealEstateList(List<RealEstate> RealEstates);
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
    }
}
