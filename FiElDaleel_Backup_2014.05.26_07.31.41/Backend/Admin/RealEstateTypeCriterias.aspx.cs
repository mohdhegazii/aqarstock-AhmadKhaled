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
    public partial class RealEstateTypeCriterias : System.Web.UI.Page, IRealEstateTypeCriteria
    {
        RealEstateTypeCriteriaController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateTypeCriteriaController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvCriterias.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvCriterias.DataKeys[item.RowIndex].Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategories.SelectedIndex > 0)
            {
                Controller.OnSelectCategory(Convert.ToInt32(ddlCategories.SelectedValue));
            }
            else
            {
                ddlTypes.Items.Clear();
                ddlTypes.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }
        }

        public int RealEstateCriteriaID
        {
            get
            {
                if (ViewState["RealEstateCriteriaID"] != null)
                {
                    return (int)ViewState["RealEstateCriteriaID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["RealEstateCriteriaID"] = value;
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

        public BrokerDLL.RealEstateTypeCriteria FillRealEstateTypeCriteriaObject()
        {
            RealEstateTypeCriteria criteria;
            if (Mode == PageMode.Add)
            {
                criteria = new RealEstateTypeCriteria();
            }
            else
            {
                criteria = Controller.OnGetById();
            }
            criteria.Title = txtTitle.Text;
            criteria.RealEstateTypeID = Convert.ToInt32(ddlTypes.SelectedValue);
            criteria.ValueType = ddlValueType.SelectedValue;
            return criteria;
        }

        public void FillRealEstateTypeCriteriaControls(BrokerDLL.RealEstateTypeCriteria Criteria)
        {
            txtTitle.Text = Criteria.Title;
            ddlCategories.SelectedValue = Criteria.RealEstateType.RealEstateCategoryId.ToString();
            Controller.OnSelectCategory(Criteria.RealEstateType.RealEstateCategoryId.Value);
            ddlTypes.SelectedValue = Criteria.RealEstateTypeID.ToString();
            ddlValueType.SelectedValue = Criteria.ValueType;
        }

        public void BindRealEstateTypeCriteriaList(List<BrokerDLL.RealEstateTypeCriteria> Criterias)
        {
            gvCriterias.DataSource = Criterias;
            gvCriterias.DataBind();
        }

        public void FillCategoryList(List<BrokerDLL.RealEstateCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Title";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
            ddlTypes.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillTypeList(List<BrokerDLL.RealEstateType> Types)
        {
            ddlTypes.DataSource = Types;
            ddlTypes.DataTextField = "Title";
            ddlTypes.DataValueField = "ID";
            ddlTypes.DataBind();
            ddlTypes.Items.Insert(0, new ListItem("--اخنار--", "0"));
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
                ddlValueType.SelectedIndex = 0;
                ddlCategories.SelectedIndex = 0;
                ddlTypes.Items.Clear();
                ddlTypes.Items.Insert(0, new ListItem("--اخنار--", "0"));
            }
        }

        public string GetValueTypeText(string value)
        {
            return ddlValueType.Items.FindByValue(value).Text;
        }
    }
}