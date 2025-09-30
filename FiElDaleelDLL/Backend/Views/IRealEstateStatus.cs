using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateStatus:IView
    {
        int RealEstateStatusID { get; set; }
        RealEstateStatus FillRealEstateStatusObject();
        void FillRealEstateStatusControls(RealEstateStatus Status);
        void BindRealEstateStatusList(List<RealEstateStatus> Statuses);
        void FillCategoryList(List<RealEstateCategory> Categories);
    }
}
