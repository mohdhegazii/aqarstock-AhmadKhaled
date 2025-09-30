using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BrokerDLL.Serializable
{
    [DataContract]
    public class ProjectModel
    {
        int _ID;
        string _Type;
        string _Name;
        string _Description;
        string _Area;
        string _Price;
        string _PlanImageURL;
        string _URL;
        string _ProjectName;
        string _ProjectLogo;

        [DataMember]
        public string ProjectLogo
        {
            get { return _ProjectLogo; }
            set { _ProjectLogo = value; }
        }

        [DataMember]
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        [DataMember]
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        [DataMember]
        public string PlanImageURL
        {
            get { return _PlanImageURL; }
            set { _PlanImageURL = value; }
        }

        [DataMember]
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        [DataMember]
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [DataMember]
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        [DataMember]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public ProjectModel(BrokerDLL.RealEstateProjectModel Model)
        {
            _Area = Model.Area.ToString();
            _Description = Model.Description;
            _ID = Model.ID;
            _Name = Model.Title;
            _PlanImageURL = Model.PlanImgURL.Replace("~/", "");
            _Price = Model.Price.ToString();
            _Type = Model.RealEstateType.Title;
            _URL = Regex.Replace(Model.Title, "[^0-9a-zA-Zء-ي]+", "-");
            _ProjectName = Model.RealEstateProject.Title;
            _ProjectLogo = Model.RealEstateProject.Logo.Replace("~/", "");
        }
    }
}
