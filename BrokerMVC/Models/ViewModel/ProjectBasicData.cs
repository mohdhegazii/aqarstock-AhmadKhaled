using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC.Models.ViewModel
{
    public class ProjectBasicData
    {
        public int ID { get; set; }
        public int? AdPackageID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string Name { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        public string EnName { get; set; }
        [Display(Name = "Slogan", ResourceType = typeof(ResourcesFiles.General))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
              ErrorMessageResourceName = "SloganRequired")]
        public string Slogan { get; set; }
        [Display(Name = "EnSlogan", ResourceType = typeof(ResourcesFiles.General))]
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishSloganRequired")]
        public string EnSlogan { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DescriptionRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
     //   [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(ResourcesFiles.General))]
        [AllowHtml]
        public string Description { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishDescriptionRequired")]
       // [StringLength(1500, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidDescription")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnDescription", ResourceType = typeof(ResourcesFiles.General))]
        [AllowHtml]
        public string EnDescription { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Summary", ResourceType = typeof(ResourcesFiles.General))]
        public string Summary { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "EnSummary", ResourceType = typeof(ResourcesFiles.General))]
        public string EnSummary { get; set; }
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
        public string Longutide { get; set; }
        public string Latitude { get; set; }

        public Suspend SuspendData { get; set; }
        
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
    }
}