using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface ICompanyUser:IView
    {
       int UserID { get; set; }
       int CompanyId { get; set; }
        Subscriber FillSubscriberObject();
    }
}
