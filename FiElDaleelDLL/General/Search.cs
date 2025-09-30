using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL.General
{
    public static class Search
    {

        public static List<BrokerDLL.Serializable.RealEstate> SearchRealEstates(SearchCriteria Criteria)
        {  
            using (BrokerEntities Context = new BrokerEntities())
            {
            //  Criteria.Keyword = Criteria.Keyword.ToLower();
            IQueryable<RealEstate> query = SearchByCretirea(Criteria,Context);
            if (query == null)
            {
                return null;
            }
         
                List<BrokerDLL.Serializable.RealEstate> realestates = new List<Serializable.RealEstate>();
                query.OrderByDescending(B=>B.IsSpecialOffer).ThenByDescending(B => B.CreatedDate).Skip((Criteria.PageIndex - 1) * Criteria.PageSize).Take(Criteria.PageSize)
                    .ToList<RealEstate>().ForEach(R => realestates.Add(new Serializable.RealEstate(R)));

                return realestates;
            }

        }

        public static List<int> CountRealEstates(SearchCriteria RealEstateSearchCriteria)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                IQueryable<RealEstate> query = SearchByCretirea(RealEstateSearchCriteria,Context);
                if (query == null)
                {
                    return null;
                }
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(query.Count()) / RealEstateSearchCriteria.PageSize;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
        }


        private static IQueryable<RealEstate> SearchByCretirea(SearchCriteria Criteria,BrokerEntities Context)
        {
           
                IQueryable<RealEstate> query = Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active && R.IsSold == false);
                if (Criteria.SubscriberID != 0 && Criteria.SubscriberID != null)
                {
                    query = query.Where(R => R.SubscriberID == Criteria.SubscriberID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.CountryID != 0 && Criteria.CountryID != null)
                {
                    query = query.Where(R => R.CountryID == Criteria.CountryID);
                    if (query == null)
                    {
                        return null;
                    }
                }
            if (Criteria.CityID != 0 && Criteria.CityID != null)
                {

                    query = query.Where(R => R.CityID == Criteria.CityID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.DistrictID != 0 && Criteria.DistrictID != null)
                {
                    query = query.Where(R => R.DistrictID == Criteria.DistrictID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.RealEstateCategoryID != 0 && Criteria.RealEstateCategoryID != null)
                {
                    query = query.Where(R => R.RealEstateCategoryID == Criteria.RealEstateCategoryID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.RealEstateStatusID != 0 && Criteria.RealEstateStatusID!=null)
                {
                    query = query.Where(R => R.RealEstateStatusID == Criteria.RealEstateStatusID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.RealEstateTypeID != 0 && Criteria.RealEstateTypeID != null)
                {
                    query = query.Where(R => R.RealEstateTypeID == Criteria.RealEstateTypeID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.SaleTypeID != 0 && Criteria.SaleTypeID != null)
                {
                    query = query.Where(R => R.SaleTypeId == Criteria.SaleTypeID || R.SaleTypeId==3);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.PaymentTypeID != 0 && Criteria.PaymentTypeID != null)
                {
                    query = query.Where(R => R.PaymentTypeID == Criteria.PaymentTypeID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.CurrencyID != 0 && Criteria.CurrencyID!=null)
                {
                    query = query.Where(R => R.CurrencyID == Criteria.CurrencyID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.MinArea != 0 && Criteria.MinArea != null)
                {
                    query = query.Where(R => R.Area >= Criteria.MinArea);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.MaxArea != 0 && Criteria.MaxArea != null)
                {
                    query = query.Where(R => R.Area <= Criteria.MaxArea);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.MinPrice != 0 && Criteria.MinPrice != null)
                {
                    query = query.Where(R => R.Price >= Criteria.MinPrice);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.MaxPrice != 0 && Criteria.MaxPrice != null)
                {
                    query = query.Where(R => R.Price <= Criteria.MaxPrice);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.IsSpecialOffer != false && Criteria.IsSpecialOffer != null)
                {
                    query = query.Where(R => R.IsSpecialOffer == Criteria.IsSpecialOffer);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (Criteria.CompanyID != 0 && Criteria.CompanyID != null)
                {
                    query = query.Where(R => R.Subscriber.CompanyID == Criteria.CompanyID);
                    if (query == null)
                    {
                        return null;
                    }
                }
                if (query == null)
                {
                    return null;
                }
                return query;
            }

        }
}
