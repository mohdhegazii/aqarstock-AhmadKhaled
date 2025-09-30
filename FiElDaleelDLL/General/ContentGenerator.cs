using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokerDLL
{
   public class ContentGenerator
    {
        int _CategoryID;
        int _TagNo;
        int _ParagraphNo;
        int _OccuranceNo;
        string _GeneralLink;
        string _Keyword;
        string _KeywordLink;
        string _Headers;
    
        public int CategoryID
        {
            get
            {
                return _CategoryID;
            }

            set
            {
                _CategoryID = value;
            }
        }

        public int TagNo
        {
            get
            {
                return _TagNo;
            }

            set
            {
                _TagNo = value;
            }
        }

        public int ParagraphNo
        {
            get
            {
                return _ParagraphNo;
            }

            set
            {
                _ParagraphNo = value;
            }
        }

        public int OccuranceNo
        {
            get
            {
                return _OccuranceNo;
            }

            set
            {
                _OccuranceNo = value;
            }
        }

        public string GeneralLink
        {
            get
            {
                return _GeneralLink;
            }

            set
            {
                _GeneralLink = value;
            }
        }

        public string KeywordText
        {
            get
            {
                return _Keyword;
            }

            set
            {
                _Keyword = value;
            }
        }

        public string KeywordLink
        {
            get
            {
                return _KeywordLink;
            }

            set
            {
                _KeywordLink = value;
            }
        }

        public string Headers
        {
            get
            {
                return _Headers;
            }

            set
            {
                _Headers = value;
            }
        }

        public string GenerateContent(string keyword,string headers)
        {
            string Content = "";
            KeywordText = keyword;
            Headers = headers;
           Content= GenerateContent();
            return Content;
        }
        public string GenerateContent()
        {
            string Content="";
            List<ContentTag> tags;
            string keyword = "<a href='" + KeywordLink + "'><strong>" + KeywordText + "</strong></a>";
            if (OccuranceNo <= 0)
            {
                OccuranceNo = 2;
            }
            if(ParagraphNo<=0)
            {
                ParagraphNo = 1;
            }
            using (BrokerEntities Context = new BrokerEntities())
            {
                GetTags(Context,out tags);
                List<ContentTag> FinalTags = new List<ContentTag>();
                ContentTag ta = new ContentTag();
                CreateTags(tags, FinalTags);
                insertKeyword(keyword, FinalTags);
                GenerateParagraphs(FinalTags);
                FinalTags.ToList().ForEach(t => Content += t.Name + " ");
            }
                return Content;
        }

        private void GenerateParagraphs(List<ContentTag> finalTags)
        {
            double no = TagNo / ParagraphNo;
            int PwNo = Convert.ToInt32(Math.Floor(no));
            ContentTag ta;
            bool isfirst = false;
            List<string> HeadersList = new List<string>();
            bool IsMenualHeader = false;
            if (Headers != "")
            {
                HeadersList = Headers.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                IsMenualHeader = true;
            }
            if (IsMenualHeader == false)
            {
                finalTags[0].Name = "<h2><a href='" + GeneralLink + "'>" + finalTags[0].Name + "</a></h2>";
            }
            else
            {
                ta = new ContentTag();
                ta.Name = "<h2><a href='" + GeneralLink + "'>" + HeadersList[0] + "</a></h2>";
                finalTags.Insert(0, ta);
            }
            int y = 1;
            for (int i = 1; i <= ParagraphNo - 1; i++)
            {
                ta = new ContentTag();
                ta.Name = "\r\n\r\n";
                finalTags.Insert(PwNo * i, ta);
                if (y >= HeadersList.Count)
                {
                    IsMenualHeader = false;
                }
                if (IsMenualHeader == false)
                {
                    isfirst = AutoHeader( finalTags, PwNo, isfirst, i);
                }
                else
                {
                    ManualHeader( finalTags, ref ta, PwNo, ref isfirst, HeadersList, y, i);
                    y++;

                }
            }

        }

        private void ManualHeader(List<ContentTag> finalTags, ref ContentTag ta, int pwNo, ref bool isfirst, List<string> headerLists, int y, int i)
        {
            if (isfirst == false)
            {
                ta = new ContentTag();
                ta.Name = "<h2><a href='" + GeneralLink + "'>" + headerLists[y] + "</a></h2>";
                finalTags.Insert((pwNo * i) + 1, ta);
                isfirst = true;
            }
            else
            {
                if (i == ParagraphNo - 1)
                {
                    finalTags[(pwNo * i) + 1].Name = "<h4><a href='" + GeneralLink + "'>" + headerLists[y] + "</a></h4>";
                    finalTags.Insert((pwNo * i) + 1, ta);
                }
                else
                {
                    finalTags[(pwNo * i) + 1].Name = "<h3><a href='" + GeneralLink + "'>" + headerLists[y] + "</a></h3>";
                    finalTags.Insert((pwNo * i) + 1, ta);
                }
            }
        }

        private bool AutoHeader(List<ContentTag> finalTags, int pwNo, bool isfirst, int i)
        {
            if (isfirst == false)
            {
                finalTags[(pwNo * i) + 1].Name = "<h2><a href='" + GeneralLink + "'>" + finalTags[(pwNo * i) + 1].Name + "</a></h2>";
                isfirst = true;
            }
            else
            {
                if (i == ParagraphNo - 1)
                {
                    finalTags[(pwNo * i) + 1].Name = "<h4><a href='" + GeneralLink + "'>" + finalTags[(pwNo * i) + 1].Name + "</a></h4>";
                }
                else
                {
                    finalTags[(pwNo * i) + 1].Name = "<h3><a href='" + GeneralLink + "'>" + finalTags[(pwNo * i) + 1].Name + "</a></h3>";
                }
            }

            return isfirst;

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

        private void CreateTags(List<ContentTag> tags, List<ContentTag> finalTags)
        {
            Random r = new Random();
            int index;
            for (int i = 0; i < TagNo; i++)
            {
                index = r.Next(0, tags.Count);
                finalTags.Add(tags[index]);
                tags.RemoveAt(index);
            }
        }

        private void GetTags(BrokerEntities Context, out List<ContentTag> tags)
        {
            int Count;
            if (TagNo <= 0)
            {
                TagNo = 500;
            }
            Count = Context.ContentTags.Where(t => t.CategoryID == CategoryID).Count();
            //if(CategoryID<=0)
            //{
            //  //  tags = Context.ContentTags.ToList();
            //    Count = Context.ContentTags.Count();
            //}
            //else
            //{
            //   tags = Context.ContentTags.Where(t => t.CategoryID == CategoryID).ToList();
            //    Count = Context.ContentTags.Where(t => t.CategoryID == CategoryID).Count();
            //}
            if (TagNo > Count)
            {
                TagNo = Count;
                tags = Context.ContentTags.Where(t => t.CategoryID == CategoryID).ToList();
            }
            else
            {
                Random r = new Random();
                tags = Context.ContentTags.OrderBy(t => t.ID).Skip(r.Next(Count - TagNo)).Take(4000).ToList();
            }

        }
    }
}
