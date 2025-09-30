using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.GeneralClasses
{
    public static class AqarFeedsGenerator
    {
        public static void GenerateRealestateFeedItems()
        {
            using (RealEstateBrokerEntities db = new RealEstateBrokerEntities())
            {
                DateTime mindate = DateTime.Now.AddDays(-30);// new DateTime(DateTime.Now.Year,DateTime.Now.Month,)
                var realestates = db.RealEstates.Where(r => r.ChangeActiveStatus>=mindate
                && r.ActiveStatusId==(int)ActiveStatus.Active);
               foreach(RealEstate real in realestates)
                {
                    GenerateProductFeedItem(real);
                }
            }
        }
        public static void GenerateProjectsFeedItems()
        {
            using (RealEstateBrokerEntities db = new RealEstateBrokerEntities())
            {
                var projects = db.RealEstateProjects.Where(p => p.ActiveStatusID == (int)ActiveStatus.Active);
                foreach(RealEstateProject p in projects)
                {
                    GenerateProjectFeedItem(p);
                }
            }
        }
        public static void GenerateProductFeedItem(RealEstate product)
        {
            if (ConfigurationSettings.AppSettings["Masharef"].Contains(product.Subscriber.CompanyID.ToString()))
            {
                GenerateProductItem(product, "~/Feeds/MasharefFeeds.Xml");
            }
            GenerateProductItem(product, "~/Feeds/PropertiesFeeds.Xml");
        }
        public static void GenerateProjectFeedItem(RealEstateProject product)
        {
            if(ConfigurationSettings.AppSettings["Masharef"].Contains(product.CompanyID.ToString()))
            {
                GenerateProjectItem(product, "~/Feeds/MasharefFeeds.Xml");
            }
                GenerateProjectItem(product, "~/Feeds/PrjectsFeeds.Xml");
        }
        private static void GenerateProjectItem(RealEstateProject product,string doc)
        {
            FeedItem item = new FeedItem();
            item.Availability = FeedAvilabilty.Available;
            item.Category = "مشروعات عقارية";
            item.Description = product.Summary;
            item.ID = product.Code.ToString();
            item.Link = ConfigurationSettings.AppSettings["WebSite"] + "/مشاريع_عقارية" + " /" + product.ID + Commons.EncodeText(product.Title);
            item.Title = product.Title;
            item.City = product.City.Name;
            item.Country = product.Country.Name;
            item.District = product.District.Name;
            item.Latitude = product.Latitude;
            item.Longtitude = product.Longitude;
            item.street = product.Address;
            item.Images = new List<FeedItemImage>();
            FeedItemImage img = new FeedItemImage();
            img.ImageLink = ConfigurationSettings.AppSettings["WebSite"] + product.Logo.Replace("~", "");
            img.IsDefault = true;
            item.Images.Add(img);
            foreach (RealEstateProjectPhoto image in product.RealEstateProjectPhotos)
            {
                img = new FeedItemImage();
                img.ImageLink = ConfigurationSettings.AppSettings["WebSite"] + image.PhotoURL.Replace("~", "");
                img.IsDefault = false;
                item.Images.Add(img);
            }
            FaceBookFeedGenerator gen = new FaceBookFeedGenerator();
            gen.AddNewNode(item, HttpContext.Current.Server.MapPath(doc));
        }

        private static void GenerateProductItem(RealEstate product, string doc)
        {
            FeedItem item = new FeedItem();
            item.Availability = FeedAvilabilty.Available;
            item.Category = product.RealEstateCategory.Title;
            item.Description = product.Description;
            item.ID = product.Code.ToString();
            item.Link = ConfigurationSettings.AppSettings["WebSite"] + "/Details" + " /" + product.ID + Commons.EncodeText(product.Title);
            item.Price = product.Price.ToString();
            item.Title = product.Title;
            item.City = product.City.Name;
            item.Country = product.Country.Name;
            item.District = product.District.Name;
            item.Latitude = product.Latitude;
            item.Longtitude = product.Longitude;
            item.street = product.Street;
            item.Images = new List<FeedItemImage>();
            FeedItemImage img = new FeedItemImage();
            img.ImageLink = ConfigurationSettings.AppSettings["WebSite"] + product.DefaultImage.PhotoName.Replace("~", "");
            img.IsDefault = true;
            item.Images.Add(img);
            foreach (RealEstatePhoto image in product.RealEstatePhotos)
            {
                if (image.PhotoName != product.DefaultImage.PhotoName)
                {
                    img = new FeedItemImage();
                    img.ImageLink = ConfigurationSettings.AppSettings["WebSite"] + image.PhotoName.Replace("~", "");
                    img.IsDefault = false;
                    item.Images.Add(img);
                }
            }
            FaceBookFeedGenerator gen = new FaceBookFeedGenerator();
            gen.AddNewNode(item, HttpContext.Current.Server.MapPath(doc));
        }
    }
}