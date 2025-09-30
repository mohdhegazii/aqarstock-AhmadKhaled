using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ISubscriberHeader
    {
        void CountUnReadNotification(int count);
        void CountUnReadPurchaseRequest(int count);
        void CountUnReadMessages(int count);
        void BindUnReadMessages(List<SubscriperMessage> Messages);
        void BindUnReadRequests(List<RealEstatePurchaseRequest> Request);

        void NavigatetoManagerView();
    }
}
