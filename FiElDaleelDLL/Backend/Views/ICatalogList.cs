using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ICatalogList
    {
        int CategoryID { get; set; }
        void FillCategoryList(List<CatalogCategory> Categories);
        void BindList(List<RealEstateCatalog> Catalogs);
        void NotifyUser(Message Msg, MessageType Type);
        void NotifyUser(string Msg, MessageType Type);

    }
}
