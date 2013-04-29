using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GroupRoleList;
using MiBo.Domain.Web.Admin.GroupRoleList;

namespace MiBo.pages.administer
{
    public partial class group_role_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptGroupRoles.DataSource = response.ListGroupRoles;
            rptGroupRoles.DataBind();
            hidGroupCd.Value = response.GroupCd;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_GROUP_LIST);
        }

        protected void btnAddRole_Command(object sender, CommandEventArgs e)
        {
            Session["GroupCd"] = hidGroupCd.Value;
            Response.Redirect(Pages.ADMIN_GROUP_ROLE_ENTRY);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                requestModel.GroupCd = Convert.ToString(Session["GroupCd"]);
                return requestModel;
            }
        }

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputGroupRoleModel groupRole = null;
                var requestModel = new UpdateRequestModel();
                var listGroupRoles = new List<OutputGroupRoleModel>();
                foreach (RepeaterItem row in rptGroupRoles.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    groupRole = new OutputGroupRoleModel();
                    groupRole.GroupCd = ((HiddenField)row.FindControl("hidGroupCd")).Value;
                    groupRole.RoleCd = ((HiddenField)row.FindControl("hidRoleCd")).Value;
                    groupRole.DeleteFlag = ((DropDownList)row.FindControl("ddlDeleteFlag")).SelectedValue;
                    listGroupRoles.Add(groupRole);
                }
                requestModel.ListGroupRoles = listGroupRoles;
                return requestModel;
            }
        }
    }
}