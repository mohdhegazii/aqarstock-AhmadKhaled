using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ISuspendedRealEstatesReport
    {
       void BindList(List<RealEstateSuspended> RealEstates);
       void FillReasonList(List<SuspendReason> Reasons);
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
    }
}
