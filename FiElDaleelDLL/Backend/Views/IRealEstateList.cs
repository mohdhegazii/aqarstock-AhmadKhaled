using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateList
    {
        PageMode Mode { get; set; }
        void BindRealEstateList(List<RealEstate> RealEstatees);
        RealEstateSearchCriteria FillSearchCriteriaObject();
        void FillRealEstateTypeList(List<RealEstateType> Types);
        void FillDistrictList(List<District> Addresses);
    }
}
