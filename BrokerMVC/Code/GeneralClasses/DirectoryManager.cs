using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BrokerMVC
{
    public static class DirectoryManager
    {
        public static string GetDirectory(string path,string foldername)
        {
            CheckDirectory(path);
            path = path + "/" + DateTime.Now.Year;
            CheckDirectory(path);
            path = path + "/" + DateTime.Now.Month;
            CheckDirectory(path);
            path = path + "/" + DateTime.Now.Day;
            CheckDirectory(path);
            path = path + "/" + foldername;
            CheckDirectory(path);
            return path;
        }
        public static void CheckDirectory(string path)
        {
           // path = "~/" + path;
            path = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void RemoveFile(string path)
        {
            // path = "~/" + path;
            path = HttpContext.Current.Server.MapPath(path);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}