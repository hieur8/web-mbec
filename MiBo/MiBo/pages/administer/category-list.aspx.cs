using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.CategoryList;
using MiBo.Domain.Web.Admin.CategoryList;

namespace MiBo.pages.administer
{
    public partial class category_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptCategories.DataSource = response.ListCategories;
            rptCategories.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateRequestModel);
            if (HasError) return;
            Refresh();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                return requestModel;
            }
        }

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputCategoryModel category = null;
                var requestModel = new UpdateRequestModel();
                var listCategories = new List<OutputCategoryModel>();
                foreach (RepeaterItem row in rptCategories.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    category = new OutputCategoryModel();
                    category.CategoryCd = ((HiddenField)row.FindControl("hidCategoryCd")).Value;
                    category.CategoryName = ((TextBox)row.FindControl("txtCategoryName")).Text;
                    category.CategorySearchName = ((HiddenField)row.FindControl("hidCategorySearchName")).Value;
                    category.CategoryDiv = ((DropDownList)row.FindControl("ddlCategoryDiv")).SelectedValue;
                    category.SortKey = ((TextBox)row.FindControl("txtSortKey")).Text;
                    category.DeleteFlag = ((DropDownList)row.FindControl("ddlDeleteFlag")).SelectedValue;
                    listCategories.Add(category);
                }
                requestModel.ListCategories = listCategories;
                return requestModel;
            }
        }
    }
}