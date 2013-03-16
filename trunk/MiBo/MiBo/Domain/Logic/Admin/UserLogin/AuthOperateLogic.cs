using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UserLogin;

namespace MiBo.Domain.Logic.Admin.UserLogin
{
    public class AuthOperateLogic : IOperateLogic<AuthResponseModel>
    {
        public AuthResponseModel Invoke(object obj)
        {
            var logic = new AuthLogic();

            return logic.Invoke((AuthRequestModel)obj);
        }
    }
}