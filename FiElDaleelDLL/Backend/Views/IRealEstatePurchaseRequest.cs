using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public  interface IRealEstatePurchaseRequest
    {
       void BindPurchaseRequest(List<RealEstatePurchaseRequest> Requests);
       void FillRequestControls(RealEstatePurchaseRequest Request);
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
       void OpenRequest();
    }
}
