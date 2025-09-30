using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface IRealEstatePhotos:IView
    {
        int RealEstateID { get; set; }
        void BindPhotoList(List<RealEstatePhoto> Photos);
        RealEstatePhoto FillRealEstatePhotoObject(string Title);
        void UploadRealEstatePhoto(string Title);
    }
}
