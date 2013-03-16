using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.UserLogin;
using MiBo.Domain.Web.Admin.UserLogin;

namespace MiBo.pages.administer
{
    public partial class user_login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private AuthRequestModel AuthRequestModel
        {
            get
            {
                var requestModel = new AuthRequestModel();
                requestModel.UserName = txtUserName.Text;
                requestModel.Password = txtPassword.Text;
                return requestModel;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var authLogic = new AuthOperateLogic();
            var responseModel = Invoke(authLogic, AuthRequestModel);
            if (HasError) Redirect(Pages.ADMIN_USER_LOGIN);
            else
            {
                Session["userCd"] = responseModel.UserCd;
                Session["userName"] = responseModel.UserName;
                RedirectWithReturnUrl(Pages.ADMIN_INDEX);
            }
        }
    }
}