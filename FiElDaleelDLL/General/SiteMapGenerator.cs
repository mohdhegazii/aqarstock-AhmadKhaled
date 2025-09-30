using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Text.RegularExpressions;
using System.Configuration;

namespace BrokerDLL.General
{
    public static class SiteMapGenerator
    {
        public static bool GenerateCatalogSiteMap()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("urlset");// Create the root element with attributes

            root.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            root.SetAttribute("xmlns:image", "http://www.google.com/schemas/sitemap-image/1.1");
            root.SetAttribute("xmlns:video", "http://www.google.com/schemas/sitemap-video/1.1");
            root.SetAttribute("xmlns:mobile", "http://www.google.com/schemas/sitemap-mobile/1.0");
            root.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            root.SetAttribute("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            doc.AppendChild(root);
            doc.Save(HttpContext.Current.Server.MapPath("~") + "/CatalogSitemap.Xml");
           // XmlNode Node;
            using (BrokerEntities Context = new BrokerEntities())
            {
                foreach (RealEstateCatalog Catlog in Context.RealEstateCatalogs)
                {
                    string URL = ConfigurationSettings.AppSettings["WebSite"] + "/كتالوجات_عقارية/" + Catlog.ID + "/" + Catlog.Title.Replace(" ", "_");
                    SiteMapGenerator.AddCatalogNode(URL, Catlog.Code, Catlog.Title);
                }
            }
            
            return true;
        }
        public static bool GenerateSiteMap()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("urlset");// Create the root element with attributes

            root.SetAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            root.SetAttribute("xmlns:image", "http://www.google.com/schemas/sitemap-image/1.1");
            root.SetAttribute("xmlns:video", "http://www.google.com/schemas/sitemap-video/1.1");
            root.SetAttribute("xmlns:mobile", "http://www.google.com/schemas/sitemap-mobile/1.0");
            root.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            root.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            root.SetAttribute("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");
            doc.AppendChild(root);

            XmlNode Node;
            using (BrokerEntities Context = new BrokerEntities())
            {
                foreach (RealEstate realestate in Context.RealEstates.Where(R => R.IsSold == false && R.ActiveStatusId == (int)Activestatus.Active).ToList())
                {
                    Node = SaveRealEstateNode(realestate, doc);
                    root.AppendChild(Node);
                }
                foreach (RealEstateCompany Company in Context.RealEstateCompanies.Where(C => C.ActivateStatusID == (int)Activestatus.Active))
                {
                    Node = SaveCompanyNode(Company, doc);
                    root.AppendChild(Node);
                }
                foreach (RealEstateProject Project in Context.RealEstateProjects.Where(P => P.ActiveStatusID == (int)Activestatus.Active))
                {
                    Node = SaveProjectNode(Project, doc);
                    root.AppendChild(Node);
                }
                foreach (SearchKeyword Keyword in Context.SearchKeywords)
                {
                    Node = SaveKeywordNode(Keyword, doc);
                    root.AppendChild(Node);
                }
                AddGeneralLinks(root, doc);
                doc.Save(HttpContext.Current.Server.MapPath("~") + "/SiteMap.Xml");
            }
            
            return true;
        }
        private static void AddGeneralLinks(XmlElement root,XmlDocument doc)
        {
            XmlDocument docGeneral = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/Backend/Admin/Settings/GeneralLinks.xml");
            docGeneral.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(docGeneral.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode rootGeneral = docGeneral.DocumentElement;
            XmlNode Node;
            string Code;
            foreach(XmlNode GeneralNode in rootGeneral.ChildNodes)
            {
                Code = GeneralNode.Attributes["Code"].InnerText;
                
                Node = root.SelectSingleNode("//nc:url[@Code='" + Code + "']", XmlNC);
                if (Node == null)
                {
                    Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
                    XmlAttribute CodeAttr = doc.CreateAttribute("Code");
                    CodeAttr.InnerText = Code;
                    Node.Attributes.Append(CodeAttr);
                    XmlNode LocNode;
                    LocNode = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
                    LocNode.InnerText = GeneralNode.ChildNodes[0].InnerText;
                    Node.AppendChild(LocNode);
                    root.AppendChild(Node);
                }
            }
        }

        public static bool AddGeneralLinks()
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement root = doc.DocumentElement;
            AddGeneralLinks(root,doc);
            doc.Save(HttpContext.Current.Server.MapPath("~") + "/SiteMap.Xml");
            return true;
        }
        
        private static XmlNode SaveKeywordNode(SearchKeyword Keyword, XmlDocument doc)
        {
            XmlNode Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute CodeAttr = doc.CreateAttribute("Code");
            XmlAttribute keywordAtt = doc.CreateAttribute("keyword");
            CodeAttr.InnerText = DateTime.Now.Ticks.ToString();
            Node.Attributes.Append(CodeAttr);
            Node.Attributes.Append(keywordAtt);
            XmlNode LocNode;
            LocNode = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            LocNode.InnerText = Keyword.URL;
            keywordAtt.InnerText = Keyword.Keywords;
            Node.AppendChild(LocNode);
            return Node;
        }

        private static XmlNode SavePartnerNode(Partner partner, XmlDocument doc)
        {
            XmlNode Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute CodeAttr = doc.CreateAttribute("Code");
            XmlAttribute keywordAtt = doc.CreateAttribute("keyword");
            CodeAttr.InnerText = partner.Code;
            Node.Attributes.Append(CodeAttr);
            XmlNode LocNode;
            LocNode = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            LocNode.InnerText = ConfigurationSettings.AppSettings["WebSite"] + "/" + EncodeText(partner.URL);
            keywordAtt.InnerText = partner.Title;
            Node.Attributes.Append(keywordAtt);
            Node.AppendChild(LocNode);
            return Node;
        }

        public static bool AddCatalogNode(string URL, string Code, string keyword)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/CatalogSitemap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            //XmlNode realEstateNode;
            XmlNode Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute CodeAttr = doc.CreateAttribute("Code");
            XmlAttribute keywordAtt = doc.CreateAttribute("keyword");
            XmlAttribute xmlnsAtt = doc.CreateAttribute("xmlns");
            xmlnsAtt.InnerText = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XmlNode ArticleLoc;
            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            CodeAttr.InnerText = Code;
            keywordAtt.InnerText = keyword;
            ArticleLoc.InnerText = URL;
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "weekly";
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "0.3";
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            Node.AppendChild(ArticleLoc);

            Node.Attributes.Append(xmlnsAtt);
            Node.Attributes.Append(CodeAttr);
            Node.Attributes.Append(keywordAtt);

            root.AppendChild(Node);
            doc.Save(path);
            return true;
        }
        public static bool AddGeneralNode(string URL, string Code, string keyword)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            //XmlNode realEstateNode;
            XmlNode Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute CodeAttr = doc.CreateAttribute("Code");
            XmlAttribute keywordAtt = doc.CreateAttribute("keyword");
            //XmlAttribute xmlnsAtt = doc.CreateAttribute("xmlns");
            //xmlnsAtt.InnerText = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XmlNode ArticleLoc;
            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            CodeAttr.InnerText = Code;
            keywordAtt.InnerText = keyword;
            ArticleLoc.InnerText = URL;
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "weekly";
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "0.3";
            Node.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            Node.AppendChild(ArticleLoc);

            Node.Attributes.Append(CodeAttr);
            Node.Attributes.Append(keywordAtt);

            root.AppendChild(Node);
            doc.Save(path);
            return true;
        }
        public static bool EditGeneralNode(string URL, string Code, string keyword)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@Code='" + Code + "']", XmlNC);
            if (realEstateNode != null)
            {
                realEstateNode.ChildNodes[0].InnerText = URL;
                realEstateNode.Attributes["keyword"].InnerText = keyword;
            }
            doc.Save(path);
            return true;

        }
        public static bool DeleteGeneralNode(string Code)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@Code='" + Code + "']", XmlNC);
            if (realEstateNode != null)
            {
                root.RemoveChild(realEstateNode);
                doc.Save(path);
            }
            return true;
        }
        public static bool AddRealEstateNde(int RealEstateID)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstate realestate = Context.RealEstates.FirstOrDefault(R => R.ID == RealEstateID);
                if (realestate != null)
                {
                    XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@Code='" + realestate.Code + "']", XmlNC);
                    if (realEstateNode == null)
                    {
                        realEstateNode = SaveRealEstateNode(realestate, doc);
                        root.AppendChild(realEstateNode);
                    }
                }
            }
            doc.Save(path);
            return true;
        }
        public static bool AddCompanyNode(int CompanyID)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstateCompany company = Context.RealEstateCompanies.FirstOrDefault(R => R.ID == CompanyID);
                if (company != null)
                {
                    XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@Code='" + company.Code + "']", XmlNC);
                    if (realEstateNode == null)
                    {
                        realEstateNode = SaveCompanyNode(company, doc);
                        root.AppendChild(realEstateNode);
                    }
                }
            }
            doc.Save(path);
            return true;
        }
        public static bool AddProjectNode(int ProjectID)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            using (BrokerEntities Context = new BrokerEntities())
            {
                RealEstateProject Project = Context.RealEstateProjects.FirstOrDefault(R => R.ID == ProjectID);
                if (Project != null)
                {
                    XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@Code='" + Project.Code + "']", XmlNC);
                    if (realEstateNode == null)
                    {
                        realEstateNode = SaveProjectNode(Project, doc);
                        root.AppendChild(realEstateNode);
                    }
                }
            }
            doc.Save(path);
            return true;
        }
        private static XmlNode SaveRealEstateNode(RealEstate realestate, XmlDocument doc)
        {
            XmlNode ArticleNode = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute ArticleId = doc.CreateAttribute("Code");
            ArticleId.InnerText = realestate.Code.ToString();
            ArticleNode.Attributes.Append(ArticleId);
            XmlNode ArticleLoc;
            XmlNode ArticleImg;
            XmlNode ArticleImgLoc;
            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"] + "Details/" + realestate.ID + "/" + EncodeText(realestate.Title);
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "weekly";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "0.3";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            ArticleNode.AppendChild(ArticleLoc);

            if (realestate.RealEstatePhotos != null)
            {
                foreach (RealEstatePhoto Photo in realestate.RealEstatePhotos.ToList())
                {
                    ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
                    ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
                    ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + Photo.PhotoName.Replace("~/", "");
                    ArticleImg.AppendChild(ArticleImgLoc);
                    ArticleNode.AppendChild(ArticleImg);
                }
            }
            else
            {
                ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
                ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
                ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + realestate.RealEstateType.Icon.Replace("~/", "");
                ArticleImg.AppendChild(ArticleImgLoc);
                ArticleNode.AppendChild(ArticleImg);
            }
            return ArticleNode;
        }
        private static XmlNode SaveCompanyNode(RealEstateCompany company, XmlDocument doc)
        {
            XmlNode ArticleNode = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute ArticleId = doc.CreateAttribute("Code");
            ArticleId.InnerText = company.Code.ToString();
            ArticleNode.Attributes.Append(ArticleId);
            XmlNode ArticleLoc;
            XmlNode ArticleImg;
            XmlNode ArticleImgLoc;
            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"] + "شركات_عقارية/" + company.ID + "/" + EncodeText(company.Title);
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "weekly";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "0.3";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            ArticleNode.AppendChild(ArticleLoc);

            ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
            ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
            ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + company.Logo.Replace("~/", "");
            ArticleImg.AppendChild(ArticleImgLoc);
            ArticleNode.AppendChild(ArticleImg);

            return ArticleNode;
        }
        private static XmlNode SaveProjectNode(RealEstateProject Project, XmlDocument doc)
        {
            XmlNode ArticleNode = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlAttribute ArticleId = doc.CreateAttribute("Code");
            ArticleId.InnerText = Project.Code.ToString();
            ArticleNode.Attributes.Append(ArticleId);
            XmlNode ArticleLoc;
            XmlNode ArticleImg;
            XmlNode ArticleImgLoc;
            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"] + "مشاريع_عقارية/" + Project.ID + "/" + EncodeText(Project.Title);
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "weekly";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = "0.3";
            ArticleNode.AppendChild(ArticleLoc);

            ArticleLoc = doc.CreateNode(XmlNodeType.Element, "lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ArticleLoc.InnerText = DateTime.Now.ToString("yyyy-MM-dd");
            ArticleNode.AppendChild(ArticleLoc);

            ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
            ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
            ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + Project.Logo.Replace("~/", "");
            ArticleImg.AppendChild(ArticleImgLoc);
            ArticleNode.AppendChild(ArticleImg);

            if (Project.RealEstateProjectPhotos != null)
            {
                foreach (RealEstateProjectPhoto Photo in Project.RealEstateProjectPhotos.ToList())
                {
                    ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
                    ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
                    ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + Photo.PhotoURL.Replace("~/", "");
                    ArticleImg.AppendChild(ArticleImgLoc);
                    ArticleNode.AppendChild(ArticleImg);
                }
            }
            if (Project.RealEstateProjectModels != null)
            {
                foreach (RealEstateProjectModel Model in Project.RealEstateProjectModels.ToList())
                {
                    if (Model.PlanImgURL != null && Model.PlanImgURL != "")
                    {
                        ArticleImg = doc.CreateNode(XmlNodeType.Element, "image:image", "http://www.google.com/schemas/sitemap-image/1.1");
                        ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "image:loc", "http://www.google.com/schemas/sitemap-image/1.1");
                        ArticleImgLoc.InnerText = ConfigurationSettings.AppSettings["WebSite"].ToString() + Model.PlanImgURL.Replace("~/", "");
                        ArticleImg.AppendChild(ArticleImgLoc);
                        ArticleNode.AppendChild(ArticleImg);
                    }
                }
            }
            //if (Project.RealEstateProjectVideos != null)
            //{
            //    foreach (RealEstateProjectVideo Vedio in Project.RealEstateProjectVideos)
            //    {
            //        ArticleImg = doc.CreateNode(XmlNodeType.Element, "video:video", "http://www.google.com/schemas/sitemap-video/1.1");
            //        ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "video:content_loc", "http://www.google.com/schemas/sitemap-video/1.1");
            //        ArticleImgLoc.InnerText = Vedio.URL;
            //        ArticleImg.AppendChild(ArticleImgLoc);
            //        ArticleImgLoc = doc.CreateNode(XmlNodeType.Element, "video:title", "http://www.google.com/schemas/sitemap-video/1.1");
            //        ArticleImgLoc.InnerText = Vedio.TiTle;
            //        ArticleImg.AppendChild(ArticleImgLoc);
            //        ArticleNode.AppendChild(ArticleImg);
            //    }
            //}
            return ArticleNode;
        }
        public static bool AddToStaticSiteMap(string URL, string Code, string keyword)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/SearchSiteMap.Xml");
            doc.Load(path);
            XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
            XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlNode root = doc.DocumentElement;
            //XmlNode realEstateNode;
            XmlNode realEstateNode = root.SelectSingleNode("//nc:url[@keyword='" + keyword + "']", XmlNC);
               if (realEstateNode == null)
               {
                   XmlNode Node = doc.CreateNode(XmlNodeType.Element, "url", "http://www.sitemaps.org/schemas/sitemap/0.9");
                   XmlAttribute CodeAttr = doc.CreateAttribute("Code");
                   XmlAttribute keywordAtt = doc.CreateAttribute("keyword");
                   //XmlAttribute xmlnsAtt = doc.CreateAttribute("xmlns");
                   //xmlnsAtt.InnerText = "http://www.sitemaps.org/schemas/sitemap/0.9";
                   XmlNode ArticleLoc;
                   ArticleLoc = doc.CreateNode(XmlNodeType.Element, "loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
                   CodeAttr.InnerText = Code;
                   keywordAtt.InnerText = keyword;
                   ArticleLoc.InnerText = URL;
                   Node.AppendChild(ArticleLoc);
                   Node.Attributes.Append(CodeAttr);
                   Node.Attributes.Append(keywordAtt);

                   root.AppendChild(Node);
                   doc.Save(path);
               }
            //doc.c
            return true;
        }
        private static string EncodeText(string text)
        {
            return Regex.Replace(text, "[^0-9a-zA-Zء-ي]+", "-");
            //UTF8Encoding encoder = new UTF8Encoding();
            //byte[] bytes = Encoding.UTF8.GetBytes(text);
            //return (Regex.Replace(encoder.GetString(bytes), "[^0-9a-zA-Zء-ي]+", "-"));
        }
    }
}
