using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IRealEstateCategory:IView
    {
        int CategoryId { get; set; }
        void BindCategoriesList(List<RealEstateCategory> Categories);
        RealEstateCategory FillCategoryObject();
        void FillCategoryControls(RealEstateCategory Category);
        void UploadCategoryIcon();
    }
}
