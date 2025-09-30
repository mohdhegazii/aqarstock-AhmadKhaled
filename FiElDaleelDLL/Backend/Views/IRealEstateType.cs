using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateType:IView
    {
        int RealEstateTypeID { get; set; }
        RealEstateType FillRealEstateTypeObject();
        void FillRealEstateTypeControls(RealEstateType Type);
        void BindRealEstateTypeList(List<RealEstateType> Types);
        void FillCategoryList(List<RealEstateCategory> Categories);
        void UploadRealEstateIcon();
    }
}
