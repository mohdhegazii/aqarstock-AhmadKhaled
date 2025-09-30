using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ICountry:IView
    {
        int CountryID { get; set; }
        void BindCountriesList(List<Country> Countries);
        Country FillCountryObject();
        void FillCountryControls(Country country);
    }
}
