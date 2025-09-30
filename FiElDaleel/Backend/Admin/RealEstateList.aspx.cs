using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using Telerik.Web.UI;
using BrokerDLL;
using BrokerDLL.General;

namespace BrokerWeb.Backend.Admin
{
    public partial class RealEstateList : System.Web.UI.Page, IAdminRealEstateList
    {
        AdminRealEstateListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminRealEstateListController(this);
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
            divRealestateList.Visible = true;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex != 0)
            {
                Controller.OnSelectCategory(Convert.ToInt32(ddlCategory.SelectedValue));
            }
            else
            {
                ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
                ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
        }

        public BrokerDLL.General.RealEstateSearchCriteria FillSearchCriteriaObject()
        {
            RealEstateSearchCriteria Criteria = new RealEstateSearchCriteria();
            if (txtCode.Text != null && txtCode.Text != "")
            {
                Criteria.Code = Convert.ToInt32(txtCode.Text);
            }
            if (rcbAddresses.SelectedIndex > 0)
            {
                Criteria.DistrictID = Convert.ToInt32(rcbAddresses.SelectedValue);
            }
            if (ddlCategory.SelectedIndex > 0)
            {
                Criteria.RealEstateCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            }
            if (ddlStatus.SelectedIndex > 0)
            {
                Criteria.RealEstateStatusID = Convert.ToInt32(ddlStatus.SelectedValue);
            }
            if (rbsSalesTypes.SelectedIndex > 0)
            {
                Criteria.SaleTypeID = Convert.ToInt32(rbsSalesTypes.SelectedValue);
            }
            if (ddlType.SelectedIndex > 0)
            {
                Criteria.RealEstateTypeID = Convert.ToInt32(ddlType.SelectedValue);
            }
            if (rcbSubscribers.SelectedIndex > 0)
            {
                Criteria.SubscriberID = Convert.ToInt32(rcbSubscribers.SelectedValue);
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


        public void FillRealEstateCategoryList(List<RealEstateCategory> Categories)
        {
            ddlCategory.DataSource = Categories;
            ddlCategory.DataTextField = "Title";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillRealEstateStatusList(List<RealEstateStatus> Status)
        {
            ddlStatus.DataSource = Status;
            ddlStatus.DataTextField = "Title";
            ddlStatus.DataValueField = "ID";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillSaleTypeList(List<SaleType> SaleTypes)
        {
            rbsSalesTypes.DataSource = SaleTypes;
            rbsSalesTypes.DataTextField = "Title";
            rbsSalesTypes.DataValueField = "ID";
            rbsSalesTypes.DataBind();
        }


        public void FillSubscriberList(List<Subscriber> Subscribers)
        {
            rcbSubscribers.DataSource = Subscribers;
            rcbSubscribers.DataTextField = "FullAndUserName";
            rcbSubscribers.DataValueField = "ID";
            rcbSubscribers.DataBind();
        }
    }

}