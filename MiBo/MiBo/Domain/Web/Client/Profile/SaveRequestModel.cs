namespace MiBo.Domain.Web.Client.Profile
{
    public class SaveRequestModel
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public bool HasNewsletter { get; set; }
        public bool HasChagngePassword { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConf { get; set; }
    }
}