using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.BannerList;
using MiBo.Domain.Web.Admin.BannerList;

namespace MiBo.pages.administer
{
    public partial class banner_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptBanners.DataSource = response.ListBanners;
            rptBanners.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = e.CommandName;
            Session["BannerCd"] = e.CommandArgument;
            Redirect(Pages.ADMIN_BANNER_ENTRY);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                return requestModel;
            }
        }
    }
}