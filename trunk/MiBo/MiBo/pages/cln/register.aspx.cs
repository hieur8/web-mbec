using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Logic.Client.Register;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Web.Client.Register;

namespace MiBo.pages.cln
{
    public partial class register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var logic = new RegisterOperateLogic();
            var response = Invoke(logic, RegisterRequestModel);
            if (response != null)
            {
                Response.Redirect("login.aspx");
            }

        }
        private RegisterRequestModel RegisterRequestModel
        {
            get
            {
                var request = new RegisterRequestModel();
                request.email = email.Text.Trim().ToString();
                request.pass = pass.Text.ToString();
                request.isSendEmail = true;
                if (is_subscribed.Checked)
                {
                    request.isSendEmail = false;
                }
                return request;
            }
        }
    }
}