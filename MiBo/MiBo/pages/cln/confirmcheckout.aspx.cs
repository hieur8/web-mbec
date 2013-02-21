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
    public partial class confirmcheckout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
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
                Session["userCd"] = response.UserCd;
                Session["userName"] = response.UserName;
                Session["payMethod"] = "1";
                Response.Redirect("checkout.aspx");
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
        protected void Button2_Click1(object sender, EventArgs e)
        {

            if (method1.Checked == false || method2.Checked == false)
            {
                Label1.Text = "Xin vui lòng chọn cách mua hàng";
            }

            if (method1.Checked)
            {
                Session["payMethod"] = "0";
                Response.Redirect("checkout.aspx");
            }

            if (method2.Checked)
            {
                Session["paying"] = "1";
                Response.Redirect("register.aspx");
            }
        }
    }
}