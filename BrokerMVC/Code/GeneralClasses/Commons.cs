using BrokerMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResourcesFiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BrokerMVC
{
    public enum Roles
    {
        Admin,
        Subscriber,
        CompanyAdmin,
        CompanyEmployee,
        Employee,
    }
    public enum MessageSeverity
    {
        None,
        Info,
        Success,
        Warning,
        Danger
    }
    public enum ActiveStatus
    {
        New = 1,
        Reviewing = 2,
        Reviewed = 3,
        Suspended = 4,
        updated = 5,
        Pending = 6,
        Active = 7,
        Migrated = 8,
        IncompleteAddress = 9,
        IncompletePhotos = 10,
    }
    public enum CriteriaValueType
    {
        [EnumValue("نعم\\لا")]
        [EnumEngValue("Yes\\No")]
        bool_Type,
        [EnumValue("ارقام")]
        [EnumEngValue("Numbers")]
        int_Type,
        [EnumValue("احرف")]
        [EnumEngValue("Letters")]
        string_Type,
    }
    public enum Menu
    {
        [EnumValue("الرئيسية")]
        [EnumEngValue("Homepage")]
        Homepage,
        [EnumValue("الفئة")]
        [EnumEngValue("Category")]
        Category,
        [EnumValue("النوع")]
        [EnumEngValue("Type")]
        Type,
        [EnumValue("مشاريع_عقارية")]
        [EnumEngValue("Projects")]
        Projects,
        [EnumValue("شركات_عقارية")]
        [EnumEngValue("Companys")]
        Companys,
        [EnumValue("دخول")]
        [EnumEngValue("Login")]
        Login,
        [EnumValue("تسجيل")]
        [EnumEngValue("Register")]
        Register,
        [EnumValue("الدعم_الفنى")]
        [EnumEngValue("Technical_Support")]
        TechnicalSupport,
        [EnumValue("آخر_الوحدات_المضافة")]
        [EnumEngValue("Latest_Added")]
        LatestAdded,
        [EnumValue("الايجار")]
        [EnumEngValue("For_Rent")]
        Rent,
        [EnumValue("وحدات_سكنية")]
        [EnumEngValue("Resdintial")]
        Resdintial,
        [EnumValue("وحدات_تجارية")]
        [EnumEngValue("Commercial")]
        Commercial,
        [EnumValue("اراضى")]
        [EnumEngValue("Lands")]
        Lands,
        [EnumValue("قارن_الوحدات")]
        [EnumEngValue("CompareList")]
        CompareList,
        [EnumValue("انواع_لاشتراكات")]
        [EnumEngValue("Supscription_Types")]
        SupscriptionTypes,
        [EnumValue("الخدمات_التسويقية")]
        [EnumEngValue("Marketing_Services")]
        MarketingServices,
    }
    public enum SupscriptionType
    {
        [EnumValue("فردي")]
        [EnumEngValue("individual")]
        Individual,
        [EnumValue("مدير")]
        [EnumEngValue("Company Admin")]
        CompanyAdmin,
        [EnumValue("موظف")]
        [EnumEngValue("Company Employee")]
        CompanyEmployee,
    }
    public enum AdPackage
    {
        Normal = 1,
        HomePage = 2,
        Banner = 3,
        Partner = 4,
    }
    public enum EmailType
    {
        [EnumValue("كود تفعيل حسابك على الموقع ")]
        ActivateAccount,
        [EnumValue("كود استرجاع كلمة مرور حسابك على الموقع ")]
        ForgetPassword,
        [EnumValue("تلقيت رسالة من إدارة الموقع ")]
        ReplyMessage,
        [EnumValue("تم مراجعة  بيانات خاصة بك")]
        ActivateBusiness,
        [EnumValue("تم حجب بيانات  خاصة بك")]
        SuspendBusiness,
        [EnumValue("إتصل بنا")]
        ContactUs,
        [EnumValue("رسالة جديدة من احد العملاء")]
        ContactCompany,
        [EnumValue("طلب شراء جديد")]
        PurchaseRequest,
        [EnumValue("طلب بحث عن عقار")]
        NotifyRequest,
        [EnumValue("كود تاكيد بيانات الاتصال ")]
        ValidateAccount,
        [EnumValue("مرحبا بك فى عقار ستوك")]
        GeneratePassword,
        [EnumValue("خدمة الرسائل متوقفة")]
        SMSNotWorking,
    }
    public enum Modules
    {
        [EnumValue("شركات")]
        [EnumEngValue("Real estates")]
        Companies = 1,
        [EnumValue("عقارات")]
        [EnumEngValue("Companies")]
        RealEstates = 2,
        [EnumValue("مشروعات")]
        [EnumEngValue("Projects")]
        Projects = 3,
        [EnumValue("عروض/خصومات")]
        [EnumEngValue("Offers")]
        Offers = 4
    }
    public enum subscriberActions
    {
        [EnumValue("جديد")]
        [EnumEngValue("Add")]
        AddNew = 1,
        [EnumValue("اضافة صورة")]
        [EnumEngValue("Add Photo")]
        AddPhoto = 2,
        [EnumValue("اضافة فرع")]
        [EnumEngValue("Add Branch")]
        AddBranch = 3,
        [EnumValue("تعديل")]
        [EnumEngValue("Edit")]
        Updated = 4,
        [EnumValue("تعديل فرع")]
        [EnumEngValue("Edit Branch")]
        UpdateBranch
    }
    public enum AdsTypes{
        _ContnetSide,
        _HomePageMainLarge,
        _HomePageMainSmall,
        _HomePageSide
    }
    public enum Pages
    {
        HomePage=1,
        TechnicalSupport=2,
        ProjectList=3,
        PropertyList=4,
        CompanyList=5,
        SupscriptionTypes=6,
        Services=7
    }
    public enum SaleTypes
    {
        [EnumValue("للبيع")]
        [EnumEngValue("for Sale")]
        Sale=1,
        [EnumValue("للإيجار")]
        [EnumEngValue("for Rent")]
        Rent=2
    }
    public enum InquiryType
    {
        PurchaseRequest,
        CompanyMessage
    }
    public static class Constants
    {
        public const string TempDataKey = "Messages";
    }
    public static class Commons
    {
       public static List<RealEstate> CompareList
        {
            get
            {
                if(HttpContext.Current.Session["CompareList"]==null)
                {
                    HttpContext.Current.Session["CompareList"] = new List<RealEstate>();
                }
                return (List<RealEstate>)HttpContext.Current.Session["CompareList"];
            }
            set
            {
                HttpContext.Current.Session["CompareList"] = value;
            }
        }
        public static string Culture
        {
            get
            {

                return System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();
            }
        }
        public static string UserName
        {
            get
            {

                return HttpContext.Current.User.Identity.Name;
            }
        }
        public static int? UserID
        {
            get
            {
                if (HttpContext.Current.Session["ID"] != null)
                    return (int)HttpContext.Current.Session["ID"];
                else
                {
                    //if(!HttpContext.Current.User.Identity.IsAuthenticated)
                    //{
                    //    RedirectResult r = new RedirectResult("~/Account/LogOff");

                    //}
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["ID"] = value;
            }
        }
        public static string GetValue(this Enum value)
        {
            // Get the type
            System.Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());
            if (Culture == "ar")
            {
                // Get the stringvalue attributes
                EnumValue[] attribs = fieldInfo.GetCustomAttributes(
                    typeof(EnumValue), false) as EnumValue[];

                // Return the first if there was a match.
                return attribs.Length > 0 ? attribs[0].StringValue : null;
            }
            else
            {
                // Get the stringvalue attributes
                EnumEngValue[] attribs = fieldInfo.GetCustomAttributes(
                    typeof(EnumEngValue), false) as EnumEngValue[];

                // Return the first if there was a match.
                return attribs.Length > 0 ? attribs[0].StringValue : null;
            }
        }

        public static string EncodeText(string text)
        {
            return Regex.Replace(text, "[^0-9a-zA-Zء-ي]+", "_");
            //UTF8Encoding encoder = new UTF8Encoding();
            //byte[] bytes = Encoding.UTF8.GetBytes(text);
            //return (Regex.Replace(encoder.GetString(bytes), "[^0-9a-zA-Zء-ي]+", "-"));
        }

        public static void RemoveLog(int objectId, int objectTypeId)
        {
            RealEstateBrokerEntities db = new RealEstateBrokerEntities();
            List<SubscriberLog> Logs = db.SubscriberLogs.Where(L => L.ObjectID == objectId && L.ObjectTypeID == objectTypeId).ToList();
            if (Logs != null && Logs.Count > 0)
            {
                Logs.ForEach(Log => db.SubscriberLogs.Remove(Log));
                db.SaveChanges();
            }

        }

        public static string GetActionType(int? ActionID)
        {
            subscriberActions action = (subscriberActions)Enum.Parse(typeof(subscriberActions), ActionID.ToString());
            switch (action)
            {
                case subscriberActions.AddNew:
                    return subscriberActions.AddNew.GetValue();
                case subscriberActions.AddBranch:
                    return subscriberActions.AddBranch.GetValue();
                case subscriberActions.AddPhoto:
                    return subscriberActions.AddPhoto.GetValue();
                case subscriberActions.UpdateBranch:
                    return subscriberActions.UpdateBranch.GetValue();
                case subscriberActions.Updated:
                    return subscriberActions.Updated.GetValue();
                default:
                    return subscriberActions.AddNew.GetValue();
            }
        }
        public static string GetObjectType(int? ObjectID)
        {
            Modules objecttype = (Modules)Enum.Parse(typeof(Modules), ObjectID.ToString());
            switch (objecttype)
            {
                case Modules.Companies:
                    return Modules.Companies.GetValue();
                case Modules.Offers:
                    return Modules.Offers.GetValue();
                case Modules.Projects:
                    return Modules.Projects.GetValue();
                case Modules.RealEstates:
                    return Modules.RealEstates.GetValue();
                default:
                    return Modules.RealEstates.GetValue();
            }
        }

        public static List<SelectListItem> GetSaleTypeList()
        {
            List<SelectListItem> types = new List<SelectListItem>();
            SelectListItem item = new SelectListItem();
            item.Text = SaleTypes.Sale.GetValue();
            item.Value = ((int)SaleTypes.Sale).ToString();
            types.Add(item);
            item = new SelectListItem();
            item.Text = SaleTypes.Rent.GetValue();
            item.Value = ((int)SaleTypes.Rent).ToString();
            types.Add(item);
            return types;
        }
        public static List<SelectListItem> GetPriceList()
        {
            int[] prices =new int[] { 1000, 5000, 10000, 15000, 20000, 50000, 100000, 250000, 500000, 1000000, 5000000, 10000000, 20000000, 50000000, 100000000 };
            List<SelectListItem> types = new List<SelectListItem>();
            SelectListItem item;
            foreach( int price in prices)
            {
                item = new SelectListItem();
                item.Text = General.Less+" "+price.ToString();
                item.Value = price.ToString();
                types.Add(item);
            }
        
            return types;
        }
        public static List<SelectListItem> GetSupscriptionTypeList()
        {
            string[] prices = new string[] { };
            List<SelectListItem> types = new List<SelectListItem>();
            SelectListItem item;
            //foreach (ActiveStatus price in ActiveStatus)
            //{
            //    item = new SelectListItem();
            //    item.Text = General.Less + " " + price.ToString();
            //    item.Value = price.ToString();
            //    types.Add(item);
            //}

            return types;
        }
        public static List<SelectListItem> GetAreaList()
        {
            int[] prices = new int[] { 100, 200 , 500 , 1000 , 1500 , 2000 , 2500 , 3000 , 5000 , 10000 };
            List<SelectListItem> types = new List<SelectListItem>();
            SelectListItem item;
            foreach (int price in prices)
            {
                item = new SelectListItem();
                item.Text = General.Less + " " + price.ToString()+" "+General.Meter;
                item.Value = price.ToString();
                types.Add(item);
            }

            return types;
        }

        public static List<SelectListItem> GetCriteriaValueList()
        {
            List<SelectListItem> ValueType = new List<SelectListItem>();
            ValueType.Add(new SelectListItem() { Text = CriteriaValueType.bool_Type.GetValue(), Value = "bool" });
            ValueType.Add(new SelectListItem() { Text = CriteriaValueType.int_Type.GetValue(), Value = "int" });
            ValueType.Add(new SelectListItem() { Text = CriteriaValueType.string_Type.GetValue(), Value = "string" });
            return ValueType;
        }

        internal static string CreateActivationCode()
        {
            Random random = new Random();
            string Code;
            Code = random.Next(100000, 1000000).ToString();
            return Code;
        }

        public static void ContactUser(Subscriber user)
        {
            Dictionary<string, string> Code = new Dictionary<string, string>();
            Code.Add("Code", user.ActivationCode);
            SendEmail(EmailType.GeneratePassword, user.Email, Code);
            SendSMS(user.MobileNo, user.ActivationCode, SMSMessages.ForgetPassword);
        }
        public static void SendEmail(EmailType emailType, string reciever, Dictionary<string, string> Code)
        {
            Email email = new Email();
            email.EmailType = emailType;
            email.HasAttachment = false;
            email.MailCriteria = Code;
            email.Recievers = new List<string>();
            email.Recievers.Add(reciever);
            if (emailType == EmailType.ActivateAccount || emailType == EmailType.ContactCompany)
            {
                email.BC = new List<string>();
                email.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
            }
            email.Send();
        }

        internal static void SendSMS(string mobileNo, string code, SMSMessages Msg)
        {
            SMS sms = new SMS();
            sms.Lang = SMSLanguage.A;
            sms.Receiver = mobileNo;
            sms.Text = Msg.GetValue() + code;
            sms.Send();

        }
        public static void Log(Modules module, subscriberActions action, int objectID, string objectName)
        {
            RealEstateBrokerEntities db = new RealEstateBrokerEntities();
            SubscriberLog Logger;
            if (action != subscriberActions.AddNew)
            {
                Logger = db.SubscriberLogs.FirstOrDefault(SL => SL.ObjectTypeID == (int)module && SL.ObjectID == objectID);
                if (Logger != null)
                {
                    if (Logger.ActionID == (int)subscriberActions.AddNew)
                    {
                        return;
                    }
                    if (action == subscriberActions.Updated && Logger.ActionID == (int)subscriberActions.Updated)
                    {
                        return;
                    }
                }
            }
            Logger = new SubscriberLog();
            Logger.ActionID = (int)action;
            Logger.Date = DateTime.Now;
            Logger.ObjectID = objectID;
            Logger.ObjectTypeID = (int)module;
            Logger.ObjectName = objectName;
            db.SubscriberLogs.Add(Logger);
            db.SaveChanges();
        }
    }
}