using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class RequestedRealestateSearchCriteria
    {
        [Display(Name = "SaleType", ResourceType = typeof(ResourcesFiles.General))]
        public int? SaleTypeID { get; set; }
        [Display(Name = "CountryName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CountryID { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CityID { get; set; }
        [Display(Name = "District", ResourceType = typeof(ResourcesFiles.General))]
        public int? DistrictID { get; set; }
        [Display(Name = "RealestateType", ResourceType = typeof(ResourcesFiles.General))]
        public int? TypeId { get; set; }
        [Display(Name = "From", ResourceType = typeof(ResourcesFiles.General))]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [Display(Name = "To", ResourceType = typeof(ResourcesFiles.General))]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        [Display(Name = "Area", ResourceType = typeof(ResourcesFiles.General))]
        public int? Area { get; set; }
        [Display(Name = "Price", ResourceType = typeof(ResourcesFiles.General))]
        public int? Price { get; set; }
        public int? Page { get; set; }
        public string SortOrder { get; set; }
        public PagedList.IPagedList<NotifyService> RequestedRealestates {get;set;}

    }
}