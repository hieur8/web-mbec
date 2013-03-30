using System;
namespace MiBo.Domain.Model.Client.Register
{
    public class SaveDataModel
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public Guid UserCd { get; set; }
    }
}