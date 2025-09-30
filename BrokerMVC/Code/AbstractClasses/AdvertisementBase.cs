using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.AbstractClasses
{
    public abstract class AdvertisementBase
    {
        int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "URLRequired")]
        [Display(Name = "URL", ResourceType = typeof(ResourcesFiles.General))]
        string URL { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "AdContentSideImage", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase ContentSideFile
        {
            get;
            set;
        }
        [DataType(DataType.Upload)]
        [Display(Name = "AdHomePageSide", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase HomePageSideFile
        {
            get;
            set;
        }
        [DataType(DataType.Upload)]
        [Display(Name = "AdHomePageMainLarge", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase HomePageMainLargeFile
        {
            get;
            set;
        }
        [DataType(DataType.Upload)]
        [Display(Name = "AdHomePageMainSmall", ResourceType = typeof(ResourcesFiles.General))]
        public HttpPostedFileBase HomePageMainSmallFile
        {
            get;
            set;
        }
    }
}