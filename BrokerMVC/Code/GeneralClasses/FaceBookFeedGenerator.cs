using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BrokerMVC.Code.GeneralClasses
{
    public enum FeedAvilabilty
    {
        [EnumValue("available for order")]
        [EnumEngValue("available for order")]
        Available,
        [EnumValue("out of stock")]
        [EnumEngValue("out of stock")]
        OutofStock,
    }
    public class FeedItemImage
    {
        public string ImageLink { get; set; }
        public bool IsDefault { get; set; }
    }
    public class FeedItem
    {
        public string ID { get; set; }
        public FeedAvilabilty Availability { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string street { get; set; }
        public string District { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Longtitude { get; set; }
        public string Latitude { get; set; }
        public List<FeedItemImage> Images { get; set; }
    }

    public class FaceBookFeedGenerator
    {
        public bool AddNewNodes(List<FeedItem> itemNodes, string DocumentPath)
        {
            XDocument doc = XDocument.Load(DocumentPath);
            XElement urlElement;
           
            foreach (FeedItem itemNode in itemNodes)
            {
                urlElement = new XElement("listing",
                    new XElement("name", itemNode.Title),
                    new XElement("home_listing_id", itemNode.ID),
                      new XElement("availability", itemNode.Availability.GetValue()),
                      new XElement("url", Uri.EscapeUriString(itemNode.Link)),
                      new XElement("description", itemNode.Description),
                      new XElement("price", itemNode.Price),
                      new XElement("property_type", itemNode.Category),
                      new XElement("neighborhood", itemNode.District),
                      new XElement("latitude", itemNode.Latitude),
                      new XElement("longitude", itemNode.Longtitude)
                     );
               urlElement.Add(SetAddressNode(itemNode));
                if (itemNode.Images != null)
                {
                    if (itemNode.Images.Count > 0)
                    {
                        AddImagesNode(itemNode, doc, urlElement);
                    }
                }
                doc.Root.Add(urlElement);
            }
            doc.Save(DocumentPath);
            return true;
        }

        private static XElement SetAddressNode(FeedItem itemNode)
        {
            XElement Address = new XElement("address");
            Address.SetAttributeValue("format", "simple");
            XElement Component = new XElement("component", itemNode.Country);
            Component.SetAttributeValue("name", "country");
            Address.Add(Component);
            Component = new XElement("component", itemNode.City);
            Component.SetAttributeValue("name", "city");
            Address.Add(Component);
            Component = new XElement("component", itemNode.City);
            Component.SetAttributeValue("name", "region");
            Address.Add(Component);
            Component = new XElement("component", itemNode.street);
            Component.SetAttributeValue("name", "addr1");
            Address.Add(Component);
            return Address;
        }

        public bool AddNewNode(FeedItem itemNode, string DocumentPath)
        {
            if (!CheckNodeExist(Uri.EscapeUriString(itemNode.ID), DocumentPath))
            {
                XDocument doc = XDocument.Load(DocumentPath);
                XElement urlElement = new XElement("listing",
                 new XElement("name", itemNode.Title),
                 new XElement("home_listing_id", itemNode.ID),
                   new XElement("availability", itemNode.Availability.GetValue()),
                   new XElement("url", Uri.EscapeUriString(itemNode.Link)),
                   new XElement("description", itemNode.Description),
                   new XElement("price", itemNode.Price),
                   new XElement("property_type", itemNode.Category),
                   new XElement("neighborhood", itemNode.District),
                   new XElement("latitude", itemNode.Latitude),
                   new XElement("longitude", itemNode.Longtitude)
                  );
                urlElement.Add(SetAddressNode(itemNode));
                if (itemNode.Images != null)
                {
                    if (itemNode.Images.Count > 0)
                    {
                        AddImagesNode(itemNode, doc, urlElement);
                    }
                }
                doc.Root.Add(urlElement);
                doc.Save(DocumentPath);
            }
            return true;
        }
        private void AddImagesNode(FeedItem itemNode, XDocument doc, XElement rootElement)
        {
            // var Path = Configuration.Website + "/" + Commons.Culture;

            XElement urlElement;
           
            foreach (FeedItemImage imgnode in itemNode.Images)
            {
                urlElement = new XElement("image");
                //urlElement = ;
                urlElement.Add(new XElement("url", imgnode.ImageLink));
                rootElement.Add(urlElement);
            }
        }
        public bool CheckNodeExist(string id, string DocumentPath)
        {
            //   XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XDocument doc = XDocument.Load(DocumentPath);
            XElement root = doc.Root;
            var exists = root.Elements("listing").Elements("home_listing_id").Any(l => l.Value == id);
            // .Elements("loc")
            // .FirstOrDefault();
            //   var result = doc.Descendants("URL").Any(x => x.Element("loc").Value.Equals(Uri.EscapeUriString(URL)));
            return exists;
        }
        public bool DeleteNode(string id, string DocumentPath)
        {
            //   XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XDocument doc = XDocument.Load(DocumentPath);
            XElement root = doc.Root;
            var element = root.Element("channel").Elements("item").Elements("id").FirstOrDefault(l => l.Value == id);
            if (element != null)
            {
                element.Remove();
            }
            // .Elements("loc")
            // .FirstOrDefault();
            //   var result = doc.Descendants("URL").Any(x => x.Element("loc").Value.Equals(Uri.EscapeUriString(URL)));
            doc.Save(DocumentPath);
            return true;
        }
    }
}