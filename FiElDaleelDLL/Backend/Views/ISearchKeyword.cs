using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.Backend.Views
{
    public interface ISearchKeyword:IView
    {
        int KeywordId { get; set; }
        void BindList(List<SearchKeyword> Keywords);
        SearchKeyword FillObject(SearchKeyword Keyword);
        void FillControls(SearchKeyword keyword);
        void FillParentKeywordsList(List<SearchKeyword> Parents);
    }
}
