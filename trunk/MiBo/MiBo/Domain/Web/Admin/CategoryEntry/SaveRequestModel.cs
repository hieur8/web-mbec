using MiBo.Domain.Common.Validate;
namespace MiBo.Domain.Web.Admin.CategoryEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã loại")]
        public string CategoryCd { get; set; }
        [ValidRequired(MessageParam = "Tên loại")]
        public string CategoryName { get; set; }
        [ValidRequired(MessageParam = "Tên tìm kiếm")]
        public string CategorySearchName { get; set; }
        [ValidRequired(MessageParam = "Chủng loại")]
        public string CategoryDiv { get; set; }
        [ValidRequired(MessageParam = "Thứ tự")]
        public string SortKey { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }
    }
}