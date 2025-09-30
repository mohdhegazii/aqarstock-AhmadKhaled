using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BrokerDLL.Backend.Views;
using BrokerDLL.Backend.Controllers;
using BrokerDLL;

namespace BrokerWeb.Backend.SubScriber.UserControls
{
    public partial class ucProjectVedio : System.Web.UI.UserControl,IProjectVedio
    {
        ProjectVedioController Controller;
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller = new ProjectVedioController(this);
            if (!IsPostBack)
            {
                Controller.OnViewInitialize();
            }
        }

        protected void gvVedios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVedios.PageIndex = e.NewPageIndex;
            gvVedios.DataSource = Controller.OnNeedDataSource();
            gvVedios.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Controller.OnSave();
        }

        protected void ibtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnDelete(Convert.ToInt32(gvVedios.DataKeys[item.RowIndex].Value));
        }

        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton ibtn = (ImageButton)sender;
            GridViewRow item = (GridViewRow)ibtn.NamingContainer;
            Controller.OnEdit(Convert.ToInt32(gvVedios.DataKeys[item.RowIndex].Value));
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

        public int VideoID
        {
            get
            {
                if (ViewState["VideoID"] != null)
                {
                    return (int)ViewState["VideoID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["VideoID"] = value;
            }
        }

        public void BindList(List<BrokerDLL.RealEstateProjectVideo> Videos)
        {
            gvVedios.DataSource = Videos;
            gvVedios.DataBind();
        }

        public BrokerDLL.RealEstateProjectVideo FillObject(BrokerDLL.RealEstateProjectVideo Vedio)
        {
           Vedio.EmedCode = txtEmbedCode.Text;
            Vedio.TiTle = txtTitle.Text;
            Vedio.URL = txtURL.Text;

            return Vedio;
        }

        public void FillControls(BrokerDLL.RealEstateProjectVideo Vedio)
        {
            txtURL.Text = Vedio.URL;
            txtTitle.Text = Vedio.TiTle;
           txtEmbedCode.Text = Vedio.EmedCode;
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
                txtEmbedCode.Text = "";
                txtTitle.Text = "";
                txtURL.Text = "";
            }
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            if (Mode != PageMode.Add)
            {
                Mode = PageMode.Add;
                Navigate();
            }
        }
    }
}