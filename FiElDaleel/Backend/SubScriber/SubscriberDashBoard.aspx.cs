using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using Telerik.Web.UI;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class SubscriberDashBoard : AqarPage, ISubscriberDashboard
    {
        SubscriberDashBoardController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SubscriberDashBoardController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }


        public void BindRealEstateList(List<RealEstate> RealEstates)
        {
            rlvRealEstates.DataSource = RealEstates;
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
                if (realestate.IsSold==false)
                {
                    imgSold.Visible=false;
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

        //public void FillControls(int MsgNo, int RequestsNo)
        //{
        //    Label lbl = (Label)rtsAddBusiness.Tabs[1].FindControl("lblUnReadMsgNo");
        //    if (MsgNo > 0)
        //    {
        //        lbl.Text = MsgNo.ToString();
        //    }
        //    lbl = (Label)rtsAddBusiness.Tabs[2].FindControl("lblRequestNo");
        //    if (RequestsNo > 0)
        //    {
        //        lbl.Text = RequestsNo.ToString();
        //    }
        //}



    }
}