using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BrokerMVC.Models;
using BrokerMVC.Models.ViewModel;

namespace BrokerMVC.Code.GeneralClasses
{
    public class GenerateCatalogContent
    {
        RealEstateBrokerEntities db;
        public int WordNo { get; set; }
        public int OccuranceNo { get; set; }
        public int ParagraphNo { get; set; }
        public string Headers { get; set; }
        public string Link { get; set; }
        public GenerateCatalogContent()
        {
            db = new RealEstateBrokerEntities();
        }
        //public void Generate(string CatalogNames)
        //{
        //    List<string> Catalogs = CatalogNames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    Catalogs.ForEach(c => c.Trim());
        //    Catalogs = Catalogs.Distinct().ToList();
        //    Catalog Catalog;
        //    foreach (string cat in Catalogs)
        //    {
        //      //  Catalog = GenerateCatalog(generator, cat);
        //    }
        //}
        public string GenerateContent(string keyword)
        {
            string Content="";
            List<ContentTag> Tags = GetContentTags();
            insertKeyword(keyword, Tags);
            GenerateParagraphs(Tags);
            Tags.ToList().ForEach(t => Content += t.Name + " ");
            return Content;
        }
        private void GenerateParagraphs(List<ContentTag> finalTags)
        {
            double no = WordNo / ParagraphNo;
            int PwNo = Convert.ToInt32(Math.Floor(no));
            ContentTag ta;
            //bool isfirst = false;
            List<string> HeadersList = new List<string>();
            //bool IsMenualHeader = false;
            if (Headers != "")
            {
                HeadersList = Headers.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //ta = new ContentTag();
                //ta.Name = "<h2><a href='" + Link + "'>" + HeadersList[0] + "</a></h2>";
                //finalTags.Insert(0, ta);
                if (ParagraphNo == HeadersList.Count())
                {
                    for (int i = 0; i < ParagraphNo; i++)
                    {
                     
                        ta = new ContentTag();
                        ta.Name = "<h2><a href='" + Link + "'>" + HeadersList[i] + "</a></h2>";
                        finalTags.Insert(PwNo * i, ta);
                        ta = new ContentTag();
                        ta.Name = "\r\n\r\n";
                        finalTags.Insert(PwNo * i, ta);
                        finalTags.Insert(PwNo * i + 2, ta);
                    }
                }
                else
                {
                    if(ParagraphNo>HeadersList.Count())
                    {
                        for (int i = 0; i < HeadersList.Count(); i++)
                        {
                            
                            ta = new ContentTag();
                            ta.Name = "<h2><a href='" + Link + "'>" + HeadersList[i] + "</a></h2>";
                            finalTags.Insert(PwNo * i, ta);
                            ta = new ContentTag();
                            ta.Name = "\r\n\r\n";
                            finalTags.Insert(PwNo * i, ta);
                            finalTags.Insert(PwNo * i + 2, ta);
                        }
                        for (int i = ParagraphNo- HeadersList.Count(); i < ParagraphNo; i++)
                        {
                            ta = new ContentTag();
                            ta.Name = "<h2><a href='" + Link + "'>" + finalTags[PwNo * i].Name + "</a></h2>";
                            finalTags.Insert(PwNo * i, ta);
                            ta = new ContentTag();
                            ta.Name = "\r\n\r\n";
                            finalTags.Insert(PwNo * i, ta);
                            finalTags.Insert(PwNo * i + 2, ta);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < ParagraphNo; i++)
                {
                    ta = new ContentTag();
                    ta.Name = "<h2><a href='" + Link + "'>" + finalTags[PwNo * i].Name + "</a></h2>";
                    finalTags.Insert(PwNo * i, ta);
                    ta = new ContentTag();
                    ta.Name = "\r\n\r\n";
                    finalTags.Insert(PwNo * i, ta);
                    finalTags.Insert(PwNo * i + 2, ta);
                }
            }


        }
        private void insertKeyword(string keyword, List<ContentTag> finalTags)
        {
            ContentTag ta;
            Random ra = new Random();
            for (int i = 1; i <= OccuranceNo; i++)
            {
                ta = new ContentTag();
                ta.Name = keyword;
                finalTags.Insert(ra.Next(finalTags.Count()), ta);
            }
        }
        public List<ContentTag> GetContentTags()
        {
            int Count = db.ContentTags.Where(c => c.CategoryID == 9).Count();
            List<ContentTag> words;
            if (WordNo <= 0)
            {
                WordNo = 500;
            }
            if (WordNo > Count)
            {
                WordNo = Count;
                words = db.ContentTags.Where(c => c.CategoryID == 9).ToList();
            }
            else
            {
                Random r = new Random();
                words = db.ContentTags.Where(c=>c.CategoryID==9).OrderBy(t => t.ID).Skip(r.Next(Count - WordNo)).Take(WordNo).ToList();
            }


            return words;
        }
        private List<ContentTag> RandomizeList(List<ContentTag> words)
        {
            List<ContentTag> random = new List<ContentTag>();
            Random r = new Random();
            int index;
            int Lenght = words.Count();
            for (int i = 0; i < Lenght; i++)
            {
                index = r.Next(0, words.Count);
                random.Add(words[index]);
                words.RemoveAt(index);
            }
            return random;
        }
    }
}