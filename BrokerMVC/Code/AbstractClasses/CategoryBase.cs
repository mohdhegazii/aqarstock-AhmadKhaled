using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class CategoryBase
    {
        int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        string Title { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        string EnTitle { get; set; }
    }
}