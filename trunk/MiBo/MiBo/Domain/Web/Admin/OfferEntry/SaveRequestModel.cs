using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.OfferEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã khuyến mãi")]
        public string OfferCd { get; set; }
        [ValidRequired(MessageParam = "Mã sản phẩm")]
        public string ItemCd { get; set; }
        [ValidRequired(MessageParam = "Ngày bắt đầu")]
        public string StartDate { get; set; }
        [ValidRequired(MessageParam = "Ngày kết thúc")]
        public string EndDate { get; set; }
        [ValidRequired(MessageParam = "Loại khuyến mãi")]
        public string OfferDiv { get; set; }
        [ValidRequired(MessageParam = "Giảm (%)")]
        public string Percent { get; set; }
        public string Notes { get; set; }
    }
}