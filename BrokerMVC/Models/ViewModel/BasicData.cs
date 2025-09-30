using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class BasicData
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        public string EnName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SummaryRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(1500, MinimumLength =  10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Summary", ResourceType = typeof(ResourcesFiles.General))]
        public string Summary { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "EnSummaryRequired")]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnSummary", ResourceType = typeof(ResourcesFiles.General))]
        public string EnSummary { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "EnglishDescriptionRequired")]
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

        public bool IsSpecial { get; set; }
        public string Logo { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Logo", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase LogoFile
        {
            get;
            set;
        }

        [Display(Name = "Address", ResourceType = typeof(ResourcesFiles.General))]
        public string Address { get; set; }
        [Display(Name = "Longitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Longutide { get; set; }
        [Display(Name = "Latitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Latitude { get; set; }
        public Suspend SuspendData { get; set; }
    }
}