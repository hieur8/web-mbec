using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Register;

namespace MiBo.Domain.Logic.Client.Register
{
    public class RegisterOperateLogic : IOperateLogic<RegisterResponseModel>
    {
        public RegisterResponseModel Invoke(object obj)
        {
            var logic = new RegisterLogic();

            return logic.Invoke((RegisterRequestModel)obj);
        }
    }
}