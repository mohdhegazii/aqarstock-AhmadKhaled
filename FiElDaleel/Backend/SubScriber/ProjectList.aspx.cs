using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class ProjectList : AqarPage, IProjectList
    {
        ProjectListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ProjectListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void gvProjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProjects.PageIndex = e.NewPageIndex;
            gvProjects.DataSource = Controller.OnNeedDataSource();
            gvProjects.DataBind();
        }


        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnRemove(Convert.ToInt32(gvProjects.DataKeys[item.RowIndex].Value));
            
        }


        public int CompanyID
        {
            get
            {
                if (ViewState["CompanyId"] != null)
                {
                    return (int)ViewState["CompanyId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CompanyId"] = value;
            }
        }

        public void BindList(List<BrokerDLL.RealEstateProject> Projects)
        {
            gvProjects.DataSource = Projects;
            gvProjects.DataBind();
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