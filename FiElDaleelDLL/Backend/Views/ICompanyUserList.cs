using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ICompanyUserList
    {
       int CompanyID { get; set; }
       void BindList(List<Subscriber> Subscribers);
       void NotifyUser(Message Msg, MessageType Type);
       void NotifyUser(string Msg, MessageType Type);
    }
}
