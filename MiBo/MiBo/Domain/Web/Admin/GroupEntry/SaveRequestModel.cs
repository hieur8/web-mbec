using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.GroupEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã nhóm")]
        public string GroupCd { get; set; }
        [ValidRequired(MessageParam = "Tên nhóm")]
        public string GroupName { get; set; }
        [ValidRequired(MessageParam = "Thứ tự")]
        public string SortKey { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }
    }
}