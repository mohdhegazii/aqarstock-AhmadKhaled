using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.General;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using Telerik.Web.UI;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class ChangeRealEstateSubscriber : AqarPage, IChangeRealEstateSubscriber
    {
        ChangeRealEstateSubscriberController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ChangeRealEstateSubscriberController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void rgRealEstates_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
                DropDownList ddl = (DropDownList)rtbmovesubscriber.Items[0].FindControl("ddlSubscribers");
                rgRealEstates.DataSource = Controller.OnNeedDataSource(Convert.ToInt32(ddl.SelectedValue));
            }
        }

        public void FillSubscriberList(List<BrokerDLL.Subscriber> Subscribers)
        {
            DropDownList ddl = (DropDownList)rtbmovesubscriber.Items[0].FindControl("ddlSubscribers");
            ddl.DataSource = Subscribers;
            ddl.DataTextField = "FullName";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddl = (DropDownList)rtbmovesubscriber.Items[1].FindControl("ddlNewSubscribers");
            ddl.DataSource = Subscribers;
            ddl.DataTextField = "FullName";
            ddl.DataValueField = "ID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void BindSubscriberList(List<Subscriber> Subscribers)
        {
           
        }

        public void BindRealEstateList(List<BrokerDLL.RealEstate> RealEstates)
        {
            rgRealEstates.DataSource = RealEstates;
            rgRealEstates.DataBind();
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

        protected void ddlSubscribers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (ddl.SelectedIndex > 0)
            {
                Controller.OnSelectSubscriber(Convert.ToInt32(ddl.SelectedValue));
            }
            else
            {
                rgRealEstates.DataSource = null;
                rgRealEstates.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)rtbmovesubscriber.Items[1].FindControl("ddlNewSubscribers");
            int NewSubcriberid = Convert.ToInt32(ddl.SelectedValue);
            ddl = (DropDownList)rtbmovesubscriber.Items[0].FindControl("ddlSubscribers");
            int OldSubcriberid = Convert.ToInt32(ddl.SelectedValue);
            List<int> realestateIds = new List<int>();
            CheckBox chkMove;
            foreach(GridItem Item in rgRealEstates.Items)
            {
                chkMove = (CheckBox)Item.FindControl("chkMove");
                if (chkMove.Checked)
                {
                    realestateIds.Add(Convert.ToInt32(Item.OwnerTableView.DataKeyValues[Item.ItemIndex]["ID"]));
                }
            }
            Controller.OnMoveRealEstates(realestateIds, OldSubcriberid, NewSubcriberid);
        }


    }
}