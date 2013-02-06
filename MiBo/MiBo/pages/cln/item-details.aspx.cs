using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;

namespace MiBo.pages.cln
{
    public partial class item_details : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (response == null) Redirect("index.aspx");

            // Set value
            hidItemCd.Value = response.ItemCd;
            hidItemDiv.Value = response.ItemDiv;
            hidOfferDiv.Value = response.OfferDiv;

            litItemName.Text = response.ItemName;
            imgItemImage.ImageUrl = string.Format("/pages/media/images/items/{0}/larger/{1}", response.ItemCd, response.ItemImage);
            rptItemImage.DataSource = response.ListImages;
            rptItemImage.DataBind();
            litPrice.Text = response.Price;
            litPriceOld.Text = response.PriceOld;
            litNotes.Text = response.Notes;
            rptOfferItems.DataSource = response.ListOfferItems;
            rptOfferItems.DataBind();
        }

        protected void lnkBuy_Command(object sender, CommandEventArgs e)
        {
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
                request.ItemCd = Request["pid"];
                return request;
            }
        }

        private BuyRequestModel BuyRequestModel
        {
            get
            {
                var requestModel = new BuyRequestModel();
                requestModel.ItemCd = Convert.ToString(hidItemCd.Value);
                requestModel.ItemQtty = Convert.ToString(txtItemQtty.Text);
                requestModel.Cart = Session["Cart"];
                return requestModel;
            }
        }
    }
}