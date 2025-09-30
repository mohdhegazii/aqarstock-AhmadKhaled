using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using Telerik.Web.UI;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class PurchaseRequestReport : System.Web.UI.Page, IPurchaseRequestReport
    {
        PurchaseRequestReportController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new PurchaseRequestReportController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
                rdpFrom.SelectedDate = DateTime.Today;
                rdpTo.SelectedDate = DateTime.Today.Add(new TimeSpan(11, 59, 0));
            }
        }
        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridItem item = (GridItem)ibtn.NamingContainer;
            int id = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["ID"]);
            Controller.OnSelectRequest(id);

        }
     

        protected void rgRequests_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                RealEstatePurchaseRequest request = (RealEstatePurchaseRequest)e.Item.DataItem;
                Label lbl = (Label)e.Item.FindControl("lblCode");
                lbl.Text = request.RealEstate.Code.ToString();
                lbl = (Label)e.Item.FindControl("lblTitle");
                lbl.Text = request.RealEstate.Title;
                CheckBox chk = (CheckBox)e.Item.FindControl("chkIsRead");
                if (request.IsRead == true)
                {
                    chk.Checked = true;
                }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool? IsActive;
            switch (rblReadStatus.SelectedValue)
            {
                case "0":
                    IsActive = null;
                    break;
                case "1":
                    IsActive = true;
                    break;
                case "2":
                    IsActive = false;
                    break;
                default:
                    IsActive = null;
                    break;
            }
            Controller.OnSearch(rdpFrom.SelectedDate.Value, rdpTo.SelectedDate.Value.Add(new TimeSpan(11, 59, 0)), IsActive);

        }
    }
}