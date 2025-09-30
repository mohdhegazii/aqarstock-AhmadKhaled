using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;

namespace BrokerWeb.Backend.Admin.Settings
{
    public partial class RemoveSuspendedRealEstates : System.Web.UI.Page, IRemoveSuspendedRealEstates
    {
        RemoveSuspendedRealestatesController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RemoveSuspendedRealestatesController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnRemove(rdpDate.SelectedDate.Value);
        }

        public BrokerDLL.PageMode Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                {
                    return (PageMode)ViewState["Mode"];
                }
                else
                {
                    return PageMode.Add;
                }
            }
            set
            {
                ViewState["Mode"] = value;
            }
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

        public void Navigate()
        {
          
        }
    }
}