using BrokerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrokerMVC.Code.GeneralClasses
{
    public static class Initialize
    {
        public static bool Initial()
        {
            InitialCategories();
            return true;
        }

        private static void InitialCategories()
        {
            using (RealEstateBrokerEntities Context = new RealEstateBrokerEntities())
            {
                Context.RealEstateCategories.Add(InsertCategory("وحدات سكنية", "Residenial"));
                Context.RealEstateCategories.Add(InsertCategory("وحدات تجارية", "Commercial"));
                Context.RealEstateCategories.Add(InsertCategory("اراضى", "Lands"));
                Context.SaveChanges();
            }
        }

        private static RealEstateCategory InsertCategory(string Title,string EnTitle)
        {
            RealEstateCategory cat = new RealEstateCategory();
            cat.Title = Title;
            cat.EnTitle = EnTitle;
            return cat;
        }
    }
}