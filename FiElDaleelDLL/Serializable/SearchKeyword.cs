using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class SearchKeyword
    {
        string _Keyword;
        string _URL;
        List<SearchKeyword> _ChildKeywords;

        [DataMember]
        public List<SearchKeyword> ChildKeywords
        {
            get { return _ChildKeywords; }
            set { _ChildKeywords = value; }
        }
        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        [DataMember]
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }
        public SearchKeyword(BrokerDLL.SearchKeyword Keyword)
        {
            _Keyword = Keyword.Keywords;
            _URL = Keyword.URL;
            if (Keyword.ChildKeywords.Count > 0)
            {
                _ChildKeywords = new List<SearchKeyword>();
                Keyword.ChildKeywords.ToList().ForEach(K => _ChildKeywords.Add(new SearchKeyword(K)));
            }
        }
    }
}
