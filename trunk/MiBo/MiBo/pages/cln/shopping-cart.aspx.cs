using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.ShoppingCart;
using MiBo.Domain.Web.Client.ShoppingCart;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Helper;
using Resources;

namespace MiBo.pages.cln
{
    public partial class shopping_cart : BasePage
    {
        public decimal giftPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var initLogic = new InitOperateLogic();
            var responseModel = Invoke(initLogic, InitRequestModel);
            if (HasError) return;
            rptCartItem.DataSource = responseModel.ListItems;
            rptCartItem.DataBind();
            rptOfferItems.DataSource = responseModel.ListOfferItems;
            rptOfferItems.DataBind();
            lblSubTotal.Text = responseModel.TotalAmount;
            Label1.Text = "0";
            if (responseModel.TotalAmountDecimal > 100000)
            {
                Label1.Text = (responseModel.TotalAmountDecimal * 10 / 100).ToString();
            }
            if (Session["GiftCd"] != null)
            {
                LblGiftPrice.Text = DataHelper.ToString(Formats.NUMBER, (decimal)Session["GiftPrice"]);
                decimal total = responseModel.TotalAmountDecimal - decimal.Parse(Session["GiftPrice"].ToString());
                LblTotalPrice.Text = DataHelper.ToString(Formats.NUMBER, total);
                if (total > 100000)
                {
                    Label1.Text = (total * 10 / 100).ToString();
                }
            }
            else
            {
                LblTotalPrice.Text = responseModel.TotalAmount;
            }
        }

        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var deleteLogic = new DeleteOperateLogic();
            var responseModel = Invoke(deleteLogic, DeleteRequestModel);
            if (HasError) return;
            Session["Cart"] = responseModel.Cart;
            Refresh();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateLogic = new UpdateOperateLogic();
            var responseModel = Invoke(updateLogic, UpdateRequestModel);
            if (HasError) return;
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

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputItemModel item = null;
                var requestModel = new UpdateRequestModel();
                var listItems = new List<OutputItemModel>();

                foreach (RepeaterItem row in rptCartItem.Items)
                {
                    item = new OutputItemModel();
                    item.ItemCd = ((HiddenField)row.FindControl("hidItemCd")).Value;
                    item.Quantity = ((TextBox)row.FindControl("txtItemQtty")).Text;
                    listItems.Add(item);
                }

                requestModel.ListItems = listItems;
                requestModel.Cart = Session["Cart"];
                return requestModel;
            }
        }

        protected void HyperLinkTT_Click(object sender, EventArgs e)
        {
            if (Session["Cart"] != null)
            {
                if (Session["userCd"] == null)
                {
                    Response.Redirect("confirmcheckout.aspx");

                }
                else
                {
                    Session["payMethod"] = "1";
                    Response.Redirect(Pages.CLIENT_CHECKOUT);
                }
            }
        }

        protected void LinkButtonCon_Click(object sender, EventArgs e)
        {
            Response.Redirect(Pages.CLIENT_INDEX);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var giftLogic = new GiftOperateLogic();
            var responseModel = Invoke(giftLogic, GiftRequestModel);
            if (HasError) return;

            if (responseModel.IsExit)
            {
                Session["GiftCd"] = responseModel.GiftCd;
                Session["GiftPrice"] = responseModel.Price;
                Session["info"] = "Gift Card " + responseModel.GiftCd + " đã được thêm vào giò hàng của bạn";
                Response.Redirect("shopping-cart.aspx");
            }
            else
            {
                Session["error"] = "Gift Card bạn nhập không đúng hoặc đã hết hạn, xin vui lòng kiểm tra lại !";
            }

        }
        private GiftRequestModel GiftRequestModel
        {
            get
            {
                var requestModel = new GiftRequestModel();
                requestModel.GiftCd = txtGift.Text.Trim();
                return requestModel;
            }
        }
    }
}