namespace MiBo.Domain.Web.Client.Register
{
    public class RegisterRequestModel
    {
        public string email { get; set; }
        public string fullname { get; set; }
        public string pass { get; set; }
        public bool isSendEmail { get; set; }
    }
}