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
    public partial class SubscriberReport : System.Web.UI.Page, ISubscriberReport
    {
        SubscriberReportController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new SubscriberReportController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
                rdpFrom.SelectedDate = DateTime.Today;
                rdpTo.SelectedDate = DateTime.Today;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetResult();

        }

        private void GetResult()
        {
            bool? IsActive;
            switch (rblActiveStatus.SelectedValue)
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

        public void BindGrid(List<BrokerDLL.Subscriber> Subscibers)
        {
            gvSubscribers.DataSource=Subscibers;
            gvSubscribers.DataBind();
        }

        protected void gvSubscribers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkIsActive");
                BrokerDLL.Subscriber subscriber = (BrokerDLL.Subscriber)e.Row.DataItem;
                if (subscriber.ActiveStatusID == (int)Activestatus.Active)
                {
                    chk.Checked = true;
                }
                else
                {
                    chk.Checked = false;
                }
            }
        }

        protected void gvSubscribers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubscribers.PageIndex = e.NewPageIndex;
            //gvSubscribers.DataSource=
            GetResult();
        }
    }
}