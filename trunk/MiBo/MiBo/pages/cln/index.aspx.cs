using System;
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

            rptBanner.DataSource = response.ListBanners;
            rptBanner.DataBind();
            rptNewItem.DataSource = response.ListNewItems;
            rptNewItem.DataBind();
            rptOfferItem.DataSource = response.ListOfferItems;
            rptOfferItem.DataBind();
            rptHotItem.DataSource = response.ListHotItems;
            rptHotItem.DataBind();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                return request;
            }
        }
    }
}