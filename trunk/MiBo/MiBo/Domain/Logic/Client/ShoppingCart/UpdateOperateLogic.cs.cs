using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class UpdateOperateLogic : IOperateLogic<UpdateResponseModel>
    {
        public UpdateResponseModel Invoke(object obj)
        {
            var logic = new UpdateLogic();

            return logic.Invoke((UpdateRequestModel)obj);
        }
    }
}