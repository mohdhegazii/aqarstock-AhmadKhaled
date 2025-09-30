using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class OwnerData
    {
        public int? Id { get; set; }
        [Display(Name = "FullName", ResourceType = typeof(ResourcesFiles.General))]
        public string Name { get; set; }
        [Display(Name = "Phone", ResourceType = typeof(ResourcesFiles.General))]
        public string Phone { get; set; }
        [Display(Name = "Email", ResourceType = typeof(ResourcesFiles.General))]
        public string Email { get; set; }
    }
}