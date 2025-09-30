using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using BrokerDLL.Serializable;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGeneraLService" in both code and config file together.
    [ServiceContract]
 
    public interface IGeneraLService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Countries")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<Country> GetCountries();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Cities")]
        List<City> GetCities();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Cities/{CountryID}")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<City> GetCitiesByCountryID(string CountryID);
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Districts")]
        List<District> GetDistricts();

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Districts/{CityID}")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<District> GetDistrictsByCityID(string cityID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SalesTypes")]
        List<SaleType> GetSalesTypes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,  UriTemplate = "PaymentTypes")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<PaymentType> GetPaymentTypes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Currencies")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<Currency> GetCurrencies();

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string ContactUs(ContactUsMail contactUsMail);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string SendNotifyRequest(NotifyRequest Request);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Keywords")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<SearchKeyword> GetSearchKeywords();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Companies/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]    
        List<BrokerDLL.Serializable.Company> GetCompanies(string PageIndex, string PageSize);
        
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CompaniesCount/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]    
        List<int> GetCompaniesCount( string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Companies/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.Company GetCompany(string ID);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string ContactCompany(CompanyMessage CompanyMail);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Advertisement")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.Advertisement> GetAdvertisement();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SearchQuery/{URL}/{Query}")]
        bool AddToSiteMap(string URL, string Query);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Catalogs/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.Catalog GetCatalog(string ID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CatalogTags/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.Tag> GetTags(string ID);
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string Login(Login account);
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string CheckLogin();
    }
}
