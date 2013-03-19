﻿using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Master;
using MiBo.Domain.Web.Client.Master;
using MiBo.Domain.Common.Utils;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.common
{
    public partial class client : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            
            rptAccessoryMenu.DataSource = response.ListAccessories;
            rptAccessoryMenu.DataBind();
            RepeaterBrands.DataSource = response.ListAccessories;
            RepeaterBrands.DataBind();
            RepeaterAge.DataSource = response.ListAges;
            RepeaterAge.DataBind();
            RepeaterGender.DataSource = response.ListGenders;
            RepeaterGender.DataBind();
            RepeaterToy.DataSource = response.ListToys;
            RepeaterToy.DataBind();
                   
                

                
            if (response.CartCount.Equals(""))
            {
                lblCartCount.Text = "0";
            }
            else
            {
                lblCartCount.Text = response.CartCount;
            }

            
            var initLogic = new MiBo.Domain.Logic.Client.ShoppingCart.InitOperateLogic();
            var responseModel2 = Invoke(initLogic, InitRequestModel2);
            if (HasError) return;
            rptCartItem.DataSource = responseModel2.ListItems;
            rptCartItem.DataBind();
            LiteralAmount.Text = responseModel2.TotalAmount;
            
        }
        private MiBo.Domain.Web.Client.ShoppingCart.InitRequestModel InitRequestModel2
        {
            get
            {
                var requestModel = new MiBo.Domain.Web.Client.ShoppingCart.InitRequestModel();
                requestModel.Cart = Session["Cart"];
                return requestModel;
            }
        }
        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            Session["ItemCd"] = e.CommandArgument;
            var deleteLogic = new MiBo.Domain.Logic.Client.ShoppingCart.DeleteOperateLogic();
            var responseModel = Invoke(deleteLogic, DeleteRequestModel);
            if (HasError) return;
            Session["Cart"] = responseModel.Cart;
            Response.Redirect(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
        
        }
        private MiBo.Domain.Web.Client.ShoppingCart.DeleteRequestModel DeleteRequestModel
        {
            get
            {
                var requestModel = new MiBo.Domain.Web.Client.ShoppingCart.DeleteRequestModel();
                requestModel.ItemCd = Convert.ToString(Session["ItemCd"]);
                requestModel.Cart = Session["Cart"];
                Session["ItemCd"] = null;
                return requestModel;
            }
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
    }
}