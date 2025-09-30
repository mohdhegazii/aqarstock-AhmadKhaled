using BrokerMVC.Code.AbstractClasses;
using BrokerMVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models
{
    public partial class Subscriber: SubscriberBase
    {
        Suspend _SuspendData;
        public Suspend SuspendData
        {
            get
            {
                if(_SuspendData==null)
                {
                    _SuspendData = new Suspend();
                    _SuspendData.ID = this.ID;
                    _SuspendData.Message = this.SuspendMessage;
                    if (this.SuspendReason != null)
                        _SuspendData.SuspendReason = this.SuspendReason.Title;
                    _SuspendData.SuspendReasonID = this.SuspendReasonID;
                }
                return _SuspendData;
            }
          
                }

        public Password Password { get; set; }

    }
}