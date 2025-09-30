using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateView
    {
        int RealEstateID { get; set; }
        void FillRealEstateControls(RealEstate realestate);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void ShowEditControls(bool Show);
    }
}
