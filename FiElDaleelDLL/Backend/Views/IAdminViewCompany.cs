using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminViewCompany
    {
        int SubscriberLogID { get; set; }
        void FillSuspendReasonList(List<SuspendReason> Reasons);
        int CompanyID { get; set; }
        void FillControls(RealEstateCompany Company);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void ShowEditControls(bool Show);
    }
}
