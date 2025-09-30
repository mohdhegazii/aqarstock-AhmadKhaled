using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ILogin
    {
       Subscriber FillSubscriberObject();
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
    }
}
