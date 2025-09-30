using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class CatlogsCriteria
    {
        public int CategoryID
        {
            get;

            set;
        }
        public int TypeID
        {
            get;

            set;
        }
        public int CountryID
        {
            get;

            set;
        }
        public int CityID
        {
            get;

            set;
        }
        public int DistrictID
        {
            get;

            set;
        }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
       [Display(Name = "CatalogsNames", ResourceType = typeof(ResourcesFiles.General))]
        public string CatlogsNames { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "ParagraphNo", ResourceType = typeof(ResourcesFiles.General))]

        public int ParagraphNo
        {
            get;

            set;
        }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "OccuranceNo", ResourceType = typeof(ResourcesFiles.General))]
        public int OccuranceNo
        {
            get;

            set;
        }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "WordsNo", ResourceType = typeof(ResourcesFiles.General))]
        public int WordNo { get; set; }

        public string GeneralLink
        {
            get;

            set;
        }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "KeywordLink", ResourceType = typeof(ResourcesFiles.General))]

        public string KeywordLink
        {
            get;

            set;
        }

        public string Headers
        {
            get;
            set;
        }

    }
}