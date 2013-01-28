using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Master;
using MiBo.Domain.Web.Client.Master;

namespace MiBo.pages.common
{
    public partial class client : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);

            rptCategoryMenu.DataSource = response.ListCategories;
            rptCategoryMenu.DataBind();
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