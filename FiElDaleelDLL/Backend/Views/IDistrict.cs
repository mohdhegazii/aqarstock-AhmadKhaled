using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IDistrict:IView
    {
        int DistrictId { get; set; }
        void BindDistrictList(List<District> Districts);
        District FillDistrictObject();
        void FillDistrictControls(District district);
        void FillCountryList(List<Country> Countries);
        void FillCityList(List<City> Cities);
    }
}
