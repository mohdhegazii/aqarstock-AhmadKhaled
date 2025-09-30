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
    public partial class Notifications : AqarPage, ISubscriberNotification
    {
        SubscriberNotificationController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SubscriberNotificationController(this);
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
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                SubscriberNotification notification = (SubscriberNotification)e.Item.DataItem;
                //"<%#"عرض_بيانات_العقار/"+Eval("RealEstateID") %>" 
                HyperLink lbtn = (HyperLink)e.Item.FindControl("lbtn");
                //lbl.Text = request.RealEstate.Code.ToString();
              //  Label lbl = (Label)e.Item.FindControl("lblTitle");
                if (notification.ObjectTypeID == (int)Modules.RealEstates)
                {
                    lbtn.NavigateUrl = "~/عرض_بيانات_العقار/" + notification.ObjectID;
                }
                if (notification.ObjectTypeID == (int)Modules.Companies)
                {
                    lbtn.NavigateUrl = "~/تعديل_بيانات_حساب_الشركة/";
                }
                if (notification.ObjectTypeID == (int)Modules.Projects)
                {
                    lbtn.NavigateUrl = "~/تعديل_بيانات_المشروع/" + notification.ObjectID;
                }
                if (notification.IsRead == false)
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
                rgRequests.DataSource = Controller.OnNeedDataSource();
            }
        }

        public void BindList(List<SubscriberNotification> Notifications)
        {
            rgRequests.DataSource = Notifications;
            rgRequests.DataBind();
        }

        public void FillNotificationControls(SubscriberNotification Notification)
        {
            lblType.Text = Notification.Type.ToString();
            lblDate.Text = Notification.CreatedDate.Value.ToShortDateString();
            lblMessage.Text = Notification.Description;
            lblTitle.Text = Notification.ObjectName;
            lblNotificationTitle.Text = Notification.Title;
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

        public void OpenNotification()
        {
            rwRequestDetails.VisibleOnPageLoad = true;
        }
    }
}