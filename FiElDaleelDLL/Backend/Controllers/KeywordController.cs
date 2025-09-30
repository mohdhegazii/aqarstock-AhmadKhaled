using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
    public class KeywordController : IController
    {
        IKeyword View;
        public KeywordController(IKeyword view)
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
            View.BindKeywordsList(Commons.Context.Keywords.OrderBy(K=>K.Title).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
        }

        public void OnSave()
        {
            try
            {
                Keyword keyword = View.FillKeywordObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.Context.Keywords.AddObject(keyword);
                }
                Commons.Context.SaveChanges();
                View.BindKeywordsList(Commons.Context.Keywords.OrderBy(K=>K.Title).ToList());
                View.Mode = PageMode.Add;
                View.Navigate();
                View.NotifyUser(Message.Save, MessageType.Success);
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {
            View.KeywordID = ID;
            View.FillKeywordControls(Commons.Context.Keywords.FirstOrDefault(K => K.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                Keyword keyword = Commons.Context.Keywords.FirstOrDefault(K => K.ID == ID);
                if (keyword != null)
                {
                    if (CanBeDeleted(keyword))
                    {
                        Commons.Context.Keywords.DeleteObject(keyword);
                        Commons.Context.SaveChanges();
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindKeywordsList(Commons.Context.Keywords.OrderBy(K=>K.Title).ToList());
                    }
                    else
                    {
                        View.NotifyUser(Message.HasChildrenError, MessageType.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        private bool CanBeDeleted(Keyword keyword)
        {
         
       
            if (keyword.RealEstateKeywords.Count > 0)
            {
                return false;
            }
            return true;
        }


        public Keyword OnGetById()
        {
            return Commons.Context.Keywords.FirstOrDefault(K => K.ID == View.KeywordID);
        }
        public List<Keyword> OnNeedDatasource()
        {
            return Commons.Context.Keywords.OrderBy(K=>K.Title).ToList();
        }
    }
}
