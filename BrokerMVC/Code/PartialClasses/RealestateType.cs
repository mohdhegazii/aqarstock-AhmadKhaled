using BrokerMVC.Code.AbstractClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class RealEstateType : TypeBase
    {
        HttpPostedFileBase _IconFile;
        [DataType(DataType.Upload)]
        [Display(Name = "Icon", ResourceType = typeof(ResourcesFiles.General))]
       public HttpPostedFileBase IconFile {
            get
            {
                return _IconFile;
            }
            set
            {
                _IconFile = value;
            }
        }
    }
}