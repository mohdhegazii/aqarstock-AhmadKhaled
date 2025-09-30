using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
  public  interface ISubscriberNotification
    {
        void BindList(List<SubscriberNotification> Notifications);
        void FillNotificationControls(SubscriberNotification Notification);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void OpenNotification();
    }
}
