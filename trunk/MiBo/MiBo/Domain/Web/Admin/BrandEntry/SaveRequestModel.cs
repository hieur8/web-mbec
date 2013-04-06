using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.BrandEntry
{
    public class SaveRequestModel
    {
        public string Status { get; set; }
        [ValidRequired(MessageParam = "Mã thương hiệu")]
        public string BrandCd { get; set; }
        [ValidRequired(MessageParam = "Tên thương hiệu")]
        public string BrandName { get; set; }
        [ValidRequired(MessageParam = "Tên tìm kiếm")]
        public string BrandSearchName { get; set; }
        [ValidRequired(MessageParam = "Mã hình ảnh")]
        public string FileId { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }

        public string Notes { get; set; }
        public string SortKey { get; set; }
    }
}