using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.BannerEntry
{
    public class SaveRequestModel
    {
        public string Status { get; set; }
        [ValidRequired(MessageParam = "Mã banner")]
        public string BannerCd { get; set; }
        [ValidRequired(MessageParam = "Tên banner")]
        public string BannerName { get; set; }
        [ValidRequired(MessageParam = "Mã hình ảnh")]
        public string FileId { get; set; }
        [ValidRequired(MessageParam = "Nhóm khuyến mãi")]
        public string OfferGroupCd { get; set; }
        public string SortKey { get; set; }
        public string DeleteFlag { get; set; }
    }
}