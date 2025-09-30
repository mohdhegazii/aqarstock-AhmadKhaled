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
    public partial class Countries : System.Web.UI.Page,ICountry
    {
        CountryController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CountryController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCountries.PageIndex = e.NewPageIndex;
            gvCountries.DataSource = Controller.OnNeedDataSource();
            gvCountries.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCountries.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCountries.DataKeys[item.RowIndex].Value));
        }

        public int CountryID
        {
            get
            {
                if (ViewState["CountryID"] != null)
                {
                    return (int)ViewState["CountryID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CountryID"] = value;
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

        public void BindCountriesList(List<BrokerDLL.Country> Countries)
        {
            gvCountries.DataSource = Countries;
            gvCountries.DataBind();
        }

        public BrokerDLL.Country FillCountryObject()
        {
            Country country;
            if (Mode == PageMode.Add)
            {
                country = new Country();
            }
            else
            {
                country = Controller.OnGet();
            }
            country.Name = txtName.Text;
            return country;
        }

        public void FillCountryControls(BrokerDLL.Country country)
        {
            txtName.Text = country.Name;
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