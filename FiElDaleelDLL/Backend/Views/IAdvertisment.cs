using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IAdvertisment:IView
    {
         int AdvertisementID { get; set; }
         void BindList(List<Advertisement> Ads);
         Advertisement FillObject(Advertisement Ad, string random);
         void FillControls(Advertisement Ad);
         void UpLaod(string Code, string random);
    }
}
