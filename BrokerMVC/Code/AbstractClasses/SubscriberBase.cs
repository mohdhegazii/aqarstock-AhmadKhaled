using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public class SubscriberBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string FullName { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        public string EnFullName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Phone", ResourceType = typeof(ResourcesFiles.General))]
        public string MobileNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
         ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidEmail")]
        [Display(Name = "Email", ResourceType = typeof(ResourcesFiles.General))]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "UserName", ResourceType = typeof(ResourcesFiles.General))]
        public string UserName { get; set; }
    }
}