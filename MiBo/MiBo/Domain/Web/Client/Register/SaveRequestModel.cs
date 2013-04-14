namespace MiBo.Domain.Web.Client.Register
{
    public class SaveRequestModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string CityCd { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
    }
}