using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Models.ViewModel
{
    public class SearchCriteria
    {
        //type
        public int TID { get;set; }
        //Country
        public int CID { get;set; }
        //City
        public int CyId { get;set; }
        //district
        public int DID { get;set; }
        //currency
        public int CUID { get;set; }
        //Paymenttype
        public int PID { get;set; }
        //SaleType
        public int SID { get;set; }
        //Status 
        public int STID { get; set; }
        //public bool ForSale { get; set; }
        //public bool ForRent { get; set; }
        public int Price { get;set; }
        public int Area { get;set; }

    }
}