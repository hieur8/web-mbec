﻿using System;
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

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.HasChangePassword = Request["edit"] == "pass" ? bool.TrueString : bool.FalseString;
                return request;
            }
        }
    }
}