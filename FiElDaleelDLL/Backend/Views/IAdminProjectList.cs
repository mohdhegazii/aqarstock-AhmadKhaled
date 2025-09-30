using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminProjectList
    {
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
        void FillCompanyDLL(List<RealEstateCompany> Companies);
        void BindGrid(List<RealEstateProject> Projects);
    }
}
