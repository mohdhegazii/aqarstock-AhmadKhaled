using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace BrokerMVC
{
    public class SitemapImageNode
    {
        public string Loc { get; set; }
        public string Caption { get; set; }
        public string Title { get; set; }
        
    }
    public class SitemapNode
    {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }
        public string AltURL { get; set; }
        public List<SitemapImageNode> Images { get; set; }
        public bool EncodeURL { get; set; }
    }

    public enum SitemapFrequency
    {
        Never,
        Yearly,
        Monthly,
        Weekly,
        Daily,
        Hourly,
        Always
    }
    public class SiteMapGenerator
    {
        public XmlDocument GenerateSiteMapIndexFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("sitemapindex");// Create the root element with attributes

            root.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            root.SetAttribute("xmlns:image", "http://www.google.com/schemas/sitemap-image/1.1");
            root.SetAttribute("xmlns:video", "http://www.google.com/schemas/sitemap-video/1.1");
            root.SetAttribute("xmlns:mobile", "http://www.google.com/schemas/sitemap-mobile/1.0");
            root.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            root.SetAttribute("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

            doc.AppendChild(root);
            doc.Save(HttpContext.Current.Server.MapPath("~") + "/Sitemap.Xml");
            return doc;
        }
        public bool AddSitemapNodes(IEnumerable<SitemapNode> sitemapNodes, string DocumentPath)
        {
            XDocument doc = new XDocument();
            // doc.Load(DocumentPath);
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XNamespace Image = "http://www.google.com/schemas/sitemap-image/1.1";
            XNamespace xhtml = "http://www.w3.org/1999/xhtml";

            XElement root = new XElement(xmlns + "urlset"
                , new XAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9")
                , new XAttribute(XNamespace.Xmlns + "image", "http://www.google.com/schemas/sitemap-image/1.1")
                , new XAttribute(XNamespace.Xmlns + "mobile", "http://www.google.com/schemas/sitemap-mobile/1.0")
                , new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance")
                , new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema")
                //, new XAttribute(XNamespace.Xmlns + "schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd")
                , new XAttribute(XNamespace.Xmlns + "xhtml", "http://www.w3.org/1999/xhtml"));

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc",Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.AltURL == null ? null : new XElement(xhtml + "link", new XAttribute("rel", "alternate"), new XAttribute("hreflang", "ar"), new XAttribute("href", Uri.EscapeUriString(sitemapNode.AltURL))),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)));
                if (sitemapNode.Images.Count > 0)
                {
                    AddSitemapImagesNode(sitemapNode, doc, urlElement);
                }
                root.Add(urlElement);
            }
            doc.Add(root);

            doc.Save(DocumentPath);
            return true;
        }

        private void AddSitemapImagesNode(SitemapNode sitemapNode, XDocument doc, XElement rootElement)
        {
            XNamespace xmlns = "http://www.google.com/schemas/sitemap-image/1.1";
            foreach (SitemapImageNode imgnode in sitemapNode.Images)
            {
                XElement urlElement = new XElement(
                   xmlns + "image",
                   new XElement(xmlns + "loc", imgnode.Loc),
                   imgnode.Caption == null ? null : new XElement(
                       xmlns + "caption",
                       imgnode.Caption),
                   imgnode.Title == null ? null : new XElement(
                       xmlns + "title", imgnode.Title));
                rootElement.Add(urlElement);
            }
        }
        public bool AddNewNodes(List<SitemapNode> sitemapNodes, string DocumentPath)
        {
            XDocument doc = XDocument.Load(DocumentPath);
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XNamespace Image = "http://www.google.com/schemas/sitemap-image/1.1";
            XNamespace xhtml = "http://www.w3.org/1999/xhtml";
            XElement urlElement;
            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                urlElement = new XElement(
   xmlns + "url",
   new XElement(xmlns + "loc", sitemapNode.EncodeURL == true ? Uri.EscapeUriString(sitemapNode.Url) : sitemapNode.Url),
          sitemapNode.AltURL == null ? null : new XElement(xhtml + "link", new XAttribute("rel", "alternate"), new XAttribute("hreflang", "ar"), new XAttribute("href", Uri.EscapeUriString(sitemapNode.AltURL))),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
       sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
   sitemapNode.Frequency == null ? null : new XElement(
       xmlns + "changefreq",
       sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
   sitemapNode.Priority == null ? null : new XElement(
       xmlns + "priority",
       sitemapNode.Priority.Value.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)));
                if (sitemapNode.Images.Count > 0)
                {
                    AddSitemapImagesNode(sitemapNode, doc, urlElement);
                }
                doc.Root.Add(urlElement);
            }
            doc.Save(DocumentPath);
            return true;
        }
        public bool AddNewNode(SitemapNode sitemapNode, string DocumentPath)
        {
            if (!CheckNodeExist(Uri.EscapeUriString(sitemapNode.Url), DocumentPath))
            {
                XDocument doc = XDocument.Load(DocumentPath);
                XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
                XNamespace Image = "http://www.google.com/schemas/sitemap-image/1.1";
                XNamespace xhtml = "http://www.w3.org/1999/xhtml";
                XElement urlElement = new XElement(
               xmlns + "url",
               new XElement(xmlns + "loc",sitemapNode.EncodeURL==true?Uri.EscapeUriString(sitemapNode.Url):sitemapNode.Url),
               sitemapNode.AltURL == null ? null : new XElement(xhtml + "link", new XAttribute("rel", "alternate"), new XAttribute("hreflang", "ar"), new XAttribute("href", Uri.EscapeUriString(sitemapNode.AltURL))),
               sitemapNode.LastModified == null ? null : new XElement(
                   xmlns + "lastmod",
                   sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
               sitemapNode.Frequency == null ? null : new XElement(
                   xmlns + "changefreq",
                   sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
               sitemapNode.Priority == null ? null : new XElement(
                   xmlns + "priority",
                   sitemapNode.Priority.Value.ToString("F1", System.Globalization.CultureInfo.InvariantCulture)));
                if (sitemapNode.Images!=null)
                { 
                if (sitemapNode.Images.Count > 0)
                {
                    AddSitemapImagesNode(sitemapNode, doc, urlElement);
                }
                }
                doc.Root.Add(urlElement);
                doc.Save(DocumentPath);
            }
            return true;
        }
        public bool CheckNodeExist(string URL,string DocumentPath)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XDocument doc = XDocument.Load(DocumentPath);
            XElement root = doc.Root;
            var exists = root.Elements(xmlns + "url").Elements(xmlns + "loc").Any(l => l.Value == URL);
                   // .Elements("loc")
                   // .FirstOrDefault();
                   //   var result = doc.Descendants("URL").Any(x => x.Element("loc").Value.Equals(Uri.EscapeUriString(URL)));
            return exists;
        }
        private string EncodeURL(string text)
        {
            //byte[] utf8Bytes = new byte[text.Length];
            //for (int i = 0; i < text.Length; ++i)
            //{
            //    utf8Bytes[i] = (byte)text[i];
            //}
            //var result = Encoding.UTF8.GetString(utf8Bytes, 0, utf8Bytes.Length);
            //return result;
            //  System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;

            // This is our Unicode string:
            //  string s_unicode = "abcéabc";

            // Convert a string to utf-8 bytes.
            byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(text);

            // Convert utf-8 bytes to a string.
            string s_unicode2 = System.Text.Encoding.UTF8.GetString(utf8Bytes);

            return s_unicode2;
        }
    }
}