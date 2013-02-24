namespace MiBo.Domain.Web.Client.Profile
{
    public class SaveRequestModel
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public string HasNewsletter { get; set; }
        public string HasChangePassword { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConf { get; set; }
    }
}