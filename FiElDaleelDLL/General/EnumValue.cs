using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BrokerDLL.General
{
   public class EnumValue:Attribute
    {
       public string StringValue { get; protected set; }
       public EnumValue(string value)
       {
            this.StringValue = value;
        }

    }
}
