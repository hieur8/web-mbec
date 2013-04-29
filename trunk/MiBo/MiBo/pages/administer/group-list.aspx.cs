using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GroupList;
using MiBo.Domain.Web.Admin.GroupList;

namespace MiBo.pages.administer
{
    public partial class group_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptGroups.DataSource = response.ListGroups;
            rptGroups.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["GroupCd"] = e.CommandArgument;
            if (e.CommandName == "list")
                Redirect(Pages.ADMIN_GROUP_ROLE_LIST);
            else Redirect(Pages.ADMIN_GROUP_ROLE_ENTRY);
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
                OutputGroupModel group = null;
                var requestModel = new UpdateRequestModel();
                var listGroups = new List<OutputGroupModel>();
                foreach (RepeaterItem row in rptGroups.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    group = new OutputGroupModel();
                    group.GroupCd = ((HiddenField)row.FindControl("hidGroupCd")).Value;
                    group.GroupName = ((TextBox)row.FindControl("txtGroupName")).Text;
                    group.SortKey = ((TextBox)row.FindControl("txtSortKey")).Text;
                    group.DeleteFlag = ((DropDownList)row.FindControl("ddlDeleteFlag")).SelectedValue;
                    listGroups.Add(group);
                }
                requestModel.ListGroups = listGroups;
                return requestModel;
            }
        }
    }
}