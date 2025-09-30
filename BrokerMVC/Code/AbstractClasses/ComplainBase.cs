using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class ComplainBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string ComplainerName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PhoneRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Phone", ResourceType = typeof(ResourcesFiles.General))]
        public string ComplainerPhone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
         ErrorMessageResourceName = "EmailRequired")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidEmail")]
        [Display(Name = "Email", ResourceType = typeof(ResourcesFiles.General))]
        public string ComplainerEmail { get; set; }
    }
}