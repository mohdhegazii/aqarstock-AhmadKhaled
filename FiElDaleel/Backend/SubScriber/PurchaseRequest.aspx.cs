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
    public partial class PurchaseRequest : AqarPage, IRealEstatePurchaseRequest
    {
        RealEstatePurchaseRequestController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstatePurchaseRequestController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridItem item = (GridItem)ibtn.NamingContainer;
            int id = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["ID"]);
            Controller.OnSelectRequest(id);
            Image img = (Image)item.FindControl("imgNew");
            img.Visible = false;
            
        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridItem item = (GridItem)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["ID"]));
        }

        protected void rgRequests_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType== GridItemType.AlternatingItem)
            {
                RealEstatePurchaseRequest request = (RealEstatePurchaseRequest)e.Item.DataItem;
                Label lbl = (Label)e.Item.FindControl("lblCode");
                lbl.Text = request.RealEstate.Code.ToString();
                lbl = (Label)e.Item.FindControl("lblTitle");
                lbl.Text = request.RealEstate.Title;
                if (request.IsRead == false)
                {
                    Image img = (Image)e.Item.FindControl("imgNew");
                    img.Visible = true;
                }
            }
        }

        protected void rgRequests_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
               rgRequests.DataSource= Controller.OnNeedDataSource();
            }
        }

        public void BindPurchaseRequest(List<RealEstatePurchaseRequest> Requests)
        {
            rgRequests.DataSource = Requests;
            rgRequests.DataBind();
        }

        public void FillRequestControls(RealEstatePurchaseRequest Request)
        {
            lblCode.Text = Request.RealEstate.Code.ToString();
            lblDate.Text = Request.Date.Value.ToShortDateString();
            lblMessage.Text = Request.Message;
            lblPurchaserEmail.Text = Request.PurchaserEmail;
            lblPurchaserName.Text = Request.PurchaserName;
            lblpurchaserPhone.Text = Request.PurchaserPhone;
            lblTitle.Text = Request.RealEstate.Title;
           // rwRequestDetails.VisibleOnPageLoad = true;
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

        public void OpenRequest()
        {
            rwRequestDetails.VisibleOnPageLoad = true;
        }
    }
}