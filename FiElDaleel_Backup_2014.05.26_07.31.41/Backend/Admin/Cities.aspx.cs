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
    public partial class Cities : System.Web.UI.Page,ICity
    {
        CityController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CityController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvCities_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCities.PageIndex = e.NewPageIndex;
            gvCities.DataSource = Controller.OnNeedDatasource();
            gvCities.DataBind();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCities.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCities.DataKeys[item.RowIndex].Value));
        }

        public int CityId
        {
            get
            {
                if (ViewState["CityId"] != null)
                {
                    return (int)ViewState["CityId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CityId"] = value;
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

        public void BindCitiesList(List<BrokerDLL.City> Cities)
        {
            gvCities.DataSource = Cities;
            gvCities.DataBind();
        }

        public BrokerDLL.City FillCityObject()
        {
            City city;
            if (Mode == PageMode.Add)
            {
                city = new City();
            }
            else
            {
                city = Controller.OnGet();
            }
            city.Name = txtName.Text;
            city.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
            return city;
        }

        public void FillCityControls(BrokerDLL.City city)
        {
            txtName.Text = city.Name;
            ddlCountries.SelectedValue = city.CountryID.ToString();
        }

        public void FillCountryList(List<BrokerDLL.Country> Countries)
        {
            ddlCountries.DataSource = Countries;
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataValueField = "ID";
            ddlCountries.DataBind();
            ddlCountries.Items.Insert(0, new ListItem("--اخنار--", "0"));
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
                ddlCountries.SelectedIndex = 0;
            }
        }
    }
}