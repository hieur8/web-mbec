using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Index;
using MiBo.Domain.Web.Client.Index;

namespace MiBo.pages.cln
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            litHotline.Text = response.Hotline;
            rptBanner.DataSource = response.ListBanners;
            rptBanner.DataBind();
            rptNewItem.DataSource = response.ListNewItems;
            rptNewItem.DataBind();
            rptOfferItem.DataSource = response.ListOfferItems;
            rptOfferItem.DataBind();
            rptHotItem.DataSource = response.ListHotItems;
            rptHotItem.DataBind();
        }

        protected void lnkBuy_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var buyLogic = new BuyOperateLogic();
            var responseModel = Invoke(buyLogic, BuyRequestModel);
            if (HasError) return;
            Session["Cart"] = responseModel.Cart;
            Redirect(Pages.CLIENT_INDEX);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                return request;
            }
        }

        private BuyRequestModel BuyRequestModel
        {
            get
            {
                var requestModel = new BuyRequestModel();
                requestModel.ItemCd = Convert.ToString(Session["ItemCd"]);
                requestModel.ItemQtty = Convert.ToString("1");
                requestModel.Cart = Session["Cart"];
                Session["ItemCd"] = null;
                return requestModel;
            }
        }
    }
}