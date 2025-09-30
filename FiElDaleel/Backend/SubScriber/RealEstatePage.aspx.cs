using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL;
using BrokerDLL.Backend.Controllers;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using BrokerDLL.General;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class RealEstatePage : AqarPage, IRealEstateData
    {
        RealEstateDataController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateDataController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
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

        public BrokerDLL.RealEstate FillRealEstateObject(RealEstate realestate, string random)
        {

            if (Mode == PageMode.Add)
            {
                // realestate = new RealEstate();
                realestate.ActiveStatusId = (int)Activestatus.New;
                realestate.CreatedDate = DateTime.Now;
            }
            //else
            //{
            //    realestate = Controller.OnGet();
            //}
            if (txtArea.Text != null && txtArea.Text != "")
            {
                realestate.Area = Convert.ToDouble(txtArea.Text);
            }
            if (ddlCities.SelectedIndex > 0)
            {
                realestate.CityID = Convert.ToInt32(ddlCities.SelectedValue);
            }
            if (ddlCountry.SelectedIndex > 0)
            {
                realestate.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
            }
            if (rptCurrency.SelectedIndex > -1)
            {
                realestate.CurrencyID = Convert.ToInt32(rptCurrency.SelectedValue);
            }
            realestate.Description = txtDescription.Text;
            if (ddlDistricts.SelectedIndex > 0)
            {
                realestate.DistrictID = Convert.ToInt32(ddlDistricts.SelectedValue);
            }
            realestate.IsSold = rptIsSold.Items[1].Selected;
            realestate.Latitude = txtLatitude.Text;
            realestate.Longitude = txtLongitude.Text;
            realestate.UseContactInfo = rptContactData.Items[0].Selected;
            if (realestate.UseContactInfo == false)
            {
                realestate.OwnerEmail = txtOwnerEmail.Text;
                realestate.OwnerMobile = txtOwnerPhone.Text;
                realestate.OwnerName = txtOwnerName.Text;
            }
            if (rptPaymentTypes.SelectedIndex > -1)
            {
                realestate.PaymentTypeID = Convert.ToInt32(rptPaymentTypes.SelectedValue);
            }
            if (txtPrice.Text != null && txtPrice.Text != "")
            {
                realestate.Price = Convert.ToDouble(txtPrice.Text);
            }
            realestate.RealEstateCategoryID = Convert.ToInt32(rplCategories.SelectedValue);
            realestate.RealEstateStatusID = Convert.ToInt32(rptStatus.SelectedValue);
            realestate.RealEstateTypeID = Convert.ToInt32(rplTypes.SelectedValue);
            realestate.SaleTypeId = Convert.ToInt32(rptSaleTypes.SelectedValue);
            realestate.Street = txtStreet.Text;
            realestate.SubscriberID = Commons.Subsciber.ID;
            realestate.Title = txtTitle.Text;
            realestate.IsMigrated = false;
            realestate.IsSpecialOffer = false;


            FillRealEstatePhotoObject(realestate,random);
            FillRealEstateCriteriaObject(realestate);

            return realestate;
        }

        private void FillRealEstatePhotoObject(RealEstate realestate,string random)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                RealEstatePhoto Photo;
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    Photo = new RealEstatePhoto();
                    Photo.IsDefault = false;
                    Photo.PhotoName = "~/Resources/RealEstates/" + DateTime.Today.Year + "/" + DateTime.Today.Month + "/"
                            + DateTime.Today.Day + "/" + realestate.Code + "/" + realestate.Code.ToString()+'-'+random+'_'+i+ ruPhoto.UploadedFiles[i].GetExtension();
                    realestate.RealEstatePhotos.Add(Photo);
                }
                if (Mode == PageMode.Add)
                {
                    realestate.RealEstatePhotos.First().IsDefault = true;
                }
            }
        }

        private void FillRealEstateCriteriaObject(RealEstate realestate)
        {
            RealEstateCriteria realEstateCriteria;
            int CriteriaId;
            TextBox txtvalue;
            CheckBox chkValue;
            HiddenField hdnValueType;
            if (realestate.RealEstateCriterias.Count > 0)
            {

                for (int i = 0; i < rptCrieria.Items.Count; i++)
                {
                    CriteriaId = Convert.ToInt32(rptCrieria.DataKeys[i].Value);

                    hdnValueType = (HiddenField)rptCrieria.Items[i].FindControl("hdnValueType");
                    realEstateCriteria = realestate.RealEstateCriterias.FirstOrDefault(RC => RC.RealEstateTypeCriteriaID == CriteriaId);
                    if (realEstateCriteria != null)
                    {
                        if (hdnValueType.Value == "bool")
                        {
                            chkValue = (CheckBox)rptCrieria.Items[i].FindControl("chkCriteria");
                            if (chkValue.Checked)
                            {
                                realEstateCriteria.Value = "true";
                            }
                            else
                            {
                                realEstateCriteria.Value = "false";
                                Controller.OnDeleteCriteria(realEstateCriteria);
                            }
                        }
                        else
                        {

                            txtvalue = (TextBox)rptCrieria.Items[i].FindControl("txtCriteriaValue");
                            realEstateCriteria.Value = txtvalue.Text;
                        }

                    }
                    else
                    {

                        if (hdnValueType.Value == "bool")
                        {
                            chkValue = (CheckBox)rptCrieria.Items[i].FindControl("chkCriteria");
                            realEstateCriteria = new RealEstateCriteria();
                            realEstateCriteria.RealEstateTypeCriteriaID = CriteriaId;
                            if (chkValue.Checked)
                            {
                                realEstateCriteria.Value = "true";
                                realestate.RealEstateCriterias.Add(realEstateCriteria);
                            }

                        }
                        else
                        {
                            txtvalue = (TextBox)rptCrieria.Items[i].FindControl("txtCriteriaValue");
                            if (txtvalue.Text != "")
                            {
                                realEstateCriteria = new RealEstateCriteria();
                                realEstateCriteria.RealEstateTypeCriteriaID = CriteriaId;
                                realEstateCriteria.Value = txtvalue.Text;
                                realestate.RealEstateCriterias.Add(realEstateCriteria);
                            }

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < rptCrieria.Items.Count; i++)
                {
                    CriteriaId = Convert.ToInt32(rptCrieria.DataKeys[i].Value);
                    hdnValueType = (HiddenField)rptCrieria.Items[i].FindControl("hdnValueType");
                    if (hdnValueType.Value == "bool")
                    {
                        chkValue = (CheckBox)rptCrieria.Items[i].FindControl("chkCriteria");
                        realEstateCriteria = new RealEstateCriteria();
                        realEstateCriteria.RealEstateTypeCriteriaID = CriteriaId;
                        if (chkValue.Checked)
                        {
                            realEstateCriteria.Value = "true";
                            realestate.RealEstateCriterias.Add(realEstateCriteria);
                        }


                        // realEstateCriteria.Value = txtvalue.Text;

                    }
                    else
                    {
                        txtvalue = (TextBox)rptCrieria.Items[i].FindControl("txtCriteriaValue");
                        if (txtvalue.Text != "")
                        {
                            realEstateCriteria = new RealEstateCriteria();
                            realEstateCriteria.RealEstateTypeCriteriaID = CriteriaId;
                            realEstateCriteria.Value = txtvalue.Text;
                            realestate.RealEstateCriterias.Add(realEstateCriteria);
                        }

                    }
                }

            }
        }

        public void FillRealEstateControls(BrokerDLL.RealEstate realestate)
        {
            if (realestate.IsSold.Value == true)
            {
                rptIsSold.Items[0].Selected = false;
                rptIsSold.Items[1].Selected = true;
            }
            txtArea.Text = realestate.Area.ToString();
            txtDescription.Text = realestate.Description;
            txtLatitude.Text = realestate.Latitude;
            txtLongitude.Text = realestate.Longitude;
            if (realestate.Price != 0 && realestate.Price != null)
            {
                txtPrice.Text = realestate.Price.ToString();
            }
            txtStreet.Text = realestate.Street;
            txtTitle.Text = realestate.Title;
            rptSaleTypes.SelectedValue = realestate.SaleTypeId.ToString();
            rplCategories.SelectedValue = realestate.RealEstateCategoryID.ToString();
            Controller.OnSelectCategory(realestate.RealEstateCategoryID.Value);
            rptStatus.SelectedValue = realestate.RealEstateStatusID.ToString();
            rplTypes.SelectedValue = realestate.RealEstateTypeID.ToString();
            Controller.OnSelectType(realestate.RealEstateTypeID.Value);
            if (realestate.CurrencyID != null && realestate.CurrencyID != 0)
            {
                rptCurrency.SelectedValue = realestate.CurrencyID.ToString();
            }
            if (realestate.CountryID != null && realestate.CountryID != 0)
            {
                ddlCountry.SelectedValue = realestate.CountryID.ToString();
                Controller.OnSelectCountry(realestate.CountryID.Value);
                ddlCities.SelectedValue = realestate.CityID.ToString();
                Controller.OnSelectCity(realestate.CityID.Value);
                ddlDistricts.SelectedValue = realestate.DistrictID.ToString();
            }
            if (realestate.PaymentTypeID != null && realestate.PaymentTypeID != 0)
            {
                rptPaymentTypes.SelectedValue = realestate.PaymentTypeID.ToString();
            }
            if(realestate.UseContactInfo.Value==false)
            {
                rptContactData.Items[0].Selected = false;
                rptContactData.Items[1].Selected = true;
                txtOwnerPhone.Text = realestate.OwnerMobile;
                txtOwnerName.Text = realestate.OwnerName;
                txtOwnerEmail.Text = realestate.OwnerEmail;
                divContactEmail.Attributes.Add("style", "display:block");
                divContactName.Attributes.Add("style", "display:block");
                divContactPhone.Attributes.Add("style", "display:block");
            }
            else
            {
                divContactEmail.Attributes.Add("style", "display:none");
                divContactName.Attributes.Add("style", "display:none");
                divContactPhone.Attributes.Add("style", "display:none");
            }

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

            //foreach (RealEstateKeyword keyword in realestate.RealEstateKeywords)
            //{
            //    txtKeywords.Entries.Add(new AutoCompleteBoxEntry(keyword.Keyword.Title, keyword.KeywordID.ToString()));
            //}
            BindPhotoList(realestate.RealEstatePhotos.ToList());
            RealEstateCriteria realestatecriteria;
            int CriteriaId;
            TextBox txtvalue;
            CheckBox chkvalue;
            if (realestate.RealEstateCriterias.Count > 0)
            {
                for (int i = 0; i < rptCrieria.Items.Count; i++)
                {

                    CriteriaId = Convert.ToInt32(rptCrieria.DataKeys[i].Value);
                    realestatecriteria = realestate.RealEstateCriterias.FirstOrDefault(RC => RC.RealEstateTypeCriteriaID == CriteriaId);
                    if (realestatecriteria != null)
                    {
                        if (realestatecriteria.RealEstateTypeCriteria.ValueType == "bool")
                        {
                            chkvalue = (CheckBox)rptCrieria.Items[i].FindControl("chkCriteria");
                            if (realestatecriteria.Value == "true")
                            {
                                chkvalue.Checked = true;
                            }
                        }
                        else
                        {
                            txtvalue = (TextBox)rptCrieria.Items[i].FindControl("txtCriteriaValue");
                            txtvalue.Text = realestatecriteria.Value;
                        }
                    }
                }
            }
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

        public void FillCategoryList(List<BrokerDLL.RealEstateCategory> Categories)
        {
            rplCategories.DataSource = Categories;
            rplCategories.DataTextField = "Title";
            rplCategories.DataValueField = "ID";
            rplCategories.DataBind();
        }

        public void FillTypeList(List<BrokerDLL.RealEstateType> Types)
        {
            rplTypes.DataSource = Types;
            rplTypes.DataTextField = "Title";
            rplTypes.DataValueField = "ID";
            rplTypes.DataBind();
        }

        public void FillStatusList(List<BrokerDLL.RealEstateStatus> Status)
        {
            rptStatus.DataSource = Status;
            rptStatus.DataTextField = "Title";
            rptStatus.DataValueField = "ID";
            rptStatus.DataBind();
        }

        public void FillPaymentList(List<BrokerDLL.PaymentType> PaymentTypess)
        {
            rptPaymentTypes.DataSource = PaymentTypess;
            rptPaymentTypes.DataTextField = "Title";
            rptPaymentTypes.DataValueField = "ID";
            rptPaymentTypes.DataBind();
        }

        public void FillCurrencyList(List<BrokerDLL.Currency> Currencies)
        {
            rptCurrency.DataSource = Currencies;
            rptCurrency.DataTextField = "Name";
            rptCurrency.DataValueField = "ID";
            rptCurrency.DataBind();
        }

        public void FillSaleTypeList(List<BrokerDLL.SaleType> SaleTypes)
        {
            rptSaleTypes.DataSource = SaleTypes;
            rptSaleTypes.DataTextField = "Title";
            rptSaleTypes.DataValueField = "ID";
            rptSaleTypes.DataBind();
        }

        public void FillKeywordList(List<BrokerDLL.Keyword> Keywords)
        {
            // throw new NotImplementedException();
        }

        public void FillRealEstateTypeCriteriaList(List<BrokerDLL.RealEstateTypeCriteria> TypeCriterias)
        {
            rptCrieria.DataSource = TypeCriterias;
            rptCrieria.DataBind();
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
                rptIsSold.Visible = false;
             //   lbtnSave.Text = "إضافة الوحدة";
            }
            else
            {
                lbtnSave.Text = "تعديل الوحدة";
                hTitle.InnerText = "تعديل الوحدة";
                rptIsSold.Visible = true;
                divTypes.Attributes.Add("style", "display:block");
                divStatus.Attributes.Add("style", "display:block");
                divHelpMsg1.Visible = false;
            }
        }

        public void BindPhotoList(List<BrokerDLL.RealEstatePhoto> Photos)
        {
            lvPhotos.DataSource = Photos;
            lvPhotos.DataBind();
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

        protected void rplCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (rplCategories.SelectedIndex != 0)
            //{
            Controller.OnSelectCategory(Convert.ToInt32(rplCategories.SelectedValue));
            divTypes.Attributes.Add("style", "display:block");
            divStatus.Attributes.Add("style", "display:block");
            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Myscript", "ShowHiddednDiv();", true);
            //}
            //else
            //{
            //    divTypes.Attributes.Add("style", "display:none");
            //    rplTypes.Items.Clear();
            //}
        }
        protected void rptCrieria_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            RealEstateTypeCriteria criteria = (RealEstateTypeCriteria)e.Item.DataItem;

            HtmlGenericControl divChec = (HtmlGenericControl)e.Item.FindControl("divCheckbox");
            HtmlGenericControl divText = (HtmlGenericControl)e.Item.FindControl("divText");
            if (criteria.ValueType == "bool")
            {
                divChec.Visible = true;
                divText.Visible = false;
            }
            else
            {
                divChec.Visible = false;
                divText.Visible = true;
                RegularExpressionValidator rev = (RegularExpressionValidator)e.Item.FindControl("revCriteriavalue");
                if (criteria.ValueType == "int")
                {
                    rev.ValidationExpression = @"\d*";
                    rev.ErrorMessage = Message.ValidateNumber.GetValue();
                }
                else
                {
                    rev.Visible = false;
                }
            }
        }

        protected void rplTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.OnSelectType(Convert.ToInt32(rplTypes.SelectedValue));
        }

        protected void lbtnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            ListViewDataItem item = (ListViewDataItem)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(lvPhotos.DataKeys[item.DisplayIndex].Value));
        }

        protected void imgSetDefault_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            ListViewDataItem item = (ListViewDataItem)ibtn.NamingContainer;
            Controller.OnSetDefault(Convert.ToInt32(lvPhotos.DataKeys[item.DisplayIndex].Value));
        }

        public void UploadRealEstatePhoto(int Code,string random)
        {
            if (ruPhoto.UploadedFiles.Count > 0)
            {
                for (int i = 0; i < ruPhoto.UploadedFiles.Count; i++)
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day);
                    }
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code);
                    }
                    string path = HttpContext.Current.Server.MapPath("~/Resources/RealEstates/") + "\\" + DateTime.Today.Year + "\\" + DateTime.Today.Month + "\\" + DateTime.Now.Day + "\\" + Code + "\\";
                    path += Code.ToString() + '-' + random + '_' + i + ruPhoto.UploadedFiles[i].GetExtension();
                    //  ruPhoto.UploadedFiles[0].SaveAs(path + Regex.Replace(Title, "[^0-9a-zA-Zء-ي]+", "-") + ruPhoto.UploadedFiles[0].GetExtension());
                    //ruPhoto.UploadedFiles[0].
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ruPhoto.UploadedFiles[i].InputStream);
                    ImageCompress.ApplyCompressionAndSave(img, path, 70, ruPhoto.UploadedFiles[0].ContentType);
                    //if (img.Width >= 2000)
                    //{

                    //    SavePhotoThump.SaveThumb(img, path, 30);
                    //}
                    //else
                    //{
                    //    if(img.Width>=1000)
                    //    {
                    //        SavePhotoThump.SaveThumb(img, path, 60);
                    //    }
                    //    else
                    //    {
                    //    if (img.Width >= 800)
                    //    {
                    //        SavePhotoThump.SaveThumb(img, path, 90);
                    //    }
                    //    else
                    //    {
                    //        SavePhotoThump.SaveThumb(img, path, 95);
                    //    }
                    //    }
                    //}
                }
            }
        }


        public string CheckDefault(object DefaultStatus)
        {
            string text = "";
            if ((bool)DefaultStatus)
            {
                text = "الصورة الرئيسية";
            }
            return text;
        }
    }
}