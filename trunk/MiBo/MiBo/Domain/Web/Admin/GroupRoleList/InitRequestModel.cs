using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.GroupRoleList
{
    public class InitRequestModel
    {
        [ValidRequired(MessageParam = "Mã nhóm")]
        public string GroupCd { get; set; }
    }
}