using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.ItemList;
using MiBo.Domain.Web.Admin.ItemList;

namespace MiBo.pages.administer
{
    public partial class item_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptItems.DataSource = response.ListItems;
            rptItems.DataBind();
            ddlCategory.DataSource = response.ListCategory;
            ddlCategory.DataBind();
            ddlCategory.SelectedValue = response.CategoryCd;
            ddlAge.DataSource = response.ListAge;
            ddlAge.DataBind();
            ddlAge.SelectedValue = response.AgeCd;
            ddlGender.DataSource = response.ListGender;
            ddlGender.DataBind();
            ddlGender.SelectedValue = response.GenderCd;
            ddlBrand.DataSource = response.ListBrand;
            ddlBrand.DataBind();
            ddlBrand.SelectedValue = response.BrandCd;
            ddlCountry.DataSource = response.ListCountry;
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = response.CountryCd;
            ddlUnit.DataSource = response.ListUnit;
            ddlUnit.DataBind();
            ddlUnit.SelectedValue = response.UnitCd;
            ddlItemDiv.DataSource = response.ListItemDiv;
            ddlItemDiv.DataBind();
            ddlItemDiv.SelectedValue = response.ItemDiv;
            ddlDeleteFlag.DataSource = response.ListDeleteFlag;
            ddlDeleteFlag.DataBind();
            ddlDeleteFlag.SelectedValue = response.DeleteFlag;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptItems.DataSource = response.ListItems;
            rptItems.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = e.CommandName;
            Session["ItemCd"] = e.CommandArgument;
            Redirect(Pages.ADMIN_ITEM_ENTRY);
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
                request.ItemCd = txtItemCd.Text;
                request.ItemName = txtItemName.Text;
                request.CategoryCd = ddlCategory.SelectedValue;
                request.AgeCd = ddlAge.SelectedValue;
                request.GenderCd = ddlGender.SelectedValue;
                request.BrandCd = ddlBrand.SelectedValue;
                request.CountryCd = ddlCountry.SelectedValue;
                request.UnitCd = ddlUnit.SelectedValue;
                request.ItemDiv = ddlItemDiv.SelectedValue;
                request.DeleteFlag = ddlDeleteFlag.SelectedValue;
                return request;
            }
        }
    }
}