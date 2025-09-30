using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Telerik.Web.UI;

namespace BrokerWeb.Services
{
    /// <summary>
    /// Summary description for AutoComplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : System.Web.Services.WebService
    {

        [WebMethod]
        public AutoCompleteBoxData BindDistricts(RadAutoCompleteContext context)
        {
            string searchString = ((Dictionary<string, object>)context)["Text"].ToString();
            List<AutoCompleteBoxItemData> result = new List<AutoCompleteBoxItemData>();
            AutoCompleteBoxItemData childNode;
            List<BrokerDLL.Address> Addresses = BrokerDLL.Commons.Context.Addresses.Where(D => D.FullName.StartsWith(searchString)).OrderBy(A => A.FullName).ToList();
            foreach (BrokerDLL.Address D in Addresses)
            {
                childNode = new AutoCompleteBoxItemData();
                childNode.Text = D.FullName;
                childNode.Value = D.ID.ToString();
            }
            AutoCompleteBoxData res = new AutoCompleteBoxData();
            res.Items = result.ToArray();
            return res;
        }
    }
}
