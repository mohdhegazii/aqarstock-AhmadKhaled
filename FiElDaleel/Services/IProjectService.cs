using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProjectService" in both code and config file together.
    [ServiceContract]
    public interface IProjectService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Projects/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]    
        List<BrokerDLL.Serializable.Project> GetProjects(string PageIndex, string PageSize);

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "BannerProjects")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.Project> GetBannerProject();

        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "HomePageProjects")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.Project> GetHomePageProject();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectCount/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]    
        List<int> GetProjectsCount(string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectsByCompany/{CompanyID}/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.Project> GetProjectsByCompany(string CompanyID,string PageIndex, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CompanyProjectsCount/{CompanyID}/{PageSize}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<int> GetCompanyProjectsCount(string CompanyID, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Projects/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.Project GetProject(string ID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectPhotoAlbum/{ID}/{PageSize}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.ProjectPhotos> GetProjectPhotoAlbum(string ID, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectPhoto/{ID}/{Date}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.ProjectPhotos> GetProjectPhotos(string ID,string Date);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectVedios/{ID}/{PageSize}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        List<BrokerDLL.Serializable.ProjectVedio> GetProjectVedios(string ID, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectModels/{ID}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<BrokerDLL.Serializable.ProjectModel> GetProjectModels(string ID, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectModel/{ID}")]
        [AspNetCacheProfile("SomeTimeChangeTableCache")]
        BrokerDLL.Serializable.ProjectModel GetProjectModel(string ID);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "ProjectProperties/{ID}/{PageIndex}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<BrokerDLL.Serializable.RealEstate> GetProjectProperties(string ID,string PageIndex, string PageSize);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "CountProjectProperties/{ID}/{PageSize}")]
        [AspNetCacheProfile("UsuallyChangeTableCache")]
        List<int> CountProjectProperties(string ID, string PageSize);
    }
}
