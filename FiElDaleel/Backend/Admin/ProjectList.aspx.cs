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
    public partial class ProjectList : System.Web.UI.Page, IAdminProjectList
    {
        AdminProjectListController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminProjectListController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
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

        public void BindGrid(List<RealEstateProject> Projects)
        {
            gvPartners.DataSource = Projects;
            gvPartners.DataBind();
        }

        public void FillCompanyDLL(List<RealEstateCompany> Companies)
        {
            ddlCompanies.DataSource = Companies;
            ddlCompanies.DataTextField = "Title";
            ddlCompanies.DataValueField = "ID";
            ddlCompanies.DataBind();
            ddlCompanies.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvPartners.DataKeys[item.RowIndex].Value));
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSelectCompany(Convert.ToInt32(ddlCompanies.SelectedValue));
        }


        
    }
}