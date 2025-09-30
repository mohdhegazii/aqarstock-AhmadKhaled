using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IGenerateCatalogs
    {
        int CategoryID { get; set; }
        string CatalogNames { get; set; }
        string CatalogDescriptions { get; set; }
        void FillCategoryList(List<CatalogCategory> Categories);
        void FillTagCategoryList(List<ContentTagCategory> Categories);
        ContentGenerator FillObject();
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);

    }
}
