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
    public partial class RealEstateTypes : System.Web.UI.Page,IRealEstateType
    {
        RealEstateTypeController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateTypeController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvTypes.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvTypes.DataKeys[item.RowIndex].Value));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           // System.Drawing.Bitmap img = new System.Drawing.Bitmap(ruIcon.UploadedFiles[0].InputStream);
            //if (img.Height < 200 || img.Width < 200)
            //{
            //    NotifyUser(Message.InvalidPhoto, MessageType.Error);
            //    return;
            //}
            Controller.OnSave();
        }

        public int RealEstateTypeID
        {
            get
            {
                if (ViewState["RealEstateTypeID"] != null)
                {
                    return (int)ViewState["RealEstateTypeID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["RealEstateTypeID"] = value;
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

        public BrokerDLL.RealEstateType FillRealEstateTypeObject()
        {
            RealEstateType Type;
            if (Mode == PageMode.Add)
            {
                Type = new RealEstateType();
            }
            else
            {
                Type = Controller.OnGetById();
            }
            Type.Title = txtTitle.Text;
            Type.RealEstateCategoryId = Convert.ToInt32(ddlCategories.SelectedValue);
            if (ruIcon.UploadedFiles.Count > 0)
            {
                Type.Icon = "~/Resources/RealEstates/Types/" + txtTitle.Text + "_icon" + ruIcon.UploadedFiles[0].GetExtension();
            }
            return Type;
        }

        public void FillRealEstateTypeControls(BrokerDLL.RealEstateType Type)
        {
            txtTitle.Text = Type.Title;
            ddlCategories.SelectedValue = Type.RealEstateCategoryId.ToString();
            if (Type.Icon != "" && Type.Icon != null)
            {
                imgIcon.ImageUrl = Type.Icon;
            }
            else
            {
                divlogo.Visible = false;
            }
        }

        public void FillCategoryList(List<RealEstateCategory> Categories)
        {
            ddlCategories.DataSource = Categories;
            ddlCategories.DataTextField = "Title";
            ddlCategories.DataValueField = "ID";
            ddlCategories.DataBind();
            ddlCategories.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void BindRealEstateTypeList(List<BrokerDLL.RealEstateType> Types)
        {
            gvTypes.DataSource = Types;
            gvTypes.DataBind();
        }

        public void UploadRealEstateIcon()
        {
            if (ruIcon.UploadedFiles.Count > 0)
            {
                string Path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Types");
                ruIcon.UploadedFiles[0].SaveAs(Path + "\\" + txtTitle.Text + "_icon" + ruIcon.UploadedFiles[0].GetExtension());
                SavePhotoThump.SaveThumb(Path + "\\" + txtTitle.Text + "_icon" + ruIcon.UploadedFiles[0].GetExtension(), Path + "\\" + txtTitle.Text + "_icon_map" + ruIcon.UploadedFiles[0].GetExtension(), 32, 32);

            }
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
                divlogo.Visible = false;
                ruIcon.UploadedFiles.Clear();
            }
            if (Mode == PageMode.Edit)
            {
                divlogo.Visible = true;
            }
        }

    }
}