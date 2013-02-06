using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class DeleteOperateLogic : IOperateLogic<DeleteResponseModel>
    {
        public DeleteResponseModel Invoke(object obj)
        {
            var logic = new DeleteLogic();

            return logic.Invoke((DeleteRequestModel)obj);
        }
    }
}