using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.GroupRoleEntry
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mã nhóm")]
        public string GroupCd { get; set; }
        [ValidRequired(MessageParam = "Mã quyền")]
        public string RoleCd { get; set; }
        [ValidRequired(MessageParam = "Dữ liệu")]
        public string DeleteFlag { get; set; }
    }
}