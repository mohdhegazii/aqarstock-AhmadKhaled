using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Code.AbstractClasses
{
    public class ProjectBase
    {

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public virtual string Title { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        public string EnTitle { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
     //   [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        public string Description { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishDescriptionRequired")]
       // [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "EnDescription", ResourceType = typeof(ResourcesFiles.General))]
        public string EnDesctiption { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Summary", ResourceType = typeof(ResourcesFiles.General))]
        public string Summary { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnSummary", ResourceType = typeof(ResourcesFiles.General))]
        public string EnSummary { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Logo", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase LogoFile
        {
            get;
            set;
        }
        [Display(Name = "Slogan", ResourceType = typeof(ResourcesFiles.General))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "SloganRequired")]
        public string Sologan { get; set; }
        [Display(Name = "EnSlogan", ResourceType = typeof(ResourcesFiles.General))]
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishSloganRequired")]
        public string EnSologan { get; set; }
        public int? CountryID { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CityID { get; set; }
        [Display(Name = "District", ResourceType = typeof(ResourcesFiles.General))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DistrictNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        public int? DistrictID { get; set; }
        [Display(Name = "Longitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Longitude { get; set; }
        [Display(Name = "Latitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Latitude { get; set; }

    }
}