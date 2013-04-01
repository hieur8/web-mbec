using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Login;
using MiBo.Domain.Web.Client.Login;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;

namespace MiBo.pages.cln
{
    public partial class login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PageHelper.HasAuthenticated){
                Response.Redirect(Pages.CLIENT_INDEX);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var logic = new LoginOperateLogic();
            var response = Invoke(logic, LoginRequestModel);
            if (response != null)
            {
                Session["userCd"] = response.UserCd;
                Session["userName"] = response.UserName;
                if (Session["paying"] == null)
                {
                    Response.Redirect(Pages.CLIENT_INDEX);
                }
                else
                {
                    Session["payMethod"] = "1";
                    Response.Redirect(Pages.CLIENT_CHECKOUT);
                }
            }

        }
        private LoginRequestModel LoginRequestModel
        {
            get
            {
                var request = new LoginRequestModel();
                request.UserName = username.Text.ToString().Trim();
                request.Password = pass.Text.ToString();
                return request;
            }
        }

    }
}