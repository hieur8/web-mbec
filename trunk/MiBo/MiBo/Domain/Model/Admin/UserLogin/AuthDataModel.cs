using System;

namespace MiBo.Domain.Model.Admin.UserLogin
{
    public class AuthDataModel
    {
        public Guid UserCd { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}