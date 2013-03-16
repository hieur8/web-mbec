using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.UserLogin
{
    public class AuthResponseModel : MessageResponse
    {
        public string UserCd { get; set; }
        public string UserName { get; set; }
    }
}