using System;
using System.Collections.Generic;
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
            if (HasError) return;
            rptCartItem.DataSource = responseModel.ListItems;
            rptCartItem.DataBind();
            rptOfferItems.DataSource = responseModel.ListOfferItems;
            rptOfferItems.DataBind();
            lblSubTotal.Text = responseModel.TotalAmount;
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
    }
}