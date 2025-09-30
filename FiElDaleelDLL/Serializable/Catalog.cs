using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class Catalog
    {
        int _ID;
        string _Name;
        string _Description;
        string _PhotoURL;
        string _SocialPhotoURL;
        List<RealEstate> _Properties;
        string _Tags;

        [DataMember]
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        [DataMember]
        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
            }
        }

        [DataMember]
        public string PhotoURL
        {
            get
            {
                return _PhotoURL;
            }

            set
            {
                _PhotoURL = value;
            }
        }

        [DataMember]
        public List<RealEstate> Properties
        {
            get
            {
                return _Properties;
            }

            set
            {
                _Properties = value;
            }
        }

        [DataMember]
        public string SocialPhotoURL
        {
            get
            {
                return _SocialPhotoURL;
            }

            set
            {
                _SocialPhotoURL = value;
            }
        }

        public string Tags
        {
            get
            {
                return _Tags;
            }

            set
            {
                _Tags = value;
            }
        }

        public Catalog (RealEstateCatalog catalog)
        {
            _ID = catalog.ID;
            _Name = catalog.Title;
            _PhotoURL = catalog.PhotoURL.Replace("~/", "") ;
            //_SocialPhotoURL = catalog.SocialPhotoURL.Replace("/~", "");
            _Description = catalog.Description;
            _Tags = catalog.Tag;
            //RealEstate realestate;
            //_Properties = new List<RealEstate>();
            //foreach (RealestateCatalogProperty Prop in catalog.RealestateCatalogProperties)
            //{
            //    realestate = new RealEstate(Prop.RealEstate);
            //    _Properties.Add(realestate);
                
            //}

        }
    }
}
