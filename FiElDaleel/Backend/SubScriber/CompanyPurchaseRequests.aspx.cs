using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using Telerik.Web.UI;
using BrokerDLL;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class CompanyPurchaseRequests : AqarPage, ICompanyPurchaseRequests
    {
        CompanyPurchaseRequestsController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new CompanyPurchaseRequestsController(this);
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
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            int id = Convert.ToInt32(rgRequests.DataKeys[item.RowIndex].Value);
            Controller.OnSelectRequest(id);

        }


        //protected void rgRequests_ItemDataBound(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == GridViewRow.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        //    {
        //        RealEstatePurchaseRequest request = (RealEstatePurchaseRequest)e.Item.DataItem;
        //        Label lbl = (Label)e.Item.FindControl("lblCode");
        //        lbl.Text = request.RealEstate.Code.ToString();
        //        lbl = (Label)e.Item.FindControl("lblTitle");
        //        lbl.Text = request.RealEstate.Title;
        //        CheckBox chk = (CheckBox)e.Item.FindControl("chkIsRead");
        //        if (request.IsRead == true)
        //        {
        //            chk.Checked = true;
        //        }
        //    }
        //}
        protected void rgRequests_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RealEstatePurchaseRequest request = (RealEstatePurchaseRequest)e.Row.DataItem;
                Label lbl = (Label)e.Row.FindControl("lblCode");
                lbl.Text = request.RealEstate.Code.ToString();
                lbl = (Label)e.Row.FindControl("lblTitle");
                lbl.Text = request.RealEstate.Title;
                CheckBox chk = (CheckBox)e.Row.FindControl("chkIsRead");
                if (request.IsRead == true)
                {
                    chk.Checked = true;
                }
            }
        }
        protected void rgRequests_NeedDataSource(object sender, GridViewPageEventArgs e)
        {
            rgRequests.PageIndex = e.NewPageIndex;
            if (IsPostBack)
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
                int? subsciberid;
                if (rcbSubscribers.SelectedIndex > 0)
                {
                    subsciberid = Convert.ToInt32(rcbSubscribers.SelectedValue);
                }
                else
                {
                    subsciberid = null;
                }
                Controller.OnNeedDataSource(rdpFrom.SelectedDate.Value, rdpTo.SelectedDate.Value.Add(new TimeSpan(11, 59, 0)), subsciberid, IsActive);
                
               
            }
        }

        //public void FillRequestList(List<RealEstatePurchaseRequest> Requests)
        //{
        //    rgRequests.DataSource = Requests;
        //}

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

        public void FillSubscriberList(List<BrokerDLL.Subscriber> Subcribers)
        {
            rcbSubscribers.DataSource = Subcribers;
            rcbSubscribers.DataTextField = "FullName";
            rcbSubscribers.DataValueField = "ID";
            rcbSubscribers.DataBind();
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


        //public void OpenRequest()
        //{
        //    rwRequestDetails.VisibleOnPageLoad = true;
        //}

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
            int? subsciberid;
            if (rcbSubscribers.SelectedIndex > 0)
            {
                subsciberid = Convert.ToInt32(rcbSubscribers.SelectedValue);
            }
            else
            {
                subsciberid = null;
            }
            Controller.OnSearch(rdpFrom.SelectedDate.Value, rdpTo.SelectedDate.Value.Add(new TimeSpan(11, 59, 0)),subsciberid, IsActive);

        }

        



      
    }
}