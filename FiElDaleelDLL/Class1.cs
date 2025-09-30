using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;

namespace BrokerDLL
{
   public class Class1
    {
        public void test()
        {
            WebClient webClient = new WebClient();
            string remoteFileUrl = "http://www.zamalekrealestate.com/module/property/upload/image/1-19-Sun-13-May-2012-No1.jpg";
            string localFileName=HttpContext.Current.Server.MapPath("~/Resources/");
            webClient.DownloadFile(remoteFileUrl, localFileName+"\\1-19-Sun-13-May-2012-No1.jpg");
        }
    }
}
