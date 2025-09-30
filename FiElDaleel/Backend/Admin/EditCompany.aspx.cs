using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using System.Text.RegularExpressions;
using System.IO;
using BrokerDLL;

namespace BrokerWeb.Backend.Admin
{
    public partial class EditCompany : System.Web.UI.Page, IRealEstateCompany
    {

        RealEstateCompanyController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateCompanyController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedIndex != 0)
            {
                Controller.OnSelectCountry(Convert.ToInt32(ddlCountry.SelectedValue));
            }
            else
            {
                ddlCities.Items.Clear();
                ddlDistricts.Items.Clear();
                ddlCities.Items.Insert(0, new ListItem("--اختار--", "0"));
                ddlDistricts.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCities.SelectedIndex != 0)
            {
                Controller.OnSelectCity(Convert.ToInt32(ddlCities.SelectedValue));
            }
            else
            {
                ddlDistricts.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
        }
        public int CompanyId
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

        public BrokerDLL.RealEstateCompany FillObject(BrokerDLL.RealEstateCompany Company)
        {
            Company.Description = txtDescription.Text;
            Company.Email = txtEmail.Text;
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                Company.Logo = "~/Resources/RealEstates/Companies/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/"
                    + DateTime.Now.Day + "/" + Company.Code + "/logo"+ ruPhoto.UploadedFiles[0].GetExtension();
            }
            Company.Phone = txtPhone.Text;
            Company.Summary = txtSummary.Text;
            Company.Title = txtTitle.Text;
            Company.CityId = Convert.ToInt32(ddlCities.SelectedValue);
            Company.CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            Company.DistrictId = Convert.ToInt32(ddlDistricts.SelectedValue);
            //Company.Street = txtstreet.Text;
            Company.Latitude = hdnLat.Value;
            Company.Longutide = hdnLng.Value;

            return Company;
        }

        public void FillControls(BrokerDLL.RealEstateCompany Company)
        {
            Controller.OnSelectCountry(Company.CountryId.Value);
            Controller.OnSelectCity(Company.CityId.Value);

            txtDescription.Text = Company.Description;
            txtEmail.Text = Company.Email;
            txtPhone.Text = Company.Phone;
            txtSummary.Text = Company.Summary;
            txtTitle.Text = Company.Title;
            imgLogo.ImageUrl = Company.Logo;
            //txtstreet.Text = Company.Street;
            ddlCountry.SelectedValue = Company.CountryId.ToString();
            ddlCities.SelectedValue = Company.CityId.ToString();
            ddlDistricts.SelectedValue = Company.DistrictId.ToString();
            hdnLng.Value = Company.Longutide;
            hdnLat.Value = Company.Latitude;
        }

        public void FillCountryList(List<BrokerDLL.Country> Countries)
        {
            ddlCountry.DataSource = Countries;
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataValueField = "ID";
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlCities.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlDistricts.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillCityList(List<BrokerDLL.City> Cities)
        {
            ddlCities.DataSource = Cities;
            ddlCities.DataTextField = "Name";
            ddlCities.DataValueField = "ID";
            ddlCities.DataBind();
            ddlCities.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlDistricts.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillDistrictList(List<BrokerDLL.District> Districts)
        {
            ddlDistricts.DataSource = Districts;
            ddlDistricts.DataTextField = "Name";
            ddlDistricts.DataValueField = "ID";
            ddlDistricts.DataBind();
            ddlDistricts.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void UploadLogo(string Code)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Companies/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code + "\\";
                    path += "logo"+ ruPhoto.UploadedFiles[i].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    ruPhoto.UploadedFiles[0].SaveAs(path);
                    //System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    //ImageCompress.ApplyCompressionAndSave(img, path, 30, ruPhoto.UploadedFiles[0].ContentType);
                }
            }
        }

        public BrokerDLL.PageMode Mode
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
                divlogo.Visible = true;
            }
            else
            {
                divlogo.Visible = false;
            }
        }
    }
}