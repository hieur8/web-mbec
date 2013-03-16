namespace MiBo.Domain.Model.Admin.UserChangePassword
{
    public class SaveDataModel
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}