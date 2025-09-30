using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ISubscriberDashboard
    {
       void BindRealEstateList(List<RealEstate> RealEstates);
       //void FillControls(int MsgNo, int RequestsNo);
    }
}
