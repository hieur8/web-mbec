using MiBo.Domain.Common.Model;
using System.Collections.Generic;

namespace MiBo.Domain.Model.Client.Items
{
    public class InitDataModel : PagerSupport
    {
        // Request
        public string SearchText { get; set; }
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string PriceCd { get; set; }
        public string ShowCd { get; set; }

        // Response
        public PagerResult<ItemModel> ListItems { get; set; }
        public string Title { get; set; }
        public decimal? DiscountMember { get; set; }
        public string Hotline { get; set; }
        public string ChatYahoo { get; set; }
        public string ChatSkype { get; set; }
    }
}