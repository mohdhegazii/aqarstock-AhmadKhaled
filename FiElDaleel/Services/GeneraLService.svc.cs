using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BrokerDLL.Serializable;
using System.Web.Script.Serialization;
using System.Configuration;
using System.ServiceModel.Activation;
using System.Web.Security;
using System.Web;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GeneraLService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GeneraLService : IGeneraLService
    {
        public List<District> GetDistricts()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<District> Districts = new List<District>();
                Context.Districts.OrderBy(D => D.Name)
                    .ToList().ForEach(D => Districts.Add(new District(D.ID, D.Name)));
                return Districts;
            }
        }


        public List<SaleType> GetSalesTypes()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<SaleType> SaleTypes = new List<SaleType>();
                Context.SaleTypes.Where(S => S.IsVisible == true).OrderBy(S => S.Title).ToList()
                    .ForEach(S => SaleTypes.Add(new SaleType(S.ID, S.Title)));
                return SaleTypes;
            }
        }


        public List<PaymentType> GetPaymentTypes()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<PaymentType> PaymentTypes = new List<PaymentType>();
                Context.PaymentTypes.OrderBy(P => P.Title).ToList()
                    .ForEach(P => PaymentTypes.Add(new PaymentType(P.ID, P.Title)));
                return PaymentTypes;
            }
        }


        public List<Currency> GetCurrencies()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<Currency> Currencies = new List<Currency>();
                Context.Currencies.OrderBy(C => C.Name).ToList()
                    .ForEach(C => Currencies.Add(new Currency(C.ID, C.Name)));
                return Currencies;
            }
        }

        public string ContactUs(ContactUsMail contactUsMail)
        {
            Dictionary<string, string> Msg = new Dictionary<string, string>();
            Msg.Add("Name", contactUsMail.Name);
            Msg.Add("Phone", contactUsMail.Phone);
            Msg.Add("Email", contactUsMail.Email);
            Msg.Add("Message", contactUsMail.Message);
            BrokerDLL.Commons.SendEmail(BrokerDLL.EmailType.ContactUs, ConfigurationSettings.AppSettings["ContactUsEMail"].ToString(), Msg);
            return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
        }

        public List<City> GetCities()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<City> Cities = new List<City>();
                Context.Cities.Where(C => C.CountryID == 1).ToList().ForEach(D => Cities.Add(new City(D.ID, D.Name)));
                return Cities.OrderBy(c => c.Name).ToList();
            }
        }


        public List<District> GetDistrictsByCityID(string cityID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int CityID = Convert.ToInt32(cityID);
                List<District> Districts = new List<District>();
                Context.Districts.Where(D => D.CityID == CityID).OrderBy(D => D.Name)
                    .ToList().ForEach(D => Districts.Add(new District(D.ID, D.Name)));
                return Districts;
            }
        }


        public List<City> GetCitiesByCountryID(string CountryID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<City> Cities = new List<City>();
                int id = Convert.ToInt32(CountryID);
                Context.Cities.Where(C => C.CountryID == id).ToList().ForEach(D => Cities.Add(new City(D.ID, D.Name)));
                return Cities.OrderBy(c => c.Name).ToList();
            }
        }

        public List<Country> GetCountries()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<Country> Countriess = new List<Country>();
                Context.Countries.ToList().ForEach(D => Countriess.Add(new Country(D.ID, D.Name)));
                return Countriess.OrderBy(c => c.Name).ToList();
            }
        }


        public string SendNotifyRequest(NotifyRequest Request)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                BrokerDLL.NotifyService Notifyrequest = new BrokerDLL.NotifyService();
                Notifyrequest.CityID = Request.CityID;
                Notifyrequest.CountryID = Request.CountryID;
                Notifyrequest.DistrictID = Request.DistrictID;
                Notifyrequest.Email = Request.Email;
                Notifyrequest.Name = Request.Name;
                Notifyrequest.Phone = Request.Phone;
                Notifyrequest.Price = Request.Price;
                Notifyrequest.RealEstateTypeID = Request.RealEstateTypeID;
                Notifyrequest.SaleTypeID = Request.SaleTypeID;
                Notifyrequest.Area = Request.Area;
                Notifyrequest.Date = DateTime.Now;
                Context.NotifyServices.AddObject(Notifyrequest);
                Context.SaveChanges();
                Dictionary<string, string> Msg = new Dictionary<string, string>();
                Msg.Add("Name", Notifyrequest.Name);
                Msg.Add("Phone", Notifyrequest.Phone);
                Msg.Add("Email", Notifyrequest.Email);
                Msg.Add("RealEstateType", Notifyrequest.RealEstateType != null ? Notifyrequest.RealEstateType.Title : "");
                Msg.Add("SaleType", Notifyrequest.SaleType != null ? Notifyrequest.SaleType.Title : "");
                Msg.Add("Country", Notifyrequest.Country != null ? Notifyrequest.Country.Name : "");
                Msg.Add("City", Notifyrequest.City != null ? Notifyrequest.City.Name : "");
                Msg.Add("District", Notifyrequest.District != null ? Notifyrequest.District.Name : "");
                Msg.Add("Price", Notifyrequest.Price.ToString());
                Msg.Add("Area", Notifyrequest.Area.ToString());
                BrokerDLL.Commons.SendEmail(BrokerDLL.EmailType.NotifyRequest, ConfigurationSettings.AppSettings["ContactUsEMail"].ToString(), Msg);
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
            }
        }


        public List<SearchKeyword> GetSearchKeywords()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                List<SearchKeyword> Keywords = new List<SearchKeyword>();
                Context.SearchKeywords.Where(K => K.ParentID == null).ToList().ForEach(D => Keywords.Add(new SearchKeyword(D)));
                return Keywords.OrderBy(K => K.Keyword).ToList();
            }
        }


        public List<Company> GetCompanies(string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.Company> Companies = new List<BrokerDLL.Serializable.Company>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstateCompanies.Where(RS => RS.ActivateStatusID == (int)BrokerDLL.Activestatus.Active)
                    .OrderByDescending(B=>B.IsSpecial).ThenByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => Companies.Add(new BrokerDLL.Serializable.Company(RS)));
                return Companies;
            }
        }

        public List<int> GetCompaniesCount(string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                //  int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<int> Pages = new List<int>();
                int Count = Context.RealEstateCompanies.Where(RS => RS.ActivateStatusID == (int)BrokerDLL.Activestatus.Active).Count();

                double counter = Convert.ToDouble(Count) / Size;
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
                //return Companies;
            }
        }


        public Company GetCompany(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstateCompany Company = Context.RealEstateCompanies.FirstOrDefault(R => R.ID == id && R.ActivateStatusID == (int)BrokerDLL.Activestatus.Active);
                return new BrokerDLL.Serializable.Company(Company);
            }
        }


        public string ContactCompany(CompanyMessage CompanyMail)
        {
            try
            {
                using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
                {

                    string Email = "";
                    BrokerDLL.CompanyMessage message = new BrokerDLL.CompanyMessage();
                    message.CreatedDate = DateTime.Now;
                    message.Email = CompanyMail.Email;
                    message.Message = CompanyMail.Message;
                    message.Name = CompanyMail.Name;
                    message.Phone = CompanyMail.Phone;
                    message.IsRead = false;
                    if (CompanyMail.ProjectID != "" && CompanyMail.ProjectID != null)
                    {
                        BrokerDLL.RealEstateProject Project;
                        int ProjectId = Convert.ToInt32(CompanyMail.ProjectID);
                        Project = Context.RealEstateProjects.FirstOrDefault(P => P.ID == ProjectId);
                        if (Project != null)
                        {
                            message.ProjectID = ProjectId;
                            message.CompanyID = Project.CompanyID;
                            Email = Project.RealEstateCompany.Email;
                        }
                    }
                    if (CompanyMail.CompanyID != "" && CompanyMail.CompanyID != null)
                    {
                        BrokerDLL.RealEstateCompany Company;
                        int Companyid = Convert.ToInt32(CompanyMail.CompanyID);
                        Company = Context.RealEstateCompanies.FirstOrDefault(C => C.ID == Companyid);
                        if (Company != null)
                        {
                            message.CompanyID = Companyid;
                            Email = Company.Email;
                        }
                    }

                    Context.CompanyMessages.AddObject(message);
                    Context.SaveChanges();
                    Dictionary<string, string> Msg = new Dictionary<string, string>();
                    Msg.Add("Name", message.Name);
                    Msg.Add("Phone", message.Phone);
                    Msg.Add("Email", message.Email);
                    Msg.Add("Message", message.Message);
                    BrokerDLL.Commons.SendEmail(BrokerDLL.EmailType.ContactCompany, Email, Msg);
                    return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Send);
                }
            }
            catch (Exception ex)
            {
                return BrokerDLL.Commons.GetValue(BrokerDLL.Message.Error);

            }
        }

        public string Login(Login account)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                if (Membership.FindUsersByName(account.UserName).Count == 0)
                {
                    return "Error:" + BrokerDLL.Commons.GetValue(BrokerDLL.Message.UserNameNotExist);
                }
                if (!Membership.ValidateUser(account.UserName, account.Password) && !FormsAuthentication.Authenticate(account.UserName, account.Password))
                {
                    return "Error:" + BrokerDLL.Commons.GetValue(BrokerDLL.Message.LoginError);
                }
                BrokerDLL.Commons.UserName = account.UserName;
                if (Roles.IsUserInRole(account.UserName, "Subscriber"))
                {
                    BrokerDLL.Commons.Subsciber = Context.Subscribers.FirstOrDefault(S => S.UserName == account.UserName);
                }
                return "Success";
            }
        }

        public List<BrokerDLL.Serializable.Advertisement> GetAdvertisement()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Count = Context.Advertisements.Count();
                //int index = r.Next(Count);
                List<BrokerDLL.Serializable.Advertisement> Ads = new List<Advertisement>();
                Context.Advertisements.ToList().ForEach(A => Ads.Add(new Advertisement(A)));
                return Ads;
                //BrokerDLL.Serializable.Project Projects = new List<BrokerDLL.Serializable.Project>();
                //Context.RealEstateProjects.Where(RS => RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active && RS.AdPackageID == (int)BrokerDLL.AdvPackage.SpecialPayed).ToList()
                //    .ForEach(RS => Projects.Add(new BrokerDLL.Serializable.Project(RS)));
                //return Projects[r.Next(Projects.Count)];
                //return Projects;
            }
        }

        public bool AddToSiteMap(string URL, string Query)
        {
            string Code = DateTime.Now.Ticks.ToString();
            URL = URL.Replace(";", "/");
            Query = Query.Replace(";", "/");
            BrokerDLL.General.SiteMapGenerator.AddToStaticSiteMap(URL, Code, Query);
            return true;
        }

        public Catalog GetCatalog(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstateCatalog Catalog = Context.RealEstateCatalogs.FirstOrDefault(R => R.ID == id);
                return new BrokerDLL.Serializable.Catalog(Catalog);
            }
        }

        public List<Tag> GetTags(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstateCatalog Catalog = Context.RealEstateCatalogs.FirstOrDefault(R => R.ID == id);
                List<Tag> Tags=new List<Tag>();
                if (Catalog.AllTags == true)
                {
                    int Count = Context.Tags.Count();
                    Random r = new Random();
                    int i = 0;// r.Next(Count);
                    Context.Tags.OrderBy(T => T.Name).Skip(i).ToList().ForEach(T => Tags.Add(new Tag(T)));

                }
                else
                {
                    List<int> ids = new List<int>();
                    Context.RealestateCatalogTags.Where(ct => ct.CatalogID == id).ToList().ForEach(ct => ids.Add(ct.TagID.Value));
                    foreach (int i in ids)
                    {
                        Context.Tags.Where(T => T.ID == i || T.ParentTagID == i).ToList().ForEach(T => Tags.Add(new Tag(T)));
                    }
                }
                return Tags;
            }
        }
        public string CheckLogin()
        {
            if(HttpContext.Current.Session["Subscriber"] != null)
            {
                return "true";
            }
            else
            {
                return "wrong";
            }
        }
    }
}
