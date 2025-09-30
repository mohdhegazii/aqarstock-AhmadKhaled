using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class AddRealEstateAditionalData
    {
        public int? ID { get; set; }
        public string RealestateName { get; set; }
        public List<RealEstateTypeCriteria> TypeCriterias { get; set; }
        public bool UseContactInfo { get; set; }
        public OwnerData Owner { get; set; }

        public IEnumerable<HttpPostedFileBase> PhotosUpload
        {
            get;
            set;
        }

        public AddRealEstateAditionalData()
        {
            TypeCriterias=new List<RealEstateTypeCriteria>();
        }
    }
}