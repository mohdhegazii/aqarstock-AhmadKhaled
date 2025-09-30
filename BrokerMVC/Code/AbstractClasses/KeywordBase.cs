using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class KeywordBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "KeywordRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "keyword", ResourceType = typeof(ResourcesFiles.General))]
        string Keywords { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "URLRequired")]
        [Display(Name = "URL", ResourceType = typeof(ResourcesFiles.General))]
        Nullable<int> URL { get; set; }
    }
}