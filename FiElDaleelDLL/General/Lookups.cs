using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public static class Lookups
    {
       public static void InsertActiveStatus(string activeStatus)
       {
           ActiveStatus status = new ActiveStatus();
           status.Title = activeStatus;
           Commons.Context.ActiveStatuses.AddObject(status);
           Commons.Context.SaveChanges();
       }

       public static void InsertRealEstateCategory(string Category)
       {
           RealEstateCategory status = new RealEstateCategory();
           status.Title = Category;
           Commons.Context.RealEstateCategories.AddObject(status);
           Commons.Context.SaveChanges();
       }

       public static void InsertPaymentType(string paymentType)
       {
           PaymentType paymenttype = new PaymentType();
           paymenttype.Title = paymentType;
           Commons.Context.PaymentTypes.AddObject(paymenttype);
           Commons.Context.SaveChanges();
       }
       public static void InsertSaleType(string saleType)
       {
           SaleType saletype = new SaleType();
           saletype.Title = saleType;
           Commons.Context.SaleTypes.AddObject(saletype);
           Commons.Context.SaveChanges();
       }
       //public static void InsertItemStatus(string status)
       //{
       //    ItemStatus itemstatus = new ItemStatus();
       //    itemstatus.Title = status;
       //    Commons.Context.ItemStatuses.AddObject(itemstatus);
       //    Commons.Context.SaveChanges();
       //}
       //public static void InsertOfferCategory(string category,string imgurl)
       //{
       //    OfferCategory offercategory = new OfferCategory();
       //    offercategory.Title = category;
       //    offercategory.Icon = imgurl;
       //    Commons.Context.OfferCategories.AddObject(offercategory);
       //    Commons.Context.SaveChanges();
       //}
       //public static void InserOfferType(string type)
       //{
       //    OfferType offerType = new OfferType();
       //    offerType.Title = type;
       //    Commons.Context.OfferTypes.AddObject(offerType);
       //    Commons.Context.SaveChanges();
       //}
       public static void InserMessageType(string type)
       {
           SubscriperMessageType messageType = new SubscriperMessageType();
           messageType.Title = type;
           Commons.Context.SubscriperMessageTypes.AddObject(messageType);
           Commons.Context.SaveChanges();
       }
       public static void InserSusspendReasson(string type)
       {
           SuspendReason susspendReason = new SuspendReason();
           susspendReason.Title = type;
           Commons.Context.SuspendReasons.AddObject(susspendReason);
           Commons.Context.SaveChanges();
       }
       public static void InserAdPackage(string type)
       {
           AdPackage Packagw = new AdPackage();
           Packagw.Title = type;
           Commons.Context.AdPackages.AddObject(Packagw);
           Commons.Context.SaveChanges();
       }
    }
}
