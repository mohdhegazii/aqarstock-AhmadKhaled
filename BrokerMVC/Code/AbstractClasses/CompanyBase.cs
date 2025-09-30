using BrokerMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class CompanyBase
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

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SummaryRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Summary", ResourceType = typeof(ResourcesFiles.General))]
        public string Summary { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnSummaryRequired")]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnSummary", ResourceType = typeof(ResourcesFiles.General))]
        public string EnSummary { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        public string Description { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishDescriptionRequired")]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnDescription", ResourceType = typeof(ResourcesFiles.General))]
        public string EnDescription { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Phone", ResourceType = typeof(ResourcesFiles.General))]
        public string Phone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidEmail")]
        [Display(Name = "Email", ResourceType = typeof(ResourcesFiles.General))]
        public string Email { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Logo", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase LogoFile
        {
            get;
            set;
        }
        public int? CountryId { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CityId { get; set; }
        [Display(Name = "District", ResourceType = typeof(ResourcesFiles.General))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DistrictNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        public int? DistrictId { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StreetNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Street", ResourceType = typeof(ResourcesFiles.General))]
        public string Street { get; set; }
        // [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EnglishStreetNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "EnStreet", ResourceType = typeof(ResourcesFiles.General))]
        public string Entreet { get; set; }

        [Display(Name = "Longitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Longutide { get; set; }
        [Display(Name = "Latitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Latitude { get; set; }
        public Suspend SuspendData { get; set; }
    }
}