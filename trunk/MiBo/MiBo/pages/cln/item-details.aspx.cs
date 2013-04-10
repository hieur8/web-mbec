using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;

namespace MiBo.pages.cln
{
    public partial class item_details : BasePage
    {
        public string firstImage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            fvwItemDetails.DataSource = response.Details;
            fvwItemDetails.DataBind();
            firstImage = response.Details[0].ListImages[0].ItemImage;
        }

        protected void lnkBuy_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var buyLogic = new BuyOperateLogic();
            var responseModel = Invoke(buyLogic, BuyRequestModel);
            if (HasError) return;
            Session["Cart"] = responseModel.Cart;
            Session["haveBuy"] = true;
            Response.Redirect(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
        }

        protected void lnkBuyNow_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var buyLogic = new BuyOperateLogic();
            var responseModel = Invoke(buyLogic, BuyRequestModel);
            if (HasError) return;
            Session["Cart"] = responseModel.Cart;
            Session["haveBuy"] = true;
            Response.Redirect("shopping-cart.aspx");
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.ItemCd = Request["pid"];
                return request;
            }
        }

        private BuyRequestModel BuyRequestModel
        {
            get
            {
                var requestModel = new BuyRequestModel();
                requestModel.ItemCd = Convert.ToString(Session["ItemCd"]);
                requestModel.ItemQtty = ((TextBox)fvwItemDetails.FindControl("txtItemQtty")).Text;
                requestModel.Cart = Session["Cart"];
                Session["ItemCd"] = null;
                return requestModel;
            }
        }
    }
}