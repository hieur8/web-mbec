using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.ShoppingCart;

namespace MiBo.Domain.Logic.Client.ShoppingCart
{
    public class GiftOperateLogic : IOperateLogic<GiftResponseModel>
    {
        public GiftResponseModel Invoke(object obj)
        {
            var logic = new GiftLogic();

            return logic.Invoke((GiftRequestModel)obj);
        }
    }
}