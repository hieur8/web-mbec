using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.UserList;
using MiBo.Domain.Web.Admin.UserList;

namespace MiBo.pages.administer
{
    public partial class user_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptUsers.DataSource = response.ListUsers;
            rptUsers.DataBind();
            ddlCity.DataSource = response.ListCity;
            ddlCity.DataBind();
            ddlCity.SelectedValue = response.CityCd;
            ddlDeleteFlag.DataSource = response.ListDeleteFlag;
            ddlDeleteFlag.DataBind();
            ddlDeleteFlag.SelectedValue = response.DeleteFlag;
            ddlGroup.DataSource = response.ListGroup;
            ddlGroup.DataBind();
            ddlGroup.SelectedValue = response.GroupCd;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptUsers.DataSource = response.ListUsers;
            rptUsers.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = e.CommandName;
            Session["UserCd2"] = e.CommandArgument;
            Redirect(Pages.ADMIN_USER_ENTRY);
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
                request.Email = txtEmail.Text;
                request.FullName = txtFullName.Text;
                request.CityCd = ddlCity.SelectedValue;
                request.GroupCd = ddlGroup.SelectedValue;
                request.DeleteFlag = ddlDeleteFlag.SelectedValue;
                return request;
            }
        }
    }
}