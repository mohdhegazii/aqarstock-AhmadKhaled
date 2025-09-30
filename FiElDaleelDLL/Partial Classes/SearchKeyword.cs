using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
    public partial class SearchKeyword
    {
        public virtual string ParentKeyword
        {
            get
            {
                if (this.Parent != null)
                {
                    return this.Parent.Keywords;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
