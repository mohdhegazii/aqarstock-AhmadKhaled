using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
     public interface ICatalogCategory : IView
    {
        int CategoryID { get; set; }
        void BindList(List<CatalogCategory> Categories);
        CatalogCategory FillCategoryObject();
        void FillCategoryControls(CatalogCategory Category);
    }
}
