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
            ddlCategory.Items.AddRange(response.ListCategory);
            ddlAge.Items.AddRange(response.ListAge);
            ddlGender.Items.AddRange(response.ListGender);
            ddlBrand.Items.AddRange(response.ListBrand);
            ddlCountry.Items.AddRange(response.ListCountry);
            ddlUnit.Items.AddRange(response.ListUnit);
            ddlItemDiv.Items.AddRange(response.ListItemDiv);
            ddlDeleteFlag.Items.AddRange(response.ListDeleteFlag);
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