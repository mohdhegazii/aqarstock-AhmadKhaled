using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using BrokerDLL.Serializable;
using System.Web.Script.Services;
using System.Configuration;

namespace BrokerWeb.Services
{
    /// <summary>
    /// Summary description for General
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class General : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetDistricts()
        {
            List<District> Districts = new List<District>();
            BrokerDLL.Commons.Context.Districts.OrderBy(D => D.City.Country.Name).ThenBy(D => D.City.Name).ThenBy(D => D.Name)
                .ToList().ForEach(D => Districts.Add(new District(D.ID, D.FullName)));
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            //string SerializedDistricts = JsonConvert.SerializeObject(Districts);
            string SerializedDistricts = serialize.Serialize(Districts);
            return SerializedDistricts;
        }

     

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetPaymentTypes()
        {
            List<PaymentType> PaymentTypes = new List<PaymentType>();
            BrokerDLL.Commons.Context.PaymentTypes.OrderBy(P => P.Title).ToList()
                .ForEach(P => PaymentTypes.Add(new PaymentType(P.ID, P.Title)));
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            return serialize.Serialize(PaymentTypes);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetCurrencies()
        {
            List<Currency> Currencies = new List<Currency>();
            BrokerDLL.Commons.Context.Currencies.OrderBy(C => C.Name).ToList()
                .ForEach(C => Currencies.Add(new Currency(C.ID, C.Name)));
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            return serialize.Serialize(Currencies);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetSaleTypes()
        {
            List<SaleType> SaleTypes = new List<SaleType>();
            BrokerDLL.Commons.Context.SaleTypes.OrderBy(S => S.Title).ToList()
                .ForEach(S => SaleTypes.Add(new SaleType(S.ID, S.Title)));
            JavaScriptSerializer Serialize = new JavaScriptSerializer();
            return Serialize.Serialize(SaleTypes);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ContactUs(string Name, string Phone, string Email, string Message)
        {
            Dictionary<string, string> Msg = new Dictionary<string, string>();
            Msg.Add("Name", Name);
            Msg.Add("Phone", Phone);
            Msg.Add("Email", Email);
            Msg.Add("Message", Message);
            BrokerDLL.Commons.SendEmail(BrokerDLL.EmailType.ContactUs, ConfigurationSettings.AppSettings["ContactUsEMail"].ToString(), Msg);
            return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
        }
    }
}
