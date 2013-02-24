using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Profile;
using MiBo.Domain.Web.Client.Profile;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.cln
{
    public partial class profile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                return request;
            }
        }
    }
}