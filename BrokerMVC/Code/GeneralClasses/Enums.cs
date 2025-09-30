using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC
{
    public class EnumValue : Attribute
    {
        public string StringValue { get; protected set; }
        public EnumValue(string value)
        {
            this.StringValue = value;
        }

    }
    public class EnumEngValue : Attribute
    {
        public string StringValue { get; protected set; }
        public EnumEngValue(string value)
        {
            this.StringValue = value;
        }

    }
    public class Enums
    {
    }
}