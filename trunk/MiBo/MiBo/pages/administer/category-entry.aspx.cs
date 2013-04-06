using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.CategoryEntry;
using MiBo.Domain.Web.Admin.CategoryEntry;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.administer
{
    public partial class category_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            fvwCategoryDatails.DataSource = response.Details;
            fvwCategoryDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Response.Redirect(Pages.ADMIN_CATEGORY_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_CATEGORY_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.CategoryCd = ((TextBox)fvwCategoryDatails.FindControl("txtCategoryCd")).Text;
                request.CategoryName = ((TextBox)fvwCategoryDatails.FindControl("txtCategoryName")).Text;
                request.CategorySearchName = ((HiddenField)fvwCategoryDatails.FindControl("hidCategorySearchName")).Value;
                request.CategoryDiv = ((DropDownList)fvwCategoryDatails.FindControl("ddlCategoryDiv")).SelectedValue;
                request.SortKey = ((TextBox)fvwCategoryDatails.FindControl("txtSortKey")).Text;
                request.DeleteFlag = ((DropDownList)fvwCategoryDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}