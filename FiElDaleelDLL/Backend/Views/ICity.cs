using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ICity:IView
    {
        int CityId { get; set; }
        void BindCitiesList(List<City> Cities);
        City FillCityObject();
        void FillCityControls(City city);
        void FillCountryList(List<Country> Countries);
    }
}
