using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Login;
using MiBo.Domain.Web.Client.Login;

namespace MiBo.pages.cln
{
    public partial class login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            var logic = new LoginOperateLogic();
            var response = Invoke(logic, LoginRequestModel);
            if (response.StatusFlag == false)
            {
                lbMsg.Text = "Tài khoản hoặc mật khẩu không đúng !";
            }
            else
            {
                Session["UserName"] = response.UserName;
                lbMsg.Text = "Đăng nhập thành công";
            }

        }
        private LoginRequestModel LoginRequestModel
        {
            get
            {
                var request = new LoginRequestModel();
                request.UserName = txtUserName.Text.ToString().Trim();
                request.Password = txtPass.Text.ToString();
                return request;
            }
        }
    }
}