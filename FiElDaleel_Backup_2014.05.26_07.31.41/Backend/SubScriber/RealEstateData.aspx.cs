using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

namespace BrokerWeb.Backend.SubScriber
{
    public partial class RealEstateData : System.Web.UI.Page, IRealEstateData
    {
        RealEstateDataController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new RealEstateDataController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
            else
            {
                Controller.OnPostBack();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex != 0)
            {
                Controller.OnSelectCategory(Convert.ToInt32(ddlCategory.SelectedValue));
            }
            else
            {
                ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
                ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
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

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex > 0)
            {
                Controller.OnSelectType(Convert.ToInt32(ddlType.SelectedValue));
            }
            else
            {
                rptCrieria.DataSource = null;
                rptCrieria.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
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

        public BrokerDLL.RealEstate FillRealEstateObject()
        {
            RealEstate realestate;
            if (Mode == PageMode.Add)
            {
                realestate = new RealEstate();
                realestate.ActiveStatusId = (int)Activestatus.New;
                realestate.CreatedDate = DateTime.Now;
            }
            else
            {
                realestate = Controller.OnGet();
            }
            if (txtArea.Text != null && txtArea.Text != "")
            {
                realestate.Area = Convert.ToDouble(txtArea.Text);
            }
            if (ddlCity.SelectedIndex > 0)
            {
                realestate.CityID = Convert.ToInt32(ddlCity.SelectedValue);
            }
            if (ddlCountries.SelectedIndex > 0)
            {
                realestate.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
            }
            if (ddlCurrency.SelectedIndex > 0)
            {
                realestate.CurrencyID = Convert.ToInt32(ddlCurrency.SelectedValue);
            }
            realestate.Description = txtDescription.Text;
            if (ddlDistrict.SelectedIndex > 0)
            {
                realestate.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
            }
            realestate.IsSold = chkIsSold.Checked;
            realestate.Latitude = txtLatitude.Text;
            realestate.Longitude = txtLongitude.Text;
            realestate.UseContactInfo = chkContactData.Checked;
            if (chkContactData.Checked == false)
            {
                realestate.OwnerEmail = txtOwnerEmail.Text;
                realestate.OwnerMobile = txtOwnerPhone.Text;
                realestate.OwnerName = txtOwnerName.Text;
            }
            if (ddlPaymentType.SelectedIndex > 0)
            {
                realestate.PaymentTypeID = Convert.ToInt32(ddlPaymentType.SelectedValue);
            }
            if (txtPrice.Text != null && txtPrice.Text != "")
            {
                realestate.Price = Convert.ToDouble(txtPrice.Text);
            }
            realestate.RealEstateCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            realestate.RealEstateStatusID = Convert.ToInt32(ddlStatus.SelectedValue);
            realestate.RealEstateTypeID = Convert.ToInt32(ddlType.SelectedValue);
            realestate.SaleTypeId = Convert.ToInt32(rbsSalesTypes.SelectedValue);
            realestate.Street = txtStreet.Text;
            realestate.SubscriberID = Commons.Subsciber.ID;
            realestate.Title = txtTitle.Text;
     


            FillRealEstateKeywordObject(realestate);
            FillRealEstateCriteriaObject(realestate);

            return realestate;
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
                        }
                        else
                        {
                            realEstateCriteria.Value = "false";
                        }

                        // realEstateCriteria.Value = txtvalue.Text;
                        realestate.RealEstateCriterias.Add(realEstateCriteria);
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

        private void FillRealEstateKeywordObject(RealEstate realestate)
        {
            RealEstateKeyword realestateKeyword;
            foreach (AutoCompleteBoxEntry keyword in txtKeywords.Entries)
            {
                if (keyword.Value != "" && keyword.Value != null)
                {
                    realestateKeyword = realestate.RealEstateKeywords.FirstOrDefault(RK => RK.KeywordID == Convert.ToInt32(keyword.Value));
                    if (realestateKeyword == null)
                    {
                        realestateKeyword = new RealEstateKeyword();
                        realestateKeyword.KeywordID = Convert.ToInt32(keyword.Value);
                        realestate.RealEstateKeywords.Add(realestateKeyword);
                    }
                }
                else
                {
                    realestateKeyword = new RealEstateKeyword();
                    realestateKeyword.KeywordID = Commons.SaveKeyword(keyword.Text);
                    realestate.RealEstateKeywords.Add(realestateKeyword);
                }

            }
        }

        public void FillRealEstateControls(BrokerDLL.RealEstate realestate)
        {
            chkIsSold.Checked = realestate.IsSold.Value;
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
            rbsSalesTypes.SelectedValue = realestate.SaleTypeId.ToString();
            ddlCategory.SelectedValue = realestate.RealEstateCategoryID.ToString();
            Controller.OnSelectCategory(realestate.RealEstateCategoryID.Value);
            ddlStatus.SelectedValue = realestate.RealEstateStatusID.ToString();
            ddlType.SelectedValue = realestate.RealEstateTypeID.ToString();
            Controller.OnSelectType(realestate.RealEstateTypeID.Value);
            if (realestate.CurrencyID != null && realestate.CurrencyID != 0)
            {
                ddlCurrency.SelectedValue = realestate.CurrencyID.ToString();
            }
            if (realestate.CountryID != null && realestate.CountryID != 0)
            {
                ddlCountries.SelectedValue = realestate.CountryID.ToString();
                Controller.OnSelectCountry(realestate.CountryID.Value);
                ddlCity.SelectedValue = realestate.CityID.ToString();
                Controller.OnSelectCity(realestate.CityID.Value);
                ddlDistrict.SelectedValue = realestate.DistrictID.ToString();
            }
            if (realestate.PaymentTypeID != null && realestate.PaymentTypeID != 0)
            {
                ddlPaymentType.SelectedValue = realestate.PaymentTypeID.ToString();
            }
            chkContactData.Checked = realestate.UseContactInfo.Value;
            if (realestate.UseContactInfo == false)
            {
                txtOwnerPhone.Text = realestate.OwnerMobile;
                txtOwnerName.Text = realestate.OwnerName;
                txtOwnerEmail.Text = realestate.OwnerEmail;
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

            foreach (RealEstateKeyword keyword in realestate.RealEstateKeywords)
            {
                txtKeywords.Entries.Add(new AutoCompleteBoxEntry(keyword.Keyword.Title, keyword.KeywordID.ToString()));
            }

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

        public void FillCategoryList(List<BrokerDLL.RealEstateCategory> Categories)
        {
            ddlCategory.DataSource = Categories;
            ddlCategory.DataTextField = "Title";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
            ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillTypeList(List<BrokerDLL.RealEstateType> Types)
        {
            ddlType.DataSource = Types;
            ddlType.DataTextField = "Title";
            ddlType.DataValueField = "ID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillStatusList(List<BrokerDLL.RealEstateStatus> Status)
        {
            ddlStatus.DataSource = Status;
            ddlStatus.DataTextField = "Title";
            ddlStatus.DataValueField = "ID";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillPaymentList(List<PaymentType> PaymentTypess)
        {
            ddlPaymentType.DataSource = PaymentTypess;
            ddlPaymentType.DataTextField = "Title";
            ddlPaymentType.DataValueField = "ID";
            ddlPaymentType.DataBind();
            ddlPaymentType.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillCurrencyList(List<Currency> Currencies)
        {
            ddlCurrency.DataSource = Currencies;
            ddlCurrency.DataTextField = "Name";
            ddlCurrency.DataValueField = "ID";
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, new ListItem("--اختار--", "0"));
        }

        public void FillSaleTypeList(List<SaleType> SaleTypes)
        {
            rbsSalesTypes.DataSource = SaleTypes;
            rbsSalesTypes.DataTextField = "Title";
            rbsSalesTypes.DataValueField = "ID";
            rbsSalesTypes.DataBind();

        }


        public void FillRealEstateTypeCriteriaList(List<RealEstateTypeCriteria> TypeCriterias)
        {
            rptCrieria.DataSource = TypeCriterias;
            rptCrieria.DataBind();
        }
        public void FillKeywordList(List<BrokerDLL.Keyword> Keywords)
        {
            txtKeywords.DataSource = Keywords;
            txtKeywords.DataTextField = "Title";
            txtKeywords.DataValueField = "ID";
            txtKeywords.DataBind();
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
                //txtOwnerEmail.Text = Commons.Subsciber.Email;
                //txtOwnerName.Text = Commons.Subsciber.FullName;
                //txtOwnerPhone.Text = Commons.Subsciber.MobileNo;
                rtsAddRealEstate.Tabs.ToList().ForEach(T => T.Enabled = false);
                rtsAddRealEstate.Tabs[0].Enabled = true;
            }
            else
            {
                rtsAddRealEstate.Tabs.ToList().ForEach(T => T.Enabled = true);
                ucRealEstatePhotos1.RealEstateID = RealEstateID;
            }
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

        protected void rtsAddRealEstate_TabClick(object sender, RadTabStripEventArgs e)
        {
            if (rtsAddRealEstate.SelectedIndex == 4)
            {
                Response.RedirectToRoute("ViewRealEstate", new { RealEstateID = RealEstateID });
            }
            divMsg.Attributes.Remove("Class");
            lblMsg.Text = "";
        }




    }
}