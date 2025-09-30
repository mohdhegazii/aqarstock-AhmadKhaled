using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IProjectRealestates
    {
        int ProjectID { get; set; }
        void BindRealestateList(List<RealEstate> realestates);
        void FillRealEstateDDL(List<RealEstate> realestates);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
    }
}
