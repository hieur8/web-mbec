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


namespace MiBo.pages.cln
{
    public partial class confirmcheckout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            if (method1.Checked == false || method2.Checked == false)
            {
                Label1.Text = "Xin vui lòng chọn cách mua hàng";
            }

            if (method1.Checked)
            {
                Session["payMethod"] = "0";
                Response.Redirect(Pages.CLIENT_CHECKOUT);
            }

            if (method2.Checked)
            {
                Session["paying"] = "1";
                Response.Redirect(Pages.CLIENT_REGISTER);
            }
            if (method3.Checked)
            {
                Session["paying"] = "1";
                Response.Redirect(Pages.CLIENT_LOGIN);
            }
        }
    }
}