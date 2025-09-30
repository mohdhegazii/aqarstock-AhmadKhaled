using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class SuspenedRealEstateReport : System.Web.UI.Page, ISuspendedRealEstatesReport
    {
        SuspendedRealEstateReportController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller=new SuspendedRealEstateReportController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
                rdpFrom.SelectedDate = DateTime.Today;
                rdpTo.SelectedDate = DateTime.Now;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSearch(Convert.ToInt32(ddlReasons.SelectedValue), rdpFrom.SelectedDate.Value, rdpTo.SelectedDate.Value);
        }

        public void BindList(List<BrokerDLL.RealEstateSuspended> RealEstates)
        {
            rgSuspended.DataSource = RealEstates;
            rgSuspended.DataBind();
        }

        public void FillReasonList(List<BrokerDLL.SuspendReason> Reasons)
        {
            ddlReasons.DataSource = Reasons;
            ddlReasons.DataTextField = "Title";
            ddlReasons.DataValueField = "ID";
            ddlReasons.DataBind();
            ddlReasons.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void NotifyUser(BrokerDLL.Message Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg.GetValue();
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }

        public void NotifyUser(string Msg, BrokerDLL.MessageType Type)
        {
            lblMsg.Text = Msg;
            if (Type == MessageType.Success)
                divMsg.Attributes.Add("Class", "alert alert-success");
            else
                divMsg.Attributes.Add("Class", "alert alert-danger"); ;
        }
    }
}