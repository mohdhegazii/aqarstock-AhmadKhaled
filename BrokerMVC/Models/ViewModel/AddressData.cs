using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class AddressData
    {
        public int ID { get; set; }

        [Display(Name = "Name", ResourceType = typeof(ResourcesFiles.General))]
        public string Name { get; set; }
        public string Logo { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CountryID { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(ResourcesFiles.General))]
        public int? CityID { get; set; }
        [Display(Name = "District", ResourceType = typeof(ResourcesFiles.General))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "DistrictNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        public int? DistrictID { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "StreetNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Street", ResourceType = typeof(ResourcesFiles.General))]
        public string Street { get; set; }
       // [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EnglishStreetNameRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "EnStreet", ResourceType = typeof(ResourcesFiles.General))]
        public string EnStreet { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "LongitudeRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Longitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Longitude { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "LatitudeRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]
        [Display(Name = "Latitude", ResourceType = typeof(ResourcesFiles.General))]
        public string Latitude { get; set; }
    }
}