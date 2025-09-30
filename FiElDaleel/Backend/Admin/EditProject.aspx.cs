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
    public partial class EditProject : System.Web.UI.Page, IRealEstateProject
    {
        RealEstateProjectController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateProjectController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void rtsProject_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedIndex != 0)
            {
                Controller.OnSelectCity(Convert.ToInt32(ddlCity.SelectedValue));
            }
            else
            {
                ddlDistrict.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountries.SelectedIndex != 0)
            {
                Controller.OnSelectCountry(Convert.ToInt32(ddlCountries.SelectedValue));
            }
            else
            {
                ddlCity.Items.Clear();
                ddlDistrict.Items.Clear();
                ddlCity.Items.Insert(0, new ListItem("--اختار--", "0"));
                ddlDistrict.Items.Insert(0, new ListItem("--اختار--", "0"));
            }
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

        public void FillCountryList(List<BrokerDLL.Country> Countries)
        {
            ddlCountries.DataSource = Countries;
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataValueField = "ID";
            ddlCountries.DataBind();
            ddlCountries.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlCity.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillCityList(List<BrokerDLL.City> Cities)
        {
            ddlCity.DataSource = Cities;
            ddlCity.DataTextField = "Name";
            ddlCity.DataValueField = "ID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlDistrict.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillDistrictList(List<BrokerDLL.District> Districts)
        {
            ddlDistrict.DataSource = Districts;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "ID";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public BrokerDLL.RealEstateProject FillObject(BrokerDLL.RealEstateProject Project)
        {
            Project.CityID = Convert.ToInt32(ddlCity.SelectedValue);
            Project.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
            Project.Description = txtDescription.Text;
            Project.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            Project.Title = txtTitle.Text;
            Project.Sologan = txtSlogan.Text;
            Project.Latitude = hdnLat.Value;
            Project.Longitude = hdnLng.Value;
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                Project.Logo = "~/Resources/RealEstates/Projects/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/"
                    + DateTime.Now.Day + "/" + Project.Code + "/logo"  + ruPhoto.UploadedFiles[0].GetExtension();
                imgLogo.ImageUrl = Project.Logo;
            }
            return Project;
        }

        public void FillControls(BrokerDLL.RealEstateProject Project)
        {
            if (Project != null)
            {
                Controller.OnSelectCountry(Project.CountryID.Value);
                Controller.OnSelectCity(Project.CityID.Value);
                txtTitle.Text = Project.Title;
                txtSlogan.Text = Project.Sologan;
                txtDescription.Text = Project.Description;
                ddlDistrict.SelectedValue = Project.DistrictID.ToString();
                ddlCountries.SelectedValue = Project.CountryID.ToString();
                ddlCity.SelectedValue = Project.CityID.ToString();
                imgLogo.ImageUrl = Project.Logo;
                hdnLng.Value = Project.Longitude;
                hdnLat.Value = Project.Latitude;
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/notFound.html");
            }
        }

        public void upload(string Code)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/Projects/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code + "\\";
                    path += "logo" + ruPhoto.UploadedFiles[i].GetExtension();
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
            if (Mode == PageMode.Add)
            {
                txtDescription.Text = "";
                txtTitle.Text = "";
                txtSlogan.Text = "";
                ddlCity.SelectedIndex = 0;
                ddlCountries.SelectedIndex = 0;
                ddlDistrict.SelectedIndex = 0;
                ruPhoto.UploadedFiles.Clear();
                divlogo.Visible = false;
                rtsProject.Tabs.ToList().ForEach(T => T.Enabled = false);
                rtsProject.Tabs[0].Enabled = true;
            }
            if (Mode == PageMode.Edit)
            {
                rtsProject.Tabs.ToList().ForEach(T => T.Enabled = true);
                divlogo.Visible = true;

                ucProjectPhoto1.ProjectID = ProjectID;
                ucProjectVedio1.ProjectID = ProjectID;
                ucProjectModel1.ProjectID = ProjectID;
                // ucProjectPhoto1.M
                // ucProjectPhoto1.InitialProjectPhotos();
                //imgLogo.

            }
            if (Mode == PageMode.Disable)
            {
                txtTitle.Enabled = false;
                txtDescription.Enabled = false;
                ddlDistrict.Enabled = false;
                ddlCountries.Enabled = false;
                ddlCity.Enabled = false;
                ruPhoto.Enabled = false;
                rtsProject.Tabs.ToList().ForEach(T => T.Enabled = false);
                btnSave.Enabled = false;
            }
        }
    }
}