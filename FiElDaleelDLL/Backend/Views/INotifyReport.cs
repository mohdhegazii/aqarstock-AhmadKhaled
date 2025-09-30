using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Views
{
    public interface INotifyReport
    {
        void FillRealEstateTypeList(List<RealEstateType> Types);
        void FillDistrictList(List<District> districts);
        void FillCountryList(List<Country> Countries);
        void FillCityList(List<City> Cities);
        void FillSaleTypeList(List<SaleType> SaleTypes);
        void BindList(List<NotifyService> NotifyRequests);
        RealEstateSearchCriteria FillSearchCriteriaObject();
        void FillRequestControls(NotifyService Request);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);
    }
}
