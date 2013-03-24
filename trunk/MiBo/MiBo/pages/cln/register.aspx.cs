using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Register;
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
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Response.Redirect(Pages.CLIENT_LOGIN);
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Email = email.Text.Trim().ToString();
                request.Password = pass.Text.ToString();
                request.Fullname = fullName.Text.Trim() + " " + fullName2.Text.Trim();
                return request;
            }
        }
    }
}