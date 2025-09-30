using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;
using BrokerDLL.General;

namespace BrokerDLL.Backend.Controllers
{
   public class SearchKeywordController:IController
    {
       ISearchKeyword View;
       public SearchKeywordController(ISearchKeyword view)
       {
           View = view;
       }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillParentKeywordsList(Context.SearchKeywords.Where(K => K.ParentID == null).OrderBy(K => K.Keywords).ToList());
                View.BindList(Context.SearchKeywords.OrderBy(C => C.Keywords).ToList());
                View.Mode = PageMode.Add;
                View.Navigate();
            }
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    SearchKeyword keyword;
                    if (View.Mode == PageMode.Add)
                    {
                        keyword = View.FillObject(new SearchKeyword() );
                        keyword.Code = "Gen-" + DateTime.Now.Ticks;
                        SiteMapGenerator.AddGeneralNode(keyword.URL, keyword.Code, keyword.Keywords);
                        Context.SearchKeywords.AddObject(keyword);
                    }
                    else
                    {
                        keyword=View.FillObject(Context.SearchKeywords.FirstOrDefault(C => C.ID == View.KeywordId));
                        if (keyword.ChildKeywords.Count> 0 && keyword.ParentID!=null)
                        {
                            View.NotifyUser(Message.KeywordHasChildren,MessageType.Error);
                            return;
                        }
                        SiteMapGenerator.EditGeneralNode(keyword.URL, keyword.Code, keyword.Keywords);
                    }
                    Context.SaveChanges();
                    View.BindList(Context.SearchKeywords.OrderBy(C => C.Keywords).ToList());
                    View.Mode = PageMode.Add;
                    View.Navigate();
                    View.NotifyUser(Message.Save, MessageType.Success);
                }

            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.KeywordId = ID;
                View.FillControls(Context.SearchKeywords.FirstOrDefault(C => C.ID == ID));
                View.Mode = PageMode.Edit;
                View.Navigate();
            }
        }
        public void OnDelete(int ID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    SearchKeyword keyword = Context.SearchKeywords.FirstOrDefault(C => C.ID == ID);
                    if (keyword != null)
                    {
                        SiteMapGenerator.DeleteGeneralNode(keyword.Code);
                        Context.SearchKeywords.DeleteObject(keyword);
                        Context.SaveChanges();
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindList(Context.SearchKeywords.OrderBy(C => C.Keywords).ToList());

                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public SearchKeyword OnGet()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.SearchKeywords.FirstOrDefault(C => C.ID == View.KeywordId);
            }
        }

        public List<SearchKeyword> OnNeedDataSource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.SearchKeywords.OrderBy(C => C.Keywords).ToList();
            }
        }
    }
}
