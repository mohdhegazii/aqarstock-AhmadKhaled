using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrokerDLL.Backend.Views;
using System.Web.Security;
using System.Web;

namespace BrokerDLL.Backend.Controllers
{
   public class CurrencyController:IController
    {
         ICurrency View;
         public CurrencyController(ICurrency view)
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
            View.BindCurrencyList(Commons.Context.Currencies.OrderBy(C => C.Name).ToList());
            View.Mode = PageMode.Add;
            View.Navigate();
            
        }

        public void OnSave()
        {
            try
            {
                Currency currency = View.FillCurrencyObject();
                if (View.Mode == PageMode.Add)
                {
                    Commons.SaveKeyword(currency.Name);
                    Commons.Context.Currencies.AddObject(currency);
                }
                Commons.Context.SaveChanges();
                View.BindCurrencyList(Commons.Context.Currencies.OrderBy(C => C.Name).ToList());
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
            View.CurrencyID = ID;
            View.FillCurrencyControls(Commons.Context.Currencies.FirstOrDefault(C => C.ID == ID));
            View.Mode = PageMode.Edit;
            View.Navigate();
        }

        public void OnDelete(int ID)
        {
            try
            {
                Currency currency = Commons.Context.Currencies.FirstOrDefault(C => C.ID == ID);
                if (currency != null)
                {
                        Commons.Context.Currencies.DeleteObject(currency);
                        Commons.Context.SaveChanges();
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindCurrencyList(Commons.Context.Currencies.OrderBy(C => C.Name).ToList());
                   
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public Currency OnGet()
        {
            return Commons.Context.Currencies.FirstOrDefault(C => C.ID == View.CurrencyID);
        }

        public List<Currency> OnNeedDataSource()
        {
            return Commons.Context.Currencies.OrderBy(C => C.Name).ToList();
        }
    }
}
