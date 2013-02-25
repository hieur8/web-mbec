﻿using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Items;
using MiBo.Domain.Web.Client.Items;

namespace MiBo.pages.cln
{
    public partial class items : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptItem.DataSource = response.ListItems;
            rptItem.DataBind();
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
                request.CategoryCd = Request["category"];
                request.AgeCd = Request["age"];
                request.GenderCd = Request["gender"];
                request.BrandCd = Request["brand"];
                request.PriceCd = Request["price"];
                request.ShowCd = Request["show"];
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