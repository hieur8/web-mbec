using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GroupRoleEntry;
using MiBo.Domain.Web.Admin.GroupRoleEntry;

namespace MiBo.pages.administer
{
    public partial class group_role_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwGroupRoleDatails.DataSource = response.Details;
            fvwGroupRoleDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["GroupCd"] = response.GroupCd;
            Response.Redirect(Pages.ADMIN_GROUP_ROLE_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["GroupCd"] = ((TextBox)fvwGroupRoleDatails.FindControl("txtGroupCd")).Text;
            Response.Redirect(Pages.ADMIN_GROUP_ROLE_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.GroupCd = Convert.ToString(Session["GroupCd"]);
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.GroupCd = ((HiddenField)fvwGroupRoleDatails.FindControl("hidGroupCd")).Value;
                request.RoleCd = ((DropDownList)fvwGroupRoleDatails.FindControl("ddlRole")).SelectedValue;
                request.DeleteFlag = ((DropDownList)fvwGroupRoleDatails.FindControl("ddlDeleteFlag")).SelectedValue;
                return request;
            }
        }
    }
}