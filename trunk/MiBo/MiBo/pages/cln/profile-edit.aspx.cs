using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Profile;
using MiBo.Domain.Web.Client.Profile;

namespace MiBo.pages.cln
{
    public partial class profile_edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) Redirect(Pages.CLIENT_LOGIN);
            fvwProfile.DataSource = response.Details;
            fvwProfile.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var saveLogic = new SaveOperateLogic();
            var responseModel = Invoke(saveLogic, SaveRequestModel);
            if (HasError) return;
            Redirect(Pages.CLIENT_INDEX);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.HasChangePassword = Request["edit"] == "pass";
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var requestModel = new SaveRequestModel();
                requestModel.FullName = ((TextBox)fvwProfile.FindControl("txtFullName")).Text;
                requestModel.HasNewsletter = ((CheckBox)fvwProfile.FindControl("chkHasNewsletter")).Checked;
                requestModel.HasChangePassword = ((CheckBox)fvwProfile.FindControl("chkHasChagngePassword")).Checked;
                requestModel.Password = ((TextBox)fvwProfile.FindControl("txtPassword")).Text;
                requestModel.NewPassword = ((TextBox)fvwProfile.FindControl("txtNewPassword")).Text;
                requestModel.NewPasswordConf = ((TextBox)fvwProfile.FindControl("txtNewPasswordConf")).Text;
                return requestModel;
            }
        }
    }
}