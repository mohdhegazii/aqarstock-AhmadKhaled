using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ITag: IView
    {
        int TagId { get; set; }
        void BindList(List<Tag> Keywords);
        Tag FillObject(Tag Keyword);
        void FillControls(Tag keyword);
        void FillParentTagsList(List<Tag> Parents);
    }
}
