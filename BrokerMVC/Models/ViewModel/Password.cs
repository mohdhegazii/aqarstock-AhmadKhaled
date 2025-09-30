using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class Password
    {
        public int? ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]

        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "ConfirmPassword", ErrorMessageResourceType = typeof(ResourcesFiles.Messages))]

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}