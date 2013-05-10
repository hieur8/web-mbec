using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.OfferItemEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã khuyến mãi")]
        public string OfferCd { get; set; }
        [ValidRequired(MessageParam = "Mã sản phẩm")]
        public string OfferItemCd { get; set; }
        [ValidRequired(MessageParam = "Số lượng")]
        public string OfferItemQtty { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }
    }
}