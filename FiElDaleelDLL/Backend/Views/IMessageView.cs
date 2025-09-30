using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IMessageView
    {
        int MainMessageID { get; set; }
        int MessageID { get; set; }
        void BindPrevMessagesControls(List<SubscriperMessage> PrevMessages);
        void FillMessageTitleControl(string Title);
        SubscriperMessage FillMessageObject();
        void NotifyUser(string Msg, MessageType Type);
    }
}
