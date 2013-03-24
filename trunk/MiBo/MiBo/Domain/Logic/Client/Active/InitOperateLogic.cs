using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Active;

namespace MiBo.Domain.Logic.Client.Active
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