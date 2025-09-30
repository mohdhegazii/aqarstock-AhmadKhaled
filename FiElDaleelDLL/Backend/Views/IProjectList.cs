using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IProjectList
    {
        int CompanyID { get; set; }
        void BindList(List<RealEstateProject> Projects);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
    }
}
