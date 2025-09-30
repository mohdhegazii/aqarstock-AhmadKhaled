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
    public partial class ProjectDetails : AqarPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnID.Value = Request.RequestContext.RouteData.Values["ID"].ToString();
            BrokerWeb.Services.ProjectService service = new Services.ProjectService();
            BrokerDLL.Serializable.Project project = service.GetProject(hdnID.Value.ToString());
            //List<BrokerDLL.Serializable.ProjectPhotos> Photos = service.GetProjectPhotos(project.ID.ToString());
            FillControls(project);
            FillMetaTags(service, project);
        }

        private void FillMetaTags(Services.ProjectService service, BrokerDLL.Serializable.Project project)
        {
            Page.Title = project.ProjectName + " - عقار ستوك | محرك بحث عقارى | شقق وفيلات واراضى | للبيع والإيجار ";
            Page.MetaDescription = project.Description;
            //Page.MetaKeywords = keywords;
            Header.Controls.Add(new HtmlMeta { Name = "twitter:card", Content = "summary" });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:title", Content = project.ProjectName });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:description", Content = project.Summary });
            Header.Controls.Add(new HtmlMeta { Name = "twitter:image", Content = ConfigurationSettings.AppSettings["WebSite"] + project.DefaultPhoto });
            Header.Controls.Add(new HtmlMeta { Name = "og:type", Content = "article" });
            Header.Controls.Add(new HtmlMeta { Name = "og:title", Content = project.ProjectName });
            Header.Controls.Add(new HtmlMeta { Name = "og:url", Content = Page.Request.Url.AbsoluteUri });
            Header.Controls.Add(new HtmlMeta { Name = "og:description", Content = project.Summary });

            Header.Controls.Add(new LiteralControl("<meta itemprop = 'name' Content ='" + project.ProjectName + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'description' Content ='" + project.Summary + "'>"));
            Header.Controls.Add(new LiteralControl("<meta itemprop = 'image' Content ='" + ConfigurationSettings.AppSettings["WebSite"] + project.DefaultPhoto + "'>"));
            Header.Controls.Add(new HtmlMeta { Name = "og:image", Content = ConfigurationSettings.AppSettings["WebSite"] + project.DefaultPhoto });
        }

        private void FillControls(BrokerDLL.Serializable.Project project)
        {
            lblAddress.Text = project.Address;
            lblDescription.Text = project.Description;
            //lblPhone.Text = project.Phone;
            lblTitle.Text = project.ProjectName;
            lblCompanyName.Text = project.CompanyName;
            imgLogo.Src = ConfigurationSettings.AppSettings["WebSite"] + project.Logo;
            imgLogo.Alt = imgLogo.Alt = "عقار ستوك - " + project.ProjectName;
            lnkCompanyURL.NavigateUrl = "/شركات_عقارية/" + project.CompanyURL;
            hdnLat.Value = project.Latitude;
            hdnLng.Value = project.Longitude;
        }
    }
}