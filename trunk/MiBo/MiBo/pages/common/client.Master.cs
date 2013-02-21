using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Master;
using MiBo.Domain.Web.Client.Master;
using MiBo.Domain.Common.Utils;

namespace MiBo.pages.common
{
    public partial class client : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptToyMenu.DataSource = response.ListToys;
            rptToyMenu.DataBind();
            rptAccessoryMenu.DataSource = response.ListAccessories;
            rptAccessoryMenu.DataBind();
            lblCartCount.Text = response.CartCount;
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.Cart = Session["Cart"];
                return request;
            }
        }
    }
}