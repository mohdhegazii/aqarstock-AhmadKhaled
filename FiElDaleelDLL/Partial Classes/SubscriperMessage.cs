using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class SubscriperMessage
    {
        public virtual string Type
        {
            get
            {
                if (this.SubscriperMessageType != null)
                {
                    return this.SubscriperMessageType.Title;
                }
                else
                {
                    return "";
                }
            }
        }

    }
}
