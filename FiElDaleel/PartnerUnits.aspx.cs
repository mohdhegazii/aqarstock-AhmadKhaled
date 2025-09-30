using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace BrokerWeb
{
    public partial class PartnerUnits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnID.Value = Request.RequestContext.RouteData.Values["ID"].ToString();
                // hdnTitle.Value = Request.RequestContext.RouteData.Values["Name"].ToString();
                using (BrokerEntities Context = new BrokerDLL.BrokerEntities())
                {
                    int id = Convert.ToInt32(hdnID.Value);
                    Partner partner = Context.Partners.FirstOrDefault(P => P.SubscriberID == id);
                    if (partner != null)
                    {
                        hdnTitle.Value = partner.PageTitle;
                        Page.Title = partner.KeyWords;
                        Page.MetaDescription = partner.Description;
                        //Page.MetaKeywords = keywords;
                        Header.Controls.Add(new HtmlMeta { Name = "twitter:card", Content = "summary" });
                        Header.Controls.Add(new HtmlMeta { Name = "twitter:title", Content = partner.PageTitle });
                        Header.Controls.Add(new HtmlMeta { Name = "twitter:url", Content = Page.Request.Url.AbsoluteUri });
                        Header.Controls.Add(new HtmlMeta { Name = "twitter:description", Content = partner.Description });
                        Header.Controls.Add(new HtmlMeta { Name = "twitter:image", Content = ConfigurationSettings.AppSettings["WebSite"] + partner.Logo });
                        Header.Controls.Add(new HtmlMeta { Name = "og:type", Content = "article" });
                        Header.Controls.Add(new HtmlMeta { Name = "og:title", Content = partner.PageTitle });
                        Header.Controls.Add(new HtmlMeta { Name = "og:url", Content = Page.Request.Url.AbsoluteUri });
                        Header.Controls.Add(new HtmlMeta { Name = "og:description", Content = partner.Description });
                        Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + partner.Logo });
                        Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + partner.PageTitle + "'>"));
                        Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + partner.Description + "'>"));
                        Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + partner.Logo + "'>"));

                    }
                }
            }
        }
    }
}