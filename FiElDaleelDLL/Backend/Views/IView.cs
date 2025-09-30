using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IView
    {
       PageMode Mode { get; set; }
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
       void Navigate();
    }
}
