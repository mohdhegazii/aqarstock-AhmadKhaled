using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Views
{
    public interface IAdminRealEstateList
    {
        void BindRealEstateList(List<RealEstate> RealEstatees);
        RealEstateSearchCriteria FillSearchCriteriaObject();

        void FillRealEstateCategoryList(List<RealEstateCategory> Categories);
        void FillRealEstateStatusList(List<RealEstateStatus> Status);
        void FillRealEstateTypeList(List<RealEstateType> Types);
        void FillDistrictList(List<District> Addresses);
        void FillSaleTypeList(List<SaleType> SaleTypes);
        void FillSubscriberList(List<Subscriber> Subscribers);
    }
}
