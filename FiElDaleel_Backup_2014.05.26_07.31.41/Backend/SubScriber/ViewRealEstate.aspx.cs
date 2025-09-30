using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using System.Configuration;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class ViewRealEstate : System.Web.UI.Page, IRealEstateView
    {
        RealEstateViewController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateViewController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void imgEdit_Click(object sender, ImageClickEventArgs e)
        {
            Response.RedirectToRoute("EditRealEstate", new { RealEstateID = RealEstateID });
        }


        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            Controller.OnDelete();
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


        public int RealEstateID
        {
            get
            {
                if (ViewState["RealEstateID"] != null)
                {
                    return (int)ViewState["RealEstateID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["RealEstateID"] = value;
            }

        }

        public void FillRealEstateControls(BrokerDLL.RealEstate realestate)
        {
            imgLogo.ImageUrl = realestate.RealEstateType.Icon;
            lblTitle.Text = realestate.Title;
            lblCode.Text = realestate.Code.ToString();
            lblDescription.Text = realestate.Description;
            lblCategory.Text = realestate.RealEstateCategory.Title;
            lblType.Text = realestate.RealEstateType.Title;
            lblStatus.Text = realestate.RealEstateStatu.Title;
            lblSaleType.Text = realestate.SaleType.Title;
            hdnLat.Value = realestate.Latitude;
            hdnLng.Value = realestate.Longitude;
            hdnMapimageURL.Value = ConfigurationSettings.AppSettings["RootURL"].ToString() + "/" + realestate.RealEstateType.Icon.Replace("~/", "").Replace("_icon", "_icon_map");
            if (realestate.UseContactInfo.Value)
            {
                    lblOwnerEmail.Text = Commons.Subsciber.Email;
                    lblOwnerName.Text = Commons.Subsciber.FullName;
                    lblOwnerPhone.Text = Commons.Subsciber.MobileNo;
            }
            else
            {
                lblOwnerEmail.Text = realestate.OwnerEmail;
                lblOwnerName.Text = realestate.OwnerName;
                lblOwnerPhone.Text = realestate.OwnerMobile;
            }
            if (realestate.IsSold == false)
            {
                imgSold.Visible = false;
            }
            if (realestate.CountryID != null && realestate.CountryID != 0)
            {
                lblAddress.Text = realestate.Street + ", " + realestate.District.Name + ", " + realestate.City.Name + ", " + realestate.Country.Name;
            }
            if (realestate.Area != null && realestate.Area != 0)
            {
                lblArea.Text = realestate.Area.ToString() + " متر مربع";
            }
            if (realestate.Price != null && realestate.Price != 0)
            {
                lblPrice.Text = realestate.Price.ToString();
            }
            if (realestate.PaymentTypeID != null && realestate.PaymentTypeID != 0)
            {
                lblPaymentType.Text = realestate.PaymentType.Title;
            }
            if (realestate.CurrencyID != null && realestate.CurrencyID != 0)
            {
                lblCurrency.Text = realestate.Currency.Name;
            }

            rptKeywords.DataSource = realestate.RealEstateKeywords;
            rptKeywords.DataBind();

            rptCriteria.DataSource = realestate.RealEstateCriterias.OrderBy(RC => RC.RealEstateTypeCriteria.ValueType);
            rptCriteria.DataBind();

            FillPhotoControls(realestate);
            if (realestate.ActiveStatusId == (int)Activestatus.Suspended)
            {
                RealEstateSuspended suspended = realestate.RealEstateSuspendeds.FirstOrDefault();
                if (suspended != null)
                {
                    string Msg = Message.Suspended.GetValue();
                    Msg += suspended.SuspendReason.Title;
                    Msg += "<br/>" + suspended.Message;
                    NotifyUser(Msg, MessageType.Error);
                }
            }

        }
        private void FillPhotoControls(RealEstate realestate)
        {

            rlvPhotos.DataSource = realestate.RealEstatePhotos;
            rlvPhotos.DataBind();
            if (realestate.RealEstatePhotos != null && realestate.RealEstatePhotos.Count > 0)
            {
                RealEstatePhoto Photo = realestate.RealEstatePhotos.FirstOrDefault(RP => RP.IsDefault == true);
                if (Photo != null)
                {
                    imgCurrentPhoto.ImageUrl = Photo.PhotoName;
                }
                else
                {
                    imgCurrentPhoto.ImageUrl = realestate.RealEstatePhotos.ToList()[0].PhotoName;
                }
            }
            else
            {
                imgCurrentPhoto.Visible = false;
            }
        }

        protected void rptCriteria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RealEstateCriteria criteria = (RealEstateCriteria)e.Item.DataItem;
            //   Image img = (Image)e.Item.FindControl("imgCriteria");
            Label lbl = (Label)e.Item.FindControl("lblCriteria");
            if (criteria.RealEstateTypeCriteria.ValueType == "bool")
            {
                lbl.Text = criteria.RealEstateTypeCriteria.Title;
            }
            else
            {
                //  img.Visible = false;
                lbl.Text = criteria.RealEstateTypeCriteria.Title + ": " + criteria.Value + ", ";
            }

        }

    }
}