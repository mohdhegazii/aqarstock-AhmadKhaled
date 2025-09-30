using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using BrokerDLL.Serializable;
using BrokerDLL.General;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRealEstateService" in both code and config file together.
    [ServiceContract]
    public interface IRealEstateService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateTypes")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<RealEstateType> GetRealEstateTypes();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstates/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<BrokerDLL.Serializable.RealEstate> GetRealEstates(string PageIndex, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateCategories")]
        List<RealEstateCategory> GetRealEstateCategories();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateTypes/{RealEstateCategoryID}")]
        List<RealEstateType> GetRealEstateTypesByCategory(string RealEstateCategoryID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateStaus/{RealEstateCategoryID}")]
        List<RealEstateStatus> GetRealEstateStaus(string RealEstateCategoryID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateStausByType/{RealEstateTypeID}")]
        [AspNetCacheProfile("RareChangeTableCache")]
        List<RealEstateStatus> GetRealEstateStausByType(string RealEstateTypeID);
       
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstates/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.RealEstate GetRealEstate(string ID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateOwner/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.Subscriber GetSubscriber(string ID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatePhotos/{RealEstateID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<RealEstatePhoto> GetRealEstatePhotos(string RealEstateID);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateKeywords/{RealEstateID}")]
          [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<RealEstateKeyword> GetRealEstateKeywords(string RealEstateID);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstateCriterias/{RealEstateID}")]
          [AspNetCacheProfile("SomeTimeChangeTableCache")]
          List<RealEstateCriteria> GetRealEstateCriterias(string RealEstateID);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Search/{PageSize}/{PageIndex}/{SaleType}/{Type}/{Status}/{Country}/{City}/{District}/{Area}/{Price}/{PaymentType}/{Currency}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]    
        List<BrokerDLL.Serializable.RealEstate> Search(string PageSize, string PageIndex, string SaleType, string Type, string Status, string Country, string City, string District, string Area, string Price, string PaymentType, string Currency);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountSearchResult/{PageSize}/{SaleType}/{Type}/{Status}/{Country}/{City}/{District}/{Area}/{Price}/{PaymentType}/{Currency}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<int> CountResult(string PageSize, string SaleType, string Type, string Status, string Country, string City, string District, string Area, string Price, string PaymentType, string Currency);

          [OperationContract]
          [WebInvoke(ResponseFormat = WebMessageFormat.Json,BodyStyle=WebMessageBodyStyle.WrappedResponse)]
          string SendComplain(Complain complain);

          [OperationContract]
          [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
          string PurchaseRequest(PurchaseRequest request);
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string InqueryRequest(PurchaseRequest request);

        [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "LatestRealEstatesBySaleType/{SaleType}/{PageIndex}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]  
        List<BrokerDLL.Serializable.RealEstate> GetLatestRealEstatesBySaleType(string SaleType,string PageIndex, string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesByCompany/{CompanyID}/{PageIndex}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]    
          List<BrokerDLL.Serializable.RealEstate> GetRealEstatesByCompany(string CompanyID, string PageIndex, string PageSize);

          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesNoByCompany/{CompanyID}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]    
          List<int> GetRealEstatesNoByCompany(string CompanyID, string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "SpecialRealEstates/{PageIndex}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")] 
        List<BrokerDLL.Serializable.RealEstate> GetSpecailRealEstates(string PageIndex, string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountSpecialRealEstates/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<int> CountSpecialRealEstates(string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesBySaleType/{SaleType}/{PageIndex}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<BrokerDLL.Serializable.RealEstate> GeRealEstatesBySaleType(string SaleType, string PageIndex, string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountRealEstatesBySaleType/{SaleType}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<int> CountRealEstatesByType(string SaleType,string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesByCategory/{Category}/{PageIndex}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<BrokerDLL.Serializable.RealEstate> GeRealEstatesByCategory(string Category, string PageIndex, string PageSize);

          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountRealEstatesByCategory/{Category}/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<int> CountRealEstatesByCategory(string Category, string PageSize);
          [OperationContract]
          [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountRealEstates/{PageSize}")]
          [AspNetCacheProfile("UsuallyChangeTableCache")]
          List<int> CountRealEstates(string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesByCatalog/{CatalogID}/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<BrokerDLL.Serializable.RealEstate> GetRealEstatesByCatalog(string CatalogID, string PageIndex, string PageSize);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "RealEstatesNoByCatalog/{CatalogID}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<int> GetRealEstatesNoByCatalog(string CatalogID, string PageSize);

        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        string ValidateContactData(PurchaseRequest contact);
    }
}
