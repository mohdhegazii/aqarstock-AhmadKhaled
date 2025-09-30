using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using BrokerDLL.Serializable;
using System.Web.Script.Serialization;
using BrokerDLL.General;

namespace BrokerWeb.Services
{
    /// <summary>
    /// Summary description for RealEstate
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RealEstate : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstateCategories()
        {
            List<RealEstateCategory> Categories = new List<RealEstateCategory>();
            BrokerDLL.Commons.Context.RealEstateCategories.OrderBy(C => C.Title).ToList()
                .ForEach(C => Categories.Add(new RealEstateCategory(C.ID, C.Title)));
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(Categories);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstateTypes(int RealEstateCategoryID)
        {
            List<RealEstateType> Types = new List<RealEstateType>();
            BrokerDLL.Commons.Context.RealEstateTypes.Where(RT => RT.RealEstateCategoryId == RealEstateCategoryID)
                .OrderBy(RT => RT.Title).ToList().ForEach(RT => Types.Add(new RealEstateType(RT.ID, RT.RealEstateCategoryId.Value, RT.Title)));
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(Types);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetALLRealEstateTypes()
        {
            List<RealEstateType> Types = new List<RealEstateType>();
            BrokerDLL.Commons.Context.RealEstateTypes.OrderBy(RT => RT.Title).ToList()
                .ForEach(RT => Types.Add(new RealEstateType(RT.ID, RT.RealEstateCategoryId.Value, RT.Title)));
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(Types);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstateStaus(int RealEstateCategoryID)
        {
            List<RealEstateStatus> Status = new List<RealEstateStatus>();
            BrokerDLL.Commons.Context.RealEstateStatuses.Where(RS => RS.RealEstateCategoryID == RealEstateCategoryID)
                .OrderBy(RS => RS.Title).ToList().ForEach(RS => Status.Add(new RealEstateStatus(RS.ID, RS.RealEstateCategoryID.Value, RS.Title)));
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(Status);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstates(int PageIndex, int PageSize)
        {
            List < BrokerDLL.Serializable.RealEstate> RealEstates= new List<BrokerDLL.Serializable.RealEstate>();
            BrokerDLL.Commons.Context.RealEstates.Where(RS => RS.ActiveStatusId == (int)BrokerDLL.Activestatus.Active && RS.IsSold==false)
                .OrderByDescending(B => B.CreatedDate).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList()
                .ForEach(RS => RealEstates.Add(new BrokerDLL.Serializable.RealEstate(RS)));
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(RealEstates);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Search(RealEstateSearchCriteria RealEstateSearchCriteria, int PageIndex, int PageSize)
        {
            JavaScriptSerializer Serialize = new JavaScriptSerializer();
            return Serialize.Serialize(BrokerDLL.General.Search.SearchRealEstates(RealEstateSearchCriteria, PageIndex, PageSize));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstate(int ID)
        {
            BrokerDLL.RealEstate realestate = BrokerDLL.Commons.Context.RealEstates.FirstOrDefault(R => R.ID == ID);
            if (realestate != null)
            {
                JavaScriptSerializer Serialize = new JavaScriptSerializer();
                return Serialize.Serialize(new BrokerDLL.Serializable.RealEstate(realestate));
            }
            else
            {
                return "";
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstatePhotos(int RealEstateID)
        {
            List<BrokerDLL.Serializable.RealEstatePhoto> Photos = new List<RealEstatePhoto>();
            BrokerDLL.Commons.Context.RealEstatePhotos.Where(P=>P.RealEstateID==RealEstateID).ToList()
                .ForEach(P=>Photos.Add(new RealEstatePhoto(P.PhotoName,P.IsDefault.Value)));
            JavaScriptSerializer Serialize = new JavaScriptSerializer();
            return Serialize.Serialize(Photos);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstateKeywords(int RealEstateID)
        {
            List<BrokerDLL.Serializable.RealEstateKeyword> Keywords = new List<RealEstateKeyword>();
            BrokerDLL.Commons.Context.RealEstateKeywords.Where(K => K.RealEstateID == RealEstateID).ToList()
                .ForEach(K => Keywords.Add(new RealEstateKeyword(K.KeywordTitle)));
            JavaScriptSerializer Serialize = new JavaScriptSerializer();
            return Serialize.Serialize(Keywords);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRealEstateCriterias(int RealEstateID)
        {
            List<BrokerDLL.Serializable.RealEstateCriteria> Criterias = new List<RealEstateCriteria>();
            BrokerDLL.Commons.Context.RealEstateCriterias.Where(C => C.RealEstateID == RealEstateID).ToList()
                .ForEach(C => Criterias.Add(new RealEstateCriteria(C.RealEstateTypeCriteria.Title,C.Value)));
            JavaScriptSerializer Serialize = new JavaScriptSerializer();
            return Serialize.Serialize(Criterias);
        }

    }
}
