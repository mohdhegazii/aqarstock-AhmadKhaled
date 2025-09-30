using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public partial class NotifyService
    {
       public virtual string Type
       {
           get
           {
               if (this.RealEstateType != null)
               {
                   return this.RealEstateType.Title;
               }
               else
               {
                   return "";
               }
           }
       }
       public virtual string Address
       {
           get
           {
               if (this.Country != null)
               {
                   if (this.City != null)
                   {
                       if (this.District != null)
                       {
                           return this.District.Name+", "+City.Name+", "+Country.Name;
                       }
                       else
                       {
                           return City.Name + ", " + Country.Name;
                       }
                   }
                   else
                   {
                       return Country.Name;
                   }
               }
               else
               {
                   return "";
               }
           }
       }
       public virtual string SaleTypeName
       {
           get
           {
               if (this.SaleType != null)
               {
                   return this.SaleType.Title;
               }
               else
               {
                   return "";
               }
           }
       }

       
    }
}
