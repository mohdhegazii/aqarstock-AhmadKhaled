using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminDashboard
    {
        void BindNewObjects(List<SubscriberLog> Objects);
    }
}
