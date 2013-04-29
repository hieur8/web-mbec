using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.UserEntry
{
    public class SaveRequestModel
    {
        public string Status { get; set; }
        public string UserCd { get; set; }
        [ValidRequired(MessageParam = "Tên đăng nhập")]
        public string Email { get; set; }
        [ValidRequired(MessageParam = "Họ tên")]
        public string FullName { get; set; }
        public string Address { get; set; }
        [ValidRequired(MessageParam = "Mã tỉnh thành")]
        public string CityCd { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string DeleteFlag { get; set; }
        [ValidRequired(MessageParam = "Mã nhóm")]
        public string GroupCd { get; set; }
    }
}