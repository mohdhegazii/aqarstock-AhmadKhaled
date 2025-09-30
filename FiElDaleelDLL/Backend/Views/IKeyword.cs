using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
   public interface IKeyword:IView
    {
       int KeywordID { get; set; }
       void BindKeywordsList(List<Keyword> Keywords);
       Keyword FillKeywordObject();
       void FillKeywordControls(Keyword keyword);
    }
}
