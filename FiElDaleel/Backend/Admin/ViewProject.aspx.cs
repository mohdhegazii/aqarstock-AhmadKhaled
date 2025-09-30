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
    public partial class ViewProject : System.Web.UI.Page, IAdminViewProject
    {
        AdminViewProjectController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminViewProjectController(this);
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
        public int SubscriberLogID
        {
            get
            {
                if (ViewState["SubscriberLogID"] != null)
                {
                    return (int)ViewState["SubscriberLogID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SubscriberLogID"] = value;
            }
        }
        public void FillControls(BrokerDLL.RealEstateProject Project)
        {
            imgLogo.ImageUrl = Project.Logo;
            lblTitle.Text = Project.Title;
            lblSlogan.Text = Project.Sologan;
            lblCode.Text = Project.Code.ToString();
            lblDescription.Text = Project.Description;
            lblCompanyName.Text = Project.RealEstateCompany.Title ;
            lblSubscriberEmail.Text = Project.Subscriber.Email;
            lblSubscriberName.Text = Project.Subscriber.FullName;
            lblSubscriberPhone.Text = Project.Subscriber.MobileNo;
            //imgPhoto.ImageUrl = company.Logo;
            if (Project.CountryID != null && Project.CountryID != 0)
            {
                lblAddress.Text = Project.District.Name + ", " + Project.City.Name + ", " + Project.Country.Name;
            }
            if (Project.AdPackageID == (int)AdvPackage.Banner)
            {
                imgSetOffer.Visible = false;
                imgRemoveOffer.Visible = true;
            }
            if (Project.AdPackageID == (int)AdvPackage.HomePage)
            {
                imgHomePage.Visible = false;
                imgRemoveOffer.Visible = true;
            }
            if (Project.AdPackageID == (int)AdvPackage.Normal)
            {
                imgSetOffer.Visible = true;
                imgHomePage.Visible = true;
                imgRemoveOffer.Visible = false;
            }
            //gvUsers.DataSource = Project.Subscribers;
            //gvUsers.DataBind();
            FillPhotoControls(Project);
            FillVedioControls(Project);
            FillModelControls(Project);
            FillPropsControls(Project);
            if (Project.ActiveStatusID == (int)Activestatus.Suspended)
            {
                string Msg = Message.Suspended.GetValue();
                Msg += Project.SuspendReason.Title;
                Msg += "<br/>" + Project.SuspendMessage;
                NotifyUser(Msg, MessageType.Error);
            }

        }

        private void FillPropsControls(RealEstateProject Project)
        {
            gvRealestates.DataSource = Project.RealEstates;
            gvRealestates.DataBind();
        }

        private void FillModelControls(RealEstateProject Project)
        {
            gvModels.DataSource = Project.RealEstateProjectModels;
            gvModels.DataBind();
        }

        private void FillVedioControls(RealEstateProject Project)
        {
            gvVedios.DataSource = Project.RealEstateProjectVideos;
            gvVedios.DataBind();
        }
        private void FillPhotoControls(RealEstateProject Project)
        {

            rlvPhotos.DataSource = Project.RealEstateProjectPhotos;
            rlvPhotos.DataBind();
            
            if (Project.RealEstateProjectPhotos != null && Project.RealEstateProjectPhotos.Count > 0)
            {
                RealEstateProjectPhoto Photo;
                Photo = Project.RealEstateProjectPhotos.FirstOrDefault(RP => RP.IsDefault == true);
                if (Photo == null)
                {
                    Photo = Project.RealEstateProjectPhotos.ToList()[0];
                }
                imgCurrentPhoto.ImageUrl = Photo.PhotoURL;
                lblDate.Text = Photo.Date.Value.ToShortDateString();
                lblPhotoDesc.Text = Photo.Description;
            }
            else
            {
                
                imgCurrentPhoto.Visible = false;
                lblPhotoDesc.Visible = false;
                lblDate.Visible = false;
            }
        }

        public void FillSuspendReasonList(List<SuspendReason> Reasons)
        {
            ddlSuspendReasons.DataSource = Reasons;
            ddlSuspendReasons.DataTextField = "Title";
            ddlSuspendReasons.DataValueField = "ID";
            ddlSuspendReasons.DataBind();
            ddlSuspendReasons.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        protected void imgActivate_Click(object sender, ImageClickEventArgs e)
        {
            Controller.OnActivate();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSuspend(Convert.ToInt32(ddlSuspendReasons.SelectedValue), txtDescription.Text);
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectToRoute("AdminEditProject", new { ProjectID = ProjectID });
        }

        protected void imgSetOffer_Click(object sender, ImageClickEventArgs e)
        {
            Controller.OnSetAdPackage((int)AdvPackage.Banner);
        }

        protected void imgRemoveOffer_Click(object sender, ImageClickEventArgs e)
        {
            Controller.OnSetAdPackage((int)AdvPackage.Normal);
        }


        public void ShowEditControls(bool Show)
        {
            //  throw new NotImplementedException();
        }

        protected void imgHomePage_Click(object sender, ImageClickEventArgs e)
        {
            Controller.OnSetAdPackage((int)AdvPackage.HomePage);
        }
    }
}