using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.UserChangePassword
{
    public class SaveRequestModel
    {
        [ValidRequired(MessageParam = "Mật khẩu")]
        public string Password { get; set; }
        [ValidRequired(MessageParam = "Mật khẩu mới")]
        public string NewPassword { get; set; }
        [ValidRequired(MessageParam = "Mật khẩu xác nhận")]
        public string NewPasswordConfirm { get; set; }
    }
}