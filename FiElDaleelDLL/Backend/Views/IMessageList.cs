using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IMessageList
    {
        void BindMessagesList(List<SubscriperMessage> Messages);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
    }
}
