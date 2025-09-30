using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Controllers;
using BrokerDLL.Backend.Views;
using BrokerDLL;
using System.IO;
using System.Text.RegularExpressions;

namespace BrokerWeb.Backend.Admin
{
    public partial class PartnerPage : System.Web.UI.Page, IPartner
    {
        PartnerController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new PartnerController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        public int PartnerID
        {
            get
            {
                if (ViewState["PartnerID"] != null)
                {
                    return (int)ViewState["PartnerID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["PartnerID"] = value;
            }
        }

        public void FillSubscriberList(List<BrokerDLL.Subscriber> Subscribers)
        {
            ddlSubscriber.DataSource = Subscribers;
            ddlSubscriber.DataTextField = "UserName";
            ddlSubscriber.DataValueField = "ID";
            ddlSubscriber.DataBind();
            ddlSubscriber.Items.Insert(0, new ListItem("--اخنار--", "0"));
        }

        public void FillControls(BrokerDLL.Partner partner)
        {
            ddlSubscriber.SelectedValue = partner.SubscriberID.ToString();
            txtTitle.Text = partner.Title;
            txtDescription.Text = partner.Description;
            txtkeywords.Text = partner.KeyWords;
            txtPageTitle.Text = partner.PageTitle;
            txtURL.Text = partner.URL;
            imgIcon.ImageUrl = partner.Logo;
        }

        public BrokerDLL.Partner FillObject(Partner partner)
        {
            partner.SubscriberID = Convert.ToInt32(ddlSubscriber.SelectedValue);
            partner.Description = txtDescription.Text;
            partner.KeyWords = txtkeywords.Text;
            partner.PageTitle = txtPageTitle.Text;
            partner.Title = txtTitle.Text;
            partner.URL = "Page/" + ddlSubscriber.SelectedValue + "/" + txtTitle.Text.Replace(' ','-');
            partner.Logo = "~/Resources/RealEstates/Companies/" + partner.Code + "/" + Regex.Replace(ruPhoto.UploadedFiles[0].GetNameWithoutExtension(), "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension();

            return partner;
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
            if (Mode == PageMode.Edit)
            {
                txtURL.Text = "Page/" + ddlSubscriber.SelectedValue + "/" + txtTitle.Text.Replace(' ', '-');
                divlogo.Visible = true;
            }
            else
            {
                divlogo.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }
        public void UploadRealEstatePhoto(string Code)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/")+"\\"+Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + Code + "\\";
                    path += Regex.Replace(ruPhoto.UploadedFiles[i].GetNameWithoutExtension(), "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[i].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    //ruPhoto.UploadedFiles[0].
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);
             
                }
            }
        }
    }
}