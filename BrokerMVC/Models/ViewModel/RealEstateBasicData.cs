using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class RealEstateBasicData
    {
        public int ID { get; set; }
        public string Code { get; set; }
        [Display(Name = "SaleType", ResourceType = typeof(ResourcesFiles.General))]
        public int? SaleTypeId { get; set; }

        [Display(Name = "RealestateCategory", ResourceType = typeof(ResourcesFiles.General))]
        public int? RealEstateCategoryID { get; set; }
        [Display(Name = "RealestateType", ResourceType = typeof(ResourcesFiles.General))]
        public int? RealEstateTypeID { get; set; }
        [Display(Name = "Status", ResourceType = typeof(ResourcesFiles.General))]
        public int? RealEstateStatusID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string Name { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
        //      ErrorMessageResourceName = "EnglishNameRequired")]
        [StringLength(150, MinimumLength = 3, ErrorMessageResourceType = typeof(ResourcesFiles.Messages), ErrorMessageResourceName = "ValidName")]
        [Display(Name = "EnglishName", ResourceType = typeof(ResourcesFiles.General))]
        public string EnName { get; set; }
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
        [Display(Name = "Address", ResourceType = typeof(ResourcesFiles.General))]
        public string Address { get; set; }
        public string Longutide { get; set; }
        public string Latitude { get; set; }
        public bool? IsSpecial { get; set; }
        public bool? IsSold { get; set; }
        public Suspend SuspendData { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
          ErrorMessageResourceName = "PriceRequired")]
        [Display(Name = "Price", ResourceType = typeof(ResourcesFiles.General))]
        
        public int? Price { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ResourcesFiles.Messages),
       ErrorMessageResourceName = "AreaRequired")]
        [Display(Name = "Area", ResourceType = typeof(ResourcesFiles.General))]
        public int? Area { get; set; }
        [Display(Name = "Currency", ResourceType = typeof(ResourcesFiles.General))]
        public int? CurrencyID { get; set; }
        [Display(Name = "PaymentType", ResourceType = typeof(ResourcesFiles.General))]
        public int? PaymentTypeID { get; set; }

        public RealEstateProject Project { get; set; }
        public Subscriber Subscriber { get; set; }
        public OwnerData Owner { get; set; }
    }
}