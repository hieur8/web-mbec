using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Login
{
    public class LoginResponseModel : MessageResponse
    {
        public bool StatusFlag { get; set; }
        public string UserName { get; set; }
        
    }
}