using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class PhotoBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        public string Description { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishDescriptionRequired")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnDescription", ResourceType = typeof(ResourcesFiles.General))]
        public string EnDescription { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Image", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase PhotoFile
        {
            get;
            set;
        }
    }
}