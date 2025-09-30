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
    public partial class Districts : System.Web.UI.Page,IDistrict
    {
        DistrictController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new DistrictController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void gvDistricts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDistricts.PageIndex = e.NewPageIndex;
            gvDistricts.DataSource = Controller.OnNeedDatasource();
            gvDistricts.DataBind();
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountries.SelectedIndex != 0)
            {
                Controller.OnSelectCountry(Convert.ToInt32(ddlCountries.SelectedValue));
            }
            else
            {
                ddlCities.Items.Clear();
                ddlCities.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }
        }


        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvDistricts.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvDistricts.DataKeys[item.RowIndex].Value));
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

        public int DistrictId
        {
            get
            {
                if (ViewState["DistrictId"] != null)
                {
                    return (int)ViewState["DistrictId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["DistrictId"] = value;
            }
        }

        public void BindDistrictList(List<BrokerDLL.District> Districts)
        {
            gvDistricts.DataSource = Districts;
            gvDistricts.DataBind();
        }

        public BrokerDLL.District FillDistrictObject()
        {
            District district;
            if (Mode == PageMode.Add)
            {
                district = new District();
            }
            else
            {
                district = Controller.OnGet();
            }
            district.CityID = Convert.ToInt32(ddlCities.SelectedValue);
            district.Name = txtName.Text;
            return district;
        }

        public void FillDistrictControls(BrokerDLL.District district)
        {
            Controller.OnSelectCountry(district.City.CountryID.Value);
            txtName.Text = district.Name;
            ddlCountries.SelectedValue = district.City.CountryID.ToString();
            ddlCities.SelectedValue = district.CityID.ToString();
           
        }

        public void FillCountryList(List<BrokerDLL.Country> Countries)
        {
            ddlCountries.DataSource = Countries;
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataValueField = "ID";
            ddlCountries.DataBind();
            ddlCountries.Items.Insert(0, new ListItem("--اخنار--", "0"));
            ddlCities.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillCityList(List<BrokerDLL.City> Cities)
        {
            ddlCities.DataSource = Cities;
            ddlCities.DataTextField = "Name";
            ddlCities.DataValueField = "ID";
            ddlCities.DataBind();
            ddlCities.Items.Insert(0, new ListItem("--اخنار--", "0"));
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
                ddlCities.Items.Clear();
                ddlCities.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }
        }
    }
}