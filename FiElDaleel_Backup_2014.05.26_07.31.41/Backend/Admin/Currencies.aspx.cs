using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class Currencies : System.Web.UI.Page, ICurrency
    {
        CurrencyController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CurrencyController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvCurrencies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCurrencies.PageIndex = e.NewPageIndex;
            gvCurrencies.DataSource = Controller.OnNeedDataSource();
            gvCurrencies.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCurrencies.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCurrencies.DataKeys[item.RowIndex].Value));
        }

        public int CurrencyID
        {
            get
            {
                if (ViewState["CurrencyID"] != null)
                {
                    return (int)ViewState["CurrencyID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CurrencyID"] = value;
            }
        }

        public PageMode Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                {
                    return (PageMode)ViewState["Mode"];
                }
                else
                {
                    return PageMode.Add;
                }
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        public void BindCurrencyList(List<BrokerDLL.Currency> Currencies)
        {
            gvCurrencies.DataSource = Currencies;
            gvCurrencies.DataBind();
        }

        public BrokerDLL.Currency FillCurrencyObject()
        {
            Currency currency;
            if (Mode == PageMode.Add)
            {
                currency = new Currency();
            }
            else
            {
                currency = Controller.OnGet();
            }
            currency.Name = txtName.Text;
            return currency;
        }

        public void FillCurrencyControls(BrokerDLL.Currency currency)
        {
            txtName.Text = currency.Name;
        }


        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg.GetValue();
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }

        public void Navigate()
        {
            if (Mode == PageMode.Add)
            {
                txtName.Text = "";
            }
        }
    }
}