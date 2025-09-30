using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ICompanyMessage
    {
        void BindList(List<CompanyMessage> Messages);
        void FillControls(CompanyMessage Message);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void OpenMessage();
    }
}
