using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.General;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class NotifyReqiestReport : System.Web.UI.Page, INotifyReport
    {
        NotifyReportController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new NotifyReportController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSearch();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedIndex != 0)
            {
                Controller.OnSelectCity(Convert.ToInt32(ddlCity.SelectedValue));
            }
            else
            {
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }

        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 0)
            {
                Controller.OnSelectCountry(Convert.ToInt32(ddlCountry.SelectedValue));
            }
            else
            {
                ddlCity.Items.Clear();
                ddlCity.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        protected void rgRequests_NeedDataSource(object sender, GridViewPageEventArgs e)
        {
            rgRequests.PageIndex = e.NewPageIndex;
            rgRequests.DataSource= Controller.OnNeedDataSource();
            rgRequests.DataBind();
        }

        public void FillRealEstateTypeList(List<BrokerDLL.RealEstateType> Types)
        {
            ddlType.DataSource = Types;
            ddlType.DataTextField = "Title";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillDistrictList(List<BrokerDLL.District> districts)
        {
            ddlDistrict.DataSource = districts;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "ID";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillCountryList(List<BrokerDLL.Country> Countries)
        {
            ddlCountry.DataSource = Countries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--اخنار--", "0"));
            ddlCity.Items.Insert(0, new ListItem("--اخنار--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillCityList(List<BrokerDLL.City> Cities)
        {
            ddlCity.DataSource = Cities;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "ID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--اخنار--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillSaleTypeList(List<BrokerDLL.SaleType> SaleTypes)
        {
            rbsSalesTypes.DataSource = SaleTypes;
            rbsSalesTypes.DataTextField = "Title";
            rbsSalesTypes.DataValueField = "ID";
            rbsSalesTypes.DataBind();
        }

        public void BindList(List<BrokerDLL.NotifyService> NotifyRequests)
        {
            rgRequests.DataSource = NotifyRequests;
            rgRequests.DataBind();
        }

        public BrokerDLL.General.RealEstateSearchCriteria FillSearchCriteriaObject()
        {
            RealEstateSearchCriteria Criteria = new RealEstateSearchCriteria();
            if (txtArea.Text != null && txtArea.Text != "")
            {
                Criteria.Area = Convert.ToInt32(txtArea.Text);
            }
            if (txtPrice.Text != null && txtPrice.Text != "")
            {
                Criteria.Price = Convert.ToInt32(txtPrice.Text);
            }
        
            if (ddlCountry.SelectedIndex > 0)
            {
                Criteria.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            if (ddlCity.SelectedIndex > 0)
            {
                Criteria.CityID = Convert.ToInt32(ddlCity.SelectedValue);
            }
            if (ddlDistrict.SelectedIndex > 0)
            {
                Criteria.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            }
            if (rbsSalesTypes.SelectedIndex > 0)
            {
                Criteria.SaleTypeID = Convert.ToInt32(rbsSalesTypes.SelectedValue);
            }
            if (ddlType.SelectedIndex > 0)
            {
                Criteria.RealEstateTypeID = Convert.ToInt32(ddlType.SelectedValue);
            }
            if (rdpFrom.SelectedDate != null)
            {
                Criteria.FromDate = rdpFrom.SelectedDate.Value;
            }
            if (rdpTo.SelectedDate != null)
            {
                Criteria.ToDate = rdpTo.SelectedDate.Value;
            }
            return Criteria;
        }

        public void FillRequestControls(BrokerDLL.NotifyService Request)
        {
            throw new NotImplementedException();
        }

        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg.GetValue();
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger");
        }
    }
}