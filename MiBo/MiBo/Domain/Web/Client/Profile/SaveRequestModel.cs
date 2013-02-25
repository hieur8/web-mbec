using MiBo.Domain.Common.Validate;
namespace MiBo.Domain.Web.Client.Profile
{
    public class SaveRequestModel
    {
        public string Address { get; set; }
        [ValidRequired(MessageParam = "Họ và tên")]
        public string FullName { get; set; }
        public bool HasNewsletter { get; set; }
        public bool HasChangePassword { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConf { get; set; }
    }
}