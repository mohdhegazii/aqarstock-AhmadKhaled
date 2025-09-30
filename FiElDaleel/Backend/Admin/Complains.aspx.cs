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

namespace BrokerWeb.Backend.Admin
{
    public partial class Complains : System.Web.UI.Page, IRealEstateComplains
    {
        RealEstateComplainsController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateComplainsController(this);
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

        protected void rgComplains_ItemDataBound(object sender, GridItemEventArgs e)
        {
            
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                RealEstateComplain request = (RealEstateComplain)e.Item.DataItem;
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

        protected void rgComplains_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
               rgComplains.DataSource= Controller.OnNeedDataSource();
            }
        }

        public void BindComplains(List<RealEstateComplain> Complains)
        {
            rgComplains.DataSource = Complains;
            rgComplains.DataBind();
        }

        public void FillComplainControls(RealEstateComplain Complain)
        {
            lblCode.Text = Complain.RealEstate.Code.ToString();
            lblDate.Text = Complain.CreatedDate.Value.ToShortDateString();
            lblComplainTitle.Text = Complain.ComplainTitle;
            lblComplainDetails.Text = Complain.ComplainDetails;
            lblComplainerEmail.Text = Complain.ComplainerEmail;
            lblComplainerName.Text = Complain.ComplainerName;
            lblComplainerPhone.Text = Complain.ComplainerPhone;
            lblTitle.Text = Complain.RealEstate.Title;
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
    }
}