namespace MiBo.Domain.Model.Client.Profile
{
    public class SaveDataModel
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public bool HasNewsletter { get; set; }
        public bool HasChangePassword { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConf { get; set; }
    }
}