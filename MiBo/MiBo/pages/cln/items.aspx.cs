using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Items;
using MiBo.Domain.Web.Client.Items;
using System.Collections.Generic;

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

            var totalPageNumber = response.ListItems.TotalPageNumber;
            if (totalPageNumber > 5)
                totalPageNumber = 5;

            var listPager = new List<int>();
            var start = response.ListItems.CurrentPageNumber - 2;
            var end = response.ListItems.CurrentPageNumber + 2;
            if (start < 1)
                start = 1;
            if (end > response.ListItems.TotalPageNumber)
                end = (int)response.ListItems.TotalPageNumber;

            if (response.ListItems.IsExistPrePage)
            {
                listPager.Add(1);
                listPager.Add(response.ListItems.CurrentPageNumber - 1);
            }
            
            for (int i = 1; i <= totalPageNumber; i++)
            {
                
            }
            if (response.ListItems.IsExistNextPage)
            {
                listPager.Add(response.ListItems.CurrentPageNumber + 1);
                listPager.Add((int)response.ListItems.TotalPageNumber);
            }


            "<<   <   2   3   4   5   6   >   >>".Clone();
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
                request.SearchText = Request["pnm"];
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