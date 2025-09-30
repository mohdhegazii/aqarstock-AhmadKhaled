using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;

namespace BrokerDLL.General
{
    public static class HtmlPageGenerator
    {
        public static string BuildPage(string PageName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html xmlns='http://www.w3.org/1999/xhtml' ng-app='brokerApp'>");
            BuildHeader(sb, PageName);
            BuildBody(sb, PageName);
            sb.AppendLine("</html>");
            FileStream file = new FileStream(HttpContext.Current.Server.MapPath("~/Static Pages/" + PageName.Replace(" ", "_") + ".html"), FileMode.Create);
            StreamWriter w = new StreamWriter(file, Encoding.UTF8);
            w.Write(sb.ToString());
            w.Close();
            // sb.ToString();
            return "true";
        }

        private static void BuildBody(StringBuilder sb, string PageName)
        {
            sb.AppendLine("<body class='rtl'>");
            sb.AppendLine("<div class='wrapper'>");
            sb.AppendLine("<header><div id='divHeader' ng-include src=\"'parts/Header.htm'\" onload='LoadHeader()'></div></header>");
            sb.AppendLine("<div class='content'>");
            sb.AppendLine("<div class='container'>");
            //sb.AppendLine("<div id='divSideBar' ng-include src=\"'parts/SideBar.htm'\"></div>");
            sb.AppendLine("<div class='searchResult' style='width:100%;float:right;'>");
            sb.AppendLine("<div class='resultTitle'><h4>" + PageName + "</h4></div>");
            sb.AppendLine("<div class='resultItems'>");
            BuildItems(sb);
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("</body>");
        }

        private static void BuildItems(StringBuilder sb)
       {
           using (BrokerEntities Context = new BrokerEntities())
           {
               int Count=Context.RealEstates.Where(R=>R.ActiveStatusId==(int)Activestatus.Active && R.IsSold==false).Count();
               Random r = new Random();
               List<RealEstate> realestates = Context.RealEstates.Where(R => R.ActiveStatusId == (int)Activestatus.Active && R.IsSold == false).OrderBy(R=>R.ID).Skip(r.Next(Count - 10)).Take(10).ToList();
               string Logo="";
               string Price = "";
               string currency = "";
               foreach (RealEstate realestate in realestates)
               {
                if (realestate.RealEstatePhotos.Count > 0)
                {
                    BrokerDLL.RealEstatePhoto photo = realestate.RealEstatePhotos.FirstOrDefault(P => P.IsDefault == true);
                    if (photo != null)
                    {
                        Logo = photo.PhotoName;
                    }
                    else
                    {
                        Logo = realestate.RealEstatePhotos.ToList()[0].PhotoName;
                    }
                }
                if (realestate.Price != null)
                {
                    Price = realestate.Price.ToString();
                }
                else
                {
                    Price = "غير متوفر";
                }
                currency = realestate.Currency != null ? realestate.Currency.Name : "";
                   sb.AppendLine("<div class='item'>");
                   sb.AppendLine("<div class='itemImg'><img src='http://www.aqarstock.com/" + Logo.Replace("~/", "") + "' /></div>");
                   sb.AppendLine("<div class='itemDitails'>");
                   sb.AppendLine("<div class='itemDesc'><span>"+realestate.RealEstateType.Title +"- "+realestate.District.Name+","+ realestate.City.Name+"</span></div>");
                   sb.AppendLine(" <div class='itemPrice'><span >السعر: <b>"+Price+"</b>"+ currency+"</span></div>");
                   sb.AppendLine("<div class='itemControls'><span class='moreDet'><a ng-href='/Details/"+realestate.ID+"/"+Regex.Replace(realestate.Title, "[^0-9a-zA-Zء-ي]+", "-")+"'>عرض التفاصيل</a></span></div>");
                   sb.AppendLine("");
                   sb.AppendLine("");
                   sb.AppendLine("</div>");
               }
           }
       }

        private static void BuildHeader(StringBuilder sb, string PageName)
        {
            sb.AppendLine("<head>");
            sb.AppendLine("<title> عقار ستوك - " + PageName + "</title>");
            sb.AppendLine("<meta name='viewport' content='width=device-width, initial-scale=1' />");
            sb.AppendLine(" <base href=' / '>");
            sb.AppendLine("<link rel='shortcut icon' href='favicon.ico' />");
            sb.AppendLine("<link rel='stylesheet' type='text/css' media='screen' href='styles/bootstrap.min.css' />");
            sb.AppendLine("<link rel='stylesheet' type='text/css' media='screen' href='styles/bootstrap-theme.min.css' />");
            sb.AppendLine("<link href='styles/CssStyle.css' rel='stylesheet' type='text/css' />");
            sb.AppendLine("<script src='scripts/jquery-1.11.0.min.js'></script>");
            sb.AppendLine("<script src='scripts/angular.min.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/angular-route.min.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/angular-ui-router.min.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/angular-animate.min.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/angular-resource.min.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/FrontEndController.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/services.js' type='text/javascript'></script>");
            sb.AppendLine("<script src='scripts/FrontEndDirective.js' type='text/javascript'></script>");

            sb.AppendLine("</head>");
        }
    }
}
