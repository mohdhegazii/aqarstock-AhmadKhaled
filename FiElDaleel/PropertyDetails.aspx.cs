using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace BrokerWeb
{
    public partial class PropertyDetails : AqarPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                hdnID.Value = Request.RequestContext.RouteData.Values["ID"].ToString();
                BrokerWeb.Services.RealEstateService service = new Services.RealEstateService();
                BrokerDLL.Serializable.RealEstate realestate = service.GetRealEstate(hdnID.Value.ToString());
                List<BrokerDLL.Serializable.RealEstatePhoto> Photos = service.GetRealEstatePhotos(realestate.ID.ToString());
                FillControls(realestate);
                FillMetaTags(service, realestate, Photos);
            }
        }

        private void FillMetaTags(BrokerWeb.Services.RealEstateService service, BrokerDLL.Serializable.RealEstate realestate, List<BrokerDLL.Serializable.RealEstatePhoto> Photos)
        {
            string keywords = "";
            service.GetRealEstateKeywords(hdnID.Value).ForEach(k => keywords += k.Keyword + ",");
            Page.Title = realestate.Name + " - عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار";
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

            Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + realestate.Name + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + realestate.Description + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo + "'>"));
            if (Photos.Count > 0)
            {
                foreach (BrokerDLL.Serializable.RealEstatePhoto Photo in Photos)
                {
                    Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + Photo.PhotoURL.Replace("../", "") });
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + "images/RealEstateSocial/Aqar-Stock-Sociallogo-" + i + ".png" });
                }
            }
        }

        private void FillControls(BrokerDLL.Serializable.RealEstate realestate)
        {
            hdnURL.Value = realestate.URL;
            lblTitle.Text = realestate.Type + " ";
            lblTitle.Text += realestate.Area != "" && realestate.Area != "0" ? "<b>" + realestate.Area + ' ' + "م</b> " : "";
            lblTitle.Text += "- " + realestate.District + " , " + realestate.City;
            lblAdvTitle.Text = realestate.Name;
            lblType.Text = realestate.Type;
            lblSaleType.Text = realestate.SaleType;
            lblDescription.Text = realestate.Description;
            lblAddress.Text = realestate.Address;
            lblPaymentType.Text = realestate.PaymentType;
            lblStatus.Text = realestate.Status;
            lblPrice.Text = realestate.Price;// +' ' + realestate.Currency;
            lblArea.Text =realestate.Area != "" && realestate.Area != "0" ? realestate.Area + ' ' + "م":"";
            lblCategory.Text = realestate.Category;
            lblCurrency.Text = realestate.Currency;
            lblDate.Text = realestate.Date;
            imgLogo.Src = ConfigurationSettings.AppSettings["WebSite"] + realestate.Logo;
            imgLogo.Alt = "عقار ستوك - " + realestate.Name;
            hdnLat.Value = realestate.Latitude;
            hdnLng.Value = realestate.Longitude;
            hdnCompanyName.Value = realestate.OwnerName;
            hdnCompanyPhone.Value = realestate.OwnerPhone;
            hdnSubscriberID.Value = realestate.SubscriberID;
        }


        public string Validatestring(string word)
        {
            return (Regex.Replace(word, "[^0-9a-zA-Zء-ي]+", "-"));
            //SpecialCharacterUnicode SCCoder = new SpecialCharacterUnicode();
            //return SCCoder.Encoder(word);
        }
    }
}