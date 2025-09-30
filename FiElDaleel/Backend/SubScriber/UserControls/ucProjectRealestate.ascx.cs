using BrokerDLL;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucProjectRealestate : System.Web.UI.UserControl, IProjectRealestates
    {
        ProjectRealestateController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ProjectRealestateController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnAdd(Convert.ToInt32(ddlRealestate.SelectedValue));
        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnRemove(Convert.ToInt32(gvRealestate.DataKeys[item.RowIndex].Value));
        }

        public int ProjectID
        {
            get
            {
                if (ViewState["ProjectID"] != null)
                {
                    return (int)ViewState["ProjectID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["ProjectID"] = value;
            }
        }

        public void BindRealestateList(List<BrokerDLL.RealEstate> realestates)
        {
            gvRealestate.DataSource = realestates;
            gvRealestate.DataBind();
        }

        public void FillRealEstateDDL(List<BrokerDLL.RealEstate> realestates)
        {
            ddlRealestate.DataSource = realestates;
            ddlRealestate.DataTextField = "Title";
            ddlRealestate.DataValueField = "ID";
            ddlRealestate.DataBind();
            ddlRealestate.Items.Insert(0, new ListItem("--اختار--", "0"));
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