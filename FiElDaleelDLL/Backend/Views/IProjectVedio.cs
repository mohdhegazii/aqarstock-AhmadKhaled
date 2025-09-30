using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IProjectVedio:IView
    {
       int ProjectID { get; set; }
       int VideoID { get; set; }
       void BindList(List<RealEstateProjectVideo> Videos);
       RealEstateProjectVideo FillObject(RealEstateProjectVideo Vedio);
       void FillControls(RealEstateProjectVideo Vedio);
    }
}
