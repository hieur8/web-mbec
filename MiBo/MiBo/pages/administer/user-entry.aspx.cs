using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.UserEntry;
using MiBo.Domain.Web.Admin.UserEntry;

namespace MiBo.pages.administer
{
    public partial class user_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwUserDatails.DataSource = response.Details;
            fvwUserDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_USER_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_USER_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                if (Session["Status"] == null)
                    Session["Status"] = Logics.CODE_STATUS_ADD;
                request.Status = Convert.ToString(Session["Status"]);
                request.UserCd = Convert.ToString(Session["UserCd2"]);
                Session["Status"] = null;
                Session["UserCd2"] = null;
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Status = ((HiddenField)fvwUserDatails.FindControl("hidStatus")).Value;
                request.UserCd = ((HiddenField)fvwUserDatails.FindControl("hidUserCd")).Value;
                request.Email = ((TextBox)fvwUserDatails.FindControl("txtEmail")).Text;
                request.FullName = ((TextBox)fvwUserDatails.FindControl("txtFullName")).Text;
                request.Phone1 = ((TextBox)fvwUserDatails.FindControl("txtPhone1")).Text;
                request.Phone2 = ((TextBox)fvwUserDatails.FindControl("txtPhone2")).Text;
                request.Address = ((TextBox)fvwUserDatails.FindControl("txtAddress")).Text;
                request.GroupCd = ((DropDownList)fvwUserDatails.FindControl("ddlGroup")).SelectedValue;
                request.CityCd = ((DropDownList)fvwUserDatails.FindControl("ddlCity")).SelectedValue;
                request.DeleteFlag = ((DropDownList)fvwUserDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}