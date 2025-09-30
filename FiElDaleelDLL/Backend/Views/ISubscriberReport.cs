using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ISubscriberReport
    {
        void BindGrid(List<Subscriber> Subscibers);

    }
}
