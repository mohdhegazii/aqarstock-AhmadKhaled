using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Advertisement
    {
        string _Name;
        string _URL;
        string _ContentAd;
        string _HomepageLeftAd;
        string _HomePageMainAd;
        string _HomePageMainSmallAd;

        [DataMember]
        public string HomePageMainSmallAd
        {
            get { return _HomePageMainSmallAd; }
            set { _HomePageMainSmallAd = value; }
        }

        [DataMember]
        public string HomePageMainAd
        {
            get { return _HomePageMainAd; }
            set { _HomePageMainAd = value; }
        }

        [DataMember]
        public string HomepageLeftAd
        {
            get { return _HomepageLeftAd; }
            set { _HomepageLeftAd = value; }
        }

        [DataMember]
        public string ContentAd
        {
            get { return _ContentAd; }
            set { _ContentAd = value; }
        }

        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Advertisement(BrokerDLL.Advertisement Ad)
        {
        _Name=Ad.Name;
            _URL=Ad.URL;
            _HomepageLeftAd = Ad.HomePageSide.Replace("~/", "");
            _HomePageMainAd = Ad.HomePageMainLarge.Replace("~/", "");
            _HomePageMainSmallAd = Ad.HomePageMainSmall.Replace("~/", "");
            _ContentAd=Ad.ContentSide.Replace("~/","");
        }
    }
}
