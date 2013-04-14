using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.BrandList;
using MiBo.Domain.Web.Admin.BrandList;

namespace MiBo.pages.administer
{
    public partial class brand_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptBrands.DataSource = response.ListBrands;
            rptBrands.DataBind();
            ddlDeleteFlag.DataSource = response.ListDeleteFlag;
            ddlDeleteFlag.DataBind();
            ddlDeleteFlag.SelectedValue = response.DeleteFlag;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptBrands.DataSource = response.ListBrands;
            rptBrands.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = e.CommandName;
            Session["BrandCd"] = e.CommandArgument;
            Redirect(Pages.ADMIN_BRAND_ENTRY);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                return requestModel;
            }
        }
        private FilterRequestModel FilterRequestModel
        {
            get
            {
                var request = new FilterRequestModel();
                request.BrandCd = txtBrandCd.Text;
                request.BrandName = txtBrandName.Text;
                request.DeleteFlag = ddlDeleteFlag.SelectedValue;
                return request;
            }
        }
    }
}