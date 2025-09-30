using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.GeneralClasses
{
    public class ContentGenerator
    {
        RealEstateBrokerEntities Context;
        public RealEstateCatalog GenerateCatalog(ContentGenerator generator, string cat)
        {
                RealEstateCatalog Catalog = Context.RealEstateCatalogs.FirstOrDefault(C => C.Title == cat);
                if (Catalog == null)
                {
                    Catalog = new RealEstateCatalog();
                    Catalog.Title = cat;
                    Catalog.CategoryID = View.CategoryID;
                    Catalog.Description = cat + " - عقار ستوك . كوم";
                    Catalog.Tag = generator.GenerateContent(cat, View.CatalogNames);
                    Catalog.Code = "PC-" + DateTime.Now.DayOfYear + DateTime.Now.TimeOfDay.Ticks;
                    Catalog.Date = DateTime.Now;
                    Catalog.PhotoURL = GetPhoto();
                    Context.RealEstateCatalogs.AddObject(Catalog);
                    Context.SaveChanges();
                    string URL = ConfigurationSettings.AppSettings["WebSite"] + "/كتالوجات_عقارية/" + Catalog.ID + "/" + Catalog.Title.Replace(" ", "_");
                    SiteMapGenerator.AddCatalogNode(URL, Catalog.Code, Catalog.Title);
                    AddCatalogProps(Context, Catalog.ID);
                    return Catalog;
                }
                else
                {
                    return null;
                }
        }
        private void AddCatalogProps( int catalogId)
        {
            Random ra = new Random();
            RealestateCatalogProperty prop;
            int i = ra.Next(Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active).Count() - 9);
            List<RealEstate> Realestates = Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active).OrderByDescending(R => R.CreatedDate).Skip(i).Take(9).ToList();
            foreach (RealEstate r in Realestates)
            {
                prop = new RealestateCatalogProperty();
                prop.CatalogID = catalogId;
                prop.RealEstateID = r.ID;
                Context.RealestateCatalogProperties.AddObject(prop);
                Context.SaveChanges();
            }
        }
        private string GetPhoto()
        {
            List<string> Photos = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Resources/Catalogs")).ToList();
            Random r = new Random();
            return "Resources/Catalogs/" + Path.GetFileName(Photos[r.Next(Photos.Count())]);
        }
    }
}