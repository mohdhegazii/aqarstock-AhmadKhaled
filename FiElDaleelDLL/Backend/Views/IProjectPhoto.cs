using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IProjectPhoto:IView
    {
       int ProjectID { get; set; }
       int PhotoID { get; set; }
       void BindList(List<RealEstateProjectPhoto> Photos);
       RealEstateProjectPhoto FillObject(RealEstateProjectPhoto Photo, string Code,string random);
       void FillControls(RealEstateProjectPhoto Photo);
       void UpLaod(string Code,string random);
    }
}
