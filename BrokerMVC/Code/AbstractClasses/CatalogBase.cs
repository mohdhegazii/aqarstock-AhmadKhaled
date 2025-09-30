using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class CatalogBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        public string Description { get; set; }
        [AllowHtml]
        string Tag { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase PhotoFile
        {
            get;
            set;
        }
    }
}