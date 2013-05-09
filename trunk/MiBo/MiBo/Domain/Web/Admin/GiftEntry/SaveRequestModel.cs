using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.GiftEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã thẻ")]
        public string GiftCd { get; set; }
        [ValidRequired(MessageParam = "Số tiền")]
        public string Price { get; set; }
        [ValidRequired(MessageParam = "Ngày bắt đầu")]
        public string StartDate { get; set; }
        [ValidRequired(MessageParam = "Ngày kết thúc")]
        public string EndDate { get; set; }
        public string Notes { get; set; }
    }
}