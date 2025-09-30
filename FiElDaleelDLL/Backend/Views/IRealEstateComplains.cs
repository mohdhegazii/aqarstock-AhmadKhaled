using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateComplains
    {
        void BindComplains(List<RealEstateComplain> Complains);
        void FillComplainControls(RealEstateComplain Complain);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
    }
}
