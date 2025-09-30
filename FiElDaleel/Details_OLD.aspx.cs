using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BrokerWeb
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnID.Value=Request.RequestContext.RouteData.Values["ID"].ToString();
                BrokerWeb.Services.RealEstateService service = new Services.RealEstateService();
                BrokerDLL.Serializable.RealEstate realestate= service.GetRealEstate(hdnID.Value.ToString());
                lblTitle.Text = realestate.Name;
                lblType.Text = realestate.Type;
                lblSaleType.Text = realestate.SaleType;
                lblDescription.InnerText = realestate.Description;
                lblAddress.Text = realestate.Address;
                lblPaymentType.Text = realestate.PaymentType;
                lblStatus.Text = realestate.Status;
                lblPrice.Text = realestate.Price + ' ' + realestate.Currency;
                lblArea.Text = realestate.Area + ' ' + "م²";
                imgLogo.Src = ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo;
                hdnLat.Value = realestate.Latitude;
                hdnLng.Value = realestate.Longitude;
                string keywords=""; 
                service.GetRealEstateKeywords(hdnID.Value).ForEach(k=>keywords+=k.Keyword+",");
                Page.Title = realestate.Name + " - عقار ستوك :  سوق تداول العقارات | التجمع | الشروق | أكتوبر | زايد | الساحل وكل مدن مصر - AqarStock.com : Egypt Real Estate Stock";
                Page.MetaDescription = realestate.Description;
                //Page.MetaKeywords = keywords;
                Header.Controls.Add(new HtmlMeta { Name = "twitter:card", Content = "summary" });
                Header.Controls.Add(new HtmlMeta { Name = "twitter:title", Content = realestate.Name });
                Header.Controls.Add(new HtmlMeta { Name = "twitter:url", Content = Page.Request.Url.AbsoluteUri });
                Header.Controls.Add(new HtmlMeta { Name = "twitter:description", Content = realestate.Description });
                Header.Controls.Add(new HtmlMeta { Name = "twitter:image", Content = ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo });
                Header.Controls.Add(new HtmlMeta { Name = "og:type", Content = "article" });
                Header.Controls.Add(new HtmlMeta { Name = "og:title", Content = realestate.Name });
                Header.Controls.Add(new HtmlMeta { Name = "og:url", Content = Page.Request.Url.AbsoluteUri });
                Header.Controls.Add(new HtmlMeta { Name = "og:description", Content = realestate.Description });
                Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo });
                Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + realestate.Name + "'>"));
                Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + realestate.Description + "'>"));
                Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo + "'>"));
              
            }

        }

        public string Validatestring(string word)
        {
            return (Regex.Replace(word, "[^0-9a-zA-Zء-ي]+", "-"));
            //SpecialCharacterUnicode SCCoder = new SpecialCharacterUnicode();
            //return SCCoder.Encoder(word);
        }
    }
}