using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;
using BrokerDLL.General;
using System.Configuration;

namespace BrokerDLL
{
    public enum AdvPackage
    { 
        Normal=1,
        HomePage=2,
        Banner=3,
        Partner=4
    }
    public enum OfferTypes
    {
        [EnumValue("عرض/خصم على منتجات")]
    ItemOffer=1,
        [EnumValue("عرض/خصم على عقارات")]
        RealEstateOffer=2
    }
    public enum MessageType
    {
        Success,
        Error,

    }
    public enum PageMode
    {
        Add,
        Edit,
        Delete,
        Search,
        EditNew,
        View,
        Disable
    }
    public enum Activestatus
    {
        New = 1,
        Updated = 5,
        Suspended = 4,
        Reviewing = 2,
        Reviewed = 3,
        Pending=6,
        Active=7,
        Migrated=8
    }
    public enum Message
    {
        [EnumValue("تم الحفظ بنجاح")]
        Save,
        [EnumValue("اسم المستخدم متاح")]
        UsernameAvailable,
        [EnumValue("اسم المستخدم غير متاح")]
        UsernameNotAvailable,
        [EnumValue(" كلمة السر غير صحيحة")]
        LoginError,
        [EnumValue("اسم المستخدم غير صحيح")]
        UserNameNotExist,
        [EnumValue("تم الحذف بنجاح")]
        Delete,
        [EnumValue("لا يمكن حذفه هناك بيانات متصلة به")]
        HasChildrenError,
        [EnumValue("تم تحديد الصورة كصورة رئيسية بنجاح")]
        DefaultPhotoChanged,
        [EnumValue("يجب ادخال ارقام فقط")]
        ValidateNumber,
        [EnumValue("الايميل مسجل من قبل")]
        EmailRegistered,
        [EnumValue("الايميل متاح")]
        EmailValid,
        [EnumValue(" كود تفعيل حسابك غير صحيح")]
        AccountActivationFailed,
        [EnumValue("تم ارسال كود تفعيل حسابك الى الايميل الخاص بك")]
        ActivationCodeSent,
        [EnumValue("الايميل غير مسجل من قبل")]
        EmailNotRegistered,
        [EnumValue("تم ارسال كلمة السرالى الايميل الخاص بك")]
        PasswordSentToEmail,
        [EnumValue("تم الارسال بنجاح")]
        Send,
        [EnumValue("تم التفعيل بنجاح")]
        ActivateObject,
        [EnumValue("تم الحجب بنجاح")]
        SuspendedObject,
        [EnumValue("تم حجب البيانات بسبب: ")]
        Suspended,
        [EnumValue("تم الحفظ بنجاح, سيتم مراجعة البيانات قبل عرضها على الموقع")]
        SaveAndMessage,
        [EnumValue("لقد تم حفظ البيانات الاساسية الرجاء ادخال باقى البيانات, سيتم مراجعة البيانات قبل عرضها على الموقع")]
        SaveNewAndMessage,
        [EnumValue("يجب ان لا يقل ابعاد الصورة عن 200 بكسل")]
        InvalidPhoto,
        [EnumValue("حجم الصورة يجب ان لا يزيد عن 1 ميجا")]
        InvalidPhotoSize,
        [EnumValue("لقد حدث خطأ, الرجاء المحاولة مرة اخرى")]
        Error,
        [EnumValue("! اسم المستخدم يجب ان يكون باللغة الأنجليزية و يتكون من حروف و ارقام فقط")]
        UserNameInvalidChars,
        [EnumValue("تم التعديل بنجاح")]
        ClosedSuccessfully,
        [EnumValue("عفوا, لا يمكنك اضافة مستخدم جديد قبل اضافة بيانات الشركة")]
        UserCompanyNotExist,
        [EnumValue("عذرا، لا يمكنك إضافة مستخدم جديد لأن عدد المستخدمين وصل بالفعل العدد المسموح به. لمزيد من المعلومات يرجى الاتصال بخدمة دعم العملاء")]
        CompanyInvalidUserNos,
        [EnumValue("تم الحفظ بنجاح، سيتم إرسال رمز التفعيل إلى البريد الإلكتروني للمستخدم")]
        SaveNewCompanyUser,
        [EnumValue("عفوا, لا يمكنك حذف المستخدم  قبل نقل العقارات الخاصة به لمستخدم اخر")]
        UserCantBeDeleted,
        [EnumValue("عفوا, لا يمكنك اضافة مشروع جديد قبل اضافة بيانات الشركة")]
        ProjectCompanyNotExist,
        [EnumValue("عذرا، لا يمكنك إضافة مشروع جديد لأن عدد المشروعات وصل بالفعل العدد المسموح به. لمزيد من المعلومات يرجى الاتصال بخدمة دعم العملاء")]
        CompanyInvalidProjectNos,
        [EnumValue("عفوا, لا يمكنك حذف كلمة بحث أساسية لان لديها كلمات متصلة بها")]
        KeywordHasChildren,
        [EnumValue("العقار يجب ان يكون مفعل")]
        MustBeActive,
        [EnumValue("كود العقار غير صحيح")]
        CodeNotExist,
        [EnumValue("تم ادخاله  من قبل")]
        AlreadyExist,
    }
    public enum EmailType
    {
         [EnumValue("كود تفعيل حسابك على الموقع ")]
        ActivateAccount,
         [EnumValue("بيانات حسابك على الموقع")]
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
    Companies=1,
        [EnumValue("عقارات")]
        RealEstates=2,
        [EnumValue("مشروعات")]
        Projects=3,
        [EnumValue("عروض/خصومات")]
        Offers=4
    }
    public enum subscriberActions
    {
        [EnumValue("جديد")]
    AddNew=1,
        [EnumValue("اضافة صورة")]
        AddPhoto=2,
        [EnumValue("اضافة فرع")]
        AddBranch=3,
        [EnumValue("تعديل")]
        Updated=4,
        [EnumValue("تعديل فرع")]
        UpdateBranch
    }
    public static class Commons
    {
        static BrokerEntities _Context;
        public static BrokerEntities Context
        {
            get
            {
                if (_Context == null)
                {
                    _Context = new BrokerEntities();
                } return Commons._Context;
            }
            set
            {
                _Context = value;
            }
        }
        public static Subscriber Subsciber
        {
            get
            {
                if (HttpContext.Current.Session["Subscriber"] != null)
                {
                    return (Subscriber)HttpContext.Current.Session["Subscriber"];
                }
                else
                {
                    HttpContext.Current.Response.RedirectToRoute("Login");
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["Subscriber"] = value;
            }
        }
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] != null)
                {
                    return HttpContext.Current.Session["UserName"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }
        //public static SearchCriteria SearchCriteria
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Session["SearchCriteria"] != null)
        //        {
        //            return (SearchCriteria)HttpContext.Current.Session["SearchCriteria"];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["SearchCriteria"] = value;
        //    }
        //}
        public static string GetValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            EnumValue[] attribs = fieldInfo.GetCustomAttributes(
                typeof(EnumValue), false) as EnumValue[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
        public static int SaveKeyword(string Title)
        {
            Keyword keyword = Context.Keywords.FirstOrDefault(K => K.Title == Title);
            if (keyword == null)
            {
                keyword = new Keyword();
                keyword.Title = Title;
                Context.Keywords.AddObject(keyword);
                Context.SaveChanges();
            }
            return keyword.ID;
        }
        public static void SaveThumpImage(string OriginalImagePath, string thumpName)
        {
            System.Drawing.Image OriginalImage = System.Drawing.Image.FromFile(OriginalImagePath);
        }

        public static void SendEmail(EmailType emailType, string reciever, Dictionary<string, string> Code)
        {
            Email email = new Email();
            email.EmailType = emailType;
            email.HasAttachment = false;
            email.MailCriteria = Code;
            email.Recievers = new List<string>();
            email.Recievers.Add(reciever);
            if(emailType==EmailType.ActivateAccount || emailType==EmailType.ContactCompany)
            {
            email.BC = new List<string>();
            email.BC.Add(ConfigurationSettings.AppSettings["ContactUsEMail"].ToString());
            }
            email.Send();
        }

        public static string CreateActivationCode()
        {
            Random random = new Random();
            //StringBuilder builder = new StringBuilder();
            string Code;
            //char ch;
            //for (int i = 0; i < random.Next(10, 30); i++)
            //{
            //    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            //    builder.Append(ch);
            //}
            //Code = random.Next(1000000).ToString() + builder.ToString() + random.Next(1000000).ToString();
            Code = random.Next(1000,1000000).ToString();
            return Code;
        }
        public static string CreatePasswordCode()
        {
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            string Code;
            char ch;
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            Code = random.Next(1000000).ToString();// + builder.ToString();
           // Code = random.Next(1000, 1000000).ToString();
            return Code;
        }

        public static int CountUnReadMessages()
        {
            if (Subsciber != null)
            {
                int Count = Commons.Context.SubscriperMessages.Count(M => M.FromSubscriber == false && M.To == Commons.Subsciber.ID
                                    && M.IsClosed == false && M.IsRead == false);
                return Count;
            }
            else
            {
                return 0;
            }
        }

        public static int CountUnReadPurchaseRequest()
        {
            if (Subsciber != null)
            {
                int RequestNo = Commons.Context.RealEstatePurchaseRequests.Count(R => R.RealEstate.SubscriberID == Commons.Subsciber.ID && R.IsDeleted == false && R.IsRead == false);
                return RequestNo;
            }
            else
            {
                return 0;
            }
        }

        internal static void SendSMS(string mobileNo, string code)
        {
            SMS sms = new SMS();
            sms.Lang = SMSLanguage.A;
            sms.Receiver = mobileNo;
            sms.Text = "كود تفعيل حسابك على الموقع: " + code;
            sms.Send();

        }
    }
}
