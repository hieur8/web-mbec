using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
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