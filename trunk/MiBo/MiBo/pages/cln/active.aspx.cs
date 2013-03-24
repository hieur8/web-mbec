using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Active;
using MiBo.Domain.Web.Client.Active;

namespace MiBo.pages.cln
{
    public partial class active : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
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