using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Index;
using MiBo.Domain.Web.Client.Login;

namespace MiBo.Domain.Logic.Client.Login
{
    public class LoginOperateLogic : IOperateLogic<LoginResponseModel>
    {
        public LoginResponseModel Invoke(object obj)
        {
            var logic = new LoginLogic();

            return logic.Invoke((LoginRequestModel)obj);
        }
    }
}