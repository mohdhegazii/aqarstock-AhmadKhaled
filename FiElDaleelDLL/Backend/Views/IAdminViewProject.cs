using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminViewProject
    {
        int SubscriberLogID { get; set; }
        void FillSuspendReasonList(List<SuspendReason> Reasons);
        int ProjectID { get; set; }
        void FillControls(RealEstateProject Project);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void ShowEditControls(bool Show);
    }
}
