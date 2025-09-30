using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace BrokerDLL.Serializable
{
    [DataContract]
   public class ProjectPhotos
    {
        int _ID;
        string _PhotoURL;
        string _Description;
        string _Date;
        string _ProjectName;

        [DataMember]
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        [DataMember]
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public string PhotoURL
        {
            get { return _PhotoURL; }
            set { _PhotoURL = value; }
        }

        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public ProjectPhotos(BrokerDLL.RealEstateProjectPhoto Photo)
        {
            _ID = Photo.ID;
            _Description = Photo.Description;
            _Date = Photo.Date.Value.ToString("dd-MM-yyyy");
            if(Photo.PhotoURL!="")
            { 
            _PhotoURL = Photo.PhotoURL.Replace("~/", "");
            }
            _ProjectName =Photo.RealEstateProject.Title;
        }
    }
}
