using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IProjectModel:IView
    {
       int ProjectID { get;set;}
       int ModelID { get; set; }
       void FillRealEstateTypeList(List<RealEstateType> Type);
       void BindList(List<RealEstateProjectModel> Models);
       RealEstateProjectModel FillObject(RealEstateProjectModel Model, string Code,string random);
       void FillControls(RealEstateProjectModel Model);
       void UpLaod(string Code,string random);
    }
}
