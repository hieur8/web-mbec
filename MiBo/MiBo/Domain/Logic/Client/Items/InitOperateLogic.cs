using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Items;

namespace MiBo.Domain.Logic.Client.Items
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