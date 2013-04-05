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
            fvwItemDatails.DataSource = response.Details;
            fvwItemDatails.DataBind();
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
                request.CategoryCd = ((TextBox)fvwItemDatails.FindControl("txtCategoryCd")).Text;
                request.CategoryName = ((TextBox)fvwItemDatails.FindControl("txtCategoryName")).Text;
                request.CategoryDiv = ((DropDownList)fvwItemDatails.FindControl("ddlCategoryDiv")).SelectedValue;
                request.SortKey = ((TextBox)fvwItemDatails.FindControl("txtSortKey")).Text;
                request.DeleteFlag = ((DropDownList)fvwItemDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}