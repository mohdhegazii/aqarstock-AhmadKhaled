using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class ViewCompany : System.Web.UI.Page, IAdminViewCompany
    {
        AdminViewCompanyController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new AdminViewCompanyController(this);
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


        public int CompanyID
        {
            get
            {
                if (ViewState["CompanyID"] != null)
                {
                    return (int)ViewState["CompanyID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CompanyID"] = value;
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
        public void FillControls(BrokerDLL.RealEstateCompany company)
        {
            imgLogo.ImageUrl = company.Logo;
            lblTitle.Text = company.Title;
            lblCode.Text = company.Code.ToString();
            lblDescription.Text = company.Description;
            lblSummary.Text = company.Summary;
            lblPhone.Text = company.Phone;
            lblEmail.Text = company.Email;
            lblProjectNo.Text = company.ProjectNos.ToString();
            lblCurrentProjectNo.Text = company.CurrentProjectNos.ToString();
            lblUserNo.Text = company.UserNos.ToString();
            lblCurrenctUserNo.Text = company.CurrentUserNos.ToString();
           // lblSubscriberEmail.Text=company.su
            //imgPhoto.ImageUrl = company.Logo;
            if (company.CountryId != null && company.CountryId != 0)
            {
                lblAddress.Text = company.District.Name + ", " + company.City.Name + ", " + company.Country.Name;
            }

            gvUsers.DataSource = company.Subscribers;
            gvUsers.DataBind();
           // FillPhotoControls(company);
            if (company.ActivateStatusID == (int)Activestatus.Suspended)
            {
                    string Msg = Message.Suspended.GetValue();
                    Msg += company.SuspendReason.Title;
                    Msg += "<br/>" + company.SuspendMessage;
                    NotifyUser(Msg, MessageType.Error);
            }

        }
        //private void FillPhotoControls(RealEstate realestate)
        //{

        //    rlvPhotos.DataSource = realestate.RealEstatePhotos;
        //    rlvPhotos.DataBind();
        //    if (realestate.RealEstatePhotos != null && realestate.RealEstatePhotos.Count > 0)
        //    {
        //        RealEstatePhoto Photo = realestate.RealEstatePhotos.FirstOrDefault(RP => RP.IsDefault == true);
        //        if (Photo != null)
        //        {
        //            imgCurrentPhoto.ImageUrl = Photo.PhotoName;
        //        }
        //        else
        //        {
        //            imgCurrentPhoto.ImageUrl = realestate.RealEstatePhotos.ToList()[0].PhotoName;
        //        }
        //    }
        //    else
        //    {
        //        imgCurrentPhoto.Visible = false;
        //    }
        //}

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
            Response.RedirectToRoute("EditCompany", new { CompanyID = CompanyID });
        }


        public void ShowEditControls(bool Show)
        {
            //  throw new NotImplementedException();
        }
    }
}