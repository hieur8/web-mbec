using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Active;
using MiBo.Domain.Web.Client.Active;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.cln
{
    public partial class active : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request["pid"])) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            Redirect(Pages.CLIENT_LOGIN);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.UserCd = Request["pid"];
                return request;
            }
        }
    }
}