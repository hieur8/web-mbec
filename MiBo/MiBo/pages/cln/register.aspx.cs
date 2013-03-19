﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Logic.Client.Register;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Web.Client.Register;
using MiBo.Domain.Common.Constants;

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
                Response.Redirect(Pages.CLIENT_LOGIN);
            }

        }
        private RegisterRequestModel RegisterRequestModel
        {
            get
            {
                var request = new RegisterRequestModel();
                request.email = email.Text.Trim().ToString();
                request.pass = pass.Text.ToString();
                request.fullname = fullName.Text.Trim() + " " + fullName2.Text.Trim();
                return request;
            }
        }
    }
}