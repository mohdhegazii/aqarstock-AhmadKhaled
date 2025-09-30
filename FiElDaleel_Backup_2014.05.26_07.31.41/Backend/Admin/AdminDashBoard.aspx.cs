using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using System.Web.Routing;

namespace BrokerWeb.Backend.Admin
{
    public partial class AdminDashBoard : System.Web.UI.Page, IAdminDashboard
    {
        AdminDashBoardController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminDashBoardController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void gvNewObjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNewObjects.PageIndex = e.NewPageIndex;
           // gvNewObjects.DataSource = Controller.OnNeedDataSource(Convert.ToInt32(rtsNewObjects.SelectedTab.Value));
            gvNewObjects.DataBind();

        }

        protected void gvNewObjects_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SubscriberLog Logger = (SubscriberLog)e.Row.DataItem;
                ImageButton imgbtn=(ImageButton) e.Row.FindControl("ibtnReview");
                Label lbl = (Label)e.Row.FindControl("lblModule");
                lbl.Text = ((Modules)Enum.Parse(typeof(Modules), Logger.ObjectTypeID.ToString())).GetValue();
                lbl = (Label)e.Row.FindControl("lblAction");
                lbl.Text = ((subscriberActions)Enum.Parse(typeof(subscriberActions), Logger.ActionID.ToString())).GetValue();
                if (Logger.ObjectTypeID == (int)Modules.Businesses)
                {
                    imgbtn.PostBackUrl = "~/ViewBusiness/" + Logger.ObjectID+"/"+Logger.ID;
                }
                if (Logger.ObjectTypeID == (int)Modules.Items)
                {
                    imgbtn.PostBackUrl = "~/ViewItem/" + Logger.ObjectID + "/" + Logger.ID;
                }
                if (Logger.ObjectTypeID == (int)Modules.Offers)
                {
                    imgbtn.PostBackUrl = "~/ViewOffer/" + Logger.ObjectID + "/" + Logger.ID;
                }
                if (Logger.ObjectTypeID == (int)Modules.RealEstates)
                {
                    imgbtn.PostBackUrl = "~/RealEstateView/" + Logger.ObjectID + "/" + Logger.ID;
                }
            }
        }

        //protected void rtsNewObjects_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        //{
        //    Controller.OnSelectModule(Convert.ToInt32(RadTabStrip1.SelectedTab.Value));
        //}

        public void BindNewObjects(List<BrokerDLL.SubscriberLog> Objects)
        {
            gvNewObjects.DataSource = Objects;
            gvNewObjects.DataBind();
        }

        //protected void RadTabStrip1_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        //{
        //    Controller.OnSelectModule(Convert.ToInt32(RadTabStrip1.SelectedTab.Value));
        //}
    }
}