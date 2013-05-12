using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.BannerEntry;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Web.Admin.BannerEntry;

namespace MiBo.pages.administer
{
    public partial class banner_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwBannerDatails.DataSource = response.Details;
            fvwBannerDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_BANNER_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_BANNER_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                if (Session["Status"] == null)
                    Session["Status"] = Logics.CODE_STATUS_ADD;
                request.Status = Convert.ToString(Session["Status"]);
                request.BannerCd = Convert.ToString(Session["BannerCd"]);
                Session["Status"] = null;
                Session["BannerCd"] = null;
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Status = ((HiddenField)fvwBannerDatails.FindControl("hidStatus")).Value;
                request.FileId = ((HiddenField)fvwBannerDatails.FindControl("hidFileId")).Value;
                request.BannerCd = ((TextBox)fvwBannerDatails.FindControl("txtBannerCd")).Text;
                request.BannerName = ((TextBox)fvwBannerDatails.FindControl("txtBannerName")).Text;
                request.SortKey = ((TextBox)fvwBannerDatails.FindControl("txtSortKey")).Text;
                request.Notes = ((TextBox)fvwBannerDatails.FindControl("txtContents")).Text;
                request.DeleteFlag = ((DropDownList)fvwBannerDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}