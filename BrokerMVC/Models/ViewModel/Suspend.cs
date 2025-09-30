using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class Suspend
    {
        public int ID { get; set; }
        public int? SuspendReasonID { get; set; }
        public string SuspendReason { get; set; }
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}