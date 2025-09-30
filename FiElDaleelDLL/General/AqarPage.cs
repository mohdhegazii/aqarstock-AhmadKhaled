using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;
using System.Web.Security;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Script.Services;
//using System.Web.;

namespace BrokerDLL.General
{
    public abstract class AqarPage : System.Web.UI.Page
    {
        public static List<Serializable.RealEstate> CompareRealestates {
            get
            {
                if (HttpContext.Current.Session["CompareRealestates"] != null)
                {
                    return (List<Serializable.RealEstate>)HttpContext.Current.Session["CompareRealestates"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["CompareRealestates"] = value;
            }
        }
      
        [WebMethod]
        public static string Signin(string username, string password)
        {
            if (Membership.FindUsersByName(username).Count == 0)
            {
                return Message.UserNameNotExist.GetValue();
            }
            if (!Membership.ValidateUser(username, password) && !FormsAuthentication.Authenticate(username, password))
            {
                return Message.LoginError.GetValue();
            }
            
            Commons.UserName = username;
            FormsAuthentication.RedirectFromLoginPage(username, true);
            if (Roles.IsUserInRole(username, "Admin"))
            {
              //  HttpContext.Current.Response.Redirect("~/AdminDashboard");
                return "Admin";
            }
            if (Roles.IsUserInRole(username, "Subscriber"))
            {
                Commons.Subsciber = Commons.Context.Subscribers.FirstOrDefault(S => S.UserName == username);
                string PurchaseRequestNo = GetPurchaseRequest();
                return "Subscriber /"+Commons.Subsciber.FullName+"/"+PurchaseRequestNo;
            }
            return "error";
        }

        [WebMethod]
        public static string SignOut()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            return "success";
        }

        [WebMethod]
        public static string CheckLogginStatus()
        {
            if (HttpContext.Current.Session["Subscriber"] != null)
            {
                string PurchaseRequestNo = GetPurchaseRequest();
                return Commons.Subsciber.FullName + "/" + PurchaseRequestNo;
            }
            else
            {
                return "None";
            }
        }
        [WebMethod]
        public static string GetPurchaseRequest()
        {
            if (HttpContext.Current.Session["Subscriber"] != null)
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    return Context.RealEstatePurchaseRequests.Where(R => R.RealEstate.SubscriberID == Commons.Subsciber.ID && R.IsRead == false && R.IsInquiry==false).Count().ToString();
                }
            }
            else
            {
                return "0";
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool AddToCompareList(string realestateId)
        {
           
            int id = Convert.ToInt32(realestateId);
            if (CompareRealestates == null)
            {
                CompareRealestates = new List<Serializable.RealEstate>();
            }
            else
            {
                if (CompareRealestates.Count >= 5)
                {
                    return false;
                }
                Serializable.RealEstate temp = CompareRealestates.FirstOrDefault(R => R.ID == id);
                if (temp != null)
                {
                    return true;
                }
            }
            
           using (BrokerEntities Context = new BrokerEntities())
            {
                BrokerDLL.RealEstate realestate = Context.RealEstates.FirstOrDefault(r => r.ID == id);
                CompareRealestates.Add(new Serializable.RealEstate(realestate,true));
            }
            return true;
        }

        [WebMethod]
        public static string RemoveFromCompareList(string realestateId)
        {
            int id = Convert.ToInt32(realestateId);
            CompareRealestates.RemoveAll(R => R.ID == id);
            return realestateId;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static List<Serializable.RealEstate> GetCompareList()
        {
            return CompareRealestates;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static bool AddToFavouriteList(string realestateId)
        {
            if (HttpContext.Current.Session["Subscriber"] != null)
            {
                int id = Convert.ToInt32(realestateId);
                using (BrokerEntities Context = new BrokerEntities())
                {
                    BrokerDLL.SubscriberFavouriteRealEstate Favrealestate = Context.SubscriberFavouriteRealEstates.FirstOrDefault(r => r.RealEstateID == id && r.SubScriberID==Commons.Subsciber.ID);
                    if (Favrealestate == null)
                    {
                        Favrealestate = new SubscriberFavouriteRealEstate();
                        Favrealestate.SubScriberID = Commons.Subsciber.ID;
                        Favrealestate.RealEstateID = id;
                        Context.SubscriberFavouriteRealEstates.AddObject(Favrealestate);
                        Context.SaveChanges();
                    }
                   // CompareRealestates.Add(new Serializable.RealEstate(realestate, true));
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string AddToSiteMap(string URL,string Query)
        {
            try
            {
                string Code = DateTime.Now.Ticks.ToString();
                BrokerDLL.General.SiteMapGenerator.AddToStaticSiteMap(URL, Code, Query);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
