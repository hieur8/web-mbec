using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Index;
using MiBo.Domain.Web.Client.Index;
using System.Web.UI.WebControls;

namespace MiBo.pages.cln
{
    public partial class index : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
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
            Redirect("index.aspx");
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