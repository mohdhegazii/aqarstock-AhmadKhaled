using BrokerDLL.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Serializable;
using BrokerWeb.Services;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace BrokerWeb
{
    public partial class CatalogDetails : AqarPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnID.Value = Request.RequestContext.RouteData.Values["ID"].ToString();
                BrokerWeb.Services.GeneraLService service = new Services.GeneraLService();
                BrokerDLL.Serializable.Catalog catalog = service.GetCatalog(hdnID.Value.ToString());
                //List<BrokerDLL.Serializable.RealEstatePhoto> Photos = service.GetRealEstatePhotos(catalog.ID.ToString());
                FillControls(catalog);
                FillMetaTags(service, catalog);
            }
        }

        private void FillMetaTags(GeneraLService service, Catalog catalog)
        {
            Page.Title = catalog.Name + " - عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار ";
            Page.MetaDescription = catalog.Description;
            //Page.MetaKeywords = keywords;
            Header.Controls.Add(new HtmlMeta { Name = "twitter:card", Content = "summary" });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:title", Content = catalog.Name });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:description", Content = catalog.Description });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:image", Content = ConfigurationSettings.AppSettings["WebSite"] + catalog.PhotoURL });
            Header.Controls.Add(new HtmlMeta { Name = "og:type", Content = "article" });
            Header.Controls.Add(new HtmlMeta { Name = "og:title", Content = catalog.Name });
            Header.Controls.Add(new HtmlMeta { Name = "og:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "og:description", Content = catalog.Description });

            Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + catalog.Name + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + catalog.Description + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + catalog.PhotoURL + "'>"));
            Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + catalog.PhotoURL });
        }

        private void FillControls(Catalog catalog)
        {
            lblTitle.Text = catalog.Name;
            lblDescription.Text = catalog.Description;
            divTagList.InnerHtml = catalog.Tags;
            imgLogo.Src = ConfigurationSettings.AppSettings["WebSite"] + catalog.PhotoURL;
            imgLogo.Alt = imgLogo.Alt = "عقار ستوك - " + catalog.Name;
        }
    }
}