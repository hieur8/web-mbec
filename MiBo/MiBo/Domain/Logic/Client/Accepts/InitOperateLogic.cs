using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Accepts;

namespace MiBo.Domain.Logic.Client.Accepts
{
    public class InitOperateLogic : IOperateLogic<InitResponseModel>
    {
        public InitResponseModel Invoke(object obj)
        {
            var logic = new InitLogic();

            return logic.Invoke((InitRequestModel)obj);
        }
    }
}