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
    public partial class RealEstateStatuses : System.Web.UI.Page,IRealEstateStatus
    {
        RealEstateStatusController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateStatusController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }

        }
        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvStatus.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvStatus.DataKeys[item.RowIndex].Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        public int RealEstateStatusID
        {
            get
            {
                if (ViewState["RealEstateStatusID"] != null)
                {
                    return (int)ViewState["RealEstateStatusID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["RealEstateStatusID"] = value;
            }
        }

        public PageMode Mode
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

        public BrokerDLL.RealEstateStatus FillRealEstateStatusObject()
        {
            RealEstateStatus status;
            if (Mode == PageMode.Add)
            {
                status = new RealEstateStatus();
            }
            else
            {
                status = Controller.OnGetById();
            }
            status.RealEstateCategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            status.Title = txtTitle.Text;
            return status;
        }

        public void FillRealEstateStatusControls(BrokerDLL.RealEstateStatus Status)
        {
            txtTitle.Text = Status.Title;
            ddlCategories.SelectedValue = Status.RealEstateCategoryID.ToString();
        }

        public void BindRealEstateStatusList(List<BrokerDLL.RealEstateStatus> Statuses)
        {
            gvStatus.DataSource = Statuses;
            gvStatus.DataBind();
        }

        public void FillCategoryList(List<BrokerDLL.RealEstateCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Title";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
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

        public void Navigate()
        {
            if (Mode == PageMode.Add)
            {
                txtTitle.Text = "";
                ddlCategories.SelectedIndex = 0;
            }
        }
    }
}