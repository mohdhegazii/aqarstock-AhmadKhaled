using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminRealEstateView : IRealEstateView
    {
        int SubscriberLogID { get; set; }
        void FillSuspendReasonList(List<SuspendReason> Reasons);
    }
}
