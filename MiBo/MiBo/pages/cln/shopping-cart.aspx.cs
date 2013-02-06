using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.pages.cln
{
    public partial class shopping_cart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var initLogic = new InitOperateLogic();
            var responseModel = Invoke(initLogic, InitRequestModel);

            rptCartItem.DataSource = responseModel.ListItems;
            rptCartItem.DataBind();

            lblSubTotal.Text = responseModel.TotalAmount;
        }

        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var deleteLogic = new DeleteOperateLogic();
            var responseModel = Invoke(deleteLogic, DeleteRequestModel);
            Session["Cart"] = responseModel.Cart;
            Refresh();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                requestModel.Cart = Session["Cart"];
                return requestModel;
            }
        }

        private DeleteRequestModel DeleteRequestModel
        {
            get
            {
                var requestModel = new DeleteRequestModel();
                requestModel.ItemCd = Convert.ToString(Session["ItemCd"]);
                requestModel.Cart = Session["Cart"];
                Session["ItemCd"] = null;
                return requestModel;
            }
        }
    }
}