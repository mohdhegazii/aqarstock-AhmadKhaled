using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Net;
using System.IO;
using BrokerDLL.General;
using System.Data;

namespace BrokerDLL.Migration.Classes
{
    public  class PropertyFinderXMLMigration : IMigrateFromXML
    {
       public bool MigrateFromXML(string File)
       {
           using (MigratedRealEstatesEntities Context = new MigratedRealEstatesEntities())
           {
              // List<PropertyFinderRealEstatesSchema> Realestates = new List<PropertyFinderRealEstatesSchema>();
               XmlDocument doc = new XmlDocument();
               string path = HttpContext.Current.Server.MapPath("~/XMLFiles/Zamalekpropertyfinder.Xml");
               doc.Load(path);
               //XmlNamespaceManager XmlNC = new XmlNamespaceManager(doc.NameTable);
               //XmlNC.AddNamespace("nc", "http://www.sitemaps.org/schemas/sitemap/0.9");
               XmlNode root = doc.DocumentElement;
               PropertyFinderRealEstatesSchema realestate;
               foreach (XmlNode Node in root.ChildNodes)
               {
                   realestate = new PropertyFinderRealEstatesSchema();
                   realestate.agent_email = Node["agent_email"].InnerText;
                   realestate.agent_name = Node["agent_name"].InnerText;
                   realestate.agent_number = Node["agent_number"].InnerText;
                   realestate.bathroom = Convert.ToInt32( Node["bathroom"].InnerText);
                   realestate.bedroom = Convert.ToInt32( Node["bedroom"].InnerText);
                   realestate.category = Node["category"].InnerText;
                   realestate.city_province = Node["city_province"].InnerText;
                   realestate.Code = Node["reference"].InnerText;
                   realestate.description_ar = Node["description_ar"].InnerText;
                   realestate.district = Node["district"].InnerText;
                   realestate.photo_url_1 = Node["photo_url_1"].InnerText;
                   realestate.photo_url_10 = Node["photo_url_10"].InnerText;
                   realestate.photo_url_2 = Node["photo_url_2"].InnerText;
                   realestate.photo_url_3 = Node["photo_url_3"].InnerText;
                   realestate.photo_url_4 = Node["photo_url_4"].InnerText;
                   realestate.photo_url_5 = Node["photo_url_5"].InnerText;
                   realestate.photo_url_6 = Node["photo_url_6"].InnerText;
                   realestate.photo_url_7 = Node["photo_url_7"].InnerText;
                   realestate.photo_url_8 = Node["photo_url_8"].InnerText;
                   realestate.photo_url_9 = Node["photo_url_9"].InnerText;
                   realestate.price = Node["price"].InnerText;
                   realestate.sqm = Convert.ToInt32( Node["sqm"].InnerText);
                   realestate.title_ar = Node["title_ar"].InnerText;
                   realestate.town_area = Node["town_area"].InnerText;
                   if (Node["type"] != null)
                   {
                       realestate.type = Node["type"].InnerText;
                   }

                   Context.PropertyFinderRealEstatesSchema.AddObject(realestate);
               }
               Context.SaveChanges();
           }
           return true;
       }

       public bool MigrateToBrokerDB(int SubscriperId,int No)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               using (MigratedRealEstatesEntities MigContext = new MigratedRealEstatesEntities())
               {
                   int i = 0;
                   List<PropertyFinderRealEstatesSchema> List=MigContext.PropertyFinderRealEstatesSchema.Where(R => R.description_ar !=""
                       && R.district!="" && R.photo_url_1!="" && R.agent_number!="" && R.type!="" && R.title_ar!=""
                       && R.agent_email.IndexOf("@") >= 0 && (R.IsMigrated != true || R.IsMigrated == null)).Take(No).ToList();
                   if (List.Count <= 0)
                   {
                       return false;
                   }
                   foreach (PropertyFinderRealEstatesSchema MigrealEstate in List)
                   {
                 //  PropertyFinderRealEstatesSchema MigrealEstate = MigContext.PropertyFinderRealEstatesSchema.FirstOrDefault(R => R.Code == "19848");
                   BrokerDLL.District district=Context.Districts.FirstOrDefault(D=>D.ID==MigrealEstate.DistrictID);
                   BrokerDLL.RealEstateType type=Context.RealEstateTypes.FirstOrDefault(T=>T.ID==MigrealEstate.TypeID);
                   RealEstate realestate = new RealEstate();
                   realestate.ActiveStatusId = (int)Activestatus.Migrated;
                   realestate.Area = MigrealEstate.sqm;
                   realestate.CityID = district.CityID;
                   realestate.Code = Context.RealEstates.Max(R => R.Code) + 1;
                   realestate.CountryID = district.City.CountryID;
                   realestate.CreatedDate = DateTime.Now.Subtract(new TimeSpan(5*i, 23, 0, 0));
                   realestate.Description = MigrealEstate.description_ar;
                   realestate.DistrictID = district.ID;
                   realestate.IsMigrated = true;
                   realestate.IsSold = false;
                   realestate.Latitude ="28.998531814051795";
                   realestate.Longitude = "31.1572265625";
                   realestate.OwnerEmail = MigrealEstate.agent_email;
                   realestate.OwnerMobile = MigrealEstate.agent_number;
                   realestate.OwnerName = MigrealEstate.agent_name;
                   realestate.Price = Convert.ToDouble(MigrealEstate.price);
                   realestate.RealEstateCategoryID = type.RealEstateCategoryId;
                   realestate.RealEstateStatusID = Context.RealEstateStatuses.FirstOrDefault(S => S.RealEstateCategoryID == type.RealEstateCategoryId && S.Title == "غير محدد").ID;
                   realestate.RealEstateTypeID = type.ID;
                   realestate.SaleTypeId = MigrealEstate.SaleType;
                   realestate.Street = MigrealEstate.district;
                   realestate.SubscriberID = SubscriperId;// 347;
                   realestate.Title = MigrealEstate.title_ar;
                   realestate.UseContactInfo = false;

                   SaveRealEstateCriteria(MigrealEstate, realestate);
                   SaveRealEstatePhoto(MigrealEstate, realestate);
                   Context.RealEstates.AddObject(realestate);
                   MigrealEstate.IsMigrated = true;
                   Context.SaveChanges();
                   i++;
                   //foreach (PropertyFinderRealEstatesSchema row in MigContext.PropertyFinderRealEstatesSchema)
                   //{
                   //    // SaveRealEstate(row);
                   }
                   MigContext.SaveChanges();
                   
                   foreach (RealEstate realestate in Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Migrated).ToList())
                   {
                       SiteMapGenerator.AddRealEstateNde(realestate.ID);
                   }
               }
           }
           return true;
       }

       public bool UpDateDistrictCoordinates()
       {
           using (MigratedRealEstatesEntities Context = new MigratedRealEstatesEntities())
           {
               string Address;
               XmlNode resultNode;
               XmlNode root;
               XmlDocument doc;
               foreach (District district in Context.District.Where(D=>D.Lat==null))
               {
                   Address = "مصر, " + district.City_AR_Name+", "+district.Ar_Name;
                   string url = "http://maps.google.com/maps/api/geocode/xml?address=" + Address + "&sensor=false";
                   WebRequest request = WebRequest.Create(url);
                   using (WebResponse response = (HttpWebResponse)request.GetResponse())
                   {
                       using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                       {
                             doc = new XmlDocument();
                             doc.Load(reader);
                             root = doc.DocumentElement;
                             resultNode = root.SelectSingleNode("result/geometry/location");
                             if (resultNode != null)
                             {
                                 district.Lng = resultNode["lng"].InnerText;
                                 district.Lat = resultNode["lat"].InnerText;
                             }
                         
                       }
                   }

               }
               Context.SaveChanges();
           }
           return true;
       }

       public bool UpDateMigratedRealEstateLatAndLng()
       {
           District district;
           using (BrokerEntities Context = new BrokerEntities())
           { 
           using (MigratedRealEstatesEntities MigContext=new MigratedRealEstatesEntities())
           {
               foreach (RealEstate realestate in Context.RealEstates.Where(R => R.IsMigrated == true))
               {
                   district = MigContext.District.FirstOrDefault(D => D.Code == realestate.DistrictID);
                   if (district != null)
                   {
                       realestate.Latitude = district.Lat;
                       realestate.Longitude = district.Lng;
                   }
               }
               Context.SaveChanges();
           }
           }
           return true;
       }

       private static void SaveRealEstateCriteria(PropertyFinderRealEstatesSchema MigrealEstate, RealEstate realestate)
       {
           RealEstateCriteria Criteria = new RealEstateCriteria();
           if (MigrealEstate.RoomCriteriaID != null)
           {
               Criteria.RealEstateTypeCriteriaID = MigrealEstate.RoomCriteriaID;
               Criteria.Value = MigrealEstate.bedroom.ToString();
               realestate.RealEstateCriterias.Add(Criteria);
           }
           if (MigrealEstate.BathroomCriteriaID != null)
           {
               Criteria = new RealEstateCriteria();
               Criteria.RealEstateTypeCriteriaID = MigrealEstate.BathroomCriteriaID;
               Criteria.Value = MigrealEstate.bathroom.ToString();
               realestate.RealEstateCriterias.Add(Criteria);
           }
       }

       private void SaveRealEstatePhoto(PropertyFinderRealEstatesSchema MigrealEstate, RealEstate realestate)
       {
           RealEstatePhoto Photo;
           string ext;
           bool IsValid;
           if (MigrealEstate.photo_url_1 != null &&MigrealEstate.photo_url_1!="")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_1.Substring(MigrealEstate.photo_url_1.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo1" + ext;
               Photo.IsDefault = true;
               IsValid=UploadRealEstatePhoto("Photo1" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_1);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_10 != null && MigrealEstate.photo_url_10 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_10.Substring(MigrealEstate.photo_url_10.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo10" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo10" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_10);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_2 != null && MigrealEstate.photo_url_2 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_2.Substring(MigrealEstate.photo_url_2.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo2" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo2" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_2);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_3 != null && MigrealEstate.photo_url_3 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_3.Substring(MigrealEstate.photo_url_3.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo3" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo3" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_3);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_4 != null && MigrealEstate.photo_url_4 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_4.Substring(MigrealEstate.photo_url_4.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo4" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo4" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_4);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_5 != null && MigrealEstate.photo_url_5 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_5.Substring(MigrealEstate.photo_url_5.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo5" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo5" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_5);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_6 != null && MigrealEstate.photo_url_6 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_6.Substring(MigrealEstate.photo_url_6.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo6" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo6" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_6);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_7 != null && MigrealEstate.photo_url_7 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_7.Substring(MigrealEstate.photo_url_7.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo7" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo7" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_7);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_8 != null && MigrealEstate.photo_url_8 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_8.Substring(MigrealEstate.photo_url_8.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo8" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo8" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_8);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
           if (MigrealEstate.photo_url_9 != null && MigrealEstate.photo_url_9 != "")
           {
               Photo = new RealEstatePhoto();
               ext = MigrealEstate.photo_url_9.Substring(MigrealEstate.photo_url_9.LastIndexOf('.'));
               Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                 + DateTime.Today.Day + "/" + realestate.Code + "/Photo9" + ext;
               Photo.IsDefault = false;
               IsValid=UploadRealEstatePhoto("Photo9" + ext, realestate.Code.ToString(), MigrealEstate.photo_url_9);
               if (IsValid) { realestate.RealEstatePhotos.Add(Photo); }
           }
       }
       private bool UploadRealEstatePhoto(string PhotoName, string Code,string URL)
       {
           try
           {
               if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year))
               {
                   Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year);
               }
               if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
               {
                   Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
               }
               if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
               {
                   Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
               }
               if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code))
               {
                   Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code);
               }
               string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code + "\\" + PhotoName;
               WebClient webClient = new WebClient();
               // string remoteFileUrl = "http://www.zamalekrealestate.com/module/property/upload/image/1-19-Sun-13-May-2012-No1.jpg";
               string localFileName = HttpContext.Current.Server.MapPath("~/Resources/");
               webClient.DownloadFile(URL, path);
               //path += Regex.Replace(ruPhoto.UploadedFiles[i].GetNameWithoutExtension(), "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[i].GetExtension();
               ////  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
               ////ruPhoto.UploadedFiles[0].
               //System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
               //ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);

               return true;
           }
           catch (System.Net.WebException ex)
           {
               return false;
           }
              
       }

    }
}
