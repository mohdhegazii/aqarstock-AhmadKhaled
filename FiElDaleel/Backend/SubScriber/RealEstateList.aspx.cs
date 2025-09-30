using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BrokerDLL;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class RealEstateList : AqarPage, IRealEstateList
    {
        RealEstateListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
          
        }


        public void BindRealEstateList(List<BrokerDLL.RealEstate> RealEstatees)
        {
            rlvRealEstates.DataSource = RealEstatees;
            rlvRealEstates.DataBind();
        }
        protected void rlvRealEstates_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            if (e.Item.ItemType == RadListViewItemType.DataItem || e.Item.ItemType == RadListViewItemType.AlternatingItem)
            {
                RadListViewDataItem Item = (RadListViewDataItem)e.Item;
                RealEstate realestate = (RealEstate)Item.DataItem;
                Image img = (Image)Item.FindControl("imgLogo");
                Image imgSold = (Image)Item.FindControl("imgSold");
                Label lbl = (Label)Item.FindControl("lblTitle");
                img.ImageUrl = realestate.RealEstateType.Icon;
                lbl.Text = realestate.Title;
                lbl = (Label)e.Item.FindControl("lblCode");
                lbl.Text = realestate.Code.ToString();
                lbl = (Label)e.Item.FindControl("lblAddress");
                if (realestate.IsSold == false)
                {
                    imgSold.Visible = false;
                }
                if (realestate.CountryID > 0 && realestate.CountryID != null)
                {
                    lbl.Text = realestate.Street + ", " + realestate.District.Name + ", " + realestate.City.Name + ", " + realestate.Country.Name;
                }
                else
                {
                    lbl.Text = "غير متوفر";
                }
                lbl = (Label)e.Item.FindControl("lblDetails");
                lbl.Text = realestate.RealEstateType.Title + ", " + realestate.RealEstateStatu.Title + ", " + realestate.SaleType.Title;
            }
        }

        protected void rlvRealEstates_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
                rlvRealEstates.DataSource = Controller.OnNeedDataSource();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSearch();
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

        public BrokerDLL.General.RealEstateSearchCriteria FillSearchCriteriaObject()
        {
            RealEstateSearchCriteria Criteria = new RealEstateSearchCriteria();
            if (txtCode.Text != null && txtCode.Text != "")
            {
                Criteria.Code = Convert.ToInt32(txtCode.Text);
            }
            if (rcbAddresses.SelectedIndex>0)
            {
                Criteria.DistrictID = Convert.ToInt32(rcbAddresses.SelectedValue);
            }
            if (ddlType.SelectedIndex > 0)
            {
                Criteria.RealEstateTypeID = Convert.ToInt32(ddlType.SelectedValue);
            }
            return Criteria;
        }

        public void FillRealEstateTypeList(List<RealEstateType> Types)
        {
            ddlType.DataSource = Types;
            ddlType.DataTextField = "Title";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillDistrictList(List<District> Addresses)
        {
            rcbAddresses.DataSource = Addresses;
            rcbAddresses.DataTextField = "FullName";
            rcbAddresses.DataValueField = "ID";
            rcbAddresses.DataBind();
        }
    }
}