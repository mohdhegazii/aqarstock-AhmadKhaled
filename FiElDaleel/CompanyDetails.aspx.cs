using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace BrokerWeb
{
    public partial class CompanyDetails : AqarPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnID.Value = Request.RequestContext.RouteData.Values["ID"].ToString();
                BrokerWeb.Services.GeneraLService service = new Services.GeneraLService();
                BrokerDLL.Serializable.Company company = service.GetCompany(hdnID.Value.ToString());
                //List<BrokerDLL.Serializable.RealEstatePhoto> Photos = service.GetRealEstatePhotos(company.ID.ToString());
                FillControls(company);
                FillMetaTags(service, company);
            }
        }

        private void FillMetaTags(Services.GeneraLService service, BrokerDLL.Serializable.Company company)
        {
            Page.Title = company.Name + " - عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار ";
            Page.MetaDescription = company.Description;
            //Page.MetaKeywords = keywords;
            Header.Controls.Add(new HtmlMeta { Name = "twitter:card", Content = "summary" });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:title", Content = company.Name });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:description", Content = company.Summary });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:image", Content = ConfigurationSettings.AppSettings["WebSite"] + company.Logo });
            Header.Controls.Add(new HtmlMeta { Name = "og:type", Content = "article" });
            Header.Controls.Add(new HtmlMeta { Name = "og:title", Content = company.Name });
            Header.Controls.Add(new HtmlMeta { Name = "og:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "og:description", Content = company.Summary });

            Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + company.Name + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + company.Summary + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + company.Logo + "'>"));
            Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + company.Logo });
        }

        private void FillControls(BrokerDLL.Serializable.Company company)
        {
            lblAddress.Text = company.Address;
            lblDescription.Text = company.Description;
            lblPhone.Text = company.Phone;
            lblTitle.Text = company.Name;
            imgLogo.Src = ConfigurationSettings.AppSettings["WebSite"] + company.Logo;
            imgLogo.Alt = imgLogo.Alt = "عقار ستوك - " + company.Name;
            hdnLat.Value = company.Latitude;
            hdnLng.Value = company.Longitude;
        }
    }
}