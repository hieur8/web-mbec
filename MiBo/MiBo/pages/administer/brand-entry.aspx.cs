using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.BrandEntry;
using MiBo.Domain.Web.Admin.BrandEntry;

namespace MiBo.pages.administer
{
    public partial class brand_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwBrandDatails.DataSource = response.Details;
            fvwBrandDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_BRAND_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_BRAND_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                if (Session["Status"] == null)
                    Session["Status"] = Logics.CODE_STATUS_ADD;
                request.Status = Convert.ToString(Session["Status"]);
                request.BrandCd = Convert.ToString(Session["BrandCd"]);
                Session["Status"] = null;
                Session["BrandCd"] = null;
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Status = ((HiddenField)fvwBrandDatails.FindControl("hidStatus")).Value;
                request.FileId = ((HiddenField)fvwBrandDatails.FindControl("hidFileId")).Value;
                request.BrandSearchName = ((HiddenField)fvwBrandDatails.FindControl("hidBrandSearchName")).Value;
                request.BrandCd = ((TextBox)fvwBrandDatails.FindControl("txtBrandCd")).Text;
                request.BrandName = ((TextBox)fvwBrandDatails.FindControl("txtBrandName")).Text;
                request.SortKey = ((TextBox)fvwBrandDatails.FindControl("txtSortKey")).Text;
                request.Notes = ((TextBox)fvwBrandDatails.FindControl("txtContents")).Text;
                request.DeleteFlag = ((DropDownList)fvwBrandDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}