using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstateTypeCriteria:IView
    {
        int RealEstateCriteriaID { get; set; }

        RealEstateTypeCriteria FillRealEstateTypeCriteriaObject();
        void FillRealEstateTypeCriteriaControls(RealEstateTypeCriteria Criteria);
        void BindRealEstateTypeCriteriaList(List<RealEstateTypeCriteria> Criterias);
        void FillCategoryList(List<RealEstateCategory> Categories);
        void FillTypeList(List<RealEstateType> Types);
    }
}
