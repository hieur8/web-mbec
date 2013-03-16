using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.UserChangePassword;
using MiBo.Domain.Web.Admin.UserChangePassword;

namespace MiBo.pages.administer
{
    public partial class user_change_password : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var saveLogic = new SaveOperateLogic();
            var responseModel = Invoke(saveLogic, SaveRequestModel);
            if (responseModel == null) Redirect(Pages.ADMIN_USER_CHANGE_PASSWORD);
            else Redirect(Pages.ADMIN_INDEX);
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var requestModel = new SaveRequestModel();
                requestModel.Password = txtPassword.Text;
                requestModel.NewPassword = txtNewPassword.Text;
                requestModel.NewPasswordConfirm = txtNewPasswordConfirm.Text;
                return requestModel;
            }
        }
    }
}